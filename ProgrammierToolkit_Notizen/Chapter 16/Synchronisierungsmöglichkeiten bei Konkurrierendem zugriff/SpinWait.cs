using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Buffers;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.Synchronisierungsmöglichkeiten_bei_Konkurrierendem_zugriff
{
	class SpinWait
	{
		private const string _fileName = @"C:\Users\DCelik\Desktop\GeometricObjectSolution\GeometricObjectSolution\MultiThreadingFile.txt";

		public void PerformSpinWait()
		{
			if( File.Exists(_fileName) )
			{
				File.Delete(_fileName);
			}
			
			System.Threading.SpinWait spinWait = new System.Threading.SpinWait();
			System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
			int limit = 1000;

			for( int count = 0; count < 10; count++ )
			{
				for( int i = 0; i <= limit; i++ )
				{
					if( i == 0 )
					{
						Task.Run(() => WriteToFile(ref spinWait));
					}
					spinWait.SpinOnce();
				}
			}

			stopwatch.Start();
			spinWait.SpinOnce();
			stopwatch.Stop();
			Console.WriteLine($"Ein Spin dauerte {stopwatch.Elapsed} sekunden. Insgesamt wurden {spinWait.Count - 1} spins benötigt.");

			DetermineExactSpinCount();
		}

		private void DetermineExactSpinCount()
		{
			System.Threading.SpinWait spin = new System.Threading.SpinWait();
			int limit = 0;

			while( true )
			{
				try
				{
					for( int count = 0; count < 100; count++ )
					{
						for( int i = 0; i <= limit; i++ )
						{
							if( i == 0 )
							{
								Task.Run(() =>
								{
									try
									{
										WriteToFile(ref spin);
									}
									catch( IOException )
									{
										limit++;
									}
								});

							}
							spin.SpinOnce();
						}
					}
				}
				catch( IOException )
				{
					limit++;
				}
				break;
			}
			Console.WriteLine($"Es braucht min {spin.Count} spins um eine IOException zu verhindern.");
		}

		private void WriteToFile( ref System.Threading.SpinWait spinWait )
		{
			File.AppendAllText(_fileName, $"{nameof(SpinWait)}: {DateTime.Now:hh:mm:ss:ffff} {Environment.NewLine}");
		}
	}
}