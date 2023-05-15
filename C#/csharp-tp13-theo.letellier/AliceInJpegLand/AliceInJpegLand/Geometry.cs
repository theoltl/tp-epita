using System;
using System.Drawing;

namespace AliceInJpegLand
{
    public static class Geometry
    {
        /// <summary>
        /// Gets a copy of the image rotated 90 degrees clockwise
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap RotateRight(this Bitmap image)
        {
            int largeur = image.Width;
            int hauteur = image.Height;
            
            Bitmap img = new Bitmap(largeur, hauteur);
            
            for (int i = 0; i < largeur; i++)
            {
                for (int j = hauteur - 1; j > 0; j--)
                    img.SetPixel(j, i, image.GetPixel(i, hauteur - j));
            }

            return img;
        }

        /// <summary>
        /// Gets a copy of the image rotated 90 degrees anti-clockwise
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap RotateLeft(this Bitmap image)
        {
            int largeur = image.Width;
            int hauteur = image.Height;

            Bitmap img = new Bitmap(largeur, hauteur);

            for (int i = largeur - 1; i > 0; i--)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    img.SetPixel(j, i, image.GetPixel(largeur - i, j));
                }
            }
            
            return img;
        }

        /// <summary>
        /// Applies a vertical rotation
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static void SymmetryX(this Bitmap image)
        {
            int largeur = image.Width;
            int hauteur = image.Height;

            Bitmap img = new Bitmap(largeur, hauteur);

            for (int i = largeur - 1; i > 0; i--)
            {
                for (int j = 0; j < hauteur; j++)
                    img.SetPixel(i, j, image.GetPixel(largeur - i, j));
            }
            
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                    image.SetPixel(i, j, img.GetPixel(i, j));
            }
        }

        /// <summary>
        /// Applies a horizontal rotation
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static void SymmetryY(this Bitmap image)
        {
            int largeur = image.Width;
            int hauteur = image.Height;
            
            Bitmap img = new Bitmap(largeur, hauteur);
            
            for (int i = 0; i < largeur; i++)
            {
                for (int j = hauteur - 1; j > 0; j--)
                    img.SetPixel(i, j, image.GetPixel(i, hauteur - j));
            }
            
            //Cloning
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                    image.SetPixel(i, j, img.GetPixel(i, j));
            }
        }

        
        private static int Restrict256(double f)
        {
            if (f > 255)
                f = 255;
            else if (f < 0)
                f = 0;
            return (int) f;
        }
        
        /// <summary>
        /// Gets a copy of the image resized
        /// </summary>
        /// <param name="image">Image to work on</param>
        /// <param name="x">Width of the new image</param>
        /// <param name="y">Height of the new image</param>
        public static Bitmap Resize(this Bitmap image, int x, int y)
        {
            Bitmap img = new Bitmap(x, y);
            
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int x2 = Restrict256((double) image.Width / x * i);
                    int y2 = Restrict256((double) image.Height / y * j);
                    
                    img.SetPixel(i, j, image.GetPixel(x2 , y2));
                }
            }

            return img;
        }


        /// <summary>
        /// Gets a copy of the image shifted
        /// </summary>
        /// <param name="image">Image to work on</param>
        /// <param name="x">Horizontal shift</param>
        /// <param name="y">Vertical shift</param>
        public static Bitmap Shift(this Bitmap image, int x, int y)
        {
            int largeur = image.Width;
            int hauteur = image.Height;
            
            Bitmap img = new Bitmap(largeur, hauteur);
            
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                    img.SetPixel((i + x + largeur) % largeur, (j + y + hauteur) % hauteur, image.GetPixel(i, j));
            }
            
            return img;
        }
    }
}
