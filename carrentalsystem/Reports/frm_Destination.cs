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
    public partial class frm_Destination : Form
    {
        public frm_Destination()
        {
            InitializeComponent();
        }

        private void frm_Destination_Load(object sender, EventArgs e)
        {
            rpt_Destination r = new rpt_Destination();
            crystalReportViewer1.ReportSource = r;

        }
    }
}
