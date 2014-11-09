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
                if(chkbxOpenGrayscale.Checked) theBitmapImage=toGrayScale(theBitmapImage);
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
            theBitmapImage = generateImage(350,350);
            if(chkbxGenGrayscale.Checked) theBitmapImage=toGrayScale(theBitmapImage);
            leftPictureBox.Image = theBitmapImage;
        }

        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            if(theBitmapImage==null){
                MessageBox.Show("You have no input image yet. Open or generate an image first.",
                        "Where?", MessageBoxButtons.OK);
                return;
            }

            //try{
                String[] temp;

                //GETTING INPUT AND CONVERTING TO NUMBERS:
                temp = txtClass1Pixel1.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c1p1 = Array.ConvertAll(temp, double.Parse); //class 1, pixel 1
                temp = txtClass1Pixel2.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c1p2 = Array.ConvertAll(temp, double.Parse);
                temp = txtClass1Pixel3.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c1p3 = Array.ConvertAll(temp, double.Parse);

                temp = txtClass2Pixel1.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c2p1 = Array.ConvertAll(temp, double.Parse); //class 2, pixel 1
                temp = txtClass2Pixel2.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c2p2 = Array.ConvertAll(temp, double.Parse);
                temp = txtClass2Pixel3.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c2p3 = Array.ConvertAll(temp, double.Parse);

                temp = txtClass3Pixel1.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c3p1 = Array.ConvertAll(temp, double.Parse); //class 3, pixel 1
                temp = txtClass3Pixel2.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c3p2 = Array.ConvertAll(temp, double.Parse);
                temp = txtClass3Pixel3.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c3p3 = Array.ConvertAll(temp, double.Parse);

                temp = txtClass4Pixel1.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c4p1 = Array.ConvertAll(temp, double.Parse); //class 4, pixel 1
                temp = txtClass4Pixel2.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c4p2 = Array.ConvertAll(temp, double.Parse);
                temp = txtClass4Pixel3.Text.Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                double[] c4p3 = Array.ConvertAll(temp, double.Parse);

                //COMPUTE MU AND SIGMA FOR EACH COLOR OF CLASS OF 4:
                double mu1r = (c1p1[0]+c1p2[0]+c1p3[0])/3; double sigma1r = Math.Pow( ((c1p1[0]-mu1r)+(c1p2[0]-mu1r)+(c1p3[0]-mu1r)) , 2) / 3;
                double mu1g = (c1p1[1]+c1p2[1]+c1p3[1])/3; double sigma1g = Math.Pow( ((c1p1[1]-mu1g)+(c1p2[1]-mu1g)+(c1p3[1]-mu1g)) , 2) / 3;
                double mu1b = (c1p1[2]+c1p2[2]+c1p3[2])/3; double sigma1b = Math.Pow( ((c1p1[2]-mu1b)+(c1p2[2]-mu1b)+(c1p3[2]-mu1b)) , 2) / 3;

                double mu2r = (c2p1[0]+c2p2[0]+c2p3[0])/3; double sigma2r = Math.Pow( ((c2p1[0]-mu2r)+(c2p2[0]-mu2r)+(c2p3[0]-mu2r)) , 2) / 3;
                double mu2g = (c2p1[1]+c2p2[1]+c2p3[1])/3; double sigma2g = Math.Pow( ((c2p1[1]-mu2g)+(c2p2[1]-mu2g)+(c2p3[1]-mu2g)) , 2) / 3;
                double mu2b = (c2p1[2]+c2p2[2]+c2p3[2])/3; double sigma2b = Math.Pow( ((c2p1[2]-mu2b)+(c2p2[2]-mu2b)+(c2p3[2]-mu2b)) , 2) / 3;

                double mu3r = (c3p1[0]+c3p2[0]+c3p3[0])/3; double sigma3r = Math.Pow( ((c3p1[0]-mu3r)+(c3p2[0]-mu3r)+(c3p3[0]-mu3r)) , 2) / 3;
                double mu3g = (c3p1[1]+c3p2[1]+c3p3[1])/3; double sigma3g = Math.Pow( ((c3p1[1]-mu3g)+(c3p2[1]-mu3g)+(c3p3[1]-mu3g)) , 2) / 3;
                double mu3b = (c3p1[2]+c3p2[2]+c3p3[2])/3; double sigma3b = Math.Pow( ((c3p1[2]-mu3b)+(c3p2[2]-mu3b)+(c3p3[2]-mu3b)) , 2) / 3;

                double mu4r = (c4p1[0]+c4p2[0]+c4p3[0])/3; double sigma4r = Math.Pow( ((c4p1[0]-mu4r)+(c4p2[0]-mu4r)+(c4p3[0]-mu4r)) , 2) / 3;
                double mu4g = (c4p1[1]+c4p2[1]+c4p3[1])/3; double sigma4g = Math.Pow( ((c4p1[1]-mu4g)+(c4p2[1]-mu4g)+(c4p3[1]-mu4g)) , 2) / 3;
                double mu4b = (c4p1[2]+c4p2[2]+c4p3[2])/3; double sigma4b = Math.Pow( ((c4p1[2]-mu4b)+(c4p2[2]-mu4b)+(c4p3[2]-mu4b)) , 2) / 3;

                //DEFINE THE 4 CLASSES:
                Class class1 = new Class(new double[]{mu1r,mu1g,mu1b}, new double[]{sigma1r,sigma1g,sigma1b}, Color.Red);
                Class class2 = new Class(new double[]{mu2r,mu2g,mu2b}, new double[]{sigma2r,sigma2g,sigma2b}, Color.Green);
                Class class3 = new Class(new double[]{mu3r,mu3g,mu3b}, new double[]{sigma3r,sigma3g,sigma3b}, Color.Blue);
                Class class4 = new Class(new double[]{mu4r,mu4g,mu4b}, new double[]{sigma4r,sigma4g,sigma4b}, Color.Cyan);

                //CLASSIFY THE IMAGE (PHEW!):
                rightPictureBox.Image = new Segment(new Class[]{class1,class2,class3,class4}, theBitmapImage).getResult();

            //} catch(Exception exp){
            //    MessageBox.Show("Something went wrong. Make sure you enter color values correctly.\n\n(Technically: "+exp.Message+")",
            //        "What?", MessageBoxButtons.OK);
            //}
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
            TextBox input = null;
                 if(txtClass1Pixel1.Focused) input=txtClass1Pixel1;
            else if(txtClass1Pixel2.Focused) input=txtClass1Pixel2;
            else if(txtClass1Pixel3.Focused) input=txtClass1Pixel3;

            else if(txtClass2Pixel1.Focused) input=txtClass2Pixel1;
            else if(txtClass2Pixel2.Focused) input=txtClass2Pixel2;
            else if(txtClass2Pixel3.Focused) input=txtClass2Pixel3;

            else if(txtClass3Pixel1.Focused) input=txtClass3Pixel1;
            else if(txtClass3Pixel2.Focused) input=txtClass3Pixel2;
            else if(txtClass3Pixel3.Focused) input=txtClass3Pixel3;

            else if(txtClass4Pixel1.Focused) input=txtClass4Pixel1;
            else if(txtClass4Pixel2.Focused) input=txtClass4Pixel2;
            else if(txtClass4Pixel3.Focused) input=txtClass4Pixel3;

            try{
                if(input!=null) input.Text = (theBitmapImage.GetPixel(e.X,e.Y).R.ToString()+" "+
                                              theBitmapImage.GetPixel(e.X,e.Y).G.ToString()+" "+
                                              theBitmapImage.GetPixel(e.X,e.Y).B.ToString());
            } catch(ArgumentOutOfRangeException){ /*Pixel out of image dimensions.*/ }

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