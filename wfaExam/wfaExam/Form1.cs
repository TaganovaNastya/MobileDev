namespace wfaExam
{
    public partial class Form1 : Form
    {
        private GameLogic game;


        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            pnlFigures.Paint += pnlFigures_Paint;
        }

        private void InitializeComboBox()
        {
            cmbGridSize.Items.Add("3x3");
            cmbGridSize.Items.Add("4x4");
            cmbGridSize.Items.Add("5x5");
            cmbGridSize.SelectedIndex = 0;
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            int gridSize = GetSelectedGridSize();
            StartGame(gridSize);
        }

        private int GetSelectedGridSize()
        {

            if (cmbGridSize.SelectedItem != null)
            {
                string selectedSize = cmbGridSize.SelectedItem.ToString();
                int size = int.Parse(selectedSize.Split('x')[0]);
                return size;
            }
            else
            {

                MessageBox.Show("Выберите размер сетки перед началом игры.");
                return 0;
            }
        }

        private void StartGame(int gridSize)
        {
            int uniqueFigureIndex = new Random().Next(0, gridSize * gridSize);

            game = new GameLogic(gridSize, uniqueFigureIndex);
            pnlFigures.Invalidate();
            UpdateUI();

            // Запуск таймера для отсчета времени
            timer1.Interval = 1000;
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (game != null)
            {
                game.TimeRemaining--;

                if (game.TimeRemaining <= 0)
                {
                    MessageBox.Show("Время вышло! Попробуйте еще раз.");
                    ResetGame();
                }

                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            lblAttempts.Text = $"Попытки: {game.Attempts}";
            lblTimeRemaining.Text = $"Времени осталось: {game.TimeRemaining} сек";

            pnlFigures.Invalidate();

            for (int i = 0; i < pnlFigures.Controls.Count; i++)
            {
                if (pnlFigures.Controls[i] is Panel panel)
                {
                    int selectedIndex = i; 
                    panel.Click += (sender, e) => Figure_Click(selectedIndex);
                }
            }
        }

        private void pnlFigures_Paint(object sender, PaintEventArgs e)
        {

            if (game != null)
            {
                int cellSize = 50;
                int gap = 5; 

                for (int i = 0; i < game.GridSize * game.GridSize; i++)
                {
                    int row = i / game.GridSize;
                    int col = i % game.GridSize;

                    int x = col * (cellSize + gap); 
                    int y = row * (cellSize + gap);

                    Rectangle rect = new Rectangle(x, y, cellSize, cellSize);

                    switch (game.Grid[i])
                    {
                        case GameLogic.FigureType.Circle:
                            e.Graphics.FillEllipse(Brushes.Blue, rect);
                            break;
                        case GameLogic.FigureType.Triangle:
                            Point[] points = { new Point(rect.Left + rect.Width / 2, rect.Top), new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Bottom) };
                            e.Graphics.FillPolygon(Brushes.Blue, points);
                            break;
                        case GameLogic.FigureType.Square:
                            e.Graphics.FillRectangle(Brushes.Blue, rect);
                            break;
                        case GameLogic.FigureType.Unique:
                            e.Graphics.FillRectangle(Brushes.Green, rect);
                            break;
                    }


                }
            }
        }



        private void Figure_Click(int selectedIndex)
        {
            bool isCorrect = game.CheckSelectedFigure(selectedIndex);

            if (isCorrect)
            {
                MessageBox.Show($"Правильно! Количество попыток: {game.Attempts}");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            game = null;
            lblAttempts.Text = "Попытки: 0";
            lblTimeRemaining.Text = "Времени осталось: 0 сек";
            pnlFigures.Invalidate();
        }

        

        private void pnlFigures_Click(object sender, EventArgs e)
        {
            Point clickLocation = pnlFigures.PointToClient(Cursor.Position);

            int cellSize = 50;
            int gap = 5; 

            
            int col = clickLocation.X / (cellSize + gap);
            int row = clickLocation.Y / (cellSize + gap);
            int selectedIndex = row * game.GridSize + col;

            bool isCorrect = game.CheckSelectedFigure(selectedIndex);

            if (isCorrect)
            {
                MessageBox.Show($"Правильно! Количество попыток: {game.Attempts}");
                ResetGame();
            }
        }
    }

    public class GameLogic
    {
        private int gridSize;
        private int uniqueFigureIndex;
        private int attempts;
        private int timeRemaining;
        private FigureType[] grid;

        public enum FigureType
        {
            Empty,
            Circle,
            Triangle,
            Square,
            Unique
        }

        public int Attempts { get { return attempts; } }
        public int TimeRemaining
        {
            get { return timeRemaining; }
            set { timeRemaining = value; }
        }
        public int GridSize { get { return gridSize; } }
        public int UniqueFigureIndex { get { return uniqueFigureIndex; } }
        public FigureType[] Grid { get { return grid.ToArray(); } }

        public GameLogic(int gridSize, int uniqueFigureIndex)
        {
            this.gridSize = gridSize;
            this.uniqueFigureIndex = uniqueFigureIndex;
            attempts = 0;
            timeRemaining = 60;
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grid = new FigureType[gridSize * gridSize];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = FigureType.Empty;
            }

            grid[uniqueFigureIndex] = FigureType.Unique;
            FillRandomFigures();
        }

        private void FillRandomFigures()
        {
            Random random = new Random();
            int remainingFigures = gridSize * gridSize - 1;

            while (remainingFigures > 0)
            {
                int index = random.Next(0, gridSize * gridSize);

                if (grid[index] == FigureType.Empty)
                {
                    grid[index] = (FigureType)random.Next(1, 4);
                    remainingFigures--;
                }
            }
        }

        public bool CheckSelectedFigure(int selectedIndex)
        {
            attempts++;
            return selectedIndex == uniqueFigureIndex;

        }
    }
}

