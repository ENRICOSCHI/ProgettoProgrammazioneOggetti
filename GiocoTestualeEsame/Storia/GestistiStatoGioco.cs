using GiocoTestualeEsame.stanze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Storia
{
    public class GestistiStatoGioco
    {
        //gestisci la stanza corrente
        public Stanza stanzaCorrente { get; set; } = ElencoStanze.pianoTerra;
    }
}
