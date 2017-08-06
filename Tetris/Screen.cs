using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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

        void Draw(PaintEventArgs e)
        {
            foreach( Figure f in model.Figure)
            e.Graphics.DrawImage(
                f.Image,
                f.Position
                );

            if (model.GameStatus != GameStatus.Playing)
               return;

            Thread.Sleep(100);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
