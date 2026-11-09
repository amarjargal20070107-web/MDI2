using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDI2
{
    public partial class FormImage : Form
    {
        private Bitmap m_bmp;
        public FormImage()
        {

            InitializeComponent();
        }
        public void SetFileName(string sImageName)
        {
            try
            {
                m_bmp = new Bitmap(sImageName);
                pictureBox1.Image = m_bmp;
                this.Text = "Зураг: " + sImageName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Алдаа: " + ex.Message);
            }

        }
    }
}
