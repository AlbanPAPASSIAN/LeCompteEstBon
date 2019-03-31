using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBon
{
    class Bag
    {
        List<int> bagList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 25, 25, 50, 50, 75, 75, 100, 100 };
        private static Random random;
        private static object syncObj = new object();

        //Constructor
        public Bag()
        {

        }

        //Constructor with custom bag
        public Bag(List<int> customList)
        {
            this.bagList = customList;
        }

        //Method to pick a random number in the bag
        public int Pick()
        {
            Random rand = new Random();

            int rng = GenerateRandomNumber(this.bagList.Count);
            int nb = this.bagList[rng];

            this.bagList.RemoveAt(rng);

            return nb;
        }

        //Method te generate a random number
        private static int GenerateRandomNumber(int max)
        {
            lock (syncObj)
            {
                if (random == null)
                    random = new Random();
                return random.Next(max);
            }
        }
    }
}
