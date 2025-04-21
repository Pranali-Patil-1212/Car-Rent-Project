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
    public partial class frm_Booking : Form
    {
        public frm_Booking()
        {
            InitializeComponent();
        }

        private void frm_Booking_Load(object sender, EventArgs e)
        {
            rpt_Booking r = new rpt_Booking();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
