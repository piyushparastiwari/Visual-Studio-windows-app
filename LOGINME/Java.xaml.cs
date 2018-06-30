using System;

using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Streams;
using System.Net.Http;
using Windows.Web.Http;
using System.Threading;
using System.Net;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LOGINME
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Java : Page
    {
        public Java()
        {
            this.InitializeComponent();
        }
        public ToastNotification CreateFailureToast()
        {
            string title = "LOGINME\n\n" + "Download Failed\n" + "Check you connection...\n" + "Or file may not exist...";
            string name = "";
            return this.CreateToast(title, name);
        }

        public ToastNotification CreateSuccessToast()
        {
            string title = "LOGINME\n\n" + "Download Completed";
            string name = "";
            return this.CreateToast(title, name);
        }

        private ToastNotification CreateToast(string title, string name)
        {

            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);


            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            IXmlNode element0 = stringElements[0];
            element0.AppendChild(toastXml.CreateTextNode(title));

            IXmlNode element1 = stringElements[1];
            element1.AppendChild(toastXml.CreateTextNode(name));


            return new ToastNotification(toastXml);
        }


        private async Task TestBackgroundDownloader(string name, string URL)
        {

            BackgroundDownloader bd = new BackgroundDownloader();
            bd.FailureToastNotification = this.CreateFailureToast();
            bd.SuccessToastNotification = this.CreateSuccessToast();
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Downloads;
            folderPicker.ViewMode = PickerViewMode.Thumbnail;
            folderPicker.FileTypeFilter.Add("*");
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                StorageFile file = await folder.CreateFileAsync(name, CreationCollisionOption.GenerateUniqueName);

                Debug.WriteLine(file.Path);
                Uri uri = new Uri(URL);
                DownloadOperation op = bd.CreateDownload(uri, file);
                var progress = op.StartAsync();
                progress.Completed = this.Completed;
            }


        }

        private void Completed(
             IAsyncOperationWithProgress<DownloadOperation, DownloadOperation> asyncInfo,
             AsyncStatus asyncStatus)
        {

            var progress = asyncInfo;
            if (progress.Status == AsyncStatus.Completed)
            {
                Debug.WriteLine("Completed successfully.");
            }
            else
            {
                Debug.WriteLine("Failed to download.");
            }
        }
        private void read_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));

        }

        private async void diwnload_Click(object sender, RoutedEventArgs e)
        {
            string name = "java basic programming.pdf";
            string URL = "https://eduwamp.com/gallery/studymaterials/Eduwamp/Oracle%20Java%20Certification/Programming%20with%20Java%20A%20Primer,3E.pdf";
            await TestBackgroundDownloader(name, URL);
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));
        }

        private async void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {

            string name = " java reference.pdf";
            string URL = "http://iiti.ac.in/people/~tanimad/JavaTheCompleteReference.pdf";
            await TestBackgroundDownloader(name, URL);
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));
        }

        private async void MenuFlyoutItem_Click_3(object sender, RoutedEventArgs e)
        {
            string name = "advanced java programming.pdf";
            string URL = "http://164.100.133.129:81/eCONTENT/Uploads/Advanced_Java.pdf";
            await TestBackgroundDownloader(name, URL);
        }
        private void MenuFlyoutItem_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));
        }

        private async void MenuFlyoutItem_Click_5(object sender, RoutedEventArgs e)
        {
            string name = " program examples.pdf";
            string URL = "https://www.skiet.org/downloads/cprogrammingquestion.pdf";
            await TestBackgroundDownloader(name, URL);
        }
        private void MenuFlyoutItem_Click_6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));
        }

        private async void MenuFlyoutItem_Click_7(object sender, RoutedEventArgs e)
        {
            string name = " practical problems.pdf";
            string URL = "https://ocw.mit.edu/courses/electrical...and...c.../MIT6_087IAP10_assn03.pdf";
            await TestBackgroundDownloader(name, URL);
        }
        private void MenuFlyoutItem_Click_8(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));
        }

        private async void MenuFlyoutItem_Click_9(object sender, RoutedEventArgs e)
        {
            string name = "  MCQ practice.pdf";
            string URL = "http://nmu.ac.in/Portals/0/Question%20Bank/F.%20Y.%20B.%20Sc.(Computer%20Science)%20Paper%20II%20Question%20Bank.pdf";
            await TestBackgroundDownloader(name, URL);
        }
        private void MenuFlyoutItem_Click_10(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));
        }

        private async void MenuFlyoutItem_Click_11(object sender, RoutedEventArgs e)
        {
            string name = "Aptitude problems.pdf";
            string URL = "http://bit.ly/2blSRFV";
            await TestBackgroundDownloader(name, URL);
        }
        private void MenuFlyoutItem_Click_12(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(scene));
        }

        private async void MenuFlyoutItem_Click_13(object sender, RoutedEventArgs e)
        {
            string name = " Interview preparation.pdf";
            string URL = "http://blog.oureducation.in/wp-content/uploads/2013/09/Interview-Question-Answers-on-C++.pdf";
            await TestBackgroundDownloader(name, URL);
        }
        private async void MenuFlyoutItem_Click_14(object sender, RoutedEventArgs e)
        {
            string name = " Introduction to c.ppt";
            string URL = "https://www.cse.cuhk.edu.hk/irwin.king/_media/teaching/csc2100b/tu1.ppt";

            await TestBackgroundDownloader(name, URL);
        }
        private async void MenuFlyoutItem_Click_15(object sender, RoutedEventArgs e)
        {
            string name = "Tutorials.ppt";
            string URL = "https://courses.cs.washington.edu/courses/cse461/08au/lectures/c-tutorial.ppt";
            await TestBackgroundDownloader(name, URL);
        }
        private async void MenuFlyoutItem_Click_16(object sender, RoutedEventArgs e)
        {
            string name = " Notes.ppt";
            string URL = "https://www.slideshare.net/gauravjuneja11/c-language-ppt";
            await TestBackgroundDownloader(name, URL);
        }
    }
}



    
