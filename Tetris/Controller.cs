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

        #region Private fields
        Model model;
        Screen screen;
        NextFigureScreen nextFigure;
        #endregion

        #region Constructor
        public MainForm()
        {
            model = new Model(this);
            screen = new Screen(model);
            nextFigure = new NextFigureScreen(model);
            InitializeComponent();
            this.Controls.Add(screen);
            this.Controls.Add(nextFigure);
        }
        #endregion

        #region Управление с помощью кнопок
        private void StartPause_Btn_Click(object sender, EventArgs e)
        {
            if (model.GameStatus == GameStatus.NewGame)
            {
                StartPause_Btn.Text = pause;
                Level_btn.Enabled = false;
                model.Random();
                screen.Invalidate();
                nextFigure.Invalidate();
                model.StartTimer(screen, nextFigure);
            }
            else if (model.GameStatus == GameStatus.Started)
            {
                StartPause_Btn.Text = resume;
                model.GameStatus = GameStatus.Paused;
                model.StartTimer(screen, nextFigure);

            }
            else
            {
                StartPause_Btn.Text = pause;
                model.GameStatus = GameStatus.Started;
                model.StartTimer(screen, nextFigure);
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
            ScoreLabel.Text = "0";
            LineLabel.Text = "0";
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
                model.StartTimer(screen, nextFigure);
            }

            DialogResult dr = MessageBox.Show("Вы уверены, что хотите выйти из игры?", "Тетрис", MessageBoxButtons.YesNoCancel);
            if (dr != DialogResult.Yes)
                e.Cancel = true;
            else
                e.Cancel = false;
        }
        #endregion

        #region Управление с клавиатуры
        private void Manipulate(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
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

        internal void Score(int score, int lines)
        {
            if (ScoreLabel.InvokeRequired)
                ScoreLabel.Invoke(new Action<int>((s) => ScoreLabel.Text = s.ToString()), score);
            else
                ScoreLabel.Text = score.ToString();

            if (LineLabel.InvokeRequired)
                LineLabel.Invoke(new Action<int>((s) => LineLabel.Text = s.ToString()), lines);
            else
                LineLabel.Text = lines.ToString();
        }

        internal void GameOver(int score, Line line)
        {
            string result = $"Игра окончена! {Environment.NewLine}Количество линий: {score} {Environment.NewLine}Очки: {score}";
            MessageBox.Show(result, "Game Over");
        }

        #endregion
    }
}
