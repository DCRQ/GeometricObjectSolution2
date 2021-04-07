using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen
{
    class ObservableCollection          //Eine ObservableCollection definiert eine Collection welche ein Event feuert sobald sie in einer Form verändert wird. Sie stellt einen EventHandler bereit welche man an eine Methode binden kann(Siehe Chapter: 5-7 "Events")
    {                                   //ObservableCollections werden häufig in WPF,MVVM und anderen UI-Projekten verwendet, da sie ein Two-Way-Databinding ermöglichen. Mit ihr kann man bspw. kontinuirlich Inhalte synchronisieren wenn diese sich verändern.
        static ObservableCollection<int> _observable = new ObservableCollection<int>();

        public static void PerformObservableCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                _observable.Add(i);
            }
            _observable.CollectionChanged += DoSomething_CollectionChanged; //Hier wird eine Methode an den EventHandler gebunden. Multicasting ist ebenfalls möglich.
            _observable[0] = 22;    //Die nächsten 5 Zeilen werden eine Reihe an Events feuern
            _observable[5] = 44;
            _observable.Add(150);
            _observable.Remove(44);
            _observable.Move(0, 7);
        }

        private static void DoSomething_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var collection = sender as ObservableCollection<int>;
            Console.WriteLine($"Die ObservableCollection wurde verändert!");
            ShowCollectionState(collection, e);
            Console.WriteLine();
            if (e.NewItems != null) //e.NewItems definiert eine Auflistung von elementen die sich in der ObservableCollection geändert haben
            {
                Console.WriteLine($"Neu definierter Wert: {e.NewItems[0]}");
            }
            if (e.OldItems != null)
            {
                Console.WriteLine($"Vorheriger Wert: {e.OldItems[0]}"); //e.OldItems definiert eine Collection von Elementen die den Zustand vor der Veränderung der ObservableCollection beinhalten
            }
            Console.WriteLine();
        }

        private static void ShowCollectionState(ObservableCollection<int> collection, NotifyCollectionChangedEventArgs e)
        {
            foreach (int i in collection)
            {
                Console.WriteLine(i);
            }
        }
        //Vorteile der ObservableCollection:
        //-Ermöglicht relativ performantes Data-Binding
        //-bietet eine gute und Praktische Möglichkeit zum Synchronisieren von Daten
        //-Um eine reaktionsfähige (eng. "Responsive") Collection zu besitzen muss die Collection oder eine Selbsterstellte Collection, das Interface "INotifyCollectionChanged" implementieren. Die ObservableCollection besitzt dies allerdings bereits in optimisierter Form

        //Nachteile der ObservableCollection:
        //-Trotz der Optimisierung ist die ObservableCollection in vielen Fällen langsamer als eine List-Collection.
        //-Der Overhead kann die Rechenleistung belasten bei großen Mengen an Daten
        //-Die ObservableCollection hat die Flexibilität einer Liste für mehr Transparenz und Interaktivität ausgetauscht.
    }
}
