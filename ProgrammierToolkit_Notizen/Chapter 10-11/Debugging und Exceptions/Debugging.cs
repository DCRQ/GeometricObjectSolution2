#define MeinDebuggingObjekt
#define TEST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_10.Debugging_und_Exceptions
{
    class Debugging //In diesem Abschnitt beschäftigen wir uns mit programmatischem Debugging. 
    {               //Programmatisches Debugging hilft gegen die nicht-sofort-einsehbaren Fehler im Programm vorzugehen. Logikfehler die nicht vom Programm erkannt werden können weil sie gegen keine Sprachregeln verstoßen. Vordefinierte Exceptions gibt es für diese Art von Fehlern nicht da diese sehr unvorhersehbar sind. Es spricht allerdings nichts dagegen selber Exceptions zu definieren und diese dann auszuwerfen Falls ein unerwünschtes Ergebnis aufkommt.
        public void PerformDebugging()              //Debugging ist essentiell für jedes Projekt. Die Klasse "Debug" und "Trace" vom "System.Diagnostics" Namespace helfen sehr. Der "Diagnostics" Namespace stellt nur statische Mitglieder(aka Member) zur verfügung.
        {
            Debug.WriteLine("Füge eine Nachricht ein.");    //Debug.WriteLine gibt bei jedem Aufruf eine Nachricht an das Output Fenster wenn man die Anwendung per Start-Knopf testet. Debug.WriteLine kann keine formatierten strings annehmen. Stringinterpolation ist also nicht möglich.
            Trace.WriteLine("Hier ist eine weitere Nachricht ");//Dies kann genutzt werden um Hinweise auszugeben oder stellen im Code zu markieren an denen man vorbeikommt
            Debug.Write("Debugausgabe ohne Zeilenumbruch. ");
            Trace.Write("Debugausgabe (per Trace-Klasse) ohne Zeilenumbruch ");
            if (bool.TryParse(Console.ReadLine().ToLower(), out bool hasValue))//Alle Klassen in System.Diagnostics sind statische Klassen. Heißt sie brauchen keine Variabelnamen um sie einzusetzen.
            {
                Debug.WriteLineIf(hasValue, "Bedingungsabhgängige Debugausgabe mit Zeilenumbruch. Bedingung: " + hasValue);//"Debug.WriteLineIf" schreibt erst etwas ins Output Fenster wenn die Bedingung erfüllt ist. Sehr praktisch um unnötig viel Code für einen Test zu vermeiden.
                Trace.WriteLineIf(hasValue, "Bedingungsabhgängige Debugausgabe(per Trace-Klasse) mit Zeilenumbruch.Bedingung: " + hasValue);

                Debug.WriteIf(hasValue, "\r\n Bedingungsabhgängige Debugausgabe ohne Zeilenumbruch. Bedingung: " + hasValue);
                Trace.WriteIf(hasValue, "\r\n Bedingungsabhgängige Debugausgabe(per Trace-Klasse) ohne Zeilenumbruch.Bedingung: " + hasValue);
            }
            else
            {
                Debug.WriteLineIf(hasValue, "Bedingungsabhgängige Debugausgabe mit Zeilenumbruch. Bedingung: " + hasValue);
                Trace.WriteLineIf(hasValue, "Bedingungsabhgängige Debugausgabe(per Trace-Klasse) mit Zeilenumbruch. Bedingung: " + hasValue);
                Debug.WriteIf(hasValue, "\r\n Bedingungsabhgängige Debugausgabe ohne Zeilenumbruch. Bedingung: " + hasValue);
                Trace.WriteIf(hasValue, "\r\n Bedingungsabhängige Debugausgabe(per Trace-Klasse) ohne Zeilenumbruch. Bedingung: " + hasValue);
            }
            Debug.Assert(hasValue, "Hier ist eine Fehlermeldung!");  //"Debug.Assert" wirft eine Fehlermeldung in Form eines Fensters aus. Dies ist besser als eine Exception zu werfen da man diese nicht handlen muss und wenig bis keinen Overhead beinhaltet.
            Trace.Assert(hasValue, "Noch eine weitere Fehlermeldung!"); //Die Klasse "Trace" unterscheidet sich nicht viel von "Debug", der Unterschied liegt darin wie VS2019 mit den Klassen umgeht. Da wir uns im Debugmodus befinden zählt die Debug Klasse zum Code dazu.
                                                                        //Wenn wir allerdings im Releasemodus wären dann wurde der Compiler alle aufrufe der Debug-Klasse einfach ignorieren. Da kommt Trace ganz gelegen. Beim Trace gibt es aber etwas mehr Overhead als beim Debug.
            PerformOptionallyCompiledDebuggingMethods();

        }
        void PerformOptionallyCompiledDebuggingMethods()    //Hier wird bedingt kompilierter Code definiert. Dies kann helfen wenn man an einem komplexen Projekt arbeitet und den Release-build nicht unnötig mit Debugger-Code zumüllen will und dem Programm mäglicherweise Hardwareresourcen entzieht und die Leistung drosselt.
        {
            #if MeinDebuggingObjekt    //Das "#" symbol vor der if-Abfrage signalisiert dass dieser Teil des Codes Optional im Debug-Modus Kompiliert, jedoch der Release-build diesen teil komplett ignoriert.
                Console.WriteLine("In der #if-Anweisung");  //die "#if"-Abfrage prüft ob an der ersten Zeile des Codes ein Objekt namens "MeinDebuggingObjekt" definiert wurde. Die Auswertung gibt dann einen Bool zurück. 
                                                            //Ein Objekt für eine bedingte Kompilierung wird wie folgt definiert: "#define MeinDebuggingObjekt". Dafür ist weder Semi-colon noch ein Datentyp-Bezeichner notwendig.
                                                            //Da das erstellen eines Objekts mit "#define" über das ganze Projekt übergreifend wirkt, kann man mit "#undef" das Objekt nichtexistent machen. Das gilt natürlich ebenfalls nur an der ersten Zeile einer Codedatei, vor all den "using"-Direktiven.
            #elif TEST
                Console.WriteLine("In der #elif-Anweisung");    
            #endif      //In den ersten 2 Zeilen werden 2 Objekte definiert welche den #if Block bedingt kompilieren. Schneidet man das erste Objekt aus dem Code raus dann wird der #elif Block ausgeführt. "#elif" steht für "#else-if".
                        //Natürlich kann man auch die #if's und "#elif"s verschachteln. "#endif" signalisiert das Ende der bedingten Kompilierung. Danach wird der Code wie gewöhnlich kompiliert.
            DefineConditionalMethod();
        }  

        [Conditional("MeinDebuggingObjekt")]    //Dies ist ein Attribut welches prüft ob das Objekt "MeinDebuggingObjekt" existiert. Wenn ja dann wird die gesamte Methode kompiliert. Andernfalls nicht.
        void DefineConditionalMethod()  //Eine Methode welches das "Conditional"-Attribut besitzt wird ähnlich wie ein "#if" Block behandelt indem es die Methode erst kompiliert wenn das angegebene Objekt existiert.
        {
            Console.WriteLine("Das ist eine Bedingungsabhängige Methode");  //Conditional Methoden MÜSSEN "void" als Rückgabewert aufweisen und dürfen keine override Methoden sein. Jedoch ist es unklar, ob dies so bleiben wird oder ob zukünftige C# Versionen der Sprache mehr flexibilität zuweist.
            Debugger.Break();   //"Debugger.Break()" der "Debugger"-Klasse setzt einen Breakpoint an der Aufrufstelle. Ein Breakpoint bringt das gesamte Programm zum anhalten sodass man bspw die variablen so einsehen kann wie sie jetzt gerade im rechenprozess sind.
                                //einen Breakpoint kann man auch in VS2019 in der Entwicklerumgebung setzen indem man auf die beliebige Zeile den Cursor setzt und F9 drückt.
                                //Wenn das Programm den Breakpoint trifft und anhält kann man in Echtzeit beobachten wie sich variablen und Datenzustände schritt für schritt verändern. Um schrittweise durch das Programm zu laufen drückt man F10. Wenn man auf einen Methodenaufruf trifft dann hat man die Chance den Inhalt der Methode mit F10 zu überspringen, oder man kann mit F11 in die Methode reingehen und jeden der Ablaufschritte beobachten.
                                //Wenn ihr eine Variable verfolgen möchtet dann müsst ihr im Break-Modus(Modus der Aktiviert wird wenn man auf einen Breakpoint stößt) die Variable mit der rechten Maustaste anklicken und diese unter Beobachtung stellen. Dies wird unten in der Entwicklerumgebung ein Fenster eröffnen mit dem Namen "Watch1"(z.d. "Überwachen"-Fenster) wo alle zur Beobachtung hinzugefügten Daten aufgelistet sind.
                                //Wenn ihr vom Break-Modus zurück zum normalen Modus wechseln wollt dann müsst ihr in der Entwicklerumgebung auf den grünen Knopf auf der oberen zweiten Leiste mit den Tools klicken wo "Fortfahren"/"Continue" steht.

            //Beim drücken von "shift" + F11 springt das Programm vom letzten Breakpoint auf den nächsten oder bis zum nächsten Statement des Programms
            Debugger.Break();

            //Anstelle von "Debugger.Break()" zu benutzen um ein Bedingungsgebundenes Breakpoint zu setzen kann man auch mit F9 einen Breakpoint setzen und beim draufhalten der Maus den Einstellungsknopf klicken. Dann ploppt ein Fenster auf in dem man entweder eine Bedingung definieren kann ab wann der Breakpoint aktiv wird, oder man kann einstellen, dass beim passieren des Breakpoints eine Ausgabe an die Konsole stattfindet und ob das Programm beim erreichen des Breakpoints anhalten soll oder automatisch weitermachen soll.
        }
    }
}
