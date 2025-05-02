using GiocoTestualeEsame.stanze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Oggetto_cartella
{
    public class Passaggio : Oggetto
    {
        public Stanza destinazione { get; set; }
        public Passaggio(string nome,string descrizione, Stanza destinazione) : base(nome, 0, descrizione, false,false)
        {
            this.destinazione = destinazione;
        }
    }
}
