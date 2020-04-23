using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace All_Nets
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private int count = 0;
        void SignUp(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You won {count} times!";

        }
        void LogIn(object sender, System.EventArgs e)
        {
           
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
