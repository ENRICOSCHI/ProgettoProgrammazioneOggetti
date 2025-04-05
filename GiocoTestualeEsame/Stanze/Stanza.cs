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

        public Stanza(List<Oggetto> oggettiPresentiNellaStanza)
        {
            
        }
        /// <summary>
        /// Mostro tutti gli oggetti presenti nella stanza.
        /// </summary>
        public void MostraOggettiNellaStanza()
        {
            foreach(object o in oggettiPresentiNellaStanza)
            {
                Console.WriteLine(o.ToString());
            }
        }
    }
}
