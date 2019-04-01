using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBon
{
    class Result
    {
        protected int total = 0;
        protected List<int> nbStart = new List<int>();
        protected List<int> nb = new List<int>();
        protected int listSize = 6;

        //Constructor
        public Result()
        {
            
        }

        //Method for generate a random target number
        public void generate()
        {
            Bag bag = new Bag();
            Random rand = new Random();

            while (this.total <= 100 || this.total >= 999)
            {
                this.total = 0;
                this.nb = new List<int>();
                this.nbStart = new List<int>();

                for (int i = 0; i < this.listSize; i++)
                {
                    int x = bag.Pick();
                    this.nb.Add(x);
                    this.nbStart.Add(x);

                    if (i > 0)
                    {
                        int ope = rand.Next(0, 3);

                        switch (ope)
                        {
                            case 0:
                                this.total += this.nb[i - 1] + this.nb[i];
                                break;
                            case 1:
                                this.total += this.nb[i - 1] - this.nb[i];
                                break;
                            case 2:
                                this.total += this.nb[i - 1] * this.nb[i];
                                break;
                            case 3:
                                if (this.nb[i - 1] % this.nb[i] == 0)
                                    this.total += this.nb[i - 1] / this.nb[i];
                                else
                                    this.total += this.nb[i - 1] * this.nb[i];
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        //Total getter
        public int getTotal()
        {
            return this.total;
        }

        //NbStart getter
        public List<int> getNbStart()
        {
            return this.nbStart;
        }

        //Nb getter
        public List<int> getNb()
        {
            return this.nb;
        }

        //Nb setter
        public void setNb(List<int> l)
        {
            this.nb = new List<int>();

            foreach (int n in l)
            {
                this.nb.Add(n);
            }
        }

        //Add a number in the list
        public void addNb(int a)
        {
            this.nb.Add(a);
        }

        //Remove a number from the list
        public void RemoveNb(int a)
        {
            this.nb.Remove(a);
        }

        //Display the nb List
        public string showNb()
        {
            String nb = "";
            for (int i = 0; i < this.nb.Count; i++)
            {
                if(i == this.nb.Count - 1)
                    nb += this.nb[i];
                else
                    nb += this.nb[i] + " | ";
            }

            return nb;
        }

        //Display the nbStart List
        public string showNbStart()
        {
            String nbStart = "";
            for (int i = 0; i < this.nbStart.Count; i++)
            {
                if (i == this.nbStart.Count - 1)
                    nbStart += this.nbStart[i];
                else
                    nbStart += this.nbStart[i] + " | ";
            }

            return nbStart;
        }

        //
        public void reset()
        {
            Console.WriteLine(this.showNb());
            Console.WriteLine(this.showNbStart());
            this.nb = this.nbStart;
        }
    }
}
