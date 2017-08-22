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

        #region Constants: константа включена для удобства определния наличия в ячейке изображения
        public const short On = 1;
        public const short Off = 0;
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
        short[,] onOff;

        public Model()
        {
            GameStatus = GameStatus.Paused;
            random = new Random();
            checkStatus = true;
            FillMatrix();
        }

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }
        public int GameLevel { set => gameLevel = value; }

        public void FillMatrix() //изначальное построение матрицы экрана
        {
            i = j = 0;
            mainScreen = new BackGraundMatrix[vertLength, gorizontLength];
            onOff = new short[vertLength, gorizontLength];

            if (timer != null)
                StartTimer(screen);

            for (int i = 0; i < vertLength; i++)
                for (int j = 0; j < gorizontLength; j++)
                {
                    mainScreen[i, j] = new BackGraundMatrix();
                    onOff[i, j] = Off;
                }
            if (screen != null)
                screen.Invalidate();

            figure = new Figure(mainScreen, onOff);
        }

        public void Random()
        {
            i = 0;
            j = random.Next(0, 10); //определяет рандомную позицию блока по горизонтальной координате
            figure.Random(ref i, ref j);
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

        void Run(object obj) //отвечает за запуск движения фигуры
        {
            if (checkStatus)
            {
                checkStatus = figure.Run(ref i, ref j);
                screen.Invalidate();
            }
            else
            {
                checkStatus = true;
                TestAllFull();
                Random();
            }
        }

        private void TestAllFull() //проверяет вся ли линия заполнена
        {
            for (j = 0; j < gorizontLength; j++)
            {
                if (onOff[i,j] == Off)
                    return;
                else
                    checkStatus = true;
            }

            if (checkStatus)
                clearLine();
        }

        private void clearLine() //если вся линия полностью заполнилась, очищает линию и перемещает верхние фигуры на пустую строку
        {
            for (j = 0; j < gorizontLength; j++)
            {
                mainScreen[i, j].PutImg();
                mainScreen[i, j].Image = mainScreen[i, j].Image;
                onOff[i, j] = Off;

            }

            //while (i > 0)
            //{
            //    for (j = 0; j < gorizontLength; j++)
            //    {
            //        if (mainScreen[i - 1, j].Image != mainScreen[i - 1, j].Images.MainImage)
            //        {
            //            mainScreen[i, j].PutImg();
            //            mainScreen[i - 1, j].PutImg();
            //        }
            //    }
            //    i--;
            //}
        }

        internal void RightMove()
        {
            throw new NotImplementedException();
        }

        internal void LeftMove()
        {
            throw new NotImplementedException();
        }
    }
}

