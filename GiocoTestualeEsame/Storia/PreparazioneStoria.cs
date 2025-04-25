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
            ElencoStanze.quadroElettrico.AddOggettoNellaStanza(ElencoOggetti.TopoDragoElettrico);
            /*SALA GIOCHI*/
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.porta_piano_terra);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.carteDaGioco);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.cacciavite);
            /*PRIMO PIANO*/
            ElencoStanze.primoPiano.AddOggettoNellaStanza(ElencoOggetti.scale_piano_terra);
            ElencoStanze.primoPiano.AddOggettoNellaStanza(ElencoOggetti.Mago);
            /*CAMERA*/
            ElencoStanze.camera.AddOggettoNellaStanza(ElencoOggetti.porta_piano_terra);
            ElencoStanze.camera.AddOggettoNellaStanza(ElencoOggetti.spada);
            ElencoStanze.camera.AddOggettoNellaStanza(ElencoOggetti.botolaGiu);
            ElencoStanze.camera.AddOggettoNellaStanza(ElencoOggetti.scarpa);
            /*PRIGIONE*///--> accessibile solo tramite tp
            ElencoStanze.prigione.AddOggettoNellaStanza(ElencoOggetti.Sicario);
            ElencoStanze.prigione.AddOggettoNellaStanza(ElencoOggetti.Poliziotto);
            ElencoStanze.prigione.AddOggettoNellaStanza(ElencoOggetti.Pirata);
            //BOSCO
            ElencoStanze.bosco.AddOggettoNellaStanza(ElencoOggetti.botolaSu);
            ElencoStanze.bosco.AddOggettoNellaStanza(ElencoOggetti.ElfoMaestro);
            ElencoStanze.bosco.AddOggettoNellaStanza(ElencoOggetti.ElfoAiutante);
        }
        
    }
}
