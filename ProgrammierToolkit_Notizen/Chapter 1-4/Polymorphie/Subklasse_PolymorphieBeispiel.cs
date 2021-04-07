using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Polymorphie
{
    class Subklasse_PolymorphieBeispiel : Basisklasse_PolymorphieBeispiel
    {
        public override void PolymorphieMethode()                   //Mit "override" kann man eine "virtual" Methode überschreiben und trotzdem den selben Methodennamen benutzen
        {                                                           //Bei einer "abstract" Methode MUSS man override benutzen. 
            Console.WriteLine("Das ist die Subklassenmethode");     //Bei Virtuellen Basisklassenmethoden kann man auch das keyword "base" benutzen. "base" ist ein aufruf an die Basisklasse
        }                                                           //Man könnte mit "base" also nicht nur die Basisklassenmethode überschreiben, man könnte die modifizieren indem man die Basismethode aufruft und dan noch etwas hinzufügt
    }                                                               //Die Freiheit(der Subklassen) liegt in den Händen des Programmierers
}
