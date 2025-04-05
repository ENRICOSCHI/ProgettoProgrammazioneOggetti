using GiocoTestualeEsame.Oggetto_cartella;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.stanze
{
    public class Casa : Stanza
    {
        /*inserire oggetti presenti nella stanza*/
        private List<Oggetto> oggettiPresentiNellaCasa = new List<Oggetto>
        {
            ElencoOggetti.scarpa,
            ElencoOggetti.spada //nell'ultimo oggetto non va la virgola
        };

        public string descrizione { get; }

        public Casa(string descrizione): base(descrizione)
        {
        }


        /// <summary>
        /// Mostra gli oggetti presenti nella casa.
        /// </summary>
        public void MostraOggettiNellaStanza()
        {
            Stanza.MostraOggettiNellaStanza(oggettiPresentiNellaCasa);
        }

        /// <summary>
        /// Rimuovo oggetto dalla stanza.
        /// </summary>
        /// <param name="o"></param>
        public void RimuoviOggettoDallaStanza(Oggetto o)
        {
            Stanza.RimuoviOggettoDallaStanza(o, oggettiPresentiNellaCasa);
        }
    }
}
