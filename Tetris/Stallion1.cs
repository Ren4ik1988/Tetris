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

        #region Определяем рандомную начальную позицию фигуры в игровом поле
        public override void Random(ref int i, ref int j)
        {
            randomTurnCode = random.Next(0,4);

            switch (randomTurnCode)
            {
                case 0: Random_0(ref i, ref j); break;
                case 1: Random_1(ref i, ref j); break;
                case 2: Random_2(ref i, ref j); break;
                case 3: Random_3(ref i, ref j); break;
            }
        }

        private void Random_3(ref int i, ref int j)
        {
            j = random.Next(0,7);
            j2 = j + 2;
            i2 = i + 1;

            for(int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNotNull.Image;
                onOff[i, k] = Model.On;
            }

            mainScreen[i2, j].Image = Model.IsNotNull.Image;
            onOff[i2, j] = Model.On;
        }

        private void Random_2(ref int i, ref int j)
        {
            j = random.Next(0,9);
            i2 = i + 2;
            j2 = j + 1;

            mainScreen[i, j].Image = Model.IsNotNull.Image;
            onOff[i, j] = Model.On;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNotNull.Image;
                onOff[k, j2] = Model.On;
            }
        }

        private void Random_1(ref int i, ref int j)
        {
            i2 = i + 1;

            j = random.Next(0, 8);
            j2 = j + 2;

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i2, k].Image = Model.IsNotNull.Image;
                onOff[i2, k] = Model.On;
            }

            mainScreen[i, j2].Image = Model.IsNotNull.Image;
            onOff[i, j2] = Model.On;
        }

        private void Random_0(ref int i, ref int j)
        {
            j = random.Next(0, 9);

            i2 = i + 2;
            j2 = j + 1;
            
            for (int k = i; k <= i2; k++)
            {
                mainScreen[i, j].Image = Model.IsNotNull.Image;
                onOff[i, j] = Model.On;
            }

            mainScreen[i2, j2].Image = Model.IsNotNull.Image;
            onOff[i2, j2] = Model.On;
        }

        #endregion

        #region Определяем правила движения для четырех позиций коня
        internal override bool Run(ref int i, ref int j)
        {
            switch (randomTurnCode)
            {
                case 0: return Run_0(ref i, ref j);
                case 1: return Run_1(ref i, ref j);
                case 2: return Run_2(ref i, ref j);
                case 3: return Run_3(ref i, ref j);
                default: return true;
            }
        }

        private bool Run_3(ref int i, ref int j)
        {
            throw new NotImplementedException();
        }

        private bool Run_2(ref int i, ref int j)
        {
            #region Первая часть метода: проверяет условие заполненности матрицы
            j2 = j + 1;
            i2 = i + 2;

            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2 + 1, j2] == Model.On )
                return false;

            #endregion

            #region Вторая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

            for (int k = j; k <= j2; k++)
            {
                mainScreen[i, k].Image = Model.IsNull.Image;
                onOff[i, k] = Model.Off;
            }

            #endregion

            #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            i++;
            i2++;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j2].Image = Model.IsNotNull.Image;
                onOff[k, j2] = Model.On;
            }

            mainScreen[i, j].Image = Model.IsNotNull.Image;
            onOff[i, j] = Model.On;
            #endregion

            return true;
        }
    

        private bool Run_1(ref int i, ref int j)
        {
            throw new NotImplementedException();
        }

        private bool Run_0(ref int i, ref int j)
        {
            #region Первая часть метода: проверяет условие заполненности матрицы
            if (i2 == (Model.vertLength - 1) ||
                    onOff[i2+1,j] == Model.On ||
                        onOff[i2 +1, j2] == Model.On)
                return false;
            
            #endregion

            #region Вторая часть метода, отвечает за очистку вверхних ячеек при перемещении объекта вниз

            mainScreen[i, j].Image = Model.IsNull.Image;
            onOff[i, j] = Model.Off;

            #endregion

            #region Третья часть метода: отвечает за пермещение элементов массива на уровень ниже(шаг один квадрат)

            ++i;
            i2 = i + 2;

            for (int k = i; k <= i2; k++)
            {
                mainScreen[k, j].Image = Model.IsNotNull.Image;
                onOff[k, j] = Model.On;
            }

            mainScreen[i2, j2].Image = Model.IsNotNull.Image;
            onOff[i2, j2] = Model.On;
            #endregion

            return true;
        }

        #endregion

        internal override void LeftMove(ref int i, ref int j)
        {
            base.LeftMove(ref i, ref j);
        }

        internal override void RightMove(ref int i, ref int j)
        {
            base.RightMove(ref i, ref j);
        }

        internal override void TurnMove(ref int i, ref int j)
        {
            base.TurnMove(ref i, ref j);
        }
    }
}
