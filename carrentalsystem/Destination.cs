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
    public partial class Destination : Form
    {
        public Destination()
        {
            InitializeComponent();
        }
        OleDbConnection cn;
        OleDbCommand cmd;
        OleDbDataReader dr;
        int flag = 0;
        private void Destination_Load(object sender, EventArgs e)
        {
            cn=new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project2k23\\carsystem.mdb";
            cn.Open();
            setGrid();
        }
        public void clearText()
        {
            txt_destid.Text = "";
            txt_desnm.Text = "";
        }
        public void EnabledText()
        {
            txt_destid.Enabled = true;
            txt_desnm.Enabled = true;
        }
        public void DisableText()
        {
            txt_destid.Enabled = false;
            txt_desnm.Enabled = false;
        }
        public void setGrid()
        {
            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select *from Destination";
           // dr = new OleDbDataReader();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
        }
        public int GetNewID()
        {
            cmd=new OleDbCommand();
            cmd.Connection=cn;
            cmd.CommandText="select max(dest_id)from Destination";
            object x= cmd.ExecuteScalar();
            if(Convert.ToString(x)=="")
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
            EnabledText();
            txt_destid.Text = Convert.ToString(GetNewID());
            btn_new.Enabled = false;
            btn_save.Enabled = true;
            txt_destid.Enabled = false;
            txt_desnm.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            cmd=new OleDbCommand();
            cmd.Connection=cn;
            
            if (flag==1)
            {
                cmd.CommandText="insert into Destination values(" + txt_destid.Text + ",'" + txt_desnm.Text+ "')";
                int x=cmd.ExecuteNonQuery();
                if (x > 0)
                    MessageBox.Show("Record inserted successfully");
                else
                    MessageBox.Show("Record not inserted");

             }
            else if (flag == 2)
            {
                cmd.CommandText = "update Destination set dest_nm='" + txt_desnm.Text + " 'where dest_id=" + txt_destid.Text;
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
            txt_destid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_desnm.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            btn_new.Enabled = false;
            btn_update.Enabled = true;
            btn_del.Enabled = true;
            DisableText();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            flag=2;
            EnabledText();
            btn_update.Enabled=false;
            btn_save.Enabled=true;
            btn_del.Enabled=false;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            cmd=new OleDbCommand();
            cmd.Connection=cn;
            cmd.CommandText="delete from Destination where dest_id="+txt_destid.Text;
            int x=cmd.ExecuteNonQuery();
            if(x>0)
                MessageBox.Show("Record deleted");
            else
                MessageBox.Show("Record not deleted");
           setGrid();
            clearText();
            DisableText();
            btn_del.Enabled=false;
            btn_new.Enabled=true;
            btn_save.Enabled=false;
            btn_update.Enabled=false;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_desnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
               // MessageBox.Show("Please enter characters");
                e.Handled = true;
            }
        }

        private void txt_destid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_desnm.Focus();
            }  
        }

        private void txt_desnm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }
        }
        }

       

  
