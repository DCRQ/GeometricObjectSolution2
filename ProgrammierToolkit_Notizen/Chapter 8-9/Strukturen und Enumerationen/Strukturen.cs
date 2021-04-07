using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Strukturen_und_Enumerationen
{
    struct Strukturen 
    {
		//Ähnlich wie Klassen, können strukturen Eigenschaften, Methoden, Ereignisse und Konstruktoren beinhalten. Zudem können sie Interfaces Implementieren.
		public int StructWert { get; set; }				//In Strukturen ist das interne Instanziieren von Feldern oder Eigenschaften nicht erlaubt
		public int StructWert_2 { get; set; }
		public int StructWert_3 { get; set; }
		public Strukturen(int x, int y, int z)			//Ein struct sollte möglichst klein sein. Heißt also dass sie nur wenige Datentypen/Eigenschaften besitzen sollte. Methoden und andere Komponenten können zuhauf genutzt werden.
		{												//Ein struct hat immer einen parameterlosen Konstruktor der nicht überschrieben werden kann und nicht im Quellcode angezeigt wird.
			StructWert = x;								//Man kann weitere Konstruktoren definieren, allerdings nur mit Parameter und auch nur wenn durch den Konstruktor alle zu speichernden Datentypen instanziiert werden.
			StructWert_2 = y;							//Um das zu Demonstrieren wird hier die Methode "PerformStructMethod()" definiert.
			StructWert_3 = z;
		}
		public void PerformStructMethod()
		{
			Console.WriteLine($"{StructWert} + {StructWert_2} + {StructWert_3} = {StructWert + StructWert_2 + StructWert_3}");		//Hier werden die bereits instanziierten Eigenschaften zusammengerechnet. Wurden diese noch nicht durch einen Konstruktor instanziiert, ist das Ergebnis 0.
			Strukturen struktur = new Strukturen();
			Console.WriteLine($"{struktur.StructWert} + {struktur.StructWert_2} + {struktur.StructWert_3} = {struktur.StructWert + struktur.StructWert_2 + struktur.StructWert_3}");	//Hier wurde eine weitere Instanz von "Strukturen" erstellt und durch einen Parametrisierten Konstruktor instanziiert.
		}
	}	//zwar können Strukturen nicht von der Vererbung profitieren, dafür sind sie sehr nützlich wenn es darum geht viele Strukturobjekte zu erstellen die auch performant sind.
}		
