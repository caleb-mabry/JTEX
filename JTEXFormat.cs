using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
// TODO: The files are still not being converted properly


namespace JTEXFileFormat
{
    static class JTEXFormat
    {
        public static List<Point> ZOrder = new List<Point>
        {
            new Point(0,0),
            new Point(1,0),
            new Point(0,1),
            new Point(1,1),
            new Point(2,0),
            new Point(3,0),
            new Point(2,1),
            new Point(3,1),
            new Point(0,2),
            new Point(1,2),
            new Point(0,3),
            new Point(1,3),
            new Point(2,2),
            new Point(3,2),
            new Point(2,3),
            new Point(3,3),
            new Point(4,0),
            new Point(5,0),
            new Point(4,1),
            new Point(5,1),
            new Point(6,0),
            new Point(7,0),
            new Point(6,1),
            new Point(7,1),
            new Point(4,2),
            new Point(5,2),
            new Point(4,3),
            new Point(5,3),
            new Point(6,2),
            new Point(7,2),
            new Point(6,3),
            new Point(7,3),
            new Point(0,4),
            new Point(1,4),
            new Point(0,5),
            new Point(1,5),
            new Point(2,4),
            new Point(3,4),
            new Point(2,5),
            new Point(3,5),
            new Point(0,6),
            new Point(1,6),
            new Point(0,7),
            new Point(1,7),
            new Point(2,6),
            new Point(3,6),
            new Point(2,7),
            new Point(3,7),
            new Point(4,4),
            new Point(5,4),
            new Point(4,5),
            new Point(5,5),
            new Point(6,4),
            new Point(7,4),
            new Point(6,5),
            new Point(7,5),
            new Point(4,6),
            new Point(5,6),
            new Point(4,7),
            new Point(5,7),
            new Point(6,6),
            new Point(7,6),
            new Point(6,7),
            new Point(7,7)
        };

        public static Color ReadPixel(this BinaryReader br, int encodingIdentifier)
        {
            Color newColor;
            if (encodingIdentifier == 0X04 && br.BaseStream.Position < br.BaseStream.Length) //Character RGBA4444
            {
                int AandRUnsplit = br.ReadByte();
                int A = AandRUnsplit % 16;
                int R = AandRUnsplit / 16;
                int GandBUnsplit = br.ReadByte();
                int G = GandBUnsplit % 16;
                int B = GandBUnsplit / 16;

                newColor = Color.FromArgb(A, R, G, B);
                return newColor;
            }
            if (encodingIdentifier == 0X03 && br.BaseStream.Position < br.BaseStream.Length) //TalkU_Bg15 RGB888
            {
                int R = br.ReadByte();
                int G = br.ReadByte();
                int B = br.ReadByte();
                newColor = Color.FromArgb(R, G, B);
                return newColor;
            }
            if (encodingIdentifier == 0X03 && br.BaseStream.Position < br.BaseStream.Length) // 
            {
                int R = br.ReadByte();
                int G = br.ReadByte();
                int B = br.ReadByte();
                newColor = Color.FromArgb(R, G, B);
                return newColor;
            }
            else
            {
                return newColor = Color.Empty;
            }
        }



        public static void Main(string[] args)
        {
            using (BinaryReader br = new BinaryReader(File.Open("Character.jtex", FileMode.Open)))
            {
                int fileDataOffset = br.ReadInt32();
                int encodingIdentifier = br.ReadInt32();
                int imageWidth = br.ReadInt32();
                int imageHeight = br.ReadInt32();
                int strideWidth = br.ReadInt32();
                int strideHeight = br.ReadInt32();
                br.BaseStream.Position = fileDataOffset;
                Bitmap newImage = new Bitmap(strideWidth, strideHeight);
                var pixel = 0;
                var widthTiles = strideWidth / 8;
                Color color;
                while (br.ReadPixel(encodingIdentifier) != Color.Empty)
                {
                    color = br.ReadPixel(encodingIdentifier);
                    var point = ZOrder[pixel % 64];
                    newImage.SetPixel(point.X + (pixel / 64 % widthTiles) * 8, point.Y + (pixel / 64 / widthTiles) * 8, color);
                    pixel++;
                }
                newImage.Save("Fixed.bitmap");
            }
        }
    }

    //public static void Main(string[] args)
    //    {
    //        using (BinaryReader sr = new BinaryReader(File.Open("TalkU_Bg15.jtex", FileMode.Open)))
    //        {
    //            int fileDataOffset = sr.ReadInt32();
    //            int encodingIdentifier = sr.ReadInt32();
    //            int imageWidth = sr.ReadInt32();
    //            int imageHeight = sr.ReadInt32();
    //            int strideWidth = sr.ReadInt32();
    //            int strideHeight = sr.ReadInt32();
    //            sr.BaseStream.Position = fileDataOffset;
    //            Bitmap newImage = new Bitmap(imageWidth, imageHeight);
    //            newImage.SetPropertyItem.strideHeight() = strideHeight
    //            using (BinaryWriter bw = new BinaryWriter(File.Open("JTEXFileData.txt", FileMode.Create)))
    //            {
    //                //if (encodingIdentifier == 0x04) // 0X04=RGBA4444
    //                //{
    //                //    for (x = 0; x < newImage.Width; x++)
    //                //    {
    //                //        for (y = 0; y < newImage.Height; y++)
    //                //        {
    //                //            Color pixelColor = newImage.GetPixel(x, y);
    //                //            Color newColor = Color.FromArgb(sr.ReadBytes(4), sr.ReadBytes(4), sr.ReadBytes(8), sr.ReadBytes(8));
    //                //            newImage.SetPixel(x, y, newColor);
    //                //        }
    //                //    }
    //                //}

    //                if (encodingIdentifier == 0x03) // 0x03=RGB888
    //                {
    //                    for (int y = 0; y < newImage.Height; y++)
    //                    {
    //                        for (int x = 0; x < newImage.Width; x++)
    //                        {
    //                            int R = sr.ReadByte();
    //                            int G = sr.ReadByte();
    //                            int B = sr.ReadByte();
    //                            Color newColor = Color.FromArgb(R, G, B);
    //                            newImage.SetPixel(x, y, newColor);
    //                        }
    //                    }

    //                    newImage.Save("NewImage.bitmap");
    //                }
    //                //if (encodingIdentifier == 0x02) // 0X02=RGBA8888
    //                //{
    //                //    for (x = 0; x < newImage.Width; x++)
    //                //    {
    //                //        for (y = 0; y < newImage.Height; y++)
    //                //        {
    //                //            Color pixelColor = newImage.GetPixel(x, y);
    //                //            Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
    //                //            newImage.SetPixel(x, y, newColor);
    //                //        }
    //                //    }
    //                //}
    //            }


    //        }
    //    }

    //}
}
