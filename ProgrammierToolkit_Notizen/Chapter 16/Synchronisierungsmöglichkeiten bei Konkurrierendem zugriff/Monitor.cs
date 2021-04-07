using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.Synchronisierungsmöglichkeiten_bei_Konkurrierendem_zugriff
{
	class Monitor
	{
		private const string _fileName = @"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\MultiThreadingFile.txt";

		private object writeLock = new object();

		public void PerformMonitor()
		{
			if( File.Exists(_fileName))
			{
				File.Delete(_fileName);
			}

			for( int i = 0; i < 10; i++ )
			{
				Task.Run(WriteToFile);
				Task.Run(WriteToFileAlternative);
			}
		}

		private void WriteToFile()
		{
			System.Threading.Monitor.Enter(writeLock);
			File.AppendAllText(_fileName, $"{nameof(Monitor)}: {DateTime.Now:hh:mm:ss:ffff} {Environment.NewLine}");
			System.Threading.Monitor.Exit(writeLock);
		}

		private void WriteToFileAlternative()
		{
			lock( writeLock )
			{
				File.AppendAllText(_fileName, $"{nameof(Monitor)} via lock-Keyword: {DateTime.Now:hh:mm:ss:ffff} {Environment.NewLine}");
			}
		}
	}
}
