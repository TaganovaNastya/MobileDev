namespace wfaControlPazzle
{
    public partial class Form1 : Form
    {
        private const int step = 10;
        private Random rnd = new();
        private PictureBox[,] px;
        private int cellWidth;
        private int cellHeight;
        private Point startMouseDown;

        public int Rows { get; private set; } = 3;
        public int Cols { get; private set; } = 6;
        public Form1()
        {
            InitializeComponent();
            CreateCells();
            RelizeCells();
            StartLocationCells();

            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    StartLocationCells();
                    break;
                case Keys.F2:
                    RelizeCells();
                    break;
                case Keys.F3:
                    RandomLocationCells();
                    break;
                case Keys.F4:
                    Random2LocationCells();
                    break;

                        
            }
        }

        private void Random2LocationCells()
        {
            StartLocationCells();
            for(int i = 0; i < 10; i++) { 
                var r1 = rnd.Next(Rows);
                var c1 = rnd.Next(Cols);
                var r2 = rnd.Next(Rows);
                var c2 = rnd.Next(Cols);

                // (1)
                //var temp = px[r1, c1].Location;
                //px[r1, c1].Location = px[r2, c2].Location;
                //px[r2, c2].Location = temp;

                //(2)
                (px[r1, c1].Location, px[r2, c2].Location) = (px[r2, c2].Location, px[r1, c1].Location);
            }
        }

        private void RandomLocationCells()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    px[r, c].Location = new Point(
                        rnd.Next(this.ClientSize.Width - px[r,c].Width),
                        rnd.Next(this.ClientSize.Height - px[r,c].Height)
                        ); 
                    
                }
        }

        private void StartLocationCells()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    px[r, c].Location = new Point(c * cellWidth, r * cellHeight);
                }
        }

        private void RelizeCells()
        {
            cellWidth = this.ClientSize.Width / Cols;
            cellHeight = this.ClientSize.Height / Rows;
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    px[r, c].Width = cellWidth;
                    px[r, c].Height = cellHeight;
                    //px[r, c].Location = new Point(c * cellWidth, r * cellHeight);
                    px[r, c].Image = new Bitmap(cellWidth, cellHeight);
                    var g = Graphics.FromImage(px[r, c].Image);
                    g.DrawImage(Properties.Resources.shema, new Rectangle(0, 0, cellWidth, cellHeight), new Rectangle(c * cellWidth, r * cellHeight, cellWidth, cellHeight), GraphicsUnit.Pixel);
                    g.DrawString($"[{r},{c}]", new Font("", 20), new SolidBrush(Color.Black), new Rectangle(0, 0, cellWidth, cellHeight), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
                    
                    g.Dispose();
                        
                }
        }

        private void CreateCells() { 
            px = new PictureBox[Rows, Cols];

            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    px[r, c] = new PictureBox();
                    px[r, c].BorderStyle = BorderStyle.FixedSingle;
                    px[r, c].Tag = (r, c);
                    px[r, c].MouseDown += PictureBoxAll_MouseDown; 
                    px[r, c].MouseMove += PictureBoxAll_MouseMove;
                    px[r, c].MouseUp += PictureBoxAll_MouseUp;



                    this.Controls.Add(px[r, c]);
                }
       }

        private void PictureBoxAll_MouseUp(object? sender, MouseEventArgs e)
        {
            if (sender is Control v)
            {
                v.Cursor = Cursors.Default;
                
                if (e.Button == MouseButtons.Left)
                {
                    var p = v.Location;
                    for (int r = 0; r < Rows; r++)
                        for (int c = 0; c < Cols; c++)
                        {
                            if (p.X > c * cellWidth - step && p.X < c * cellWidth + step)
                                p.X = c * cellWidth;

                            if (p.Y > r * cellHeight - step && p.Y < r * cellHeight + step)
                                p.Y = r * cellHeight;
                        }
                    v.Location = p;

                    CheckCell(v);
                }

                
            }
        }

        private void CheckCell(Control v)
        {
            (int r, int c) = ((int, int))v.Tag;
            //MessageBox.Show($"{r}, {c}");
            if (v.Location == new Point(c * cellWidth, r * cellHeight))
                MessageBox.Show("Верно");
        }

        private void PictureBoxAll_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is PictureBox v)
            {
                startMouseDown = e.Location;
                v.BringToFront();
                v.Cursor = Cursors.SizeAll;

                if (e.Button == MouseButtons.Right)
                {
                    v.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    v.Invalidate();
                }
            }
        }

        private void PictureBoxAll_MouseMove(object? sender, MouseEventArgs e)
        {
            if (sender is Control v)
            {
                if (e.Button == MouseButtons.Left)
                {
                    v.Location = new Point(v.Location.X + e.X - startMouseDown.X, v.Location.Y+ e.Y - startMouseDown.Y);
                }
            }
        }

    }
}