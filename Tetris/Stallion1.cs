using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Stallion1 : Figure
    {
        public Stallion1(BackGraundMatrix[,] mainScreen, short[,] onOff) : base(mainScreen, onOff){}

        public override void Random(ref int i, ref int j)
        {
            randomTurnCode = randomTurn.Next(0,4);

            switch (randomTurnCode)
            {
                case 0: Random_0(); break;
                case 1: Random_1(); break;
                case 2: Random_2(); break;
                case 3: Random_3(); break;
            }
        }

        private void Random_0()
        {
            j2 = j + 1;
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
