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
        public Oggetto richiesta { get; set; } 
        public Oggetto regalo { get; set; }

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
            if (richiesta != null)
            {
                Console.Write($"{descrizione},{nome} vorrebbe ");
                Console.ForegroundColor = ConsoleColor.DarkRed;//cambio il colore solo per la variabile
                Console.Write(richiesta.nome + ".\n");
            }
            if(richiesta == null)//se non vuole niente stampa solo la descrizione
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(descrizione + "\n");
            }
            if (regalo != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"In cambio riceverai ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;//cambio il colore solo per la variabile
                Console.Write(regalo.nome + ".\n");
            }
        }
        /// <summary>
        /// Il personaggio può dare un oggetto dopo aver ricevuto la richiesta.
        /// <br>=== Il codice controlla se l'oggetto è presente nello zaino. ===</br>
        /// </summary>
        public bool AddZainoRegalo()
        {
            if(richiesta != null)//se c'è una richiesta...
            {
                if (GestisciStatoGioco.giocatoreCorrente.IsOggettoNelloZaino(richiesta))
                {
                    GestisciStatoGioco.giocatoreCorrente.RimuoviSenzaLasciareNellaStanza(richiesta);//rimuovo definitivamente l'oggetto dal gioco
                    if(regalo != null)
                        GestisciStatoGioco.giocatoreCorrente.AddZaino(regalo);//aggiungo l'oggetto dato dal personaggio nello zaino
                    return true;
                }
                else
                {
                    Warning.WarningOggettoNonPresenteNelloZaino(richiesta);
                    return false;
                }
            }
            else
            {
                if (regalo != null)
                    GestisciStatoGioco.giocatoreCorrente.AddZaino(regalo);//se non c'è richiesta do direttamente il regalo...
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("non ha regali da darti\n");
                }
                return true;
                
            }
        }
    }
}
