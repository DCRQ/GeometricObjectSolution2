using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.TPL;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16
{
	public class TPL
	{
		public static int MethodProvider()
		{
			int defaultNapTime = 1000;

			Console.WriteLine("Task wurde gestartet");
			Thread.Sleep(defaultNapTime);
			return defaultNapTime;
		}

		public static void MethodProvider( int i )
		{
			Console.WriteLine("Task wurde gestartet");
			Thread.Sleep(i);
		}

		public static void MethodProviderWithoutParameter()
		{
			int defaultNapTime = 1000;

			Console.WriteLine("Task wurde gestartet");
			Thread.Sleep(defaultNapTime);
		}
	}
}
