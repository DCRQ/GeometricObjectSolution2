using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Delegaten_Ereignisse_und_Lambda_Ausdruecke
{
    class Delegates
    {
        #region Definition von Delegaten + Syntax
        //Delegaten sind 'pointer' oder verweise die eine Methode referenzieren.
        //Sprich: eine Methode wird in ein Verweis/Objekt gekapselt der auf die Methode zeigt. Dieser kann dann an einer beliebigen Stelle im Code ausgeführt werden.
        //Nur Funktionen mit dem selben Rückgabewert wie dem definierten Delegaten können diesem Delegaten zugewiesen werden.
        //Es ist nützlich wenn das Programm zur Laufzeit noch nicht weiß welche Funktion sie ausführen soll(bspw, bei Input-abhängigen Situationen). Man würde einen Delegaten eine Methode zuweisen und sie später auswerten.
        private delegate int SimpleDelegate(int i = 0);


        //Ein Delegat kann einen optionalen Parameter angeben AUCH WENN die Funktion der sie zugewiesen ist einen Parameter vorschreibt. Trotzdem darf das Parameterfeld des Delegaten nicht leer sein, solange die Methode Parameter verlangt. Der Delegat gibt bei leerem Parameterfeld den default Wert des optionalen Parameters(also 0) an(weil: int i = 0).
        //Delegaten die außerhalb von Klassen deklariert sind können nur statische Methoden annehmen.
        public void InvokeDelegates()
        {
            SimpleDelegate simpleDelegate = new SimpleDelegate(DelegateMethod); // Dem Delegaten "simpleDelegate" wird die Methode "DelegateMethod" zugewiesen
                                                                                //Anstatt die Methode mit dem new Modifizierer und dem Delegatennamen einem Delegaten zuzuweisen kann man auch schreiben: 
            SimpleDelegate simple = DelegateMethod;

            simpleDelegate += new SimpleDelegate(AnotherDelegateMethod); //Der Delegat "simpleDelegate" hat eine weitere Methode aufgenommen. Ein Delegat der Verweise zu mehreren Methoden hat nennt man "Multicast-Delegaten". Er wird bei Ausführung die beiden Methoden nacheinander aufrufen.
                                                                         //Delegaten kann man auf mehrere Weisen Multicasten. Man kann entweder die Funktion ".Combine()" aufrufen oder die Delegaten mit dem "+=" Operator überladen.
            simpleDelegate.Invoke();                                     //".Invoke()" ist ein Befehl der die ausführung der Methoden verlangt. Wenn der Delegat nicht vom Typ "void" ist kann man den Rückgabewert des Delegaten auch in eine Variable laden. (z.b. int result = simpleDelegate; / int result = simpleDelegate.Invoke(); Console.WriteLine(result);) 

            //Statt die ".Invoke()" Methode zu nutzen kann man Delegaten auch wie normale Methoden aufrufen wie unten:
            simple();


            Console.WriteLine("Generische Delegaten ausführen?[y/n]");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    GenericDelegates();
                    break;
                case "n":
                default:
                    return;
            }
        }
        #endregion

        #region Generische Delegat-Typen / Generic Delegates
        private void GenericDelegates()                                                                                     //Es gibt auch bereitgestellte Delegat-Typen wie 'Action' oder 'Func'. Beide haben ihren nutzen für folgende Fälle:
        {
            Action actionDelegateType = NoReturnMethod;                                                             //Delegat der keine Parameter annimmt und keinen Rückgabewert hat
            Action<string> actionDelegateTypeWithParameters = NoReturnMethodWithParameters;                         //Delegat der einen Parameter annimmt und keinen Rückgabewert hat
            Func<string> funcDelegateType = ReturnMethodWithNoParameters;                                           //Delegat der keine Parameter annimmt und einen Rückgabewert hat
            Console.WriteLine(funcDelegateType?.Invoke());
            Func<int, int, string> funcDelegateTypeWithMutlipleParameters = ReturnMethodWithMultipleParameters;     //Delegat der mehrere Parameter annimmt und einen Rückgabewert hat
            //Demo:
            Console.WriteLine(funcDelegateTypeWithMutlipleParameters.Invoke(2, 2));
        }
        #endregion

        #region Methoden die Delegaten zugewiesen werden
        private int DelegateMethod(int parameter)
        {
            Console.WriteLine($"{10 + parameter}");
            return 10 + parameter;
        }

        private int AnotherDelegateMethod(int g)
        {
            Console.WriteLine($"{5 + g}");
            return 5 + g;
        }

        private void NoReturnMethod()
        {
            Console.WriteLine("Für Delegaten ohne Rückgabewert(genutzt von 'Action').");
        }

        private void NoReturnMethodWithParameters(string line)
        {
            if (line != null)
            {
                Console.WriteLine("Für Delegaten mit Parameter aber ohne Rückgabewert(genutzt von 'Action<string>').");
            }
        }
        private string ReturnMethodWithMultipleParameters(int arg1, int arg2)
        {
            return $"Für Delegaten mit Rückgabewert und mehreren Parameter. Ergebnis der beiden Zahlen ist: {arg1} + {arg2} = {arg1 + arg2} ; (genutzt von 'Func<int,int,string>').";
        }

        private string ReturnMethodWithNoParameters()
        {
            return "Für Delegaten ohne Parameter aber mit Rückgabewert(genutzt von 'Func<string>').";
        }
        #endregion
    }
}
