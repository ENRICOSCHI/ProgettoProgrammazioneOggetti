using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.Storia;
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

        private static Random random = new Random();

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
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            foreach (Oggetto o in oggettiNellaStanza)
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
            if(o.nome != "")
                oggettiNellaStanza.Add(o);
        }
        /// <summary>
        /// Ritorna true se l'oggetto è presente nella stanzaCorrente
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool ControlloOggettoNellaStanza(Oggetto o)
        {
            if (oggettiNellaStanza.Contains(o))
                return true;
            else return false;

        }
        /// <summary>
        /// Ottengo una stanza random
        /// </summary>
        /// <returns></returns>
        public static Stanza GetRandomStanza()
        { 
            Stanza nuovoaStanza = ElencoStanze.TutteLeStanze.ElementAt(random.Next(ElencoStanze.TutteLeStanze.Count)).Value;//con .Value accedo alla stanza
            while (nuovoaStanza == GestisciStatoGioco.stanzaCorrente)
                nuovoaStanza = ElencoStanze.TutteLeStanze.ElementAt(random.Next(ElencoStanze.TutteLeStanze.Count)).Value;
            return nuovoaStanza;
        }
    }
}
