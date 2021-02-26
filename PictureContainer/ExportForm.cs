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
    public partial class ExportForm : Form
    {
        public string str = "dupka";
        public event ExportHandler Export;
        public delegate void ExportHandler(ExportForm ef,EventArgs e);


        public ExportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export(this,null);
            
            this.Dispose();
        }
    }
}
