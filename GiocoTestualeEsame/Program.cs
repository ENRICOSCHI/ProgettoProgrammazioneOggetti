using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
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
            player.AddZaino(ElencoOggetti.scarpa);
            player.RemoveZaino(ElencoOggetti.scarpa);
            Casa casa = new Casa("Bella e accogliente");
            casa.MostraOggettiNellaStanza();
        }
        
    }
}
