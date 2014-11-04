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

        Random rand = new Random();

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
                theBitmapImage = toGrayScale(theBitmapImage);
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
            
            for(int y=0; y<height; y++)
                for(int x=0; x<sectorWidth; x++){
                    int r = normalRandom((int)numRMu1.Value,(int)numRSigma1.Value);
                    int g = normalRandom((int)numGMu1.Value,(int)numGSigma1.Value);
                    int b = normalRandom((int)numBMu1.Value,(int)numBSigma1.Value);
                    Color color = Color.FromArgb(r,g,b); //Color of sector #1
                    bitmap.SetPixel(x, y, color);
                }
            for(int y=0; y<height; y++)
                for(int x=0; x<sectorWidth; x++){
                    int r = normalRandom((int)numRMu2.Value,(int)numRSigma2.Value);
                    int g = normalRandom((int)numGMu2.Value,(int)numGSigma2.Value);
                    int b = normalRandom((int)numBMu2.Value,(int)numBSigma2.Value);
                    Color color = Color.FromArgb(r,g,b); //...etc.
                    bitmap.SetPixel(x+sectorWidth*1, y, color);
                }
            for(int y=0; y<height; y++)
                for(int x=0; x<sectorWidth; x++){
                    int r = normalRandom((int)numRMu3.Value,(int)numRSigma3.Value);
                    int g = normalRandom((int)numGMu3.Value,(int)numGSigma3.Value);
                    int b = normalRandom((int)numBMu3.Value,(int)numBSigma3.Value);
                    Color color = Color.FromArgb(r,g,b);
                    bitmap.SetPixel(x+sectorWidth*2, y, color);
                }
            for(int y=0; y<height; y++)
                for(int x=0; x<sectorWidth; x++){
                    int r = normalRandom((int)numRMu4.Value,(int)numRSigma4.Value);
                    int g = normalRandom((int)numGMu4.Value,(int)numGSigma4.Value);
                    int b = normalRandom((int)numBMu4.Value,(int)numBSigma4.Value);
                    Color color = Color.FromArgb(r,g,b);
                    bitmap.SetPixel(x+sectorWidth*3, y, color);
                }
            return bitmap;
        }

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            leftPictureBox.Image = theBitmapImage = generateImage(350,350);
        }

        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            Class class1 = new Class((double)numTask2RMu1.Value, (double)numTask2RSigma1.Value, Color.Red);
            Class class2 = new Class((double)numTask2RMu2.Value, (double)numTask2RSigma2.Value, Color.Green);
            Class class3 = new Class((double)numTask2RMu3.Value, (double)numTask2RSigma3.Value, Color.Blue);
            Class class4 = new Class((double)numTask2RMu4.Value, (double)numTask2RSigma4.Value, Color.Cyan);
            rightPictureBox.Image = new Segment(new Class[]{class1,class2,class3,class4},theBitmapImage).getResult();
        }

        private int normalRandom(int mu, int sigma)
        {
            //int randNormal = rand.Next(Math.Min(mu,sigma), Math.Max(mu,sigma));

            double u1 = rand.NextDouble(),
                   u2 = rand.NextDouble(); //uniform (0,1)
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal (0,1)
            double randNormal = mu + sigma * randStdNormal; //random normal (mean,stdDev^2)
            randNormal = randNormal>255 ? 255 : randNormal;
            randNormal = randNormal<0   ? 0   : randNormal;
            
            //double pOfX = (1 / (Math.Sqrt(2 * Math.PI) * sigma)) * Math.Exp(-0.5 * Math.Pow((u1 - Math.PI) / sigma, 2));

            return (int)randNormal;
        }

        private void leftPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            NumericUpDown input = null;
                 if(numTask2RMu1.Focused) input=numTask2RMu1;
            else if(numTask2RMu2.Focused) input=numTask2RMu2;
            else if(numTask2RMu3.Focused) input=numTask2RMu3;
            else if(numTask2RMu4.Focused) input=numTask2RMu4;

            if(input!=null) input.Value=theBitmapImage.GetPixel(e.X,e.Y).R;

            /***TESTING***/
            //if(leftPictureBox.Image!=null && e.X<theBitmapImage.Width && e.Y<theBitmapImage.Height)
            //    theBitmapImage.SetPixel(e.X,e.Y,Color.Red);
            //leftPictureBox.Refresh();
        }

        private Bitmap toGrayScale(Bitmap bitmap){
            Bitmap newBitmap = new Bitmap(bitmap.Width,bitmap.Height);
            for(int j=0; j<newBitmap.Height; j++)
                for(int i=0; i<newBitmap.Width; i++){
                    Color oldColor = bitmap.GetPixel(i, j);
                    int greyValue = (int)(0.2126*oldColor.R + 0.7152*oldColor.G + 0.0722*oldColor.B);
                    Color newColor = Color.FromArgb(greyValue,greyValue,greyValue);
                    newBitmap.SetPixel(i,j,newColor);
                }
            return newBitmap;
        }
    }
}