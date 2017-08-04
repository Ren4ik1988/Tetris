using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Tetris
{
    class Figure
    {
        FigureImg figureImg;
        public Image img;
        public int x, y;
        Random r;

        //Лучше так:

        //#region public members // добавление регионов в код дисциплинирует размещение свойств, методов и пр. еще их можно скрывать чтобы не мешались

        //public Image image; //img тоже было хорошее название, но image более описательно 
        //public int xPos, yPos; // xPos, yPos - так название более читабельно чем просто x, y

        //#endregion

        //#region private properties

        //FigureImg figureImage;
        //Random random;

        //#endregion

        //... 
        // вообще открытые члены класса должны быть с большой буквы, либо добавь методы для получения и установки в них значения.
        // x, y предлагаю заменить на объект Point

        internal Figure() // - почему решил именно internal ?
        {
            //предлагаю после этой строчки:
            figureImg = new FigureImg();
            //вызывать приватную функцию инициализации позиции
            //InitializePos();

            r = new Random();
            x = figureImg.X + r.Next(0, 225);
            y = figureImg.Y;

            img = figureImg.Img;
        }

        //в итоге конструктор с учетом всех переделок может принять вид (как один из вариантов):

        //public Figure()
        //{
        //    figureImage = new FigureImg();
        //    image = figureImg.Img;

        //    InitializePos();
        //}

        //а функция InitializePos такой вид:
        //void InitializePos()
        //{
        //  random = new Random();

        //  position = new Point(
        //      figureImg.X + random.Next(0, 225), 
        //      figureImg.Y);
        //}

        public void Run()
        {
            Thread.Sleep(100);
            y++;
        }

        #region private functions

        //void InitializePos()
        //{
            //r = new Random();
            //x = figureImg.X + r.Next(0, 225);
            //y = figureImg.Y;
        //}

        #endregion
    }
}
