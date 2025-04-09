using GiocoTestualeEsame.Oggetto_cartella;
using GiocoTestualeEsame.stanze;
using GiocoTestualeEsame.Storia;
using GiocoTestualeEsame.warning;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoTestualeEsame.comandiDiGioco
{
    public class Comandi
    {
        /// <summary>
        /// Controllo i comandi inseriti dall'utente e in caso con l'argomento passato
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="argomento"></param>
        public static void ControlloComandi(string comando, string argomento)
        {
            Comandi c = new Comandi();
            /*swtich case con tutti i casi del comando che può esser stato scelto*/
            switch (comando)
            {
                case "ciao": Console.WriteLine("ciao!");break;
                case "prendi": c.MettiNellaMano(argomento); break;
                case "guarda": c.GuardaStanza(); break;
                case "help": c.Help(); break;
                default: Warning.WarningComandoNonEsistente(comando); break;
            }
        }

        /// <summary>
        /// Attacca un personaggio con l'oggetto assegnato.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="p"></param>
        public void Attacca(Oggetto o, Personaggio p)
        {

        }

        /// <summary>
        /// L'oggetto assegnato viene messo nella mano del giocatore e quello che era in mano viene lasciato nella stanza
        /// </summary>
        /// <param name="argomento"></param>
        public void MettiNellaMano(string argomento)
        {
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            Oggetto oggettoPassato = ConvertiStringToOggetto(argomento);
            Oggetto oggettoCorrenteInMano = GestistiStatoGioco.oggettoInMano;//oggetto che ho in mano prima di cambiarlo
            if (oggettoPassato != null && GestistiStatoGioco.stanzaCorrente.ControlloOggettoNellaStanza(oggettoPassato))// se è vero...
            {
                GestistiStatoGioco.stanzaCorrente.AddOggettoNellaStanza(oggettoCorrenteInMano);// metto l'oggetto che avevo in mano nella stanza
                Giocatore.MettiOggettoInMano(oggettoPassato);// metto l'oggetto nuovo in mano
                Console.WriteLine("L'oggetto " + argomento + " è stato preso in mano");
            }
            else
            {
                Warning.WarnignOggettoNonPresenteNellaStanza();
            }
        }

        /// <summary>
        /// Mostro gli oggetti presenti nella stanza
        /// </summary>
       public void GuardaStanza()
       {
            GestistiStatoGioco.stanzaCorrente.MostraOggettiNellaStanza();
       }

       public void Help()
       {
            Console.ForegroundColor = ConsoleColor.Green;//cambio colore scritta
            Console.WriteLine("- help\n" +
                "- ciao: saluta!\n- prendi + oggetto da prendere. Prendi un oggetto presente nella stanza .Per esempio: prendi spada\n" +
                "- guarda: guarda gli oggetti presenti nella stanza");
       }
        
        /// <summary>
        /// Converto la stringa in oggetto.
        /// Ritorna un oggetto. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Oggetto ConvertiStringToOggetto(string input)
        {
            Oggetto o;
            if (!ElencoOggetti.TuttiGliOggetti.TryGetValue(input, out o))
            {
                Warning.WarningErroreDiBattitura();
                return null;
            }
            return o;
        }
    }
}
