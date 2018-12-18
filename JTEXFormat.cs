using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;




namespace JTEXFileFormat
{
    class JTEXFormat
    {
        public int x;
        public int y;

        static void Main(string[] args)
        {
            
        }
        public void getImageData()
        {
            using (BinaryReader sr = new BinaryReader(File.Open("Character.jtex", FileMode.Open)))
            {
                int fileDataOffset = sr.ReadInt32();
                int encodingIdentifier = sr.ReadInt32();
                int imageWidth = sr.ReadInt32();
                int imageHeight = sr.ReadInt32();
                int strideWidth = sr.ReadInt32();
                int strideHeight = sr.ReadInt32();
                sr.BaseStream.Position = fileDataOffset;
                Bitmap newImage = new Bitmap(imageWidth, imageHeight);
                using (BinaryWriter bw = new BinaryWriter(File.Open("JTEXFileData.txt", FileMode.Create)))
                {
                    if (encodingIdentifier == 0x04) // 0X04=RGBA4444
                    {
                        for (x = 0; x < newImage.Width; x++)
                        {
                            for (y = 0; y < newImage.Height; y++)
                            {
                                Color pixelColor = newImage.GetPixel(x, y);
                                Color newColor = Color.FromArgb(sr.ReadBytes(4), sr.ReadBytes(4), sr.ReadBytes(8), sr.ReadBytes(8));
                                newImage.SetPixel(x, y, newColor);
                            }
                        }
                    }
                    if (encodingIdentifier == 0x03) // 0x03=RGB888
                    {
                        for (y = 0; y < newImage.Height; y++)
                        {
                            for (x = 0; x < newImage.Width; x++)
                            {
                                int R = sr.ReadByte();
                                int G = sr.ReadByte();
                                int B = sr.ReadByte();
                                Color newColor = Color.FromArgb(R, G, B);
                                newImage.SetPixel(x, y, newColor);
                            }
                        }
                    }
                    if (encodingIdentifier == 0x02) // 0X02=RGBA8888
                    {
                        for (x = 0; x < newImage.Width; x++)
                        {
                            for (y = 0; y < newImage.Height; y++)
                            {
                                Color pixelColor = newImage.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                                newImage.SetPixel(x, y, newColor);
                            }
                        }
                    }
                }
                

            }
        }

    }
}
