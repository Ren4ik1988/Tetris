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
        Thread modelPlay;
        public Model model;


        public MainForm()
        {
            model = new Model();
            screen = new Screen(model);
            model.GameStatus = GameStatus.Paused;
            InitializeComponent();
            this.Controls.Add(screen);

        }

        private void StartPause_Btn_Click(object sender, EventArgs e)
        {
            if (model.GameStatus == GameStatus.Playing)
            {
                model.GameStatus = GameStatus.Paused;
                modelPlay.Abort();
            }
            else
            {
                model.GameStatus = GameStatus.Playing;
                modelPlay = new Thread(model.Play);
                modelPlay.Start();
                screen.Invalidate();
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(modelPlay != null)
            {
                model.GameStatus = GameStatus.Stop;
                modelPlay.Abort();
            }


           DialogResult dr = MessageBox.Show("Вы уверены, что хотите закрыть игру?", "Tetris", MessageBoxButtons.YesNoCancel);

            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
