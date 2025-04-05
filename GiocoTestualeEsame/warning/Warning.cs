using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.warning
{
    public  class Warning
    {
        private static string superatoLimitePeso = "Non puoi inserire {0}, hai superato il limite"; //nello 0 ci andrà il nome dell'oggetto

        /// <summary>
        /// Warning per il superamento del limite di peso nello zaino
        /// </summary>
        /// <param name="oggetto"></param>
        /// <returns></returns>
        public static string WarnignSuperamentoPesoMassimo(Oggetto oggetto)
        {
            return string.Format(superatoLimitePeso,oggetto.nome);
        }
    }
}
