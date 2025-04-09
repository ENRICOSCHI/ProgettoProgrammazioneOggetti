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
        /*MESSAGGI DI WARNING*/
        private static string superatoLimitePeso = "Non puoi inserire {0}, hai superato il limite\r"; //nello 0 ci andrà il nome dell'oggetto
        private static string oggettoNonPresenteNelloZaino = "ERRORE, {0} non è presente nello zaino\r";
        private static string oggettoNonPresenteNellaStanza = "ERRORE, {0} non è presente nella stanza\r";
        private static string oggettoNonRaccoglibile = "Non puoi raccogliere questo oggetto!\r";
        private static string oggettoNonAggiuntoAlloZaino = "{0} non è stato aggiunto nello zaino\r";
        private static string erroreDiBattitura = "Attenzione, il nome inserito è sbagliato\r";
        private static string comandoErrato = "Attenzione, il comando {0} inserito non esiste\r";





        /// <summary>
        /// Warning per il superamento del limite di peso nello zaino.
        /// </summary>
        /// <param name="oggetto"></param>
        /// <returns></returns>
        public static void WarnignSuperamentoPesoMassimo(Oggetto oggetto)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(string.Format(superatoLimitePeso,oggetto.nome));
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
        public static void WarningNonPuoiRaccogliereOgetto()
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

        public static void WarnignOggettoNonPresenteNellaStanza(Oggetto o)
        {
            Console.ForegroundColor = ConsoleColor.Red;//cambio colore scritta
            Console.WriteLine(string.Format(oggettoNonPresenteNellaStanza, o.nome));
        }
    }
}
