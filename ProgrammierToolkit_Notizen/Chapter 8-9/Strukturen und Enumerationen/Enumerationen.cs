using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Strukturen_und_Enumerationen
{
    public enum EnumExamples : int  //Standartmäßig ist der Datentyp einer Enumeration ein Integer. Wenn man den Datentyp jedoch ändern will muss man den Datentyp in das enum ableiten wie hier demonstriert.
    {                               //Ein enum kann nur Wertetypen als Datentyp besitzen. Werden den elementen keine Zahlen/Werte beigefügt dann werden diese Automatisch generiert. Der erste bezeichner fängt dann mit dem Wert 0 an, der Rest wird dann um 1 erhöht. 
        Example_1 = 1,
        Example_2 = 2,
        Example_3 = 3,
        Example_4 = 4
    }
    //im prinzip ist das Beispiel oben das Equivalent zu:
    public enum EnumExamples_2
    {
        Example_1 = 1,
        Example_2,
        Example_3,
        Example_4
    }
    //[...] aber dies liest sich nicht besonders gut.
    class Enumerationen
    {
        public void GetAllEnumerationValues()
        {
            //Console.WriteLine($"Bezeichner: {EnumExamples.Example_1}; Zahlenwert: {(int)EnumExamples.Example_1}");    //
            //Console.WriteLine($"Bezeichner: {EnumExamples.Example_2}; Zahlenwert: {(int)EnumExamples.Example_2}");    //
            //Console.WriteLine($"Bezeichner: {EnumExamples.Example_3}; Zahlenwert: {(int)EnumExamples.Example_3}");    //
            //Console.WriteLine($"Bezeichner: {EnumExamples.Example_4}; Zahlenwert: {(int)EnumExamples.Example_4}");    // <-- anstatt alles auszutippen wie hier könnte man auch eine Schleife benutzen wie folgt:

            foreach (EnumExamples examples in Enum.GetValues(typeof(EnumExamples)))
            {
                Console.WriteLine($"Bezeichner: {examples}; Zahlenwert: {(int)examples}");  //Wenn nur die enum-Instanz aufgerufen wird liefert das Programm nur den Bezeichner der Konstanten. Um den Zahlenwert zu erhalten muss man implizit konvertieren, also mit "(int)enumObjekt".
            }
        }
    }
}
