namespace wfaFileExporer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            buBack = new ToolStripButton();
            buForward = new ToolStripButton();
            buUp = new ToolStripButton();
            edDir = new ToolStripTextBox();
            buDirSelect = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            statusStrip1 = new StatusStrip();
            panel1 = new Panel();
            listView1 = new ListView();
            imageList1 = new ImageList(components);
            splitter1 = new Splitter();
            treeView2 = new TreeView();
            imageList2 = new ImageList(components);
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { buBack, buForward, buUp, edDir, buDirSelect, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // buBack
            // 
            buBack.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buBack.ImageTransparentColor = Color.Magenta;
            buBack.Name = "buBack";
            buBack.Size = new Size(23, 22);
            buBack.Text = "←";
            // 
            // buForward
            // 
            buForward.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buForward.ImageTransparentColor = Color.Magenta;
            buForward.Name = "buForward";
            buForward.Size = new Size(23, 22);
            buForward.Text = "→";
            // 
            // buUp
            // 
            buUp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buUp.ImageTransparentColor = Color.Magenta;
            buUp.Name = "buUp";
            buUp.Size = new Size(23, 22);
            buUp.Text = "↑";
            // 
            // edDir
            // 
            edDir.Name = "edDir";
            edDir.Size = new Size(500, 25);
            // 
            // buDirSelect
            // 
            buDirSelect.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buDirSelect.ImageTransparentColor = Color.Magenta;
            buDirSelect.Name = "buDirSelect";
            buDirSelect.Size = new Size(23, 22);
            buDirSelect.Text = "...";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(40, 22);
            toolStripDropDownButton1.Text = "Вид";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(splitter1);
            panel1.Controls.Add(treeView2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 403);
            panel1.TabIndex = 3;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.LargeImageList = imageList1;
            listView1.Location = new Point(158, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(642, 403);
            listView1.SmallImageList = imageList2;
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "file.png");
            imageList1.Images.SetKeyName(1, "papka.png");
            // 
            // splitter1
            // 
            splitter1.Location = new Point(155, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 403);
            splitter1.TabIndex = 3;
            splitter1.TabStop = false;
            // 
            // treeView2
            // 
            treeView2.Dock = DockStyle.Left;
            treeView2.Location = new Point(0, 0);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(155, 403);
            treeView2.TabIndex = 2;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "file.png");
            imageList2.Images.SetKeyName(1, "papka.png");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton buBack;
        private ToolStripButton buForward;
        private ToolStripButton buUp;
        private ToolStripTextBox edDir;
        private ToolStripButton buDirSelect;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private StatusStrip statusStrip1;
        private Panel panel1;
        private TreeView treeView2;
        private Splitter splitter1;
        private ListView listView1;
        private ImageList imageList1;
        private ImageList imageList2;
    }
}