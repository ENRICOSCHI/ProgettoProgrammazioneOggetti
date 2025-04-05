using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.warning
{
    public  class Warning
    {
        /*MESSAGGI DI WARNING*/
        private static string superatoLimitePeso = "Non puoi inserire {0}, hai superato il limite"; //nello 0 ci andrà il nome dell'oggetto
        private static string oggettoNonPresenteNelloZaino = "ERRORE, {0} non è presente nello zaino";
        /// <summary>
        /// Warning per il superamento del limite di peso nello zaino.
        /// </summary>
        /// <param name="oggetto"></param>
        /// <returns></returns>
        public static string WarnignSuperamentoPesoMassimo(Oggetto oggetto)
        {
            return string.Format(superatoLimitePeso,oggetto.nome);
        }
        /// <summary>
        /// Warning per avvisare che l'oggetto non era nello zaino.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string WarningOggettoNonPresenteNelloZaino(Oggetto o)
        {
            return string.Format(oggettoNonPresenteNelloZaino, o.nome);
        }
    }
}
