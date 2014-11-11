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
            temp = txtClass1.Text.Split(new String[]{","}, StringSplitOptions.RemoveEmptyEntries);
            double[][] class1pixels = new double[temp.Length][];
            for(int i=0; i<temp.Length; i++){
                String[] splitTemp = temp[i].Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                class1pixels[i] = Array.ConvertAll(splitTemp, double.Parse);
            }

            temp = txtClass2.Text.Split(new String[]{","}, StringSplitOptions.RemoveEmptyEntries);
            double[][] class2pixels = new double[temp.Length][];
            for(int i=0; i<temp.Length; i++){
                String[] splitTemp = temp[i].Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                class2pixels[i] = Array.ConvertAll(splitTemp, double.Parse);
            }

            temp = txtClass3.Text.Split(new String[]{","}, StringSplitOptions.RemoveEmptyEntries);
            double[][] class3pixels = new double[temp.Length][];
            for(int i=0; i<temp.Length; i++){
                String[] splitTemp = temp[i].Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                class3pixels[i] = Array.ConvertAll(splitTemp, double.Parse);
            }

            temp = txtClass4.Text.Split(new String[]{","}, StringSplitOptions.RemoveEmptyEntries);
            double[][] class4pixels = new double[temp.Length][];
            for(int i=0; i<temp.Length; i++){
                String[] splitTemp = temp[i].Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                class4pixels[i] = Array.ConvertAll(splitTemp, double.Parse);
            }

            //check number of pixels in every class:
            if(class1pixels.GetLength(0)!=class2pixels.GetLength(0) ||
               class1pixels.GetLength(0)!=class3pixels.GetLength(0) ||
               class1pixels.GetLength(0)!=class4pixels.GetLength(0) ||
               class2pixels.GetLength(0)!=class3pixels.GetLength(0) ||
               class2pixels.GetLength(0)!=class4pixels.GetLength(0) ||
               class3pixels.GetLength(0)!=class4pixels.GetLength(0) ){
                MessageBox.Show("Enter same number of samples (pixels) per class.",
                        "That's Not Fair", MessageBoxButtons.OK);
                return;
            }


            //COMPUTE MU FOR EACH COLOR OF CLASS OF 4:
            double[,] mean = new double[4,3];
            for(int i=0; i<class1pixels.GetLength(0); i++){
                double fraction = (1/(double)class1pixels.GetLength(0));
                mean[0,0] += fraction*class1pixels[i][0];
                mean[0,1] += fraction*class1pixels[i][1];
                mean[0,2] += fraction*class1pixels[i][2];

                mean[1,0] += fraction*class2pixels[i][0];
                mean[1,1] += fraction*class2pixels[i][1];
                mean[1,2] += fraction*class2pixels[i][2];

                mean[2,0] += fraction*class3pixels[i][0];
                mean[2,1] += fraction*class3pixels[i][1];
                mean[2,2] += fraction*class3pixels[i][2];

                mean[3,0] += fraction*class4pixels[i][0];
                mean[3,1] += fraction*class4pixels[i][1];
                mean[3,2] += fraction*class4pixels[i][2];
            }


            //COMPUTE SIGMA FOR EACH COLOR OF CLASS OF 4:
            double[,] sigma = new double[4,3];
            for(int i=0; i<class1pixels.GetLength(0); i++){
                double fraction = (1/(double)class1pixels.GetLength(0));
                sigma[0,0] += fraction*Math.Pow(class1pixels[i][0]-mean[0,0],2);
                sigma[0,1] += fraction*Math.Pow(class1pixels[i][1]-mean[0,1],2);
                sigma[0,2] += fraction*Math.Pow(class1pixels[i][2]-mean[0,2],2);

                sigma[1,0] += fraction*Math.Pow(class2pixels[i][0]-mean[1,0],2);
                sigma[1,1] += fraction*Math.Pow(class2pixels[i][1]-mean[1,1],2);
                sigma[1,2] += fraction*Math.Pow(class2pixels[i][2]-mean[1,2],2);

                sigma[2,0] += fraction*Math.Pow(class3pixels[i][0]-mean[2,0],2);
                sigma[2,1] += fraction*Math.Pow(class3pixels[i][1]-mean[2,1],2);
                sigma[2,2] += fraction*Math.Pow(class3pixels[i][2]-mean[2,2],2);

                sigma[3,0] += fraction*Math.Pow(class4pixels[i][0]-mean[3,0],2);
                sigma[3,1] += fraction*Math.Pow(class4pixels[i][1]-mean[3,1],2);
                sigma[3,2] += fraction*Math.Pow(class4pixels[i][2]-mean[3,2],2);
            }

            for(int i=0; i<class1pixels.GetLength(0); i++)
                for(int j=0; j<class1pixels.GetLength(0); j++)
                    if(sigma[i,j]==0){
                        MessageBox.Show("After calculations, one sigma value (at least) is equal to zero, which is not cool.\nChoose your pixels nicely.",
                            "Sigma Cannot be Zero", MessageBoxButtons.OK);
                        return;
                    }


            //GETTING LAMBDAS:
            double[][] lambda = new double[5][];
            if(txtLambda.Text.ToString()!="" && txtLambda.Text.ToString()!=null){
                temp = txtLambda.Text.Split(new String[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                for(int i=0; i<lambda.GetLength(0); i++){
                    String[] splitTemp = temp[i].Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                    lambda[i] = Array.ConvertAll(splitTemp, double.Parse);
                }
            }
            else //initialize by zeros if no input:
                for(int i=0; i<lambda.GetLength(0); i++)
                    lambda[i] = new double[]{0,0,0,0};


            //DEFINE THE 4 CLASSES:
            Class class1 = new Class(new double[]{mean[0,0],mean[0,1],mean[0,2]}, new double[]{sigma[0,0],sigma[0,1],sigma[0,2]}, Color.Red);
            Class class2 = new Class(new double[]{mean[1,0],mean[1,1],mean[1,2]}, new double[]{sigma[1,0],sigma[1,1],sigma[1,2]}, Color.Green);
            Class class3 = new Class(new double[]{mean[2,0],mean[2,1],mean[2,2]}, new double[]{sigma[2,0],sigma[2,1],sigma[2,2]}, Color.Blue);
            Class class4 = new Class(new double[]{mean[3,0],mean[3,1],mean[3,2]}, new double[]{sigma[3,0],sigma[3,1],sigma[3,2]}, Color.Cyan);

            //CLASSIFY THE IMAGE (PHEW!):
            Segment segment = new Segment(new Class[]{class1,class2,class3,class4}, theBitmapImage, lambda);
            rightPictureBox.Image = segment.getResult();
            new TableForm(segment.getTable(), segment.getAccuracy(), segment.getOverallAccuracy()).ShowDialog();

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
                 if(txtClass1.Focused) input=txtClass1;
            else if(txtClass2.Focused) input=txtClass2;
            else if(txtClass3.Focused) input=txtClass3;
            else if(txtClass4.Focused) input=txtClass4;

            try{
                if(input!=null){
                    String text = "";
                    if(input.Text!="") text=", ";
                    text += (theBitmapImage.GetPixel(e.X,e.Y).R.ToString()+" "+
                             theBitmapImage.GetPixel(e.X,e.Y).G.ToString()+" "+
                             theBitmapImage.GetPixel(e.X,e.Y).B.ToString());
                    input.Text += text;
                }
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