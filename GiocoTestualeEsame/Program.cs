using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
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
            Stanza[] stanze = new Stanza[2];
            stanze[0] = new Casa("bella sta casa");
            Casa casa = (Casa)stanze[0];
            //Casa casa = new Casa("Bella e accogliente");
            player.AddZaino(ElencoOggetti.scarpa);
            casa.MostraOggettiNellaStanza();
            Console.WriteLine("Ho rimosso " + ElencoOggetti.scarpa.nome + " dalla stanza e lo messo nello zaino");
            casa.RimuoviOggettoDallaStanza(ElencoOggetti.scarpa);
            player.RemoveZaino(ElencoOggetti.scarpa);
            casa.MostraOggettiNellaStanza();
            Console.WriteLine("scegli uno tra questi tre oggetti");
            string input = Console.ReadLine();
            Oggetto oggettoScelto = null;
            oggettoScelto = ControlloInput(input, oggettoScelto);//controllo oggetto scelto
            Console.WriteLine($"{oggettoScelto.nome} è stato scelto");
               
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
