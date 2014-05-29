using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Core.File
{
    /*See http://en.wikipedia.org/wiki/BMP_file_format for more information*/
    public class BitmapHolder
    {
        /* 
         * This codebook is formed from the concatenation of the 
         * first two bytes to form an integer
         */
        public enum BitmapHeaderCode
        {
            BM = 16973,     //Windows 3.1x, 95, NT, ... etc.
            BA = 16961,     //OS/2 struct Bitmap Array
            CI,             //OS/2 struct Color Icon
            CP,             //OS/2 const Color Pointer
            IC,             //OS/2 struct Icon
            PT              //OS/2 Pointer
        }

        #region Constructors
        public BitmapHolder(byte[] bitmapArray)
        {
            this.RawBitmap = bitmapArray;

            BitmapHeader = FindBitmapHeader(RawBitmap);
            BitmapSize = FindBitmapSizeInBytes(RawBitmap);
            ImageOffset = FindImageOffset(RawBitmap);
        }
        #endregion

        #region Properties

        public byte[] RawBitmap { get; private set; }

        /* See enum BitmapHeaderCode for information */
        public BitmapHeaderCode BitmapHeader { get; set;}

        /* Size in Bytes */
        public int BitmapSize { get; set;}

        /* Where the image data actually begins */
        public int ImageOffset { get; set; }

        #endregion

        
        #region Procedures

        public static BitmapHeaderCode FindBitmapHeader(byte[] bitmapArray)
        {
            byte[] bitmapSub = new byte[2];
            Array.Copy(bitmapArray, 0, bitmapSub, 0, 2);

            int headerCode = bitmapSub[0] <<= 8;
            headerCode ^= bitmapSub[1];

            return (BitmapHeaderCode) headerCode;
        }

        public static int FindBitmapSizeInBytes(byte[] bitmapArray)
        {
            byte[] bitmapSub = new byte[4];
            Array.Copy(bitmapArray, 2, bitmapSub, 0, 4);

            int size = 0;

            for (int i = 0; i < 4; i++)
            {
                size ^= bitmapArray[i];
                size <<= 8;
            }

            return size ^= bitmapArray[4];
        }


        /* Starts at position and is 4 bytes long */
        public static int FindImageOffset(byte[] bitmapArray)
        {

            byte[] bitmapSub = new byte[4];
            Array.Copy(bitmapArray, 10, bitmapSub, 0, 4);

            int startingLocation = 0;

            for (int i = 0; i < 4; i++)
            {
                startingLocation ^= bitmapSub[i];

                if (i == 3) { break; }
                
                startingLocation <<= 8;
            }

            return startingLocation;
        }

        #endregion
    }
}
