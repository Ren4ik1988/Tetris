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
        public const int Middle = 600;
        public const int Hard = 100;
        #endregion

        public GameStatus GameStatus;
        Random random;
        static bool checkStatus;
        int i, j; //поля определяют номера ячеек матрицы
        int gameLevel; //определяет скорость игры
        Timer timer;
        TimerCallback moveBlock;
        Screen screen;
        Figure figure;

        BackGraundMatrix[,] mainScreen; // основной слой экрана, создается по типу матрицы обычного монитора, но вместо пикселей ячейки 

        public Model()
        {
            GameStatus = GameStatus.Paused;
            random = new Random();
            FillMatrix();
        }

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }
        public int GameLevel { set => gameLevel = value; }

        public void FillMatrix() //изначальное построение матрицы экрана
        {
            i = j = 0;
            mainScreen = new BackGraundMatrix[vertLength, gorizontLength];

            if (timer != null)
                StartTimer(screen);

            for (int i = 0; i < vertLength; i++)
                for (int j = 0; j < gorizontLength; j++)
                {
                    mainScreen[i, j] = new BackGraundMatrix();
                }
            if (screen != null)
                screen.Invalidate();

            figure = new Figure(mainScreen);
        }

        public void Random()
        {
            i = 0;
            j = random.Next(0, 10); //определяет рандомную позицию блока по горизонтальной координате
            //mainScreen[i, j].PutImg(); // меняет изображение переменной Image на картинку блока
            //mainScreen[i, j].Image = mainScreen[i, j].Image; // производит замену элемента ячейки
            figure.Random(ref i,ref j);
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
            if (i == (vertLength - 1))
            {
                Random();
            }
            else if (mainScreen[i + 1, j].Image == mainScreen[i + 1, j].Images.BlockImage |
                   mainScreen[i + 1, j + 1].Image == mainScreen[i + 1, j + 1].Images.BlockImage)
            {
                figure.Run(ref i, ref j);
                screen.Invalidate();
            }
        }

        private void isAllFull() //проверяет вся ли линия заполнена
        {
            for(j=0; j < gorizontLength; j++)
            {
                if (mainScreen[i, j].Image == mainScreen[i, j].Images.MainImage)
                {
                    checkStatus = false;
                    return;
                }
                else
                    checkStatus = true;
            }

            if (checkStatus == true)
                clearLine();
        }

        private void clearLine() //если вся линия полностью заполнилась, очищает линию и перемещает верхние фигуры на пустую строку
        {
            for (j = 0; j < gorizontLength; j++)
            {
                if(mainScreen[i, j].Image != mainScreen[i, j].Images.MainImage)
                    mainScreen[i, j].PutImg();
            }

            while (i > 0)
            {
                for (j = 0; j < gorizontLength; j++)
                {
                    if (mainScreen[i - 1, j].Image != mainScreen[i - 1, j].Images.MainImage)
                    {
                        mainScreen[i, j].PutImg();
                        mainScreen[i - 1, j].PutImg();
                    }
                }
                i--;
            }
        }
    }
}
