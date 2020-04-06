using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log;
using Log.Tools;
using System.Threading;

namespace LogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write(Application.Root);
            //Console.ReadLine();

            LogManager log = new LogManager(LogType.Monthly, "START_", null);

            log.WriteLine("[Begin Processing " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "] -------------------------------");

            for(int i = 0; i < 5; i++)
            {
                log.WriteLine("Start Processing : " + i.ToString());
                Console.WriteLine("Start Processing : " + i.ToString());

                Thread.Sleep(1000);

                log.WriteLine("End Processing : " + i.ToString());
                Console.WriteLine("End Processing : " + i.ToString());
            }

            log.WriteLine("[End Processing " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "] -------------------------------");

        }
    }
}
