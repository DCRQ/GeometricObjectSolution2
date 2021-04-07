using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    class VarTypen  //Das "var" keyword, beschreibt eine Variable für einen Datentyp der auf der rechten seite des gleichheitszeichen definiert wird. 
    {               //Das "var" keyword wird die Variable automatisch zur Kompilierzeit seinem Datentyp zuweisen.
        public static void PerformVarTypes()
        {
            var x = new DateTime(2020, 06, 01, 10, 11, 50, 54);  //Da auf der rechten seite des Gleichheitszeichens ein Wert des Typen "DateTime" zugeordnet wird wird aus dem "var" automatisch ein DateTime-Objekt. Hier wird ein DateTime definiert welches das heutige Datum + Zeit + Millisekunden angibt.
            Console.WriteLine(x.GetType()); //Wenn man mit der Maus über dem "var" schwebt kann man auch sehen was der Compiler aus dem var gemacht hat. Nämlich eine DateTime instanz.
        }   //Im prinzip ist "var x = new DateTime();" nichts weiter als "DateTime x = new DateTime();". Es verkürzt die schreibarbeit beim Coden und ist hilfreich beim erstellen von anonymen Objekten/Klassen.
    }
    class AnonymeTypen  //Ein Anonymer Typ ist nichts weiter als eine Klasse welche keine explizite definition im Code oder in einer Datei hat. Sie kann nicht von sich aus Objekte instanziieren und ist nur lokal zugänglich. Außerdem ist sie "readonly", kann also nicht überschrieben werden.
    {
        public static void PerformAnonymousTypes()
        {
            var anonymousObject = new { Zahl = 0, Zeichen = "0" };  //Hier wird eine Klasse erstellt welche nur 2 Properties besitzt: Zahl und Zeichen. Keiner der properties ist veränderbar und nur zum auslesen geeignet. 
                                                                    //Dies kann nützlich sein wenn man viele Daten in einen einzigen Aufruf/einzige Variable zusammenfassen möchte.
            Console.WriteLine($"{nameof(anonymousObject)}: {anonymousObject.GetType()} | {nameof(anonymousObject.Zahl)}: {anonymousObject.Zahl}, {nameof(anonymousObject.Zeichen)}: {anonymousObject.Zahl.GetType()} | {anonymousObject.Zeichen}, {anonymousObject.Zeichen.GetType()}");
        }
    }
}
