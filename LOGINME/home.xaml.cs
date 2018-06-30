using System.Collections;

using System;
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
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LOGINME
{

    public sealed partial class home : Page
    {
  

        public String path;
        SQLite.Net.SQLiteConnection conn;
        public home()
        {

            this.InitializeComponent();

            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite"); conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            MyFrame.Navigate(typeof(Page1));
        }

     

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoForward)
            {
                MyFrame.GoForward();
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataTransferManager dtManager = DataTransferManager.GetForCurrentView();
            dtManager.DataRequested += DtManager_DataRequested;
            string email = e.Parameter as string;
             us1.Text = email;

        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            var query = conn.Table<info>();
            foreach (var message in query)
            {
                if (us1.Text == message.Email)
                {
                    us.Text = message.Name;
                }

            }

        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));

        }

        private void us2_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Page3));
        }

        private  void asugbox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                string text = sender.Text;
                if (sender.Text.Length > 1)
                {
                    sender.ItemsSource =  this.GetSuggestions(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new string[] { "No suggestions..." };
                }
            }
        }

        private string[] suggestions = new string[] {"C","C++","Java","java","Python","python", "Amado Dukes", "Nolan Bickham", "Joel Wunderlich", "Wm Conant", "Thanh Marquez", "Elvis Braley", "Donnell Brant", "Silas Dillinger", "Patricia Farrar", "Elisha Burchfield", "Hunter Wilker", "Chauncey Renfrew", "Salvatore Stennett", "Josef Risner", "Saul Gatlin", "Faustino Younan", "Deon Rodriguez", "Sammie Sevigny", "Valentine Avina", "Thomas Laurence", "Tony Greeno", "Antonia Hymes", "Elliott Cerrato", "Johnson Mcgurk", "Landon Medel", "Darnell Hugley", "Mauricio Niswander", "Cleveland Mercuri", "Rupert Okada", "Darrell Mccaslin", "Elroy Snyder", "Alejandro Cayer", "Grant Calvi", "Timmy Traynor", "Alexis Melo", "Stephan Lynn", "Jose Radabaugh", "Blake Zollinger", "Norman Gorton", "Rocky Broce", "Norberto Alden", "Bert Linwood", "Fabian Pietsch", "Pete Maly", "Reyes Purdom", "Dan Holdren", "Ted Pineo", "Morris Mcilrath", "Tyson Hardesty", "Arron Nappi" };

        private string[] GetSuggestions(string text)
        {
            string[] result = null;

            result = suggestions.Where(x => x.Contains(text)).ToArray();

            return result;
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Page1));
        }
      

        private void DtManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.Properties.Title = "LOGINME";
            args.Request.Data.Properties.Description ="Link for app" ;
            args.Request.Data.SetWebLink(new Uri("http://youtube.com"));
        }


        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();

        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(contact));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(asugbox.Text=="c" || asugbox.Text == "C")
            {
                MyFrame.Navigate(typeof(C));
            }
            if (asugbox.Text == "C++" || asugbox.Text == "C plus plus")
            {
                MyFrame.Navigate(typeof(Cpp));
            }
            if (asugbox.Text == "python" || asugbox.Text == "Python")
            {
                MyFrame.Navigate(typeof(Python));
            }
            if (asugbox.Text == "Java" || asugbox.Text == "java")
            {
               MyFrame.Navigate(typeof(Java));
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(C));
        }

        private void Cpp_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Cpp));
        }

        private void Java_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Java));
        }

        private void Python_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Python));
        }

        private void MenuFlyoutItem_Click_3(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(C));

        }

        private void MenuFlyoutItem_Click_4(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Cpp));
        }

        private void MenuFlyoutItem_Click_5(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Java));
        }

        private void MenuFlyoutItem_Click_6(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Python));
        }
    }


}
      
        


    


