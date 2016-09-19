using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace ASSISTME.SNIPS.IMG.FILTERS
{
    public class Booster
    {
        private static byte[] cpy;
       
        [DllImport("Boost.dll")]
        private static extern void YSobel(int size, int width, int height, byte[] image, byte[] cpy);

        public static void Execute(MyImg img)
        {
            if (cpy == null || cpy.Length != img.Length)
                cpy = new byte[img.Length];

            YSobel(img.Length, img.Width, img.Height, img.ImageData, cpy);
        }
    }
}
