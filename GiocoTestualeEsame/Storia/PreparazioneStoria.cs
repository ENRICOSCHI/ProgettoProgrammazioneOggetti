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
            /*PIANO TERRA*/
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scarpa);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.spada);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.porta_destra);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.porta_sinistra);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scale_su);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scale_giu);
            /*CANTINA*/
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.torna_piano_terra);
        }
        
    }
}
