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
    partial class Screen : UserControl
    {
        Model model;

        public Screen(Model model)
        {
            this.model = model;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }

        private void Draw(PaintEventArgs e)
        {
            for (int i = 0; i < Model.vertLength; i++)
                for (int j = 0; j < Model.gorizontLength; j++)
                    e.Graphics.DrawImage(model.MainScreen[i, j].Image, PositionOfBlocks.Position[i,j]);
        }
    }
}
