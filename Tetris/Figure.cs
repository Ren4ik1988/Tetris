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

            #region Третья часть метода: проверяет условие заполненности матрицы
            if (i2 == (Model.vertLength - 1))
            {
                i = i2; // замена значений необходима для корректной работы методов класса Model
                return false;
            }
            else if (onOff[i2 + 1, j] == Model.On ||
                     onOff[i2 + 1, j2] == Model.On)
            {
                i = i2;
                return false;
            }
            return true;
            #endregion

        } 

        internal void RightMove(ref int i, ref int j)
        {
            if (j2 == Model.gorizontLength - 1)
                return;

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
        }

        internal void LeftMove(ref int i , ref int j)
        {
            if (j2 == 1)
                return;

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
        }

        internal void DownMove(ref int i, ref int j)
        {
            // to do
        }

        internal void TurnMove(ref int i, ref int j)
        {
            return;
        }
    }
}

