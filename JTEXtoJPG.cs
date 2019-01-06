using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Diagnostics.Contracts;
using System.Windows.Forms;

namespace JTEXFileFormat
{
    static class JTEXtoJPG
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
            if (encodingIdentifier == 0X04) //RGBA4444
            {
                int firstByte = br.ReadByte();
                int secondByte = br.ReadByte();
                int B = firstByte >> 4; 
                int A = firstByte & 0x0F;
                int R = secondByte >> 4;
                int G = secondByte & 0x0F;
                newColor = Color.FromArgb(ConvertTo255(A), ConvertTo255(R), ConvertTo255(G), ConvertTo255(B));
                return newColor;
            }
            if (encodingIdentifier == 0X03) //RGB888
            {
                int B = br.ReadByte();
                int G = br.ReadByte();
                int R = br.ReadByte();
                newColor = Color.FromArgb(R, G, B);
                return newColor;
            }
            if (encodingIdentifier == 0X02) //RGB8888
            {
                int A = br.ReadByte();
                int R = br.ReadByte();
                int G = br.ReadByte();
                int B = br.ReadByte();
                newColor = Color.FromArgb(A, R, G, B);
                return newColor;
            }
            else
            {
                return newColor = Color.Empty;
            }
        }
        public static int ConvertTo255(int value)
        {
            var fromMaxRange = (1 << 4) - 1;
            var toMaxRange = (1 << 8) - 1;

            var div = 1;
            while (toMaxRange % fromMaxRange != 0)
            {
                div <<= 1;
                toMaxRange = ((toMaxRange + 1) << 1) - 1;
            }

            return value * (toMaxRange / fromMaxRange) / div;
        }
        [STAThreadAttribute]
        public static string FileDialogBox()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jtex files (*.jtex)|*.jtex|jtex (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
                return filePath;
            }
        }
        [STAThreadAttribute]
        public static void Main(string[] args)
        {
            string FileName = FileDialogBox();
            if (string.IsNullOrEmpty(FileName))
            {
                return;
            }
            using (BinaryReader br = new BinaryReader(File.Open(FileName, FileMode.Open)))
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
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    color = br.ReadPixel(encodingIdentifier);
                    var point = ZOrder[pixel % 64]; //Cycles 0-63
                    int x = (point.X + (pixel / 64 % widthTiles) * 8);
                    int y = (point.Y + (pixel / 64 / widthTiles) * 8);
                    newImage.SetPixel(x, y, color);
                    pixel++;
                }
                newImage.Save(FileName + ".jpg");
            }
        }
    }
}
