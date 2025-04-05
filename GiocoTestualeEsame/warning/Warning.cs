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
        private static string oggettoNonRaccoglibile = "Non puoi raccogliere questo oggetto!\r";
        private static string oggettoNonAggiuntoAlloZaino = "{0} non è stato aggiunto nello zaino\r";
        private static string erroreDiBattitura = "Attenzione, il nome inserito è sbagliato\r";





        /// <summary>
        /// Warning per il superamento del limite di peso nello zaino.
        /// </summary>
        /// <param name="oggetto"></param>
        /// <returns></returns>
        public static void WarnignSuperamentoPesoMassimo(Oggetto oggetto)
        {
            Console.WriteLine(string.Format(superatoLimitePeso,oggetto.nome));
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto non era nello zaino.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static void WarningOggettoNonPresenteNelloZaino(Oggetto o)
        {
            Console.WriteLine(string.Format(oggettoNonPresenteNelloZaino, o.nome));
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto che si cercava di raccogliere non è raccoglibile
        /// </summary>
        /// <returns></returns>
        public static void WarningNonPuoiRaccogliereOgetto()
        {
            Console.WriteLine(oggettoNonRaccoglibile);
        }

        /// <summary>
        /// Warning per avvisare che l'oggetto non è stato aggiunto nello zaino
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static void WarningOggettoNonAggiuntoAlloZaino(Oggetto o)
        {
            Console.WriteLine(string.Format(oggettoNonAggiuntoAlloZaino, o.nome));
        }

        /// <summary>
        /// Warning per avvisare l'utente dell'errore di battitura nell'input
        /// </summary>
        public static void WarningErroreDiBattitura()
        {
            Console.WriteLine(erroreDiBattitura);
        }
    }
}
