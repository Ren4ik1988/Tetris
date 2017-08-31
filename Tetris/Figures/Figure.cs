using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Figure
    {
        #region Protected fields

        protected int randomTurnCode;
        protected Random random;
        static protected int i2, j2, i3, j3;
        protected BackGraundMatrix[,] mainScreen;
        protected short[,] onOff;

        #endregion

        public Figure(BackGraundMatrix[,] mainScreen, short[,] onOff)
        {
            this.mainScreen = mainScreen;
            this.onOff = onOff;
            random = new Random();
        }

        internal virtual int Current_i()
        {
            return i2;
        }

        public virtual void Random(ref int i, ref int j) 
        {
            j = random.Next(0,9);

            i2 = i + 1;
            j2 = j + 1;

            for ( int k = i; k <= i2; k++)
                for( int l = j; l <=j2; l++)
                {
                    mainScreen[k, l].Image = Model.IsNotNull.Image;
                    onOff[k, l] = Model.On;
                }
        }

        internal virtual bool Run(ref int i, ref int j) 
        {
            #region Третья часть метода: проверяет условие заполненности матрицы

            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2 + 1, j] == Model.On ||
                        onOff[i2 + 1, j2] == Model.On)
                return false;

            #endregion

            #region Первая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

            for (int k = i; k <= i2; k++)
                for (int l = j; l <= j2; l++)
                {
                    mainScreen[k, l].Image = Model.IsNull.Image;
                    onOff[k, l] = Model.Off;
                }

            #endregion

            #region Вторая часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            ++i;
            ++i2;

            for (int k = i; k <= i2; k++)
                for (int l = j; l <= j2; l++)
                {
                    mainScreen[k, l].Image = Model.IsNotNull.Image;
                    onOff[k, l] = Model.On;
                }
            
            #endregion

            return true;
        }

        internal virtual void RightMove(ref int i, ref int j)
        {
            #region Первое условие, проверяет свободны ли боковые ячейки для перемещения

            if (j2 == Model.gorizontLength - 1 ||
                    onOff[i, j2 + 1] == Model.On ||
                        onOff[i2, j2 + 1] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }
            #endregion


            #region Сбарсываем старую фигуру

            for (int k = i; k <= i2; k++)
                for (int l = j; l <= j2; l++)
                {
                    mainScreen[k, l].Image = Model.IsNull.Image;
                    onOff[k, l] = Model.Off;
                }

            #endregion

            #region Рисуем новую фигуру
            j++;
            j2++;

            for (int k = i; k <= i2; k++)
                for (int l = j; l <= j2; l++)
                {
                    mainScreen[k, l].Image = Model.IsNotNull.Image;
                    onOff[k, l] = Model.On;
                }

            #endregion

            //Дублирование кода из начала метода необходимо для улучшения логики игры,
            //если квадрат уже упал на повехность, остается еще возможность сместить его на одну ячейку вправо
            #region Второе условие позволяет перенести объект на одну клетку влево, если даже по горизонтальной линии уже достигнут предел.
            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2 + 1, j] == Model.On ||
                        onOff[i2 + 1, j2] == Model.On)
            {
                Model.CanNavigateRight = false;
                return;
            }
            #endregion
        }

        internal virtual void LeftMove(ref int i, ref int j)
        {
            #region Первое условие, проверяет свободны ли боковые ячейки для перемещения
            if (j2 == 1 ||
                 onOff[i, j - 1] == Model.On ||
                     onOff[i2, j - 1] == Model.On)
            {
                Model.CanNavigateLeft = false;
                return;
            }
            #endregion

            #region Сбарсываем элементы правого столбца фигуры

            for (int k = i; k <= i2; k++)
                for (int l = j; l <= j2; l++)
                {
                    mainScreen[k, l].Image = Model.IsNull.Image;
                    onOff[k, l] = Model.Off;
                }

            #endregion

            #region Дополняем левую часть фигуры новыми элементами
            j--;
            j2--;

            for (int k = i; k <= i2; k++)
                for (int l = j; l <= j2; l++)
                {
                    mainScreen[k, l].Image = Model.IsNotNull.Image;
                    onOff[k, l] = Model.On;
                }

            #endregion

            #region Второе условие позволяет перенести объект на одну клетку влево, если даже по горизонтальной линии уже достигнут предел.

            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2 + 1, j] == Model.On ||
                        onOff[i2 + 1, j2] == Model.On)
            {
                Model.CanNavigateLeft = false;
                return;
            }
            #endregion
        }

        internal virtual void DownMove(ref int i, ref int j)
        {
            //реализуется через метод Run()
        }


        internal virtual void TurnMove(ref int i, ref int j)
        {
            return;
        }
    }
    
}

