using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.stanze
{
    public class ElencoStanze
    {
        public static Stanza pianoTerra { get; } = new Stanza("piano terra","descrizione Piano Terra");
        public static Stanza cantina { get; } = new Stanza("cantina","descrizione cantina");

        public static readonly Dictionary<string, Stanza> TutteLeStanze = new Dictionary<string, Stanza>()
        {
            { "piano_terra" , pianoTerra },
            {"cantina", cantina }
        };
    }
}
