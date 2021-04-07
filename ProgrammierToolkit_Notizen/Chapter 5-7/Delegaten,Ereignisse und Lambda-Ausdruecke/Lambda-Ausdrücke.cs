using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Delegaten_Ereignisse_und_Lambda_Ausdruecke
{
    class Lambda_Ausdrücke
    {
        private delegate int DelegatMitMehrerenParameter(int x, int y);
        private delegate int DelegatMitNurEinemParameter(int x);
        private delegate void DelegatOhneParameter();

        private int _zahl;
        public int Zahl
        {
            get
            {
                Console.WriteLine("Gib eine Zahl ein");
                return int.Parse(Console.ReadLine());
            }
            set => _zahl = value;   //Mit C# 7 kann man Lambda-Ausdrücke jetzt auch an Properties, Methoden, Konstruktoren, Destruktoren, und an Indexern Anwenden.
        }                           //Jedoch ist es nicht möglich so mehr als eine Anweisung zu definieren. Dazu bräuchte es geschweifte Klammern.

        public void CallLambdaExpressions()
        {
            Console.WriteLine("Gib die zu summierenden zahlen nacheinander ein");
            DelegatMitMehrerenParameter summe;                                                             //Ein Lambda-Ausdruck ist im prinzip nichts als ein Delegat welcher eine nicht-aufrufbare Methode(a.k.a. eine Anonyme Methode) ausführt.
            DelegatMitNurEinemParameter summe_2;
            DelegatOhneParameter summe_3;

            summe = (summand_1, summand_2) => summand_1 + summand_2;                     //für gewöhnlich wird ein Lambda-Ausdruck mit dem "=>" Zeichen gekennzeichnet.

            //Vollständig ausgeschrieben sieht der Lambda-Ausdruck jedoch so aus:                                                                            
            summe = delegate (int summand_1, int summand_2)
            {
                return summand_1 + summand_2;
            };
            //Auf die angemessenen Parameter ist sehr zu achten! Diese sind nicht außerhalb des Lambda-Blocks nutzbar.
            //Hat man mehrere Parameter so muss man diese in Klammern setzen. Bei einem einzelnen parameter jedoch, reicht es aus wenn man den Ausdruck wie folgt definiert:
            summe_2 = summand =>                                                                //Wenn man einen Codeblock definiert dann muss man darauf achten einen "return"-Wert zu definieren, da der Delegat kein void-oder Action-Delegat ist und einen Rückgabewert erwartet
            {                                                                                   //Bei Delegaten die keinen Rückgabewert erwarten, muss kein return-Wert angegeben werden.
                summand += summand;
                return summand;
            };
            //Wenn ein Delegat keine Parameter hat dann sieht der Lambda-Ausdruck wie folgt aus. Um zu demonstrieren wie man einen Lambda-Codeblock für einen void-oder Action-Delegaten definiert, wurde ein Delegat ohne Rückgabewert erstellt:
            summe_3 = () =>
             {
                 int ergebnis = Zahl += Zahl += Zahl;
                 Console.WriteLine($"Das Ergebnis von Beispiel 3 ist: {ergebnis}");
                 //ohne return-Anweisung
             };
            //Lambda-Ausdrücke dessen Rückgabewert einen anderen Datentyp als den der Parameter haben, werden Projektionen genannt. So kann man als Parameter einen Datentyp von String haben, aber als Rückgabewert einen Integer-Wert.
            //Um dies zu ermöglichen muss man nur den Delegaten umschreiben und den return-Wert anpassen. 
            //Projektionen die durch bestimmte Operationen einen Boolschen Wert liefern, nennt man Prädikate 
            Console.WriteLine($"Das Ergebnis von Beispiel 1 ist: {summe.Invoke(Zahl, Zahl)}");
            Console.WriteLine($"Das Ergebnis von Beispiel 2 ist: {summe_2.Invoke(Zahl)}");
            summe_3.Invoke();   //Da der Delegat "summe_3" eine void-funktion delegiert, hat er keinen Rückgabewert den es hätte, an die Konsole ausgeben können. 
        }                       //Deshalb muss die Ausgabe des Ergebnisses innerhalb des Lambda-Codeblocks stattfinden.
    }                           //Theoretisch könnte man jede der hier stehenden "Console.WriteLine()"-Methoden in den entsprechenden Lambda-Codeblöcken definieren, aber um den Code simpel zu halten lassen wir die Ausgaben besser in einem abgetrennten Bereich des Codes.
}
