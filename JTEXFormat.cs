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
            using (BinaryReader sr = new BinaryReader(File.Open("Character.jtex", FileMode.Open)))
            {
                int fileDataOffset = sr.ReadInt32();
                int encodingIdentifier = sr.ReadInt32();
                int imageWidth = sr.ReadInt32();
                int imageHeight = sr.ReadInt32();
                int strideWidth = sr.ReadInt32();
                int strideHeight = sr.ReadInt32();
                sr.BaseStream.Position = fileDataOffset;
                using (BinaryWriter br = new BinaryWriter(File.Open("Character.jtex", FileMode.Create)))
                {
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
                

            }
        }

    }
}
