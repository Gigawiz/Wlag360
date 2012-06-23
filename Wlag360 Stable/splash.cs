using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Net;

namespace Wlag360_Stable
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
            getlocalgateway();
            checknetconnection();
        }
        private bool checknetconnection()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void getlocalgateway()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
                if (addresses.Count > 0)
                {
                    foreach (GatewayIPAddressInformation address in addresses)
                    {
                            listBox1.Items.Add(address.Address.ToString());
                    }
                }
            }
            Wlag360_Stable.Properties.Settings.Default.defaultgateway = listBox1.Items[0].ToString();
            Wlag360_Stable.Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 100)
            {
                getupdates();
            }
            else
            {
                progressBar1.Value += 1;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://djlyriz.com/projects.php?id=wlag360");
        }

        private void getupdates()
        {
            timer1.Stop();
            try
            {
                string updateurl = "http://dl.dropbox.com/u/22054429/wlag360_version.txt";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updateurl);
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string update = sr.ReadToEnd();
                int build = Convert.ToInt32(update);
                int thisbuild = 1;
                if (build > thisbuild)
                {
                    label2.Visible = true;
                    var result = MessageBox.Show("There is an update available for Wlag 360! Would you like to download it now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        updater updater = new updater();
                        updater.Show();
                        this.Dispose(false);
                    }
                }
                else
                {
                    label2.Visible = false;
                    Form1 home = new Form1();
                    home.Show();
                    this.Dispose(false);
                }
            }
            catch
            {
                MessageBox.Show("Unable to connect to update server! Wlag360 will check for updates at next launch!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label2.Visible = false;
                Form1 home = new Form1();
                home.Show();
                this.Dispose(false);
            }
        }
    }
}
