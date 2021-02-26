using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureContainer
{
    public partial class OverwriteForm : Form
    {
        
        public OverwriteForm(string fname)
        {
            InitializeComponent();
            label2.Text = fname;
        }

        private void addcopybutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void replacebutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Dispose();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
