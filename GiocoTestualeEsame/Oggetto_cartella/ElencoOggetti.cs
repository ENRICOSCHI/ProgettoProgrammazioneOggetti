using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Oggetto_cartella
{
    /*CLASSE CON TUTTI GLI OGGETTI CREATI*/
    public class ElencoOggetti
    {
        public static Oggetto spada { get; } = new Oggetto("spada", 9.50, "spada trovata in un fosso", true);
        public static Oggetto scarpa { get; } = new Oggetto("scarpa",1.5, "scarpe rotte da usare come abbellimento", true);

        //dizionario
        public static readonly Dictionary<string, Oggetto> Tutti = new Dictionary<string, Oggetto>(System.StringComparer.OrdinalIgnoreCase)//per non renderelo case sensitive
        {
            { "spada", spada },
            { "scarpa", scarpa }
        };
    }
}
