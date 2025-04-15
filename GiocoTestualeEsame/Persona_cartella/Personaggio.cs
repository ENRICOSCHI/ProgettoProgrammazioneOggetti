using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Personaggio : Persona
    {
        public string descrizione { get; }

        public Personaggio(string nome, string descrizione) : base(nome)
        {
            this.descrizione = descrizione;
        }
    }
}
