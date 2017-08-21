using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Figure
    {
        int i, j;
        BackGraundMatrix[,] mainScreen;

        public Figure(BackGraundMatrix[,] mainScreen)
        {
            this.mainScreen = mainScreen;
        }

        public void Random(ref int i,ref int j) // метод вызывается когда необходимо создать фигуру "квадрат"
        {
            this.i = ++i;

            if (j > 8)
                this.j = --j;
            else
                this.j = j;

            mainScreen[i, j].PutImg(); // меняет изображение переменной Image на картинку блока

            mainScreen[i, j].Image = mainScreen[i, j].Image; // производит замену элемента ячейки
            mainScreen[i, j+1].Image = mainScreen[i, j].Image;
            mainScreen[i-1, j].Image = mainScreen[i, j].Image;
            mainScreen[i-1, j+1].Image = mainScreen[i, j].Image;
        }

        internal void Run(ref int i, ref int j)
        {
            this.i = i;
            this.j = j;

        #region Первая часть метода, отвечающая за очистку вверхних ячеек при перемещении объекта вниз
            mainScreen[i, j].PutImg();

            mainScreen[i-1, j].Image = mainScreen[i, j].Image; 
            mainScreen[i-1, j + 1].Image = mainScreen[i, j].Image;
            #endregion

        #region Вторая часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)
            i++;
            mainScreen[i, j].PutImg();

            mainScreen[i, j].Image = mainScreen[i, j].Image;
            mainScreen[i, j + 1].Image = mainScreen[i, j].Image;
            mainScreen[i - 1, j].Image = mainScreen[i, j].Image;
            mainScreen[i - 1, j + 1].Image = mainScreen[i, j].Image;

            #endregion

        }
    }
}
