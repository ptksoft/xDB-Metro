using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

using PTKSOFT.Network2;
using PTKSOFT.Utils2;
using ZiCure.Log;
using Newtonsoft.Json;

namespace xDB2013
{   // Peer TO Peer Class Working Stuff

    [Serializable]
    public class PeerProfile
    {
        public string PeerID { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public string Version { get; set; }
        public long TotalProfile { get; set; }
        public string UpdateTime { get; set; }

        public PeerProfile(string hostName, string ipAddress, string version, long totalProfile)
        {
            this.PeerID = ptkConvert.Md5String(hostName + ipAddress);
            this.HostName = hostName;
            this.IpAddress = ipAddress;
            this.Version = version;
            this.TotalProfile = totalProfile;
            this.UpdateTime = ptkGeneral.GetTodayDateTimeSqlFormat();
        }
    }

    [Serializable]
    public class PeerDataMessage
    {
        public PacketUDP packet { get; set; }
        public Hashtable hData { get; set; }
        public bool isResponse { get; set; }
        public PeerDataMessage(PacketUDP pk, Hashtable hd, bool ir)
        {
            this.packet = pk;
            this.hData = hd;
            this.isResponse = ir;
        }
    }

    //----------------------------------------------------------------------------//
    public class P2P    
    {
        //--------------------------------------- Public Var
        public static bool IsTerminate = false;
        public static ptkUdpService UDP = null;
        public static Hashtable hPeerProfile = Hashtable.Synchronized(new Hashtable());

        //--------------------------------------- Private Var
        private const int P2P_PORT = 6969;
        private static Queue queDataMessage = Queue.Synchronized(new Queue());
        private static ManualResetEvent trickDataMessage = new ManualResetEvent(false);
        private static Thread thrProcessDataMessage = null;
        private static Thread thrSendPeerProfile = null;
        private static PeerProfile myProfile = null;

        //--------------------------------------- Public Method
        public static bool Initialize()
        {
            zLog.Write("P2P->Initialize(): Create UdpService on Port=" + P2P_PORT.ToString());
            P2P.UDP = new ptkUdpService(P2P_PORT);
            zLog.Write("Create UdpService: " + ((P2P.UDP.IsReady)?("Success"):("Fail!!!")));

            if (P2P.UDP.IsReady)
            {
                P2P.UDP.OnPacketUdpArrival += new WhenPacketUdpArrival(_OnPacketUdpAttrival);
                
                P2P.thrProcessDataMessage = new Thread(new ThreadStart(_ThreadProcess_DataMessage));
                P2P.thrProcessDataMessage.Name = "P2P.ProcessDataMessage";
                P2P.thrProcessDataMessage.IsBackground = true;
                P2P.thrProcessDataMessage.Priority = ThreadPriority.AboveNormal;
                P2P.thrProcessDataMessage.Start();

                P2P.myProfile = new PeerProfile(
                                    System.Environment.MachineName, 
                                    "255.255.255.255", 
                                    that.VersionOnly(), 
                                    0
                                );

                P2P.thrSendPeerProfile = new Thread(new ThreadStart(_ThreadSendPeerProfile));
                P2P.thrSendPeerProfile.Name = "P2P.SendPeerProfile";
                P2P.thrSendPeerProfile.IsBackground = true;
                P2P.thrSendPeerProfile.Priority = ThreadPriority.BelowNormal;
                P2P.thrSendPeerProfile.Start();
                
                return (true);
            }
            else
                return (false);
        }
        public static void Terminate()
        {
            zLog.Write("Begin P2P.Terminate()...");
            P2P.IsTerminate = true;
            if (!(P2P.UDP == null)) P2P.UDP.Terminate();
                        
            if (P2P.thrProcessDataMessage != null) P2P.thrProcessDataMessage.Join();
            if (P2P.thrSendPeerProfile != null) P2P.thrSendPeerProfile.Join();
        }
        
        //--------------------------------------- Private Method
        private static void _OnPacketUdpAttrival(PacketUDP packet)
        {
            if (P2P.IsTerminate) return;
            that.DebugAndLog("PacketUDP Arrvial from: " + packet.IpAddress + ":" + packet.Port.ToString());

            /* PreCheck if packet is JsonRPC or NOT? */
            Hashtable hData = null;
            bool isResponse = false;
            try
            {
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.MaxDepth = 1;
                hData = JsonConvert.DeserializeObject<Hashtable>(
                            Encoding.Default.GetString(packet.DataByteArray), 
                            jsetting);

                // Check Protocol Version
                if (!hData.Contains(KW.JsonRpc)) return;
                if (!hData[KW.JsonRpc].ToString().Trim().Equals(KW.RpcVersion20)) return;

                // Check ID
                if (!hData.Contains(KW.ID)) return;
                int id = int.Parse((string)hData[KW.ID]); if (id < 0) return;

                // Check Param or Result
                if (!hData.Contains(KW.Method))
                    if (!hData.Contains(KW.Result)) { return; } else { isResponse = true; } // Response Must have Result
                else
                    if (!hData.Contains(KW.Params)) { return; } else { isResponse = false; } // Method Must have Param
            }
            catch (Exception ex) {
                that.DebugAndLog("Cannot decode packet to HashingTable");
                that.DebugAndLog(ex.Message);
                return; 
            }

            // Evertything OK, Can Push This Data/Packet to process
            that.DebugAndLog("Push PeerDataMessage to ProcessQueue");
            lock (queDataMessage.SyncRoot)
            {
                queDataMessage.Enqueue(new PeerDataMessage(packet, hData, isResponse));
                trickDataMessage.Set();
            }
        }

