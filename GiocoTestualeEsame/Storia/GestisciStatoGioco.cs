using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Storia
{
    public class GestisciStatoGioco
    {

        //gestisci la stanza corrente
        public static Stanza stanzaCorrente { get; set; } = ElencoStanze.pianoTerra;
        public static Oggetto oggettoInMano { get; set; } = ElencoOggetti.manoVuota; //non ha niente all'inizio in mano
        public static Giocatore giocatoreCorrente { get; set; } //il giocatore lo creo da StoriaPrincipale
        public void CreateGiocatore(string nome,string cognome)
        {
            giocatoreCorrente = new Giocatore(nome, cognome);//creo giocatore
        }
        /// <summary>
        /// Aggiorno la storia dopo che è stato dato l'oggetto richiesto dal cattivo
        /// </summary>
        /// <param name="c"></param>
        public static void ControllaMorteCattivo(Personaggio c)
        {
            if(c.nome == ElencoOggetti.TopoDragoElettrico.nome && stanzaCorrente.nome == ElencoStanze.quadroElettrico.nome)//se si trova nella stanza giusta e ha dato l'oggetto richiesta al cattivo...
            {
                ElencoOggetti.Elettricista.descrizione = "Ora che il mostro se ne andato, può riparare il quadro elettrico";//cambio descrizione all'elettricista
                ElencoOggetti.Elettricista.richiesta = ElencoOggetti.cacciavite;//aggiorno la richiesta
                ElencoOggetti.Elettricista.regalo = ElencoOggetti.ticket;//aggiorno regalo
                stanzaCorrente.RimuoviOggettoDallaStanza(c);//rimuovo il cattivo
            }
        }
        /// <summary>
        /// Controllo se il giocatore ha fatto la quest finale
        /// </summary>
        /// <param name="c"></param>
        public static void ControlloFinePartira(Personaggio c)
        {
            if(c.nome == ElencoOggetti.Elettricista.nome)//se sta parlando con l'elettricista e ha il ticket nello zaino o nella stanza
            {
                if (giocatoreCorrente.IsOggettoNelloZaino(ElencoOggetti.ticket) || stanzaCorrente.ControlloOggettoNellaStanza(ElencoOggetti.ticket))
                {
                    Console.WriteLine("==========================HAI FINITO IL GIOCO==========================\nLa corrente è finalmente tornata e la sala giochi è di nuovo accessibile!\n=============================================================================");
                    Console.ForegroundColor= ConsoleColor.White;
                    Environment.Exit(0);
                }
            }
        }
    }
}
