using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_14
{
    class NullReferenzTypen
    {
        //C# hat seit seiner 7.3 version Nullable-Referenztypen implementiert. Diese sorgen dafür dass Referenztypen wie strings oder Klassen nicht "null" sein können oder zumindest sie als Warnung anzeigt.
        //Das kann sehr hilfreich sein da "null" ein nicht gegebener Wert ist der im Normalfall nicht lieber eine Exception werfen sollte um den Entwickler vor einem Logikfehler zu Warnen(Beispielsweise). 
        //Der einzige vorteil bei null-Werten ist dass sie eine zusätzliche Option bei manchen Operationen bietet, jedoch könnte man dies mit leichtigkeit ersetzen.
        //Um das non-nullable-reference-type Feature zu aktivieren muss man ganz oben im Quellcode, am besten direkt unter den using-Direktiven, den Befehl "#nullable enable" angeben. Der sorgt dafür dass alle null-Wertigen Refernztypen als Warnung unterstrichen werden.
        //Um sie als Fehler anzeigen zu lassen muss man im Solution-Explorer auf die Einstellungen/Properties klicken und unter "Build" die Option "Warnungen als Fehler behandeln" entweder auf "Alle" klicken, oder den Warnungscode in der option "Spezifische Warnungen:" angeben sodass nur die null-Warnungen als Fehler angezeigt werden.
        //Falls Ihr nicht wisst wo Ihr die Option finden könnt oder welchen Code ich an dieser Stelle meine, dann schaut am besten in diesem Projekt nach und Sucht im Internet was der Fehlercode bedeuted
        public void PerformNullableStrings()
        {
            //string x = null;      ////Entfernt die Kommentarzeichen(mit STRG + K & STRG + U) um die Fehlermeldung anzuzeigen und drückt STRG + K & STRG + C um die Zeile wieder ein zu kommentieren
            string? y = null;       //Natürlich kann man mit dem "?"-Operator alle Datentypen in Nullable-Typen umwandeln falls man doch einen null-Wert brauchen sollte.
                                    //Console.WriteLine(x);
            Console.WriteLine(y);
            string[] s = new string[2];
            Console.WriteLine(s[1]);
        }
    }
}
