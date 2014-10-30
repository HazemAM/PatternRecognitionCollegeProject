using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PatternRecognition
{
    public partial class mainForm : Form
    {
        public mainForm(){
            InitializeComponent();
        }

        Bitmap theBitmapImage;
        Image  imageToSave=null;

        private void btnOpen_Click(object sender, EventArgs e){
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog()==DialogResult.OK){
                //Open the image:
                String imageFilePath = fileDialog.FileName.ToLower();
                if(imageFilePath.EndsWith(".jpg") || imageFilePath.EndsWith(".png") ||
                   imageFilePath.EndsWith(".gif") || imageFilePath.EndsWith(".bmp")){
                    theBitmapImage = new Bitmap(imageFilePath);
                }
                else{
                    MessageBox.Show("This type of files is not supported... yet.\n(Are you sure it's an image?)",
                        "Not Supported", MessageBoxButtons.OK);
                    return;
                }
                leftPictureBox.Image = theBitmapImage;
            }
        }

        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            PictureBox pictureBox = ((PictureBox)sender);
            if(pictureBox.Image != null){
                toolTip.Active = true;
                toolTip.SetToolTip(pictureBox, "Double click to save");
            }
            else
                toolTip.Active = false;
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e){
            //Save the image.
            if(((PictureBox)sender).Image!=null){
                saveDialog.FileName = "image.jpg";
                saveDialog.Filter   = "JPEG|*.jpg|All files|*.*";
                imageToSave = ((PictureBox)sender).Image;
                saveDialog.ShowDialog();
            }
        }

        private void saveDialog_FileOk(object sender, CancelEventArgs e){
            imageToSave.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            imageToSave = null;
        }

        private Bitmap generateImage(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            int sectorWidth = width/4;
            Color color1 = Color.FromArgb(10,150,255); //Color of sector #1,
            Color color2 = Color.FromArgb(255,150,10); //...etc.
            Color color3 = Color.FromArgb(10,255,150);
            Color color4 = Color.FromArgb(150,10,255);
            for(int y=0; y<height; y++) //Write the pixels
                for(int x=0; x<sectorWidth; x++){
                    bitmap.SetPixel(x, y, color1);
                    bitmap.SetPixel(x+sectorWidth*1, y, color2);
                    bitmap.SetPixel(x+sectorWidth*2, y, color3);
                    bitmap.SetPixel(x+sectorWidth*3, y, color4);
                }
            return bitmap;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            leftPictureBox.Image = generateImage(350,350);
        }
    }
}