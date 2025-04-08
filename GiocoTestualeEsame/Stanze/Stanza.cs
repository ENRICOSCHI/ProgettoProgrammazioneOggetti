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
        public string nome { get; }
        public string descrizione { get; }
        /*inserire oggetti presenti nella stanza (si riemprirà con addOggettiNellaStanza)*/
        private List<Oggetto> oggettiNellaStanza = new List<Oggetto>
        {
        };

        public Stanza(string nome,string descrizione)
        {
            this.nome = nome;
            this.descrizione = descrizione;
        }

        /// <summary>
        ///  Mostro tutti gli oggetti presenti nella stanza.
        /// </summary>
        /// <param name="list_ogg"></param>
        public void MostraOggettiNellaStanza()
        {
            foreach(Oggetto o in oggettiNellaStanza)
            {
                Console.WriteLine("- " + o.nome + "\r");
            }
        }

        /// <summary>
        /// Rimuovo oggetto dalla stanza.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="list_ogg"></param>
        public void RimuoviOggettoDallaStanza(Oggetto o)
        {
            oggettiNellaStanza.Remove(o);
        }
        /// <summary>
        /// Aggiungo oggetto alla stanza.
        /// </summary>
        /// <param name="o"></param>
        public void AddOggettoNellaStanza(Oggetto o)
        {
            oggettiNellaStanza.Add(o);
        }
    }
}
