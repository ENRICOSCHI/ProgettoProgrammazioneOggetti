using GiocoTestualeEsame.comandiDiGioco;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.warning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Storia
{
    internal class StoriaPrincipale
    {
        static void Main(string[] args)
        {
            CreazioneGiocatore_StartStoria();
            while (true)
            {
                Prompt();
            }

        }
        /// <summary>
        /// Gestisco prompt del giocatore
        /// </summary>
        public static void Prompt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;//cambio colore scritta del prompt 
            Console.Write($"[{GestisciStatoGioco.stanzaCorrente.nome}] {GestisciStatoGioco.oggettoInMano.nome} > "); //scrivo nella riga dove il giocatore scrive l'input con Write
            string input = Console.ReadLine();
            string[] substring =  input.Split();
            string command = substring[0];//comando utilizzato
            string argomento = "";
            if(substring.Length>1)//evito così che vada in eccezione in caso non venga inserito l'argomento
                argomento = substring[1];//argomento del comando (una parola)
             Comandi.ControlloComandi(command, argomento);// controllo il comando inserito
            //Console.WriteLine($"Hai scritto: {command} {argomento}"); test comando
        }
        /// <summary>
        /// Creo il giocatore e faccio partire la storia
        /// </summary>
        public static void CreazioneGiocatore_StartStoria()
        {
            GestisciStatoGioco GS = new GestisciStatoGioco();
            /*Chiedo le credenziali del giocatore*/
            Console.WriteLine("Inserisci nome e cognome\n");
            Console.Write("Nome: "); string nomeUtente = Console.ReadLine();
            Console.Write("Cognome: "); string cognomeUtente = Console.ReadLine();
            GS.CreateGiocatore(nomeUtente, cognomeUtente);//creo il giocatore
            Warning.WriteInfoGiocatoreOnLogFile(nomeUtente, cognomeUtente);
            StoriaPrincipale storia = new StoriaPrincipale();
            PreparazioneStoria.CostruisciStoria();
            Comandi.ControlloPresenzaDati();//Controllo se il giocatore ha file di salvataggio esistenti
            /*descrizione piano iniziale*/
            Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta del prompt 
            Console.WriteLine(GestisciStatoGioco.stanzaCorrente.descrizione);
        }
    }
}
