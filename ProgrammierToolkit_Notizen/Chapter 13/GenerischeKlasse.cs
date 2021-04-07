using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_13
{
	class GenerischeKlasse<T>   //Generische Klassen sind klassen die einen platzhalter für einen Datentypen bereitstellen. Ähnlich wie parameter, sind diese Platzhalter gedacht nur bestimmte Datentypen zu akzeptieren. 
								//Bspw. kann man in einer List<int> nur den Typ Int32 hinzufügen. Und zu List<string> kann man nur string-elemente hinzufügen.
								//Generische Klassen machen das aufwendige Boxing & Unboxing unnötig und tragen so zur abstraktion und effizienz einer Applikation bei.
								//Wenn man eine Generische Klasse definiert deklariert man den Platzhalter innerhalb dreieckigen Klammern ( "<>" ) und schreibt den namen des Platzhalters rein. Generell wird der Buchstabe T gewählt weil T für "Type" steht.
	{
		public GenerischeKlasse()
		{

		}
		public void PerformGenericClasses()
		{
			GenerischeSubklasse<int, List<int>, string, bool, SpinLock> generischeSubklasse = new GenerischeSubklasse<int, List<int>, string, bool, SpinLock>();
			generischeSubklasse.Dispose();
			generischeSubklasse.Dispose<int>();
		}

		public T Property { get; set; } //Alle Operationen die den Plathalter miteinbeziehen werden mit Rücksicht auf den zukünftigen Datentyp vollzogen. Heißt also dass wenn eine GenerischeKlasse<int> Instanz kreirt wird dann wird aus jedem T automatisch ein Integer-Typ. 
										//Deshalb muss man aufpassen dass die Operationen nicht nur für "int"-Typen gelten sondern auch für "String"-Typen oder "bool"-Typen(außer es wurden Constraints gesetzt).

	}

	class GenerischeKlasse<T, E> : GenerischeKlasse<T> where T : ICollection<T> where E : IEnumerable<E>
		//Constraints in C# werden mit dem "where" keyword definiert. Man setzt den Platzhalter nach dem "where" keyword an und gibt an von welcher Klasse oder welchem Interface der Platzhalter erben soll.
		//um mehrere Constraints setzen zu können stellt man unmittelbar nach dem ersten Constraints wieder ein "where" keyword an.
	{

	}

	class GenerischeKlasse<T, A, B, C, D> : GenerischeKlasse<T>, IDisposable where T : IEquatable<int>, IComparable where A : List<int> where B : class where C : struct where D : new()
		//Will man das ein Platzhalter mehrere Interfaces geerbt haben soll dann stellt man mehrere Interfaces/Klassen wie bei der gewöhnlichen Klassenvererbung hintereinander auf und separiert sie mit einem Komma.
		//Der Constraint "new()" sorgt dafür dass man den Platzhalter nur mit Klassen ersetzen kann die einen Parameterlosen Konstruktor haben. 
	{
		public new void PerformGenericClasses()
		{
			GenerischeKlasse<int, List<int>, string, DateTime, Random> generischeKlasse = new GenerischeKlasse<int, List<int>, string, DateTime, Random>();
			generischeKlasse.Dispose();
		}
		public void Dispose()
		{
			Console.WriteLine($"{nameof(T)} ist {typeof(T)} {Environment.NewLine}{nameof(A)} ist {typeof(A)} {Environment.NewLine}{nameof(B)} ist {typeof(B)} {Environment.NewLine}{nameof(C)} ist {typeof(C)} {Environment.NewLine}{nameof(D)} ist {typeof(D)} {Environment.NewLine}");
		}

		public void Dispose<t>() where t : struct
		{
			Console.WriteLine($"Generische Methode vom Typ: {typeof(t)}");
		}
	}

	class GenerischeSubklasse<T, A, B, C, D> : GenerischeKlasse<T, A, B, C, D>, IDisposable where T : IEquatable<int>, IComparable where A : List<int> where B : class where C : struct where D : new()
	{
		//Merke: "IDisposable" wird gewöhnlich dazu verwendet unkontrollierte/nicht verwaltete Resourcen vom Speicher zu befreien.
		//"Dispose()" ist die Methode welche die Aufräumarbeit erledigt und wird meistens von Klassen wie den "Stream"-Klassen oder der Task-Klasse bereits implementiert.
		//in unserem Fall wird Dispose() fälschlicherweise als Dummy-methode genutzt aus rein Demonstrationszwecken.
		public void Perform()
		{
			Dispose();
		}
	}
}
