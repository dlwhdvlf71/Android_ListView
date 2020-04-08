using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log;
using Log.Tools;
using System.Threading;
using Log.Extensions;

namespace LogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pro = new Program();

            pro.func3();
        }

        #region function
        public void func1()
        {
            //Console.Write(Application.Root);
            //Console.ReadLine();

            //return;

            LogManager log = new LogManager(LogType.Monthly, "log_", null);

            //log.WriteLine("[Begin Processing " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "] -------------------------------");
            log.WriteLineConsole("[Begin Processing " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "] -------------------------------");
            for (int i = 0; i < 5; i++)
            {
                log.WriteLineConsole("Start Processing : " + i.ToString());
                //log.WriteLine("Start Processing : " + i.ToString());
                //Console.WriteLine("Start Processing : " + i.ToString());

                Thread.Sleep(1000);

                //log.WriteLine("End Processing : " + i.ToString());
                //Console.WriteLine("End Processing : " + i.ToString());
                log.WriteLineConsole("End Processing : " + i.ToString());
            }

            //log.WriteLine("[End Processing " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "] -------------------------------");
            log.WriteLineConsole("[End Processing " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "] -------------------------------");

            Console.ReadLine();

        }

        public void func2()
        {
            try
            {
                String val = "213";

                Console.WriteLine(val.IsDateTime());
                Console.WriteLine(val.IsNumeric());

                Console.ReadLine();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void func3()
        {
            try
            {
                DateTime date = DateTime.Now;

                Console.WriteLine(date.FirstDateOfMonth());
                Console.WriteLine(date.LastDateOfMonth());

                Console.ReadLine();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }


    /*
     * 확장메서드는 항상 static 클래스 안에 선언되어야 한다.
     * 확장메서드는 static 함수로 선언되어야 한다.
     * */

    public static class ExtensionTest
    {
        // public static void 'name' (this 확장할 Type) 
        public static void WriteConsole(this LogManager log, String data)
        {
            try
            {
                log.Write(data);
                Console.Write(data);
            }
            catch(Exception ex)
            {

            }
        }

        public static void WriteLineConsole(this LogManager log, String data)
        {
            try
            {
                log.WriteLine(data);
                Console.WriteLine(data);
            }
            catch (Exception)
            {

            }
        }
    }

  
}
