using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    public static class ErweiterungsmethodenProvider
    {
        public static void PerformExtensionMethodFromAnotherClass(this Erweiterungsmethoden obj)  //Die zu erweiternde Klasse wird hier mit dem keyword "this" verbunden. Damit auch klar ist dass diese Methode von dieser Klasse zur Klasse "Erweiterungsmethoden" gehört
                                                                                                  //Die zur erweiterung definierten Methoden müssen als static markiert sein. Nur so kann das Programm fehlerfrei auf die Methode in dieser Klasse zugreifen.
        {
            Console.WriteLine($"Dies ist eine Erweiterungsmethode für die Klasse {nameof(obj)}.");
        }
        public static void PerformExtensionMethodFromAnotherClass(this WeitereSprachFeatures obj)   //man kann in einer Klasse auch mehreren anderen Klassen Erweiterungsmethoden anbieten.
        {
            Console.WriteLine($"Dies ist eine Erweiterungsmethode für die Klasse {nameof(obj)}.");
        }

        public static void PerformGenericExtensionMethodFromAnotherClass<T>(this Erweiterungsmethoden obj) where T : struct     //Natürlich kann man auch generische erweiterungsmethoden hinzufügen. Man beachte aber dass alle erweiterungsmethoden als static markiert werden müssen
        {
            Console.WriteLine($"Dies ist eine generische Erweiterungsmethode für die Klasse {nameof(obj)}. {nameof(T)} ist Typ: {typeof(T)}.");
        }

        public static int PerformExtensionMethodWithParameter(this Erweiterungsmethoden obj, int parameter)
        {
            int result = parameter * parameter; //alternativ kann mit "Math.Pow()" potenziert werden
            Console.WriteLine($"{nameof(parameter)}² = {result}.");
            return result;
        }
    }
}
