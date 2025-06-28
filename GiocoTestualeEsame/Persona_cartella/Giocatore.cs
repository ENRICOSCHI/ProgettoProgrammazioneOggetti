using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.Persona_cartella;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.Storia;
using GiocoTestualeEsame.warning;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame
{
    public class Giocatore
    {
        //uso le proprietà con solo il get perchè il set lo faccio già quando creo l'oggetto
        public string nome { get;  }
        public string cognome { get;  } //credo per il loggin serve sapere il cognome
        public double pesoMaxZaino { get; } //peso massimo che può portare il giocatore
        private Stack<Oggetto> zaino = new Stack<Oggetto>();//lista zaino con tecnica LIFO
        private List<Oggetto> oggettiMomentaneiRimossi = new List<Oggetto>();
        public double pesoNelloZaino { get; set;} = 0; //il peso che si aggiorna man mano che si aggiungono oggetti nello zaino

        public Giocatore(string nome, string cognome,double pesoMaxZaino) //creo la classe con nome e cognome e peso max zaino
        {
            this.nome = nome;
            this.cognome = cognome;
            this.pesoMaxZaino = pesoMaxZaino;
        }
        /// <summary>
        /// Creo il giocatore utilizzando la classe SalvattaggiGiocatore e ricarica gli oggetti presenti nello zaino e in mano
        /// </summary>
        /// <param name="sg"></param>
        /// <returns></returns>
        public static Giocatore CreoGiocatoreDaSalvattaggiGiocatore(SalvataggiGiocatore sg)
        {
            Giocatore g = GestisciStatoGioco.LoadGiocatoreEsistente(sg.Nome, sg.Cognome,sg.pesoMassimoZaino); //creo il giocatore dai file caricati
            /*RICARICO OGGETTI NELLO ZAINO*/
            foreach (string nomeOggetto in sg.Zaino)
            {
                if (ElencoOggetti.TuttiGliOggetti.TryGetValue(nomeOggetto, out Oggetto oggetto))
                {
                    g.AddZaino(oggetto); //uso il metodo già creato per inserire gli oggetti nello zaino
                }
            }
            /*RICARICO L'OGGETTO IN MANO*/
            if (!string.IsNullOrEmpty(sg.OggettoInMano) && ElencoOggetti.TuttiGliOggetti.TryGetValue(sg.OggettoInMano, out Oggetto oggettoInMano))
            {
                GestisciStatoGioco.oggettoInMano = oggettoInMano;
            }
            else
            {
                GestisciStatoGioco.oggettoInMano = ElencoOggetti.manoVuota;
            }
            /*CARICO LA STANZA IN CUI ERO*/
            if(ElencoStanze.TutteLeStanze.TryGetValue(sg.stanzaAttuale, out Stanza stanzaSalvata))
            {
                GestisciStatoGioco.stanzaCorrente = stanzaSalvata;
            }
            Warning.InfoCaricamentoGiocatore();
            return g;
        }
        /// <summary>
        /// Importo i dati da caricare nella classe SalvattiGiocatore
        /// </summary>
        /// <returns></returns>
        public SalvataggiGiocatore ImportoDatiCorrenti()
        {
            return new SalvataggiGiocatore { Nome = this.nome,Cognome=this.cognome,Zaino = this.zaino.Select(o=> o.nome).ToList(), OggettoInMano = GestisciStatoGioco.oggettoInMano?.nome, stanzaAttuale = GestisciStatoGioco.stanzaCorrente.nome, pesoMassimoZaino = pesoMaxZaino};
        }
        /// <summary>
        /// Aggiunge l'oggetto raccolto in mano
        /// </summary>
        /// <param name="o"></param>
        public void MettiOggettoInMano(Oggetto o)
        {
            GestisciStatoGioco.oggettoInMano = o;//metto l'oggetto in mano
            GestisciStatoGioco.stanzaCorrente.RimuoviOggettoDallaStanza(o);//rimuovo l'oggetto dalla stanza
        }

        /// <summary>
        /// Lascio l'oggetto presente nella mano nella stanza e la manon diventa vuota
        /// </summary>
        public void LasciOggettoDallaMano()
        {
            GestisciStatoGioco.stanzaCorrente.AddOggettoNellaStanza(GestisciStatoGioco.oggettoInMano);
            GestisciStatoGioco.oggettoInMano = ElencoOggetti.manoVuota; 
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            Console.WriteLine("Oggetto lasciato nella stanza");
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
                if (!GestisciStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(oggetto))//se non è presente nella stanza...
                {
                    GestisciStatoGioco.stanzaCorrente.AddOggettoNellaStanza(oggetto);//vuol dire che era un regalo di un personaggio e quindi lo lascio nella stanza..
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Oggetto lasciato nella stanza");
                    Warning.InfoOggettoLasciatoInStanza(oggetto,GestisciStatoGioco.stanzaCorrente);
                }
            }
            else if (!oggetto.isRaccoglibile)//se non può essere raccolto
                Warning.WarningNonPuoiRaccogliereOggetto();
            else
            {
                //l'oggetto viene inserito
                zaino.Push(oggetto);
                pesoNelloZaino += oggetto.peso;//aggiorno il peso
                GestisciStatoGioco.stanzaCorrente.RimuoviOggettoDallaStanza(oggetto);//siccome ho messo l'oggetto nello zaino, lo tolgo dalla stanza
                Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
                Console.WriteLine($"{oggetto.nome} inserito nello zaino");
                Warning.InfoCustomizable($"{oggetto.nome} inserito nello zaino");
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
                pesoNelloZaino -= oggetto.peso;//tolgo il peso dell'oggetto principale
                Oggetto o = zaino.Pop();
                while (o.nome != oggetto.nome)
                {
                    pesoNelloZaino -= o.peso;//tolgo momentaneamente il peso degli oggetti per poi riaggionralo con AddZaino
                    oggettiMomentaneiRimossi.Add(o);
                    o = zaino.Pop();//rimuovo oggetto dalla lista
                }
                oggettiMomentaneiRimossi.Remove(o);//rimuovo l'oggetto che ho appena tolto dallo zaino
                GestisciStatoGioco.stanzaCorrente.AddOggettoNellaStanza(o);//aggiungo l'oggetto rimosso nella stanza
                foreach (Oggetto ogg in oggettiMomentaneiRimossi)
                {
                    AddZaino(ogg);//rimetto gli oggetti che ho tolto
                }
                oggettiMomentaneiRimossi.Clear();//svuoto la lista
                Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
                Console.WriteLine($"{oggetto.nome} rimosso dallo zaino");
                Warning.InfoCustomizable($"{oggetto.nome} rimosso dallo zaino");
            }
            else
                Warning.WarningOggettoNonPresenteNelloZaino(oggetto);
        }
        /// <summary>
        /// Rimuovo un oggetto per sempre dal gioco
        /// </summary>
        /// <param name="oggetto"></param>
        public void RimuoviSenzaLasciareNellaStanza(Oggetto oggetto)
        {
            //controllo se l'oggetto è presente nello zaino
            if (zaino.Contains(oggetto)) // contaians controlla se l'oggetto è presente e ritorna o false o true
            {
                pesoNelloZaino -= oggetto.peso;//tolgo il peso dell'oggetto principale
                Oggetto o = zaino.Pop();
                while (o.nome != oggetto.nome)
                {
                    pesoNelloZaino -= o.peso;//tolgo momentaneamente il peso degli oggetti per poi riaggionralo con AddZaino
                    oggettiMomentaneiRimossi.Add(o);
                    o = zaino.Pop();//rimuovo oggetto dalla lista
                } 
                oggettiMomentaneiRimossi.Remove(o);//rimuovo l'oggetto che ho appena tolto dallo zaino
                foreach (Oggetto ogg in oggettiMomentaneiRimossi)
                {
                    AddZaino(ogg);//rimetto gli oggetti che ho tolto
                }
                oggettiMomentaneiRimossi.Clear();//svuoto la lista
                Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
                Console.WriteLine($"{oggetto.nome} rimosso dallo zaino");
                Warning.InfoCustomizable($"{oggetto.nome} rimosso dallo zaino");
            }
            else
                Warning.WarningOggettoNonPresenteNelloZaino(oggetto);
        }
        /// <summary>
        /// Elenca gli oggetti presenti nello zaino
        /// </summary>
        public void GuardaOggettiNelloZaino()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//cambio colore scritta
            int i = 1;
            foreach(Oggetto o in zaino)
            {
                Console.WriteLine($"{i}) {o.nome}");
                i++;//aggiorno il count per l'elenco
            }
            if(i == 1)// se i non è stato aggiornato allora lo zaino è vuoto
            {
                Console.WriteLine("zaino vuoto");
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
        /// <summary>
        /// Ritorna true se l'oggetto passato è in mano
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool IsOggettoInMano(Oggetto o)
        {
            if(o.nome == GestisciStatoGioco.oggettoInMano.nome)
            {
                return true; //l'oggetto è in mano
            }
            else
            {
                return false;// l'oggetto non è in mano
            }
        }
    }
}
