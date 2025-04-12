using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.Storia;
using GiocoTestualeEsame.warning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Giocatore : Persona
    {
        //uso le proprietà con solo il get perchè il set lo faccio già quando creo l'oggetto
        private string nome { get; }
        private string cognome { get; } //credo per il loggin serve sapere il cognome
        public double pesoMaxZaino { get; } = 50; //peso massimo che può portare il giocatore
        private Stack<Oggetto> zaino = new Stack<Oggetto>();//lista zaino con tecnica LIFO
        private List<Oggetto> oggettiMomentaneiRimossi = new List<Oggetto>();
        public double pesoNelloZaino { get; set;} = 0; //il peso che si aggiorna man mano che si aggiungono oggetti nello zaino

        public Giocatore(string nome, string cognome) : base(nome) //creo la classe con nome e cognome e poi gli passo il nome
        {
            this.cognome = cognome;
        }

        /// <summary>
        /// Aggiunge l'oggetto raccolto in mano
        /// </summary>
        /// <param name="o"></param>
        public static void MettiOggettoInMano(Oggetto o)
        {
            GestistiStatoGioco.oggettoInMano = o;//metto l'oggetto in mano
            GestistiStatoGioco.stanzaCorrente.RimuoviOggettoDallaStanza(o);//rimuovo l'oggetto dalla stanza
        }

        /// <summary>
        /// Aggiunge allo zaino l'oggetto che si vuole inserire.
        /// Rimuove l'oggetto dalla stanza.
        /// <br> N.B. Puoi inserire oggetti che fanno parte dell'ELENCO OGGETTI.</br>
        /// <br>N.B.2 Gli oggetti vengono inseriti con lo schema LIFO</br>
        /// </summary>
        /// <param name="oggetto"></param>
        public void AddZaino(Oggetto oggetto)
        {
            //se la somma tra l'oggetto da inserire e quelli già presenti nello zaino sfora il peso massimo
            if((oggetto.peso + pesoNelloZaino) > pesoMaxZaino)
            {
                Warning.WarnignSuperamentoPesoMassimo(oggetto);
                Warning.WarningOggettoNonAggiuntoAlloZaino(oggetto);
            }
            else if (!oggetto.isRaccoglibile)//se non può essere raccolto
            {
                Warning.WarningNonPuoiRaccogliereOgetto();
            }
            else
            {
                //l'oggetto viene inserito
                zaino.Push(oggetto);
                pesoNelloZaino += oggetto.peso;//aggiorno il peso
                GestistiStatoGioco.stanzaCorrente.RimuoviOggettoDallaStanza(oggetto);//siccome ho messo l'oggetto nello zaino, lo tolgo dalla stanza
                Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
                Console.WriteLine("Oggetto inserito nello zaino");
            }
        }
        /// <summary>
        /// Controlla se l'oggetto è presente nello zaino.
        /// <br>Viene rimosso l'oggetto indicato.</br>
        /// <br> N.B. Puoi inserire oggetti che fanno parte dell'ELENCO OGGETTI.</br>
        /// </summary>
        /// <param name="oggetto"></param>
        public void RemoveZaino(Oggetto oggetto)
        {
            //controllo se l'oggetto è presente nello zaino
            if (zaino.Contains(oggetto)) // contaians controlla se l'oggetto è presente e ritorna o false o true
            {
                pesoNelloZaino -= oggetto.peso;
                /*Pensare come tirare fuori l'oggetto desiderato!!!!*/
                Oggetto o = null;
                do
                {
                    o = zaino.Pop();//rimuovo oggetto dalla lista
                    oggettiMomentaneiRimossi.Add(o);
                } while (o.nome != oggetto.nome);
                oggettiMomentaneiRimossi.Remove(o);//rimuovo l'oggetto che ho appena tolto dallo zaino
                GestistiStatoGioco.stanzaCorrente.AddOggettoNellaStanza(o);//agiungo l'oggetto rimosso nella stanza
                foreach (Oggetto ogg in oggettiMomentaneiRimossi)
                {
                    AddZaino(ogg);//rimetto gli oggetti che ho tolto
                }
                oggettiMomentaneiRimossi.Clear();//svuoto la lista
                Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
                Console.WriteLine("Oggetto rimosso dallo zaino");
            }
            else
            {
                Warning.WarningOggettoNonPresenteNelloZaino(oggetto);
            }
        }

        public void GuardaOggettiNelloZaino()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//cambio colore scritta
            int i = 1;
            foreach(Oggetto o in zaino)
            {
                Console.WriteLine($"{i}) {o.nome}");
                i++;//aggiorno il count per l'elenco
            }
        }

        /// <summary>
        /// Ritorna true se l'oggetto è presente nello zaino
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool IsOggettoNelloZaino(Oggetto o)
        {
            if (zaino.Contains(o))
            {
                return true;
            }
            return false;
        }
    }
}
