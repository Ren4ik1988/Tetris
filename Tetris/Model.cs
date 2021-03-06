﻿using System;
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

        #region Readonly: для обозначения пустой ячейки и заполненной соответственно
        static readonly BackGraundMatrix isNull;
        static readonly BackGraundMatrix isNotNull;
        internal static BackGraundMatrix IsNull => isNull;
        internal static BackGraundMatrix IsNotNull => isNotNull;
        #endregion

        #region Переменные для объектов фигур

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

        public GameStatus GameStatus;
        Random random;
        static bool checkStatus;
        int i, j; //поля определяют номера ячеек матрицы
        int gameLevel; //определяет скорость игры
        Timer timer;
        TimerCallback moveBlock;
        Screen screen;
        bool navigatorStatus;
        NavigateType navigateType;
        FigureList figurelist;
        static bool canNavigateRight;
        static bool canNavigateLeft;

        BackGraundMatrix[,] mainScreen; // основной слой экрана, создается по типу матрицы обычного монитора, но вместо пикселей ячейки 
        short[,] onOff;

        #endregion

        #region Constructors
        public Model()
        {
            GameStatus = GameStatus.NewGame;
            gameLevel = Easy;
            navigateType = NavigateType.Right;
            random = new Random();
            checkStatus = true;
            navigatorStatus = false;
            FillMatrix();
            figure = new Figure(mainScreen, onOff);
            line = new Line(mainScreen, onOff);
        }

        static Model()
        {
            isNull = new BackGraundMatrix();
            isNotNull = new BackGraundMatrix();
            isNotNull.PutImg();
        }

        #endregion

        #region Свойства

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }
        public int GameLevel { set => gameLevel = value; }
        public static bool CanNavigateRight { get => canNavigateRight; set => canNavigateRight = value; }
        public static bool CanNavigateLeft { get => canNavigateLeft; set => canNavigateLeft = value; }

        #endregion

        #region Построение сетки/очистка игрового поля, выбор случайной фигуры и запуск ее обрисовки

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

            #region Создание объектов всех игровых фигур

            stallion1 = new Stallion1(mainScreen, onOff);
            figure = new Figure(mainScreen, onOff);
            line = new Line(mainScreen, onOff);
            stallion2 = new Stallion2(mainScreen, onOff);
            triangle = new Triangle(mainScreen, onOff);
            zFigure = new ZFigure(mainScreen, onOff);
            sFigure = new SFigure(mainScreen, onOff);

            #endregion

        }

        public void Random()
        {
            i = 0;

            ChooseFigure();
            mainFigure.Random(ref i, ref j);

            if (screen != null)
                screen.Invalidate();

            CanNavigateRight = canNavigateLeft = true;
        }

        private void ChooseFigure()
        {
            figurelist = (FigureList)random.Next(0, 7);

            switch (figurelist)
            {
                case FigureList.rectangle: mainFigure = figure; break;
                case FigureList.line: mainFigure = line; break;
                case FigureList.stallion1: mainFigure = stallion1; break;
                case FigureList.stallion2: mainFigure = stallion2; break;
                case FigureList.triangle: mainFigure = triangle; break;
                case FigureList.sfigure: mainFigure = sFigure; break;
                case FigureList.zfigure: mainFigure = zFigure; break;
            }
        }

        #endregion

        #region Скорость игры и движение фигур

        public void StartTimer(Screen screen)
        {
            if (GameStatus == GameStatus.NewGame)
            {
                GameStatus = GameStatus.Started;
                this.screen = screen;
            
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

                navigatorStatus = true;
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
                MoveFigure();
            }
        }

        private void MoveFigure()
        {
            navigatorStatus = false;

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


