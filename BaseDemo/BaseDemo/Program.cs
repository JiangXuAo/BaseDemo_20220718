using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDemo {

    internal static class Program {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main() {
            bool ret;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret) {
                try {
                    System.Windows.Forms.Application.EnableVisualStyles();   //这两行实现   XP   可视风格
                    System.Windows.Forms.Application.DoEvents();             //这两行实现   XP   可视风格
                    System.Windows.Forms.Application.Run(new FrmBase());
                } finally {
                    //   Main   为你程序的主窗体，如果是控制台程序不用这句
                    mutex.ReleaseMutex();
                }
            } else {
                MessageBox.Show(null, "应用程序已经在运行，请不要同时运行多个本程序。\n这个程序即将退出。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();//退出程序
            }
        }
    }
}