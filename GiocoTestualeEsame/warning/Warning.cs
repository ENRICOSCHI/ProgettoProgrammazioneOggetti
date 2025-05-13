using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.Storia;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.warning
{
    public  class Warning
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region"stringhe per i messaggi di ERRORE/AVVISO"
        /*MESSAGGI DI ERRORE/WARNING*/
        private static string superatoLimitePeso = "Non puoi inserire {0}, hai superato il limite di peso. Peso zaino attuale: {1}\r"; //nello 0 ci andrà il nome dell'oggetto
        private static string oggettoNonPresenteNelloZaino = "ERRORE, {0} non è presente nello zaino\r";
        private static string oggettoNonPresenteNellaStanza = "ERRORE, l'oggetto non è presente nella stanza\r";
        private static string oggettoNonInMano = "ERRORE, l'oggetto non è in mano\r";
        private static string oggettoNonRaccoglibile = "Non puoi raccogliere questo oggetto!\r";
        private static string oggettoNonAggiuntoAlloZaino = "{0} non è stato aggiunto nello zaino\r";
        private static string erroreDiBattitura = "Attenzione, il nome inserito è sbagliato\r";
        private static string comandoErrato = "Attenzione, il comando '{0}' inserito non esiste\r";
        private static string direzioneErrata = "Non è presente questo passaggio nella stanza\r";
        private static string erroreOggettoPassato = "Attenzione, non puoi passare questo oggetto\r";
        private static string erroreFileNonEsistente = "Attenzione, non sono stati trovati file di salvataggio\r";
        #endregion

        #region"stringhe per i messaggi di avviso"
        /*MESSAGGI DI AVVISO*/
        private static string infoManoGiaVuota = "Info, si è provato a rimuovere un oggetto da una mano già vuota.";
        private static string infoGuardoStanza = "Info, l'utente guarda la stanza: {0}.";
        private static string infoUtenteUsaHelp = "Info, l'utente ha usato il comando help.";
        private static string infoUtenteUsaPrendi = "Info, l'utente ha usato il comando prendi.";
        private static string infoUtenteUsaLascia = "Info, l'utente ha usato il comando lascia.";
        private static string infoUtenteUsaVai = "Info, l'utente ha usato il comando vai.";
        private static string infoUtenteUsaParla = "Info, l'utente ha cambiato parla.";
        private static string infoUtenteUsaDai = "Info, l'utente ha usato il comando dai.";
        private static string infoUtenteUsaZaino = "Info, l'utente ha usato il comando zaino.";
        private static string infoUtenteUsaAggiungi = "Info, l'utente ha usato il comando aggiugni.";
        private static string infoUtenteUsaRimuovi = "Info, l'utente ha usato il comando rimuovi.";
        private static string infoUtenteUsaPeso = "Info, l'utente ha usato il comando peso.";
        private static string infoUtenteUsaDescrizione = "Info, l'utente ha usato il comando descrizione.";
        private static string infoUtenteUsaTeletrasporto = "Info, l'utente ha usato il comando teletrasporto.";
        private static string infoUtenteUsaSalva= "Info, l'utente ha usato il comando salva.";
        private static string infoUtenteUsaCarica = "Info, l'utente ha usato il comando carica.";
        private static string infoUtenteUsaNuovaPartita= "Info, l'utente ha usato il comando nuova partita.";
        private static string infoCreazioneDaiSalvataggiGiocatore = "Info, dati giocatore caricati nella classe SalvataggiGiocatore.";
        private static string infoOggettoPresoInMano = "Oggetto {0} preso in mano";
        private static string infoOggettoLasciatoNellaStanza = "Oggetto {0} lasciato nella stanza{1}";
        private static string infoStanzaTeletrasportato = "Giocatore teletrasportato nella stanza{0}";
        private static string infoDatiSalvatiSuccesso = "Dati salvati correttamente";
        private static string infoDatiCaricatiSuccesso = "Dati caricati correttamente";
        private static string infoDatiGiocatoreEliminati = "Dati giocatore eliminati correttamente";
        private static string infoDatiStanzeEliminati = "Dati stanze eliminati correttamente";
        #endregion

        #region "metodi per il warning"
        /// <summary>
        /// Warning per il superamento del limite di peso nello zaino.
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        /// <param name="oggetto"></param>
        /// <returns></returns>
        public static void WarnignSuperamentoPesoMassimo(Oggetto oggetto)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(string.Format(superatoLimitePeso,oggetto.nome,GestisciStatoGioco.giocatoreCorrente.pesoNelloZaino));
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto non era nello zaino.
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static void WarningOggettoNonPresenteNelloZaino(Oggetto o)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(string.Format(oggettoNonPresenteNelloZaino, o.nome));
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto che si cercava di raccogliere non è raccoglibile
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        /// <returns></returns>
        public static void WarningNonPuoiRaccogliereOggetto()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(oggettoNonRaccoglibile);
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto non è stato aggiunto nello zaino
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static void WarningOggettoNonAggiuntoAlloZaino(Oggetto o)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(string.Format(oggettoNonAggiuntoAlloZaino, o.nome));
        }

        /// <summary>
        /// Warning per avvisare l'utente dell'errore di battitura nell'input
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        public static void WarningErroreDiBattitura()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(erroreDiBattitura);
        }
        /// <summary>
        /// Warning per aver inserito il comando sbalgiato nel terminale
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        /// <param name="input"></param>
        public static void WarningComandoNonEsistente(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(string.Format(comandoErrato,input));
        }

        /// <summary>
        /// Warning per avvisare l'utente che l'oggetto non è presente nella stanza
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        public static void WarnignOggettoNonPresenteNellaStanza()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(oggettoNonPresenteNellaStanza);
        }

        /// <summary>
        /// Warning per avvisare che la direzione indicata non è presente nella scena
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        public static void WarningDirezioneNonPresenteNellaScena()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(direzioneErrata);
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto indicato non è in mano
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        public static void WarningOggettoNonInMano()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(oggettoNonInMano);
        }
        /// <summary>
        /// Warning per avvisare che il casting eseguito è errato
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        public static void WarningErroreCasting()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            _log.Error(erroreOggettoPassato);
        }
        /// <summary>
        /// Warning per avvisare che non esiste nessun file da caricare.
        /// Il messaggio viene scritto sia su console che su file di log
        /// </summary>
        public static void WarningErroreFileNonEsistente()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _log.Error(erroreFileNonEsistente);
        }
        #endregion
        #region"metodi per gli avvisi"
        /// <summary>
        /// Scrivi una string direttamente dalla posizione del codice se non è presente tra gli info di default
        /// </summary>
        /// <param name="stringaInfo"></param>
        public static void InfoCustomizable(string stringaInfo)
        {
            _log.Info(stringaInfo);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoManoGiàVuota()
        {
            _log.Info(infoManoGiaVuota);
        }
        /// <summary>
        /// Inserire la stanza in cui sta guardando l'utente.
        /// <br>Scrivo nel file di log l'azione eseguita dall'utente.</br>
        /// </summary>
        /// <param name="stanza"></param>
        public static void InfoGuardaStanza(Stanza stanza)
        {
            _log.Info(string.Format(infoGuardoStanza,stanza.nome));
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoHelp()
        {
            _log.Info(infoUtenteUsaHelp);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoPrendi()
        {
            _log.Info(infoUtenteUsaPrendi);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoLascia()
        {
            _log.Info(infoUtenteUsaLascia);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoVai()
        {
            _log.Info(infoUtenteUsaVai);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoParla()
        {
            _log.Info(infoUtenteUsaParla);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoDai()
        {
            _log.Info(infoUtenteUsaDai);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoZaino()
        {
            _log.Info(infoUtenteUsaZaino);
        }

        public static void InfoUsoAggiungi()
        {
            _log.Info(infoUtenteUsaAggiungi);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoRimuovi()
        {
            _log.Info(infoUtenteUsaRimuovi);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoPeso()
        {
            _log.Info(infoUtenteUsaPeso);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoDescrizione()
        {
            _log.Info(infoUtenteUsaDescrizione);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoTeletrasporto()
        {
            _log.Info(infoUtenteUsaTeletrasporto);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoSalva()
        {
            _log.Info(infoUtenteUsaSalva);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoCarica()
        {
            _log.Info(infoUtenteUsaCarica);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoUsoNuovaPartita()
        {
            _log.Info(infoUtenteUsaNuovaPartita);
        }
        /// <summary>
        /// Scrivo nel file di log l'azione eseguita dall'utente
        /// </summary>
        public static void InfoCaricamentoGiocatore()
        {
            _log.Info(infoCreazioneDaiSalvataggiGiocatore);
        }
        /// <summary>
        /// Inserire l'oggetto inserito in mano.
        /// <br>Scrivo nel file di log l'azione eseguita dall'utente.</br>
        /// </summary>
        /// <param name="oggetto"></param>
        public static void InfoOggettoPresoInMano(Oggetto oggetto)
        {
            _log.Info(string.Format(infoOggettoPresoInMano,oggetto.nome));
        }
        /// <summary>
        /// Inserire l'oggetto lasciato e la stanza in cui viene lasciato.
        /// <br>Scrivo nel file di log l'azione eseguita dall'utente.</br>
        /// </summary>
        /// <param name="oggetto"></param>
        /// <param name="stanza"></param>
        public static void InfoOggettoLasciatoInStanza(Oggetto oggetto,Stanza stanza)
        {
            _log.Info(string.Format(infoOggettoLasciatoNellaStanza, oggetto.nome,stanza.nome));
        }
        /// <summary>
        /// Inserire la stanza in cui si è teletrasportato il giocatore.
        /// <br>Scrivo nel file di log l'azione eseguita dall'utente.</br> 
        /// </summary>
        /// <param name="stanza"></param>
        public static void InfoStanzaTeletrasportato(Stanza stanza)
        {
            _log.Info(string.Format(infoStanzaTeletrasportato, stanza.nome));
        }
        /// <summary>
        /// Inserire la stanza in cui si è teletrasportato il giocatore.
        /// </summary>
        public static void InfoDatiSalvatiConSuccesso()
        {
            _log.Info(infoDatiSalvatiSuccesso);
        }
        /// <summary>
        /// Inserire la stanza in cui si è teletrasportato il giocatore.
        /// </summary>
        public static void InfoDatiCaricatiConSuccesso()
        {
            _log.Info(infoDatiCaricatiSuccesso);
        }
        /// <summary>
        /// Inserire la stanza in cui si è teletrasportato il giocatore.
        /// </summary>
        public static void InfoDatiGiocatoreEliminati()
        {
            _log.Info(infoDatiGiocatoreEliminati);
        }
        /// <summary>
        /// Inserire la stanza in cui si è teletrasportato il giocatore.
        /// </summary>
        public static void InfoDatiStanzeEliminati()
        {
            _log.Info(infoDatiStanzeEliminati);
        }
        #endregion
    }
}
