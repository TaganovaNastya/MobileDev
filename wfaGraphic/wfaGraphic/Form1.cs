namespace wfaGraphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.BackgroundImageLayout = ImageLayout.None;
            this.Text += ": (Sin - красный, Cos - жёлтый, Tan - розовый)";
            DrawAll();
            this.ResizeEnd += (s, e) => DrawAll();

        }

        private void DrawAll()
        {
            MyGraphic myGraphic = new(
                        this.ClientSize.Width,
                        this.ClientSize.Height);

            myGraphic.DrawAxes();
            myGraphic.DrawSin();
            myGraphic.DrawCos();
            myGraphic.DrawTan();

            this.BackgroundImage =
            (Bitmap)myGraphic.GetBitmap().Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}