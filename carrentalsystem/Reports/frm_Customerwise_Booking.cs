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
    public partial class frm_Customerwise_Booking : Form
    {
        public frm_Customerwise_Booking()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection cn;
        OleDbDataReader dr;
        private void frm_Customerwise_Booking_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();
            Setdropdown();

        }
        public void Setdropdown()
        {
            cmd = new OleDbCommand("select *from Customer", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "cust_id";
            comboBox1.DisplayMember = "cust_nm";
            dr.Close();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            rpt_Booking r = new rpt_Booking();
            crystalReportViewer1.SelectionFormula = "{Booking.cust_id}=" + comboBox1.SelectedValue;
            crystalReportViewer1.ReportSource = r;

        }
    }
}
