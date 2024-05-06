using PingPong.GameManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppPingPong.Properties;
using WinFormsAppPingPong.Temporary.AdditionalClasses;
using WinFormsAppPingPong.Temporary.GameManager.Events;

namespace WinFormsAppPingPong
{
    public partial class MenuForm : Form
    {
        System.Media.SoundPlayer menuPlayer;
        IPlayer player = null;

        int magicNum1 = 32;
        int magicNum2 = 32;

        bool isHost = false;
        bool isClient = false;

        bool isReady;

        public MenuForm()
        {
            InitializeComponent();
            var music = Resources.menu;
            menuPlayer = new System.Media.SoundPlayer(music);
            menuPlayer.PlayLooping();

            PingPongEvents.OnPlayerJoin = ActivateGame;

            JoinPanel.Visible = false;
            HostPanel.Visible = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < magicNum1)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - magicNum2 && pos.Y >= this.ClientSize.Height - magicNum2)
                {
                    m.Result = (IntPtr)17; return;
                }
            }
            base.WndProc(ref m);
        }

        private void HostButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (player != null) player.Destroy();

            }
            catch { }

            this.isClient = false;
            this.isHost = true;
            this.JoinPanel.Visible = false;
            this.HostPanel.Visible = true;

            //menuPlayer.Stop();
            //var music = Resources.medium;
            //System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer(music);
            //soundPlayer.PlayLooping();

            Host host = new Host();
            IPAddress ip = host.ownEndPoint.Address;
            int port = host.ownEndPoint.Port;

            host.Setup();

            player = host;

            // show in panel ip and host
            // wait for the other connection

            this.HostIpLabel.Text = $"Local IP: {ip.ToString()}";
            this.HostPortLabel.Text = $"Local port: {port}";

            host.WaitForOtherConnection();

            //soundPlayer.Stop();
            //menuPlayer.PlayLooping();
        }


        private void JoinButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (player != null) player.Destroy();
            }
            catch { }

            this.isClient = true;
            this.isHost = false;
            this.JoinPanel.Visible = true;
            this.HostPanel.Visible = false;

            // wait for IP and Port to be written
            Client client = new Client().Setup();
            player = client;


            // show fields for ip and port
        }

        private void IPAndPortSubmit(object sender, EventArgs e)
        {
            string Ip = this.IpInput.Text;
            string Port = this.PortInput.Text;

            IPAddress ip;
            int port;
            try
            {
                ip = IPAddress.Parse(Ip);
                port = int.Parse(Port);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid IP or Port");
                return;
            }

            (player as Client).ConnectToHost(ip, port);
        }

        private void ActivateGame(PlayerJoinEvent e)
        {
            new Game(5, 5, player);
        }


        // TODO
        // add a create game as host and create game as Client with giving it ipaddress of the host
    }
}
