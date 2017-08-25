using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Line : Figure
    {
        public Line(BackGraundMatrix[,] mainScreen, short[,] onOff) : base(mainScreen, onOff){}

        public override void Random(ref int i, ref int j)
        {
            this.i = i;

            randomTurnCode = randomTurn.Next(0, 2);

            if (randomTurnCode == 0)
            {
                #region Проверяем не выходит ли линия за пределы боковых границ
                if (j > Model.gorizontLength - 4)
                {
                    j = j - 3;
                }
                #endregion

                j2 = j + 3;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = Model.IsNotNull.Image;
                    onOff[i, k] = Model.On;
                }
            }
            else
            {
                i2 = i + 3;

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = Model.IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }
            }
        }

        internal override int Current_i()
        {
            return base.Current_i();
        }

        internal override bool Run(ref int i, ref int j)
        {
            if (randomTurnCode == 0)
            {
                #region Первая часть метода: проверяет условие заполненности матрицы
                if (i == (Model.vertLength - 1) )
                    return false;

                for (int k = j; k <= j2; k++)
                {
                    if (onOff[i + 1, k] == Model.On)
                        return false;
                }
                #endregion

                #region Вторая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = Model.IsNull.Image;
                    onOff[i, k] = Model.Off;
                }

                #endregion

                #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

                ++i;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = Model.IsNotNull.Image;
                    onOff[i, k] = Model.On;
                }

                #endregion

                return true;

            }
            else
            {
                #region Первая часть метода: проверяет условие заполненности матрицы
                if (i2 == (Model.vertLength - 1) ||
                        onOff[i2 + 1, j] == Model.On ||
                            onOff[i2 + 1, j2] == Model.On)
                {
                    return false;
                }
                #endregion

                #region Вторая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

                mainScreen[i, j].Image = Model.IsNull.Image;
                onOff[i, j] = Model.Off;

                #endregion

                #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

                ++i;
                ++i2;

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = Model.IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }

                #endregion

                return true;
            }
        }

        internal override void DownMove(ref int i, ref int j)
        {
            base.DownMove(ref i, ref j);
        }

        internal override void LeftMove(ref int i, ref int j)
        {
            base.LeftMove(ref i, ref j);
        }

        internal override void RightMove(ref int i, ref int j)
        {
            base.RightMove(ref i, ref j);
        }

        internal override void TurnMove(ref int i, ref int j)
        {
            base.TurnMove(ref i, ref j);
        }
    }
}
