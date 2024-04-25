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
        public MenuForm()
        {
            InitializeComponent();
            var music = Resources.menu;
            menuPlayer = new System.Media.SoundPlayer(music);
            menuPlayer.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuPlayer.Stop();
            var music = Resources.easy;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(music);
            player.PlayLooping();

            Game game = new Game(3, 3);
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

            Game game = new Game(5, 5);
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

            Game game = new Game(7, 7);
            game.ShowDialog();

            player.Stop();
            menuPlayer.PlayLooping();
        }
    }
}
