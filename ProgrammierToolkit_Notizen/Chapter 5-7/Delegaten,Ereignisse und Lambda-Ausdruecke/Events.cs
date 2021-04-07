using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Delegaten_Ereignisse_und_Lambda_Ausdruecke;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Delegaten_Ereignisse_und_Lambda_Ausdruecke
{
    class Events
    {
        public delegate void InvalidMeasureEventHandler();                                      //Delegaten die für Events Bereit stehen haben Konventionell immer den suffix "...EventHandler();"
        public delegate void InvalidMeasureEventHandlerWithParameter(object sender);
        public event InvalidMeasureEventHandlerWithParameter InvalidMeasureWithParameter;
        public event InvalidMeasureEventHandler InvalidMeasure;                                 //Das Event wird in dieser Zeile definiert. Events sind so wie "Action" und "Func" nichts weiter als Delegaten. Das Delegat dient nur zur Typvorgabe und als Konstruktor des Events.

        private int _eventField;
        public int EventProperty                                                                //Die Eigenschaft "EventProperty" wird im Falle eines negativen Wertes ein Event auslösen
        {
            get { return _eventField; }
            set
            {
                if (value >= 0)
                {
                    _eventField = value;
                }
                else
                {
                    InvalidMeasure();                                                           //Spätestens hier wird das event nach einer Methode suchen die vorher in "FireEvent()" dem Event-Delegaten zugewiesen wurde. Falls keine gefunden wird passiert nichts im Programm.
                    _eventField = value;
                }
            }
        }

        private int _nullEventExample;
        public int NullEventExample
        {
            get { return _nullEventExample; }
            set
            {
                if (value >= 0)
                {
                    _nullEventExample = value;
                }
                else
                {
                    InvalidMeasure?.Invoke();                                                   //Der Null-Bedingungsoperator sorgt dafür dass nur dann das Event ausgeführt wird wenn dem Event eine Methode zugewiesen wurde(man sagt auch "abonnieren" dazu).
                    _nullEventExample = value;                                                  //Wenn das Event also Null ist wird sie nicht ausgeführt. Bei Null-Bedingungsoperatoren müssen Delegaten und Events jedoch mit ".invoke()" aufgerufen werden.
                }                                                                               //Man kann den Null-Bedingungsoperator auch anstelle von "if(object != null)" verwenden. z.b.: statt 'if(string != null){ Console.WriteLine($"{string.Length}"); }' kann man schreiben: Console.WriteLine($"{string?.Length}");'
            }
        }

        private int _eventMitSenderParameter;
        public int EventMitSenderParameter
        {
            get { return _eventMitSenderParameter; }
            set
            {
                if (value >= 0)
                {
                    _eventMitSenderParameter = value;
                }
                else
                {
                    InvalidMeasureWithParameter?.Invoke(this);
                    _eventMitSenderParameter = value;
                }
            }
        }
        public void FireEvents()
        {
            //Events events = new Events();
            InvalidMeasure += new InvalidMeasureEventHandler(Events_InvalidMeasure);                            //Das Event muss an die Methode gebunden werden(Schließlich sind events auch "nur" Delegaten).
            InvalidMeasure = Events_InvalidMeasure;                                                             //<- Die Kurzform^
            InvalidMeasureWithParameter = Events_InvalidMeasureWithParameter;
            while (EventProperty >= 0)
            {
                Console.WriteLine("Gib einen negativen Wert ein um ein Event zu feuern.");
                _ = int.TryParse(Console.ReadLine(), out int ergebnis);                                         //Die Discard-Variable( " _ = ") ist eine nicht-definierte dummy-Variable die vom Programm ignoriert wird. Man kann ihr beinahe alles zuordnen und sie wird trotzdem keinen Speicher belegen, da sie sowieso ignoriert wird. 
                EventProperty = ergebnis;                                                                       //Bei Statements die nicht ohne zuweisung / gleichung den Code Kompilieren, kann der Discard eine gute Lösung sein.
            }
            Console.WriteLine();
            while (NullEventExample >= 0)
            {
                Console.WriteLine("Gib noch einen negativen Wert für das NullEventBeispiel ein.");
                _ = int.TryParse(Console.ReadLine(), out int ergebnis);                          
                NullEventExample = ergebnis;                                                
            }

            Console.WriteLine("Gib einen negativen Wert ein um das Event auszulösen dass einen gültigen Wert an das aufrufende Objekt zuweist.");
            _ = int.TryParse(Console.ReadLine(), out int resultat);
            EventMitSenderParameter = resultat;
        }
        public void Events_InvalidMeasure()                                                                     //Konventionell gilt für das naming der Eventmethoden das erst der Objektname und dann der Eventname erwähnt wird. 
        {
            Console.WriteLine("Event wurde gefeuert!");
        }
       
        public void Events_InvalidMeasureWithParameter(object  sender)                                          //Mit dem Objekt "sender" kann die Methode auf die Eigenschaften des Objekts zugreifen. Wenn "sender" also vom Typ "Events" ist kann er durch Typkonvertierung auf die Properties zugreifen.            
        {                                                                                                       //Dies würde heissen dass auch ein Eventaufruf die Eigenschaften einer Klasse ändern kann, wenn die explizite Typkonvertierung stattgefunden hat.
            Console.WriteLine("Event wurde gefeuert! Bitte gib diesmal einen gültigen Wert ein.");
            _ = int.TryParse(Console.ReadLine(), out int ergebnis);
            Events events = sender as Events;
            events.EventMitSenderParameter = ergebnis;                                                          //"this.EventMitSenderParameter = ergebnis" bezieht sich ebenfalls auf das Objekt. Der Unterschied zu "sender" ist das "sender" jedes Objekt referenzieren kann während "this" sich nur auf das eine Objekt bezieht die den Begriff erwähnt. 
        }                                                                                                       //"object sender" macht das Event abstrakter und vielseitiger als ein spezifizierter Objektverweis.
        // oder
        public void Events_InvalidMeasureWithSpecifiedParameters(Events sender)                                          
        {                                                                                                       //Theoretisch könnte man anstelle von "object sender" auch "Events sender" hinschreiben und den sender direkt spezifizieren,aber dies würde das event nicht so abstrakt und von mehreren handlers nutzbar machen.
            Console.WriteLine("Event wurde gefeuert! Bitte gib diesmal einen gültigen Wert ein.");
            _ = int.TryParse(Console.ReadLine(), out int ergebnis);
            sender.EventMitSenderParameter = ergebnis;                                                           
        }
    }
}
