using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaActivZona5
{
    public partial class AddZoneForm : Form
    {
        public string ZoneName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public AddZoneForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            ZoneName = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        public int RectangleX
        {
            get { return int.Parse(numericUpDownX.Text); }
            set { numericUpDownX.Text = value.ToString(); }
        }

        public int RectangleY
        {
            get { return int.Parse(numericUpDownY.Text); }
            set { numericUpDownY.Text = value.ToString(); }
        }

        public int RectangleWidth
        {
            get { return int.Parse(numericUpDownWidth.Text); }
            set { numericUpDownWidth.Text = value.ToString(); }
        }

        public int RectangleHeight
        {
            get { return int.Parse(numericUpDownHeight.Text); }
            set { numericUpDownHeight.Text = value.ToString(); }
        }
    }
}
