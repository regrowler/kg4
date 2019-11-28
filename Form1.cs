using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG4
{
    public partial class Form1 : Form
    {
        public static Bitmap bmp { get; set; }

        public static Bitmap bmpAfterConvert { get; set; }

        public static Bitmap bmpAfterConvertContrast { get; set; }

        public static Bitmap bmpAfterConvertFilter { get; set; }

        private int sawpicks = 4;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmp = null;
            }

            openFileDialog1.Filter =
                "JPEG (*.jpg; *.jpeg)|*.jpg; *.jpeg|Точечные рисунки (*.bmp)|*.bmp|GIF (*.gif)|*.gif|PNG (*png)|*.png";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.OpenFile());
            }

            pictureBox1.Image = bmp;
        }

        private void grey_Click(object sender, EventArgs e)
        {
            try
            {
                if (bmp != null)
                {
                    bmpAfterConvert = (Bitmap) bmp.Clone();
                    Color color;
                    byte color_after_convert;
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        for (int j = 0; j < bmp.Height; j++)
                        {
                            color = bmp.GetPixel(i, j);
                            color.GetBrightness();
                            color_after_convert = (byte) (0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                            bmpAfterConvert.SetPixel(i, j,
                                Color.FromArgb(color_after_convert, color_after_convert, color_after_convert));
                        }
                    }

                    pictureBox1.Image = bmpAfterConvert;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Ошибка обработки!\nВозможно, обрабатываемый файл отсутствует или не найден.\nПовторите попытку позже.",
                    "Сообщение");
            }
        }

        private void saw_Click(object sender, EventArgs e)
        {
            if (bmpAfterConvert == null)
            {
                grey_Click(null, null);
            }
            bmpAfterConvertContrast = (Bitmap) bmpAfterConvert.Clone();
            for (int i = 0; i < bmpAfterConvertContrast.Width; i++)
            {
                for (int j = 0; j < bmpAfterConvertContrast.Height; j++)
                {
                    Color clr = bmp.GetPixel(i, j);
                    int g = clr.R;
                    int s = (256 / sawpicks);
                    g = (g % s) * sawpicks;
                    //if (g >= 0 && g <= 63)
                    //{
                    //    g = g * 4;
                    //}
                    //else if (g >= 64 && g <= 127)
                    //{
                    //    g = (g - 64) * 4;
                    //}
                    //else if (g >= 128 && g <= 191)
                    //{
                    //    g = (g - 128) * 4;
                    //}
                    //else
                    //{
                    //    g = (g - 192) * 4;
                    //}

                    bmpAfterConvertContrast.SetPixel(i, j, Color.FromArgb(clr.A, g, g, g));
                    pictureBox1.Image = bmpAfterConvertContrast;
                }
            }
        }

        private void mask_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmpAfterConvertFilter = (Bitmap) bmp.Clone();
                double[,] matrix = new double[3, 3];
                matrix[0, 0] = 0;
                matrix[1, 0] = -1;
                matrix[2, 0] = 0;
                matrix[0, 1] = -1;
                matrix[1, 1] = 8;
                matrix[2, 1] = -1;
                matrix[0, 2] = 0;
                matrix[1, 2] = -1;
                matrix[2, 2] = 0;
                int width = bmp.Width;
                int height = bmp.Height;

                int matrixWidth = matrix.GetLength(0);
                int matrixHeight = matrix.GetLength(1);

                //Производим вычисления
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        double rSum = 0, gSum = 0, bSum = 0,matrixsum=0;

                        for (int i = 0; i < matrixWidth; i++)
                        {
                            for (int j = 0; j < matrixHeight; j++)
                            {
                                int pixelPosX = x + (i - 1);
                                int pixelPosY = y + (j - 1);
                                if ((pixelPosX < 0) ||
                                  (pixelPosX >= width) ||
                                  (pixelPosY < 0) ||
                                  (pixelPosY >= height))
                                    continue;

                                byte r = bmp.GetPixel(pixelPosX, pixelPosY).R;
                                byte g = bmp.GetPixel(pixelPosX, pixelPosY).G;
                                byte b = bmp.GetPixel(pixelPosX, pixelPosY).B;

                                double matrixVal = matrix[i, j];
                                matrixsum += matrixVal;
                                rSum += r * matrixVal;
                                gSum += g * matrixVal;
                                bSum += b * matrixVal;

                                
                            }
                        }

                        rSum /= matrixsum;
                        if (rSum < 0)
                        {
                            rSum = 0;
                        }
                        if (rSum > 255)
                        {
                            rSum = 255;
                        }

                        gSum /= matrixsum;
                        if (gSum < 0)
                        {
                            gSum = 0;
                        }
                        if (gSum > 255)
                        {
                            gSum = 255;
                        }

                        bSum /= matrixsum;
                        if (bSum < 0)
                        {
                            bSum = 0;
                        }
                        if (bSum > 255)
                        {
                            bSum = 255;
                        }

                        //Записываем значения в результирующее изображение

                        bmpAfterConvertFilter.SetPixel(x, y, Color.FromArgb((byte)rSum, (byte)gSum, (byte)bSum));
                        
                    }
                }
                pictureBox1.Image = bmpAfterConvertFilter;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBox1.Text,out sawpicks);
        }
    }
}