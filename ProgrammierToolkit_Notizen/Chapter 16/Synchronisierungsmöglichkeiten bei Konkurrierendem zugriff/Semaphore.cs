using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.Synchronisierungsmöglichkeiten_bei_Konkurrierendem_zugriff
{
	class Semaphore
	{
		private const string _fileName = @"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\MultiThreadingFile.txt";
		private static SemaphoreSlim semaphoreSlim = new System.Threading.SemaphoreSlim(1, 1);

		public void PerformSemaphore()
		{
			if( File.Exists(_fileName) )
			{
				File.Delete(_fileName);
			}

			for( int i = 0; i < 10; i++ )
			{
				Task.Run(WriteToFile);
			}
			Thread.Sleep(5000);
			for( int i = 0; i < 10; i++ )
			{
				Task.Run(SemaphoreSlimShowOff);
			}
		}

		private void WriteToFile()
		{
			using System.Threading.Semaphore semaphore = new System.Threading.Semaphore(1, 1, "OS-übergreifende Semaphore");
			semaphore.WaitOne();
			File.AppendAllText(_fileName, $"{nameof(Semaphore)}: {DateTime.Now:hh:mm:ss:ffff} {Environment.NewLine}");
			semaphore.Release();
		}

		private void SemaphoreSlimShowOff()
		{
			semaphoreSlim.Wait();
			File.AppendAllText(_fileName, $"{nameof(SemaphoreSlim)}: {DateTime.Now:hh:mm:ss:ffff} {Environment.NewLine}");
			semaphoreSlim.Release();
		}
	}
}
