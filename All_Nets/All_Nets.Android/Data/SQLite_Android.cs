using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using All_Nets.Data;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Xamarin.Forms;
using All_Nets.Droid.Assets.Data;

namespace All_Nets.Droid.Assets.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
            public SQLite.SQLiteConnection GetConnection()
                { 
            var sqliteFileName = "TestAN.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
                }
    }
}