using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen
{
    class Hashset   //Ein HashSet ist vermutlich die performanteste und zugleich die modifizierbarste Collection in .Net.
                    //Es stellt eine Collection bereit welche nicht nur extrem schnelle set-Operations bereitstellt, sondern auch sicher stellt dass jedes Element nur 1 mal vorkommt.
                    //versucht man also Duplikate eines Objektes innerhalb der Collection zu erstellen so wird das HashSet diese Operation nicht ausführen und die Collection bleibt unverändert.
                    //Dies stellt sicher dass jedes Objekt in einem HashSet garantiert einzigartig ist.
                    //Nicht mit einem Hashtable zu verwechseln!

    {

        public static void PerformHashSet()
        {
            HashSet<int> hashSet = new HashSet<int>();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    hashSet.Add(i);     //Hier wird ein Element in das HashSet hinzugefügt. Fall das Element bereits existieren sollte wird keine Operation ausgeführt 
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine($"Maximale Anzahl an items in diesem HashSet = {i:0,0} items.");
                    break;
                }
            }
            Console.WriteLine($"HashSet ist geladen, {hashSet.Count:0,0} items.");


            for (int i = 0; i < 20; i++)
            {
                hashSet.Add(i);     //Hier wird nichts an der Collection verändert bis i == 10 ist. Erst wenn i über 10 ist wird tatsächlich etwas an der Collection verändert.
            }

            Console.WriteLine($"HashSet ist geladen, {hashSet.Count:0,0} items.");

            for (int i = 0; i < 20; i++)
            {
                hashSet.Remove(i);  //Hier wird das HashSet stück für stück verkleinert bis es leer ist.
            }

            hashSet.Remove(1);  //Wenn eine Remove()-Methode auf ein HashSet aufgerufen wird obwohl das HashSet leer ist wird nichts ausgeführt und es wird keine Exception geworfen

            //Vorteile eines HashSet:
            //-Sehr schnelles iterieren und ausführen von Set-Operationen
            //-Flexibel und Lightweight zugleich
            //-Fehlerhafte aktionen werden nicht mit einer Exception geahndet.

            //Nachteile eines HashSet:
            //-Die Collection hat keine konsistente Reihenfolge
            //-Es akzeptiert keine Duplikate(nicht immer ein Nachteil)
            //-Dadurch dass Fehlerhafte/Belastende Operationen keine Exception werfen muss man ganz penibel auf Performance und optimisierung achten. Auch Logikfehler die fatal sein können und durch Exceptions verhindert werden könnten, könnten durch das nichtexistieren der Exceptions autreten.
        }
    }
}
