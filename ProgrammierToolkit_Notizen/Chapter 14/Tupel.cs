using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    class Tupel     //Tupel sind eine weitere Form der Datenzusammenfassung. Mit Tupel kann man mehrere Daten aufeinander "Stapeln" und sie als ein einzelnes Objekt ausgeben in einer Form die sich deutlich von anderen Datencontainern unterscheiden.
    {               //Tupel werden vorzugsweise genutzt um mehrere Rückgabewerte von verschiedenen Typen darzustellen oder um Parameter-restriktionen zu umgehen.
        public void PerformTuple()
        {
            Tuple<int, int, int> tuple = new Tuple<int, int, int>(1, 2, 3); //Hier wird ein Tupel mit 3 Integer Werten erstellt. 
            Console.WriteLine($"{tuple}, Typ: {tuple.GetType()} | {tuple.Item1} + {tuple.Item2} + {tuple.Item3} = {tuple.Item1 + tuple.Item2 + tuple.Item3}");    //Hier werden alle Werte durch das "readonly" Property "Item#" dargestellt. Alle Items werden einzeln aufgerufen und addiert an die Konsole weitergereicht.
            Console.WriteLine();
            Console.WriteLine();
            tuple.Deconstruct(out int ersteZahl, out int zweiteZahl, out int dritteZahl);   //Mit ".Deconstruct()" kann man alle Items in dezidierte Variablen Verpacken und weiter im Code nutzen. Zwar könnte man auch neue Variablen definieren, jedoch sind die von .NET zur verfügung gestellten Methoden optimierter und reduzieren den Aufwand.
            Console.WriteLine($"{ersteZahl} + {zweiteZahl} + {dritteZahl} = {ersteZahl + zweiteZahl + dritteZahl}");

            ValueTuple<int, int, int> valueTuple = new ValueTuple<int, int, int>(1, 2, 3);  //Das ValueTuple ist das gegenstück zur Tuple-Klasse. Im gegensatz zum gewöhnlichen Tuple, besteht ein ValueTuple aus einem struct und ist somit viel effizienter und praktischer wenn es darum geht viele Objekte gleichzeitig zu verarbeiten.
                                                                                            //Man sollte bedenken dass ValueTuple als structs nicht zu viele Items besitzen sollte. Idealerweise sollten es unter 10 Items sein aber das ValueTuple sowie das gewöhnliche Tuple akzeptieren bis zu 16 Items pro Instanz. Zum vergleich: Das DateTime-Objekt welches ebenfalls ein struct ist besitzt auch 16 Properties, es zählt aber zu den wenigsten structs die so viele Daten besitzen.

            valueTuple = tuple.ToValueTuple();  //Die Methode ".ToValueTuple()" Konvertiert ein gewöhnliches Tuple in ein ValueTuple mit allen Items die es besaß.
                                                //In diesem Fall hat ".ToValueTuple()" nichts verändert da "valueTuple" diese Werte(vom gewöhnlichen Tuple) bereits besitzt
            Console.WriteLine($"{valueTuple.Item1} + {valueTuple.Item2} + {valueTuple.Item3} = {valueTuple.Item1 + valueTuple.Item2 + valueTuple.Item3}");


            //Ein ValueTuple lässt sich auch einfach wie Folgt definieren:
            var i = (1, 2, 3);
            Console.WriteLine($"{i}, Typ: {i.GetType()} | {i.Item1} + {i.Item2} + {i.Item3} = {i.Item1 + i.Item2 + i.Item3}");

            PerformModernTuple();
        }

        public void PerformModernTuple()    //Die Tupel-Klasse zu benutzen ist zwar gängig, geht aber auf dauer sehr auf die Performance da ständig im Heap speicher eingerichtet werden muss.
                                            //Eine neuere schreibweise von Tupel macht sich der ValueTuple-Technologie zunutze und ist auch gegenüber der Tupel-Klasse praktischer und performancetechnisch, leichtgewichtiger
        {
            //Die Syntax sieht wie folgt aus:
            var unnamedTuple = ("Jefferson", 40, true); //Dies beschreibt ein unbeschriftetes ValueTuple mit einem string-Wert, einem Integer-Wert und einem Boolean-Wert.

            Console.WriteLine($"{unnamedTuple}, Typ: {unnamedTuple.GetType()} | Name: {unnamedTuple.Item1}, Alter: {unnamedTuple.Item2}, IsLegit: {unnamedTuple.Item3}");   //Hier werden die Werte ausgegeben. Da die Werte keine Namen bzw Variablebezeichner haben müssen sie über Item1,Item2 und Item3 angesprochen werden. 

            var namedTuple = (Name: "Han-swolo", Alter: 69, IsLegit: true); //Um den Items zu benennen und aus den ValueTuple-Inhalten richtige benutzerdefinierte Variablen zu machen kann man die verschiedenen Werte in so wie benannte Parameter aufrufen. Der Compiler macht dann bspw. aus "Name:" eine String-Variable mit den Namen "Name" der den Wert "Han-Swolo" zugewiesen bekommt.
            //Der Datentyp von "Name" hängt dann von dem Wert ab den er zugewiesen bekommt.

            Console.WriteLine($"{namedTuple}, Typ: {namedTuple.GetType()} | Name: {namedTuple.Name}, Alter: {namedTuple.Alter}, IsLegit: {namedTuple.Item3}");  //Auch wenn die Items des ValueTuple nun Variablenamen haben kann man sie immernoch mit "Item1","Item2" oder "Item3" ansprechen

            (string Name, int Alter, bool IsLegit) definedTuple = ("boblitz", 69, true);    //Um die erstellung eines ValueTuples unmissverständlich zu gestalten kann man die genauen Inhalte des Tupels genau da definieren wo sonst der Datentyp gehören würde.

            Console.WriteLine($"{definedTuple}, Typ: {definedTuple.GetType()} | Name: {definedTuple.Name}, Alter: {definedTuple.Alter}, IsLegit: {definedTuple.Item3}");
            Console.WriteLine();

            //Im folgenden Teil wird demonstriert wie man mehrere Rückgabewerte mithilfe eines Tupels zurückgibt:
            var newTuple = PerformValueTupleAsReturnType(("Andreas", 4));
            Console.WriteLine($"{newTuple}, Typ: {newTuple.GetType()} | Name: {newTuple.Name}, ID: {newTuple.ID}");
            Console.WriteLine();

            newTuple = PerformValueTupleAsReturnType((null, 4));
            Console.WriteLine($"{newTuple}, Typ: {newTuple.GetType()} | Name: {newTuple.Name}, ID: {newTuple.ID}");
            Console.WriteLine();

            newTuple = PerformValueTupleAsReturnType(("Andreas", default));
            Console.WriteLine($"{newTuple}, Typ: {newTuple.GetType()} | Name: {newTuple.Name}, ID: {newTuple.ID}");
            Console.WriteLine();

            //Natürlich können sie auch ValueTupel Dekonstruiren indem man das var-keyword benutzt und alle im Tupel enthaltenen Datentypen aufzählt wie folgt:
            var (s, i) = PerformValueTupleAsReturnType(("Andreas", 54));    //Das var-Keyword definiert jedes in Klammern enthaltene Element als Variable. Der Datentyp hängt von der Reihenfolge der Items des ValueTuples ab.
            Console.WriteLine($"{s}, Typ: {s.GetType()} | {i}, Typ: {i.GetType()}");
            Console.WriteLine();

            //Wenn man ein oder mehrere Elemente des Tupels ausschliessen will(aus performance oder abstraktionsgründen) so kann man auch den Discard einsetzen:
            var (b, _) = PerformValueTupleAsReturnType(("Dieter", 385));
            Console.WriteLine($"{b}, Typ: {b.GetType()}");
            Console.WriteLine();
        }
        (string? Name, int ID) PerformValueTupleAsReturnType(ValueTuple<string?, int> valueTuple)
        {
            if (valueTuple.Item1 == null)
            {
                return (null, valueTuple.Item2);
            }
            if (valueTuple.Item2 == 0)
            {
                return (valueTuple.Item1, 0);
            }
            return valueTuple;
        }
    }
}
