using GiocoTestualeEsame.Oggetto_cartella;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.stanze
{
    public class Stanza
    {
        private string descrizione;

        public Stanza(string descrizione)
        {
            this.descrizione = descrizione;
        }

        /// <summary>
        ///  Mostro tutti gli oggetti presenti nella stanza.
        /// </summary>
        /// <param name="list_ogg"></param>
        public static void MostraOggettiNellaStanza(List<Oggetto> list_ogg)
        {
            foreach(Oggetto o in list_ogg)
            {
                Console.WriteLine("- " + o.nome + "\r");
            }
        }

        /// <summary>
        /// Rimuovo oggetto dalla stanza.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="list_ogg"></param>
        public static void RimuoviOggettoDallaStanza(Oggetto o,List<Oggetto> list_ogg)
        {
            list_ogg.Remove(o);
        }
    }
}
