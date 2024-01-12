namespace wfaGraphicSinCos
{
    public partial class Form1 : Form
    {
        private const int DOT_WIDTH = 2;
        private const int DOT_HEIGHT = 2;

        private readonly Dictionary<int, double> _sinValues = new();
        private readonly Dictionary<int, double> _cosValues = new();
        private readonly Dictionary<int, double> _tanValues = new();
        private readonly Dictionary<int, double> _lnValues = new();
        private readonly Dictionary<int, double> _sqrtValues = new();
        private readonly Dictionary<int, double> _tanhValues = new();

       



        public Form1()
        {
            InitializeComponent();

            BackgroundImageLayout = ImageLayout.None;

            DrawAll();
            Resize += (s, e) => DrawAll();
            
            


        }

        private void DrawAll()
        {
            
            var b = new Bitmap(ClientSize.Width, ClientSize.Height);
            var g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var grCountWave = 5; 
            var grShiftY = b.Height / 2; 
            var grHeight = grShiftY * 0.9; 
            var grWidthPI = Math.PI / (b.Width - 1); 

            g.DrawLine(new Pen(Color.Black), 0, grShiftY, b.Width, grShiftY);

            // Рисуем стрелки на оси X
            int arrowSize = 5; // Размер стрелки
            int arrowOffset = 10; // Отступ стрелки от конца оси

            // Стрелка на конце оси
            g.DrawLine(new Pen(Color.Black), b.Width - arrowOffset, grShiftY - arrowSize, b.Width, grShiftY);
            g.DrawLine(new Pen(Color.Black), b.Width - arrowOffset, grShiftY + arrowSize, b.Width, grShiftY);

            // Стрелки между делениями
            for (int i = 1; i < grCountWave; i++)
            {
                var xPoint = b.Width / grCountWave * i;
                g.DrawLine(Pens.Black, xPoint, grShiftY - 15, xPoint, grShiftY + 15);
            }

            // Рисуем ось Y
            g.DrawLine(new Pen(Color.Black), 0, 0, 0, b.Height);

            // рисование графиков
            float x;
            float y;

            for (int i = 0; i < b.Width; i++)
            {
                // Рисуем график Sin
                x = i;
                var sin = Math.Sin(i * grCountWave * grWidthPI);
                y = (float)(grHeight * -sin + grShiftY);
                g.FillEllipse(new SolidBrush(Color.Red), x - DOT_WIDTH / 2, y - DOT_HEIGHT / 2, DOT_WIDTH, DOT_HEIGHT);

                _sinValues[i] = sin;

                // Рисуем график Cos
                x = i;
                var cos = Math.Cos(i * grCountWave * grWidthPI);
                y = (float)(grHeight * -cos + grShiftY);
                g.FillEllipse(new SolidBrush(Color.Green), x - DOT_WIDTH / 2, y - DOT_HEIGHT / 2, DOT_WIDTH, DOT_HEIGHT);

                _cosValues[i] = cos;

                // Рисуем график Tan
                x = i;
                var tan = Math.Tan(i * grCountWave * grWidthPI);
                y = (float)(grHeight * -tan + grShiftY);
                if (y > 0 && y < b.Height)
                    g.FillEllipse(new SolidBrush(Color.Blue), x - DOT_WIDTH / 2, y - DOT_HEIGHT / 2, DOT_WIDTH, DOT_HEIGHT);

                _tanValues[i] = tan;

                // Рисуем график ln
                x = i;
                var ln = Math.Log(i * grCountWave * grWidthPI + 1); // Добавляем 1, чтобы избежать логарифма от нуля
                y = (float)(grHeight * -ln + grShiftY);
                g.FillEllipse(new SolidBrush(Color.Purple), x - DOT_WIDTH / 2, y - DOT_HEIGHT / 2, DOT_WIDTH, DOT_HEIGHT);

                _lnValues[i] = ln;

                x = i;
                var sqrt = Math.Sqrt(i * grCountWave * grWidthPI);
                y = (float)(grHeight * -sqrt + grShiftY);
                g.FillEllipse(new SolidBrush(Color.Orange), x - DOT_WIDTH / 2, y - DOT_HEIGHT / 2, DOT_WIDTH, DOT_HEIGHT);

                _sqrtValues[i] = sqrt;

                x = i;
                var tanh = Math.Tanh((i - b.Width / 2.0) * grCountWave * grWidthPI);
                y = (float)(grHeight * -tanh + grShiftY);
                g.FillEllipse(new SolidBrush(Color.Magenta), x - DOT_WIDTH / 2, y - DOT_HEIGHT / 2, DOT_WIDTH, DOT_HEIGHT);

                _tanhValues[i] = tanh;
            }



            BackgroundImage = (Bitmap)b.Clone();
        }

        private void pbCharts_MouseMove(object sender, MouseEventArgs e)
        {
            var b = new Bitmap(ClientSize.Width, ClientSize.Height);
            var g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawLine(Pens.Gray, new Point(0, e.Y), e.Location);
            g.DrawLine(Pens.Gray, new Point(e.X, 0), e.Location);

            var sin = _sinValues[e.Location.X];
            var cos = _cosValues[e.Location.X];
            var tan = _tanValues[e.Location.X];

           

            var ln = _lnValues[e.Location.X];
            var sqrt = _sqrtValues[e.Location.X];
            var tanh = _tanhValues[e.Location.X];
            g.DrawString($"sin = {sin:F3}\ncos = {cos:F3}\ntan = {tan:F3}\nln = {ln:F3}\nsqrt = {sqrt:F3}\ntanh = {tanh:F3}\n", Font, Brushes.Black, e.Location.X + 20, e.Location.Y);

            pbCharts.Image = (Bitmap)b.Clone();

            pbCharts.Invalidate();
        }
    }
}