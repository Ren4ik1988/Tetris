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
        public Model model;

        public Screen(Model model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.figure.img, new Point(model.figure.x, model.figure.y));
            Invalidate();
        }
    }
}
