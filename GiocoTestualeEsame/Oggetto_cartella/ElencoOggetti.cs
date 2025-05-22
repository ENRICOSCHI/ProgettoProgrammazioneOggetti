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
        #region"OGGETTI"
        /*OGGETTI*/
        public static Oggetto manoVuota { get; } = new Oggetto("", 0, "non hai niente in mano", false,false);
        public static Oggetto spada { get; } = new Oggetto("spada", 9.50, "spada trovata sotto il letto", true, false);
        public static Oggetto scarpa { get; } = new Oggetto("scarpa",1.5, "scarpe rotte da usare come abbellimento... più o meno", true, false);
        public static Oggetto teletrasporto { get; } = new Oggetto("teletrasporto", 10, "vieni portato in una stanza casuale", true, false);
        public static Oggetto cacciavite { get; } = new Oggetto("cacciavite", 2, "serve all'elettricista", true, false);
        public static Oggetto dadi { get; } = new Oggetto("dadi", 1.50, "li vuole il sicario", true, false);
        public static Oggetto carteDaGioco { get; } = new Oggetto("carte_da_gioco", 2, "potrebbero interessare a qualcuno che si annoia", true, false);
        public static Oggetto palla { get; } = new Oggetto("palla", 3, "una palla da calcia, perfetta per giocarchi", true, false);
        public static Oggetto sfera { get; } = new Oggetto("sfera", 5, "creata unendo una palla da calcio con alluminio", true, false);
        public static Oggetto sferaElettrica { get; } = new Oggetto("sferaElettrica", 7, "una sfera elettrica che quando attivata crea una fortissima scarica elettrica, si dice che sia in grado di sfamare per sempre un certo tipo di topo...", true, false);
        public static Oggetto ticket { get; } = new Oggetto("ticket", 0.5, "dato come segno di gratitudine dall'eletricista per averlo aiutato", true, false);
        public static Oggetto ArcadePM { get; } = new Oggetto("Arcade_PacMan", 120, "arcade con il gioco pacman", false, false);
        public static Oggetto ArcadeSM { get; } = new Oggetto("Arcade_Super_Mario", 120, "arcade con il gioco super mario", false, false);
        public static Oggetto ArcadeFootball { get; } = new Oggetto("Arcade_Calcio", 120, "arcade con un gioco di calcio", false, false);
        public static Oggetto ArcadeDK { get; } = new Oggetto("Arcade_Donkey_Kong", 120, "arcade con il gioco donkey kong", false, false);
        public static Oggetto ArcadeSI { get; } = new Oggetto("Arcade_Space_Invaders", 120, "arcade con il gioco space invaders", false, false);
        public static Oggetto libro { get; } = new Oggetto("libro", 5, "libro di Giulia", true, false);
        public static Oggetto discoLayla { get; } = new Oggetto("discoLayla", 5, "disco della canzone Layla dei Derek and the Dominos", true, false);

        #endregion
        #region"PASSAGGI"
        /*PASSAGGI*/
        public static Passaggio porta_camera { get; } = new Passaggio("porta3", "questa porta va in camera", ElencoStanze.camera);
        public static Passaggio porta_salagiochi { get; } = new Passaggio("porta2", "questa porta va alla sala giochi", ElencoStanze.salaGiochi);
        public static Passaggio porta_piano_terra { get; } = new Passaggio("porta1", "questa porta va al piano terra", ElencoStanze.pianoTerra);
        public static Passaggio porta_quadro_elettrico { get; } = new Passaggio("porta4","questa porta conduce al quadro elettrico",ElencoStanze.quadroElettrico);
        public static Passaggio porta_cantina { get; } = new Passaggio("porta5", "questa porta conduce in cantina", ElencoStanze.cantina);
        public static Passaggio scale_su_primo_piano { get; } = new Passaggio("scalaPrimoPiano", "queste scale portano al primo piano", ElencoStanze.primoPiano);
        public static Passaggio scale_piano_terra { get; } = new Passaggio("scala1", "queste scale portano al piano terra", ElencoStanze.pianoTerra);
        public static Passaggio scale_giu_cantina { get; } = new Passaggio("scalaCantina", "queste scale portano alla cantina", ElencoStanze.cantina);
        public static Passaggio botolaGiu { get; } = new Passaggio("botola1", "questa botola sotto il letto porta in un posto misterioso", ElencoStanze.bosco);//da mettere in camera
        public static Passaggio botolaSu { get; } = new Passaggio("botola2", "questa botola ti riporta in camera", ElencoStanze.camera);//da mettere nel bosco
        #endregion
        #region"PERSONAGGI"
        /*PERSONAGGI*/
        public static Personaggio ragazzoChill { get; } = new Personaggio("ChillGuy", "è solo un ragazzo nel chill che ti vuole bene", spada,teletrasporto,true);
        public static Personaggio Elettricista { get; } = new Personaggio("Elettricista","appena arrivato ha visto il topo drago elettrico ed è corso a nascondersi sotto un tavolo", cacciavite, ticket, false); //all'inizio non è interagibile, lo diventerà dopo aver scacciato il mostro
        public static Personaggio Sicario { get; } = new Personaggio("Sicario", "qui in prigione si è stancato di giocare con la palla", dadi, palla, true);
        public static Personaggio Pirata { get; } = new Personaggio("Pirata", "è stato incarcerato 10 anni fa in questa prigione, non vuole niente, solo la libertà!", null, null, true);
        public static Personaggio Poliziotto { get; } = new Personaggio("Poliziotto", "stare tutto il tempo in prigione lo sta annoiando, per passare il tempo", carteDaGioco, null, true);
        public static Personaggio Mago { get; } = new Personaggio("Mago", "ti darà dei dadi per aver partecipato a un suo trucco di magia", null, dadi, true);
        public static Personaggio ElfoMaestro { get; } = new Personaggio("ElfoMaestro", "è l'unico che sa creare l'oggetto perfetto per sfamare il TopoDragoElettrico, ti vuole aiutare però gli manca un materiale importante...", sfera, sferaElettrica, true);//buono
        public static Personaggio ElfoAiutante { get; } = new Personaggio("ElfoAiutante", "è sempre pronto ad aiutare il maestro", palla, sfera, true);
        public static Personaggio TopoDragoElettrico { get; } = new Personaggio("TopoDragoElettrico", "ha sempre fame di energia elettrica, non si toglierà finchè non ha saziato la sua fame", sferaElettrica, null, true);//cattivo
        public static Personaggio bambinoTriste { get; } = new Personaggio("bambinoTriste", "oggi voleva andare a giocare al suo gioco preferito nella sala giochi, ma per colpa del mostro non può", null, null, true);
        public static Personaggio giulia { get; } = new Personaggio("Giulia", "sta cercando il suo libro ma ha paura che gli sia caduto dalle scale", libro, null, true);
        public static Personaggio Marco { get; } = new Personaggio("Marco", "è stato appena lasciato dalla sua ragazza Layla", discoLayla, null, true);
        #endregion
        #region"DIZIONARI"
        //dizionario oggetto
        public static readonly Dictionary<string, Oggetto> TuttiGliOggetti = new Dictionary<string, Oggetto>(System.StringComparer.OrdinalIgnoreCase)//per non renderelo case sensitive
        {
            { spada.nome, spada },
            { scarpa.nome, scarpa },
            {teletrasporto.nome,teletrasporto },
            {cacciavite.nome,cacciavite },
            {dadi.nome,dadi },
            {carteDaGioco.nome, carteDaGioco },
            {palla.nome, palla },
            {sfera.nome, sfera },
            {sferaElettrica.nome, sferaElettrica },
            {ticket.nome, ticket },
            {ArcadeDK.nome, ArcadeDK },
            {ArcadeFootball.nome, ArcadeFootball },
            {ArcadePM.nome, ArcadePM },
            {ArcadeSI.nome, ArcadeSI },
            {ArcadeSM.nome, ArcadeSM },
            {libro.nome, libro },
            {discoLayla.nome, discoLayla },
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
            {porta_cantina.nome,porta_cantina },
            { botolaGiu.nome,botolaGiu },
            {botolaSu.nome,botolaSu}
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
            {ElfoAiutante.nome,ElfoAiutante},
            {ElfoMaestro.nome,ElfoMaestro},
            {TopoDragoElettrico.nome,TopoDragoElettrico},
            {giulia.nome,giulia},
            {bambinoTriste.nome,bambinoTriste},
            {Marco.nome,Marco}
        };
        //Dizionario generale
        public static readonly Dictionary<string, Oggetto> TuttiGliInteragibili = new Dictionary<string, Oggetto>(System.StringComparer.OrdinalIgnoreCase)
        {
            
        };
        #endregion
        //inserisco gli elementi dei 3 dizionari nel dizionario generale
        static ElencoOggetti()
        {
            InizializzoTuttiGliInteragibili();
        }

        public static void InizializzoTuttiGliInteragibili()
        {
            TuttiGliInteragibili.Clear();
            foreach (var elemento in TuttiIPassaggi)
            {
                TuttiGliInteragibili[elemento.Key] = elemento.Value;
            }
            foreach (var elemento in TuttiIPersonaggi)
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
