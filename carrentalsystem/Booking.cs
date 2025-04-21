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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection cn;
        OleDbDataReader dr;
        int flag = 0;
        private void Booking_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();
            setGrid();
            setdropdown1();
            setdropdown2();
            setdropdown3();
            setdropdown4();
        }
        public void clearText()
        {
            txt_bid.Text = "";
           
        }
        public void EnabledText()
        {
            txt_bid.Enabled = true;
            
        }
        public void setdropdown1()
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
        public void setdropdown2()
        {
            cmd = new OleDbCommand("select *from Car", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "car_id";
            comboBox2.DisplayMember = "car_nm";
            dr.Close();
        }
        public void setdropdown3()
        {
            cmd = new OleDbCommand("select *from Driver", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox3.DataSource = dt;
            comboBox3.ValueMember = "driver_id";
            comboBox3.DisplayMember = "driver_nm";
            dr.Close();
        }
        public void setdropdown4()
        {
            cmd = new OleDbCommand("select *from Destination", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox4.DataSource = dt;
            comboBox4.ValueMember = "dest_id";
            comboBox4.DisplayMember = "dest_nm";
            dr.Close();
        }
        public void DisableText()
        {
           
            txt_bid.Enabled = false;
           
        }
        public void setGrid()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select *from Booking";
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
            cmd.CommandText = "select max(book_id)from Booking";
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
            txt_bid.Text = Convert.ToString(GetNewID());
            GetNewID();
            EnabledText();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
            dateTimePicker1.Focus();
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;

            if (flag == 1)
            {
                cmd.CommandText = "insert into Booking values(" + txt_bid.Text + ",'" +dateTimePicker1.Value + "'," + comboBox1.SelectedValue + "," + comboBox2.SelectedValue + "," + comboBox3.SelectedValue + ", " + comboBox4.SelectedValue + ")";
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show("Record inserted successfully");
                else
                    MessageBox.Show("Record not inserted");

            }
            else if (flag == 2)
            {
                cmd.CommandText = "update Booking set book_date='" + dateTimePicker1.Value + "',cust_id=" + comboBox1.SelectedValue +",car_id="+comboBox2.SelectedValue+",driver_id=" +comboBox3.SelectedValue + ",dest_id="+ comboBox4.SelectedValue +" where book_id=" + txt_bid.Text;
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
            cmd.CommandText = "delete from Booking where book_id=" + txt_bid.Text;
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
            txt_bid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();

            comboBox1.SelectedValue= dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.Rows[i].Cells[3].Value.ToString();
          comboBox3.SelectedValue = dataGridView1.Rows[i].Cells[4].Value.ToString();
         comboBox4.SelectedValue= dataGridView1.Rows[i].Cells[5].Value.ToString();
           
            btn_new.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
            DisableText();

        }

        private void txt_bid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
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
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox3.Focus();
            }

        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox4.Focus();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }

      

        


    }
}
