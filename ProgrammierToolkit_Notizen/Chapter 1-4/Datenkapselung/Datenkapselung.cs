using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Datenkapselung
{
    class Datenkapselung
    {
		private int _innerField;					//Datenkapselung beschreibt eine Property welche durch ein privates Feld unterstützt werden.
													//Eine Property besitzt durch Datenkapselung höhere Sicherheit, sei es von fremden Zugriff auf den Quellcode oder mit Rücksicht auf Fehlerbehebung, Datenkapselung macht die langfristig zu speichernden Daten sicherer.
		public int OuterField					//Zwar kann man ein gekapseltes Feld über ein öffentlich zugängliches Feld erreichen, die dahinter verborgenen Operationen bleiben einem fremden jedoch unbekannt
		{									
			get { return _innerField; }         //Da die Datenkapselung nichts weiter ist als zwei Felder welche auf sich gegenseitig verweisen, kann man sie auch als Properties bezeichnen. 
			set                                     //folglich ist jede Property gekapselt und somit sicherer als ein Feld. Auf hinsicht der Performance sind gekapselte Daten weder aufwendig zu schreiben, noch sind sie Rechenintensiv. Daher sollte man für alle Variablen und Felder mit denen man langfristig arbeitet Properties verwenden.
			{
				Console.WriteLine($"Vor der Zuweisung: {_innerField}");
				_innerField = value;
				Console.WriteLine($"Nach der Zuweisung: {_innerField}");
			}			
		}										//Ziel ist es alle Operationen welche direkt mit der Property zusammenhängen, in einem "Unit" zu behalten
	}
}
