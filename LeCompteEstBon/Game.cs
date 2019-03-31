using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LeCompteEstBon
{
    class Game
    {
        protected List<int> nbStart;

        //Constructor
        public Game()
        {
            this.Credit();
            this.Menu();
        }

        //Initialization method
        public void Start()
        {
            int ok = 0;
            Result result = new Result();
            result.generate();
            this.nbStart = result.getNb();

            Console.WriteLine("Vous devez trouver le nombre : " + result.getTotal());
            Console.WriteLine("En utilisant les nombres suivants : " + result.showNb());

            while(ok == 0)
            {
                while (result.getNb().Count > 1)
                {
                    this.ChooseCalcul(result);
                    if (this.isVictory(result))
                    {
                        Console.WriteLine("Victoire, le compte est bon !");
                        if (this.Replay())
                        {
                            this.Start();
                        }
                        else
                            Environment.Exit(0);
                    }
                    else
                        Console.WriteLine("Vous disposez des nombres suivants : " + result.showNb());
                }

                Console.WriteLine("Le compte n'est pas bon...");
                Console.WriteLine("Souhaitez vous réinitialiser les calculs ? o/n");
                String answer = Console.ReadLine().ToUpper();

                switch (answer)
                {
                    case "O":
                        result.setNb(result.getNbStart());
                        Console.WriteLine("Les calculs on été réinitialisés");
                        Console.WriteLine("-----");
                        Console.WriteLine("Vous devez trouver le nombre : " + result.getTotal());
                        Console.WriteLine("En utilisant les nombres suivants : " + result.showNb());
                        break;
                    case "N":
                        ok = 1;
                        break;

                    default:
                        break;
                }
            }

            if (this.Replay())
                this.Start();
            else
                Environment.Exit(0);
        }   

        //
        public void Reset(Result result)
        {
            result.reset();
        }

        //Menu display method
        public void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1 : Lancer la partie");
            Console.WriteLine("2 : Voir les règles du jeu");
            String answer = Console.ReadLine();
            int intAnswer = -1;

            if(int.TryParse(answer, out intAnswer))
            {
                if (intAnswer == 1)
                    this.Start();
                else if (intAnswer == 2)
                {
                    this.Rules();
                    this.Menu();
                } else
                {
                    Console.WriteLine("Veuillez saisir une réponse valide");
                    this.Menu();
                } 
            } else
            {
                Console.WriteLine("Veuillez saisir une réponse valide");
                this.Menu();
            }
        }

        //Replay method
        public Boolean Replay()
        {
            String answer;      //User answer
            Boolean? rtn = null;        //Nullable boolean
            Boolean rtn2 = false;        //Nullable boolean

            //While the user does not send a valid answer
            do
            {
                Console.WriteLine("Souhaitez vous rejouer ? o/n");
                answer = Console.ReadLine().ToUpper();      //Set the asnwer to uppercase (o => O and n => N)

                switch (answer)
                {
                    case "O":
                        rtn = true;
                        rtn2 = true;
                        break;
                    case "N":
                        rtn = false;
                        rtn2 = false;
                        break;

                    default:
                        break;
                }
            } while (rtn == null);
            
            return rtn2;
        }

        //Ask for a calcul
        public void ChooseCalcul(Result r)
        {
            Boolean valid = false;
            do
            {
                Console.WriteLine("Votre calcule : ");
                String answer = Console.ReadLine();
                answer = answer.Replace(" ", "");       //Delete the spaces

                if(answer == "r")
                {
                    Console.WriteLine("Les calculs on été réinitialisés");
                    Console.WriteLine("-----");
                    r.setNb(r.getNbStart());
                    return;
                }
                else
                {
                    String pattern = @"(\d+)([-+*/])(\d+)";
                    String[] matches = Regex.Split(answer, pattern);
                    if (matches.Length > 1)
                    {
                        int value1, value2;
                        if (int.TryParse(matches[1], out value1) && int.TryParse(matches[3], out value2))
                        {
                            if (value1 % 1 == 0 && value2 % 1 == 0)
                            {
                                if (this.isCalculValid(value1, value2, matches[2], r))
                                {
                                    this.NewCalcul(value1, value2, matches[2], r);
                                    valid = true;
                                }
                            }
                            else
                                Console.WriteLine("Erreur de saisie, veuillez entrer un calcul sous la forme '1 + 1'");
                        }
                        else
                            Console.WriteLine("Erreur de saisie, veuillez entrer un calcul sous la forme '1 + 1'");
                    }
                    else
                        Console.WriteLine("Erreur de saisie, veuillez entrer un calcul sous la forme '1 + 1'");
                }
            } while (!valid);
        }

        //Calcul method
        public void NewCalcul(int a, int b, string c, Result r)
        {
            switch (c)
            {
                case "+":
                    Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
                    r.addNb(a + b);
                    break;
                case "-":
                    Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
                    r.addNb(a - b);
                    break;
                case "*":
                    Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
                    r.addNb(a * b);
                    break;
                case "/":
                    Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
                    r.addNb(a / b);
                    break;

                default:
                    Console.WriteLine("Veuillez saisir un opérateur correct (+ - * /)");
                    break;
            }
            
            r.RemoveNb(a);
            r.RemoveNb(b);
        }

        //Check if the numbers used in the calcul are legit
        public Boolean isCalculValid(int a, int b, string c, Result r)
        {
            int x = -1, y = -1;
            x = r.getNb().IndexOf(a);
            y = r.getNb().IndexOf(b);

            if (x>=0 && y >= 0)     //If the numbers used are in the list available
            {
                if (c == "-")       //If the operation if a -
                {
                    if(a > b)       //If the result of a - b is not a negativ number
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Vous ne pouvez pas effectuer un calcul qui a pour résultat un nombre négatif");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("Veuillez utiliser uniquement les nombres disponibles");
                return false;
            }
                
        }

        //Check if the user found the right number
        public Boolean isVictory(Result r)
        {
            for(int i=0; i<r.getNb().Count; i++)
            {
                if (r.getNb()[i] == r.getTotal())
                {
                    return true;
                }
            }

            return false;
        }

        //Display credit
        public void Credit()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Le Compte est Bon - Par Alban PAPASSIAN");
            Console.WriteLine("-----");
        }

        //Display rules
        public void Rules()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Le Compte est Bon - Règles du jeu");
            Console.WriteLine("Vous disposez de 5 nombres et vous devez obtenir le nombre cible, en combinant ces 5 nombres avec les 4 opérations élémentaires (+, -, *, /) : addition, soustraction, multiplication et division.");
            Console.WriteLine("Chaque nombre ne peut être utilisé qu'une seule fois, vous ne pouvez combiner que des nombres positifs et entiers.");
            Console.WriteLine("Bonne chance !");
            Console.WriteLine("-----");
        }
    }
}
