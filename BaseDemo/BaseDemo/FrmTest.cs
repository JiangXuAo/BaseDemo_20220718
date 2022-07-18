using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using HKING.Log4Net;

namespace BaseDemo {

    public partial class FrmTest : DockContent {

        public FrmTest() {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e) {
            Log4NetService.GetInstance().WriteLog("Test");
        }
    }
}