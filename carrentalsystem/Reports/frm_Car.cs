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
    public partial class frm_Car : Form
    {
        public frm_Car()
        {
            InitializeComponent();
        }

        private void frm_Car_Load(object sender, EventArgs e)
        {
            rpt_Car r = new rpt_Car();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
