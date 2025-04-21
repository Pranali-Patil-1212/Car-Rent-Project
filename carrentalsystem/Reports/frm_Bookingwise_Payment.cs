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
    public partial class frm_Bookingwise_Payment : Form
    {
        public frm_Bookingwise_Payment()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection cn;
        OleDbDataReader dr;
        private void frm_Bookingwise_Payment_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();
            Setdropdown();
        }
        public void Setdropdown()
        {
            cmd = new OleDbCommand("select *from Booking", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "book_id";
            comboBox1.DisplayMember = "book_id";
            dr.Close();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {

            rpt_Payment r = new rpt_Payment();
            crystalReportViewer1.SelectionFormula = "{Payment.book_id}=" + comboBox1.SelectedValue;
            crystalReportViewer1.ReportSource = r;
        }
    }
}
