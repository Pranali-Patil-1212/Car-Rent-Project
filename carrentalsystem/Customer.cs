using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
namespace carrentalsystem
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection cn;
        OleDbDataReader dr;
        int flag = 0;
        private void Customer_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();
            setGrid();
        }
        public void clearText()
        {
            txt_custid.Text = "";
            txt_custnm.Text = "";
            txt_custaddr.Text = "";
            txt_custphone.Text = "";
            txt_custemail.Text = "";
            txt_custadhar.Text = "";
        }
        public void EnabledText()
        {
            txt_custid.Enabled = true;
            txt_custnm.Enabled = true;
            txt_custaddr.Enabled = true;
            txt_custphone.Enabled = true;
            txt_custemail.Enabled = true;
            txt_custadhar.Enabled = true;
        }
        public void DisableText()
        {
            txt_custid.Enabled = false;
            txt_custnm.Enabled = false;
            txt_custaddr.Enabled = false;
            txt_custphone.Enabled = false;
            txt_custemail.Enabled = false;
            txt_custadhar.Enabled = false;
        }

        public void setGrid()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select *from Customer";
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
            cmd.CommandText = "select max(cust_id)from Customer";
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
            txt_custid.Text = Convert.ToString(GetNewID());
            GetNewID();
            EnabledText();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
            txt_custnm.Focus();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;

            if (flag == 1)
            {
                cmd.CommandText = "insert into Customer values(" + txt_custid.Text + ",'" + txt_custnm.Text + "','"+txt_custaddr.Text+"',"+txt_custphone.Text+",'"+txt_custemail.Text+"', "+txt_custadhar.Text+ ")";
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show("Record inserted successfully");
                else
                    MessageBox.Show("Record not inserted");

            }
            else if (flag == 2)
            {
                cmd.CommandText = "update Customer set cust_nm='" + txt_custnm.Text + "',cust_addr='" + txt_custaddr.Text + "',cust_phone=" + txt_custphone.Text + ",cust_email='" +txt_custemail.Text+ "',cust_adhar_no="+txt_custadhar.Text+ " where cust_id=" + txt_custid.Text;
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
            cmd.CommandText = "delete from Customer where cust_id=" + txt_custid.Text;
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt_custid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_custnm.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_custaddr.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_custphone.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_custemail.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_custadhar.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            btn_new.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            DisableText();
        }

        private void txt_custnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
               // MessageBox.Show("Please enter characters");
                e.Handled = true;
            }
        }

        private void txt_custaddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
               // MessageBox.Show("No special characters are allowed");
                e.Handled = true;
            }
        }

        private void txt_custphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
              //  MessageBox.Show("Please enter numbers");
                e.Handled = true;
            }

        }

        private void txt_custemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = "([0-9a-zA]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txt_custemail.Text, pattern))
            {
               // MessageBox.Show("Please enter valid email");
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txt_custemail, "Please provide valid mail address");
            }
        }

        private void txt_custid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 txt_custnm.Focus();
            }

        }

        private void txt_custnm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 txt_custaddr.Focus();
            }
        }

        private void txt_custaddr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 txt_custphone.Focus();
            }
        }

        private void txt_custphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_custemail.Focus();
            }
        }

        private void txt_custemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_custadhar.Focus();
            }
        }

        private void txt_custadhar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }

        private void txt_custadhar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
               // MessageBox.Show("Please enter numbers");
                e.Handled = true;
            }
        }

    }
  }


