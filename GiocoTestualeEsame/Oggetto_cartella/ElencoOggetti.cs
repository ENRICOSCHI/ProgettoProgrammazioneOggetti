using GiocoTestualeEsame.stanze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Oggetto_cartella
{
    /*CLASSE CON TUTTI GLI OGGETTI CREATI*/
    public class ElencoOggetti
    {
        /*OGGETTI*/
        public static Oggetto manoVuota { get; } = new Oggetto("", 0, "non hai niente in mano", false);
        public static Oggetto spada { get; } = new Oggetto("spada", 9.50, "spada trovata sotto il letto", true);
        public static Oggetto scarpa { get; } = new Oggetto("scarpa",1.5, "scarpe rotte da usare come abbellimento... più o meno", true);
        public static Oggetto teletrasporto { get; } = new Oggetto("teletrasporto", 10, "vieni portato in una stanza casuale", true);
        public static Oggetto cacciavite { get; } = new Oggetto("cacciavite", 2, "serve all'elettricista", true);
        public static Oggetto dadi { get; } = new Oggetto("dadi", 1.50, "li vuole il sicario", true);
        public static Oggetto carteDaGioco { get; } = new Oggetto("carte_da_gioco", 2, "potrebbero interessare a qualcuno che si annoia", true);

        /*PASSAGGI*/
        public static Passaggio porta_camera { get; } = new Passaggio("porta3", "questa porta va in camera", ElencoStanze.camera);
        public static Passaggio porta_salagiochi { get; } = new Passaggio("porta2", "questa porta va alla sala giochi", ElencoStanze.salaGiochi);
        public static Passaggio porta_piano_terra { get; } = new Passaggio("porta1", "questa porta va al piano terra", ElencoStanze.pianoTerra);
        public static Passaggio porta_quadro_elettrico { get; } = new Passaggio("porta4","questa porta conduce al quadro elettrico",ElencoStanze.quadroElettrico);
        public static Passaggio porta_cantina { get; } = new Passaggio("porta5", "questa porta conduce in cantina", ElencoStanze.cantina);
        public static Passaggio scale_su_primo_piano { get; } = new Passaggio("scala2", "queste scale portano al primo piano", ElencoStanze.primoPiano);
        public static Passaggio scale_piano_terra { get; } = new Passaggio("scala1", "queste scale portano al piano terra", ElencoStanze.pianoTerra);
        public static Passaggio scale_giu_cantina { get; } = new Passaggio("scala3", "queste scale portano alla cantina", ElencoStanze.cantina);

        /*PERSONAGGI*/
        public static Personaggio ragazzoChill { get; } = new Personaggio("ChillGuy", "è solo un ragazzo nel chill che ti vuole bene", spada,teletrasporto);
        public static Personaggio Elettricista { get; } = new Personaggio("Elettricista","è l'unico che può mettere a posto la corrente elettrica", cacciavite,null);
        public static Personaggio Sicario { get; } = new Personaggio("Sicario", "ti aiuterà ad uccidere il cattivo", dadi, null);//vedi meglio il personaggio
        public static Personaggio Pirata { get; } = new Personaggio("Pirata", "è stato incarcerato 10 anni fa in questa prigione, non vuole niente, solo la libertà!", null, null);
        public static Personaggio Poliziotto { get; } = new Personaggio("Poliziotto", "stare tutto il tempo in prigione lo sta annoiando, per passare il tempo", carteDaGioco, null);
        public static Personaggio Mago { get; } = new Personaggio("Mago", "ti darà dei dadi per aver partecipato a un suo trucco di magia", null, dadi);

        //dizionario oggetto
        public static readonly Dictionary<string, Oggetto> TuttiGliOggetti = new Dictionary<string, Oggetto>(System.StringComparer.OrdinalIgnoreCase)//per non renderelo case sensitive
        {
            { spada.nome, spada },
            { scarpa.nome, scarpa },
            {teletrasporto.nome,teletrasporto },
            {cacciavite.nome,cacciavite },
            {dadi.nome,dadi },
            {carteDaGioco.nome, carteDaGioco },
            { "vuoto", manoVuota } //oggetto di default
        };
        //dizionario passaggio
        public static readonly Dictionary<string, Passaggio> TuttiIPassaggi = new Dictionary<string, Passaggio>(System.StringComparer.OrdinalIgnoreCase)
        {
            {scale_giu_cantina.nome,scale_giu_cantina },
            {scale_piano_terra.nome,scale_piano_terra },
            {scale_su_primo_piano.nome, scale_su_primo_piano } ,
            {porta_camera.nome,porta_camera },
            {porta_piano_terra.nome ,porta_piano_terra },
            {porta_salagiochi.nome,porta_salagiochi},
            {porta_quadro_elettrico.nome,porta_quadro_elettrico},
            {porta_cantina.nome,porta_cantina }
        };
        //dizionario personaggi
        public static readonly Dictionary<string, Personaggio> TuttiIPersonaggi = new Dictionary<string, Personaggio>(System.StringComparer.OrdinalIgnoreCase)
        {
            {ragazzoChill.nome,ragazzoChill},
            { Elettricista.nome,Elettricista},
            {Sicario.nome,Sicario},
            {Mago.nome,Mago},
            {Pirata.nome,Pirata},
            {Poliziotto.nome,Poliziotto},
        };
        //Dizionario generale
        public static readonly Dictionary<string, Oggetto> TuttiGliInteragibili = new Dictionary<string, Oggetto>(System.StringComparer.OrdinalIgnoreCase)
        {
            
        };
        
        //inserisco gli elementi dei 3 dizionari nel dizionario generale
        static ElencoOggetti()
        {
            foreach(var elemento in TuttiIPassaggi)
            {
                TuttiGliInteragibili[elemento.Key] = elemento.Value;
            }
            foreach(var elemento in TuttiIPersonaggi)
            {
                TuttiGliInteragibili[elemento.Key] = elemento.Value;
            }
            foreach (var elemento in TuttiGliOggetti)
            {
                TuttiGliInteragibili[elemento.Key] = elemento.Value;
            }
        }
    }
}
