﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Triangle : Figure
    {
        public Triangle(BackGraundMatrix[,] mainScreen, short[,] onOff) : base(mainScreen, onOff){ }

        #region Определяем рандомную начальную позицию фигуры в игровом поле
        public override void Random(ref int i, ref int j)
        {
            randomTurnCode = random.Next(0, 4);

            switch (randomTurnCode)
            {
                case 0: Random_0(ref i, ref j); break;
                case 1: Random_1(ref i, ref j); break;
                case 2: Random_2(ref i, ref j); break;
                case 3: Random_3(ref i, ref j); break;
            }
        }

        private void Random_3(ref int i, ref int j)
        {
            j = random.Next(0, 7);
            j2 = j + 2;
            j3 = j + 1;
            i2 = i + 1;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNotNull.Image;
                onOff[i, k] = Model.On;
            }

            mainScreen[i2, j3].Image = Model.IsNotNull.Image;
            onOff[i2, j3] = Model.On;
        }

        private void Random_2(ref int i, ref int j)
        {
            j = random.Next(0, 9);
            i2 = i + 2;
            i3 = i + 1;
            j2 = j + 1;

            mainScreen[i3, j].Image = Model.IsNotNull.Image;
            onOff[i3, j] = Model.On;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNotNull.Image;
                onOff[k, j2] = Model.On;
            }
        }

        private void Random_1(ref int i, ref int j)
        {
            i2 = i + 1;

            j = random.Next(0, 8);
            j2 = j + 2;
            j3 = j + 1;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNotNull.Image;
                onOff[i2, k] = Model.On;
            }

            mainScreen[i, j3].Image = Model.IsNotNull.Image;
            onOff[i, j3] = Model.On;
        }

        private void Random_0(ref int i, ref int j)
        {
            j = random.Next(0, 9);
            i2 = i + 2;
            j2 = j + 1;
            i3 = i + 1;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNotNull.Image;
                onOff[k, j] = Model.On;
            }

            mainScreen[i3, j2].Image = Model.IsNotNull.Image;
            onOff[i3, j2] = Model.On;
        }

        #endregion

        #region Определяем правила движения для четырех позиций коня
        internal override bool Run(ref int i, ref int j)
        {
            switch (randomTurnCode)
            {
                case 0: return Run_0(ref i, ref j);
                case 1: return Run_1(ref i, ref j);
                case 2: return Run_2(ref i, ref j);
                case 3: return Run_3(ref i, ref j);
                default: return true;
            }
        }

        private bool Run_3(ref int i, ref int j)
        {
            #region Первая часть метода: проверяет условие заполненности матрицы
            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2, j] == Model.On ||
                        onOff[i2, j2] == Model.On ||
                            onOff[i2 + 1, j3] == Model.On )
                return false;

            #endregion

            #region Вторая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNull.Image;
                onOff[i, k] = Model.Off;
            }

            mainScreen[i2, j3].Image = Model.IsNull.Image;
            onOff[i2, j3] = Model.Off;

            #endregion

            #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            i++;
            i2++;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNotNull.Image;
                onOff[i, k] = Model.On;
            }

            mainScreen[i2, j3].Image = Model.IsNotNull.Image;
            onOff[i2, j3] = Model.On;

            return true;

            #endregion
        }

        private bool Run_2(ref int i, ref int j)
        {
            #region Первая часть метода: проверяет условие заполненности матрицы

            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2 + 1, j2] == Model.On ||
                        onOff[i2, j] == Model.On)
                return false;

            #endregion

            #region Сбрасываем ячейки на ноль

            mainScreen[i3, j].Image = Model.IsNull.Image;
            onOff[i3, j] = Model.Off;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNull.Image;
                onOff[k, j2] = Model.Off;
            }

            #endregion

            #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            i++;
            i2++;
            i3++;

            mainScreen[i3, j].Image = Model.IsNotNull.Image;
            onOff[i3, j] = Model.On;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNotNull.Image;
                onOff[k, j2] = Model.On;
            }
            #endregion

            return true;
        }

        private bool Run_1(ref int i, ref int j)
        {
            #region Первая часть метода: проверяет условие заполненности матрицы
            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2+1, j] == Model.On ||
                        onOff[i2+1, j2] == Model.On ||
                            onOff[i2 + 1, j3] == Model.On)
                return false;

            #endregion

            #region Вторая часть метода, отвечает за очистку ячеек фигуры

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNull.Image;
                onOff[i2, k] = Model.Off;
            }

            mainScreen[i, j3].Image = Model.IsNull.Image;
            onOff[i, j3] = Model.Off;

            #endregion

            #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            i++;
            i2++;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNotNull.Image;
                onOff[i2, k] = Model.On;
            }

            mainScreen[i, j3].Image = Model.IsNotNull.Image;
            onOff[i, j3] = Model.On;
            #endregion

            return true;
        }

        private bool Run_0(ref int i, ref int j)
        {
            #region Первая часть метода: проверяет условие заполненности матрицы
            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2 + 1, j] == Model.On ||
                        onOff[i2, j2] == Model.On)
                return false;

            #endregion

            #region Вторая часть метода, отвечает за очистку ячеек фигуры

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNull.Image;
                onOff[k, j] = Model.Off;
            }

            mainScreen[i3, j2].Image = Model.IsNull.Image;
            onOff[i3, j2] = Model.Off;

            #endregion

            #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            i++;
            i2++;
            i3++;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNotNull.Image;
                onOff[k, j] = Model.On;
            }

            mainScreen[i3, j2].Image = Model.IsNotNull.Image;
            onOff[i3, j2] = Model.On;
            #endregion

            return true;
        }

        #endregion

        #region Отвечает за перемещение фигуры влево
        internal override void LeftMove(ref int i, ref int j)
        {
            switch (randomTurnCode)
            {
                case 0: LeftMove_0(ref i, ref j); break;
                case 1: LeftMove_1(ref i, ref j); break;
                case 2: LeftMove_2(ref i, ref j); break;
                case 3: LeftMove_3(ref i, ref j); break;
            }
        }

        private void LeftMove_1(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j == 0 ||
                    onOff[i, j] == Model.On ||
                        onOff[i2, j-1] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNull.Image;
                onOff[i2, k] = Model.Off;
            }

            mainScreen[i, j3].Image = Model.IsNull.Image;
            onOff[i, j3] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j--;
            j2--;
            j3--;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNotNull.Image;
                onOff[i2, k] = Model.On;
            }

            mainScreen[i, j3].Image = Model.IsNotNull.Image;
            onOff[i, j3] = Model.On;

            #endregion
        }

        private void LeftMove_2(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j == 0 ||
                    onOff[i, j] == Model.On ||
                        onOff[i3, j-1] == Model.On ||
                            onOff[i2, j] == Model.On )
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры

            mainScreen[i3, j].Image = Model.IsNull.Image;
            onOff[i3, j] = Model.Off;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNull.Image;
                onOff[k, j2] = Model.Off;
            }

            #endregion

            #region Построение фигуры по новым координатам

            j--;
            j2--;

            mainScreen[i3, j].Image = Model.IsNotNull.Image;
            onOff[i3, j] = Model.On;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNotNull.Image;
                onOff[k, j2] = Model.On;
            }

            #endregion
        }

        private void LeftMove_3(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j == 0 ||
                    onOff[i, j - 1] == Model.On ||
                        onOff[i2, j] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNull.Image;
                onOff[i, k] = Model.Off;
            }

            mainScreen[i2, j3].Image = Model.IsNull.Image;
            onOff[i2, j3] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j--;
            j2--;
            j3--;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNotNull.Image;
                onOff[i, k] = Model.On;
            }

            mainScreen[i2, j3].Image = Model.IsNotNull.Image;
            onOff[i2, j3] = Model.On;

            #endregion
        }

        private void LeftMove_0(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j == 0)
            {
                Model.CanNavigateRight = false;
                return;
            }

            for (int k = i; k <= i2; k++)
                if (onOff[k, j-1] == Model.On)
                {
                    Model.CanNavigateRight = false;
                    return;
                }

            #endregion

            #region Сброс фигуры

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNull.Image;
                onOff[k, j] = Model.Off;
            }

            mainScreen[i3, j2].Image = Model.IsNull.Image;
            onOff[i3, j2] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j--;
            j2--;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNotNull.Image;
                onOff[k, j] = Model.On;
            }

            mainScreen[i3, j2].Image = Model.IsNotNull.Image;
            onOff[i, j2] = Model.On;

            #endregion
        }

        #endregion

        #region Отвечает за перемещение фигуры вправо
        internal override void RightMove(ref int i, ref int j)
        {
            switch (randomTurnCode)
            {
                case 0: RightMove_0(ref i, ref j); break;
                case 1: RightMove_1(ref i, ref j); break;
                case 2: RightMove_2(ref i, ref j); break;
                case 3: RightMove_3(ref i, ref j); break;
            }
        }

        private void RightMove_1(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j2 == Model.gorizontLength - 1 ||
                    onOff[i, j] == Model.On ||
                        onOff[i2, j2 + 1] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNull.Image;
                onOff[i2, k] = Model.Off;
            }

            mainScreen[i, j3].Image = Model.IsNull.Image;
            onOff[i, j3] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j++;
            j2++;
            j3++;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNotNull.Image;
                onOff[i2, k] = Model.On;
            }

            mainScreen[i, j3].Image = Model.IsNotNull.Image;
            onOff[i, j3] = Model.On;

            #endregion
        }

        private void RightMove_2(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j2 == Model.gorizontLength - 1)
            {
                Model.CanNavigateRight = false;
                return;
            }

            for(int  k = i; k <= i2; k++)
                if(onOff[k,j2+1] == Model.On)
                {
                    Model.CanNavigateRight = false;
                    return;
                }

            #endregion

            #region Сброс фигуры

            mainScreen[i3, j].Image = Model.IsNull.Image;
            onOff[i3, j] = Model.Off;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNull.Image;
                onOff[k, j2] = Model.Off;
            }

            #endregion

            #region Построение фигуры по новым координатам

            j++;
            j2++;

            mainScreen[i3, j].Image = Model.IsNotNull.Image;
            onOff[i3, j] = Model.On;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNotNull.Image;
                onOff[k, j2] = Model.On;
            }

            #endregion
        }

        private void RightMove_3(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j2 == Model.gorizontLength - 1 ||
                    onOff[i, j2 + 1] == Model.On ||
                        onOff[i2, j2] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNull.Image;
                onOff[i, k] = Model.Off;
            }

            mainScreen[i2, j3].Image = Model.IsNull.Image;
            onOff[i2, j3] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j++;
            j2++;
            j3++;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNotNull.Image;
                onOff[i, k] = Model.On;
            }

            mainScreen[i2, j3].Image = Model.IsNotNull.Image;
            onOff[i2, j3] = Model.On;

            #endregion
        }

        private void RightMove_0(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            if (j2 == Model.gorizontLength - 1 ||
                    onOff[i, j2] == Model.On||
                        onOff[i3, j2 + 1] == Model.On||
                            onOff[i2, j2] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNull.Image;
                onOff[k, j] = Model.Off;
            }

            mainScreen[i3, j2].Image = Model.IsNull.Image;
            onOff[i3, j2] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j++;
            j2++;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNotNull.Image;
                onOff[k, j] = Model.On;
            }

            mainScreen[i3, j2].Image = Model.IsNotNull.Image;
            onOff[i3, j2] = Model.On;

            #endregion
        }

        #endregion

        #region Отвечает за поворот фигуры вокруг своей оси
        internal override void TurnMove(ref int i, ref int j)
        {
            switch (randomTurnCode)
            {
                case 0: TurnMove_0(ref i, ref j); break;
                case 1: TurnMove_1(ref i, ref j); break;
                case 2: TurnMove_2(ref i, ref j); break;
                case 3: TurnMove_3(ref i, ref j); break;
            }
        }

        private void TurnMove_0(ref int i, ref int j)
        {
            #region Проверка возможности поворота
            int tmp_j2 = j + 2;
            int tmp_i2 = i + 1;
            int tmp_j3 = j + 1;
            if (tmp_j2 > (Model.gorizontLength - 1) ||
                    onOff[i, tmp_j3] == Model.On ||
                        onOff[tmp_i2, tmp_j2] == Model.On )
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры
            randomTurnCode++;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNull.Image;
                onOff[k, j] = Model.Off;
            }

            mainScreen[i3, j2].Image = Model.IsNull.Image;
            onOff[i3, j2] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j2 = tmp_j2;
            i2 = tmp_i2;
            j3 = tmp_j3;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNotNull.Image;
                onOff[i2, k] = Model.On;
            }

            mainScreen[i, j3].Image = Model.IsNotNull.Image;
            onOff[i, j3] = Model.On;

            #endregion
        }

        private void TurnMove_1(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения

            int tmp_j2 = j + 1;
            int tmp_i2 = i + 2;
            int tmp_i3 = i + 1;
            if (tmp_j2 > (Model.gorizontLength - 1) ||
                    onOff[tmp_i2, tmp_j2] == Model.On )
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры
            randomTurnCode++;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNull.Image;
                onOff[i2, k] = Model.Off;
            }

            mainScreen[i, j3].Image = Model.IsNull.Image;
            onOff[i, j3] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам
            j2 = tmp_j2;
            i2 = tmp_i2;
            i3 = tmp_i3;

            mainScreen[i3, j].Image = Model.IsNotNull.Image;
            onOff[i3, j2] = Model.On;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNotNull.Image;
                onOff[k, j2] = Model.On;
            }

            #endregion
        }

        private void TurnMove_2(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения
            int tmp_i2 = i + 1;
            int tmp_j2 = j + 2;
            int tmp_j3 = j + 1;

            if (tmp_j2 > Model.gorizontLength - 1 ||
                    onOff[i, tmp_j2] == Model.On ||
                        onOff[i, j] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры
            randomTurnCode++;

            mainScreen[i3, j].Image = Model.IsNull.Image;
            onOff[i3, j] = Model.Off;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNull.Image;
                onOff[k, j2] = Model.Off;
            }

            #endregion

            #region Построение фигуры по новым координатам

            i2 = tmp_i2;
            j2 = tmp_j2;
            j3 = tmp_j3;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNotNull.Image;
                onOff[i, k] = Model.On;
            }

            mainScreen[i2, j3].Image = Model.IsNotNull.Image;
            onOff[i2, j3] = Model.On;

            #endregion
        }

        private void TurnMove_3(ref int i, ref int j)
        {
            #region Проверка свободна ли боковая ячейка для перемещения
            int tmp_i2 = i + 2;
            int tmp_j2 = j + 1;
            int tmp_i3 = i + 1;

            if (tmp_j2 > Model.gorizontLength - 1 ||
                    onOff[tmp_i3, j] == Model.On ||
                        onOff[tmp_i2, j] == Model.On )
            {
                Model.CanNavigateRight = false;
                return;
            }

            #endregion

            #region Сброс фигуры
            randomTurnCode = 0;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNull.Image;
                onOff[i, k] = Model.Off;
            }

            mainScreen[i2, j2].Image = Model.IsNull.Image;
            onOff[i2, j3] = Model.Off;

            #endregion

            #region Построение фигуры по новым координатам

            j2 = tmp_j2;
            i2 = tmp_i2;
            i3 = tmp_i3;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNotNull.Image;
                onOff[k, j] = Model.On;
            }

            mainScreen[i3, j2].Image = Model.IsNotNull.Image;
            onOff[i3, j2] = Model.On;

            #endregion
        }

        #endregion
    }
}
