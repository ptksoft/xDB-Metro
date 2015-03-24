using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Newtonsoft.Json;

namespace xDB2013
{
    public class JsonRpcRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public object @params { get; set; }
        public int id { get; set; }
    }

    public class ptkJRPC
    {
        private static int iKey = 0;
        private static Hashtable hTricker = Hashtable.Synchronized(new Hashtable());
        private static Hashtable hReturn = Hashtable.Synchronized(new Hashtable());

        public const string KwJsonRpc = "jsonrpc";
        public const string kwMethod = "method";
        public const string KwParams = "params";
        public const string KwId = "id";

        public const string KwResult = "result";
        public const string KwError = "error";
        public const string kwErrCode = "code";
        public const string kwErrMessage = "message";
        public const string kwErrData = "data";

        public static ManualResetEvent RegisterRpcRequest(Hashtable hJRPC)
        {
            int myKey = 0;
            ManualResetEvent myTricker = new ManualResetEvent(false);
            lock (hTricker.SyncRoot)
            {
                iKey++; if (iKey >= int.MaxValue) iKey = 1;
                myKey = iKey;
                hTricker[myKey] = myTricker;
            }
            lock (hJRPC.SyncRoot) { hJRPC[KwId] = myKey; }
            lock (hReturn.SyncRoot)
            {
                hReturn[myKey] = hJRPC;
            }
            return (myTricker);
        }
        public static int RegisterRPC(Hashtable hJRPC)
        {
            int iKeyNow = 0;
            lock (hTricker.SyncRoot)
            {
                iKey++; if (iKey >= int.MaxValue) iKey = 1;
                iKeyNow = iKey;
                hTricker[iKeyNow] = new ManualResetEvent(false);
            }
            lock (hReturn.SyncRoot)
            {
                hReturn[iKeyNow] = Queue.Synchronized(new Queue());
            }
            return (iKeyNow);
        }
        public static ManualResetEvent GetTricker(int k)
        {
            lock (hTricker.SyncRoot)
            {
                return ((ManualResetEvent)hTricker[k]);
            }
        }
        //public static bool SetReturnAndTricking(Hashtable hJRPC
    }
}
