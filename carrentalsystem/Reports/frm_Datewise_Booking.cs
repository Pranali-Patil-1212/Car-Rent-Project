using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace carrentalsystem.Reports
{
    public partial class frm_Datewise_Booking : Form
    {
        public frm_Datewise_Booking()
        {
            InitializeComponent();
        }
       //OleDbCommand cmd;
        OleDbConnection cn;
       // OleDbDataReader dr;

        private void frm_Datewise_Booking_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();

        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            rpt_Booking r = new rpt_Booking();
           crystalReportViewer1.SelectionFormula = "Date({Booking.book_date})>=Date('" + dateTimePicker1.Value + "')and Date({Booking.book_date})<=Date('" + dateTimePicker2.Value + "')";
            crystalReportViewer1.ReportSource = r;
        }

    
    }
}
