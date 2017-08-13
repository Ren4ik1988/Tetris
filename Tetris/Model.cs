using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Tetris
{
    class Model
    {
        #region Constants: разрешение экрана в клетках

        public const int vertLength = 20;
        public const int gorizontLength = 10;

        #endregion

        #region Constants: константы уровней игры
        public const int Easy = 1000;
        public const int Middle = 700;
        public const int Hard = 500;
        #endregion

        public GameStatus GameStatus;
        Random random;
        int i, j; //поля определяют номера ячеек матрицы
        int gameLevel; //определяет скорость игры
        Timer timer;
        TimerCallback moveBlock;
        Screen screen;

        BackGraundMatrix[,] mainScreen; // основной слой экрана, создается по типу матрицы обычного монитора, но вместо пикселей ячейки 

        public Model()
        {
            GameStatus = GameStatus.Paused;
            random = new Random();
            FillMatrix();
        }

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }
        public int GameLevel { set => gameLevel = value; }

        public void FillMatrix()
        {
            i = j = 0;
            mainScreen = new BackGraundMatrix[vertLength, gorizontLength];

            for (int i = 0; i < vertLength; i++)
                for (int j = 0; j < gorizontLength; j++)
                {
                    mainScreen[i, j] = new BackGraundMatrix();
                }
            if (timer != null)
            {
                StartTimer(screen);
                screen.Invalidate();
            }
        }

        public void Random()
        {
            i = 0;
            j = random.Next(0, 9); //определяет рандомную позицию блока по горизонтальной координате
            mainScreen[i, j].PutImg(); // меняет изображение переменной Image на картинку блока
            mainScreen[i, j].Image = mainScreen[i, j].Image; // производит замену элемента ячейки
        }

        public void StartTimer(Screen screen)
        {
            if (GameStatus == GameStatus.Started)
            {
                this.screen = screen;
                moveBlock = new TimerCallback(Run);
                timer = new Timer(moveBlock, null, 500, gameLevel);
            }
            else
                timer.Change(Timeout.Infinite, 0);
        }

        void Run(object obj) //отвечает за движение фигуры
        {
            mainScreen[i, j].PutImg();
            mainScreen[i, j].Image = mainScreen[i, j].Image;
            i++;
            mainScreen[i, j].PutImg();
            mainScreen[i, j].Image = mainScreen[i, j].Image;

            screen.Invalidate();
            if (i == (vertLength - 1))
                Random();
        }
    }
}
