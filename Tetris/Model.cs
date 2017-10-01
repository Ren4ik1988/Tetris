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

        public const int vertLength = 24;
        public const int gorizontLength = 10;

        #endregion

        #region Constants: константы уровней игры
        public const int Easy = 1000;
        public const int Middle = 500;
        public const int Hard = 300;
        #endregion

        #region Constants: показывает состояние элемента матрицы
        public const short On = 1;
        public const short Off = 0;
        #endregion

        #region Переменные для объектов фигур

        Figure nextFig;
        Figure mainFigure;
        Figure figure;
        Line line;
        Stallion1 stallion1;
        Stallion2 stallion2;
        Triangle triangle;
        ZFigure zFigure;
        SFigure sFigure;

        #endregion

        #region Поля

        int score, lines, level;
        public GameStatus GameStatus;
        Random random;
        static bool checkStatus;
        int i, j; //поля определяют номера ячеек матрицы
        int gameLevel; //определяет скорость игры
        Timer timer;
        TimerCallback moveBlock;
        Screen screen;
        NavigateType navigateType;
        FigureList figurelist;
        static bool canNavigateRight;
        static bool canNavigateLeft;
        static BackGraundMatrix nullImage;
        NextFigureScreen nextFigure;
        MainForm controller;

        BackGraundMatrix[,] mainScreen; // основной слой экрана, создается по типу матрицы обычного монитора, но вместо пикселей ячейки 
        short[,] onOff;
        BackGraundMatrix [,] nextScreen = new BackGraundMatrix[4, 3];

        #endregion

        #region Constructors
        public Model(MainForm mainForm)
        {
            this.controller = mainForm;
            GameStatus = GameStatus.NewGame;
            gameLevel = Easy;
            navigateType = NavigateType.Right;
            random = new Random();
            checkStatus = true;
            mainScreen = new BackGraundMatrix[vertLength, gorizontLength];
            onOff = new short[vertLength, gorizontLength];
            FillMatrix();
            
            #region Создание объектов всех игровых фигур

            stallion1 = new Stallion1(mainScreen, onOff, nextScreen);
            figure = new Figure(mainScreen, onOff, nextScreen);
            line = new Line(mainScreen, onOff, nextScreen);
            stallion2 = new Stallion2(mainScreen, onOff, nextScreen);
            triangle = new Triangle(mainScreen, onOff, nextScreen);
            zFigure = new ZFigure(mainScreen, onOff, nextScreen);
            sFigure = new SFigure(mainScreen, onOff, nextScreen);

            #endregion
            ChooseFirstFigure();
        }

        static Model()
        {
            nullImage = new BackGraundMatrix();
            nullImage.Image = NullImage.Images.GridNextFigure;
        }

        #endregion

        #region Свойства

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }
        public int GameLevel { set => gameLevel = value; }
        public static bool CanNavigateRight { get => canNavigateRight; set => canNavigateRight = value; }
        public static bool CanNavigateLeft { get => canNavigateLeft; set => canNavigateLeft = value; }
        internal static BackGraundMatrix NullImage { get => nullImage; }
        internal BackGraundMatrix[,] NextScreen { get => nextScreen; set => nextScreen = value; }

        #endregion

        #region Построение сетки/очистка игрового поля, выбор случайной фигуры и запуск ее обрисовки

        public void FillMatrix() //изначальное построение матрицы экрана
        {
            score = level = lines = 0;
            i = j = 0;
            

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

            FillNextscreen();

        }
        void FillNextscreen()
        {
            for (int i = 0; i < 4; i++)
                for (int k = 0; k < 3; k++)
                {
                    NextScreen[i, k] = new BackGraundMatrix();
                    NextScreen[i, k].Image = nullImage.Image;
                }
            if (nextFigure != null)
                nextFigure.Invalidate();
        }

        internal int FixLines()
        {
            return lines; ;
        }

        internal int FixScore()
        {
            return score;
        }

        public void Random()
        {
            i = 0;
            mainFigure = nextFig;
            mainFigure.Random(ref i, ref j);
            level = 0;

            if (screen != null)
                screen.Invalidate();

            #region Определяем следующую фигуру и выводим ее на экран подсказки
            FillNextscreen();
            ChooseFirstFigure();
            nextFig.ImplementNextFigureMatrix();
            if(nextFigure != null)
                nextFigure.Invalidate();
        #endregion

            CanNavigateRight = canNavigateLeft = true;
        }

        private void ChooseFirstFigure()
        {
            figurelist = (FigureList)random.Next(0, 7);

            switch (figurelist)
            {
                case FigureList.rectangle: nextFig = figure; break;
                case FigureList.line: nextFig = line; break;
                case FigureList.stallion1: nextFig = stallion1; break;
                case FigureList.stallion2: nextFig = stallion2; break;
                case FigureList.triangle: nextFig = triangle; break;
                case FigureList.sfigure: nextFig = sFigure; break;
                case FigureList.zfigure: nextFig = zFigure; break;
            }
        }

        #endregion

        #region Скорость игры и движение фигур

        public void StartTimer(Screen screen, NextFigureScreen nextFigure)
        {
            if (GameStatus == GameStatus.NewGame)
            {
                GameStatus = GameStatus.Started;
                this.screen = screen;
                this.nextFigure = nextFigure;
            
                if(moveBlock == null)
                    moveBlock = new TimerCallback(Run);

                if (timer == null)
                    timer = new Timer(moveBlock, null, 0, gameLevel);
                else
                    timer.Change(0, gameLevel);

                return;
            }
            if (GameStatus == GameStatus.Paused)
                timer.Change(Timeout.Infinite, 0);
            if (GameStatus == GameStatus.Started)
                timer.Change(0, gameLevel);
        }

        void Run(object obj) //отвечает за запуск движения фигуры
        {
            mainFigure.CanMoveSide(ref i, ref j);
            checkStatus = mainFigure.CanMoveDown(ref i, ref j);
            if (checkStatus)
            {
                mainFigure.Run(ref i, ref j);
                screen.Invalidate();
            }
            else
            {
                checkStatus = true;

                for (i = vertLength - 1; i > 0; i--)
                    TestAllFull();
                Random();
            }
        }
    
        #endregion

        #region Проверка заполненности линий, их очистка и смещение блоков после очистки

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
            {
                level++;
                ClearLine();
            }

            
        }

        private void ClearLine() //если вся линия полностью заполнилась, очищает линию и перемещает верхние фигуры на пустую строку
        {
            lines += 1;
            for (j = 0; j < gorizontLength; j++)
            {
                mainScreen[i, j].Image = mainScreen[i, j].Images.MainImage;
                onOff[i, j] = Off;
            }

            for (int k = i; k > 0; k--)
            {
                for (j = 0; j < gorizontLength; j++)
                {
                    if (onOff[k - 1, j] == On)
                    {
                        mainScreen[k, j].Image = mainScreen[k - 1, j].Image;
                        mainScreen[k - 1, j].Image = mainScreen[k-1, j].Images.MainImage;
                        onOff[k, j] = On;
                        onOff[k - 1, j] = Off;
                    }
                }
            }
            score += level;
            controller.Score(score, lines);
            TestAllFull();
        }

        #endregion

        #region Управление поворотом и перемещением

        internal void RightMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                if (!CanNavigateRight)
                {
                    return;
                }

                navigateType = NavigateType.Right;
                MoveFigure();
            }
        }

        internal void LeftMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                if (!CanNavigateLeft)
                {
                    return;
                }
                navigateType = NavigateType.Left;
                MoveFigure();
            }
        }

        internal void DownMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                navigateType = NavigateType.Down;
                MoveFigure();
            }
        }

        internal void TurnMove()
        {
            if (GameStatus == GameStatus.Started)
            {
                navigateType = NavigateType.Turn;
                MoveFigure();
            }
        }

        private void MoveFigure()
        {
            switch (navigateType)
            {
                case NavigateType.Right:
                    mainFigure.RightMove(ref i, ref j);
                    screen.Invalidate();
                    checkStatus = true;
                    break;

                case NavigateType.Left:
                    mainFigure.LeftMove(ref i, ref j);
                    screen.Invalidate();
                    checkStatus = true;
                    break;

                case NavigateType.Down:
                    checkStatus = mainFigure.CanMoveDown(ref i, ref j);
                    if (!checkStatus)
                        return;
                    mainFigure.Run(ref i, ref j);
                    screen.Invalidate();
                    break;

                case NavigateType.Turn:
                    mainFigure.TurnMove(ref i, ref j);
                    screen.Invalidate();
                    break;
            }
        }

        #endregion
    }

}


