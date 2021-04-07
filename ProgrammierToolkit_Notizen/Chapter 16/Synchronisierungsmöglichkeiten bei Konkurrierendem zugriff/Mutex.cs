using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.Synchronisierungsmöglichkeiten_bei_Konkurrierendem_zugriff
{
	class Mutex
	{
		private const string _fileName = @"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\MultiThreadingFile.txt";

		private readonly System.Threading.Mutex mutexField = new System.Threading.Mutex();

		public void PerformMutex()
		{
			if( File.Exists(_fileName) )
			{
				File.Delete(_fileName);
			}

			for( int i = 0; i < 10; i++ )
			{
				Task.Run(WriteToFile);
			}
		}

		private void WriteToFile()
		{
			using System.Threading.Mutex mutex = new System.Threading.Mutex(false, "OS-Übergreifender Mutex");
			mutex.WaitOne();

			File.AppendAllText(_fileName, $"{nameof(Mutex)}: {DateTime.Now:hh:mm:ss:ffff} {Environment.NewLine}");

			mutex.ReleaseMutex();
		}
	}
}
