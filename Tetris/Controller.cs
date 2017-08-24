using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainForm : Form
    {
        #region Константы названий кнопок
        const string start = "Начать игру";
        const string pause = "Пауза";
        const string resume = "Продолжить";
        const string easy = "Легко";
        const string middle = "Средне";
        const string hard = "Тяжело";
        #endregion

        Model model; // объект класса модел, используего для реализации всей логики приложения
        Screen screen; // объект пользовательского элемента управления, отвечающего за визуальное отображение игрового поля

        public MainForm()
        {
            model = new Model();
            screen = new Screen(model);
            model.GameStatus = GameStatus.NewGame;
            model.GameLevel = Model.Easy;
            InitializeComponent();
            this.Controls.Add(screen);
        }

        private void StartPause_Btn_Click(object sender, EventArgs e)
        {
            if (model.GameStatus == GameStatus.NewGame)
            {
                StartPause_Btn.Text = pause;
                Level_btn.Enabled = false;
                model.Random();
                screen.Invalidate();
                model.StartTimer(screen);
            }
            else if (model.GameStatus == GameStatus.Started)
            {
                StartPause_Btn.Text = resume;
                model.GameStatus = GameStatus.Paused;
                model.StartTimer(screen);

            }
            else
            {
                StartPause_Btn.Text = pause;
                model.GameStatus = GameStatus.Started;
                model.StartTimer(screen);
            }
        }

        private void Level_btn_Click(object sender, EventArgs e)
        {
            if (Level_btn.Text == easy)
            {
                Level_btn.Text = middle;
                model.GameLevel = Model.Middle;
                return;
            }
            if (Level_btn.Text == middle)
            {
                Level_btn.Text = hard;
                model.GameLevel = Model.Hard;
                return;
            }
            if (Level_btn.Text == hard)
            {
                Level_btn.Text = easy;
                model.GameLevel = Model.Easy;
            }
        }

        private void NewGame_btn_Click(object sender, EventArgs e)
        {
            model.GameStatus = GameStatus.NewGame;
            model.FillMatrix();
            StartPause_Btn.Text = start;
            Level_btn.Enabled = true;
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (model.GameStatus == GameStatus.Started)
            {
                StartPause_Btn.Text = resume;
                model.GameStatus = GameStatus.Paused;
                model.StartTimer(screen);
            }

            DialogResult dr = MessageBox.Show("Вы уверены, что хотите выйти из игры?", "Тетрис", MessageBoxButtons.YesNoCancel);
            if (dr != DialogResult.Yes)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void Manipulate(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left: model.LeftMove(); break;
                case Keys.Right: model.RightMove(); break;
                case Keys.Down: model.DownMove(); break;
                case Keys.Up: model.TurnMove(); break;
                default: break;
            }
        }

        private void InputCatch(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    e.IsInputKey = true;
                    break;
            }
        }
    }
}
