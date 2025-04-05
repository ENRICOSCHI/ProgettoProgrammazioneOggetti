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
        /// Mostro tutti gli oggetti presenti nella stanza.
        /// </summary>
        public static void MostraOggettiNellaStanza(List<Oggetto> list_ogg)
        {
            foreach(Oggetto o in list_ogg)
            {
                Console.WriteLine("- " + o.nome + "\n");
            }
        }
    }
}
