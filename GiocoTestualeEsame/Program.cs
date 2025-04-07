using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.Storia;
using GiocoTestualeEsame.warning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*prove generali SI POTRANNO RIMUOVERE*/
            Console.WriteLine(ElencoOggetti.scarpa.nome); //esempio
            Giocatore player = new Giocatore("Enrico", "Fiore");
            //Casa casa = new Casa("Bella e accogliente");
            player.AddZaino(ElencoOggetti.scarpa);
            Console.WriteLine("Ho rimosso " + ElencoOggetti.scarpa.nome + " dalla stanza e lo messo nello zaino");
            player.RemoveZaino(ElencoOggetti.scarpa);
            Console.WriteLine("scegli uno tra questi tre oggetti");
            string input = Console.ReadLine();
            Oggetto oggettoScelto = null;
            oggettoScelto = ControlloInput(input, oggettoScelto);//controllo oggetto scelto
            Console.WriteLine($"{oggettoScelto.nome} è stato scelto");
            PreparazioneStoria.CostruisciStoria();
            GestistiStatoGioco statoGioco = new GestistiStatoGioco();
            statoGioco.stanzaCorrente = ElencoStanze.cantina;
               
        }

        public static Oggetto ControlloInput(string input, Oggetto oggettoScelto)
        {
            while (!ElencoOggetti.Tutti.TryGetValue(input, out oggettoScelto))
            {
                Warning.WarningErroreDiBattitura();
                input = Console.ReadLine();
            }
            return oggettoScelto;
        }
        
    }
}
