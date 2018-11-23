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
            var t1 = Task.Run(() =>
            {
                while(true)
                {
                    if(Console.ReadKey(true).KeyChar == 'q')
                    {
                        cts.Cancel();
                        break;
                    }
                }
            });
            var t2 = Task.Run(() => { MainProc(cts.Token); });
            Task.WaitAll(t1, t2);
            cts.Dispose();
        }

        private static void MainProc(CancellationToken ctsToken)
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
