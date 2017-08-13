using System;
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

        public const int vertLength = 20;
        public const int gorizontLength = 10;

        #endregion

        Random random;
        int i, j; //поля определяют номера ячеек матрицы
        Timer timer;
        TimerCallback moveBlock;
        Screen screen;

        BackGraundMatrix[,] mainScreen; // основной слой экрана, создается по типу матрицы обычного монитора, но вместо пикселей ячейки 

        public Model()
        {
            random = new Random();
            mainScreen = new BackGraundMatrix[vertLength, gorizontLength];
            FillMatrix();
        }

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }

        private void FillMatrix()
        {
            for (int i = 0; i < vertLength; i++)
                for (int j = 0; j < gorizontLength; j++)
                {
                    mainScreen[i, j] = new BackGraundMatrix();
                }
        }

        public void Random()
        {
            j = random.Next(0, 9); //определяет рандомную позицию блока по горизонтальной координате
            mainScreen[i, j].PutImg(); // меняет изображение переменной Image на картинку блока
            mainScreen[i, j].Image = mainScreen[i, j].Image; // производит замену элемента ячейки
        }

        public void StartTimer(Screen screen)
        {
            this.screen = screen;
            moveBlock = new TimerCallback(Run);
            timer = new Timer(moveBlock, null, 1000, 1000);
        }

        void Run(object obj)
        {
            mainScreen[i, j].PutImg();
            mainScreen[i, j].Image = mainScreen[i, j].Image;
            i++;
            mainScreen[i, j].PutImg();
            mainScreen[i, j].Image = mainScreen[i, j].Image;

            screen.Invalidate();
            if (i == (vertLength-1) )
                timer.Change(Timeout.Infinite, 0);
        }
    }
}
