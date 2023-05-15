using System.Drawing;

namespace AliceInJpegLand
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (!ParameterManager.VerifyArgsValidity(args))
                return;
            Bitmap b = new Bitmap(args[0]);
            ParameterManager.ApplyArgs(ref b, args);
            b.Save(args[^1]); // Gets the last argument as filename
        }
    }
}
