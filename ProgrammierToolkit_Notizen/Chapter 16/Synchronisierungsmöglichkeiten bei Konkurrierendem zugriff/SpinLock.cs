using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.Synchronisierungsmöglichkeiten_bei_Konkurrierendem_zugriff
{
	class SpinLock
	{
		private const string _fileName = @"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\MultiThreadingFile.txt";
		private System.Threading.SpinLock spin = new System.Threading.SpinLock();

		public void PerformSpinLock()
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
			bool isLockTaken = false;

			spin.Enter(ref isLockTaken);
			File.AppendAllText(_fileName, $"{nameof(SpinLock)}: {DateTime.Now:hh:mm:ss:ffff} {Environment.NewLine}");
			spin.Exit(false);
		}
	}
}
