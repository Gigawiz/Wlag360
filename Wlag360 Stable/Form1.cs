using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Wlag360_Stable
{
    public partial class Form1 : Form
    {
        public static string IP;
        public static int Port;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Wlag 360 - Lagging In Progress";
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Error! You need to type the ip address of your console to start lagging!");
            }
            else
            {
                if (button1.Text == "&Lag!")
                {
                    button1.Text = "&Stop Lagging!";
                    IP = textBox1.Text;
                    Port = 80;
                    label2.Text = "Status: Lagging";
                    timer1.Start();
                    timer2.Start();
                    timer3.Start();
                    timer6.Start();
                    backgroundWorker1.RunWorkerAsync();
                    //Runs the backgroundworker
                    backgroundWorker2.RunWorkerAsync();
                    backgroundWorker3.RunWorkerAsync();
                    backgroundWorker4.RunWorkerAsync();
                    backgroundWorker5.RunWorkerAsync();
                    backgroundWorker6.RunWorkerAsync();
                    backgroundWorker7.RunWorkerAsync();
                    backgroundWorker8.RunWorkerAsync();
                    backgroundWorker9.RunWorkerAsync();
                    backgroundWorker10.RunWorkerAsync();
                }
                else if (button1.Text == "&Stop Lagging!")
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer6.Stop();
                    progressBar1.Value = 0;
                    timer5.Start();
                    backgroundWorker1.CancelAsync();//Stops flooding
                    backgroundWorker2.CancelAsync();
                    backgroundWorker3.CancelAsync();
                    backgroundWorker4.CancelAsync(); //Stops flooding
                    backgroundWorker5.CancelAsync();
                    backgroundWorker6.CancelAsync();
                    backgroundWorker7.CancelAsync();
                    backgroundWorker8.CancelAsync();
                    backgroundWorker9.CancelAsync();
                    backgroundWorker10.CancelAsync();
                }
                else
                {
                    MessageBox.Show("Error! Something Broke!");
                }
            }
        }

        #region background workers
        private void backgroundWorker1_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress targetIp = IPAddress.Parse(IP);
            //IP to send the packets to
            IPEndPoint target = new IPEndPoint(targetIp, Port);
            //Port to flood
            byte[] packet = new byte[1470];
            //Creates bytes
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //Creates sockets
            while (true)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, target);
                    //Sends packets
                    i += 1;
                }
                catch (Exception ex)
                {
                    //MessageBox(IP + " is not reachable at the moment! Please try again later.");
                    Application.Exit();
                    //Closes the application
                }
            }
        }

        private void backgroundworker2_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker2.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker2.CancelAsync();
                }
            }
        }
        private void backgroundworker3_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker3.CancellationPending == true)
                {
                    return;
                }

                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker3.CancelAsync();
                }
            }
        }
        private void backgroundWorker4_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker4.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker4.CancelAsync();
                }
            }
        }

        private void backgroundWorker5_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker5.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker5.CancelAsync();
                }
            }
        }

        private void backgroundWorker6_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker6.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker6.CancelAsync();
                }
            }
        }

        private void backgroundWorker7_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker7.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker7.CancelAsync();
                }
            }
        }

        private void backgroundWorker8_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker8.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker8.CancelAsync();
                }
            }
        }

        private void backgroundWorker9_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker9.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker9.CancelAsync();
                }
            }
        }

        private void backgroundWorker10_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress victimIp = IPAddress.Parse(IP);
            IPEndPoint slave = new IPEndPoint(victimIp, Port);
            byte[] packet = new byte[1470];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                if (backgroundWorker10.CancellationPending == true)
                {
                    return;
                }
                try
                {
                    socket.SendTo(packet, slave);
                    i += 1;
                }
                catch (Exception ex)
                {
                    backgroundWorker10.CancelAsync();
                }
            }
        }
        #endregion
        #region timers
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 100;
                timer2.Stop();
            }
            else
            {
                progressBar1.Value += 1;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (aGauge1.Value >= 320)
                {
                    backgroundWorker1.CancelAsync();
                    backgroundWorker2.CancelAsync();
                    backgroundWorker3.CancelAsync();
                    backgroundWorker4.CancelAsync();
                    backgroundWorker5.CancelAsync();
                    backgroundWorker6.CancelAsync();
                    backgroundWorker7.CancelAsync();
                    backgroundWorker8.CancelAsync();
                    backgroundWorker9.CancelAsync();
                    timer3.Stop();
                    timer6.Stop();
                    timer4.Start();
                }
                else if (aGauge1.Value <= 200)
                {
                    timer4.Stop();
                    if (backgroundWorker1.IsBusy == false)
                    {
                        timer3.Start();
                        timer6.Start();
                        backgroundWorker1.RunWorkerAsync();
                        backgroundWorker2.RunWorkerAsync();
                        backgroundWorker3.RunWorkerAsync();
                        backgroundWorker4.RunWorkerAsync();
                        backgroundWorker5.RunWorkerAsync();
                        backgroundWorker6.RunWorkerAsync();
                        backgroundWorker7.RunWorkerAsync();
                        backgroundWorker8.RunWorkerAsync();
                        backgroundWorker9.RunWorkerAsync();
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (aGauge1.Value >= 320)
            {
                aGauge1.Value -= 2f;
            }
            else
            {
                aGauge1.Value += 1f;
            }
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            if (aGauge2.Value >= 399)
            {
                aGauge2.Value -= 2f;
            }
            else
            {
                aGauge2.Value += 1f;
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            aGauge1.Value -= 1f;
            if (aGauge2.Value >= 201)
            {
                aGauge2.Value -= 4f;
            }
            else
            {
                aGauge2.Value += 2f;
            }

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if ((aGauge1.Value == 0) && (progressBar1.Value == 100) && (aGauge2.Value == 0))
            {
                aGauge1.Value = 0;
                progressBar1.Value = 0;
                label2.Text = "Status: Ready";
                button1.Text = "Lag!";
                button1.Enabled = true;
                textBox1.Enabled = true;
                timer5.Stop();
            }
            else
            {
                if (aGauge1.Value != 0)
                {
                    aGauge1.Value -= 1f;
                }
                if (aGauge2.Value != 0)
                {
                    aGauge2.Value -= 1f;
                }
                if (progressBar1.Value != 100)
                {
                    progressBar1.Value += 1;
                }
                label2.Text = "Status: Cooling Down";
                button1.Text = "Please Wait...";
                button1.Enabled = false;
                textBox1.Enabled = false;
            }
        }
        #endregion

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click((object)sender, (EventArgs)e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Wlag360_Stable.Properties.Settings.Default.defaultgateway.Contains("192.168.1"))
            {
                 textBox1.Text = "192.168.1.";
            }
            else if (Wlag360_Stable.Properties.Settings.Default.defaultgateway.Contains("192.168.0"))
            {
                textBox1.Text = "192.168.0.";
            }
            else if (Wlag360_Stable.Properties.Settings.Default.defaultgateway.Contains("10.0.0."))
            {
                textBox1.Text = "10.0.0.";
            }
            else
            {
                textBox1.Text = Wlag360_Stable.Properties.Settings.Default.defaultgateway;
            }
        }
    }
}
