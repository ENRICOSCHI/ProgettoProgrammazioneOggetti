using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.Storia;
using GiocoTestualeEsame.warning;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.comandiDiGioco
{
    public class Comandi
    {
        /// <summary>
        /// Controllo i comandi inseriti dall'utente e in caso con l'argomento passato
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="argomento"></param>
        public static void ControlloComandi(string comando, string argomento)
        {
            Comandi c = new Comandi();
            /*swtich case con tutti i casi del comando che può esser stato scelto*/
            switch (comando)
            {
                case "ciao": Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("ciao!");break;
                case "prendi": c.MettiNellaMano(argomento); break;
                case "guarda": c.GuardaStanza(); break;
                case "help": c.Help(); break;
                case "vai": c.Vai(argomento); break;
                case "zaino": c.GuardaZaino(); break;
                case "aggiungi": c.AggiungiNelloZaino(argomento); break;
                case "rimuovi": c.RimuoviOggettoDalloZaino(argomento); break;
                case "peso": c.PesoZaino(); break;
                case "descrizione": c.DescrizioneOggetto(argomento); break;
                case "tp": c.Teletrasporto(); break;
                case "lascia": c.Lascia();break;
                default: Warning.WarningComandoNonEsistente(comando); break;
            }
        }

        /// <summary>
        /// Attacca un personaggio con l'oggetto assegnato.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="p"></param>
        public void Attacca(Oggetto o, Personaggio p)
        {

        }

        /// <summary>
        /// L'oggetto assegnato viene messo nella mano del giocatore e quello che era in mano viene lasciato nella stanza
        /// </summary>
        /// <param name="argomento"></param>
        public void MettiNellaMano(string argomento)
        {
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            Oggetto oggettoPassato = ConvertiStringToOggetto(argomento);
            Oggetto oggettoCorrenteInMano = GestisciStatoGioco.oggettoInMano;//oggetto che ho in mano prima di cambiarlo
            if (oggettoPassato != null && GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(oggettoPassato))// se è vero...
            {
                if (oggettoPassato.isRaccoglibile)//se è raccoglibile
                {
                    GestisciStatoGioco.stanzaCorrente.AddOggettoNellaStanza(oggettoCorrenteInMano);// metto l'oggetto che avevo in mano nella stanza
                    GestisciStatoGioco.giocatoreCorrente.MettiOggettoInMano(oggettoPassato);// metto l'oggetto nuovo in mano
                    Console.WriteLine("L'oggetto " + argomento + " è stato preso in mano");
                }
                else
                {
                    Warning.WarningNonPuoiRaccogliereOgetto();
                }
                
            }
            else
            {
                Warning.WarnignOggettoNonPresenteNellaStanza();
            }
        }
        /// <summary>
        /// Lascio nella stanza l'oggetto presente nella mano
        /// </summary>
        public void Lascia()
        {
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            if (GestisciStatoGioco.oggettoInMano.nome != "")
                GestisciStatoGioco.giocatoreCorrente.LasciOggettoDallaMano();
            else
                Console.WriteLine("non hai oggetti in mano");
        }

        /// <summary>
        /// Mostro gli oggetti presenti nella stanza
        /// </summary>
       public void GuardaStanza()
       {
            GestisciStatoGioco.stanzaCorrente.MostraOggettiNellaStanza();
       }
        /// <summary>
        /// Riassunto dei comandi
        /// </summary>
       public void Help()
       {
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            Console.WriteLine("- help: mostra i comandi presenti nel gioco.\n" +
                "- ciao: saluta!\n" +
                "- prendi + oggetto da prendere. Prendi un oggetto presente nella stanza (l'oggetto in mano verrà messo nella stanza).Per esempio: prendi spada.\n" +
                "- lascia: l'oggetto in mano viene lasciato nella scena, e la mano sarà così liberata\n"+
                "- guarda: guarda gli oggetti presenti nella stanza.\n" +
                "- vai + direzione: Spostati nel mondo di gioco inserendo verso quale posizone spostarti. Per esempio: vai porta_destra.\n" +
                "- zaino: Guarda gli oggetti presenti nel tuo zaino.\n" +
                "- aggiungi + oggetto: aggiunge l'oggetto nello zaino e lo rimuove dalla stanza. Per esempio: aggiungi spada.\n" +
                "- rimuovi + oggetto: rimuove l'oggetto dallo zaino e lo lascia nella stanza. Per esempio: rimuovi spada.\n" +
                "- peso: Puoi vedere quanto pesa il tuo zaino\n" +
                "- descrizione + oggetto: mostra la descrizione e/o peso di un oggetto presente nella scena o nello zaino. Per esempio: descrizione spada\n" +
                "- tp: se hai il teletrasporto nello zaino, puoi teletrasportarti in una stanza casuale\n");
       }
        /// <summary>
        /// Sposta il giocatore nelle stanze del gioco
        /// </summary>
        /// <param name="direzione"></param>
        public void Vai(string direzione)
        {
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            Oggetto o = ConvertiStringToOggetto(direzione);//converto la stringa in un Oggetto, e controllo se la direzione è presente come oggetto nella stanza
            if (!GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(o))
            {
                Warning.WarningDirezioneNonPresenteNellaScena();
                return;//se non è presente esco dal metodo 
            }
            /*CAMBIARE STANZE, C'E' SOLO CANTINA*/
            switch (direzione)
            {
                case "porta_sinistra": GestisciStatoGioco.stanzaCorrente = ElencoStanze.camera; break;
                case "porta_destra": GestisciStatoGioco.stanzaCorrente = ElencoStanze.salaGiochi;break;
                case "scale_su": GestisciStatoGioco.stanzaCorrente = ElencoStanze.primoPiano; break;
                case "scale_giu": GestisciStatoGioco.stanzaCorrente = ElencoStanze.cantina; break;
                case "torna_piano_terra": GestisciStatoGioco.stanzaCorrente = ElencoStanze.pianoTerra;break;
                default: break;  
            }
            Console.WriteLine(GestisciStatoGioco.stanzaCorrente.descrizione);//mostro la descrizione della stanza
        }
        /// <summary>
        /// Il giocatore guarda gli oggetti presenti nello zaino.
        /// </summary>
        public void GuardaZaino()
        {
            GestisciStatoGioco.giocatoreCorrente.GuardaOggettiNelloZaino();
        }
        /// <summary>
        /// L'utente aggiunge l'oggetto nella stanza.
        /// <br> Passare l'argomento come parametro.</br>
        /// </summary>
        /// <param name="oggettoPassato"></param>
        public void AggiungiNelloZaino(string oggettoPassato)
        {
            Oggetto o = ConvertiStringToOggetto(oggettoPassato);//mentre converto controllo se l'oggetto esiste
            if(GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(o))//se è presente nella stanza...
            {
                GestisciStatoGioco.giocatoreCorrente.AddZaino(o);//inserisco l'oggetto nello zaino
            }
            else
            {
                Warning.WarnignOggettoNonPresenteNellaStanza();
            }
        }
        /// <summary>
        /// Rimuovo l'oggetto dallo zaino
        /// </summary>
        /// <param name="oggettoPassato"></param>
        public void RimuoviOggettoDalloZaino(string oggettoPassato)
        {
            Oggetto o = ConvertiStringToOggetto(oggettoPassato);//mentre converto controllo se l'oggetto esiste
            GestisciStatoGioco.giocatoreCorrente.RemoveZaino(o);
        }
        /// <summary>
        /// L'utene può vedere quanto pesa lo zaino.
        /// </summary>
        public void PesoZaino()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
            Console.WriteLine("Lo zaino pesa: " + GestisciStatoGioco.giocatoreCorrente.pesoNelloZaino + " kg / "+ GestisciStatoGioco.giocatoreCorrente.pesoMaxZaino);
        }
        /// <summary>
        /// Mostra all'utente il peso e la descrizione di un oggetto presente nella scena o nello zaino o in mano
        /// </summary>
        /// <param name="oggettoPassato"></param>
        public void DescrizioneOggetto(string oggettoPassato)
        {
            Oggetto o = ConvertiStringToOggetto(oggettoPassato);//mentre converto controllo anche se esiste
            if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(o))//controllo se l'oggetto è nella stanza
            {
                Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
                if (o.isRaccoglibile)
                    Console.WriteLine("Descrizione: " + o.descrizione + "\nPeso: " + o.peso);// se è raccoglibile mostro il peso..
                else
                    Console.WriteLine("Descrizione: " + o.descrizione+"\n");//...altrimenti non lo mostro
                return;
            }
            else if (GestisciStatoGioco.giocatoreCorrente.IsOggettoNelloZaino(o))//controllo se l'oggetto è nello zaino
            {
                Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
                Console.WriteLine("Descrizione: " + o.descrizione + "\nPeso: " + o.peso);
                return;
            }else if (GestisciStatoGioco.oggettoInMano.nome == oggettoPassato)//se l'oggetto è in mano
            {
                Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
                Console.WriteLine("Descrizione: " + o.descrizione + "\nPeso: " + o.peso);
            }
            /*Avviso che non è presente ne nella scena ne nello zaino*/
            Warning.WarningOggettoNonPresenteNelloZaino(o);
            Warning.WarningDirezioneNonPresenteNellaScena();
        }

        /*Da completare*/
        public void Teletrasporto()
        {
            if (GestisciStatoGioco.giocatoreCorrente.IsOggettoNelloZaino(ElencoOggetti.teletrasporto) || GestisciStatoGioco.giocatoreCorrente.IsOggettoInMano(ElencoOggetti.teletrasporto))
            {
                GestisciStatoGioco.stanzaCorrente = Stanza.GetRandomStanza();
                Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
                Console.WriteLine("ti sei teletrasportato con successo");
            }
            else
            {
                Warning.WarningOggettoNonPresenteNelloZaino(ElencoOggetti.teletrasporto);
                Warning.WarningOggettoNonInMano();
            }
        }

        /// <summary>
        /// Converto la stringa in oggetto.
        /// Ritorna un oggetto.
        /// Se l'oggetto non esiste ritorna null con un warning
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Oggetto ConvertiStringToOggetto(string input)
        {
            Oggetto o;
            if (!ElencoOggetti.TuttiGliOggetti.TryGetValue(input, out o))
            {
                Warning.WarningErroreDiBattitura();
                return null;
            }
            return o;
        }
    }
}
