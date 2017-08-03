using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tetris
{
    partial class MainForm : Form
    {
       public Screen screen;
        Thread thread;
        public Model model;


        public MainForm()
        {
            model = new Model();
            screen = new Screen(model);
            model.gameStatus = GameStatus.game_Paused;
            InitializeComponent();
            this.Controls.Add(screen);

        }

        private void Level_btn_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {

        }

        private void NewGame_btn_Click(object sender, EventArgs e)
        {

        }

        private void StartPause_Btn_Click(object sender, EventArgs e)
        {
            if (model.gameStatus != GameStatus.game_Playing)
            {
                model.gameStatus = GameStatus.game_Playing;
                thread = new Thread(model.Play);
                thread.Start();
            }
            else
            {
                 model.gameStatus = GameStatus.game_Playing;
                thread.Abort();

            }
        }
    }
}
