using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gif.Components;
using System.Drawing;
using System.Drawing.Imaging;

namespace Command
{
    public class GifHelp
    {
        /// <summary>
        /// 将图片集合转换为GIF
        /// </summary>
        /// <param name="imgFilePaths">图片集合路径</param>
        /// <param name="gifFileName">输出gif文件路径</param>
        /// <param name="Delay">每帧间隔毫秒</param>
        /// <returns></returns>
        public static bool ImageToGif(string[] imgFilePaths, string gifFileName, int Delay)
        {
            try
            {
                //String[] imageFilePaths = new String[] { "c:\\01.png", "c:\\02.png", "c:\\03.png" };
                //String outputFilePath = "c:\\test.gif";
                AnimatedGifEncoder e = new AnimatedGifEncoder();
                e.Start(gifFileName);
                e.SetDelay(Delay);
                //-1:no repeat,0:always repeat
                e.SetRepeat(0);
                for (int i = 0, count = imgFilePaths.Length; i < count; i++)
                {
                    var img = Image.FromFile(imgFilePaths[i]);
                    e.AddFrame(img);
                    img.Dispose();
                }
                e.Finish();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GifToImage(string outPath, string gifFileName)
        {
            try
            {
                /* extract Gif */
                GifDecoder gifDecoder = new GifDecoder();
                gifDecoder.Read(gifFileName);
                for (int i = 0, count = gifDecoder.GetFrameCount(); i < count; i++)
                {
                    Image frame = gifDecoder.GetFrame(i); // frame i
                    frame.Save(outPath + Guid.NewGuid().ToString()
                                          + ".png", ImageFormat.Png);
                    frame.Dispose();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
