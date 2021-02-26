using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PictureContainer
{


    public partial class UserControl1 : UserControl
    {
        /// <summary>
        /// Color of thumbnail background should be set to the same color as listView background
        /// </summary>
        private Brush _thumbBackground = Brushes.White;
        /// <summary>
        /// Export form
        /// </summary>
        private ExportForm _exp;
        /// <summary>
        /// List of images displayed in the listView but without direct relation
        /// </summary>
        private List<Image> _imagesList = new List<Image>();
        public Image imageToEdit = null;
        public event ImageEditHandler ImageEdit;
        public delegate void ImageEditHandler(UserControl1 uc, EventArgs e);
            
        /// <summary>
        /// Control initialization stuff
        /// </summary>
        public UserControl1()
        {
            InitializeComponent();
            listView1.LargeImageList = thumbnailList;
            
        }

        //import image button
        //- add filters, name etc ...
        /// <summary>
        /// Hamdler to "Import" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {             
                    AddImage(Image.FromFile(openFileDialog1.FileNames[i]), openFileDialog1.SafeFileNames[i],true);                    
                }
            }
        }

        public void AddImage(Image img, string name, bool overwrite)
        {
            int counter = 0;
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Text == name)
                {
                    //item with this name already exists
                    counter++;
                    OverwriteForm of = new OverwriteForm(i.Text);
                    DialogResult dr = of.ShowDialog();
                    
                    if (dr == DialogResult.OK)
                    {
                        //add copy
                        AddImage(img,name.Remove(name.IndexOf(GetImageExtension(img))) +"_"+ DateTime.Now.ToString() + GetImageExtension(img));
                    }
                    else if (dr == DialogResult.Yes)
                    {
                        //replace remove and add
                        RemoveImage(i);
                        AddImage(img, name);
                    }
                    break;
                }
            }

            if (counter == 0)
                AddImage(img, name);

        }


        // - prevent from adding picture with the same name
        //   ask to repleace(add,repleace,cancel)
        /// <summary>
        /// Adds image to listView, imageList and creates thumbnail image in thumbnailList
        /// </summary>
        /// <param name="img">Image file to add</param>
        /// <param name="name">String name of an image</param>
        /// <param name="overwrite">If image with the same name is already on the list then is overwrited if true </param>
        public void AddImage(Image img,string name)
        {
            _imagesList.Add(img);
            Image _thumb = new Bitmap(100,100);
            Graphics g = Graphics.FromImage(_thumb);
            g.FillRegion(_thumbBackground, new Region(new Rectangle(0, 0, 100, 100)));

            double _ratio = (double)img.Width / (double)img.Height;
            int _width = 0;
            int _height = 0;

            if (img.Width <= 100 && img.Height <= 100)
            {
                _width = img.Width;
                _height = img.Height;
            }
            else if (_ratio > 1)
            {
                _width = 100;
                _height = (int)(((double)img.Height / (double)img.Width) * 100);
            }
            else if (_ratio < 1)
            {
                _width = (int)(((double)img.Width / (double)img.Height) * 100);
                _height = 100;
            }
            else
            {
                _width = 100;
                _height = 100;
            }

            g.DrawImageUnscaled(img.GetThumbnailImage(_width,_height,null,new IntPtr()),50-_width/2,100 - _height);
            thumbnailList.Images.Add(_thumb);
            listView1.Items.Add(name, listView1.Items.Count);
            
        }

        /// <summary>
        /// Removes image specified by name ex. "huston.jpg"
        /// </summary>
        /// <param name="name"></param>
        public void RemoveImage(string name)
        {
            ListViewItem item = null;
            foreach (ListViewItem i in listView1.Items)
            {
                if(i.Text == name)
                {
                    item = i;
                    break;
                }
            }
            if(item != null)
            item.Remove();

        }

        /// <summary>
        /// Gets image size in bytes, KB and MB
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public string GetImageSize(Image img)
        {
            ImageConverter _converter = new ImageConverter();
            byte[] _ba = (byte[])_converter.ConvertTo(img, typeof(byte[]));
            double _bytes = _ba.Length;
            string _size = "Unknown";

            if (_bytes < 1024)
                _size = String.Format("{0:0.##}", _bytes) + " bytes";      
            else if (_bytes < 1024000)
                _size = String.Format("{0:0.##}", _bytes / 1024) + " KB";
            else
                _size = String.Format("{0:0.##}", _bytes / 1048567) + " MB"; 
           
            return _size;
        }

        /// <summary>
        /// Gets image format png, jpg, gif, ...
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public string GetImageFormat(Image img)
        {
            string _imageFormat = "Unknown";

            if (img.RawFormat.Equals(ImageFormat.Jpeg))
                _imageFormat = "JPEG image";
            else if (img.RawFormat.Equals(ImageFormat.Png))
                _imageFormat = "PNG image";
            else if (img.RawFormat.Equals(ImageFormat.Tiff))
                _imageFormat = "TIFF image";
            else if (img.RawFormat.Equals(ImageFormat.Gif))
                _imageFormat = "GIF image";
            else if (img.RawFormat.Equals(ImageFormat.Bmp))
                _imageFormat = "Bitmap image";

            return _imageFormat;
        }

        public string GetImageExtension(Image img)
        {
            string _imageFormat = "Unknown";

            if (img.RawFormat.Equals(ImageFormat.Jpeg))
                _imageFormat = ".jpg";
            else if (img.RawFormat.Equals(ImageFormat.Png))
                _imageFormat = ".png";
            else if (img.RawFormat.Equals(ImageFormat.Tiff))
                _imageFormat = ".tif";
            else if (img.RawFormat.Equals(ImageFormat.Gif))
                _imageFormat = ".gif";
            else if (img.RawFormat.Equals(ImageFormat.Bmp))
                _imageFormat = ".bmp";

            return _imageFormat;
        }

        //export images button
        //- display new form with export settings
        /// <summary>
        /// Handler to the "Export" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            _exp = new ExportForm();
            //_exp.FormClosing += new FormClosingEventHandler(ExpClosing);
            _exp.Export += new ExportForm.ExportHandler(ExpClosing);

            _exp.ShowDialog();
           
        }

       
        /// <summary>
        /// Handler to the confirmation button at Export Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpClosing(ExportForm sender, EventArgs e)
        {

            
            MessageBox.Show(_exp.str + sender.str);

        }

        /// <summary>
        /// Handler to double click on listview item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //MessageBox.Show(listView1.SelectedItems.Count.ToString() + " " + _imagesList.Count.ToString());
            if (listView1.SelectedItems.Count == 1)
            {
                imageToEdit = _imagesList.ElementAt<Image>(listView1.SelectedItems[0].Index);
                ImageEdit(this, null);
            }
        } 

        /// <summary>
        /// Handler to selected item event. Used to display at hoh atributes of image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                nameLabel.Text = listView1.SelectedItems[0].Text;
                imageflabel.Text = "Image format: " + GetImageFormat( _imagesList.ElementAt<Image>(listView1.SelectedItems[0].Index));
                dimlabel.Text = "Dimensions: " + _imagesList.ElementAt<Image>(listView1.SelectedItems[0].Index).Width.ToString() + " x " + _imagesList.ElementAt<Image>(listView1.SelectedItems[0].Index).Height.ToString();
                sizelabel.Text = "Size: " + GetImageSize(_imagesList.ElementAt<Image>(listView1.SelectedItems[0].Index));


            }
            else if (listView1.SelectedItems.Count > 1)
            {
                nameLabel.Text = listView1.SelectedItems.Count.ToString() + " items selected";
                imageflabel.Text = "Image format: ";
                dimlabel.Text = "Dimensions: ";
                sizelabel.Text = "Size: ";
            }
            else if (listView1.SelectedItems.Count == 0)
            {
                nameLabel.Text = "No items selected";
                imageflabel.Text = "Image format: ";
                dimlabel.Text = "Dimensions: ";
                sizelabel.Text = "Size: ";
            }
            
        }

        //not working
        private void UserControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
           // MessageBox.Show("deletepressed");
        }
        //not working
        private void UserControl1_KeyDown(object sender, KeyEventArgs e)
        {
            ///if (e.KeyCode == Keys.Delete)
             //   MessageBox.Show("deletepressed");

            
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            //delete operation
            if (listView1.SelectedItems.Count != 0 && e.KeyCode == Keys.Delete)
            {
                List<ListViewItem> _lvitm = new List<ListViewItem>();
                foreach(ListViewItem i in listView1.SelectedItems)
                {
                    _lvitm.Add(i);
                }

                listView1.SelectedItems.Clear();

                foreach (ListViewItem i in _lvitm)
                {
                    RemoveImage(i);
                }
            }
            else if (e.Control == true && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem i in listView1.Items)
                    i.Selected = true;
            }

            
        }

        public void RemoveImage(ListViewItem i)
        {
            _imagesList.RemoveAt(i.Index);
            thumbnailList.Images.RemoveAt(i.Index);
            listView1.Items.Remove(i);
            int _couner = 0;
            foreach (ListViewItem lvi in listView1.Items)
            {
                lvi.ImageIndex = _couner;
                _couner++;
            }
        }

       

    }
}
