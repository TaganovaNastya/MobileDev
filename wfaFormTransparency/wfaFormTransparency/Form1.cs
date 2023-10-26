namespace wfaFormTransparency
{
    public partial class Form1 : Form
    {
        private object startMouseDown;

        public Form1()
        {
            InitializeComponent();

            button1.Click += (s, e) => this.Close();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = this.BackColor;

            this.MouseDown += (s, e) => startMouseDown = e.Location;
            this.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Location = new Point(this.Location.X + e.X - startMouseDown.X, this.Location.Y + e.Y - startMouseDown.Y);
                }
            };
            
           }

        }
    }
}