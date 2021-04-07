using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen
{
    class BeispielKlasse
    {
        SemaphoreSlim Semaphore = new SemaphoreSlim(1,1);
        public void BeispielMain()
        {
            Console.WriteLine(Semaphore.CurrentCount);
            Semaphore.WaitAsync();
            for (int i = 0; i < 10; i++) { Console.WriteLine(i); }
            Semaphore.Release();
            Console.WriteLine(Semaphore.CurrentCount);
        }
    }
}
