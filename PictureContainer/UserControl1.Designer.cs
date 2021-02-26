namespace PictureContainer
{
    partial class UserControl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.imageflabel = new System.Windows.Forms.Label();
            this.dimlabel = new System.Windows.Forms.Label();
            this.sizelabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.thumbnailList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(10, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(307, 323);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(21, 340);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name: ";
            // 
            // imageflabel
            // 
            this.imageflabel.AutoSize = true;
            this.imageflabel.Location = new System.Drawing.Point(21, 364);
            this.imageflabel.Name = "imageflabel";
            this.imageflabel.Size = new System.Drawing.Size(74, 13);
            this.imageflabel.TabIndex = 5;
            this.imageflabel.Text = "Image format: ";
            // 
            // dimlabel
            // 
            this.dimlabel.AutoSize = true;
            this.dimlabel.Location = new System.Drawing.Point(21, 389);
            this.dimlabel.Name = "dimlabel";
            this.dimlabel.Size = new System.Drawing.Size(67, 13);
            this.dimlabel.TabIndex = 6;
            this.dimlabel.Text = "Dimensions: ";
            // 
            // sizelabel
            // 
            this.sizelabel.AutoSize = true;
            this.sizelabel.Location = new System.Drawing.Point(21, 415);
            this.sizelabel.Name = "sizelabel";
            this.sizelabel.Size = new System.Drawing.Size(33, 13);
            this.sizelabel.TabIndex = 7;
            this.sizelabel.Text = "Size: ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // thumbnailList
            // 
            this.thumbnailList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.thumbnailList.ImageSize = new System.Drawing.Size(100, 100);
            this.thumbnailList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sizelabel);
            this.Controls.Add(this.dimlabel);
            this.Controls.Add(this.imageflabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(327, 481);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserControl1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserControl1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label imageflabel;
        private System.Windows.Forms.Label dimlabel;
        private System.Windows.Forms.Label sizelabel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList thumbnailList;
    }
}
