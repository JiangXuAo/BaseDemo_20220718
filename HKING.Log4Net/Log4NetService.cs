using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace HKING.Log4Net {

    public class Log4NetService {
        private static Log4NetService instance = new Log4NetService();

        private Log4NetService() {
        }

        public static Log4NetService GetInstance() {
            return instance;
        }

        public void WriteLog(string info) {
            LogHelper.WriteLog(info);
        }

        public void WriteLog(string info, Exception ex) {
            LogHelper.WriteLog(info, ex);
        }
    }
}