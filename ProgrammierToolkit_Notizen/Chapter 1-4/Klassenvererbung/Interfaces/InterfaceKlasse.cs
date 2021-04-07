using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_1_4.Klassenvererbung.Interfaces
{
    class InterfaceKlasse : IExample, IExample_2    //Interfaces sind Schnittstellen welche Methoden und Properties einer Klasse zur verfügung stellen. Ist ein Interface erstmal vererbt worden muss jeder ihrer "Member"/Inhalte von der besagten Klasse genutzt werden.
                                                    //Interfaces ermöglichen es mehrere gleichnamige Methoden zu nutzen, sie sorgen für einen saubereren Programmablauf und machen die Programmabläufe schneller da sie alle anderen nicht beinhalteten member ausschließt.
                                                    //Interfaces können verschieden implementiert werden: Implizit und Explizit. Implizite Interfaces vererben ihre member als wären sie teil der Klasse und werden auch so im Programm aufgerufen
                                                    //Explizite Interfaces implementieren auf eine Weise wo nur eine Interface-Variable im Programm auf ihre member zugreifen kann. Diese Variable kann dann NUR Interface member aufrufen und nicht die member die in der Klasse sind.
                                                    //Bei der Expliziten implementierung wird Klasse und Interface getrennt gehalten und hat auf lange dauer einen bessere Performance als die implizite implementierung. Trotzdem ist die implizite Implementierung weniger zeitaufwendig und leichter zu programmieren.
    { 
        public int IntProperty { get; set; }        //So sieht eine implizite Interface-Implementierung aus
        string IExample_2.StringProperty { get; set; }  //So sieht eine explizite Interface-Implementierung aus

        public void SomeInterfaceMethod()   //Interface member stellen nur die Namen,Zugriffsmodifizierer und Datentypen bereit. Sie beinhalten keine Werte,Code oder Befehle. Daher muss man die Member neu definieren wenn man die Interfaces implementiert.
        {
            Console.WriteLine("Das ist eine Interface-Methode");
        }

        void IExample_2.SomePrivateInterfaceMethod()    //Dies ist eine weitere explizite implementation eines Interface-Members. Der Zugriffsmodifizierer ist von dem Interface selbst gegeben.
        {
            Console.WriteLine("Diese Methode kann nur außerhalb der Klasse über eine Interface Variable erreicht werden");
        }
    }
}
