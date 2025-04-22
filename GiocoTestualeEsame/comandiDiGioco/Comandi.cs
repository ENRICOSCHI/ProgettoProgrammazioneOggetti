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
                case "parla": c.Parla(argomento); break;
                case "dai": c.Dai(argomento); break;
                default: Warning.WarningComandoNonEsistente(comando); break;
            }
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
            Console.ForegroundColor = ConsoleColor.DarkGray;//cambio colore scritta
            Console.WriteLine("- help: mostra i comandi presenti nel gioco.\n\n" +
                "- ciao: saluta!\n\n" +
                "- prendi + oggetto da prendere. Prendi un oggetto presente nella stanza (l'oggetto in mano verrà messo nella stanza).Per esempio: prendi spada.\n\n" +
                "- lascia: l'oggetto in mano viene lasciato nella scena, e la mano sarà così liberata\n\n"+
                "- guarda: guarda gli oggetti presenti nella stanza.\n\n" +
                "- vai + direzione: Spostati nel mondo di gioco inserendo verso quale posizone spostarti. Per esempio: vai porta_destra.\n\n" +
                "- zaino: Guarda gli oggetti presenti nel tuo zaino.\n\n" +
                "- aggiungi + oggetto: aggiunge l'oggetto nello zaino e lo rimuove dalla stanza. Per esempio: aggiungi spada.\n\n" +
                "- rimuovi + oggetto: rimuove l'oggetto dallo zaino e lo lascia nella stanza. Per esempio: rimuovi spada.\n\n" +
                "- peso: Puoi vedere quanto pesa il tuo zaino.\n\n" +
                "- descrizione + oggetto: mostra la descrizione e/o peso di un oggetto presente nella scena o nello zaino. Per esempio: descrizione spada.\n\n" +
                "- tp: se hai il teletrasporto nello zaino, puoi teletrasportarti in una stanza casuale.\n\n" +
                "- parla + nome personaggio: ascolta cosa ha da dirti un personaggio nella scena.\n\n" +
                "- dai + nome personaggio: dai al personaggio indicato l'oggetto richieste == l'oggetto deve essere nello zaino ==.");
       }
        /// <summary>
        /// Sposta il giocatore nelle stanze del gioco
        /// </summary>
        /// <param name="direzione"></param>
        public void Vai(string nomePassaggio)
        {
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            Oggetto o = ConvertiStringToOggetto(nomePassaggio);//converto la stringa in un Oggetto, e controllo se la direzione è presente come oggetto nella stanza
            if (o is Passaggio)
            {
                Passaggio p = (Passaggio)o;
                if (!GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(p))
                {
                    Warning.WarningDirezioneNonPresenteNellaScena();
                    return;//se non è presente esco dal metodo 
                }
                Stanza stanzaDestinazione = p.destinazione; //prendo la stanza in cui entrerà il giocatore
                GestisciStatoGioco.stanzaCorrente = stanzaDestinazione; //entra nella stanza
                Console.WriteLine(GestisciStatoGioco.stanzaCorrente.descrizione);//mostro la descrizione della stanza
            }
            else
                Warning.WarningErroreCasting();
            
        }
        /// <summary>
        /// L'utente può leggere la richiesta del personaggio selezionato.
        /// </summary>
        /// <param name="personaggio"></param>
        public void Parla(string personaggio)
        {
            Oggetto o = ConvertiStringToOggetto(personaggio);
            if (o is Personaggio)
            {
                Personaggio c = (Personaggio)o;//casting...
                if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(c))
                    c.RichiestaToString();//stampo la richeista del personaggio
                else
                    Warning.WarnignOggettoNonPresenteNellaStanza();
            }
            else
                Warning.WarningErroreCasting();
            
        }

        /// <summary>
        /// Il personaggio da al giocatore il premio per avergli dato quello che ha richiesto.
        /// </summary>
        /// <param name="personaggio"></param>
        public void Dai(string personaggio)
        {
            Oggetto o = ConvertiStringToOggetto(personaggio);
            if (o is Personaggio)//controllo se è effettivamente di tipo personaggio
            {
                Personaggio c = (Personaggio)o;
                if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(c))//se il personaggio è nella stanza...
                    c.AddZainoRegalo();//controlla se il giocatore ha la richiesta nello zaino
            }
            else
                Warning.WarningErroreCasting();
            
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
            Oggetto o = ConvertiStringToOggetto(oggettoPassato);//converto in Oggetto o Passaggi
            Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
            if (o.isRaccoglibile)//se è un Oggetto...
            {
                if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(o))//controllo se l'oggetto è nella stanza
                {
                    Console.WriteLine("Descrizione: " + o.descrizione + "\nPeso: " + o.peso);
                    return;
                }
                else if (GestisciStatoGioco.giocatoreCorrente.IsOggettoNelloZaino(o))//controllo se l'oggetto è nello zaino
                {
                    Console.WriteLine("Descrizione: " + o.descrizione + "\nPeso: " + o.peso);
                    return;
                }
                else if (GestisciStatoGioco.oggettoInMano.nome == oggettoPassato)//se l'oggetto è in mano
                {
                    
                    Console.WriteLine("Descrizione: " + o.descrizione + "\nPeso: " + o.peso);
                    return;
                }
                else
                {
                    Warning.WarningOggettoNonPresenteNelloZaino(o);
                    Warning.WarnignOggettoNonPresenteNellaStanza();
                }
            }else if(!o.isRaccoglibile)//se è un Passaggio...
            {
                if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(o))
                {
                    Console.WriteLine("Descrizione: " + o.descrizione);
                }
                else
                {
                    Warning.WarningDirezioneNonPresenteNellaScena();
                }
            }
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
        /// Converto la stringa in Oggetto.
        /// Ritorna un Oggetto.
        /// Se l'oggetto non esiste ritorna null con un warning
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Oggetto ConvertiStringToOggetto(string input)
        {
            Oggetto o;
            if (!ElencoOggetti.TuttiGliInteragibili.TryGetValue(input, out o))
            {
                Warning.WarningErroreDiBattitura();
                return null;
            }
            return o;
        }
    }
}
