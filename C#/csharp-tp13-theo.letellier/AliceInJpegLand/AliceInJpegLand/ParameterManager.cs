using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;

namespace AliceInJpegLand
{
    public static class ParameterManager
    {
        /// <summary>
        /// Displays an help message
        /// </summary>
        private static void Help()
        {
            string help = @" Usage: ./aliceInJpegLand input-image [options...] output-image
Options
-i, --invert
-g, --grayscale
-b, --brightness INTEGER
-c, --contrast INTEGER
-a, --gradient-map COLOR1 COLOR2
-m, --cover PATH INTEGER
-l, --rotate-left
-r, --rotate-right
-x, --symmetry-x
-y, --symmetry-y
--resize INTEGER1 INTEGER2
--shift INTEGER1 INTEGER2
--gauss
--sharpen
--blur
--edge-enhance
--edge-detect
--emboss
--encrypt-string STRING
--encrypt-image IMAGEPATH
--decrypt-string
--decrypt-image
-h, --help
";
            Console.Error.WriteLine(help);
        }


        public static List<string> GetArgs(string[] command)
        {
            List<string> list = new List<string>(command);
            
            if (command[0] == "-h" || command[0] == "--help")
                Help();

            else
            {
                if (command.Length == 0)
                {
                    throw new Exception();
                }
                
                if (command.Length == 1)
                {
                    program = command[0];
                    throw new Exception();
                }
                list.RemoveAt(0);
            }
            
            return list;
        }

        public static string program;

