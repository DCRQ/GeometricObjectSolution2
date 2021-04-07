using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen
{
    class List
    {
        public static void PerformLists()
        {
            List<int> intList = new List<int>();    //Eine Liste ist im prinzip das gleiche wie ein Array nur dass die Liste eine variierbare Größe hat. Die verhält sich wie ein verstellbares/dynamisches Array welches zugleich Performant bei Iterationsvorgängen ist.

            for (int i = 0; i < 10; i++)
            {
                intList.Add(i);      //Eine Liste zu 
            }

            foreach(int i in intList)   
            {
                Console.WriteLine(i);
            }

            intList.ForEach((number) => Console.WriteLine(number)); //Die List-Klasse implementiert zusätzlich eine Methode welche die foreach-Schleife nachahmt, aber dabei kürzer gefasst, lesbarer ist und
            
            //Vorteil von Listen: -Performant beim iterieren
            //                    -Dynamische größe
            //                    -Leicht zugänglich
            //                    -Typsicher
            //                    -Unterstützt Duplikate

            //Nachteile:         -Einfügen von Werten in der Mitte der Liste ist sehr teuer wenn es um Rechenleistung geht
            //                   -Verbraucht etwas mehr Speicher als ein gewöhnliches Array
            //                   -Eine Liste kann nur ein-dimensional sein. Auch wenn man Listen verschachteln kann (z.b. List<List<List<string>>>) Ist die Liste an sich eindimensional.

            //Generell gilt: 
            //solange es nicht um micro-optimization geht, hat die Liste gegenüber einem normalen Array sehr viele Vorteile und ist somit auch viel empfehlenswerter.
            //Listen sollten daher überall verwendet werden wo man sich sicher ist dass man evtl eine verstellbare Collection braucht und man häufig Daten hinzufügt und löscht.
        }
    }
}
