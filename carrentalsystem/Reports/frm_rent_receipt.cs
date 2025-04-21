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
    public partial class frm_rent_receipt : Form
    {
        public frm_rent_receipt()
        {
            InitializeComponent();
        }

        private void frm_rent_receipt_Load(object sender, EventArgs e)
        {

            Rent_receipt d = new Rent_receipt();
            crystalReportViewer1.SelectionFormula = "{Payment.Pay_id}=" + Payment.Payid;
            crystalReportViewer1.ReportSource = d;
        }
    }
}
