using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBon
{
    class Player
    {
        protected String pseudo;

        //Constructor
        public Player(String pseudo)
        {
            this.pseudo = pseudo;
        }

        //Pseudo getter
        public String getPseudo()
        {
            return this.pseudo;
        }

        //Pseudo setter
        public void setPseudo(String pseudo)
        {
            this.pseudo = pseudo;
        }
    }
}
