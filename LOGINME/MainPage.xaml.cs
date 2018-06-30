using System;
using Windows.UI.Popups;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite.Net.Attributes;
using Microsoft.VisualBasic;
using Windows.UI.ViewManagement;
using System.Xml.Linq;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LOGINME
{
    public sealed partial class MainPage : Page
    {
        public String path;
        SQLite.Net.SQLiteConnection conn;
        public MainPage()
        {
            this.InitializeComponent();
       
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite"); conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<info>();
        }


        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            signup1.IsPaneOpen = !signup1.IsPaneOpen;
            stack.Visibility = Visibility.Collapsed;
            signup1.IsPaneOpen = true;


        }


        private void revealModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == true)
            {
                passwordBox1.PasswordRevealMode = PasswordRevealMode.Visible;
            }

        }

        private void revealModeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == false)
            {
                passwordBox1.PasswordRevealMode = PasswordRevealMode.Hidden;
            }
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {

            stack.Visibility = Visibility.Visible;
            signup1.IsPaneOpen = false;
            var query = conn.Table<info>(); string id = ""; string name = ""; string email = "" ;String password = "";
            foreach (var message in query) { id = id + " " + message.Id; name = name + " " + message.Name; email = email + " " + message.Email;password = password + " " + message.Password; }
            // text1.Text = "ID: " + id + "\nName: " + name + "\nemail: " + email+"\npassword:"+password;
        
        }


    


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool x = true;
            var query = conn.Table<info>();
            foreach (var message in query)
            {
                if(pass.Password=="" || fillemail.Text=="" || pass2.Password=="" || fullname.Text==""  )
                {
                    var dialog = new MessageDialog("Please fill all information....");
                    await dialog.ShowAsync();
                    x = false;
                    break;
                }
                if (pass.Password.Length <= 6)
                {
                    var dialog = new MessageDialog("Password length must greater then 6....");
                    await dialog.ShowAsync();
                    x = false;
                    break;
                }
                if (fillemail.Text.Length <= 8)
                {
                    var dialog = new MessageDialog("Email length must greater then 8....");
                    await dialog.ShowAsync();
                    x = false;
                    break;
                }
                if (pass.Password != pass2.Password)
                {
                    var dialog = new MessageDialog("Passwords are not matching....");
                    await dialog.ShowAsync();
                    x = false;
                    break;
                }
               
                if (fillemail.Text.EndsWith("@gmail.com"))
                    
                {
                
                }
                
                else
                {
                    var dialog = new MessageDialog("Please use @gmail.com at the end of the Email Id....");
                    await dialog.ShowAsync();
                    x = false;
                    break;
                }

                if (fillemail.Text == message.Email)
                {
                    var dialog = new MessageDialog("this email already exists....");
                    await dialog.ShowAsync();
                    x = false;
                    break;
                }
            }
            if (x == true)
            {
                var s = conn.Insert(new info()
                {
                    Name = fullname.Text,
                    Email = fillemail.Text,

                    Password = pass.Password
                });

                var dialog = new MessageDialog("Signup Successfull....");
                await dialog.ShowAsync();
            }

        }
        public class info
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public string  Email { get; set; }
            public string Password { get; set; }
        }
       

        private async void login_Click(object sender, RoutedEventArgs e)
        {
           

            bool x = true;
            var query = conn.Table<info>();

            foreach (var message in query)
            {
                if (email.Text == message.Email && passwordBox1.Password == message.Password)
                {
                    if (email.Text != "" && passwordBox1.Password != "")
                    {
                        Frame.Navigate(typeof(home),email.Text);
                        x = false;
                        break;
                    }
                    else
                    {
                        var dialog = new MessageDialog("fill all information.....");
                       
                        await dialog.ShowAsync();
                        Frame.Navigate(typeof(MainPage));
                        x = false;
                        break;
                    }
                }
            }
            if (x == true)
            {
                var dialog = new MessageDialog("Please Enter valid Username or password");
                Frame.Navigate(typeof(MainPage));
                await dialog.ShowAsync();
            }
        }

        private void foeget_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page3));
        }
    }
    }

