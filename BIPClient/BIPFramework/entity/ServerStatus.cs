using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.system.monitor.mapper
{
    [Serializable]
    public class ServerStatus
    {
        private bool serverNetworking;

        public bool ServerNetworking
        {
            get { return serverNetworking; }
            set { serverNetworking = value; }
        }
        private bool appRunning;

        public bool AppRunning
        {
            get { return appRunning; }
            set { appRunning = value; }
        }
        private bool databaseConnecting;

        public bool DatabaseConnecting
        {
            get { return databaseConnecting; }
            set { databaseConnecting = value; }
        }

        public void AllGood()
        {
            serverNetworking = true;
            appRunning = true;
            databaseConnecting = true;
        }
    }
}
