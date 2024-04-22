using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppPingPong
{
    public partial class Menu : Form
    {
        System.Media.SoundPlayer menuPlayer;
        public Menu()
        {
            InitializeComponent();
            menuPlayer = new System.Media.SoundPlayer();
            menuPlayer.SoundLocation = "menu.wav";
            menuPlayer.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuPlayer.Stop();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "easy.wav";
            player.PlayLooping();

            Game game = new Game(2, 2);
            game.ShowDialog();

            player.Stop();
            menuPlayer.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuPlayer.Stop();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "medium.wav";
            player.PlayLooping();

            Game game = new Game(5, 5);
            game.ShowDialog();

            player.Stop();
            menuPlayer.PlayLooping();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuPlayer.Stop();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "hard.wav";
            player.PlayLooping();

            Game game = new Game(8, 8);
            game.ShowDialog();

            player.Stop();
            menuPlayer.PlayLooping();
        }
    }
}
