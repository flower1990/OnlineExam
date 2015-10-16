using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace Sower.CommFunction
{
    public class ValidCode
    {
        private const int intHeight = 25;
        private const int intWidth = 66;
        private static int complexDepth = 4;

        /// <summary>
        /// 生产随机数
        /// </summary>
        /// <returns></returns>
        public string CreateValidString()
        {
            Random random = new Random();
            string letters = "1234567890abcdefghjklmnpqrstuvwxyABCDEFGHJKLMNPQRSTUVWXY";
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < complexDepth; i++)
            {
                result.Append(letters.Substring(random.Next(0, letters.Length - 1), 1));
            }
            return result.ToString();
        }

        /// <summary>
        /// 根据获取的随机数生产图片
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public byte[] CreateValidCodeImage(string code)
        {

            Bitmap _tmpbit;
            if (string.IsNullOrEmpty(code.Trim()))
            {
                return null;
            }
            Bitmap desImage = new Bitmap(intWidth, intHeight);
            Graphics graphics = Graphics.FromImage(desImage);
            try
            {
                Random randon = new Random();
                graphics.Clear(Color.White);
                for (int i = 0; i < complexDepth; i++)
                {
                    int x1 = randon.Next(desImage.Width);
                    int y1 = randon.Next(desImage.Height);
                    int x2 = randon.Next(desImage.Width);
                    int y2 = randon.Next(desImage.Height);
                    switch (i)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            graphics.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                            break;

                        case 4:
                        case 5:
                        case 6:
                            graphics.DrawLine(new Pen(Color.DarkRed), x1, y1, x2, y2);
                            break;

                        case 7:
                        case 8:
                        case 9:
                            graphics.DrawLine(new Pen(Color.Blue), x1, y1, x2, y2);
                            break;

                        case 10:
                        case 11:
                        case 12:
                            graphics.DrawLine(new Pen(Color.Coral), x1, y1, x2, y2);
                            break;
                    }
                }
                Font font = new Font("Arial", 14f, FontStyle.Italic | FontStyle.Bold);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, desImage.Width, desImage.Height), Color.Blue, Color.Red, 1.2f, true);
                graphics.DrawString(code, font, brush, (float)1f, (float)1f);
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, desImage.Width - 1, desImage.Height - 1);
                _tmpbit = desImage;

                MemoryStream stream = new MemoryStream();
                _tmpbit.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            //catch (Exception)
            //{
            //    desImage.Dispose();
            //    _tmpbit = null;
            //    return byte[];
            //}
            finally
            {
                desImage.Dispose();
                graphics.Dispose();
            }
            //return _tmpbit;
        }
    }
}
