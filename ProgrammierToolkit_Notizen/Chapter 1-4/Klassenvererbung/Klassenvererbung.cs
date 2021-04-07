using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_1_4.Klassenvererbung.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Klassenvererbung
{
    class Klassenvererbung
    {
        public void PerformInheritance()
        {
            Subklasse_2 subklasse_2 = new Subklasse_2();
            subklasse_2.StartBaseClassMethod();
            subklasse_2.StartSubClassMethod();
            subklasse_2.StartSubClassMethod_2();
            Console.WriteLine("Alle Funktionen wurden aus einer Klasse aufgerufen!");

            Interfaces_und_Mehrfachvererbung mehrfachvererbung = new Interfaces_und_Mehrfachvererbung();
            mehrfachvererbung.PerformInterfaces();
        }
    }

    class Interfaces_und_Mehrfachvererbung : InterfaceKlasse, IDisposable       //Mehrfachvererbung ist wenn eine Klasse von mehreren Basisklassen erbt. In C# gibt es keine Mehrfachvererbung per se, sondern es gibt Interfaces welche, wie Klassen, Properties und Methoden zur verfügung stellt, die Subklasse aber dazu zwingt sie zu benutzen.
                                                                                //Zudem kann ein Interface keine Daten enthalten. Nur bezeichner. In diesem Fall ist ein Interface vergleichbar mit einer Schablone beim Zeichnen. Die Umrisse sind gegeben aber den Inhalt muss man selbst ausfüllen.
                                                                                //Das ist in der Hinsicht ein Vorteil da bei gewöhnlicher Mehrfachvererbung schnell Chaos entsteht durch den man nicht durchblicken kann. Wenn man jedoch Interfaces benutzt ist man sich sicher dass was immer das Interface enthält, auch garantiert benutzt wird.
                                                                                //Das entlastet auch den Programmablauf indem er bei einer expliziten Interfaceimplementation unnötige "Member"(= Daten die der Klasse angehören) ignoriert und sich komplett auf die Interface-Member beschränkt.(siehe: InterfaceKlasse.cs)
    {
        public void PerformInterfaces()
        {
            //Interface: InterfaceKlasse-Member die von "IExample" zur verfügung gestellt wurden 
            IntProperty = 1;        //Implizite implementation können wie gewöhnliche Klassen-Member aufgerufen werden
            SomeInterfaceMethod();

            //Interface: "IExample_2" über "InterfaceKlasse"-Klasse explizit per IExample_2-Variable zugegriffen
            IExample_2 example = new InterfaceKlasse();     //"example" kann nur auf "IExample_2"-Member zugreifen die in "InterfaceKlasse" implementiert sind. Auf keine anderen Member. 
                                                            //"example" kann explizit auf jede "IExample_2"-Member zugreifen von jeder Klasse die "IExample_2" implementiert. Nicht nur "InterfaceKlasse". 
                                                            //Dazu müsste man einfach den Klassennamen hinter dem "new" keyword anpassen.
            example.SomePrivateInterfaceMethod();
            example.StringProperty = "Darauf kann nur eine Interface-Variable zugreifen";

            Console.WriteLine(example.StringProperty);

            //Interface: "IDisposable"
            Dispose();  //Normalerweise steht "IDisposable" für eine "Dispose()"-Methode welche aufräumarbeiten tätigt und Speicher befreien soll. In diesem Fall aber ist sie nur zu Beispielzwecken implementiert und tut praktisch nix.
        }

        public void Dispose()
        {
            return;
        }
    }
}
