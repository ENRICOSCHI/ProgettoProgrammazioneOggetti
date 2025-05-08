using GiocoTestualeEsame.Storia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.warning
{
    public  class Warning
    {
        #region"stringhe per i messaggi di avviso"
        /*MESSAGGI DI WARNING*/
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

        #region"stringhe per il logging"
        /*MESSAGGI DI ERRORE*/
        public static string errorecomandoInesistente_LOG = "ERRORE, inserito comando errato.";
        public static string erroreOggettoPassato_LOG = "ERRORE, la stringa passata non puo' diventare oggetto";
        public static string erroreFileNonEsistente_LOG = "ERRORE, file di salvataggio non esistente";
        public static string erroreDiBattitura_LOG = "ERRORE,il nome inserito nel terminale non esiste";
        public static string erroreoggettoNonRaccoglibile_LOG = "ERRORE,oggetto non raccoglibile.";
        public static string erroreoggettoNonAggiuntoAlloZaino_LOG = "ERRORE, oggetto non aggiunto allo zaino.";
        public static string superatoLimitePeso_LOG = "Superato limite del peso.";
        public static string oggettoNonPresenteNelloZaino_LOG = "Oggetto non è presente nello zaino.";
        public static string oggettoNonPresenteNellaStanza_LOG = "Oggetto non è presente nella stanza.";
        public static string oggettoNonInMano_LOG = "Oggetto non è in mano.";
        public static string direzioneErrata_LOG = "Passaggio non presente nella stanza.";
        /*MESSAGGI DI AVVISO*/
        public static string infoManoGiaVuota = "Info, si è provato a rimuovere un oggetto da una mano già vuota.";
        public static string infoGuardoStanza = "Info, l'utente guarda la stanza.";
        public static string infoUtenteUsaHelp = "Info, l'utente ha usato il comando help.";
        public static string infoUtenteUsaPrendi = "Info, l'utente ha usato il comando prendi.";
        public static string infoUtenteUsaLascia = "Info, l'utente ha usato il comando lascia.";
        public static string infoUtenteUsaVai = "Info, l'utente ha usato il comando vai.";
        public static string infoUtenteUsaParla = "Info, l'utente ha cambiato parla.";
        public static string infoUtenteUsaDai = "Info, l'utente ha usato il comando dai.";
        public static string infoUtenteUsaZaino = "Info, l'utente ha usato il comando zaino.";
        public static string infoUtenteUsaAggiungi = "Info, l'utente ha usato il comando aggiugni.";
        public static string infoUtenteUsaRimuovi = "Info, l'utente ha usato il comando rimuovi.";
        public static string infoUtenteUsaPeso = "Info, l'utente ha usato il comando peso.";
        public static string infoUtenteUsaDescrizione = "Info, l'utente ha usato il comando descrizione.";
        public static string infoUtenteUsaTeletrasporto = "Info, l'utente ha usato il comando teletrasporto.";
        public static string infoUtenteUsaSalva= "Info, l'utente ha usato il comando salva.";
        public static string infoUtenteUsaCarica = "Info, l'utente ha usato il comando carica.";
        public static string infoUtenteUsaNuovaPartita= "Info, l'utente ha usato il comando nuova partita.";
        public static string infoCreazioneDaiSalvataggiGiocatore = "Info, dati giocatore caricati nella classe SalvataggiGiocatore.";

        #endregion

        #region "metodi per il warning"
        /// <summary>
        /// Warning per il superamento del limite di peso nello zaino.
        /// </summary>
        /// <param name="oggetto"></param>
        /// <returns></returns>
        public static void WarnignSuperamentoPesoMassimo(Oggetto oggetto)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(string.Format(superatoLimitePeso,oggetto.nome,GestisciStatoGioco.giocatoreCorrente.pesoNelloZaino));
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto non era nello zaino.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static void WarningOggettoNonPresenteNelloZaino(Oggetto o)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(string.Format(oggettoNonPresenteNelloZaino, o.nome));
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto che si cercava di raccogliere non è raccoglibile
        /// </summary>
        /// <returns></returns>
        public static void WarningNonPuoiRaccogliereOggetto()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(oggettoNonRaccoglibile);
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto non è stato aggiunto nello zaino
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static void WarningOggettoNonAggiuntoAlloZaino(Oggetto o)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(string.Format(oggettoNonAggiuntoAlloZaino, o.nome));
        }

        /// <summary>
        /// Warning per avvisare l'utente dell'errore di battitura nell'input
        /// </summary>
        public static void WarningErroreDiBattitura()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(erroreDiBattitura);
        }
        /// <summary>
        /// Warning per aver inserito il comando sbalgiato nel terminale
        /// </summary>
        /// <param name="input"></param>
        public static void WarningComandoNonEsistente(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(string.Format(comandoErrato,input));
        }

        /// <summary>
        /// Warning per avvisare l'utente che l'oggetto non è presente nella stanza
        /// </summary>
        public static void WarnignOggettoNonPresenteNellaStanza()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(oggettoNonPresenteNellaStanza);
        }

        /// <summary>
        /// Warning per avvisare che la direzione indicata non è presente nella scena
        /// </summary>
        public static void WarningDirezioneNonPresenteNellaScena()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(direzioneErrata);
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto indicato non è in mano
        /// </summary>
        public static void WarningOggettoNonInMano()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(oggettoNonInMano);
        }
        /// <summary>
        /// Warning per avvisare che il casting eseguito è errato
        /// </summary>
        public static void WarningErroreCasting()
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(erroreOggettoPassato);
        }
        public static void WarningErroreFileNonEsistente()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erroreFileNonEsistente);
        }
        #endregion
    }
}
