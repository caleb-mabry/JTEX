using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTEXFileFormat
{
    public class JTEXFileSupport
    {
        public int fileDataOffset;
        int encodingIdentifier; // 0X04=RGBA4444 | 0x03=RGB888 | 0X02=RGBA8888
        int imageWidth; //Without Stride
        int imageHeight; //Without Stride
        int strideWidth;
        int strideHeight;

    }
}
