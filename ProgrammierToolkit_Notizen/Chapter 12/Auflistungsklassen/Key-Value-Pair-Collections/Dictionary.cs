using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen
{
    class Dictionary    //Ein Dictionary ist eine Collection welche ihren Inhalt in 2 weitere Collections einteilt: KeyCollections und ValueCollections. 
                        //KeyCollections Speichern alle Keys denen man in einem Dictionary gespeichert hat. ValueCollections speichern demnach auch alle Values in einem Dictionary.
                        //Ein Dictionary speichert einen Wert(also Value) zusammen mit einem Key. Man kann nur auf den Wert zugreifen wenn man den richtigen Key zur verfügung stellt.
                        //Das Dictionary wird dann den Key benutzen um den dazugehörigen Wert ausfündig zu machen. Ähnlich wie bei einem Richtigen Wörterbuch wo man erst das zu suchende Wort braucht bevor man die Bedeutung nachlesen kann.
    {
        static int _userInput => int.Parse(Console.ReadLine());

        public static void PerformDictionaryOperations()
        {
            Dictionary<int, string> _dictionary;
            _dictionary = new Dictionary<int, string>() //So wird ein Dictionary initialisiert
            {
                {1,"Nummer_1" },
                {2,"Nummer_2" },        //Wenn man Initialwerte einträgt ist es wichtig Kommas zwischen den einzelnen Werten zu platzieren. Wenn du nicht weisst wo du grad bist dann stell den Cursor innerhalb der Klammern und drück STRG + SHIFT + SPACEBAR
                {3,"Nummer_3" },        //Ein Dictionary akzeptiert keine mehrmals vorkommenden Keys. Jeder Key muss einzigartig sein. Andernfalls wird eine Exception geworfen.
            };

            for (int i = 4; i < 10; i++)
            {
                _dictionary.Add(i, $"Nummer_{i}");  //Das Dictionary enthält auch eine "Add()" Methode. Der Key wird als erstes und das Value als zweites eingegeben. Getrennt wird wie üblich mit einem Komma.
            }
            Console.WriteLine();
            Console.WriteLine("Aufzählung der Keys:");
            foreach (int item in _dictionary.Keys)
            {
                Console.WriteLine(item);        //Natürlich sind Dictionaries sowie ihre internen Collections iterierbar. In diesem Fall greifen wir auf die KeyCollection des Dictionarys zu, welche nur die gespeicherten Keys des Dictionary enthält.
            }
            Console.WriteLine();
            Console.WriteLine("Aufzählung der Values:");
            foreach (string item in _dictionary.Values)
            {
                Console.WriteLine(item);        //Hier greifen wir auf die ValueCollection des Dictionary zu, welche alle gespeicherten Values enthält.
            }
            Console.WriteLine();
            Console.WriteLine("Aufzählung der Keys und Values:");
            foreach (KeyValuePair<int, string> item in _dictionary)
            {
                Console.WriteLine(item);        //Um auf beide Collections im Dictionary gleichzeitig zugreifen zu können benutzt man ein "KeyValuePair<>". Ein Struct-Objekt welches typisiert den Key und das Value enthält. Für nicht-typisierte Dictionary-Collections hat man früher "DictionaryEntry" genommen. Aber typisierte/generische Objekte sind in den meisten Fällen effizienter & sicherer.
            }
            Console.WriteLine();
            Console.WriteLine("Gib einen potentiellen Key-Wert ein.");
            Console.WriteLine(_dictionary.ContainsKey(_userInput));     //Das Dictionary stellt auch Suchmethoden zur verfügung. Somit kann man nicht nur Keys einfügen mit der Hoffnung dass das Dictionary kein solches Key bereits enthält, sondern man kann sie auch in if-statements einfügen dank des Rückgabewerts von "ContainsKey()"
            Console.WriteLine("Gib einen potentiellen Value-Wert ein.");
            Console.WriteLine(_dictionary.ContainsValue(Console.ReadLine()));

            Console.WriteLine();
            Console.WriteLine("Value von Key: 2 wurde verändert");
            _dictionary[2] = "Nummer_2222";     //Dictionaries können auch über einen Indexer zugegriffen werden. Als Index nimmt man dann einfach den Key und bekommt den Key-gebundenen Value zurück. Oder man überschreibt das Value, sowie das hier der Fall ist.
            Console.WriteLine($"Value von Key: 2 ist derzeit: {_dictionary[2]}");

            //Vorteile von Dictionaries:
            //-Sehr schnelles ausgeben von Values
            //-Kann beliebig angeordnet werden
            //-Nicht allzu rechenintensiv
            //-Typsicher 
            //-Vielfältig einsetzbar (z.b. als Passworteingabe[Key] für ein Konto[Value] oder einen Dateipfad[Key] zu einem Dokument[Value])

            //Nachteile von Dictionaries:
            //-Verbraucht etwas mehr Speicher als eine Liste
            //-Keys akzeptieren keine Duplikate aus Sicherheitsgründen
            //-Values können auch ohne Key über die ValueCollection zugegriffen werden, daher muss man beim implementieren eines Dictionarys besonders auf die Zugriffssicherheit bei einem Dictionary achten
            //-Das Zugreifen auf Values über die ValueCollection ist nicht so effizient wie auf das zugreifen über Keys. Da sich ein Dictionary nach dem Key schneller orientieren kann.
        }
    }
}
