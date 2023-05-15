using System.Collections;

namespace WonderlandTycoon
{
    public class Map : IEnumerable
    {
        public Tile[,] matrix;

        public Map(string name)
        {
            matrix = TycoonIO.ParseMap(name);
        }

        public bool Build(int i, int j, ref long money,
                Building.BuildingType type)
        {
            return matrix[i, j].Build(ref money, type);
        }

        public bool Upgrade(int i, int j, ref long money)
        {
            Tile type = matrix[i, j];
            return type.Upgrade(ref money);
        }

        public long GetAttractiveness()
        {
            long count = 0;

            foreach (Tile tile in matrix)
            {
                count += tile.GetAttractiveness();
            }

            return count;
        }

        public long GetHousing()
        {
            long count = 0;

            foreach (Tile tile in matrix)
            {
                count += tile.GetHousing();
            }

            return count;
        }

        public long GetPopulation()
        {
            long housing = GetHousing();
            long attract = GetAttractiveness();

            if (attract < housing)
                return attract;
            
            return housing;
        }

        public long GetIncome(long population)
        {
            long count = 0;

            foreach (Tile tile in matrix)
            {
                count += tile.GetIncome(population);
            }

            return count;
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
