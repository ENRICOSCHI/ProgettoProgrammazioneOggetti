using GiocoTestualeEsame.Oggetto_cartella;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GiocoTestualeEsame.Persona_cartella
{
    public class SalvataggiGiocatore
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public List<string> Zaino { get; set; }
        public string OggettoInMano { get; set; }
        public string stanzaAttuale { get; set; }
        public double pesoMassimoZaino { get; set; }
    }
}
