using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Figure
    {
        int i, j; // поля совместимы с полями из класса Model
        static int i2, j2; // вспомогательные поля для обозначения позиций дополнительных элементов фигуры
        BackGraundMatrix[,] mainScreen;
        short[,] onOff;

        public Figure(BackGraundMatrix[,] mainScreen, short[,] onOff)
        {
            this.mainScreen = mainScreen;
            this.onOff = onOff;
        }

        internal int Current_i()
        {
            return i2;
        }

        public void Random(ref int i, ref int j) // метод вызывается когда необходимо создать фигуру "квадрат"
        {
            this.i = i;

            if (j > 8)  //условия исключает возможность выхода значения квадрата за пределы массива по горизонатльной линии
                this.j = --j;
            else
                this.j = j;
            i2 = i + 1;
            j2 = j + 1;

            mainScreen[i, j].Image =
                mainScreen[i, j2].Image =
                    mainScreen[i2, j].Image =
                        mainScreen[i2, j2].Image = Model.IsNotNull.Image;

            onOff[i, j] = onOff[i, j2] = onOff[i2, j] = onOff[i2, j2] = Model.On;
        }

        internal bool Run(ref int i, ref int j) //метод определяет логику движения квадрата и заполнение игрового поля
        {
            this.i = i;
            this.j = j;

            #region Третья часть метода: проверяет условие заполненности матрицы
            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2 + 1, j] == Model.On ||
                        onOff[i2 + 1, j2] == Model.On)
            {
                return false;
            }
            #endregion

            #region Первая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

            mainScreen[i, j].Image = mainScreen[i, j2].Image = Model.IsNull.Image;
            onOff[i, j] = onOff[i, j2] = Model.Off;

            #endregion

            #region Вторая часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            ++i;
            ++i2;

            mainScreen[i, j].Image =
                mainScreen[i, j2].Image =
                    mainScreen[i2, j].Image =
                        mainScreen[i2, j2].Image = Model.IsNotNull.Image;

            onOff[i, j] = onOff[i, j2] = onOff[i2, j] = onOff[i2, j2] = Model.On;


            #endregion

            return true;
        }

        internal void RightMove(ref int i, ref int j)
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

            this.i = i;
            this.j = j;

            #region Сбарсываем элементы левого столбца фигуры

            mainScreen[i, j].Image =
                mainScreen[i2, j].Image = Model.IsNull.Image;

            onOff[i, j] = onOff[i2, j] = Model.Off;

            #endregion

            #region Дополняем правую часть фигуры новыми элементами
            j++;
            j2++;

            mainScreen[i, j2].Image =
                mainScreen[i2, j2].Image = Model.IsNotNull.Image;

            onOff[i, j2] = onOff[i2, j2] = Model.On;

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

        internal void LeftMove(ref int i, ref int j)
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

            this.i = i;
            this.j = j;

            #region Сбарсываем элементы правого столбца фигуры

            mainScreen[i, j2].Image =
                mainScreen[i2, j2].Image = Model.IsNull.Image;

            onOff[i, j2] = onOff[i2, j2] = Model.Off;

            #endregion

            #region Дополняем левую часть фигуры новыми элементами
            j--;
            j2--;

            mainScreen[i, j].Image =
                mainScreen[i2, j].Image = Model.IsNotNull.Image;

            onOff[i, j] = onOff[i2, j] = Model.On;

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

        internal void DownMove(ref int i, ref int j)
        {
            //реализуется через метод Run()
        }


        internal void TurnMove(ref int i, ref int j)
        {
            return;
        }
    }
    
}

