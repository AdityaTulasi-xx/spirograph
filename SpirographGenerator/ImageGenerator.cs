using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SpirographGenerator
{
    public static class ImageGenerator
    {
        public static void CreateAndSaveImage(string fullFilePath,
            IEnumerable<Tuple<double, double>> pointsToPlot,
            int width,
            int height)
        {
            int xCenter = width / 2;
            int yCenter = height / 2;

            using (var bmp = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    Pen drawingPen = new Pen(Color.Black);

                    Tuple<double, double> prevPoint = null;

                    foreach (var curPoint in pointsToPlot)
                    {
                        if (prevPoint != null)
                        {
                            g.DrawLine(drawingPen,
                                new Point((int)prevPoint.Item1 + xCenter, (int)prevPoint.Item2 + yCenter),
                                new Point((int)curPoint.Item1 + xCenter, (int)curPoint.Item2 + yCenter));
                        }

                        prevPoint = curPoint;
                    }
                }

                MemoryStream stream = new MemoryStream();
                bmp.Save(stream, ImageFormat.Jpeg);
                File.WriteAllBytes(fullFilePath, stream.ToArray());
            }
        }
    }
}
