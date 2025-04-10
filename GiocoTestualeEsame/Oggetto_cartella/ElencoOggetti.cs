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
        public static Oggetto manoVuota { get; } = new Oggetto("", 0, "non hai niente in mano", false);
        public static Oggetto spada { get; } = new Oggetto("spada", 9.50, "spada trovata in un fosso", true);
        public static Oggetto scarpa { get; } = new Oggetto("scarpa",1.5, "scarpe rotte da usare come abbellimento", true);
        public static Oggetto porta_sinistra { get; } = new Oggetto("porta_sinistra", 0, "questa porta va in camera", false);
        public static Oggetto porta_destra { get; } = new Oggetto("porta_destra", 0, "questa porta va alla sala giochi", false);
        public static Oggetto scale_su { get; } = new Oggetto("scale_su", 0, "queste scale portano al primo piano", false);
        public static Oggetto scale_giu { get; } = new Oggetto("scale_giu", 0, "queste scale portano alla cantina", false);
        public static Oggetto torna_piano_terra { get; } = new Oggetto("torna_piano_terra", 0, "ritorna al piano terra", false);




        //dizionario
        public static readonly Dictionary<string, Oggetto> TuttiGliOggetti = new Dictionary<string, Oggetto>(System.StringComparer.OrdinalIgnoreCase)//per non renderelo case sensitive
        {
            { "spada", spada },
            { "scarpa", scarpa },
            {"scale_giu",scale_giu },
            {"scale_su", scale_su } ,
            {"porta_destra",porta_destra },
            { "porta_sinistra",porta_sinistra},
            {"torna_piano_terra", torna_piano_terra },
            { "vuoto", manoVuota } //oggetto di default
        };
    }
}
