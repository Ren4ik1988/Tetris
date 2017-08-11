using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tetris
{
    class Model // вмещает в себя логику игры
    {
        private List<Figure> figure;
        public GameStatus GameStatus;
        int numberOfBlock;

        internal List<Figure> Figure { get => figure; }

        public Model() 
        {
            figure = new List<Figure>() { new Figure() };
            GameStatus = GameStatus.Paused;
        }

        public void Play(object obj)
        {
            if (GameStatus != GameStatus.StartNew)
            {
                //почему именно 445 ?
                //если это не случайное число, то вынеси в константу и назови как-нибудь))
                //в программировании такие вещи называют "магическими числами", это нехорошо.
                //На самом деле не обязательно выносить в константу, можно даже в локальную переменную,
                //главное чтобы название было у этого числа
                if (Figure[numberOfBlock].Position.Y != 475)
                {

                    Figure[numberOfBlock].Run();
                }
                else
                {
                    numberOfBlock = figure.Count;
                    figure.Add(new Figure());
                    Figure[numberOfBlock].Run();
                }
            }
        }

        internal void Reset()
        {
            numberOfBlock = 0;
            figure.Clear();
            figure = new List<Figure>() { new Figure() }; //такая строчка уже есть в конструкторе. 
            //Вынеси в функцию, например - InitializeFigureList()
        }
    }
}
