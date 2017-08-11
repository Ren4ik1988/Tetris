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
        public Model model;

        TimerCallback modelPlay;
        System.Threading.Timer move;
        int speedGame;
        


        public MainForm()
        {
            speedGame = 1000;
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
                StartPause_Btn.Text = "Продолжить";
                model.GameStatus = GameStatus.Paused;
                move.Change(Timeout.Infinite, 0);
            }
            else
            {
                StartPause_Btn.Text = "Пауза";
                Level_btn.Enabled = false;
                model.GameStatus = GameStatus.Playing;
                screen.Invalidate();
                modelPlay = new TimerCallback(model.Play);
                move = new System.Threading.Timer(modelPlay, null, 0, speedGame);
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(model.GameStatus == GameStatus.Playing)
            {
                model.GameStatus = GameStatus.Paused;
                move.Change(Timeout.Infinite, 0);
                StartPause_Btn.Text = "Продолжить";
            }

            DialogResult dr = MessageBox.Show("Вы уверены, что хотите закрыть игру?", "Tetris", MessageBoxButtons.YesNoCancel);

            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void NewGame_btn_Click(object sender, EventArgs e)
        {
            if (move != null)
                move.Change(Timeout.Infinite, 0);
            StartPause_Btn.Text = "Начать игру";
            Level_btn.Enabled = true;
            model.GameStatus = GameStatus.StartNew;
            model.Reset();
            model.Play(model.GameStatus);
            screen.Invalidate();
        }

        private void Level_btn_Click(object sender, EventArgs e)
        {
            // если используешь текст в условии (if), то лучше вынеси его в const string, так будет правильнее

            if( Level_btn.Text == "Легко")
            {
                speedGame = 700;
                Level_btn.Text = "Средне";
                return;
            }

            if (Level_btn.Text == "Средне")
            {
                speedGame = 400;
                Level_btn.Text = "Тяжело";
                return;
            }

            if (Level_btn.Text == "Тяжело")
            {
                speedGame = 1000;
                Level_btn.Text = "Легко";
                return;
        }
    }
    }
}
