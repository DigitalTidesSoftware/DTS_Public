using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ImageProcessing.Utilities;
using ImageProcessing.Core;

//for using MySQL database
using System.Data.SqlClient;

namespace ImageProcessing1
{
    public partial class MainForm : Form
    {


        #region Constructors
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion


        #region Properties
        private string _imageFileLocation = "";
        #endregion


        #region Procedures

        private void OpenFile()
        {
            OpenFileDialog browseFile = new OpenFileDialog();

            if (browseFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                _imageFileLocation = browseFile.FileName;
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion


        #region Event Handlers
        //New Image Clicked
        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();

            //TODO: If bitmap, use bitmap holder, if jpg use jpeg holder etc

            ImageProcessing.Core.File.BitmapHolder bitmapHolder =
                new ImageProcessing.Core.File.BitmapHolder(ImageProcessing.Utilities.Image.GetImageRaw(_imageFileLocation));

            MemoryStream ms = new MemoryStream(bitmapHolder.RawBitmap);
            //imageBytes = ms.ToArray();
            //Image bitmap = Image.FromStream(ms);
            //Bitmap img = (Bitmap)Image.FromStream(ms);

            try
            {
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                throw new BadImageFormatException();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //
        private void histogramEquilizationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Convert image to black and white
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
