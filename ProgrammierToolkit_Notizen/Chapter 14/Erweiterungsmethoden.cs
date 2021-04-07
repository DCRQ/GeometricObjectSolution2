using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    public class Erweiterungsmethoden  //Erweiterungsmethoden sind Methoden welche einer bereits existierenden Klasse hinzugefügt werden. 
                                       //Wenn man bspw. Eine Klasse hat welche als "sealed" markiert ist wie die "String"-Klasse, dann kann man eine Erweiterungsmethode erstellen um der Klasse weitere Funktionen zu geben obwohl sie mit "sealed" markiert wurde.
                                       //Zudem sind Erweiterungsmethoden vererbbar und können somit der Polymorphie in die Hände spielen.
    {
        public void PerformExtensionMethods()   //Hier werden die Erweiterungsmethoden im Codeblock getriggert.
        {
            this.PerformExtensionMethodFromAnotherClass();
            this.PerformGenericExtensionMethodFromAnotherClass<int>();
            this.PerformExtensionMethodWithParameter(2);
        }

    }
}
