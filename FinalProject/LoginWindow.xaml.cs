using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; 
            InitializeComponent();
        }
        TaskCompletionSource<string> tSource = new TaskCompletionSource<string>();

        public Task<string> Login()
        {
            Show();
            var loginUrl = "https://www.facebook.com/dialog/oauth?client_id=802934243086932&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token&scope=email&display=popup";
            web.Navigate(loginUrl);
            return tSource.Task;
        }

        private void web_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var match = System.Text.RegularExpressions.Regex.Match(e.Uri.Fragment, "token=(.*)&");
            if (match.Success)
            {
                tSource.SetResult(match.Groups[1].Value);
                this.Close();
            }
        }
    }
}
    

