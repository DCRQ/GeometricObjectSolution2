using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen.List_typen
{
    class LinkedList        //Eine LinkedList Collection ist eine Collection welche viele Objekte enthalten die verkettet sind. Mit verkettet meine ich dass jedes Objekt in der LinkedList maximal auf 2 weitere Objekte verweist: Einmal das Objekt das vor ihm kam, und einmal das Objekt das nach ihm kommt.
    {                       //Jedes element in der LinkedList weiß nur das hinter ihm und vor ihm kommt. Ein durchiterieren ist nicht mehr nötig wenn man ein element ändern will. Das macht die LinkedList effizienter wenn man auf lange Zeit die elemente hin & her schieben will.
        public static void PerformLinkedList()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < 10_000_000; i++)
            {
                try
                {
                    linkedList.AddFirst(i);     //"AddFirst()" fügt ein element an der ersten Stelle der LinkedList ein. Die LinkedList enthält auch "AddLast()" welche ein Element auf dem letzten Platz der Collection einfügt,
                                                //"AddBefore()" welche ein Element eine position vor einem anderen Element einfügt,
                                                //und "AddAfter()" welche ein Element eine Position weiter hinten einfügt als ein anderes Element das man definiert hat (siehe parameterbeschreibung)
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine($"Die LinkedList kann maximal {linkedList.Count:#,0} items aufnehmen");
                    break;
                }
            }
            Console.WriteLine($"Die LinkedList besitzt zurzeit {linkedList.Count:#,0} items");

            while(true)
            {
                if(linkedList.Count == 0)   //Da die Elemente einer LinkedList verkettet sind und gegenseitig auf sich verweisen ist jede Hinzufügen und Löschen Operation eine O(1) Operation.
                {                           //Eine O(1) Operation ist ein Prozess der immer gleich viel Zeit verbraucht egal wie groß die Collection ist. Eine O(n) Operation ist ein Prozess bei dem die Dauer Proportional zur große der Collection ist.
                    break;                  //Logischerweise sind O(1) Operationen wünschenswerter weshalb die LinkedList bei großen Sammlungen sehr nützlich sein können.
                }
                linkedList.RemoveFirst();   //hier wird das erste Element der LinkedList gelöscht. "RemoveLast()" tut so ziemlich das gleiche mit dem letzten Element.
            }
            Console.WriteLine($"Die LinkedList beinhaltet nurnoch {linkedList.Count:#,0} items");

            try
            {
            linkedList.RemoveFirst();   //Versucht man ein Element zu löschen wenn die Liste leer ist wird eine InvalidOperationException geworfen
            }
            catch (InvalidOperationException)
            {
                return;
            }
           //Vorteile einer LinkedList:
           //-Viele der Operationen die bei gewöhnlichen Collections eine O(n) Operation wäre, ist bei der LinkedList eine O(1) Operation
           //-LinkedLists sind sehr einfach aufgebaut und nützlich um große Mengen an Daten zu Sammeln

            //Nachteile einer LinkedList:
            //-Sie verbraucht relativ viel Speicher
            //-Performance hat keine hohe Priorität für diese Collection
            //-Ist zwar konsistent,jedoch nicht Threadsicher
            //-Operationen die nich von der LinkedList Klasse angeboten werden können diese Collection erheblich verlangsamen

        }

    }
}

