using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.Storia
{
    public class GestisciStatoGioco
    {

        //gestisci la stanza corrente
        public static Stanza stanzaCorrente { get; set; } = ElencoStanze.pianoTerra;
        public static Oggetto oggettoInMano { get; set; } = ElencoOggetti.manoVuota; //non ha niente all'inizio in mano
        public static Giocatore giocatoreCorrente { get; set; } //il giocatore lo creo da StoriaPrincipale
        public void CreateGiocatore(string nome,string cognome)
        {
            giocatoreCorrente = new Giocatore(nome, cognome);//creo giocatore
        }
    }
}
