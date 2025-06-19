using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace GiocoTestualeEsame.Configurazioni
{
    public class ConfigurazioneGioco
    {
        public double PesoMaxZaino { get; set; } = 10.0; //peso default

        /// <summary>
        /// Carico configurazione per avere un peso differente dello zaino --> di 20 insierito nel config.json
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ConfigurazioneGioco CaricaConfigurazione(string path = "config.json")
        {
            //Se il file non esiste nel percorso specificato (default: config.json)
            if (!File.Exists(path))
            {
                //Stampo un messaggio informativo e restituisco una configurazione con valori di defaul
                Console.WriteLine("File di configurazione non trovato. Uso impostazioni di default.");
                return new ConfigurazioneGioco(); //creo e ritorno un oggetto con valori predefiniti (quindi con PesoMaxZaino = 10)
            }

            //Leggo tutto il contenuto del file json come stringa
            string json = File.ReadAllText(path);

            try
            {
                //Provo a deserializzare la stringa json in un oggetto ConfigurazioneGioco
                return JsonSerializer.Deserialize<ConfigurazioneGioco>(json) ?? new ConfigurazioneGioco();
                //Se la deserializzazione fallisce, restituisco null e quindi creo un oggetto di default
            }
            catch
            {
                //Se avviene un errore nel parsing (es. file json con qualche errore), stampo l'errore e restituisco configurazione di default
                Console.WriteLine("Errore nel parsing di config.json. Uso impostazioni di default.");
                return new ConfigurazioneGioco();
            }
        }
    }
}
