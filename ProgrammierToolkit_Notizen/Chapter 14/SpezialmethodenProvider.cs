using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    partial class Spezialmethoden       //Hier wird die Klasse aufgesplittet. bspw können hier Funktionen für bestimmte Aufgaben der Klasse definiert werden.
    {
        partial void PerformPartialMethod() //Diese Methode wird hier zwar definiert, jedoch in einer anderen Methode dieser Klasse aufgerufen
        {
            Console.WriteLine("partielle Methode ausgeführt.");
        }
    }
}
