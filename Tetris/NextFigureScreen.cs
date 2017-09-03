using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    partial class NextFigureScreen : UserControl
    {
        private Model model;

        public NextFigureScreen(Model model)
        {
            this.model = model;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i<4; i++)
                for (int k = 0; k <2; k++)
                {
                    e.Graphics.DrawImage(model.NextScreen[i,k].Image, PositionOfBlocks.Position[i, k]);
                }
        }

    }
}
