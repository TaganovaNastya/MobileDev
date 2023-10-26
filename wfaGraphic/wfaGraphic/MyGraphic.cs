using Accessibility;

namespace wfaGraphic
{
    internal class MyGraphic
    {
        public int Width { get; }
        public int Height { get; }
        public int CountWave { get;  } = 5;
        public int DotDiametr { get; } = 4;

        private Bitmap b;
        private Graphics g;
        private int grShiftY;
        private double grHeight;
        private double grWhidthPI;

        public MyGraphic(int width, int height)
        {
            Width = width;
            Height = height;

            b = new Bitmap(width, height);
            g = Graphics.FromImage(b);

            grShiftY = b.Height / 2;
            grHeight = grShiftY * 0.9;
            grWhidthPI = Math.PI / b.Width;
        }

        internal void DrawAxes()
        {
            // ось x
            //g.DrawLine(new Pen(Color.Black), 0, grShiftY, b.Width, grShiftY);
            g.DrawLine(Pens.Black, 0, grShiftY, b.Width, grShiftY);
            for (int i = 0; i < CountWave; i++)
            {
                var _x = b.Width / CountWave * i;
                //g.DrawLine(Pens.DarkGray, _x, 0, _x, b.Height);
            }


            // ось y
            g.DrawLine(Pens.Black, 0, 0, 0, b.Height);
        }

        internal Bitmap? GetBitmap()
        {
            return b;
        }

        internal void DrawSin()
        {
            double _x;
            double _y;
            for (int i = 0; i < b.Width; i++)
            {
                _x = i;
                _y = grHeight * -Math.Sin(_x * CountWave * grWhidthPI) + grShiftY;
                g.FillEllipse(new SolidBrush(Color.Red),
                    (int)_x - DotDiametr / 2, (int)_y - DotDiametr / 2, DotDiametr, DotDiametr);
            }
        }

        internal void DrawCos()
        {
            double _x;
            double _y;
            for (int i = 0; i < b.Width; i++)
            {
                _x = i;
                _y = grHeight * -Math.Cos(_x * CountWave * grWhidthPI) + grShiftY;
                g.FillEllipse(new SolidBrush(Color.Gold),
                    (int)_x - DotDiametr / 2, (int)_y - DotDiametr / 2, DotDiametr, DotDiametr);
            }

        }

        internal void DrawTan()
        {
            double _x;
            double _y;
            for (int i = 0; i < b.Width; i++)
            {
                _x = i;
                _y = grHeight * -Math.Tan(_x * CountWave * grWhidthPI) + grShiftY;
                if (_y > 0 && _y < b.Height)
                g.FillEllipse(new SolidBrush(Color.HotPink),
                    (int)_x - DotDiametr / 2, (int)_y - DotDiametr / 2, DotDiametr, DotDiametr);
            }

        }
    }
}
    
