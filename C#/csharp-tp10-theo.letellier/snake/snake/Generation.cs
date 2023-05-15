using System;

namespace snake
{
    public class Generation
    {
        /**
         * The array containing all the bots of the population
         */
        private Bot[] generation;

        /**
         * Create a new random Generation of the size given in parameter,
         * all playing on a 8 * 8 Grid
         */
        public Generation(int size)
        {
            generation = new Bot[size];
            for (int i = 0; i < size; ++i)
                generation[i] = new Bot(8, 8);
        }

        /**
         * Sort bots by decreasing order of fitness
         * FIXME
         */
         
        

        public void Sort()
        {
            int j;
            long temp;
            for (int i = 1; i < generation.Length - 1; i++)
            {
                temp = generation[i].Score;
                j = i - 1;
                while (j >= 0 && generation[j].Score < temp)
                {
                    generation[j + 1] = generation[j];
                    j--;
                }
                generation[j + 1].Score = temp;
            }
        }

        
        /**
         * HINT: Return an array of the n best bots of the generation
         * FIXME
         */
        public Bot[] GetBestBots(int n)
        {
            Bot[] bot = new Bot[n];
            Sort();
            for (int count = 0; count < n; count++)
            {
                bot[count] = generation[count];
            }

            return bot;
        }

        /**
         * HINT: Bot selection for the next generation,
         * the fitness parameter represents the sum of the scores
         * of every bot of the generation
         * FIXME
         */
        public Bot SelectBot(long fitness_sum)
        {
            throw new NotImplementedException();
        }

        /**
         * HINT: Bot selection for the next generation, no parameter,
         * naive implementation
         * FIXME
         */
        public Bot SelectBot()
        {
            Random rnd = new Random();
            int i = rnd.Next(generation.Length);
            return generation[i];
        }

        /**
         * HINT: Copy, crossover and mutate the previous generation bots into
         * the gen array in parameter
         * FIXME
         */
        public void Duplicate(Bot[] gen)
        {
            throw new NotImplementedException();
        }

        /**
         * Create a new generation, if the parameter is true,
         * the best bot of the previous generation must play a new game and be
         * displayed on stdout
         * FIXME
         */
        public void NewGen(bool display_best = false)
        {
            if (display_best)
            {
                SelectBot();
                Bot test = SelectBot();
                test.Play(true);
            }

            Generation nouvelle;
            nouvelle = new Generation(generation.Length);
            generation = nouvelle.generation;
        }    

        /**
         * Each bot of the population play a game
         */
        public void Play(bool display = false)
        {
            for (int i = 0; i < generation.Length; ++i)
                generation[i].Play(display);
        }

        /**
         * Train a population for nbGen generations
         * FIXME
         */
        public void Train(int nbGen)
        {
            while (nbGen != 0)
            {
                foreach (var bot in generation)
                {
                    bot.Play();
                }
                NewGen(true);
                nbGen -= 1;
            }
            
        }

        /**
         * Create a generation with 'size' Bots all restores from the file
         * given in parameter
         */
        public Generation(int size, string path)
        {
            generation = new Bot[size];
            Bot saved = new Bot(path);
            for (int i = 0; i < size; i++)
                generation[i] = new Bot(saved, false);
        }
    }
}
