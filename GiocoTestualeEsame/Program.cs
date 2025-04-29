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
        /*static void Main(string[] args)
        {
            /*prove generali SI POTRANNO RIMUOVERE
            StoriaPrincipale storia = new StoriaPrincipale();
            //storia.Prompt();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ElencoOggetti.scarpa.nome); //esempio
            Giocatore player = new Giocatore("Enrico", "Fiore");
            //Casa casa = new Casa("Bella e accogliente");
            player.AddZaino(ElencoOggetti.scarpa);
            Console.WriteLine("Ho rimosso " + ElencoOggetti.scarpa.nome + " dalla stanza e lo messo nello zaino");
            player.RemoveZaino(ElencoOggetti.scarpa);
            Console.WriteLine("Ho rimesso " + ElencoOggetti.scarpa.nome + " dalla zaino e lo messa nella stanza");
            /*Console.WriteLine("scegli uno tra questi tre oggetti");
            string input = Console.ReadLine();
            Oggetto oggettoScelto = null;
            oggettoScelto = ControlloInput(input, oggettoScelto);//controllo oggetto scelto
            Console.WriteLine($"{oggettoScelto.nome} è stato scelto");
            GestisciStatoGioco.stanzaCorrente.MostraOggettiNellaStanza();
            PreparazioneStoria.CostruisciStoria();
            Console.WriteLine("costruisco storia");
            GestisciStatoGioco.stanzaCorrente.MostraOggettiNellaStanza();
            //GestistiStatoGioco statoGioco = new GestistiStatoGioco();
            //statoGioco.stanzaCorrente = ElencoStanze.cantina;
            GestisciStatoGioco.stanzaCorrente = ElencoStanze.cantina;
            storia.Prompt();
               
        }

        public static Oggetto ControlloInput(string input, Oggetto oggettoScelto)
        {
            while (!ElencoOggetti.TuttiGliOggetti.TryGetValue(input, out oggettoScelto))
            {
                Warning.WarningErroreDiBattitura();
                input = Console.ReadLine();
            }
            return oggettoScelto;
        }*/
        
    }
}