        private static void _ThreadSendPeerProfile()
        {
            zLog.Write("Starting ... Thread");
            
            int countTime = 0;
            int stepTime = 100;     // Step Increase (Millisecond)
            int limitTime = 5000;   // 5 Second (Millisecond)

            while (!P2P.IsTerminate)
            {
                if (countTime >= limitTime)
                {
                    P2P.myProfile.UpdateTime = ptkGeneral.GetTodayDateTimeSqlFormat();
                    P2P.myProfile.TotalProfile = MovieDB.hMovie.Count;
                    string strParam = JsonConvert.SerializeObject(P2P.myProfile);
                    
                    Hashtable hMessage = new Hashtable();
                    hMessage[KW.JsonRpc] = KW.RpcVersion20;
                    hMessage[KW.ID] = "0";
                    hMessage[KW.Method] = KW.NotifyPeerProfile;
                    hMessage[KW.Params] = strParam;
                    //hMessage[KW.Params] = "";
                    
                    string strData = JsonConvert.SerializeObject(hMessage);
                    byte[] abData = Encoding.Default.GetBytes(strData);
                    string[] ipBCast = ptkNetTool.GetLocalIpV4BroadCastList();

                    for (int i = 0; i < ipBCast.Length; i++)
                    {
                        P2P.UDP.Send(
                            new PacketUDP(
                                abData,
                                new IPEndPoint(IPAddress.Parse(ipBCast[i]), P2P.P2P_PORT)
                            )
                        );
                    }
                    P2P.UDP.Send(
                            new PacketUDP(
                                abData,
                                new IPEndPoint(IPAddress.Parse("192.168.1.41"),P2P.P2P_PORT)
                            )
                        );

                    countTime = 0;
                    continue;
                }
                Thread.Sleep(stepTime);
                countTime += stepTime;
            }

            zLog.Write("Terminate ... Thread");
        }
        
        private static void _ThreadProcess_DataMessage()
        {
            zLog.Write("Starting ... Thread");
            
            int countMessage = 0;
            PeerDataMessage pdm = null;

            while (!P2P.IsTerminate)
            {
                lock (P2P.queDataMessage.SyncRoot) { countMessage = P2P.queDataMessage.Count; }
                if (countMessage < 1)
                {
                    P2P.trickDataMessage.WaitOne(100, true);
                    P2P.trickDataMessage.Reset();
                    continue;
                }

                lock (P2P.queDataMessage.SyncRoot) { pdm = (PeerDataMessage)P2P.queDataMessage.Dequeue(); }
                if (pdm.isResponse)
                    __Process_DataMessage_Response(pdm);
                else
                    __Process_DataMessage_Request(pdm);
            }

            zLog.Write("Terminate ... Thread");
        }
        private static void __Process_DataMessage_Request(PeerDataMessage pdm)
        {
            string method = ((string)pdm.hData[KW.Method]).Trim().ToLower();
            switch (method)
            {
                case KW.NotifyPeerProfile: ___AddOrUpdate_PeerProfile(pdm); break;
            }
        }
        private static void ___AddOrUpdate_PeerProfile(PeerDataMessage pdm)
        {
            try
            {
                PeerProfile pp = JsonConvert.DeserializeObject<PeerProfile>((string)pdm.hData[KW.Params]);
                pp.IpAddress = pdm.packet.IpAddress;    // Get Real IP Address
                PeerProfile pp_now = null;

                lock (hPeerProfile.SyncRoot)
                {
                    if (hPeerProfile.Contains(pp.PeerID))
                    {
                        pp_now = (PeerProfile)hPeerProfile[pp.PeerID];

                        pp_now.TotalProfile = pp.TotalProfile;
                        pp_now.Version = pp.Version;
                        pp_now.UpdateTime = pp.UpdateTime;
                        
                        that.DebugAndLog("Update Existing PeerProfile ID=" + pp.PeerID);
                        pp = null;      // Dispose Memory
                    }
                    else
                    {
                        hPeerProfile[pp.PeerID] = pp;   // Link this memory to hPeerProfile
                        that.DebugAndLog("Add New PeerProfile ID=" + pp.PeerID);
                    }
                }
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Invalid JSON->PeerProfile: " + ex.Message);
            }
        }
        private static void __Process_DataMessage_Response(PeerDataMessage pdm)
        {

        }        
        
    }
}
