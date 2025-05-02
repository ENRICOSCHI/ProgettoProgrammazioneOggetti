using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.stanze
{
    public class ElencoStanze
    {
        public static Stanza pianoTerra { get; set; } = new Stanza("piano terra","sei al piano terra, questa è una grande stanza piena di persone, oggetti e porte.");
        public static Stanza cantina { get; set; } = new Stanza("cantina","la cantina sta sotto al piano a terra, è fredda e umida... certamente non un posto accogliente.");
        public static Stanza primoPiano { get; set; } = new Stanza("primo piano", "sei al primo piano, qui c'è una vista fantastica... però guardando dalle finestre si vede una prigione, chissà se è possibile arrivarci?");
        public static Stanza salaGiochi { get; set; } = new Stanza("sala giochi", "sei nella sala giochi, però non si vede molto, è tutta buia perchè è saltata la corrente e non è quindi possibile giocare a nessun arcade.");
        public static Stanza camera { get; set; } = new Stanza("camera", "sei in camera, non c'è molto apparte qualche abbigliamento e armature.");
        public static Stanza quadroElettrico { get; set; } = new Stanza("quadro elettrico", "In questa stanza è presente il quadro elettrico dell'intero edificio, magari qui qualcuno sa come far tornare la corrente.");
        public static Stanza prigione { get; set; } = new Stanza("prigione", "Sei in prigione, questa stanza non ha porte e l'unico modo per uscirne è tramite teletrasporto.");
        public static Stanza bosco { get; set; } = new Stanza("bosco", "Sotto la camera da letto c'è un piccolo bosco incantanto");

        public static Dictionary<string, Stanza> TutteLeStanze = new Dictionary<string, Stanza>()
        {
            { pianoTerra.nome , pianoTerra },
            {cantina.nome, cantina },
            {primoPiano.nome, primoPiano },
            {salaGiochi.nome, salaGiochi },
            {camera.nome,camera },
            {quadroElettrico.nome,quadroElettrico },
            {prigione.nome,prigione }
        };
        
    }
}
