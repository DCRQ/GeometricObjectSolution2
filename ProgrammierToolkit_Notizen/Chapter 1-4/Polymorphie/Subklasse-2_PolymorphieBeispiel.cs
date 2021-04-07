using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Polymorphie
{
    class Subklasse_2_PolymorphieBeispiel : Basisklasse_PolymorphieBeispiel
    {
        public new void PolymorphieMethode()                                //Mit "new" kann man nicht nur eine brandneue Methode mit dem selben Namen der Basismethode definieren, bei richtiger Polymorphie ruft "new" NUR die Basisklassenmethode auf.
        {                                                                   //Mit "new" in richtiger Polymorphie wird der Code im Subklassen Methodenblock, komplett ignoriert und es wird stattdessen die Basismethode aktiviert.
            Console.WriteLine("Das ist die Subklassenmethode mit 'new'");   //Man kann den Code innerhalb der Subklassenmethode immernoch ausführen, jedoch ist dies nur mit explizitem Klassenaufruf möglich. Heißt das wahre Polymorphie keine Verwendung für "new" hat.
            //Füge hier weiteren Code ein                                   //Heißt folglich auch dass "new" niemals mit Polymorphie in Verbindung gebracht werden kann.
        }
    }
}
