using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppPingPong.Properties;

namespace WinFormsAppPingPong
{
    public partial class MenuForm : Form
    {
        System.Media.SoundPlayer menuPlayer;

        int magicNum1 = 32;
        int magicNum2 = 32;

        public MenuForm()
        {
            InitializeComponent();
            var music = Resources.menu;
            menuPlayer = new System.Media.SoundPlayer(music);
            menuPlayer.PlayLooping();
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

        private void button1_Click(object sender, EventArgs e)
        {
            menuPlayer.Stop();
            var music = Resources.easy;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(music);
            player.PlayLooping();

            Game game = new Game(3, 3, false);
            game.ShowDialog();

            player.Stop();
            menuPlayer.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuPlayer.Stop();
            var music = Resources.medium;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(music);
            player.PlayLooping();

            Game game = new Game(5, 5, false);
            game.ShowDialog();

            player.Stop();
            menuPlayer.PlayLooping();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuPlayer.Stop();
            var music = Resources.hard;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(music);
            player.PlayLooping();

            Game game = new Game(7, 7, false);
            game.ShowDialog();

            player.Stop();
            menuPlayer.PlayLooping();
        }

        // TODO
        // add a create game as host and create game as Client with giving it ipaddress of the host
    }
}
