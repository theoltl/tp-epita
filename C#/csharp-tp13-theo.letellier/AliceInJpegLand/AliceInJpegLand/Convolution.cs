using System;
using System.Drawing;

namespace AliceInJpegLand
{
    public static class Convolution
    {
        /// <summary>
        /// Gauss convolution Matrix
        /// </summary>
        private static readonly float[,] GaussMatrix = {
            {1/9f, 2/9f, 1/9f},
            {2/9f, 4/9f, 2/9f},
            {1/9f, 2/9f, 1/9f}
        };

        /// <summary>
        /// Sharpen convolution Matrix
        /// </summary>
        private static readonly float[,] SharpenMatrix = {
            { 0f, -1f,  0f},
            {-1f,  5f, -1f},
            { 0f, -1f,  0f}
        };

        /// <summary>
        /// Blur convolution Matrix
        /// </summary>
        private static readonly float[,] BlurMatrix = {
            {1/9f, 1/9f, 1/9f},
            {1/9f, 1/9f, 1/9f},
            {1/9f, 1/9f, 1/9f}
        };

        /// <summary>
        /// Edge enhance convolution Matrix
        /// </summary>
        private static readonly float[,] EdgeEnhanceMatrix = {
            { 0f, 0f, 0f},
            {-1f, 1f, 0f},
            { 0f, 0f, 0f}
        };

        /// <summary>
        /// Edge detect convolution Matrix
        /// </summary>
        private static readonly float[,] EdgeDetectMatrix = {
            {0f,  1f, 0f},
            {1f, -4f, 1f},
            {0f,  1f, 0f}
        };

        /// <summary>
        /// Emboss convolution Matrix
        /// </summary>
        private static readonly float[,] EmbossMatrix = {
            {-2f, -1f, 0f},
            {-1f,  1f, 1f},
            { 0f,  1f, 2f}
        };

        
        private static int Restrict256(double f)
        {
            if (f > 255)
                f = 255;
            else if (f < 0)
                f = 0;
            return (int) f;
        }
        
        
        /// <summary>
        /// Returns a copy of the image with a convolution mask applied
        /// </summary>
        /// <param name="image">Image to work on</param>
        /// <param name="mask">Convolution matrix to apply</param>
        /// <returns>A copy of image with convolution mask applied</returns>
        public static Bitmap Convolute(this Bitmap image, float[,] mask)
        {
            int M_Size = mask.GetLength(0);
                int largeur = image.Width;
                int hauteur = image.Height;
                
                Bitmap img = new Bitmap(largeur, hauteur);

                for (int i = 0; i < largeur; i++)
                {
                    for (int j = 0; j < hauteur; j++)
                    {
                        double rouge = 0;
                        double vert = 0;
                        double bleu = 0;
                    
                        for (int k = 0; k < M_Size; k++)
                        {
                            for (int l = 0; l < M_Size; l++)
                            {
                                if(i+k < largeur && j+l < hauteur)
                                {
                                    rouge += image.GetPixel(i + k, j + l).R * mask[k, l];
                                    vert += image.GetPixel(i + k, j + l).G * mask[k, l];
                                    bleu += image.GetPixel(i + k, j + l).B * mask[k, l];
                                }
                            }
                        }
                    
                        img.SetPixel(i, j, Color.FromArgb(Restrict256(rouge), 
                            Restrict256(vert), Restrict256(bleu)));
                    }
                }
            return img;
        }


        /// <summary>
        /// Applies gauss convolution
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap Gauss(this Bitmap image)
        {
            return Convolute(image, GaussMatrix);
        }

        /// <summary>
        /// Applies sharpen convolution
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap Sharpen(this Bitmap image)
        {
            return Convolute(image, SharpenMatrix);
        }

        /// <summary>
        /// Applies blur convolution
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap Blur(this Bitmap image)
        {
            return Convolute(image, BlurMatrix);
        }

        /// <summary>
        /// Applies edge enhance convolution
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap EdgeEnhance(this Bitmap image)
        {
            return Convolute(image, EdgeEnhanceMatrix);
        }

        /// <summary>
        /// Applies edge detect convolution
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap EdgeDetect(this Bitmap image)
        {
            return Convolute(image, EdgeDetectMatrix);
        }

        /// <summary>
        /// Applies emboss convolution
        /// </summary>
        /// <param name="image">Image to work on</param>
        public static Bitmap Emboss(this Bitmap image)
        {
            return Convolute(image, EmbossMatrix);
        }

    }
}
