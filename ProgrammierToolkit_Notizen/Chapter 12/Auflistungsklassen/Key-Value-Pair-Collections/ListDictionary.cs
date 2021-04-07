using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen
{
    class ListDictionary        //Eine ListDictionary ist im Prinzip ein primitives Dictionary welches nur Object-Objekte annimmt und nur bis zu einer Anzahl von maximal 10 Items/Elementen performant ist.
    {                           //Über 10 Items und die ListDictionary wird erheblich Performancelastiger 
        static Stopwatch _stopwatch = new Stopwatch();             //Die Stopwatch-Klasse bietet eine exakte Methode um vergangene Zeit zwischen Prozessen zu messen. Sie ist genauer als die DateTime-Struktur und daher für Prozessmessungen eher geeignet.
        static bool _isLoading = false;

        public static void PerformListDictionary()     //Diese Methode zeigt wie schnell eine kleine ListDictionary sein kann und wie sehr eine große ListDictionary die Performance beeinträchtigt
        {
            System.Collections.Specialized.ListDictionary listDictionary = new System.Collections.Specialized.ListDictionary(); //Da unsere Klasse ebenfalls "ListDictionary" heißt, müssen wir die ListDictionary-Collection bei vollem Namen nennen. Natürlich war das beabsichtigt um den Hintergrund zu erklären ;) Man kann gleichnamige Klassen haben solange sich der Vollständige name bzw der Namespace unterscheidet.
            Hashtable hashtable = new Hashtable();      //Ein HashTable ist im Prinzip genau wie ein Dictionary nur dass es seinen Inhalt nach dem HashCode sortiert. HashCodes sind Codes die jedes Objekt generiert. Hashtables gelten jedoch als veraltet weshalb ich nicht weiter darauf eingehen werde.

            string bigHashTableResult = null;
            string smallDictionaryResult = null;
            string bigDictionaryResult = null;

            _isLoading = true;
            Task.Run(VisibleLoadingCycle);      //Hier bedeuted "Task" eine Asynchrone Operation welches parallel zum derzeitigem Hauptprogramm abläuft. Während wir also die Methode "VisibleLoadingCycle" angestoßen haben gehen wir gleichzeitig weiter mit der nächsten Zeile.
            FillDictionaryWithContent(10, listDictionary);  // ^in diesem Kontext bedeuted "Hauptprogramm"/"Mainthread" das programm welches das Konsolenfenster/Kommandofenster verfolgt.
            WriteAllContentToConsole(listDictionary);
            _isLoading = false;
            smallDictionaryResult = _stopwatch.Elapsed.ToString();
            _stopwatch.Reset();     //Hier stellen wir die Stopwatch wieder auf 0

            listDictionary.Clear();

            Console.WriteLine("Drücke 'Enter' um das große ListDictionary zu füllen");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                _isLoading = true;
                Task.Run(VisibleLoadingCycle);
                FillDictionaryWithContent(100_000, listDictionary);
                WriteAllContentToConsole(listDictionary);
                _isLoading = false;
                bigDictionaryResult = _stopwatch.Elapsed.ToString();
                _stopwatch.Reset();
            }

            Console.WriteLine("Drücke 'Enter' um das Hashtable zu füllen");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                _isLoading = true;
                Task.Run(VisibleLoadingCycle);
                FillDictionaryWithContent(100_000, hashtable);
                WriteAllContentToConsole(hashtable);
                _isLoading = false;
                bigHashTableResult = _stopwatch.Elapsed.ToString(); //Die "stopwatch.Elapsed" Property gibt die Zeitspanne zurück die wir während der Laufzeit der Stopwatch aufgenommen haben
            }

            Console.WriteLine(smallDictionaryResult);
            Console.WriteLine(bigDictionaryResult);
            Console.WriteLine(bigHashTableResult);
        }

        private static void VisibleLoadingCycle()
        {
            int napTime = 500;
            while (_isLoading)
            {
                Thread.Sleep(napTime);
                Console.Write(".");
                if (!_isLoading)
                {
                    return;
                }
                Thread.Sleep(napTime);
                Console.Write(".");
                if (!_isLoading)
                {
                    return;
                }
                Thread.Sleep(napTime);
                Console.Write(".");
                if (!_isLoading)
                {
                    return;
                }
                Thread.Sleep(napTime);
                Console.Write(Environment.NewLine);
                if (!_isLoading)
                {
                    return;
                }
            }
        }

        private static void WriteAllContentToConsole(System.Collections.Specialized.ListDictionary listDictionary)
        {
            _stopwatch.Start();         //ab hier fängt das aufzeichnen der Zeit an
            foreach (DictionaryEntry item in listDictionary)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            _stopwatch.Stop();          //ab hier stoppen wir die Aufzeichnung
        }
        private static void WriteAllContentToConsole(Hashtable hashtable)
        {
            _stopwatch.Start();
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            _stopwatch.Stop();
        }

        private static void FillDictionaryWithContent(int limit, System.Collections.Specialized.ListDictionary listDictionary)
        {
            _stopwatch.Start();
            for (int i = 0; i < limit; i++)
            {
                listDictionary.Add(i, $"Nummer_{i}");
            }
            _stopwatch.Stop();
        }

        private static void FillDictionaryWithContent(int limit, Hashtable hashtable)
        {
            _stopwatch.Start();
            for (int i = 0; i < limit; i++)
            {
                hashtable.Add(i, $"Nummer_{i}");
            }
            _stopwatch.Stop();
        }

        //Vorteile der ListDictionary:
        //-Mitunter eine der schnellsten Dictionaries in .Net
        //-leicht zu benutzen
        
        //Nachteile der ListDictionary:
        //-performancevorteile gelten nur wenn ListDictionaries kleiner als 10 elemente gehalten werden
        //-Zeiteffizienz heißt nicht gleich das die ListDictionary nicht Rechenintensiv ist. Da sie nur Object-Objekte annimmt wird ständiges boxing & unboxing betrieben
                    //Boxing ist wenn man einen Datentyp wie z.b. einen Integer in eine Basisklasse Konvertiert, wie Z.b Object. Alle Objekte haben Object als Basisklasse und auf diese Weise verpackt man Daten hinter Basisklassen
                    //Unboxing ist wenn man den  Datentyp "Object" wieder in spezifizierte Datentypen Umwandelt. dies erreicht man ebenfalls durch Typkonvertierung.
                    //Die meisten nicht-generic Collections können nur "Object" annehmen und leiden daher unter den selben Nachteilen
    }
}
