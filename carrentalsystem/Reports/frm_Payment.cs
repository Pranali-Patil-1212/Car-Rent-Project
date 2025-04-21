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
    public partial class frm_Payment : Form
    {
        public frm_Payment()
        {
            InitializeComponent();
        }

        private void frm_Payment_Load(object sender, EventArgs e)
        {
            rpt_Payment r = new rpt_Payment();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
