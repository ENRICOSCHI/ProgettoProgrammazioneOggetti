using GiocoTestualeEsame.Oggetto_cartella;
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
        private double pesoMaxZaino = 50; //peso massimo che può portare il giocatore
        private List<Oggetto> zaino = new List<Oggetto>();
        private double pesoNelloZaino = 0; //il peso che si aggiorna man mano che si aggiungono oggetti nello zaino

        public Giocatore(string nome, string cognome) : base(nome) //creo la classe con nome e cognome e poi gli passo il nome
        {
            this.cognome = cognome;
        }
        /// <summary>
        /// Aggiunge allo zaino l'oggetto che si vuole inserire. <br> N.B. puoi inserire oggetti che fanno parte dell'ELENCO OGGETTI.</br>
        /// </summary>
        /// <param name="oggetto"></param>
        public void AddZaino(Oggetto oggetto)
        {
            //se la somma tra l'oggetto da inserire e quelli già presenti nello zaino sfora il peso massimo
            if((oggetto.peso + pesoNelloZaino) > pesoMaxZaino)
            {
                Console.WriteLine(Warning.WarnignSuperamentoPesoMassimo(oggetto));
            }
            else
            {
                //l'oggetto viene inserito
                zaino.Add(oggetto);
            }
        }

    }
}
