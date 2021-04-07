using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.TPL;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16
{
	public class Tasks
	{
		public void PerformTasks()
		{
			int napTime = 1000;

			Task task = new Task(() => MethodProvider(napTime));
			task.Start();
			try
			{
				task.Start();
			}
			catch
			{
				while( !task.IsCompleted )
				{
					Thread.Sleep(10);
				}
				Console.WriteLine("Es wurde versucht einen Task zwei mal zu starten");
				task.Dispose();
			}


			Task.Run(MethodProvider);
			Console.WriteLine("Dieser Task wurde Asynchron gestartet");

			Task<int> returnedTask = Task<int>.Run(MethodProvider);
			var tasksResult = returnedTask.Result;

			int returnedTasksResultValue = Task.Run(MethodProvider).Result;

			Console.WriteLine($"Rückgabewert des Asynchronen Tasks #1: {tasksResult}. Rückgabewert des Asynchronen Tasks #2: {returnedTasksResultValue}");
		}
	}
}
