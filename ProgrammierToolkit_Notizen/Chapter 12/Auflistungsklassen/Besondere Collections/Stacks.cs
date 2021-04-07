using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen.Besondere_Collections
{
    class Stacks        //Ein Stack ist so ähnlich wie ein Queue nur dass ein Stack nach dem LIFO (Last-In-First-Out) verfahren funktioniert im Gegensatz zum FIFO (First-In-First-Out) verfahren
                        //Ein Stack kann man sich wie einen Stapel Chips vorstellen. Die Chips die als erste in der Dose landen sind die letzten die da wieder herauskommen.
                        //Genau wie ein Queue kann man die Reihenfolge eines Stacks nicht verändern oder anderweitig Manipulieren als mit den zur verfügung gestellten Stack-Methoden "Push()" und "Pop()".
                        //"Push()" packt weitere Elemente zusätzlich auf den Stapel drauf während "Pop()" die zuletzt hinzugefügten Elemente als erste ausgibt.
    {
        public static void PerformStack()
        {
            Stack<int> newStack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    newStack.Push(i);       //Hier wird ein neues element hinzugefügt
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine($"Stack hat eine maximalanzahl von {newStack.Count:#,0} items");  //Die strings einer int-Property kann man formatieren. Vorzugsweise mit ".ToString()" wo der Parameter die formatierung enthält.
                                                                                                        //In diesem Fall ist die Formatierung ein Komma nach jeder Tausenderstelle einzufügen um die Zahl lesbarer zu machen. Leider macht dies in diesem Fall wenig Sinn da wir hier keine Zahl haben die größer ist als 1.000
                }
            }
            Console.WriteLine($"Stack besitzt {newStack.Count:#,0} items");

            while (newStack.Count != 0)
            {
                newStack.Pop(); //Hier wird das zuletzt hinzugefügte Element ausgegeben und gleichzeitig aus der Collection entfernt.
            }
            Console.WriteLine($"Stack hat nun {newStack.Count:#,0} items");

            try
            {
                newStack.Pop(); //Genau wie beim Queue wirft das Stack eine Exception wenn man Pop() auf ein leeres Stack aufruft.
                                //Und wie beim Queue hat ein Stack eine "Peek()" funktion welche genau das tut was sie in der Queue macht.
            }
            catch (InvalidOperationException)
            {
                return;
            }
        }
    }
}
