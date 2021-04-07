using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen
{
    //Achtung! In diesem Abschnitt werden wir uns mit "Threads" und "Barrier" beschäftigen. Beides elemente die wir noch nicht durchgenommen haben aber in naher Zukunft uns annähern werden wenn es um Multithreading/Multitasking geht.
    //Aus diesem Grund werde ich euch jetzt eine kleine beschreibung zu Threads und Barrieren geben:
    //Thread: Ein Thread ist eine Spezifische Aufgabe welche unabhängig vom Rest des Programmes abläuft. Man stelle sich eine Abzweigung des Programms vor. Wenn das Hauptprogramm bspw darin besteht 2 Zahlen zu addieren kann man einen Thread definieren,
    //welcher pro Sekunde eine Zufallszahl(Im hintergrund) zum addieren generiert.

    //Barrier: einen Barrier-Klasse sorgt dafür dass sobald ein Thread einen bestimmten bereich erreicht hat, dieser Thread so lange pausiert bis die restlichen Threads am selben Punkt sind. Bspw sind in diesem programm zwei punkte wo die Threads aufgehalten werden.
    //Diese Punkte sind durch die Methode ".SignalAndWait()" definiert. Wenn "thread1" da angekommen ist dann wird thread1 so lange warten bis thread2 ebenfalls die SignalAndWait-Methode erreicht hat. Von da an werden beide Threads parallel,gleichzeitig den Programmablauf durchgehen,
    //bis sie erneut auf "SignalAndWait()" antreffen oder sie zum ende der Methode gelangen.
    class BlockingCollection
    {
        static Barrier _barrier = new Barrier(2);
        static BlockingCollection<int> _blockingCollection = new BlockingCollection<int>();    //eine BlockingCollection ist eine threadsichere Collection welche threads daran hindert auf den Inhalt zu zugreifen wenn ein thread bereits Zugriff auf den Collection-Inhalt erworben hat
        public static void PerformBlockingCollection()                                         //Die Threads welche von der BlockingCollection zurückgewiesen wurden warten so lange bis der Thread der davor den Zugriff erlangt hat, nicht mehr auf den Inhalt der Collection zugreift.
        {                                                                               //Welcher Thread als nächstes den Zugriff erhält hängt davon ab welcher Thread am schnellsten war. Es ist also das warteschlangenprinzip oder das FIFO-verfahren(First-In-First-Out). Wer zuerst kommt der wird auch als erster Bedient.
            Thread thread1 = new Thread(FillBlockingCollection);    //hier wird dem Thread eine Funktion zugewiesen
            Thread thread2 = new Thread(FillBlockingCollection);
            
            thread1.Start();    //Hier werden die Threads angestoßen
            thread2.Start();
            while (thread1.IsAlive || thread2.IsAlive)  //Damit das Programm nicht vor abschluss der Thread-tätigkeiten weiter macht wird der Main-Thread so lange "schlafen" bis die Threads ihre Aufgabe erledigt haben. Erst dann kehrt der Main-Thread zur Aufrufklasse zurück.
            {
                Thread.Sleep(500);
            }
        }
        static void FillBlockingCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                _barrier.SignalAndWait();       //Hier werden die Threads aufgehalten damit alle Threads gleichzeitig !versuchen! auf die BlockingCollection zugreifen
                _blockingCollection.Add(i);     //Die BlockingCollection wird nur einem Thread erlauben auf die Collection zuzugreifen. Andere threads müssen solange warten. Durch die ".Add()" Methode wissen wir auch dass die BlockingCollection eine Collection mit dynamischen größen ist.
            }
            _barrier.SignalAndWait();   //Hier werden wieder alle Threads aufgehalten um sie danach parallel auf die Collection loszulassen
            Console.WriteLine(_blockingCollection.Take()); //die ".Take()" Methode entfernt der aller ersten Wert der BlockingCollection und gibt diese dann als Rückgabewert aus. Ähnlich wie bei einem Queue oder einem Stack.

            //Vorteile einer BlockingCollection:
            //-Verhindert konkurrierenden Zugriff und ist Threadsicher
            //-Hat eine dynamische größe
            //-Gehört zum "System.Collection.Concurrent"-Namespace,welche Klassen besitzen die in Multithreadingoperationen wesentlich performanter, nützlicher und sicherer sind als "System.Collections.Generic"-Klassen

            //Nachteile:
            //-In gewöhnlichen, nicht Multithreading Programmen sind Concurrent-Collections eher Rechenintensiv und verbrauchen viele Resourcen.
            //-Bei sehr großen und komplexen Collections oder bei vielen zugreifenden Threads ist häufiger gebrauch nicht rechen-, sondern Zeitintensiv da die Threads gegenseitig auf sich warten bevor sie zugreifen können.
        }
    }
}
