using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16
{
	public class Threads	//Threads sind einfache Abzweigungen eines Programms welche auf einem einzelnen Prozessorkern laufen. 
							//Sie funktionieren indem das Betriebssystem eine bestimmte Zeitspanne für den Thread einräumt und das Hauptprogramm unterbrochen wird um den Thread laufen zu lassen.
							//Hat der Thread seine Aufgabe nicht erledigt wird das Hauptprogramm(aka MainThread) wieder gestartet und das Betriebssystem richtet einen weiteren Zeitschnipsel ein.
							//Die Zeitspannen sind im Programm so kurz dass es so aussähe als würden die Prozesse parallel laufen. Das ganze läuft so lange bis der Thread seine Aufgabe erledigt hat.
							//Ein Thread kann nur ein mal gestartet werden.
	{
		public void PerformThreads()
		{
			const int napTime = 1000;
			Thread thread1 = new Thread(ThreadMethodProvider);	//Der Thread wird mit "new" kreirt und über den Konstruktor mit einer Aufgabe/Operation versehen
			thread1.Name = "Thread_#1";	//Oft kann man Single-Core Threads einen Namen zuweisen. Die Property "Thread.Name" ist hierfür gedacht.

			Thread thread2 = new Thread(new ParameterizedThreadStart(MethodProviderWithParameter));	//Für Methoden mit Parameter wird ein "ParametizedThreadStart" Objekt genutzt dem wir die Methode übergeben.
																									//Den Parameter gibt man dann über, wenn der Thread per Befehl gestartet wird.
																									//Dies ist eine alte schreibweise und wird nur selten genutzt. Das Beispiel dient zum Verständnis.
																									//Der "ParametizedThreadStart" nimmt nur Parameter des Typ "Object" an. Daher muss man den Parameter in der Methode unboxen.
																									//info: boxing und unboxing sind Begriffe welche das verpacken von Variablen in einen höheren Datentypen beschreibt. Alle objekte sind in Typ "object" box-fähig.
																									//Das boxing findet implizit statt, aber das unboxing muss explizit angegeben werden.
			thread2.Name = "Thread_#2";
			
			Thread thread3 = new Thread(() => MethodProviderWithAbstractParameter(napTime));	//Die neue schreibweise für Parameterhaltige Methoden in Threads sieht vor dass man einen Action-Delegaten mit Parametern nutzt
																								//Dabei spielt der Datentyp des Parameters keine Rolle mehr und muss nicht gecastet werden. Unboxing ist nicht mehr nötig.
			thread3.Name = "Thread_#3";

			thread1.Start();	//Threads werden für gewöhnlich mit dem "Start()" Befehl gestartet. Threads können nur einmal gestartet werden.
			thread2.Start(napTime);	//Hier wird das Objekt für den "ParametizedThreadStart" aufgerufen
			thread3.Start();

			Thread.Sleep(5000);	//Thread.Sleep() Befiehlt dem zurzeit aktiven Thread seinen Code zu pausieren. Thread.Sleep() lohnt sich bei längeren schlafzeiten mehr als wenn man einen Thread für kurze Schlafzeiten anhält.
								//Das ständige einschlafen und erwachen des Threads kann auf dauer sehr rechenintensiv werden. Hier dient es nur zu demonstrationszwecken. Für sehr kurze Schlafzeiten eignet sich ein SpinWait-Objekt.
								//Der "aktive Thread" ist der Thread welcher die Thread.Sleep() Methode in sich einschließt. Thread.Sleep() kann von mehreren Threads individuell genutzt werden.

			Thread thread4 = new Thread(ThreadMethodProvider);
			thread4.Name = "Thread_#4";
			Thread thread5 = new Thread(new ParameterizedThreadStart(MethodProviderWithParameter));
			thread5.Name = "Thread_#5";
			Thread thread6 = new Thread(() => MethodProviderWithAbstractParameter(napTime));
			thread6.Name = "Thread_#6";

			thread4.Start();
			thread4.Join();
			thread5.Start(napTime);
			thread5.Join();
			thread6.Start();
			thread6.Join();

			Thread thread7 = new Thread(ThreadMethodProvider);
			thread7.IsBackground = true;
			thread7.Name = "Thread_#7";
			Thread thread8 = new Thread(new ParameterizedThreadStart(MethodProviderWithParameter));
			thread8.IsBackground = true;
			thread8.Name = "Thread_#8";
			Thread thread9 = new Thread(() => MethodProviderWithAbstractParameter(napTime));
			thread9.IsBackground = true;
			thread9.Name = "Thread_#9";

			thread7.Start();
			thread8.Start(napTime);
			thread9.Start();
		}

		public void ThreadMethodProvider()
		{
			Thread.Sleep(1500);
			if( string.IsNullOrEmpty(Thread.CurrentThread.Name) || !Thread.CurrentThread.Name.Contains("Thread") )
			{
				Console.WriteLine("ThreadPool/Worker Thread");
			}
			Console.WriteLine(Thread.CurrentThread.Name);
		}
		public void MethodProviderWithParameter(object obj )
		{
			int i = (int)obj;
			Thread.Sleep(i);
			if( string.IsNullOrEmpty(Thread.CurrentThread.Name) || !Thread.CurrentThread.Name.Contains("Thread") )
			{
				Console.WriteLine("ThreadPool/Worker Thread");
			}
			Console.WriteLine(Thread.CurrentThread.Name);
		}
		public void MethodProviderWithAbstractParameter(int i)
		{
			Thread.Sleep(i);
			if( string.IsNullOrEmpty(Thread.CurrentThread.Name) || !Thread.CurrentThread.Name.Contains("Thread") )
			{
				Console.WriteLine("ThreadPool/Worker Thread");
			}
			Console.WriteLine(Thread.CurrentThread.Name);
		}
	}
}
