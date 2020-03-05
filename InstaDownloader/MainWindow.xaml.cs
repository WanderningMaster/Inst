using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
using System.Threading;

namespace InstaDownloader
{
    /// <summary>
    /// tak tse ya
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void FolderExplorerBtn(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";
            
            if(name.Text == null | name.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Input name");
                return;
            }
            //getting save path
            if (browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tempPath = browser.SelectedPath; 
            }

            string rootPath = tempPath;
            string DownloadUrl = Parser.urlParse(url.Text).Item1;
            string fileType = Parser.urlParse(url.Text).Item2;
            type.Content = rootPath;

            //Downloading file
            WebClient wc = new WebClient();
            wc.DownloadFile(DownloadUrl, @"" + rootPath + "/a." + fileType);
            Status.Content = "Completed";
        }
    }
}
