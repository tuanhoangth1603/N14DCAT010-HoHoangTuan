using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitmap;
using System.Windows.Forms;


namespace Bitmap
{
    public partial class BitMap : Form
    {
        public BitMap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
            openDialog.InitialDirectory = @"D:";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openDialog.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(textBox1.Text);
            for(int i = 0; i < img.Width; i++)
            {
                for(int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if( i <1 && j< textBox2.TextLength)
                    {
                        Console.WriteLine("R + [" + i + "][" + j + "] = " + pixel.R);
                        Console.WriteLine("B + [" + i + "][" + j + "] = " + pixel.B);
                        Console.WriteLine("G + [" + i + "][" + j + "] = " + pixel.G);
                        char letter = Convert.ToChar(textBox2.Text.Substring(j, 1));
                        int value = Convert.ToInt32(letter);
                        Console.WriteLine("letter: " + letter + " value: " + value);
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, value));
                    }
                    if( i == img.Width - 1 && j == img.Height - 1)
                    {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, textBox2.TextLength));
                    }

                }
                
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image Files (*.png, *.jpg) | *.png, *.jpg";
            saveFile.InitialDirectory = @"D:\";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFile.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
                img.Save(textBox1.Text);
            }
            textBox1.Clear();
            textBox2.Clear();
            
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(textBox1.Text);
            string mess = "";

            Color lastpixel = img.GetPixel(img.Width -1, img.Height -1);
            int messlenght = lastpixel.B;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    if (i < 1 && j < messlenght)
                    {
                        int value = pixel.B;
                        char c = Convert.ToChar(value);
                        string letter = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                        mess = mess + letter;
                    }
                }
            }
            textBox2.Text = mess;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
