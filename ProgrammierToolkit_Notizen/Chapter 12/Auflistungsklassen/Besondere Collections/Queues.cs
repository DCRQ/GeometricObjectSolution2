using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen.Besondere_Collections
{
    class Queues        //Ein Queue stellt eine Collection bereit welche nicht manipuliert werden kann. Man kann items zu einem Queue hinzufügen oder entfernen aber man kann dies nur an der ersten Stelle einer Queue tun.
                        //Ein Queue hat nur 2 definitive Methoden. "Enqueue()" und "Dequeue()". "Enqueue()" Schiebt ein Item in die Collection. "Dequeue()" gibt ein Item aus der Collection heraus und entfernt dieses aus der Collection.
                        //Das element welches als erste in die Queue kam wird das erste element sein welches die Queue verlässt. Das Queue funktioniert also nach dem FIFO verfahren (First-In-First-Out).
                        //Man mag sich das wie eine Warteschlange vorstellen. Wer eher in der schlange ansteht wird auch eher bedient. Vordrängeln gibts in der Queue nicht und man kann die Reihenfolge auch nicht durchmischen.
    {
        public static void PerformQueue()
        {
            Queue<int> newQueue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                newQueue.Enqueue(i);            //Hier ist das "Enqueue()" mit einem "Add()" einer List vergleichbar 
            }
            Console.WriteLine($"{newQueue.Count:#,0} items wurden in das Queue geladen");

            while (newQueue.Count != 0)
            {
                newQueue.Dequeue();     //Hier werden alle Elemente des Queue durch die "Dequeue()" Methode ausgegeben und gelöscht. Die Dequeue nimmt die elemente zuerst die als erstes in die Queue gelangt sind.
            }
            Console.WriteLine($"Die Queue enthält nach dem Dequeuen noch {newQueue.Count:#,0} items");

            try
            {
                _ = newQueue.Dequeue();     //An dieser Stelle ist es wichtig zu wissen dass die Queue 1 weitere Methode bereit stellt: "Peek()". Peek() gibt ein Element aus OHNE es sofort zu löschen und verändert somit nicht die Collection.
                                            //Da sie nichts an der Collection ändert wird beim mehrmaligen Aufrufen von Peek() immer das gleiche Element zurückgegeben
                                            //Möchte man ein Element entfernen ohne es auszugeben dann ruft man wie hier Dequeue() auf und kann zum besseren verständnis einen Discard verwenden.
                                            //Wenn man ein Dequeue auf eine leere Queue aufruft dann wirft die Queue eine InvalidOperationException.
            }
            catch (InvalidOperationException)
            {
                return;
            }

            //Vorteile einer Queue:
            //-Äußerst effizient und sehr Lightweight
            //-Ordnung der Collection ist immer gegeben
            //-Berechenbar und leicht zu Implementieren

            //Nachteile einer Queue:
            //-Kann nicht in der Reihenfolge verändert werden
            //-Ausgabe der Queue ist ebenfalls unveränderbar
        }
    }
}
