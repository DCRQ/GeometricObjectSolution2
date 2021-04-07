using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometricObjectSolution;
using GeometricObjectSolution.ProgrammierToolkit_Notizen;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Klassendefinition;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Datenkapselung;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Klassenvererbung;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Polymorphie;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Delegaten_Ereignisse_und_Lambda_Ausdruecke;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Strukturen_und_Enumerationen;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_10.Debugging_und_Exceptions;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_12.Auflistungsklassen;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_13;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14;
using GeometricObjectSolution.ProgrammierToolkit_Notizen._15;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16;

namespace GeometricObjectSolution
{
	class PerformClass                  //Performklasse ist nur zu Demonstrationszwecken gedacht! Sie beinhaltet keine Erklärungen und gehört nicht zu den Notizdateien. Sie existiert nur um Code auszuführen!
	{
		public class NotizKlassen
		{
			BeispielKlasse beispiel = new BeispielKlasse();
			public Klassendefinition klassendefinition = new Klassendefinition();
			public Datenkapselung datenkapselung = new Datenkapselung();
			public Klassenvererbung klassenvererbung = new Klassenvererbung();
			public PolymorphieBeispiel polymorphie = new PolymorphieBeispiel();
			public Delegates delegates = new Delegates();
			public Events events = new Events();
			public Lambda_Ausdrücke ausdrücke = new Lambda_Ausdrücke();
			public Strukturen structs = new Strukturen(3, 3, 3);
			public Enumerationen enumerationen = new Enumerationen();
			public Debugging debugging = new Debugging();
			public Exceptions exceptions = new Exceptions();
			public Auflistungsklassen auflistungsklassen = new Auflistungsklassen();
			public GenerischeKlasse<int> generischeKlasse = new GenerischeKlasse<int>();
			public WeitereSprachFeatures WeitereSprachFeatures = new WeitereSprachFeatures();
			public Serialisierung Serialisierung = new Serialisierung();
			public Multithreading multithreading = new Multithreading();
		}
		static void Main()
		{
			Console.SetWindowPosition(0, 0);
			Console.SetWindowSize(220, 40);
			NotizKlassen notizKlassen = new NotizKlassen();
			#region Abfrage
			while( true )
			{
				Console.WriteLine("Chapter 1-4: Klassendefinition, Datenkapselung, Klassenvererbung & Polymorphie");
				Console.WriteLine("Chapter 5-7: Delegates,Events & Lambda-Ausdrücke");
				Console.WriteLine("Chapter 8-9 Strukturen & Enumerationen");
				Console.WriteLine("Chapter 10-11 Exceptions & Debugging");
				Console.WriteLine("Beispielklasse");
				Console.WriteLine();
				_ = int.TryParse(Console.ReadLine(), out int auswahl);
				switch( 12 )
				{
					case 0:
						Console.WriteLine();
						notizKlassen = new NotizKlassen();
						Console.WriteLine();
						break;
					case 1:
						Console.WriteLine();
						notizKlassen.klassendefinition.ClassMethod();
						Console.WriteLine();
						break;
					case 2:
						Console.WriteLine();
						Console.WriteLine("Bitte gib eine Zahl ein.");
						notizKlassen.datenkapselung.OuterField = int.Parse(Console.ReadLine());
						Console.WriteLine();
						break;
					case 3:
						Console.WriteLine();
						notizKlassen.klassenvererbung.PerformInheritance();
						Console.WriteLine();
						break;
					case 4:
						Console.WriteLine();
						notizKlassen.polymorphie.PerformPolymorphie();
						Console.WriteLine();
						break;
					case 5:
						Console.WriteLine();
						notizKlassen.delegates.InvokeDelegates();
						Console.WriteLine();
						break;
					case 6:
						Console.WriteLine();
						notizKlassen.events.FireEvents();
						Console.WriteLine();
						break;
					case 7:
						Console.WriteLine();
						notizKlassen.ausdrücke.CallLambdaExpressions();
						Console.WriteLine();
						break;
					case 8:
						Console.WriteLine();
						notizKlassen.structs.PerformStructMethod();  //Konstruktor-Instanziiert!
						Console.WriteLine();
						break;
					case 9:
						Console.WriteLine();
						notizKlassen.enumerationen.GetAllEnumerationValues();
						Console.WriteLine();
						break;
					case 10:
						Console.WriteLine();
						notizKlassen.exceptions.PerformExceptionHandling();
						Console.WriteLine();
						break;
					case 11:
						Console.WriteLine();
						notizKlassen.debugging.PerformDebugging();
						Console.WriteLine();
						break;
					case 12:
						Console.WriteLine();
						notizKlassen.auflistungsklassen.PerformCollectionDemonstration();
						Console.WriteLine();
						break;
					case 13:
						Console.WriteLine();
						notizKlassen.generischeKlasse.PerformGenericClasses();
						Console.WriteLine();
						break;
					case 14:
						Console.WriteLine();
						notizKlassen.WeitereSprachFeatures.Perform();
						Console.WriteLine();
						break;
					case 15:
						Console.WriteLine();
						notizKlassen.Serialisierung.PerformSerialization();
						Console.WriteLine();
						break;
					case 16:
						Console.WriteLine();
						notizKlassen.multithreading.PerformVariousThreadingPrinciples();
						Console.WriteLine();
						break;
					default:
						break;
				}
			} 
			#endregion

			//#region Essentials
			//void PerformProgrammingEssentials()
			//{
			//    InvokeDelegates();
			//    events.FireEvents();
			//}
			//#endregion

			//#region Notes
			//void PerformGeometricObjectSolutionNotes()
			//{
			//    geometricObjectSolution.PerformGeometricObjectSolution();
			//}
			//#endregion

		}
	}
}