        /// <summary>
        /// Verify args validity for the program
        /// Prints an error message in error console if the arguments are invalid
        /// </summary>
        /// <param name="args">CLI arguments array</param>
        /// <returns>true if the arguments are valid, false otherwise</returns>
        public static bool VerifyArgsValidity(string[] args)
        {
            List<string> command;
            try
            {
                command = GetArgs(args);
                while (command.Count > 1)
                {
                    program = command[0];
                    if (program == "-i" || program == "--invert")
                        command.RemoveAt(0);

                    else if (program == "-g" || program == "--grayscale")
                        command.RemoveAt(0);

                    else if (program == "-b" || program == "--brightness")
                    {
                        command.RemoveAt(0);
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                    }

                    else if (program == "-c" || program == "--contrast")
                    {
                        command.RemoveAt(0);
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                    }

                    else if (program == "-b" || program == "--brightness")
                    {
                        command.RemoveAt(0);
                        program = command[0];
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                    }

                    else if (program == "-a" || program == "--gradient-map")
                    {
                        command.RemoveAt(0);
                        ColorExtension.FromHexa(command[0]);
                        program = command[0];
                        command.RemoveAt(0);
                        program = command[0];
                        ColorExtension.FromHexa(command[0]);
                        command.RemoveAt(0);
                    }

                    else if (program == "-m" || program == "--cover")
                    {
                        command.RemoveAt(0);
                        command.RemoveAt(0);
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                    }

                    else if (program == "-l" || program == "--rotate-left")
                        command.RemoveAt(0);

                    else if (program == "-r" || program == "--rotate-right")
                        command.RemoveAt(0);

                    else if (program == "-x" || program == "--symmetry-x")
                        command.RemoveAt(0);

                    else if (program == "-y" || program == "--symmetry-y")
                        command.RemoveAt(0);

                    else if (program == "--resize")
                    {
                        command.RemoveAt(0);
                        program = command[0];
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                        program = command[0];
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                    }

                    else if (program == "--shift")
                    {
                        command.RemoveAt(0);
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                        int.Parse(command[0]);
                        command.RemoveAt(0);
                    }

                    else if (program == "--gauss")
                        command.RemoveAt(0);

                    else if (program == "--sharpen")
                        command.RemoveAt(0);

                    else if (program == "--blur")
                        command.RemoveAt(0);

                    else if (program == "--emboss")
                        command.RemoveAt(0);

                    else if (program == "--edge-enhance")
                        command.RemoveAt(0);

                    else if (program == "--edge-detect")
                        command.RemoveAt(0);

                    else if (program == "--encrypt-string")
                    {
                        command.RemoveAt(0);
                        program = command[0];
                        command.RemoveAt(0);
                    }

                    else if (program == "--encrypt-image")
                    {
                        command.RemoveAt(0);
                        program = command[0];
                        command.RemoveAt(0);
                    }

                    else if (program == "--decrypt-string")
                        command.RemoveAt(0);

                    else if (program == "--decrypt-image")
                        command.RemoveAt(0);

                    else if (program == "-h" || program == "--help")
                    {
                        command.RemoveAt(0);
                        Help();
                    }

                    else
                    {
                        throw new Exception();
                    }
                }
                
                if (command.Count < 1)
                {
                    program = command[0];
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.Error.Write(@"Invalid argument: {0}
Usage: ./aliceInJpegLand inputFile [options ...] outputFile
Use -h or --help option to list all available options" + "\n", program);
                return false;
            }

            
                
            return true;
        }

        /// <summary>
        /// Applies verified arguments on image
        /// </summary>
        /// <param name="image">Image to modify</param>
        /// <param name="args">CLI arguments array</param>
        public static void ApplyArgs(ref Bitmap image, string[] args)
        {
            List<string> command = GetArgs(args);
            while (command.Count > 1)
            {
                string programme = command[0];
                if (programme == "-i" || programme == "--invert")
                {
                    command.RemoveAt(0);
                    Basics.Invert(image);
                }

                else if (programme == "-g" || programme == "--grayscale")
                {
                    command.RemoveAt(0);
                    Basics.Grayscale(image);
                }

                else if (programme == "-b" || programme == "--brightness")
                {
                    command.RemoveAt(0);
                    Basics.Brightness(image, int.Parse(command[0]));
                    command.RemoveAt(0);
                }

                else if (programme == "-c" || programme == "--contrast")
                {
                    command.RemoveAt(0);
                    Basics.Contrast(image, int.Parse(command[0]));
                    command.RemoveAt(0);
                }

                else if (programme == "-a" || programme == "--gradient-map")
                {
                    command.RemoveAt(0);
                    var a = ColorExtension.FromHexa(command[0]);
                    command.RemoveAt(0);
                    var b = ColorExtension.FromHexa(command[0]);
                    command.RemoveAt(0);
                    Basics.GradientMap(image, a, b);
                }

                else if (programme == "-m" || programme == "--cover")
                {
                    command.RemoveAt(0);
                    var path = command[0];
                    command.RemoveAt(0);
                    int opacity = int.Parse(command[0]);
                    command.RemoveAt(0);
                    Basics.Cover(image, path, opacity);
                }

                else if (programme == "-l" || programme == "--rotate-left")
                {
                    command.RemoveAt(0);
                    image = Geometry.RotateLeft(image);
                }


                else if (programme == "-r" || programme == "--rotate-right")
                {
                    command.RemoveAt(0);
                    image = Geometry.RotateRight(image);
                }

                else if (programme == "-x" || programme == "--symmetry-x")
                {
                    command.RemoveAt(0);
                    Geometry.SymmetryX(image);
                }

                else if (programme == "-y" || programme == "--symmetry-y")
                {
                    command.RemoveAt(0);
                    Geometry.SymmetryY(image);
                }

                else if (programme == "--resize")
                {
                    command.RemoveAt(0);
                    int x = int.Parse(command[0]);
                    command.RemoveAt(0);
                    int y = int.Parse(command[0]);
                    command.RemoveAt(0);
                    image = Geometry.Resize(image, x, y);
                }

                else if (programme == "--shift")
                {
                    command.RemoveAt(0);
                    int x = int.Parse(command[0]);
                    command.RemoveAt(0);
                    int y = int.Parse(command[0]);
                    command.RemoveAt(0);
                    image = Geometry.Shift(image, x, y);
                }

                else if (programme == "--gauss")
                {
                    command.RemoveAt(0);
                    image = Convolution.Gauss(image);
                }

                else if (programme == "--sharpen")
                {
                    command.RemoveAt(0);
                    image = Convolution.Sharpen(image);
                }

                else if (programme == "--blur")
                {
                    command.RemoveAt(0);
                    image = Convolution.Blur(image);
                }

                else if (programme == "--emboss")
                {
                    command.RemoveAt(0);
                    image = Convolution.Emboss(image);
                }

                else if (programme == "--edge-enhance")
                {
                    command.RemoveAt(0);
                    image = Convolution.EdgeEnhance(image);
                }

                else if (programme == "--edge-detect")
                {
                    command.RemoveAt(0);
                    image = Convolution.EdgeDetect(image);
                }

                else if (programme == "--encrypt-string")
                {
                    command.RemoveAt(0);
                    var str = command[0];
                    command.RemoveAt(0);
                    Steganography.EncryptString(image, str);
                }

                else if (programme == "--encrypt-image")
                {
                    command.RemoveAt(0);
                    var path = command[0];
                    command.RemoveAt(0);
                    Steganography.EncryptImage(image, path);
                }

                else if (programme == "--decrypt-string")
                {
                    command.RemoveAt(0);
                    Steganography.DecryptString(image);
                }

                else if (programme == "--decrypt-image")
                {
                    command.RemoveAt(0);
                    Steganography.DecryptImage(image);
                }
                else if (programme == "-h" || programme == "--help")
                {
                    command.RemoveAt(0);
                    Help();
                }
            }
        }
    }
}