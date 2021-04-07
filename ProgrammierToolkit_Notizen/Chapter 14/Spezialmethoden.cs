using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    public partial class Spezialmethoden
    {
        //Partielle Methoden
        partial void PerformPartialMethod();    //Um eine Partielle Methode aufzurufen muss sie erst einmal in der als "partial" gekennzeichneten Klassendefinition erwähnt werden.
                                                //Was heißt "partial"?:
                                                //partielle Methoden sind methoden welche zwar in der Klasse aufgerufen werden aber in einer anderen Klasse definiert werden. 
                                                //Ähnlich wie eine Erweiterungsmethode nur dass partielle Methoden member der Klasse sind während Erweiterungsmethoden von einer seperaten Klasse zur verfügung gestellt werden.
                                                //partielle Methoden fordern eine Partielle Klasse. Partielle Klassen sind wünschenswert wenn man z.b. im team an mehreren Aspekten einer Klasse gleichzeitig arbeitet. 
                                                //bspw. kann eine Person im Team an der Schreib-Funktion der Klasse arbeiten während eine andere Person an den einlese-Funktionen der Klasse arbeitet.
                                                //Dabei wird beim kreiren der Klasse die Klasse aufgeteilt. Sie kann überall in der Solution neu definiert und beschrieben werden. Dabei wird jeder Klassenaufruf summiert und man erhält eine Klasse welche eine Kombination aus vielen Klassendefinitionen in mehreren Dateien ist.
                                                //Partielle Methoden funktionieren ähnlich indem sie in einer fremden Datei definiert und in einer anderen Datei ausgeführt werden können. Um eine partielle Methode korrekt zu implementieren muss sie in der Klassendefinition aufgerufen werden (siehe Zeile: #98)
        public void PerformSpecialMethods()
        {
            PerformPartialMethod();
        }

        //Lokale Functions
        public void PerformLocalFunctions()     //Lokale Funktionen sind Methoden welche verschachtelt in einer weiteren Methode definiert sind. sie sorgen dafür dass nur die Methode sie aufrufen kann in der sie verschachtelt wurde.
                                                //Dies erhöht die Abstraktion und die Sicherheit des Programms.
                                                //im Gegensatz zu privaten Klassen lassen sich lokale Methoden nicht außerhalb der verschachtelten Methode aufrufen.
        {
            int value = 2;
            int anotherValue = 10;

            LocalFunction();    //Hier wird die lokale Funktion aufgerufen. Da sie keine statische Funktion ist fängt sie alle Variablen/Objekte ab die bis hierhin nicht entsorgt wurden.

            LocalFunctionWithParameter(value);      //Hier wird eine weitere Lokale Funktion aufgerufen. Da sie jedoch als statisch markiert ist wird sie nur die Objekte & Variablen annehmen die in der Parameterübergabe beschrieben sind.
            //Das static-Keyword sorgt im Fall der lokalen Funktion für mehr Abstraktion & Sicherheit.


            void LocalFunction()
            {
                value = 45;
                anotherValue = 90;
                Console.WriteLine(@"Dies ist eine lokale Funktion. Lokale Funkion =\= Methode.");   //Im prinzip sind lokale Funktionen nicht anders als Methoden. Microsoft macht aber deutlich dass sie sich voneinander unterscheiden. Meist geht es darum das es das Workflow im Team erleichtert weil man lokale Funktionen leicht identifizieren kann und sich sicher sein kann dass sie nur in einer Funktion aufgerufen werden kann.
                                                                                                    //Im gegensatz zu lokalen Funktionen stehen Methoden eher als Symbol für ein immer wiederverwertbaren Teil des Codes der in vielen Bereichen angewendet werden kann. Lokale Funktionen sind da spezifizierter was ihre Aufgabe betrifft.
            }
            static void LocalFunctionWithParameter(int parameter)
            {
                parameter = 69;
            }
        }
    }
}
