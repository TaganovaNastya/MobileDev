using System.Drawing.Drawing2D;
namespace wfaControlRegion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GraphicsPath gp = new();
            gp.AddEllipse(0, 0,button1.Width,button1.Height);

            button1.Region = new Region(gp);
            gp.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(gp);
        }
    }
}