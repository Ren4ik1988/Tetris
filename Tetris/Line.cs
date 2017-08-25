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

            randomTurnCode = randomTurn.Next(0, 2);

            if (randomTurnCode == 0)
            {
                #region Проверяем не выходит ли линия за пределы боковых границ
                if (j > Model.gorizontLength - 4)
                {
                    j = j - 3;
                }
                #endregion

                j2 = j + 3;

                for (int k = j; k <= j2; k++)
                {
                    mainScreen[i, k].Image = Model.IsNotNull.Image;
                    onOff[i, k] = Model.On;
                }
            }
            else
            {
                i2 = i + 3;

                for (int k = i; k <= i2; k++)
                {
                    mainScreen[k, j].Image = Model.IsNotNull.Image;
                    onOff[k, j] = Model.On;
                }
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
