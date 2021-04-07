using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.Synchronisierungsmöglichkeiten_bei_Konkurrierendem_zugriff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.TPL;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16
{
	class Multithreading	//Multithreading ist das aufspalten eines Programmes um mehrere Operationen gleichzeitig erledigen zu können. 
							//Dabei gibt es viele mittel. Es wird unterschieden zwischen Synchronem Threading,Single-Core Multithreading, Multi-Core Multithreading und Asynchronem Threading.
							//Es muss erwähnt werden dass auch wenn der Computer asynchron Multitasking betreibt, diese Operationen in bestimmten Fällen zurück synchronisiert werden müssen.
							//Auch wenn die Klassen und Objekte verschieden benannt sind, wird jede abzweigung des Programms als "Thread" bezeichnet und im ThreadPool eingelagert bis sie erledigt sind.
							//Dabei werden asynchrone Operationen als "worker threads" bezeichnet während synchrone Threads über den Benutzer frei über eine Property benannt werden können.
							//Alle Threads haben jedoch eins gemeinsam: allen wird eine "ManagedThreadID" zugewiesen durch die man sie Identifizieren kann.
							//info: Es gibt einen ConcurrencyVisualizer, ein Erweiterungstool das man sich runterladen kann, welches alle Operationen und infos über die Hardwarenutzung ausgibt. 
	{
		public void PerformVariousThreadingPrinciples()
		{
			Threads threads = new Threads();	//Single-Core Multithreading mit asynchron und synchron option
			threads.PerformThreads();
			Tasks tasks = new Tasks();			//Multi-Core Threading Objekt welches ausschliesslich asynchron läuft
			tasks.PerformTasks();
			ThreadPool threadPool = new ThreadPool();	//Multi-Core Collection welche alle zu verrichtenden Aufgaben/Operationen enthält(Typ der Collection: Queue)
			threadPool.PerformThreadPoolThreads();
			Parallelism parallelism = new Parallelism();	//Klasse mit der man sehr viele Operationen gleichzeitig verrichten kann.
			parallelism.PerformParallelClass();
			Async_Await async = new Async_Await();	//Syntaktische schreibweise um eine Methode asynchron zu Spalten und auf einen Rückgabewert zu warten.
			async.PerformAsyncMethods();

			//Ab hier werde ich Objekte und Klassen vorstellen welche asynchrone threads synchronisieren um konkurrierenden Zugriff zwischen Threads zu regulieren.
			
			Mutex mutex = new Mutex();	//"Mutual Exclusion"(Mutex) symbolisiert eine Systemweite blockade für Threads die versuchen auf einen bestimmten bereich des Codes zuzugreifen.
			mutex.PerformMutex();
			Semaphore semaphore = new Semaphore();	//Semaphore bezeichnet ein limit die bestimmt wie viele Threads in einem bestimmten Teil des Codes erlaubt sind.
			semaphore.PerformSemaphore();
			SpinLock spinLock = new SpinLock();	//Spinlock beschreibt eine systemweite blockade welche jedoch konstant den Zugriff abfragt und die CPU nicht unnötig besetzt.
			spinLock.PerformSpinLock();
			SpinWait spinWait = new SpinWait();	//Ähnlich wie ein SpinLock aber es gibt keine Blockade sondern nur ein spin-basiertes Warten auf etwas.
			spinWait.PerformSpinWait();
			Monitor monitor = new Monitor();	//Monitor ist eine Prozessweite blockade über konkurrierendem Zugriff.
			monitor.PerformMonitor();
		}
	}
}
