using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Storia
{
    public class PreparazioneStoria
    {
        //da chiamare all'inizio per preparare la storia
        /*Attenzione gli oggetti devono avere nomi differenti se stanno in stanze diverse*/
        public static void CostruisciStoria()
        {
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scarpa);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.spada);
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.scarpa);
        }
        
    }
}
