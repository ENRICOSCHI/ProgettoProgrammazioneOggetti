using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Oggetto
    {
        public string nome { get; }
        public double peso { get; } //ogni oggetto ha un peso
        public string descrizione { get; set; }
        public bool isRaccoglibile { get; } //non tutti gli oggetti sono raccoglibile
        public bool isInteragibile { get; set; } //riferito più ai personaggi

        public Oggetto(string nome,double peso,string descrizione,bool isRaccoglibile,bool isInteragibile)
        {
            this.nome = nome;
            this.peso = peso;
            this.descrizione = descrizione;
            this.isRaccoglibile = isRaccoglibile;
            this.isInteragibile = isInteragibile;
        }
    }
}
