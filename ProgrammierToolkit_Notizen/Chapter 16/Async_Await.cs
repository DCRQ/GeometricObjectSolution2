using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.TPL;
using System.Collections.Concurrent;
using System.Data.SqlTypes;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16
{
	class Async_Await
	{
		public async void PerformAsyncMethods()
		{
			Console.Clear();

			NewMethodAsync(2000);
			await NewMethodAsync(5000);
			Console.WriteLine("Nach Aufruf von 'await'");

			Task awaitableTask = Task.Run(() => NewMethodAsync());
			Console.WriteLine("Async-Task wird vor 'await' ausgeführt");
			await awaitableTask;

			Task task = Task.Run(async () => await NewMethodAsync());
			
			var result = await NewMethodAsync();
		}

		public Task NewMethodAsync( int i )
		{
			return Task.Run(() =>
			{
				Console.WriteLine("Operation wird Asynchron gestartet...");
				Thread.Sleep(i);
				Console.WriteLine("Asynchrone Operation wurde vollendet");
			});
		}

		public Task<int> NewMethodAsync()
		{
			return Task.Run(() =>
			{
				var napTime = 1000;
				Console.WriteLine("Operation wird Asynchron gestartet...");
				Thread.Sleep(napTime);
				Console.WriteLine("Asynchrone Operation wurde vollendet");
				return napTime;
			});
		}
	}
}
