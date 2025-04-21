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
        public static Stanza primoPiano { get; } = new Stanza("primo piano", "descrizione primo piano");
        public static Stanza salaGiochi { get; } = new Stanza("sala giochi", "descrizione sala giochi");
        public static Stanza camera { get; } = new Stanza("camera", "descrizione camera");
        public static Stanza quadroElettrico { get; } = new Stanza("quadro elettrico", "In questa stanza è presente il quadro elettrico dell'intero edificio");

        public static readonly Dictionary<string, Stanza> TutteLeStanze = new Dictionary<string, Stanza>()
        {
            { "piano_terra" , pianoTerra },
            {"cantina", cantina },
            {"primo_piano", primoPiano },
            {"sala_giochi", salaGiochi },
            {"camera",camera },
            {"quadro_elettrico",quadroElettrico }
        };
    }
}
