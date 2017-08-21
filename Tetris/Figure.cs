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

            if (j > 8)
                this.j = --j;
            else
                this.j = j;
            i2 = i + 1;
            j2 = j + 1;

            mainScreen[i, j].PutImg(); // меняет изображение переменной Image на картинку блока

            mainScreen[i, j].Image = mainScreen[i, j].Image; // производит замену элемента ячейки
            mainScreen[i, j2].Image = mainScreen[i, j].Image;
            mainScreen[i2, j].Image = mainScreen[i, j].Image;
            mainScreen[i2, j2].Image = mainScreen[i, j].Image;
            onOff[i, j] = onOff[i, j2] = onOff[i2, j] = onOff[i2, j2] = Model.On;
        }

        internal bool Run(ref int i, ref int j)
        {
            this.i = i;
            this.j = j;

            #region Первая часть метода, отвечающая за очистку вверхних ячеек при перемещении объекта вниз

            mainScreen[i, j].PutImg();
            mainScreen[i, j].Image = mainScreen[i, j].Image;
            mainScreen[i, j2].Image = mainScreen[i, j].Image;
            onOff[i, j] = onOff[i, j2] = Model.Off;

            #endregion


            #region Вторая часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)
            ++i;
            ++i2;
            mainScreen[i, j].PutImg();

            mainScreen[i, j].Image = mainScreen[i, j].Image;
            mainScreen[i, j2].Image = mainScreen[i, j].Image;
            mainScreen[i2, j].Image = mainScreen[i, j].Image;
            mainScreen[i2, j2].Image = mainScreen[i, j].Image;
            onOff[i, j] = onOff[i, j2] = onOff[i2, j] = onOff[i2, j2] = Model.On;

            #endregion

            if (i2 == (Model.vertLength - 1))
                return false;
            else if (onOff[i2+1,j] == Model.On ||
                     onOff[i2+1, j2] == Model.On)
                return false;
            return true;

        }
    }
}
