using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Personaggio : Persona
    {
        private string nome;
        private string descrizione;

        public Personaggio(string nome, string descrizione) : base(nome)
        {
            this.descrizione = descrizione;
        }
    }
}
