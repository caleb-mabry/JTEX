using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JTEXFileFormat
{
    class JTEXFormat
    {

        static void Main(string[] args)
        {
            
        }
        public void getImageData()
        {
            try
            {
                BinaryReader sr = new BinaryReader("C:\Users\Evan\Desktop"); //Change this to change the location of your file
                int fileDataOffset = sr.ReadInt32();
                int encodingIdentifier = sr.ReadInt32();
                int imageWidth = sr.ReadInt32();
                int imageHeight = sr.ReadInt32();
                int strideWidth = sr.ReadInt32();
                int strideHeight = sr.ReadInt32();
                sr.BaseStream.Position = fileDataOffset;

                if (encodingIdentifier == 0x04) // 0X04=RGBA4444
                {

                }
                if (encodingIdentifier == 0x03) // 0x03=RGB888
                {

                }
                if (encodingIdentifier == 0x02) // 0X02=RGBA8888
                {

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Exception: Maybe another time");
            }
        }

    }
}
