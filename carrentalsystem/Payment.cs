using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using carrentalsystem.Reports;
namespace carrentalsystem
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection cn;
        OleDbDataReader dr;
        int flag = 0;
       public static int Payid;
        private void Payment_Load(object sender, EventArgs e)
        {

            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();
            setdropdown1();
            setGrid();
        }
        public void clearText()
        {
           // txt_bookid.Text = "";
            txt_payid.Text = "";
            txt_rate.Text = "";
            txt_tamt.Text = "";
            txt_startkm.Text = "";
            txt_endkm.Text = "";
            txt_totkm.Text = "";
            txt_tollrate.Text = "";
            txt_nooftolls.Text = "";
            txt_tollamt.Text = "";
            

        }
        public void EnabledText()
        {
            //txt_bookid.Enabled = true;
            txt_payid.Enabled = true;
           // txt_rate.Enabled = true;
            //txt_tamt.Enabled = true;
           // txt_totkm.Enabled = true;
            txt_startkm.Enabled = true;
            txt_endkm.Enabled = true;
           // txt_totkm.Enabled = true;
            txt_tollrate.Enabled = true;
            txt_nooftolls.Enabled = true;
          // txt_tollamt.Enabled = true;



        }
        public void DisableText()
        {
           // txt_bookid.Enabled = false;
            txt_payid.Enabled = false;
            txt_rate.Enabled = false;
            txt_tamt.Enabled = false;
            txt_startkm.Enabled = false;
            txt_endkm.Enabled = false;
            txt_totkm.Enabled = false;
            txt_tollrate.Enabled = false;
            txt_nooftolls.Enabled = false;
            txt_tollamt.Enabled = false;
        }
        public void setGrid()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select *from Payment";
            // dr = new OleDbDataReader();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
        }
        public int GetNewID()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select max(pay_id)from Payment";
            object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
            {
                return 1;
            }
            else
            {
                return (Convert.ToInt32(x) + 1);
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            flag = 1;
            txt_payid.Text = Convert.ToString(GetNewID());
            GetNewID();
            Payid = Convert.ToInt32(txt_payid.Text);
            EnabledText();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
        }
        public void setdropdown1()
        {

            cmd = new OleDbCommand("select *from  Booking", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "book_id";
            comboBox1.DisplayMember = "book_date";
            dr.Close();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;

            if (flag == 1)
            {
                cmd.CommandText = "insert into Payment values(" + txt_payid.Text + "," + comboBox1.SelectedValue+ "," + txt_rate.Text + "," + txt_startkm.Text + "," +txt_endkm.Text+","+txt_totkm.Text+","+txt_tollrate.Text+","+txt_nooftolls.Text+","+txt_tollamt.Text+","+ txt_tamt.Text + ")";
                int x = cmd.ExecuteNonQuery();
               frm_rent_receipt f = new frm_rent_receipt();
                f.Show();
                if (x > 0)
                    MessageBox.Show("Record inserted successfully");
                else
                    MessageBox.Show("Record not inserted");

            }
            else if (flag == 2)
            {
                cmd.CommandText = "update Payment set book_id=" + comboBox1.SelectedValue + ",rate_per_km=" + txt_rate.Text +",start_km="+txt_startkm.Text+",End_km="+txt_endkm.Text + ",total_km="+ txt_totkm.Text+ ",toll_rate="+ txt_tollrate.Text+", No_of_tolls="+ txt_nooftolls.Text+ ",total_tolls="+ txt_tollamt.Text+",total_amount="+txt_tamt.Text+" where pay_id=" + txt_payid.Text;
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show("Record updated successfully");
                else
                    MessageBox.Show("Record not updated");
            }
            setGrid();
            clearText();
            DisableText();
            btn_new.Enabled = true;
            btn_save.Enabled = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            flag = 2;
            EnabledText();
            btn_update.Enabled = false;
            btn_save.Enabled = true;
            btn_delete.Enabled = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from Payment where pay_id=" + txt_payid.Text;
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
                MessageBox.Show("Record deleted");
            else
                MessageBox.Show("Record not deleted");
            setGrid();
            clearText();
            DisableText();
            btn_delete.Enabled = false;
            btn_new.Enabled = true;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
             txt_payid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_rate.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_startkm.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_endkm.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_totkm.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txt_tollrate.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txt_nooftolls.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txt_tollamt.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            txt_tamt.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            btn_new.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            DisableText();
        }

        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txt_totkm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txt_tamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
       // static string book_id;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_totkm_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cmd = new OleDbCommand();
            //cmd.Connection = cn;
            //cmd.CommandText = "Select * from Booking where cust_id=" + comboBox1.SelectedValue;
            //dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    book_id = Convert.ToString(dr[0]);
            //}
            //dr.Close();
            //int idd;
            //cmd = new OleDbCommand("select car_id from Booking where book_id=" + book_id, cn);
            //object x = cmd.ExecuteScalar();

           // idd = Convert.ToInt32(x);
            cmd = new OleDbCommand("select rate_per_km from Car where car_id in (select car_id from booking where book_id="+comboBox1.SelectedValue+")", cn);
            object y = cmd.ExecuteScalar();
            txt_rate.Text = Convert.ToString(y);
            txt_startkm.Enabled = true;
        }

        private void txt_totkm_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void txt_totkm_MouseLeave(object sender, EventArgs e)
        {
           // int km = Convert.ToInt32(txt_rate.Text);
          //  int tokm = Convert.ToInt32(txt_startkm.Text);
        //    int fin = km * tokm;
            //txt_tamt.Text = Convert.ToString(fin);
           // int skm = Convert.ToInt32(txt_startkm.Text);
           // int ekm = Convert.ToInt32(txt_endkm.Text);
            //int tkm = skm * ekm;
            //txt_totkm.Text = Convert.ToString(tkm);
            //int trate = Convert.ToInt32(txt_tollrate.Text);
            //int notoll = Convert.ToInt32(txt_nooftolls.Text);
            //int totoll = trate * notoll;
            //txt_tollamt.Text = Convert.ToString(totoll);
            //int totamt = (tkm * km) + totoll;
            //txt_tamt.Text = Convert.ToString(totamt);
        }


        int tkm = 0;
     

       /* private void txt_nooftolls_MouseLeave(object sender, EventArgs e)
        {
            int km = Convert.ToInt32(txt_rate.Text);
            //  int tokm = Convert.ToInt32(txt_startkm.Text);
            //    int fin = km * tokm;
            //txt_tamt.Text = Convert.ToString(fin);
           // int skm = Convert.ToInt32(txt_startkm.Text);
            //int ekm = Convert.ToInt32(txt_endkm.Text);
            //int tkm = skm * ekm;
            //txt_totkm.Text = Convert.ToString(tkm);
            int trate = Convert.ToInt32(txt_tollrate.Text);
            int notoll = Convert.ToInt32(txt_nooftolls.Text);
            int totoll = trate * notoll;
            txt_tollamt.Text = Convert.ToString(totoll);
            int totamt = (tkm * km) + totoll;
            txt_tamt.Text = Convert.ToString(totamt);
        }
        private void txt_endkm_MouseLeave(object sender, EventArgs e)
        {
            int skm = Convert.ToInt32(txt_startkm.Text);
            int ekm = Convert.ToInt32(txt_endkm.Text);
             tkm = ekm-skm;
            txt_totkm.Text = Convert.ToString(tkm);
        }*/

        private void txt_endkm_MouseLeave_1(object sender, EventArgs e)
        {

            int skm = Convert.ToInt32(txt_startkm.Text);
            int ekm = Convert.ToInt32(txt_endkm.Text);
            tkm = ekm - skm;
            txt_totkm.Text = Convert.ToString(tkm);
        }

        private void txt_tollamt_MouseLeave(object sender, EventArgs e)
        {
            int km = Convert.ToInt32(txt_rate.Text);
            int trate = Convert.ToInt32(txt_tollrate.Text);
            int notoll = Convert.ToInt32(txt_nooftolls.Text);
            int totoll = trate * notoll;
            txt_tollamt.Text = Convert.ToString(totoll);
            int totamt = (tkm * km) + totoll;
            txt_tamt.Text = Convert.ToString(totamt);
        }
        
        private void txt_nooftolls_MouseLeave(object sender, EventArgs e)
        {
            int km = Convert.ToInt32(txt_rate.Text);
            //  int tokm = Convert.ToInt32(txt_startkm.Text);
            //    int fin = km * tokm;
            //txt_tamt.Text = Convert.ToString(fin);
            // int skm = Convert.ToInt32(txt_startkm.Text);
            //int ekm = Convert.ToInt32(txt_endkm.Text);
            //int tkm = skm * ekm;
            //txt_totkm.Text = Convert.ToString(tkm);
            int trate = Convert.ToInt32(txt_tollrate.Text);
            int notoll = Convert.ToInt32(txt_nooftolls.Text);
            int totoll = trate * notoll;
            txt_tollamt.Text = Convert.ToString(totoll);
            int totamt = (tkm * km) + totoll;
            txt_tamt.Text = Convert.ToString(totamt);
        }

        private void txt_rate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_startkm.Focus();
            }
        }

        private void txt_startkm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_endkm.Focus();
            }
        }

        private void txt_totkm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_tollrate.Focus();
            }
        }

        private void txt_tollrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_nooftolls.Focus();
            }
        }

        private void txt_payid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_rate.Focus();
            }
        }

        

      
 }
}
