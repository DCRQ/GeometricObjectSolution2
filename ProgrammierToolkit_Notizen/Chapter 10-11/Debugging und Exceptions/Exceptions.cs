using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_10.Debugging_und_Exceptions
{
    class Exceptions
    {
        //Exceptions sind Fehlermeldungen die während der Laufzeit ausgelöst werden.
        //Sie können bei jeder Methode auftreten bei jeglichen Operationen auftreten und müssen immer behandelt (ugs. "handled") werden damit Ihr Programm nicht abstürzt
        //Zudem könnt Ihr eure eigenen Exceptions schreiben je nach dem welche Ihr für sinnvoll findet.
        public void PerformExceptionHandling()
        {
            var array = new int[] { 1 };
            try
            {
                Console.WriteLine($"Bitte gib eine Zahl ein um eine OutOfMemoryException auszulösen,{Environment.NewLine} einen Buchstaben um eine FormatException auszulösen{Environment.NewLine} oder nichts um eine ArgumentNullException auszulösen.");
                string input = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))        //Hier wird über die statischen String-Methoden geprüft ob der eingegebene string entweder null oder leer/mit leerzeichen gefüllt ist
                {                                                                           //wenn ja, dann wird versucht "null" in eine Zahl zu parsen, was zu einer ArgumentNullException führt und das Programm abbricht
                    int.Parse(null);
                }

                int.Parse(input);                                                           //wenn input jedoch einen legitimen Wert enthält dann wird tatsächlich versucht diesen Wert in einen Zahlenwert umzuwandeln
                                                                                            //Falls der user eine Zahl in form eines Strings eingegeben haben sollte dann wird der String-Wert ganz normal in einen Int-Wert umgewandelt                
                                                                                            //Falls der user jedoch einen Buchstaben oder ein anderes Zeichen eingegeben haben sollte, dann wird eine FormatException geworfen und das Programm stürtzt ab

                for (int i = 0; true; i++)
                {                                                                           //Wenn input korrekt geparsed wurde dann wird diese Endlosschleife dafür sorgen,dass die variable "i" so lange hochgezählt wird bis dem PC der Speicher ausgeht
                    throw new OutOfMemoryException("Oh nein! Die Endlosschleife verbraucht den ganzen Speicher!");//<-- In diesem Fall wird eine OutOfMemoryException geworfen. Bei einer simplen schleife dauert das jedoch sehr lange deshalb werfe ich die Exception manuell wie hier demonstriert  
                }                                                                           //Wenn man eine Methode des .Net Frameworks benutzt und mit der Maus drüber hält dann werden alle möglichen Exceptions angezeigt. 
            }                                                                               //Bei manchen sachen wie bei Keywords oder Schleifen gilt die Regel nicht und man muss selber nach Möglichkeiten suchen wie man das eigene Programm sabotieren kann um potentielle Exceptions zu vermeiden.
                                                                                            //Meistens hilft VS2019 dabei potentielle Exceptions zu erkennen indem es Warnungen anzeigt die z.b. sagen dass die möglichkeit besteht dass >=70% der Rechenleistung bereits verbraucht wird. Für die meisten Hardware & Software Diagnose-Tools bzw Optimierungshilfen ist der "Diagnostics" Namespace sehr hilfreich
            catch (ArgumentNullException argEx)
            {
                Console.WriteLine($"{argEx.GetType()} {argEx.Message}");
            }
            catch (IndexOutOfRangeException indexOOREx)
            {
                Console.WriteLine($"{indexOOREx.GetType()} {indexOOREx.Message}");
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine($"{formatEx.GetType()} {formatEx.Message}");
            }
            catch (OutOfMemoryException OOMEx) when (array is Array)        //Das "when" Keyword ist ein Ausnahmefilter der alle Exceptions dieser Art behandelt welche eine bestimmte Bedingung erfüllt. (kurzgesagt muss im "when" teil ein boolsches Ergebnis stehen damit die Exception gehandled wird)
            {                                                               //dieses "when" Keyword bspw wird die OutOfMemoryException erst handlen wenn die variable "array" auch WIRKLICH vom Datentyp "Array" ist
                Console.WriteLine($"{OOMEx.GetType()} {OOMEx.Message}");
                try                                                         //Natürlich kann es sein, dass innerhalb eines catch-blocks eine weiter Exception ausgelöst wird, daher können wir Try-catch blöcke verschachteln um das Vorzubeugen
                {
                    array[2] = 3;                                           //Hier wird z.b. eine IndexOutOfRangeException geworfen welche innerhalb des catch-blocks einer OutOfMemoryException ausgelöst wird. IndexOutOfRangeException daher weil hier versucht wird den 3. Wert eines Arrays zuzugreifen, obwohl der Array nur 1 Wert "groß" ist.
                }
                catch (IndexOutOfRangeException indexOOREx)
                {
                    Console.WriteLine($"{indexOOREx.GetType()} {indexOOREx.Message}");
                }
            }
            catch (Exception ex)                    //Das catchen von allen Exceptions kann entweder explizit mit catch(Exception) erfolgen oder implizit indem man die Parameter-Klammern auslässt
            {                                       //Der Compiler wird sich auch HIER beschweren, dass eine der Option genügt und das bereits alle Arten von Exceptions von eine der catch-Methoden abgefangen werden
                Console.WriteLine(ex.Message);      //Jedoch ist der Fehler nicht schwerwiegend genug um das Programm am Starten zu verhindern
            }
            catch                                   //Man muss allerdings anmerken, dass bei dem impliziten abfangen aller Exceptions, das ausgeben der abgefangenen Exception nicht möglich ist da sie nicht über den Parameter der catch-Methode in den Codeblock übergeben wird
            {
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            try
            {
                throw new Exception();              //Hier wird eine allgemeine Exception geworfen
            }
            catch
            {
                Console.WriteLine("Exception wurde hier gefangen");     //Hier wird jede Art von Exception abgefangen
                Console.WriteLine("Füge hier Aufräumarbeiten ein");     //Generell sollten Catch-Blöcke genutzt werden um Aufräumarbeiten zu tätigen. Da Exceptions ein Programm zum Absturz zwingen kann es sein dass man mitten in einer Operation abstürzt und wichtige Daten verloren gehen könnten
            }                                                           //Aus diesem Grund sollte man in Catch-Blöcken dafür sorgen dass möglichst wenig Daten verloren gehen. Z.b. kann man in einem Catch-Block noch ein letztes mal etwas in eine Logdatei loggen oder das letzte mal programmatisch abspeichern.
            finally
            {
                Console.WriteLine("Dieser Code wird garantiert ausgeführt");    //In einem finally-Block wird der Code IMMER ausgeführt, egal ob eine Exception geworfen wurde oder nicht.
                Console.WriteLine("Bei Bedarf noch mehr Aufräumarbeitn durchführen");   //Bei Bedarf kann man Aufräumarbeiten auch hier durchführen, ist aber nicht zu empfehlen wenn die Aufräumarbeiten zu Performancelastig werden.
            }                                                                           //Objekte mit IDisposable können z.b. entsorgt(aka. ".Dispose()") werden oder variablen welche wichtig im Try-Block waren können hier zurückgesetzt werden 



            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;     //"AppDomain.CurrentDomain.UnhandledException" handled alle nicht abgefangenen Exceptions welche in der Applikation auftreten. 
            throw new DeveloperDefinedException();      //"UnhandledException" ist ein Event welches erst dann feuert wenn eine Exception geworfen aber nicht aufgefangen wird. Sie ermöglicht es mögliche Exceptions welche nicht einfach erkennbar sind (Siehe OutOfMemoryException) abzufangen und so gut es geht zu handlen.
                                                                                     //Wie bei einem gewöhnlichen Event kann man dem eine Methode beifügen, Event-Multicasting betreiben und die Parameter so Anpassen wie man sie benötigt
                                                                                     //Generell wird das "UnhandledException" Event aber nur als ein FailSafe benutzt da es zwar dem Programm ermöglicht eine Methode auszuführen(z.b. Aufräumarbeiten) aber das Programm kurz danach trotzdem abstürzt. Es bietet eine letzte Chance alles wichtige abzuspeichern bevor alles verloren geht. 
                                                                                     //Zudem ist es nicht immer ersichtlicht für spätere Debugging-Pläne ob ein UnhandledException Event präsent ist oder nicht, und da man ggf die Exceptions von Typ zu Typ unterschiedlich handlen will, müsste man im Event die Exceptions in typisierte Exceptions zurück-umwandeln
                                                                                     //Da das alles unnötig viel Arbeit mit relativ wenig "gain" in Verbindung steht benutzt man lieber das try-catch-finally Verfahren für die öfter auftretenden Exceptions während das Unhandled Event eher als FailSafe benutzt wird um unerkannte Exceptions abzufangen
                                                                                     //denn wie gesagt, das Unhandled-Event verhindert nicht das abstürzen, sondern nur den Datenverlust.
        }
        public void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception myException = e.ExceptionObject as InvalidCastException;
            Console.WriteLine($"Das ist die Exception: {myException.GetType()} {myException.Message}"); //Hier werden alle ungehandleten Exceptions abgefangen. Alle ungehandleten Exceptions werden als Basisklasse "Exception" angesehen, daher muss man einzelne Exceptions aufteilen wenn man einen bestimmten Exceptiontypen behandeln will.

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Hier sind alle Properties einer Exception:{Environment.NewLine}");

            ExceptionTypesAndProperties exceptionTypes = new ExceptionTypesAndProperties();
            exceptionTypes.ExecuteExceptionProperties(myException);
            Console.WriteLine("Das Programm wird sich selbst abstürzen lassen und ein neues starten");

            Process.Start("GeometricObjectSolution.exe", null);   //"Process.Start" öffnet eine Applikation dessen Pfad bzw. Dateiname und parameter in ".Start()" definiert wurden. Dies ist KEINE gute Recovery-Methode im Falle einer fatalen Exception.
        }

        class ExceptionTypesAndProperties
        {
            //Alle Exception-Typen sind indirekt von der Klasse "Exception" abgeleitet
            //Die Klasse "Exception" leitet direkt in nur 2 weitere Exceptionarten ab: "SystemException" und "ApplicationException"
            //SystemException definiert alle Exceptions welche im Zusammenhang mit dem CLR stehen. Diese sind häufig schwerwiegende Exceptions die aber trotzdem behandelt werden können
            //ApplicationException definiert alle Exceptions welche vom Entwickler selbst programmiert wurden. Allerdings gilt ApplicationException bereits als bedeutungslos da man selbstdefinierte Exceptions auch direkt von der Basisklasse "Exception" ableiten kann. 
            //ApplicationException hat der Basisklasse "Exception" also nichts voraus.

            public void ExecuteExceptionProperties(Exception insertInnerException = null)   //Ein optionaler Parameter wird erwartet. Falls kein Parameter übergeben wird, wird anstelle einer Exception, der Wert "null" weitergereicht.
            {
                //Schauen wir uns jetzt die Properties einer jeden Exception an
                Exception myException;
                myException = new Exception("Dies ist eine Entwicklerdefinierte Message", insertInnerException)   //Dies sind die beschreibbaren Properties einer Exception
                {
                    HelpLink = "C\\InsertFilePathHere",         //HelpLink  soll auf eine Datei in einem Verzeichnis hinweisen welche die Exception beschreibt und eventuell eine Lösung für das Problem bereitstellt. HelpLink ist ein Pfad der im String-Format eingegeben wird. HelpLink kann auch eine URL sein.
                    Source = "Programm & Methodenname",         //Source    gibt einfach den Ursprung zurück aus dem die Exception geworfen wurde. Programm und Methodenname können hier definiert und entnommen werden(alles im String-Format). 
                };

                //Nicht beschreibbare Properties:
                _ = myException.Message; //Message gibt eine einfach zu verstehende erklärung zurück, welche Ursache das auslösen der Exception hatte. Message kann nur im konstruktor eigenständig eingegeben werden, andernfalls ist sie "readonly", also schreibgeschützt.

                _ = myException.StackTrace;  //StackTrace ist eine Dokumentation von allen Methoden die zur Zeit der Exceptionauslösung aktiv waren. An erster Stelle steht die Methode welche die Exception ausgelöst hatte.

                _ = myException.Data;    //Data kann benutzt werden um wichtige Zusatzinformationen an die Methode weiter zu geben welche die Exception behandelt. Dabei muss die Property "Data" über ein Objekt weitergeleitet werden welche das "IDictionary" Interface implementiert,da Data mit einem Key-Value-Pair Schema arbeitet.(Siehe "Collections")
                                         //Daten die von "Data" bereitgestellt werden sollen "Message" auf keinen Fall ersetzen. Data bietet jedoch viel Detailreichere Infos wie z.b. wann? wo? zu welcher Uhrzeit? in welcher Zeile? oder unter welchem Kontext die Exception geworfen wurde. Alles Infos die nützlich für die Behandlung der Exception sein KÖNNTEN.
                                         //Die Daten in "Data" müssen vom Entwickler hinzugefügt werden bevor sie Ausgelesen werden können.

                _ = myException.TargetSite;  //TargetSite gibt detailreiche Infos über die Exceptionauslösende Methode zurück. Damit kann man z.b. einsehen welche Parameter die Methode hatte oder was für ein Rückgabewert die Methode hätte.

                _ = myException.InnerException; //InnerException ist eine Exception die Entsteht wenn bei der Behandlung einer Exception eine weitere Exception ausgelöst wird. Dadurch entsteht eine verschachtelte Exception welche als InnerException bekannt ist. Eine InnerException beinhaltet alle Eigenschaften wie eine normale Exception und ist auch abgeleitet vom Typ "Exception".
                                                //Im Konstruktor kann auch eine InnerException in die äußere Exception übergeben werden.

                _ = myException.HResult;    //HResult ist ein Integer-Wert welche einer bestimmten Exception zugeordnet wird. Kann als ID für Exceptions genutzt werden.

                try
                {
                    throw myException;      //Bei einer vordefinierten Exception muss das "new"-keyword nicht vor dem Exceptionaufruf stehen
                }
                catch
                {
                    myException.Data.Add("CurrentTime", $"{DateTime.Now:hh:mm:ss:ff}");   //Hier wird ein "Key-Value"-Pair zum Dictionary hinzugefügt. Der Wert ist "DateTime.Now" welches den jetzigen Zeitpunkt dokumentiert und "Date" ist der Schlüssel der den DateTime-Wert aufruft.
                                                                                          //"DateTime.Now:hh:mm:ss" beschreibt nur das Format in dem die Uhrzeit gezeigt werden soll. "h" steht für die Stellenanzahl der Stunden,"m" steht für die Minuten,"s" steht für die Sekunden und "f" für die Millisekunden.
                                                                                          //diese Formatierungsart funktioniert allerdings nur bei Interpolierten strings, also bei strings welche mit einem "$" versehen sind und wo Variablen in den Strings in geschweiften Klammern aufgerufen werden.
                                                                                          //Generell sind interpolierte strings Performanter und bieten bessere Stringformatierungsmöglichkeiten und sind obendrein noch lesbarer als die einfache stringaddition
                    WriteAllPropertyValues(myException);
                }
            }
            void WriteAllPropertyValues(Exception myException)
            {
                Console.WriteLine($"Dies sind alle Properties:{Environment.NewLine}Message: {myException.Message}{Environment.NewLine}");   //Message wird ausgegeben

                Console.WriteLine($"StackTrace: {myException.StackTrace}{Environment.NewLine}");    //StackTrace wird ausgegeben

                Console.WriteLine($"Data: {myException.Data["CurrentTime"]}{Environment.NewLine}"); //Uhrzeit wird ausgegeben

                Console.WriteLine($"TargetSite: {myException.TargetSite.Name},{myException.TargetSite.DeclaringType},{myException.TargetSite.IsConstructor}{Environment.NewLine}");  //Methodenname, Rückgabetyp wird ausgegeben und ob die Methode eine Konstruktormethode ist oder nicht

                Console.WriteLine($"InnerException: {myException.InnerException?.GetType()}{Environment.NewLine}");  //Der Typ der InnerException wird ausgegeben. Der Null-Coalescin Operator ( der "?" Operator) wird dabei benutzt um zu prüfen ob die InnerException "null" ist oder nicht. Wenn ja dann wird nichts ausgegeben. Wenn nein dann wir der Typ der InnerException ausgegeben.

                Console.WriteLine($"HResult: {myException.HResult}{Environment.NewLine}");   //Ein Zahlenwert wird ausgegeben
            }
        }


        [Serializable]  //Eine Klasse oder Keyword welches vor einer Methode oder einer Klasse in eckigen Klammern steht nennt man "Attribute". Sie bestimmen wie,wo,wann und unter welchen Umständen die Klasse oder Methode genutzt werden kann. Das Thema Attribute wird in der notizdatei "Attribute" behandelt.
        public class DeveloperDefinedException : Exception      //Alle Entwicklerdefinierten Exceptions sind entweder vom Typ "ApplicationException" oder nur "Exception", welches mittlerweile der ApplicationException vorgezogen wird
        {                                                       //Falls man jedoch eine Entwicklerdefinierte Exception braucht die bspw im Rahmen einer ArgumentException ist,dann kann man die Entwicklerdefinierte Exception auch direkt von ArgumentException ableiten
            public override string Message { get; } //virtual/abstract und overrides können auch auf Properties angewant werden da die getter und setter auch nichts als umformulierte Methoden sind die überschrieben & vererbt werden können.
            public DeveloperDefinedException()
            {
                Message = "DeveloperDefinedException ist eine dummy-Exception zum Testen von Entwicklerdefinierten Exceptions";
                //Alle Exceptions haben mindestens 4 Konstruktoren. Natürlich kann man immer weitere Konstruktoren dazu codieren, jedoch sollten diese 4 Konstruktoren immer da sein.
            }
            public DeveloperDefinedException(string message) : base(message) { }
            public DeveloperDefinedException(string message, Exception inner) : base(message, inner) { }
            protected DeveloperDefinedException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }  //Serialisierung und deserialisierung wird später behandelt,kann aber für's erste ignoriert werden
        }
    }
}
