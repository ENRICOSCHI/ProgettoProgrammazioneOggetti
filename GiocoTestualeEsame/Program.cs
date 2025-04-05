using GiocoTestualeEsame.Oggetto_cartella;
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
            Console.WriteLine(ElencoOggetti.scarpa.nome); //esempio
            Giocatore player = new Giocatore("Enrico", "Fiore");
            player.AddZaino(ElencoOggetti.scarpa);
        }
        
    }
}
