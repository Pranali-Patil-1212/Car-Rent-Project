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
    public partial class frm_Customer : Form
    {
        public frm_Customer()
        {
            InitializeComponent();
        }

        private void frm_Customer_Load(object sender, EventArgs e)
        {
            rpt_Customer r = new rpt_Customer();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
