using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Polymorphie
{
    class Basisklasse_PolymorphieBeispiel
    {
        public virtual void PolymorphieMethode()            //Um Polymorphie möglich zu machen muss eine Basisklasse zur verfügung stehen
        {                                                   //Diese Basisklasse muss in alle Klassen die Polymorphie-Fähig sein sollen, abgeleitet werden.
            Console.WriteLine("Das ist die Basismethode!"); //Als nächstes muss diese Basisklasse eine Methode zur verfügung stellen welche mit dem "virtual" oder "abstract" keyword versehen ist.
        }                                                   //virtual oder abstract bedeuted dass die Subklasse welche die Basisklasse erbt, die methoden der Basisklasse annehmen und benutzen kann.
    }                                                       //Das großartige an Polymorphie ist dass sie ein Angebot von Basisklassen an die Subklassen ist. Sie soll die Methode der Basisklasse bereitstellen. 
}                                                           //Die Subklassen müssen selbst entscheiden ob sie das Angebot annehmen und die Methode der Basisklasse benutzen, oder ob sie Ihre eigene Methode verwenden oder die Basisklassenmethode modifizieren
                                                            //
                                                            //Der Unterschied zwischen "virtual" und "abstract" ist das virtual den Subklassen erlaubt das Angebot abzulehnen während abstract die Subklassen dazu zwingt die Basisklassenmethoden zu erben.
                                                            //Wenn man also "abstract" sieht dann weiß man ganz genau dass in dieser Klasse die Methode verändert bzw gänzlich vererbt/geerbt wurde.
                                                            //Die basisklassenmethode könnte leer stehen, aber solange "abstract" davor steht MUSS die Subklasse diese Methode überschreiben.
                                                            //"virtual" hingegen gibt den Subklassen lediglich die OPTION die Basisklassenmethode zu überschreiben. Sie sind nicht dazu gezwungen.
                                                            //Daher muss man aufpassen und nachprüfen sobald man "virtual" vor einer Methode sieht, und prüfen in wiefern die Methode überschrieben wurde oder OB sie überhaupt überschrieben wurde.

    //Hier wird nur das "virtual" beispiel getestet, einfach aus dem Grund da "abstract" in diesem Fall nicht viel verändern würde. Das Prinzip bleibt das selbe.