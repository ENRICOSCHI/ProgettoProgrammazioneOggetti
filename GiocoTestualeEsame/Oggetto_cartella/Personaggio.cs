using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Personaggio : Oggetto
    {
        public Oggetto richiesta { get; set; } 
        public Personaggio(string nome, string descrizione, Oggetto richiesta) : base(nome, 0, descrizione, false)
        {
            this.richiesta = richiesta;
        }

        public void CambiaRichiesta(Oggetto nuovaRichiesta)
        {
            richiesta = nuovaRichiesta;
        }
    }
}
