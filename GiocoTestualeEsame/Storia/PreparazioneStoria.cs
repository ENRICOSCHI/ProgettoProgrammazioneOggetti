using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.warning;
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
            Warning.InfoCustomizable("Storia creata");//metto un info nel log per mostrare che sono stati caricati i personaggi ecc.. nel gioco
            /*TESTO NARRATIVO INIZIALE*/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
            $"\nINTRODUZIONE\n{GestisciStatoGioco.giocatoreCorrente.nome} sei stato chiamato in un luogo avvolto nel mistero.\n" +
            "La sala giochi non ha più la corrente e i bambini non possono più giocarci.\n" +
            "Si è venuti a sapere di un mostro famelico che si aggira tra i cavi elettrici, divorandoli senza sosta.\n\n" +
            "Si dice che solo gli elfi conoscano il modo per scacciarlo...\n" +
            "Ma nessuno sa dove si nascondano.\n" +
            "L'elettricista deve riparare quei quadri elettrici, ma con il mostro nelle vicinanze lui non si muoverà.\n" +
            "========================================= PER SAPERE I COMANDI SCRIVERE -> help <- =========================================\n"
            );
            /*PIANO TERRA*/
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.porta_camera);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.porta_salagiochi);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scale_giu_cantina);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.scale_su_primo_piano);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.ragazzoChill);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.giulia);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.bambinoTriste);
            ElencoStanze.pianoTerra.AddOggettoNellaStanza(ElencoOggetti.Marco);
            /*CANTINA*/
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.scale_piano_terra);
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.libro);
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.discoLayla);
            ElencoStanze.cantina.AddOggettoNellaStanza(ElencoOggetti.porta_quadro_elettrico);
            /*QUADRO ELETTRICO*/
            ElencoStanze.quadroElettrico.AddOggettoNellaStanza(ElencoOggetti.Elettricista);
            ElencoStanze.quadroElettrico.AddOggettoNellaStanza(ElencoOggetti.porta_cantina);
            ElencoStanze.quadroElettrico.AddOggettoNellaStanza(ElencoOggetti.TopoDragoElettrico);
            /*SALA GIOCHI*/
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.porta_piano_terra);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.carteDaGioco);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.cacciavite);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.ArcadeSM);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.ArcadeSI);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.ArcadePM);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.ArcadeFootball);
            ElencoStanze.salaGiochi.AddOggettoNellaStanza(ElencoOggetti.ArcadeDK);
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
