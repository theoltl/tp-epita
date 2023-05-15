using System;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Generation gen = new Generation(2000);
            gen.Train(1000);
            Bot bot = gen.GetBestBots(1)[0];
            bot.Play(true);
            bot.Save(".save");
        }
    }
}
