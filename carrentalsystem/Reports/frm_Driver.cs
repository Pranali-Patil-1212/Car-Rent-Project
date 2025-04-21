using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace carrentalsystem.Reports
{
    public partial class frm_Driver : Form
    {
        public frm_Driver()
        {
            InitializeComponent();
        }

        private void frm_Driver_Load(object sender, EventArgs e)
        {
            rpt_Driver r = new rpt_Driver();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
