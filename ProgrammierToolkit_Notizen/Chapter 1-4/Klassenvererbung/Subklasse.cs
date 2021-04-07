using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Klassenvererbung
{
    class Subklasse : Basisklasse
    {
        public void StartSubClassMethod()
        {
            Console.WriteLine("Diese Methode wurde ebenfalls vererbt");
        }
    }
}