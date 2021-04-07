using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Web;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen._15
{
	public class Serialisierung     //Serialisierung ermöglicht das langzeitige Speichern und lesen von Objekten und deren Daten in einer Datei.  
									//Man wir sehen uns 3 Arten der Serialisierung an. Binär-, DataContract- und DataContractJson-Serialisierung.
									//Um zu Serialisieren muss man 3 schritte beachtem: 1. Etabliere einen Datenstrom (Stream,FileStream) 
									//													2. Erstelle einen Formatter oder Contractor(BinaryFormatter,DataContract)
									//													3. Markiere alle Member einer Klasse und die Klasse selbst, mit Serializable-Attributen
									//Serialisierung kann sehr nützlich sein wenn man mit verschiedenen Prozessen und Systemen Kommunizieren will, oder um bestimmten Fortschritt abzuspeichern (wie z.b. in Videospielen oder auto-save Anwendungen)
									//Je sicherer jedoch die Serialisierungsmethoden sind desto Komplexer funktionieren sie auch.
	{

		
		public void PerformSerialization( object serializableData = null )
		{
			if( serializableData == null )
			{

				//Die Klasse "DataClass" ist eine selbsterstellte Klasse die verschiedene Datentypen besitzt um später die deserialisierungsfunktion zu prüfen.
				DataClass datenklasse = new DataClass(69);
				serializableData = datenklasse;
			}
			PerformBinarySerialization(serializableData);
			Console.WriteLine();
			PerformDataContractSerialization();
			Console.WriteLine();
			PerformDataContractJsonSerialization();
			Console.WriteLine();
		}

		#region Serialisierung
		private void PerformBinarySerialization( object serializableData )
		//Binäre Serialisierung ist die wahrscheinlich einfachste form der Serialisierung. Diese Serialisierungsform speichert die Objekte in einem Binären format ab welches für menschen unlesbar ist.
		//und auch wenn sie sehr schnell und einfach zu implementieren ist ist sie auch sehr unsicher welches eine Angriffsfläche für bspw. Hacker bietet. Durch ihre Binäre verschlüsselung sind alle Objekte von jedem PC lesbar.
		{
			//An dieser Stelle wird der DatenStrom erzeugt. Ein Strom sorgt für eine kontinuirliche verbindung zwischen Applikation und Datei. Wer einen Datenstrom etabliert hat, kann nicht von außen auf die betroffene Datei zugreifen.
			//Man kann dies aber auch flexibel einstellen. Z.b. Kann man einstellen ob mehrere Datenströme auf eine Datei zugreifen dürfen und ob die nur aus der Datei lesen oder auch schreiben dürfen. 
			FileStream fileStream = new FileStream(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\BinaryData.dat", FileMode.Append, FileAccess.Write, FileShare.Read);

			//Der BinaryFormatter formatiert den Inhalt der Objekte in eine Binäre Schreibweise. Durch den Formatter können wir die Serialisierung aktivieren wenn wir den Datenstrom übergeben.
			BinaryFormatter formatter = new BinaryFormatter();

			//Man kann auch ein Array von Objekten Serialisieren. Warum ein Array gegenüber den Wiederholten Serialisierungsaufruf bevorzugt wird wird in der nächsten Methode erklärt.
			object[] objects = new object[] { serializableData, "u", 232, true };
			formatter.Serialize(fileStream, objects);
			//Es ist wichtig den Strom nach dem Schreiben, gleich wieder zu Schließen(via ".Close()") oder ggf. auch zu Entsorgen mit ".Dispose()".
			fileStream.Dispose();

			PerformBinaryDeserialization();
		}

		public void PerformDataContractSerialization()
		{
			//Die Klasse "ContractedClass" ist eine selbsterstellte Klasse die verschiedene Datentypen besitzt um später die deserialisierungsfunktion zu prüfen.
			ContractedClass contractedClass = new ContractedClass(66, "XML-Serialisiertes Objekt", true);

			//Ein Contractor wie den DataContractSerializer ist ähnlich wie der BinaryFormatter nur dass der DataContractSerializer im XML format die Objekte schreibt.
			//Ein Contractor schließt eine vereinbarung zwischen Applikation und Datei. Der Contractor nimmt nur Datentypen an die er vorher über die Parameter kennengelernt hat. Sonst droht eine SerializationException.
			DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(object), new List<Type>(4) { typeof(string), typeof(ContractedClass), typeof(int), typeof(bool), typeof(object[]) });

			FileStream fileStream = new FileStream(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\SerializedXMLData.dat", FileMode.Append, FileAccess.Write, FileShare.Read);

			//Wegen der Hirarchischen Struktur von XML Dateien kann nur ein Stammobjekt übergegeben werden. Mehrere Stammobjekte führt bei der Deserialisierung immer zu einer Exception. 
			//Glücklicherweise können wir Arrays und andere Collections problemlos Serialisieren. Somit kann man über ein workaround mehrere Objekte im XML format serialisieren und deserialisieren.
			//Bei Contractor heißt die Serialisierungsfunktion ".WriteObject()" und die Deserialisierungsfunktion ".ReadObject()".
			dataContractSerializer.WriteObject(fileStream, new object[4] { contractedClass, 9999, "Ist erfolgreich auf XML-Format serialisiert", true });
			fileStream.Dispose();

			//In der unteren Methode wird die selbe Datei wieder Deserialisiert
			PerformDataContractDeserialization();
		}

		public void PerformDataContractJsonSerialization()
		{

			//Ähnlich wie beim gewöhnlichen DataContractSerializer ist der DataContractJsonSerializer ein Contractor der aber auf ein JSon Format die Objekte schreibt.
			//Ein wichtiger unterschied ist das JSon keine Metadaten schreibt sondern nur öffentliche Member dazuzählt während das XML-Format fast alle Daten eines Objekts miteinbezieht.
			DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(object), new List<Type>(5) { typeof(int), typeof(object[]), typeof(bool), typeof(string), typeof(ContractedClass) });

			ContractedClass contractedClass = new ContractedClass(99, "JSon serialisiertes Objekt", true);

			FileStream fileStream = new FileStream(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\SerializedJSONData.dat", FileMode.Append, FileAccess.Write, FileShare.Read);

			jsonSerializer.WriteObject(fileStream, new object[4] { contractedClass, 6666, "Ist erfolgreich auf JSon-Format serialisiert", true });
			fileStream.Dispose();

			PerformDataContractJsonDeserializer();
		}
		#endregion

		#region Deserialisierung
		private void PerformBinaryDeserialization()
		{
			//wieder müssen wir einen Formatter aufrufen und einen Datenstrom zum lesen der Datei etablieren. Auch wieder müssen wir den Formatter mit den Datentypen vertraut machen.
			BinaryFormatter formatter = new BinaryFormatter();

			FileStream fileStream = new FileStream(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\BinaryData.dat", FileMode.Open, FileAccess.Read, FileShare.Read);

			//im folgendem Abschnitt wird eine While-Schleife benutzt um ein Objekt nach dem anderen aus der Datei zu lesen und in eine Liste zu verpacken.
			//Der formatter wird so lange deserialisieren bis der Datenstrom versiegt und keine Objekte mehr auszulesen sind. 
			object deserializationResult = null;
			List<object> objectsArray = new List<object>();
			while( true )
			{
				if( fileStream.Length == fileStream.Position )	//fileStream.Length beschreibt die Anzahl der Objekte in Bytes. Die Position gibt an an welcher Stelle wir von der Datei lesen. Wenn die Position so weit ist wie die maximale größe der Datei dann 
				{
					break;	//Wenn der Strom alle Objekte ausgelesen hat wird der Loop enden
				}
				deserializationResult = formatter.Deserialize(fileStream);
				objectsArray.Add(deserializationResult);
			}
			fileStream.Dispose();
			var result = PatternMatchingOnDeserialization(deserializationResult);	//Der Richtige Datentyp wird via Pattern-Matching ermittelt
			Console.WriteLine($"{result}. ");

			File.Delete(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\BinaryData.dat");	//Nachdem alles vorbei ist wird die erstellte Datei gelöscht.
		}

		private void PerformDataContractDeserialization()
		{
			FileStream fileStream = new FileStream(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\SerializedXMLData.dat", FileMode.Open, FileAccess.Read, FileShare.Write);

			DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(object), new List<Type>(5) { typeof(string), typeof(ContractedClass), typeof(int), typeof(bool), typeof(object[]) });
			var xmlSerializedObject = dataContractSerializer.ReadObject(fileStream);
			fileStream.Dispose();

			var result = PatternMatchingOnDeserialization(xmlSerializedObject);
			Console.WriteLine(result);

			File.Delete(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\SerializedXMLData.dat");
		}

		private void PerformDataContractJsonDeserializer()
		{
			FileStream fileStream = new FileStream(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\SerializedJSONData.dat", FileMode.Open, FileAccess.Read, FileShare.Write);

			DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(object), new List<Type>(5) { typeof(int), typeof(object[]), typeof(bool), typeof(string), typeof(ContractedClass) });

			var jsonSerializedObject = jsonSerializer.ReadObject(fileStream);
			fileStream.Close();

			var result = PatternMatchingOnDeserialization(jsonSerializedObject);
			Console.WriteLine(result);

			File.Delete(@"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\SerializedJSONData.dat");
		}
		#endregion

		#region Benutzerdefinierte Klassen
		[Serializable()]	//Jede Klasse die Binär Serialisiert werden soll muss das Serializable-Attribut vorweisen
		class DataClass
		{
			public DataClass( int value )
			{
				MyIntProperty = value;
			}

			private readonly string _type = $"{typeof(DataClass)}";
			public string Typ
			{
				get { return _type; }
			}

			public int MyIntProperty { get; set; } = 100;

			[NonSerialized()]	//Klassenmember welche nicht mitserialisiert werden sollen müssen das Attribut "NonSerialized()" vorweisen.
			public bool NonSerializableAttribute = false;
		}

		//Jede Klasse die durch einen Contractor Serialisiert werden soll muss das "DataContract"-Attribut vorweisen. 
		[DataContract(Name = "Serialization via DataContract Object", Namespace = "GeometricObjectSolution.ProgrammierToolkit_Notizen._15")]
		class ContractedClass
		{
			public ContractedClass( int intValue, string stringValue, bool boolValue )
			{
				MyIntProperty = intValue;
				MyStringProperty = stringValue;
				_myPrivateField = boolValue;
			}

			//Alle Klassenmember müssen das DataMember-Attribut vorweisen
			//Das DataMember-Attribut besitzt wichtige Parameter die bestimmen: 
			//1. Die ausgewählten Member bei jedem Lesen und schreiben mitserialisiert werden sollen
			//2. welchen namen die Member für die Serialisierung haben sollen
			//3. in welcher Reihenfolge sie Serialisiert werden sollen
			//4. ob default-Werte mitserialisiert werden sollen
			[DataMember(IsRequired = true, Name = "Int Property", Order = 3)]
			public int MyIntProperty { get; set; }

			[DataMember(EmitDefaultValue = false, IsRequired = true, Name = "String Property", Order = 1)]
			public string MyStringProperty { get; set; }

			public bool MyBoolProperty
			{
				get => _myPrivateField;
			}

			[DataMember(IsRequired = true, Name = "Bool Property", Order = 2)]
			internal bool _myPrivateField = false;
		}
		#endregion

		#region in Verbindung mit Pattern-matching
		private static string PatternMatchingOnDeserialization( object deserializationResult )
		{
			switch( deserializationResult )
			{
				case IEnumerable<object> deserializedObject:
					object[] deserializedArray = deserializedObject.ToArray();
					foreach( var deserializedArrayItems in deserializedArray )
					{
						switch( deserializedArrayItems )
						{
							case DataClass d:
								Console.WriteLine($"Typ: {d.Typ}, NonSerializable-Attribut für ein Feld: {d.NonSerializableAttribute}, Gespeicherter Wert der Klasse: {d.MyIntProperty}");
								break;
							case ContractedClass cC:
								Console.WriteLine($"Typ: {cC.GetType()}, NonSerializable-Attribut für ein Feld: {cC.MyBoolProperty}, Gespeicherte Werte der Klasse: {cC.MyIntProperty}, {cC._myPrivateField}, {cC.MyStringProperty}");
								break;
							case string s:
								Console.WriteLine($"Typ: {s.GetType()}, Wert: {s}");
								break;
							case int i:
								Console.WriteLine($"Typ: {i.GetType()}, Wert: {i}");
								break;
							case bool b:
								Console.WriteLine($"Typ: {b.GetType()}, Wert: {b}");
								break;
							case null:
								return null;
						}
					}
					return "Deserialization und Pattern Matching war erfolgreich";
				case ContractedClass cc:
					return "Deserialisierung und Pattern Matching war erfolgreich";
				case null:
					return "Deserialisierung und Pattern Matching war nicht erfolgreich";
				default:
					return "Deserialisierungstyp wurde nicht erkannt";
			}
		}
		#endregion

	}
}
