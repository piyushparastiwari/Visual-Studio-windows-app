using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LOGINME
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        public String path;
        SQLite.Net.SQLiteConnection conn;
        public Page3()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite"); conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

        }

        private async void change_Click(object sender, RoutedEventArgs e)
        {
            bool x = true;
            var query = conn.Table<info>();
            string p = "";
            string q="";
            foreach (var message in query)
            {
                p = remail.Text;
              q=old.Password;
                if (p == message.Email)
                {
                    if (q == message.Password)
                    {
                        if (passwordBox3.Password != passwordBox2.Password)
                        {


                            var dialog = new MessageDialog("Password not matched....");
                            await dialog.ShowAsync();
                            x = false;
                            break;

                        }
                        if (passwordBox2.Password == "" || passwordBox3.Password == "" || remail.Text == "" || old.Password == "")
                        {


                            var dialog = new MessageDialog("Please fill all information....");
                            await dialog.ShowAsync();
                            x = false;
                            break;

                        }
                        else

                        {
                            if (passwordBox2.Password == passwordBox3.Password )
                            {


                                message.Password = passwordBox3.Password;
                                if (message.Email == p)
                                {
                                    
                                    var s = conn.Update(new info()
                                    {
                                        id = message.id,
                                        Name = message.Name,

                                        Email = message.Email,

                                        Password = passwordBox3.Password

                                    });


                                }
                                Frame.Navigate(typeof(MainPage));
                                var dialog = new MessageDialog("Password changed sucessfully....");
                                await dialog.ShowAsync();
                                x = true;
                                break;

                            }
                        }

                    }
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string)
            {
                var value = (string)e.Parameter;
                remail.Text = value;
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {

            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}

