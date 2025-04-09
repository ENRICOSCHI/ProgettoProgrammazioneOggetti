using GiocoTestualeEsame.comandiDiGioco;
using GiocoTestualeEsame.stanze;
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
            StoriaPrincipale storia = new StoriaPrincipale();
            PreparazioneStoria.CostruisciStoria();
            while (true)
            {
                storia.Prompt();
            }

        }
        /// <summary>
        /// Gestisco prompt del giocatore
        /// </summary>
        public void Prompt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;//cambio colore scritta del prompt 
            Console.Write($"[{GestistiStatoGioco.stanzaCorrente.nome}] {GestistiStatoGioco.oggettoInMano.nome} > "); //scrivo nella riga dove il giocatore scrive l'input con Write
            string input = Console.ReadLine();
            string[] substring =  input.Split();
            string command = substring[0];//comando utilizzato
            string argomento = "";
            if(substring.Length>1)//evito così che vada in eccezione in caso non venga inserito l'argomento
                argomento = substring[1];//argomento del comando (una parola)
             Comandi.ControlloComandi(command, argomento);// controllo il comando inserito
            //Console.WriteLine($"Hai scritto: {command} {argomento}"); test comando
        }
    }
}
