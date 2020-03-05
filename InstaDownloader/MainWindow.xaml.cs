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
    /// Логика взаимодействия для MainWindow.xaml
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
            
            //getting save path
            if (browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tempPath = browser.SelectedPath; 
            }

            //needful params
            string rootPath = tempPath;
            string DownloadUrl = Parser.urlParse(url.Text).Item1;
            string fileType = Parser.urlParse(url.Text).Item2;
            
            //Save path visualize
            type.Content = rootPath;

            //Downloading file
            WebClient wc = new WebClient();
            wc.DownloadFile(DownloadUrl, @"" + rootPath + "/a." + fileType);
            Status.Content = "Completed";

            //TODO: Add file name menu 
        }
    }
}
