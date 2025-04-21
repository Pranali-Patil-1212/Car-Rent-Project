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
    public partial class Driver : Form
    {
        public Driver()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection cn;
        OleDbDataReader dr;
        int flag = 0;
        private void Driver_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();
            setGrid();
        }
        public void clearText()
        {
            txt_daddr.Text = "";
            txt_dadhar.Text = "";
            txt_demail.Text = "";
            txt_did.Text = "";
            txt_dlice.Text = "";
            txt_dnm.Text = "";
            txt_mobno.Text = "";

        }
        public void EnabledText()
        {
            txt_daddr.Enabled = true;
            txt_dadhar.Enabled = true;
            txt_demail.Enabled = true;
            txt_did.Enabled = true;
            txt_dlice.Enabled = true;
            txt_dnm.Enabled = true;
            txt_mobno.Enabled = true;
        }
        public void DisableText()
        {
            txt_daddr.Enabled = false;
            txt_dadhar.Enabled = false;
            txt_demail.Enabled = false;
            txt_did.Enabled = false;
            txt_dlice.Enabled = false;
            txt_dnm.Enabled = false;
            txt_mobno.Enabled = false;
        }
        public void setGrid()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select *from Driver";
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
            cmd.CommandText = "select max(driver_id)from Driver";
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
           txt_did.Text = Convert.ToString(GetNewID());
            GetNewID();
            EnabledText();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;

            if (flag == 1)
            {
                cmd.CommandText = "insert into Driver values(" + txt_did.Text + ",'" + txt_dnm.Text + "'," + txt_mobno.Text + ",'" + txt_demail.Text + "','" + txt_daddr.Text + "', '" + txt_dlice.Text + "',"+txt_dadhar.Text+")";
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show("Record inserted successfully");
                else
                    MessageBox.Show("Record not inserted");

            }
            else if (flag == 2)
            {
                cmd.CommandText = "update Driver set driver_nm='" + txt_dnm.Text + "',driver_mobile=" + txt_mobno.Text + ",driver_email='" + txt_demail.Text + "',driver_address='" + txt_daddr.Text + "',driver_license='" + txt_dlice.Text + "',driver_adhar_no="+txt_dadhar.Text+" where driver_id=" + txt_did.Text;
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
            cmd.CommandText = "delete from Driver where driver_id=" + txt_did.Text;
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
            txt_did.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_dnm.Text= dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_mobno.Text= dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_demail.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_daddr.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_dlice.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txt_dadhar.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            btn_new.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            DisableText();
        }

        private void txt_dnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                
                e.Handled = true;
            }
        }

        private void txt_mobno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                
                e.Handled = true;
            }
        }

        private void txt_demail_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = "([0-9a-zA]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txt_demail.Text, pattern))
            {
                
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txt_demail, "Please provide valid mail address");
            }
        }

        private void txt_daddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
               // MessageBox.Show("No special character is allowed");
                e.Handled = true;
            }
        }

        private void txt_dlice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
               // MessageBox.Show("No special character is allowed");
                e.Handled = true;
            }
        }

        private void txt_did_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_dnm.Focus();
            }
        }

        private void txt_dnm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_mobno.Focus();
            }

        }

        private void txt_mobno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_demail.Focus();
            }
        }

        private void txt_demail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_daddr.Focus();
            }
        }

        private void txt_daddr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_dlice.Focus();
            }
        }

        private void txt_dlice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_dadhar.Focus();
            }
        }

        private void txt_dadhar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }

        private void txt_dadhar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        
    }
}
