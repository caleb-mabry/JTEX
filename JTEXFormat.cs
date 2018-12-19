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

        public static int gen(int n)
        {

            // S(0) = 0 
            if (n == 0)
                return 0;

            // S(1) = 1 
            else if (n == 1)
                return 1;

            // S(2 * n) = 4 * S(n) 
            else if (n % 2 == 0)
                return 4 * gen(n / 2);

            // S(2 * n + 1) = 4 * S(n) + 1 
            else if (n % 2 == 1)
                return 4 * gen(n / 2) + 1;
            return 0;
        }

        // Generating the first 'n' terms  
        // of Moser-de Bruijn Sequence 
        public static void moserDeBruijn(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(gen(i) + " ");
            Console.WriteLine();
        }

        // Driver Code 
        public static void Main()
        {
            int n = 8;
            Console.WriteLine("First " + n +
                            " terms of " +
            "Moser-de Bruijn Sequence : ");
            moserDeBruijn(n);
        }
        public static void test()
        {
            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            dict.Add(4, "One");
            dict.Add(5, "Two");
            dict.Add(6, "Three");
            dict.Add(7, "Three");
            dict.Add(8, "Three");
            dict.Add(9, "Three");
            dict.Add(10, "Three");
            dict.Add(11, "Three");
            dict.Add(12, "Three");
            dict.Add(13, "Three");
            dict.Add(14, "Three");
            dict.Add(15, "Three");
            dict.Add(16, "Three");
            dict.Add(17, "Three");
            dict.Add(18, "Three");
            dict.Add(19, "Three");
            dict.Add(20, "Three");
            dict.Add(21, "One");
            dict.Add(22, "Two");
            dict.Add(23, "Three");
            dict.Add(24, "One");
            dict.Add(25, "Two");
            dict.Add(26, "Three");
            dict.Add(27, "Three");
            dict.Add(28, "Three");
            dict.Add(29, "Three");
            dict.Add(30, "Three");
            dict.Add(31, "Three");
            dict.Add(32, "Three");
            dict.Add(33, "Three");
            dict.Add(34, "Three");
            dict.Add(35, "Three");
            dict.Add(36, "Three");
            dict.Add(37, "Three");
            dict.Add(38, "Three");
            dict.Add(39, "Three");
            dict.Add(40, "Three");
            dict.Add(41, "One");
            dict.Add(42, "Two");
            dict.Add(43, "Three");
            dict.Add(44, "One");
            dict.Add(45, "Two");
            dict.Add(46, "Three");
            dict.Add(47, "Three");
            dict.Add(48, "Three");
            dict.Add(49, "Three");
            dict.Add(50, "Three");
            dict.Add(51, "Three");
            dict.Add(52, "Three");
            dict.Add(53, "Three");
            dict.Add(54, "Three");
            dict.Add(55, "Three");
            dict.Add(56, "Three");
            dict.Add(57, "Three");
            dict.Add(58, "Three");
            dict.Add(59, "Three");
            dict.Add(61, "Three");
            dict.Add(62, "Three");
            dict.Add(63, "Three");
            dict.Add(64, "Three");
            dict.Add(65, "Three");

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
