using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.porta_camera);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.porta_salagiochi);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scale_giu_cantina);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scale_su_primo_piano);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.ragazzoChill);
            /*CANTINA*/
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.scale_piano_terra);
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.porta_quadro_elettrico);
            /*QUADRO ELETTRICO*/
            ElencoStanze.quadroElettrico.AddOggettoNellaStanza(ElencoOggetti.Elettricista);
            ElencoStanze.quadroElettrico.AddOggettoNellaStanza(ElencoOggetti.porta_cantina);
            /*SALA GIOCHI*/
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.teletrasporto);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.porta_piano_terra);
            /*PRIMO PIANO*/
            ElencoStanze.primoPiano.AddOggettoNellaStanza(ElencoOggetti.scale_piano_terra);
            /*CAMERA*/
            ElencoStanze.camera.AddOggettoNellaStanza(ElencoOggetti.porta_piano_terra);
            ElencoStanze.camera.AddOggettoNellaStanza(ElencoOggetti.spada);
        }
        
    }
}
