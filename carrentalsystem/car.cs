using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace carrentalsystem
{
    public partial class car : Form
    {
        public car()
        {
            InitializeComponent();
        }
        OleDbConnection cn;
        OleDbCommand cmd;
        OleDbDataReader dr;
        int flag = 0;
        private void car_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection(); 
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
           cn.Open();
           setGrid();

        }
        public void clearText()
        {
            txt_carid.Text = "";
            txt_carnm.Text = "";
            txt_carno.Text = "";
            txt_carmodel.Text = "";
            txt_rate.Text = "";
        }
        public void EnabledText()
        {
           txt_carid.Enabled= true;
           txt_carnm.Enabled= true;
           txt_carmodel.Enabled = true;
           txt_carno.Enabled = true;
           txt_rate.Enabled = true;
        }
        public void DisableText()
        {
            txt_carid.Enabled = false;
            txt_carnm.Enabled = false;
            txt_carmodel.Enabled = false;
            txt_carno.Enabled = false;
            txt_rate.Enabled = false;
        }
        public void setGrid()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select *from Car";
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
            cmd.CommandText = "select max(car_id)from Car";
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
            txt_carid.Text = Convert.ToString(GetNewID());
            GetNewID();
            EnabledText();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
            txt_carnm.Focus();
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;

            if (flag == 1)
            {
                cmd.CommandText = "insert into car values("+ txt_carid.Text+",'"+txt_carnm.Text+"',"+txt_carno.Text+" ,'"+txt_carmodel.Text+"',"+txt_rate.Text+")";
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show("Record inserted successfully");
                else
                    MessageBox.Show("Record not inserted");

            }
            else if (flag == 2)
            {
                cmd.CommandText = "update car set car_nm='"+txt_carnm.Text+"',car_number="+txt_carno.Text+",car_model='"+txt_carmodel.Text+"',rate_per_km="+txt_rate.Text+" where car_id="+txt_carid.Text;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt_carid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_carnm.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_carno.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_carmodel.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_rate.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            btn_new.Enabled = false;
            btn_update.Enabled = true;
            btn_del.Enabled = true;
            DisableText();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from car where car_id=" + txt_carid.Text;
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
                MessageBox.Show("Record deleted");
            else
                MessageBox.Show("Record not deleted");
            setGrid();
            clearText();
            DisableText();
            btn_del.Enabled = false;
            btn_new.Enabled = true;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            flag = 2;
            EnabledText();
            btn_update.Enabled = false;
            btn_save.Enabled = true;
            btn_del.Enabled = false;
        }

        private void txt_carnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txt_carno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txt_carmodel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        
        }

        private void txt_carid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_carnm.Focus();
            }
        }

        private void txt_carnm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               txt_carno.Focus();
            }
        }

        private void txt_carno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_carmodel.Focus();
            }
        }

        private void txt_carmodel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               txt_rate.Focus();
            }   
        }

        private void txt_rate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }

       

        
       
    }
}
