using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    class Attribute
    //Attribute geben der Komponente über der sie stehen eine besondere Eigenschaft bzw einen besonderen nebeneffekt. Bspw kann man durch Attribute dafür sorgen dass einige member der unterstehenden Klasse als nicht-benutzbar angezeigt werden oder dass einige Methoden von Grund auf Threadsicher sind.
    {                   //Deklariert sind Attribute ausschliesslich in eckigen Klammern. Daran kann man Attribute im Code erkennen.
                        //Attribute unterscheiden sich grundsätzlich nicht von regulären Klassen und haben daher die selben Fähigkeiten die eine gewöhnliche Klasse hat wie z.b. Konstruktoren zu definieren oder Felder oder Methoden zu setzen/aktivieren.

        [SpecialNameAttribute]   //Attribute können jedem member über stehen. Dieses Attribut hat im Grunde keinen Effekt auf die darunter liegende Methode. Dieses Attribut ist nur zu Demonstrationszwecken aufgelistet.

        [MethodImplAttribute(MethodImplOptions.Synchronized)]    //Attribute können auch addiert und gestapelt werden. Dann erhält ein member die Kombination aller Effekte aller Attribute die über Ihm stehen. Dieses Attribut sorgt dass die folgende Methode von Grund auf Threadsafe ist (Alles über Multithreading: siehe Multithreading.cs)

        [ObsoleteAttribute("Diese Methode ist veraltet", false)]  //Attribute können auch die Entwicklungsumgebung verändern. Dieses Attribut sorgt nämlich dafür dass diese dazugehörige Methode mit einer Warnung unterstrichen (oder wenn "true" ist als Fehler unterstrichen) wird wenn man sie aufrufen sollte. Attribute können also durchaus die Macht besitzen das Programmieren im großen Maße zu beeinflussen.

        [PropertyAndFieldAttribute("Das ist ein Benutzerdefiniertes Attribut", NamedString = null, NamedInt = 2)] //für Benannte Parameter spielt die Reihenfolge keine Rolle aber für Positionale Parameter ist die Reihenfolge von hoher Priorität. 

        //Der Suffix "-Attribute" wird hier ausgegraut. Manche Attribute erkennt der Compiler ohne den Suffix "-Attribute". Das dies Attribute sind erkennt man immer an den eckigen Klammern. Eckige Klammern = Attribut.

        public void PerformAttributes([CallerMemberNameAttribute]string a = "", [CallerLineNumberAttribute] int i = 0, [CallerFilePathAttribute] string b = "")  //Attribute können auch an Parameterübergaben oder Variabledeklarationen beteiligt sein. Dabei muss man darauf achten dass diese auch einen Grundwert besitzen Falls das Attribut keinen Wert zurück gibt. 
        {                               //Die obigen Attribute geben einmal den Namen der Methode zurück welche diese Methode aufruft, die Zeile zurück an der diese Methode aufgerufen wird und den Datei-Pfad zurück in der sich die aufrufende Datei aufhält. Alle 3 Attribute werden dann in die Parametervariablen a,b und i gespeichert und ausgegeben.
            Console.WriteLine($"Datei: {b} | Methode:{a} , Zeile:{i}");
        }

        //So erstellt man eigene Attribute:
        //Mit dem Schlüsselwort "Attribute" und dem zweimaligen drücken von TAB kann man das schreiben eines Attributs deutlich vereinfachen
        [System.AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]    //Alle Benutzerdefinierten Attribute müssen das Attribut: AttributeUseage implementieren und von der Basisklasse abgeleitet werden.

        //"AttributeTarget" gibt an welche Art von Objekt diesem Attribut unterstehen kann. "AttributeTarget.All" erlaubt es dem Attribut über allen Arten von Objekten zu stehen.
        //Es können auch 2 oder mehrere Objektarten ausgewählt werden.
        //"Inherited" bestimmt ob die Funktionen dieses Attributs vererbt werden kann oder nicht.
        //"AllowMultiple" bestimmt ob dieses Attribut mehrmals dem selben Objekt zugeordnet werden kann oder nicht. 


        sealed class PropertyAndFieldAttribute : System.Attribute
        {

            //Man sollte beachten dass man so wenig öffentlich,setzbare Properties wie möglich haben sollte. Entweder sollten Properties durch einen Setter gesetzt werden oder durch einen Konstruktor. Nicht beides. Es sollte klar definiert sein welche Properties Angabepflichtig sind und welche eher optional sind. 2 Wege zu definieren um nur ein Ziel zu erreichen ist nicht optimal, gerade wenn es keinen Leistungs- oder Benutzervorteil mit sich bringt.
            //Zudem sollte man, wenn möglich, nur einen Konstruktor definieren. Aus dem selben Grund für den man nur optionale Properties mit einem öffentlichen Setter definieren sollte, sagt ein einzelner Konstruktor aus welche Komponenten optional und welche Angabepflichtig sind. Mehrere Konstruktoren sind zwar gestattet, jedoch eher ungünstig, da sie oft wenig Funktionalität bieten und Abtraktion riskiert.
            //Man sollte auch darauf achten, dass man eine Attributklasse als "sealed" markiert damit die Laufzeit das Attribut schneller nachschlagen/finden kann.
            //Über mehr hilfreiche Richtlinien kann man die MSDN seite über Attribut-Richtlinien von Microsoft nachlesen.

            readonly string positionalString;
            public PropertyAndFieldAttribute(string positionalString)
            {
                this.positionalString = positionalString;
                NamedInt *= 2;
            }
            //Dies ist ein Positionaler Parameter. Dadurch dass er keinen Setter besitzt kann er nur über den Konstruktor gesetzt werden und gilt somit zu den angabepflichtigen Parametern
            public string PositionalString
            {
                get { return positionalString; }
            }

            // Dies ist ein benannter Parameter. Benannte Parameter müssen immer default-Werte aufweisen, für den Fall dass sie nicht erwähnt werden. Dass kommt daher dass sie optionale Parameter für ein Attribut sind und daher flexibel setzbar sind und nicht gezwungenermaßen über einen Konstruktor aufgerufen werden. 
            //Der Grundwert eines Integers ist immer 0.
            public int NamedInt { get; set; }
            public string? NamedString { get; set; }
        }
    }
}
