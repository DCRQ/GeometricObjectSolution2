using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen;
using System.Threading.Tasks;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen.Key_Value_Pair_Collections;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen.Besondere_Collections;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen.List_typen;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen
{
    class Auflistungsklassen    //Wie Arrays und Listen gibt es viele verschiedene Collection-Arten mit denen man Daten Sammeln und zwischenspeichern kann. Generell besitzen alle Collections eine innere Collection welche sie modifizieren und erweitern.
                                //Z.b. ist die Collection "List" so implementiert dass sie im hintergrund einen Array erstellt welcher immer wieder durch ein größeres Array ersetzt wird.
                                //Generell unterscheidet .Net alle Collections in 4 Namespaces: System.Collections.Generic
                                //                                                              System.Collections.ObjectModel
                                //                                                              System.Collections.Concurrent   und
                                //                                                              Systen.Collections.Specialized 
                                //Generell gilt auch dass Collections des "Generic" und "ObjectModel" Namespaces die Performantesten und sichersten Collections sind während die aus dem "Specialized" Namespace mehr schwerwiegende Nachteile haben und auf veralteter Technologie basieren.
                                //Collections des "Concurrent" Namespaces sind hingegen besonderer. Sie stellen neben einer Collection auch sicher dass nur ein Programm bzw. nur ein Thread auf die Collection zugreifen kann. Konkurrierender Zugriff, also Zugriff von mehreren Prozessen gleichzeitig wird also verhindert.
    {
        public void PerformCollectionDemonstration()    //In den verschiedenen Klassen wird erklärt um welche Art von Collection es sich handelt und was deren Vor-und Nachteile sind.
        {
			Console.WriteLine("HashSet?");
			if( !string.IsNullOrEmpty(Console.ReadLine()) )  Hashset.PerformHashSet();   //aus dem "Generic" Namespace
            Console.WriteLine("Queue?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) Queues.PerformQueue();  //aus dem "Generic" Namespace
            Console.WriteLine("Stack?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) Stacks.PerformStack();  //aus dem "Generic" Namespace
            Console.WriteLine("List?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) List.PerformLists();    //aus dem "Generic" Namespace
            Console.WriteLine("LinkedList?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) LinkedList.PerformLinkedList(); //aus dem "Generic" Namespace
            Console.WriteLine("Dictionary?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) Dictionary.PerformDictionaryOperations();   //aus dem "Generic" Namespace
            Console.WriteLine("ListDictionary?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) ListDictionary.PerformListDictionary(); //aus dem "Specialized" Namespace
            Console.WriteLine("HybridDictionary?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) HybridCollection.PerformHybridDictionary(); //aus dem "Specialized" Namespace
            Console.WriteLine("ObservableCollection?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) ObservableCollection.PerformObservableCollection(); //aus dem "ObjectModel" Namespace
            Console.WriteLine("BlockingCollecion?");
            if( !string.IsNullOrEmpty(Console.ReadLine()) ) BlockingCollection.PerformBlockingCollection(); //aus dem "Concurrent" Namespace

            //Mittlerweile wurden fast alle "Specialized" Collection in "Generic" Collections übersetzt und umbenannt, jedoch gibt es Ausnahmen

            //!ACHTUNG! Es ist sehr wichtig anzumerken, dass der Usecase(= Der Problemfall) der wichtigste Faktor für die Performance und eignung  einer Collection ist. Wählt also eine Collection aus die eurem Usecase entsprechen und nicht eine die nur eine etwas schnellere ausleserate hat
            //Eine schnelle Collection die falsch benutzt wird ist langsamer als eine langsamere Collection die passend benutzt wird.
        }
    }
}
