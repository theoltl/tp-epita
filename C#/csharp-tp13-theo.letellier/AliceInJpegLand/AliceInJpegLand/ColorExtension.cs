using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AliceInJpegLand
{
    public static class ColorExtension
    {
        /// <summary>
        /// Get a color from a string
        /// </summary>
        /// <param name="str">Hexadecimal color code (with no #)</param>
        public static Color FromHexa(string str)
        {
            if (str.Length != 6)
                throw new ArgumentException();
            str = '#' + str.ToUpper();
            Color color;
            try
            {
                color =  ColorTranslator.FromHtml(str);
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
            return color;
        }

        /// <summary>
        /// Returns a color corresponding to the given color inverted
        /// </summary>
        /// <param name="color">The color to work on</param>
        public static Color Invert(this Color color)
        {
            var rouge = 255 - color.R;
            var bleu = 255 - color.B;
            var vert = 255 - color.G;
            return Color.FromArgb(rouge, vert, bleu);
        }

        /// <summary>
        /// Return a color corresponding to the given color human grayscaled (see formula)
        /// </summary>
        /// <param name="color">The color to work on</param>
        public static Color Grayscale(this Color color)
        {
            int grey = (int) (0.21 * color.R + 0.72 * color.G + 0.07 * color.B);
            return Color.FromArgb(grey, grey, grey);
        }

        /// <summary>
        /// OPTIONAL
        /// Limits an int n between 0 and 255
        /// </summary>
        private static int Restrict256(int n)
        {
            if (n > 255)
                n = 255;
            else if (n < 0)
                n = 0;
            return n;
        }

        /// <summary>
        /// OPTIONAL
        /// Limits a float f between 0 and 255
        /// </summary>
        private static int Restrict256(double f)
        {
            if (f > 255)
                f = 255;
            else if (f < 0)
                f = 0;
            return (int) f;
        }

        /// <summary>
        /// Returns a color corresponding the given color with a modified brightness
        /// </summary>
        /// <param name="color">The color to work on</param>
        /// <param name="delta">Brightness modification (usually between -255 and 255)</param>
        public static Color Brightness(this Color color, int delta)
        {
            
            var rouge = Restrict256(color.R + delta);
            var bleu = Restrict256(color.B + delta);
            var vert = Restrict256(color.G + delta);

            return Color.FromArgb(rouge, vert, bleu);
        }

        /// <summary>
        /// Returns a contrasted color with a given factor
        /// </summary>
        /// <param name="color">Color to modify</param>
        /// <param name="factor">Factor of modification</param>
        public static Color Contrast(this Color color, double factor)
        {
            double F = 259 * (factor + 255) / (255 * (259 - factor));
            
            var rouge = Restrict256(F * (color.R-128) + 128);
            var bleu = Restrict256(F * (color.B-128) + 128);
            var vert = Restrict256(F * (color.G-128) + 128);
            
            return Color.FromArgb(rouge, vert, bleu);
            
        }

        /// <summary>
        /// Returns a color resulting from a gradient map
        /// </summary>
        /// <param name="color">The color to work on</param>
        /// <param name="blackMatch">Dark color match in the gradient</param>
        /// <param name="whiteMatch">Light color match in the gradient</param>
        public static Color GradientMap(this Color color,
                Color blackMatch, Color whiteMatch)
        {
            var r = (whiteMatch.R - blackMatch.R) / 255;
            var b = (whiteMatch.B - blackMatch.B) / 255;
            var v = (whiteMatch.G - blackMatch.G) / 255;

            var luminosity = (color.R + color.B + color.G) / 3;
            
            var rouge = luminosity * r + blackMatch.R;
            var bleu = luminosity * b + blackMatch.B;
            var vert = luminosity * v + blackMatch.G;
            
            return Color.FromArgb(rouge, vert, bleu);
        }

        /// <summary>
        /// Returns the resulting color from two color with an opacity percentage
        /// </summary>
        /// <param name="a">Color to cover</param>
        /// <param name="b">Covering color</param>
        /// <param name="opacity">Opacity percentage</param>
        public static Color Cover(this Color a, Color b, int opacity)
        {
            if (opacity < 0)
                opacity = 0;
            
            else if (opacity > 255)
                opacity = 255;
            
            var rouge = (a.R * (100 - opacity) + b.R * opacity) / 100;
            var bleu = (a.B * (100 - opacity) + b.B * opacity) / 100;
            var vert = (a.G * (100 - opacity) + b.G * opacity) / 100;
            
            return Color.FromArgb(rouge, vert, bleu);
        }
    }
}
