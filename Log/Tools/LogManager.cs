using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Log.Tools
{
    public enum LogType { Daily, Monthly, Yearly };

    public class LogManager
    {
        /*
         * 2020\04\01\20200401.txt
         * 
         * 2020\04\202004.txt
         * 
         * */
        
        private String _path;

        #region 생성자
        public LogManager(String path, String prefix, String postfix, LogType logType = LogType.Daily)
        {
            _path = path;
            _SetLogPath(logType, prefix, postfix);
            // test
        }

        public LogManager()
            : this(Path.Combine(Application.Root, "Log"), null, null)
        {
        }

        public LogManager(LogType logType)
            : this(Path.Combine(Application.Root, "Log"), null, null, logType)
        {
        }

        public LogManager(String prefix, String postfix)
            : this(Path.Combine(Application.Root, "Log"), prefix, postfix)
        {
        }

        public LogManager(LogType logType, String prefix, String postfix)
            : this(Path.Combine(Application.Root, "Log"), prefix, postfix, logType)
        {
        }
        #endregion

        private void _SetLogPath(LogType logtype, String prefix, String postfix)
        {
            String path = String.Empty;
            String name = String.Empty;

            switch (logtype)
            {
                case LogType.Daily:

                    path = String.Format(@"{0}\{1}\{2}\", DateTime.Now.Year, DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));
                    name = DateTime.Now.ToString("yyyyMMdd");

                    break;

                case LogType.Monthly:

                    path = String.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMM");

                    break;

                case LogType.Yearly:

                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyy");

                    break;
            }

            if (!String.IsNullOrEmpty(prefix))
            {
                name = prefix + name;
            }

            if (!String.IsNullOrEmpty(postfix))
            {
                name += postfix;
            }

            name += ".txt";

            _path = Path.Combine(_path, path);

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
         
            _path = Path.Combine(_path, name);
            
        }

        #region 사용 함수
        public void Write(String data)
        {
            /*
             * using 사용시 해당 스코프 안에 있는 코드가 작성되면 시스템이 자동으로 닫는 작업을 실행해준다.
             * */
            try
            {
                using (StreamWriter sw = new StreamWriter(_path, true))
                {
                    sw.Write(data);
                }
            }catch(Exception ex) { }
        }

        public void WriteLine(String data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss \t") + data);
                }
            }catch(Exception ex) { }
        }
        #endregion

    }
}
