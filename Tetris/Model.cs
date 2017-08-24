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
        public const int Middle = 300;
        public const int Hard = 100;
        #endregion

        #region Constants: константа включена для удобства определния наличия в ячейке изображения
        public const short On = 1;
        public const short Off = 0;
        #endregion

        #region Readonly: поля ридонли для обозначения пустой ячейки и заполненной соответственно
        static readonly BackGraundMatrix isNull;
        static readonly BackGraundMatrix isNotNull;
        internal static BackGraundMatrix IsNull => isNull;
        internal static BackGraundMatrix IsNotNull => isNotNull;
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
        bool navigatorStatus;
        NavigateType navigateType;
        static bool canNavigateRight;
        static bool canNavigateLeft;

        BackGraundMatrix[,] mainScreen; // основной слой экрана, создается по типу матрицы обычного монитора, но вместо пикселей ячейки 
        short[,] onOff;

        public Model()
        {
            GameStatus = GameStatus.Paused;
            navigateType = NavigateType.Right;
            random = new Random();
            checkStatus = true;
            navigatorStatus = false;
            FillMatrix();
        }

        static Model()
        {
            isNull = new BackGraundMatrix();
            isNotNull = new BackGraundMatrix();
            isNotNull.PutImg();
        }

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }
        public int GameLevel { set => gameLevel = value; }
        public static bool CanNavigateRight { get => canNavigateRight; set => canNavigateRight = value; }
        public static bool CanNavigateLeft { get => canNavigateLeft; set => canNavigateLeft = value; }

        public void FillMatrix() //изначальное построение матрицы экрана
        {
            i = j = 0;
            mainScreen = new BackGraundMatrix[vertLength, gorizontLength];
            onOff = new short[vertLength, gorizontLength];

            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }

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

            if (timer != null)
            {
                timer.Change(0, gameLevel);
            }
            figure.Random(ref i, ref j);
            CanNavigateRight = canNavigateLeft = true;
        }

        public void StartTimer(Screen screen)
        {
            if (GameStatus == GameStatus.NewGame)
            {
                GameStatus = GameStatus.Started;
                this.screen = screen;

                if(moveBlock == null)
                    moveBlock = new TimerCallback(Run);
                timer = new Timer(moveBlock, null, 0, gameLevel);
                return;
            }
            if (GameStatus == GameStatus.Paused)
                timer.Change(Timeout.Infinite, 0);
            if (GameStatus == GameStatus.Started)
                timer.Change(0, gameLevel);
        }

        void Run(object obj) //отвечает за запуск движения фигуры
        {
            if (checkStatus)
            {
                if (!navigatorStatus)
                {
                    checkStatus = figure.Run(ref i, ref j);
                    screen.Invalidate();
                }
                    
                    

                
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
            if (i == 0)
                return;

            for (j = 0; j < gorizontLength; j++)
            {
                if (onOff[i, j] == Off)
                    return;
                else
                    checkStatus = true;
            }

            if (checkStatus)
                ClearLine();
        }

        private void ClearLine() //если вся линия полностью заполнилась, очищает линию и перемещает верхние фигуры на пустую строку
        {
            for (j = 0; j < gorizontLength; j++)
            {
                mainScreen[i, j].Image = IsNull.Image;
                onOff[i, j] = Off;
            }

            for (int k = i; k > 0; k--)
            {
                for (j = 0; j < gorizontLength; j++)
                {
                    if (onOff[k - 1, j] == On)
                    {
                        mainScreen[k, j].Image = IsNotNull.Image;
                        mainScreen[k - 1, j].Image = IsNull.Image;
                        onOff[k, j] = On;
                        onOff[k - 1, j] = Off;
                    }
                }
            }

            TestAllFull();
        }


        internal void RightMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                canNavigateLeft = true;

                if (!CanNavigateRight)
                {
                    return;
                }

                navigatorStatus = true;
                navigateType = NavigateType.Right;
                MoveFigure();
            }
        }

        internal void LeftMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                canNavigateRight = true;

                if (!CanNavigateLeft)
                {
                    return;
                }
                navigatorStatus = true;
                navigateType = NavigateType.Left;
                MoveFigure();
            }
        }

        internal void DownMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                navigatorStatus = true;
                navigateType = NavigateType.Down;
                MoveFigure();
            }
        }

        internal void TurnMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                navigatorStatus = true;
                navigateType = NavigateType.Turn;
            }
        }

        private void MoveFigure()
        {
            navigatorStatus = false;

            switch (navigateType)
            {
                case NavigateType.Right:
                    figure.RightMove(ref i, ref j);
                    screen.Invalidate();
                    break;

                case NavigateType.Left:
                    figure.LeftMove(ref i, ref j);
                    screen.Invalidate();
                    break;

                case NavigateType.Down:
                    //to do
                    break;

                case NavigateType.Turn:
                    figure.TurnMove(ref i, ref j);
                    screen.Invalidate();
                    break;
            }
        }
    }

}


