namespace MDI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form ChildForm = new Form();

            ChildForm.Name = "Child" + (this.MdiChildren.Length + 1);
            ChildForm.Text = "Child" + (this.MdiChildren.Length + 1);
            ChildForm.MdiParent = this;

            TextBox txtBox = new TextBox();
            txtBox.Dock = DockStyle.Fill;
            txtBox.Multiline = true;

            ChildForm.Controls.Add(txtBox);
            ChildForm.Show();
        }


        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVertialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OF = new OpenFileDialog();

            OF.Filter = "Text files (*.txt)|*.txt|Image files (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif|All files (*.*)|*.*";

            if (OF.ShowDialog() == DialogResult.OK)
            {
                string sFN = OF.FileName;
                string sExt = System.IO.Path.GetExtension(sFN).ToUpper();

                if (sExt == ".BMP" || sExt == ".JPG" || sExt == ".GIF")
                {
                    FormImage imgForm = new FormImage();
                    imgForm.SetFileName(sFN);
                    imgForm.MdiParent = this;
                    imgForm.Show();
                }
                else if (sExt == ".TXT" || sExt == ".CS")
                {
                    FormText txtForm = new FormText();
                    txtForm.SetFileName(sFN);
                    txtForm.MdiParent = this;
                    txtForm.Show();
                }
                else
                {
                    MessageBox.Show("Уучлаарай. Файлыг нээж чадахгүй.");
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }
    }
}
