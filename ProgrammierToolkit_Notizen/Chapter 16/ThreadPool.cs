using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16;

namespace GeometricObjectSolution.ProgrammierToolkit_Notizen.Chapter_16
{
	class ThreadPool
	{
		readonly Threads threads = new Threads();
		public void PerformThreadPoolThreads()
		{
			int napTime = 1000;
			System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(obj => threads.ThreadMethodProvider()));
			System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(obj => threads.MethodProviderWithParameter(napTime)));
			System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(obj => threads.MethodProviderWithAbstractParameter(napTime)));
		}
	}
}
