using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Line : Figure
    {
        public Line(BackGraundMatrix[,] mainScreen, short[,] onOff, BackGraundMatrix[,] nextScreen) : base(mainScreen, onOff, nextScreen) 
                    => IsNotNull.Image = IsNotNull.Images.LineImage;

        #region Определяем начальную позицию фигуры и ее поворот: 0 - линия горизонтальная, 1 - вертикальная
        public override void Random(ref int i, ref int j)
        {
            randomTurnCode = random.Next(0, 2);

            if (randomTurnCode == 0)
            {
                j = random.Next(0, 6);

                j2 = j + 3;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = IsNotNull.Image;
                    onOff[i, k] = Model.On;
                }
            }
            else
            {
                i2 = i + 3;
                j = random.Next(0, 10);

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }
            }
        }
        #endregion

        internal override void Run(ref int i, ref int j)
        {
            if (randomTurnCode == 0)
            {
                #region Первая часть метода: проверяет условие заполненности матрицы
                if (i == (Model.vertLength - 1))
                    return;

                for (int k = j; k <= j2; k++)
                {
                    if (onOff[i + 1, k] == Model.On)
                        return;
                }
                #endregion

                #region Вторая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = IsNull.Image;
                    onOff[i, k] = Model.Off;
                }

                #endregion

                #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

                ++i;
                i2 = i;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = IsNotNull.Image;
                    onOff[i, k] = Model.On;
                }

                #endregion

            }
            else
            {
                #region Первая часть метода: проверяет условие заполненности матрицы

                if (i2 == (Model.vertLength - 1) ||
                        onOff[i2 + 1, j] == Model.On )
                    return;

                #endregion

                #region Вторая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

                mainScreen[i, j].Image = IsNull.Image;
                onOff[i, j] = Model.Off;

                #endregion

                #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

                ++i;
                ++i2;

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }

                #endregion;
            }
        }

        internal override void LeftMove(ref int i, ref int j)
        {
            if (randomTurnCode == 0)
            {
                #region Проверка свободна ли боковая ячейка для перемещения
                j2 = j + 3;

                if (j == 0 ||
                        onOff[i, j - 1] == Model.On)
                {
                    Model.CanNavigateLeft = false;
                    return;
                }
                #endregion

                #region Сброс крайней правой ячейки фигуры

                mainScreen[i, j2].Image = IsNull.Image;
                onOff[i, j2] = Model.Off;

                #endregion

                #region Построение фигуры по новым координатам

                j--;
                j2--;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = IsNotNull.Image;
                    onOff[i, j] = Model.On;
                }

                #endregion
            }
            else
            {
                #region Проверка свободна ли боковая ячейка для перемещения
                i2 = i + 3;

                if (j == 0)
                {
                    Model.CanNavigateLeft = false;
                    return;
                }

                for (int k = i; k <= i2; k++)
                {
                    if (onOff[k, j - 1] == Model.On)
                    {
                        Model.CanNavigateLeft = false;
                        return;
                    }
                }
                #endregion

                #region Сброс ячеек текущего расположения фигуры

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNull.Image;
                    onOff[k, j] = Model.Off;
                }

                #endregion

                #region Построение фигуры по новым координатам

                j--;

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }

                #endregion
            
            }
        }

        internal override void RightMove(ref int i, ref int j)
        {
            if (randomTurnCode == 0)
            {
                #region Проверка свободна ли боковая ячейка для перемещения
                j2 = j + 3;

                if (j2 == Model.gorizontLength - 1 ||
                        onOff[i, j2 + 1] == Model.On)
                {
                    Model.CanNavigateRight = false;
                    return;
                }
                #endregion

                #region Сброс крайней левой ячейки фигуры

                mainScreen[i, j].Image = IsNull.Image;
                onOff[i, j] = Model.Off;

                #endregion

                #region Построение фигуры по новым координатам

                j++;
                j2++;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = IsNotNull.Image;
                    onOff[i, j] = Model.On;
                }

                #endregion
            }
            else
            {
                #region Проверка свободна ли боковая ячейка для перемещения
                i2 = i + 3;

                if (j == Model.gorizontLength - 1)
                {
                    Model.CanNavigateRight = false;
                    return;
                }

                for (int k = i; k <= i2; k++)
                {
                    if (onOff[k,j+1] == Model.On)
                    {
                        Model.CanNavigateRight = false;
                        return;
                    }
                }
                #endregion

                #region Сброс ячеек текущего расположения фигуры

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNull.Image;
                    onOff[k, j] = Model.Off;
                }

                #endregion

                #region Построение фигуры по новым координатам

                j++;

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }

                #endregion
            }
        }

        internal override void TurnMove(ref int i, ref int j)
        {
            if (randomTurnCode == 0)
            {
                #region Проверяем условия возможности поворота с горизонтали на вертикаль

                i2 = i + 3;

                if (i2 > Model.vertLength - 1 || onOff[i2, j] == Model.On)
                {
                    Model.CanNavigateRight = false;
                    return;
                }
                #endregion

                #region Сбрасываем горизонталь

                j2 = j + 3;
                randomTurnCode = 1;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = IsNull.Image;
                    onOff[i, k] = Model.Off;
                }
                #endregion
                 
                #region Заполняем вертикаль 

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }

                #endregion
            }
            else
            {
                #region Проверяем условия возможности поворота с вертикали на горизонталь

                j2 = j + 3;

                if (j2 > Model.gorizontLength - 1 || onOff[i, j2] == Model.On)
                {
                    Model.CanNavigateRight = false;
                    return;
                }
                #endregion

                #region Сбрасываем вертикаль

                i2 = i + 3;
                randomTurnCode = 0;

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = IsNull.Image;
                    onOff[k, j] = Model.Off;
                }

                #endregion

                #region Заполняем горизонталь

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = IsNotNull.Image;
                    onOff[i, k] = Model.On;
                }
                #endregion
            }
        }

        internal override void CanMoveSide(ref int i, ref int j)
        {
            if (randomTurnCode == 0)
            {
                if (j == 0 ||
                        onOff[i, j - 1] == Model.On)
                    Model.CanNavigateLeft = false;
                else
                    Model.CanNavigateLeft = true;

                if (j2 == Model.gorizontLength - 1 ||
                        onOff[i, j2 + 1] == Model.On)
                    Model.CanNavigateRight = false;
                else
                    Model.CanNavigateRight = true;
            }
            else
            {
                if (j == Model.gorizontLength - 1 ||
                        onOff[i, j + 1] == Model.On ||
                            onOff[i + 1, j + 1] == Model.On ||
                                onOff[i + 2, j + 1] == Model.On ||
                                    onOff[i2, j + 1] == Model.On)
                    Model.CanNavigateRight = false;
                else
                    Model.CanNavigateRight = true;

                if (j == 0 ||
                    onOff[i, j - 1] == Model.On ||
                        onOff[i + 1, j - 1] == Model.On ||
                            onOff[i + 2, j - 1] == Model.On ||
                                onOff[i2, j - 1] == Model.On)
                    Model.CanNavigateLeft = false;
                else
                    Model.CanNavigateLeft = true;
            }
        }

        internal override bool CanMoveDown(ref int i, ref int j)
        {
            if (randomTurnCode == 0)
            {
                if (i == (Model.vertLength - 1))
                    return false;

                for (int k = j; k <= j2; k++)
                {
                    if (onOff[i + 1, k] == Model.On)
                        return false;
                }
                return true;
            }
            else
            {
                if (i2 == (Model.vertLength - 1) ||
                        onOff[i2 + 1, j] == Model.On)
                    return false;
                return true;
            }
        }
    }
}
