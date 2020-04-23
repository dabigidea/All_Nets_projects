using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace All_Nets.Models
{
    public class Constants
    {
        public static bool ISDev = true;

        public static Color BackgroundColor = Color.FromRgb(0, 0, 0);
        public static Color MainTextColor = Color.White;


        public static int LoginIconHeight = 250;

        //---Login--------------------
        public static string loginUrl = "https://test.com/api/auth/login";

        public static string NoInternetText = "No Internet, please reconnect";
    }
}
