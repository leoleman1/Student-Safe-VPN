using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SSVPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Amsterdam UDP")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config amsterdam-UDP.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You have successfully connected to the Amsterdam VPN server using UDP");
            }

            if (comboBox1.Text == "New York UDP")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config newyork-UDP.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You have successfully connected to the New York VPN server using UDP");
            }

            else if (comboBox1.Text == "Amsterdam TCP")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config amsterdam-TCP.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You have successfully connected to the Amsterdam VPN server using TCP");
            }

            else if (comboBox1.Text == "New York TCP")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config newyork-TCP.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You have successfully connected to the New York VPN server using TCP");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
        }
        private void disconnect()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/f /im openvpn.exe",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();
        }

    }
}
