using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTemplateCore1
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            //program end 
            var t1 = Task.Run(() => { if (Console.ReadKey(true).KeyChar == 'q') cts.Cancel(); });
            var t2 = Task.Run(() => { MainPric(cts.Token); });
            Task.WaitAll(t1, t2);
            cts.Dispose();
        }

        private static void MainPric(CancellationToken ctsToken)
        {
            while (true)
            {
                //main logic
                Thread.SpinWait(50000000);

                if (ctsToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }
    }
}
