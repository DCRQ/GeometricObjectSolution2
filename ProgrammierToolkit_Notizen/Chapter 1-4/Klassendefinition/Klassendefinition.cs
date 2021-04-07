using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Klassendefinition
{
    class Klassendefinition             //Eine Klasse ist eine Sammlung von Daten die als ein einziges Objekt zusammengefasst werden
    {                                   //Jedes Element in C# ist ein Objekt. Datentypen wie int, string und bool sind ebenfalls Objekte.
        //Eigenschaften/Properties      //Eine Klasse kann Properties (also Eigenschaften), Fields (Felder) und Methoden enthalten. Alle dieser Daten können nur von einer Klasseninstanz benutzt werden.
        private static int _intProperty;
        public static int IntProperty   //Die Eigenschaft "IntProperty" ist statisch. Soll heißen dass alle instanzen der Klasse auf ein- und das selbe objekt zugreifen
        {                               //Wenn man also zwei Instanzen der Klasse "Klassendefinition" hat und die eine Instanz "IntProperty" auf 3 setzt, dann wird die andere Instanz beim Abfragen des "IntProperty"-Werts auch 3 anzeigen obwohl es verschiedene Instanzen sind
            get { return _intProperty; }//wäre "Intproperty" nicht als statisch markiert dann wären auf beiden Instanzen verschiedene Werte. Statische Properties werden über alle Instanzen der Klasse geteilt!
            set { _intProperty = value; }
        }

        private string _stringProperty;
        public string StringProperty
        {
            get                                                 //Das "get"-Schlüsselwort ist nicht weiter als eine Methode die einen Wert zurück gibt. In diesem Fall muss der "getter" einen string-typ zurückgeben. Der getter wird nur dann ausgeführt wenn nach dem Wert des Property gefragt wird wie in "string S = StringProperty;" 
            {                                                   //Das "set"-Schlüsselwort repräsentiert eine void Methode. In diesem Fall gibt es keinen Rückgabewert. Der "setter" wir nur dann aufgerufen wenn der Property einen Wert zugewiesen wird wie z.b.: "StringProperty = "Hallo";".
                if (_stringProperty != null && !string.IsNullOrEmpty(_stringProperty))//Im setter ist "value" ein schlüsselwort das als Parameterwert gilt in dem die Reingeladenen Werte stehen. Wenn man dem Property also einen Wert zuweisen will dann steht "value" für den Wert den das Property annehmen soll.
                {
                    string beispielCode = $"String hat einen Wert: {_stringProperty}";
                    return beispielCode;
                }
                else
                {
                    return "String hat keinen Wert";
                }
            }
            set
            {
                _stringProperty = Convert.ToString(value);
            }
        }

        private object _objectProperty;
        public object ObjectProperty    //Generell ist es dem setter und dem getter egal wo man welche Werte zuordnet solange man beachtet dass im getter der richtige Rückgabewert eingerichtet ist
        {
            get { return StringProperty as Object; }//hier kann man alles einfügen was man auch in jeder x-beliebigen Methode einfügen hätte können.
            set { _objectProperty = IntProperty as Object; }//Wenn man also will, dass beim Aufruf einer Property eine Funktion ausgeführt wird dann bieten getter und setter einen validen Ansatz
        }

        private bool _boolProperty;
        public bool BoolProperty
        {
            get { return _boolProperty; } //Properties können auserdem "readonly" gemacht werden. Das kann man erreichen indem man nur den getter definiert und den setter auslässt.
        }

        private long _longProperty;
        public long LongProperty
        {
            get { return _longProperty; }
            private set { _longProperty = value; } //Man kann auch einen setter als "private" markieren. Das ermöglicht es die property innerhalb der Klasse zu bearbeiten während sie
        }

        private short _shortProperty;
        public short ShortProperty { get; set; } //Zwar kann man den getter und setter einzeln ausschreiben, jedoch bietet sich die Möglichkeit die beiden Methoden verkürzt aufzurufen
                                                 //Man muss jedoch beachten dass man auf diese Weise keine Verweise auf andere Properties oder Felder angeben kann. Bei der kurzen Schreibweise (aka Auto-Property) wird ein Property durch ein Field Unterstützt wie die erste 2 Beispiele.
                                                 //Wer auf ständiges tippen verzichten will, kann auch "propfull" eintippen und zwei mal auf die Tabulator-Taste drücken. Dies wird automatisch eine voll-ausgeschriebene Property generieren.
                                                 //Oder einfach nur "prop" um eine Auto-Implementierte Property zu generieren
                                                 //Methoden                               
        public void ClassMethod()
        {
            Console.WriteLine("Bitte geben sie eine Zahl ein.");
            if (int.TryParse(Console.ReadLine(), out int i))//Methoden die in Klassen definiert sind lassen sich auch nur von Instanzen der Klasse ausführen
            {           
                IntProperty = i;
                Console.WriteLine($"{IntProperty} + {IntProperty} = ");
                IntProperty += IntProperty;
                Console.WriteLine(IntProperty);
            }
            _ = StringClassMethod();

            ObjectClassMethod();
        }

        string StringClassMethod()
        {
            while (true)
            {
                if (_stringProperty == null)                //Properties die durch Felder Unterstützt werden die nicht als readonly-markiert wurden können auch innerhalb der gleichen Klasse aufgerufen werden. 
                {
                    Console.WriteLine("Bitte gib einen Text für die StringProperty ein."); //Da die StringProperty-Property auf das private,aber nicht als readonly-markierte Feld "_stringProperty" zugreift kann man einen Wert auf "_stringProperty" zuweisen und durch den "StringProperty"-Property wieder aufrufen.
                    _stringProperty = Console.ReadLine();   //Dabei sollte man jedoch sehr vorsichtig sein da die Property dadurch Fehleranfälliger sein könnte und man leicht in Codingfehler tappen könnte. 
                    return _stringProperty;
                }
                else
                {
                    Console.WriteLine(StringProperty);
                    break;
                }
            }
            return StringProperty;
        }

        void ObjectClassMethod()
        {
            if (ObjectProperty is String)
            {
                string methodString = ObjectProperty as String;
                Console.WriteLine(methodString);
            }
            else if (ObjectProperty is Int32)
            {
                int methodValue = (int)ObjectProperty;
                Console.WriteLine(methodValue);
            }
        }


    }
}
