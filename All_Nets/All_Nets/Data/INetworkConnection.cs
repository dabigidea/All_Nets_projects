using System;
using System.Collections.Generic;
using System.Text;

namespace All_Nets.Data
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();
    }
}
