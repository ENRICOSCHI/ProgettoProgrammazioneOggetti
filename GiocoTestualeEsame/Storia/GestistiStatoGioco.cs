using GiocoTestualeEsame.Oggetto_cartella;
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
        public static Stanza stanzaCorrente { get; set; } = ElencoStanze.pianoTerra;
        public static Oggetto oggettoInMano { get; set; } = ElencoOggetti.manoVuota; //non ha niente all'inizio in mano
    }
}
