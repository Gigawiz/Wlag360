﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace Wlag360_Stable
{
    public partial class updater : Form
    {
        public updater()
        {
            InitializeComponent();
        }

        private void updater_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            Uri update = new Uri("https://dl.dropbox.com/u/22054429/Wlag360_Installer.exe");
            client.DownloadFileAsync(update, "update.exe");
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start("update.exe");
            Environment.Exit(0);
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label1.Text = "Downloading Update Please Wait..." + e.ProgressPercentage.ToString() + "%";
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
