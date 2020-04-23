using System;
using All_Nets.Data;
using Android.App;
using Android.Content;
using Android.Net;
using All_Nets.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]

namespace All_Nets.Droid.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected {get; set; }

        public bool IsConnection => throw new NotImplementedException();

        [Obsolete]
        public void CheckNetworkConnection()
        {
            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;
            if(ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }

        }
    }
}