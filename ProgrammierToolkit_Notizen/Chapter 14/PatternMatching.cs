using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
	class PatternMatching   //Pattern-Matching ist ein Feature aus der Funktionalen Programmierung und dient dazu das unboxing von Object-Objekten zu vereinfachen und performanter zu gestalten.
	{
		public void PerformPatternMatching()
		{
			object stringObject = "Das ist ein String";     //Hier werden 3 Objekte erstellt welche verschiedene Datentyp-Werte enthalten aber in "Object" verschachtelt wurden. 
			object intObject = 3291;                        //Objects werden zwar alle Datentypen annehmen aber der Computer erkennt von alleine nicht welchen Inhalt bzw welchen Datentyp das Objekt hat(oder hatte).
			object boolObject = false;

			PerformExtensivePatternMatching(intObject, false);	//Das ist die ausführlichste Art um Pattern-Matching zu implementieren
			PerformExtensivePatternMatching(stringObject, false);
			PerformExtensivePatternMatching(boolObject, false);
			Console.WriteLine();
			PerformExtensivePatternMatching(intObject, true);	//Wenn der bool auf true ist dann wechselt die Methode auf eine etwas schreibfreundlichere Art des Pattern-Matchings
			PerformExtensivePatternMatching(stringObject, true);
			PerformExtensivePatternMatching(boolObject, true);
			Console.WriteLine();
			Console.WriteLine(PerformSwitchWithoutCasesOrBreaks(intObject));	//Hier wird Pattern-Matching genutzt um schnell den Korrekten Datentyp ausfündig zu machen und auszugeben.
			Console.WriteLine(PerformSwitchWithoutCasesOrBreaks(stringObject));	//Dabei ist darauf zu achten dass die Methode als Dynamisch deklariert ist. Der Rückgabewert wird also während der Laufzeit festgelegt und ist somit flexibel.
			Console.WriteLine(PerformSwitchWithoutCasesOrBreaks(boolObject));
		}

		public void PerformExtensivePatternMatching( object newObject, bool switchOptions )
		{
			if( !switchOptions )
			{
				switch( newObject )		//Mit einer switch-anweisung wird überprüft ob der Inhalt eines Objekts zu einem der Datentypen passt.
				{
					case null:			//Wenn das Objekt "null" entspricht dann wird ein Text an das Konsolenfenster ausgegeben.
						Console.WriteLine("Es wurde kein Objekt übergeben");
						break;
					case int a when a > -1:	//Der Inhalt des Objects kann auch direkt in eine neue Variable kopiert und ausgegeben werden.
											//Auch bei switch-Cases kann man Constraints verhängen. Dies wird durch ein "when" keyword verdeutlicht und es wird die typisierte Variable benutzt.
						Console.WriteLine($"Das Objekt ist ein Integer. Wert: {a}");
						break;
					case string a when a.Length < 100:	
						Console.WriteLine($"Das Objekt ist ein String. Wert: {a}");
						break;
					case bool a:
						Console.WriteLine($"Das Objekt ist ein Bool. Wert: {a}");
						break;
					default:				//Wenn der Datentyp von den vorherigen cases nicht erkannt wird wird der default-case aktiviert. In dem Fall ist der typisierte Inhalt des Objects unbekannt.
						Console.WriteLine("Der Typ des Objektes ist unbekannt");
						break;
				}
			}
			else
			{

				string objectText = newObject switch	//Diese schreibweise stellt eine kürzere jedoch einzeilige Pattern-Matching Art vor. Mehr als eine Operation ist nicht möglich.
				{
					null => "Es wurde kein Objekt übergeben",
					int a when a > -1 => $"Das Objekt ist ein Integer. Wert: {a}",
					string a when a.Length < 100 => $"Das Objekt ist ein String. Wert: {a}",
					bool a => $"Das Objekt ist ein Bool. Wert: {a}",
					_ => "Der Typ des Objektes ist unbekannt.",
				};
				Console.WriteLine(objectText);
			}
		}

		private dynamic PerformSwitchWithoutCasesOrBreaks( object newObject ) => newObject switch       //Diese art des Pattern-Matching nutzt die kurze "lambda expression" schreibweise jedoch wird der Datentyp selbst direkt ausgegeben. 
		{
			null => "Es wurde kein Objekt übergeben",
			int a when a > -1 => a,
			string a when a.Length < 100 => a,
			bool a => a,
			_ => "Der Typ des Objektes ist unbekannt",
		};
	}

}
