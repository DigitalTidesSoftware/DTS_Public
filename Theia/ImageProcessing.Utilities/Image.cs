using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace ImageProcessing.Utilities
{
    public class Image
    {
        public static byte[] GetImageRaw(string imageFileLocation)
        {
            byte[] imageBytes;

            using (FileStream fileStream = new FileStream(imageFileLocation, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fileStream);
                try
                {
                    imageBytes = new byte[fileStream.Length];
                    fileStream.Read(imageBytes, 0, imageBytes.Length);
                }
                catch (Exception ex)
                {
                    //What could this possibly throw?
                    throw;
                }
                finally
                {
                    br.Close();
                    fileStream.Close();
                }
            }

            return imageBytes;
        }


        public static System.Drawing.Image GetImageFromRaw(byte[] imageRaw)
        {

        }
    }
}
