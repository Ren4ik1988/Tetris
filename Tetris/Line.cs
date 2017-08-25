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
            this.j = j;

            randomTurnCode = randomTurn.Next(0, 2);

            if(randomTurnCode == 0)
            {

            }
            else
            {

            }


        }

        internal override int Current_i()
        {
            return base.Current_i();
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

        internal override bool Run(ref int i, ref int j)
        {
            return base.Run(ref i, ref j);
        }

        internal override void TurnMove(ref int i, ref int j)
        {
            base.TurnMove(ref i, ref j);
        }
    }
}
