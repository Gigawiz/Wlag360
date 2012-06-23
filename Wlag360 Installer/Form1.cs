using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace Wlag360_Installer
{
    public partial class Form1 : Form
    {
        string installfolder = @"C:\Program Files\Dj Lyriz\Wlag 360\";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 100)
            {
                progressBar1.Value += 1;
            }
            else
            {
                end();
            }
        }
        private void end()
        {
            timer1.Stop();
            #region shortcut installer
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Wlag360.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Wlag360";
            shortcut.Hotkey = "Ctrl+Shift+W";
            shortcut.TargetPath = installfolder + @"\\Wlag360.exe";
            shortcut.Save();
            #endregion
            #region file installer
            string dir = installfolder + "AGauge.dll";
            string dir2 = installfolder + "System.Web.dll";
            string dir3 = installfolder + "Wlag360.exe";
            System.IO.File.WriteAllBytes(dir, Wlag360_Installer.Properties.Resources.AGauge);
            System.IO.File.WriteAllBytes(dir2, Wlag360_Installer.Properties.Resources.System_Web);
            System.IO.File.WriteAllBytes(dir3, Wlag360_Installer.Properties.Resources.Wlag360);
            #endregion
        }
    }
}
