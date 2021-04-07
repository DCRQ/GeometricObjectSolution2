using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Polymorphie
{
    class PolymorphieBeispiel
    {
        public void PerformPolymorphie()
        {
            Basisklasse_PolymorphieBeispiel basisklasse = new Basisklasse_PolymorphieBeispiel();    //Polymoprhie ist wenn man viele instanzen einer Klasse hat und deren gleichnamige Methode aufruft, wo der Computer weiß in welcher Subklasse er nachsehen muss um die richtige Methode auszuführen
            basisklasse.PolymorphieMethode();                                                   //Beispielsweise Faken wir hier Polymorphie, da wir dem Programm explizit mitteilen wo er nachschauen soll
            Subklasse_PolymorphieBeispiel subklasse = new Subklasse_PolymorphieBeispiel();      //Wahre Polymorphie zeichnet sich dadurch aus dass sie implizit weiß welche Subklasse die richtige ist ohne es explizit aufzuschreiben
            subklasse.PolymorphieMethode();                                                     //Polymorphie hat viele Vorteile. Zum einen kann man komplexe Prozesse runterbrechen und automatisieren,es bietet eine praktische Art an Methodennamen wieder zu verwerten und nicht zu guter letzt erhöht es die Sicherheit in manchen fällen 
            Subklasse_2_PolymorphieBeispiel subklasse_2 = new Subklasse_2_PolymorphieBeispiel();
            subklasse_2.PolymorphieMethode();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Basisklasse_PolymorphieBeispiel[] basisklassen = new Basisklasse_PolymorphieBeispiel[3];    //In diesem Teil wird "wahre" Polymorphie demonstriert. Hier wird eine sammlung an Bsisklassen erstellt.
            basisklassen[0] = new Basisklasse_PolymorphieBeispiel();                                    //Dann werden den instanzen der Basisklassen der Weg zu den Subklassen zugeordnet
            basisklassen[1] = new Subklasse_PolymorphieBeispiel();                                      //Schliesslich wird eine schleife genutzt um die gleichnamige Methode aufzurufen, jedoch mit einer Basisklassenreferenz!
            basisklassen[2] = new Subklasse_2_PolymorphieBeispiel();                                    
            foreach(Basisklasse_PolymorphieBeispiel basis in basisklassen)                              //Die basisklassenreferenz weiß genau welche Methode wir haben wollen auch wenn wir nur die Basisklasse aufrufen.
            {                                                                                           //Das Zusammenspiel von Klassendefinition, Kapselung und Klassenvererbung kommen hier zusammen und unterstützen die Polymorphie, welche die letzte der 4 Säulen der Objekt-Orientierten Programmierung ist
                Console.WriteLine();                                                                    //Wie genau Polymorphie in den einzelnen Klassen implementiert wird, erfährt Ihr indem Ihr auf die Klasse klickt und F12 drückt.
                basis.PolymorphieMethode();
                Console.WriteLine();
            }
        }
    }
}
