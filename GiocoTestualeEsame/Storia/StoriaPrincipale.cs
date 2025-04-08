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

        private void STORIA()
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
            string[] substring =  input.Split(' ');
            string command = substring[0];//comando utilizzato
            string argomento = substring[1];//argomento del comando (una parola)
            //Console.WriteLine($"Hai scritto: {command} {argomento}"); test comando
        }
    }
}
