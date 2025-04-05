using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Personaggio : Persona
    {
        public string nome { get; } 
        public string descrizione { get; }
        public int vita { get; }

        public Personaggio(string nome, string descrizione, int vita) : base(nome)
        {
            this.descrizione = descrizione;
            this.vita = vita;
        }
    }
}
