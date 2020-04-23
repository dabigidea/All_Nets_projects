using All_Nets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_Nets.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace All_Nets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();

            void Init()
            {
                BackgroundColor = Constants.BackgroundColor;
                Lbl_Username.TextColor = Constants.MainTextColor;
                Lbl_Password.TextColor = Constants.MainTextColor;
                ActivitySpinner.IsVisible = false;
                LoginIcon.HeightRequest = Constants.LoginIconHeight;
                App.StartCheckIfInternet(lbl_NoInternet, this);



                Entry_Username.Completed += (s, e) => Entry_Password.Focus();
                Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
            }

            async void SignInProcedure(object sender, EventArgs e)
            {
                User user = new User(Entry_Username.Text, Entry_Password.Text);
                if (user.CheckInformation())
                {
                    await DisplayAlert("Login", "Login Success", "OK");
                    var result = await App.RestService.Login(user);
                    if (result != null)
                    {
                        App.UserDatabase.SaveUser(user);
                    }
                    App.UserDatabase.SaveUser(user);
                }
                else
                {
                    await DisplayAlert("Login", "Login Not Correct, empty username or password.", "OK");
                }
            }
        }
    }
}