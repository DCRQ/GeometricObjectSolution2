using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen.Key_Value_Pair_Collections
{
    class HybridCollection  //Eine HybridCollection wie z.b. ein HybridDictionary ist eine Collection welche sich wie eine ListDictionary verhält wenn die Collection unter 10 Elemente groß ist, und sich wie ein Hashtable verhält wenn die Collection über 10 Elemente besitzt 
    {                       //Wann sich das HybridDictionary vom ListDictionary zum Hashtable umwandelt wird nicht preisgegeben da es automatisch passiert
        static HybridDictionary _hybridDictionary = new HybridDictionary();
        static Random _rng = new Random();     //Die Random-Klasse hat die Fähigkeit eine Zufallszahl zu generieren mit der Random.Next()-Methode
        public static void PerformHybridDictionary()
        {
            FillDictionaryWithContent(6);
            WriteContentToConsole();

            _hybridDictionary.Clear();

            FillDictionaryWithContent(100);
            WriteContentToConsole();
        }

        private static void FillDictionaryWithContent(int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                while (true)        //Diese While-Schleife wird so lange versuchen eine Zahl zu generieren bis die HybridDictionary den Key annimmt. Da ein Dictionary nur ein Key aufnehmen kann und keine Keys mit dem gleichen Wert annimmt wird es eine Exception werfen sobald es merkt dass dieser Key bereits in der Dictionary vorhanden ist.
                {
                    int rng = _rng.Next(limit);
                    try
                    {
                        _hybridDictionary.Add(rng, $"Nummer_{rng}");
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private static void WriteContentToConsole()
        {
            foreach (DictionaryEntry item in _hybridDictionary)     //Da die HybridDictionary keine Generic-Collection ist muss sie anstelle von "KeyValuePair<>" bei einer enumeration auf "DictionaryEntry" zurückgreifen
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            };
        }

        //Vorteile einer HybridDictionary:
        //-Kann flexibel zwischen Hashtable und ListDictionary wechseln
        //-Erleichtert Optimisierung 
        //-Wenig Zeitaufwand bei gleichbleibender Performance

        //Nachteile einer HybridDictionary:
        //-Erbt alle Nachteile einer ListDictionary und eines Hashtables
        

    }
}
