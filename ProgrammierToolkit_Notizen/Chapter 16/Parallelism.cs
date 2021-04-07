using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using static GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16.TPL;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16
{
	public class Parallelism
	{
		public void PerformParallelClass()
		{
			Action[] actions = new Action[3]
			{
					() => MethodProviderWithoutParameter(),
					() => MethodProviderWithoutParameter(),
					() => MethodProviderWithoutParameter(),
			};

			int[] totalIterations = new int[5] { 100_000, 1_000_000, 5_000_000, 10_000_000, 100_000_000 };
			Console.WriteLine("Starte Delegaten Parallel");
			Parallel.Invoke(actions);
			Console.WriteLine();
			
			Console.WriteLine("Starte For-Loops parallel");
			CompareForLoopPerformance(totalIterations);
			Console.WriteLine();

			Console.WriteLine("Starte ForEach-Loops parallel");
			CompareForEachLoopPerformance(totalIterations);
		}

		private static void CompareForEachLoopPerformance( int[] totalIterations )
		{
			for( int i = 0; i < totalIterations.Length; i++ )
			{
				int iterations = totalIterations[i];
				Action[] actions = new Action[iterations];
				double[] arr = new double[iterations];
				for( int index = 0; index < iterations; index++ )
				{
					actions[index] = new Action(() => arr[iterations - 1] = Math.Pow(iterations, 0.333) * Math.Sqrt(Math.Sin(iterations)));
				}

				Stopwatch stopwatch = new Stopwatch();

				stopwatch.Start();
				ParallelForEachWork(actions);
				stopwatch.Stop();
				var parallelTime = stopwatch.Elapsed;

				Console.WriteLine($"ForEach Loop-Count: {iterations}");
				Console.WriteLine($"Parallel: {Environment.NewLine }---{parallelTime}---");


				stopwatch.Reset();
				stopwatch.Start();
				SynchronizedForEachWork(actions);
				stopwatch.Stop();

				var synchronizedTime = stopwatch.Elapsed;

				Console.WriteLine($"Synchronized: {Environment.NewLine}---{synchronizedTime}---");
				Console.WriteLine($"Difference: {parallelTime.Subtract(synchronizedTime)}");
				Console.WriteLine();
			}
		}

		private static void CompareForLoopPerformance( int[] totalIterations )
		{
			Stopwatch stopwatch = new Stopwatch();
			for( int i = 0; i < totalIterations.Length; i++ )
			{
				int loops = totalIterations[i];

				stopwatch.Start();
				ParallelForWork(loops);
				stopwatch.Stop();

				Console.WriteLine($"For Loop-Count: {loops}");
				Console.WriteLine($"Parallel: {Environment.NewLine }---{stopwatch.Elapsed}---");

				var parallelTime = stopwatch.Elapsed;

				stopwatch.Reset();
				stopwatch.Start();
				SynchronizedForWork(loops);
				stopwatch.Stop();

				var synchronizedTime = stopwatch.Elapsed;

				Console.WriteLine($"Synchronized: {Environment.NewLine}---{stopwatch.Elapsed}---");
				Console.WriteLine($"Difference: {parallelTime.Subtract(synchronizedTime)}");
				Console.WriteLine();
			}
		}

		private static void SynchronizedForWork( int loops )
		{
			double[] arr = new double[loops];
			for( int i = 0; i < loops; i++ )
			{
				arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
			}
		}

		private static void SynchronizedForEachWork( Action[] actions )
		{
			foreach( Action action in actions )
			{
				action.Invoke();
			}
		}

		private static void ParallelForWork( int loops )
		{
			double[] arr = new double[loops];
			Parallel.For(0, loops, i =>
			{
				arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
			});
		}

		private static void ParallelForEachWork( Action[] actions )
		{
			Parallel.ForEach(actions, ( t ) => t.Invoke());
		}
	}
}
