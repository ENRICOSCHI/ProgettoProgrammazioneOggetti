using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.Persona_cartella;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.Storia;
using GiocoTestualeEsame.warning;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using log4net;
using System.Reflection;
using System.Configuration;
using System.Timers;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace GiocoTestualeEsame.comandiDiGioco
{
    public class Comandi
    {
        private const string FILEJSONGIOCATORE = "giocatore.json";
        private const string FILEJSONSTANZE = "OggettiStanze.json";
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
                case "ciao": Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"ciao! {GestisciStatoGioco.giocatoreCorrente.nome}");break;
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
                case "salva": c.Salva(); break;
                case "carica": c.Carica(); break;
                case "nuovaPartita": c.NuovaPartita(); break;
                default: Warning.WarningComandoNonEsistente(comando); break;
            }
        }
        #region "metodi comando prendi/lascia"
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
                    Console.WriteLine("L'oggetto " + oggettoPassato.nome + " è stato preso in mano");
                    Warning.InfoOggettoPresoInMano(oggettoPassato);
                    Warning.InfoOggettoLasciatoInStanza(oggettoCorrenteInMano, GestisciStatoGioco.stanzaCorrente);
                }
                else
                    Warning.WarningNonPuoiRaccogliereOggetto();
            }
            else
                Warning.WarnignOggettoNonPresenteNellaStanza();
        }
        /// <summary>
        /// Lascio nella stanza l'oggetto presente nella mano
        /// </summary>
        public void Lascia()
        {
            Warning.InfoUsoLascia();
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            if (GestisciStatoGioco.oggettoInMano.nome != "")
                GestisciStatoGioco.giocatoreCorrente.LasciOggettoDallaMano();
            else
            {
                Console.WriteLine("non hai oggetti in mano");
                Warning.InfoManoGiàVuota();
            }                
        }
        #endregion
        #region "metodi comando guarda"
        /// <summary>
        /// Mostro gli oggetti presenti nella stanza
        /// </summary>
        public void GuardaStanza()
        {
            GestisciStatoGioco.stanzaCorrente.MostraOggettiNellaStanza();
            Warning.InfoGuardaStanza(GestisciStatoGioco.stanzaCorrente);
        }
        #endregion
        #region "metodi comando help"
        /// <summary>
        /// Riassunto dei comandi
        /// </summary>
        public void Help()
       {
            Console.ForegroundColor = ConsoleColor.DarkGray;//cambio colore scritta
            Console.WriteLine("============================DESCRIZIONE PROMPT============================\n\n" +
                "[stanza attuale] oggetto in mano > lettura comandi\n\n" +
                "==========================COMANDI GESTIONE PARTITA==========================\n\n" +
                "- salva: salva partita attuale\n\n" +
                "- carica: carica partita precedente\n\n" +
                "- nuovaPartita: comincia una partita da capo e (se sono presenti) cancellando i dati di salvataggio esistenti\n\n" +
                "==========================COMANDI================================\n\n" +
                "- help: mostra i comandi presenti nel gioco.\n\n" +
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
                "- dai + nome personaggio: dai al personaggio indicato l'oggetto richiesto == l'oggetto deve essere nello zaino ==.\n");
            Warning.InfoUsoHelp();
        }
        #endregion
        #region "metodi comando vai/muoversi tra le stanze"
        /// <summary>
        /// Sposta il giocatore nelle stanze del gioco
        /// </summary>
        /// <param name="direzione"></param>
        public void Vai(string nomePassaggio)
        {
            Warning.InfoUsoVai();
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
        #endregion
        #region "metodi comando interazione con i personaggi (parla,dai)"
        /// <summary>
        /// L'utente può leggere la richiesta del personaggio selezionato.
        /// </summary>
        /// <param name="personaggio"></param>
        public void Parla(string personaggio)
        {
            Warning.InfoUsoParla();
            Oggetto o = ConvertiStringToOggetto(personaggio);
            if (o is Personaggio)
            {
                Personaggio c = (Personaggio)o;//casting...
                if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(c))
                {
                    c.RichiestaToString();//stampo la richeista del personaggio
                    if (c.richiesta == null && c.regalo != null)//se il personaggio non ha la richiesta...
                        c.AddRegalo(c);//do direttamente il regalo

                }
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
            Warning.InfoUsoDai();
            Oggetto o = ConvertiStringToOggetto(personaggio);
            if (o is Personaggio)//controllo se è effettivamente di tipo personaggio
            {
                Personaggio c = (Personaggio)o;
                if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(c))//se il personaggio è nella stanza...
                {
                    if (c.AddZainoRegalo())//controlla se il giocatore ha la richiesta nello zaino e se c'è la dai il regalo
                    {
                        GestisciStatoGioco.ControllaMorteCattivo(c);//controllo se ha completato la richiesta del cattivo
                        GestisciStatoGioco.ControlloFinePartira(c);//Controllo se ha finito il gioco
                        if(c != null)
                        {
                            //azzero richiesta e regalo
                            c.descrizione = $"{c.nome} ti è riconoscete per il regalo";
                            c.richiesta = null;
                            c.regalo = null;
                            c.isInteragibile = false;
                        }
                    }
                }
            }
            else
                Warning.WarningErroreCasting();
        }
        #endregion
        #region "metodi interazione con lo zaino (guardaZaino,Aggiungi,Rimuovi,Peso)"
        /// <summary>
        /// Il giocatore guarda gli oggetti presenti nello zaino.
        /// </summary>
        public void GuardaZaino()
        {
            Warning.InfoUsoZaino();
            GestisciStatoGioco.giocatoreCorrente.GuardaOggettiNelloZaino();
        }
        /// <summary>
        /// L'utente aggiunge l'oggetto nella stanza.
        /// <br> Passare l'argomento come parametro.</br>
        /// </summary>
        /// <param name="oggettoPassato"></param>
        public void AggiungiNelloZaino(string oggettoPassato)
        {
            Warning.InfoUsoAggiungi();
            Oggetto o = ConvertiStringToOggetto(oggettoPassato);//mentre converto controllo se l'oggetto esiste
            if(GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(o))//se è presente nella stanza...
            {
                GestisciStatoGioco.giocatoreCorrente.AddZaino(o);//inserisco l'oggetto nello zaino
            }
            else
                Warning.WarnignOggettoNonPresenteNellaStanza();
        }
        /// <summary>
        /// Rimuovo l'oggetto dallo zaino
        /// </summary>
        /// <param name="oggettoPassato"></param>
        public void RimuoviOggettoDalloZaino(string oggettoPassato)
        {
            Warning.InfoUsoRimuovi();
            Oggetto o = ConvertiStringToOggetto(oggettoPassato);//mentre converto controllo se l'oggetto esiste
            if(o != null)
                GestisciStatoGioco.giocatoreCorrente.RemoveZaino(o);
        }
        /// <summary>
        /// L'utene può vedere quanto pesa lo zaino.
        /// </summary>
        public void PesoZaino()
        {
            Warning.InfoUsoPeso();
            Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
            Console.WriteLine("Lo zaino pesa: " + GestisciStatoGioco.giocatoreCorrente.pesoNelloZaino + " kg / "+ GestisciStatoGioco.giocatoreCorrente.pesoMaxZaino);
        }
        #endregion
        #region"metodi comando descrizione"
        /// <summary>
        /// Mostra all'utente il peso e la descrizione di un oggetto presente nella scena o nello zaino o in mano
        /// </summary>
        /// <param name="oggettoPassato"></param>
        public void DescrizioneOggetto(string oggettoPassato)
        {
            Warning.InfoUsoDescrizione();
            Oggetto o = ConvertiStringToOggetto(oggettoPassato);//converto in Oggetto o Passaggi
            Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
            if(o != null)
            {
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
                }
                else if (!o.isRaccoglibile)//se è un Passaggio...
                {
                    if (GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(o))
                    {
                        Console.WriteLine("Descrizione: " + o.descrizione);
                    }
                    else
                        Warning.WarningDirezioneNonPresenteNellaScena();
                }
            }
        }
        #endregion
        #region"metodi comando tp"
        public void Teletrasporto()
        {
            Warning.InfoUsoTeletrasporto();
            if (GestisciStatoGioco.giocatoreCorrente.IsOggettoNelloZaino(ElencoOggetti.teletrasporto) || GestisciStatoGioco.giocatoreCorrente.IsOggettoInMano(ElencoOggetti.teletrasporto))
            {
                GestisciStatoGioco.stanzaCorrente = Stanza.GetRandomStanza();
                Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
                Console.WriteLine("ti sei teletrasportato con successo");
                Console.ForegroundColor = ConsoleColor.Magenta;//cambio colore scritta
                Console.WriteLine(GestisciStatoGioco.stanzaCorrente.descrizione);
                Warning.InfoStanzaTeletrasportato(GestisciStatoGioco.stanzaCorrente);//salvo nel log la stanza in cui mi sono tp
            }
            else
            {
                Warning.WarningOggettoNonPresenteNelloZaino(ElencoOggetti.teletrasporto);
                Warning.WarningOggettoNonInMano();
            }
        }
        #endregion
        #region"metodi Salvataggio, Caricamento, Nuova Partita "
        /// <summary>
        /// Salvo i dati della partita attuale.
        /// </summary>
        public void Salva()
        {
            Warning.InfoUsoSalva();
            /*SALVATAGGIO DATI GIOCATORE*/
            SalvataggiGiocatore sg = GestisciStatoGioco.giocatoreCorrente.ImportoDatiCorrenti();
            string jsonGiocatore = JsonSerializer.Serialize(sg, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILEJSONGIOCATORE, jsonGiocatore);
            /*SALVATAGGIO DATI OGGETTI STANZE*/
            string jsonStanze = JsonSerializer.Serialize(ElencoStanze.TutteLeStanze , new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILEJSONSTANZE, jsonStanze);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("dati salvati");
            Warning.InfoDatiSalvatiConSuccesso();
        }
        /// <summary>
        /// Carico dati della partita salvata precedentemente.
        /// </summary>
        public void Carica()
        {
            Warning.InfoUsoCarica();
            if (File.Exists(FILEJSONGIOCATORE) && File.Exists(FILEJSONSTANZE))
            {
                /*CARICAMENTO OGGETTI NELLA STANZA*/
                string jsonStanze = File.ReadAllText(FILEJSONSTANZE);
                Dictionary<string, Stanza> tutteLeStanzeDatiCaricati = JsonSerializer.Deserialize<Dictionary<string, Stanza>>(jsonStanze);
                foreach (string nomeStanza in ElencoStanze.TutteLeStanze.Keys)
                {
                    Stanza stanza = ConvertiStringToStanza(nomeStanza);
                    stanza.PuliscoLista_oggettiNellaStanza();//ripulisco la lista così da mettere altri i nuovi oggetti salvati nella stanza 
                    foreach (var o in tutteLeStanzeDatiCaricati[nomeStanza].oggettiNellaStanza)
                    {
                        Oggetto oggetto = ConvertiStringToOggetto(o.nome);//oggetto estratto è diverso dall'oggetto caricato inizialmente
                        oggetto.isInteragibile = o.isInteragibile;//carico lo stato di interagibile precedentemente salvato
                        oggetto.descrizione = o.descrizione; //carico la descrizione precedentemente salvata
                        stanza.AddOggettoNellaStanza(oggetto);
                    }
                }
                /*CARICAMENTO GIOCATORE*/
                string jsonGiocatore = File.ReadAllText(FILEJSONGIOCATORE);
                SalvataggiGiocatore sg = JsonSerializer.Deserialize<SalvataggiGiocatore>(jsonGiocatore);
                Giocatore giocatore = Giocatore.CreoGiocatoreDaSalvattaggiGiocatore(sg);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("dati caricati");
                Warning.InfoDatiCaricatiConSuccesso();
            }
            else
                Warning.WarningErroreFileNonEsistente();
        }
        /// <summary>
        /// Cancello i dati precedenti (se presenti) e della partita attuale per cominciarne una nuova.
        /// </summary>
        public void NuovaPartita()
        {
            Warning.InfoUsoNuovaPartita();
            /*GESTIRE ECCEZIONE QUANDO NON è PRESENTE NESSUN FILE DI CARICAMENTEO*/
            string pathGiocatore = FILEJSONGIOCATORE;
            string pathStanza = FILEJSONSTANZE;
            if (File.Exists(pathStanza))
            {
                File.Delete(pathStanza);
                Console.WriteLine("Salvataggio stanze eliminato.");
                Warning.InfoDatiStanzeEliminati();
            }else if (File.Exists(pathGiocatore))
            {
                File.Delete(pathGiocatore);
                Console.WriteLine("Salvataggio giocatore eliminato.");
                Warning.InfoDatiGiocatoreEliminati();
            }
            Console.Clear();//pulisco la console
            Console.ResetColor();//rimetto il colore bianco
            StoriaPrincipale.CreazioneGiocatore_StartStoria();//faccio ripartire la storia
        }
        /// <summary>
        /// Controllo se i dati sono già presenti e stampo a video un messaggio di notifica.
        /// </summary>
        public static void ControlloPresenzaDati()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (File.Exists(FILEJSONGIOCATORE) && File.Exists(FILEJSONSTANZE))
            {
                Console.WriteLine("\n---------IMPORATANTE!!!---------\nSono stati trovati file di salvattaggio precedenti, per caricarli scrivere ''carica''\n\n");
                Warning.InfoCustomizable("Trovati file di salvataggio precedenti");
            }     
        }
        #endregion
        #region "metodi di conversione"
        /// <summary>
        /// Converto la stringa in Oggetto.
        /// Ritorna un Oggetto.
        /// Se l'oggetto non esiste ritorna null con un warning
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Oggetto ConvertiStringToOggetto(string input)
        {
            Warning.InfoCustomizable($"Conversione in oggetto {input}");
            Oggetto o;
            if (!ElencoOggetti.TuttiGliInteragibili.TryGetValue(input, out o))
            {
                Warning.WarningErroreDiBattitura();
                return null;
            }
            return o;
        }
        public static Stanza ConvertiStringToStanza(string input)
        {
            Warning.InfoCustomizable($"Conversione in stanza {input}");
            Stanza s;
            if (!ElencoStanze.TutteLeStanze.TryGetValue(input, out s))
            {
                Warning.WarningErroreDiBattitura();
                return null;
            }
            return s;
        }
        #endregion
    }
}
