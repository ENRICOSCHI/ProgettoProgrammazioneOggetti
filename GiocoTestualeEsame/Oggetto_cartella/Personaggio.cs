using GiocoTestualeEsame.Storia;
using GiocoTestualeEsame.warning;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Personaggio : Oggetto
    {
        Giocatore giocatore; 
        public Oggetto richiesta { get;} 
        public Oggetto regalo { get; }
        public Personaggio(string nome, string descrizione, Oggetto richiesta, Oggetto regalo) : base(nome, 0, descrizione, false)
        {
            this.richiesta = richiesta;
            this.regalo = regalo;
        }

        /// <summary>
        /// Stampa la richiesta in formato string
        /// </summary>
        public void RichiestaToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{nome} vorrebbe ");
            Console.ForegroundColor = ConsoleColor.DarkRed;//cambio il colore solo per la variabile
            Console.Write(richiesta.nome+"\n");
        }
        /// <summary>
        /// Il personaggio può dare un oggetto dopo aver ricevuto la richiesta.
        /// <br>=== Il codice controlla se l'oggetto è presente nello zaino. ===</br>
        /// </summary>
        public void AddZainoRegalo()
        {
            giocatore = GestisciStatoGioco.giocatoreCorrente;//prendo il giocatore attuale
            if (giocatore.IsOggettoNelloZaino(richiesta))
            {
                giocatore.RimuoviSenzaLasciareNellaStanza(richiesta);//rimuovo definitivamente l'oggetto dal gioco
                giocatore.AddZaino(regalo);//aggiungo l'oggetto dato dal personaggio nello zaino
            }
            else
            {
                Warning.WarningOggettoNonPresenteNelloZaino(richiesta);
            }
            
        }
    }
}
