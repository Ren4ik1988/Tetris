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

        public void AddNew1(int i, int j) // дополняетя квадрарт элементами для визуальной зарисовки квадрата
        {
            this.i = i;
            this.j = j;
            
            mainScreen[i, j+1].Image = mainScreen[i, j].Image;
            mainScreen[i+1, j].Image = mainScreen[i, j].Image;
            mainScreen[i+1, j+1].Image = mainScreen[i, j].Image;

             mainScreen[i + 1, j + 1].PutImg();
            if (mainScreen[i + 1, j].Image == mainScreen[i+1, j].Images.MainImage)
                mainScreen[i + 1, j].PutImg();
            if (mainScreen[i, j + 1].Image == mainScreen[i + 1, j + 1].Images.MainImage)
                mainScreen[i, j + 1].PutImg();
        }
    }
}
