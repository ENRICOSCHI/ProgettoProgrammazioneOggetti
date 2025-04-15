using GiocoTestualeEsame.stanze;
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
        /*OGGETTI*/
        public static Oggetto manoVuota { get; } = new Oggetto("", 0, "non hai niente in mano", false);
        public static Oggetto spada { get; } = new Oggetto("spada", 9.50, "spada trovata in un fosso", true);
        public static Oggetto scarpa { get; } = new Oggetto("scarpa",1.5, "scarpe rotte da usare come abbellimento", true);
        public static Oggetto teletrasporto { get; } = new Oggetto("teletrasporto", 10, "vieni portato in una stanza casuale", true);

        
        /*PASSAGGI*/
        public static Passaggio porta_camera { get; } = new Passaggio("porta3", "questa porta va in camera", ElencoStanze.camera);
        public static Passaggio porta_salagiochi { get; } = new Passaggio("porta2", "questa porta va alla sala giochi", ElencoStanze.salaGiochi);
        public static Passaggio porta_piano_terra { get; } = new Passaggio("porta1", "questa porta va al piano terra", ElencoStanze.pianoTerra);
        public static Passaggio scale_su_primo_piano { get; } = new Passaggio("scala2", "queste scale portano al primo piano", ElencoStanze.primoPiano);
        public static Passaggio scale_piano_terra { get; } = new Passaggio("scala1", "queste scale portano al piano terra", ElencoStanze.pianoTerra);
        public static Passaggio scale_giu_cantina { get; } = new Passaggio("scala3", "queste scale portano alla cantina", ElencoStanze.cantina);


        //dizionario oggetto
        public static readonly Dictionary<string, Oggetto> TuttiGliOggetti = new Dictionary<string, Oggetto>(System.StringComparer.OrdinalIgnoreCase)//per non renderelo case sensitive
        {
            { spada.nome, spada },
            { scarpa.nome, scarpa },
            {teletrasporto.nome,teletrasporto },
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
            {porta_salagiochi.nome,porta_salagiochi}
        };
    }
}
