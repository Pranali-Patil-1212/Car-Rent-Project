using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using carrentalsystem.Reports;
namespace carrentalsystem
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void destinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Destination f1 = new Destination();
            f1.MdiParent = this;
            f1.Show();
        }

        private void carToolStripMenuItem_Click(object sender, EventArgs e)
        {
            car f2 = new car();
            f2.MdiParent = this;
            f2.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Customer f3 = new Customer();
            f3.MdiParent = this;
            f3.Show();

        }

        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Driver f4 = new Driver();
            f4.MdiParent = this;
            f4.Show();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Booking f5 = new Booking();
            f5.MdiParent = this;
            f5.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment f6 = new Payment();
            f6.MdiParent = this;
            f6.Show();
        }

        private void destinationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Destination r1 = new frm_Destination();
            r1.MdiParent = this;
            r1.Show();
        }

        private void carToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Car r2=new frm_Car();
            r2.MdiParent=this;
            r2.Show();
       }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
              frm_Customer r3=new frm_Customer();
            r3.MdiParent=this;
            r3.Show();
       }

        private void bookingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
              frm_Booking r4=new frm_Booking();
            r4.MdiParent=this;
            r4.Show();
        }

        private void driverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
              frm_Driver r5=new frm_Driver();
            r5.MdiParent=this;
            r5.Show();
       }

        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
              frm_Payment r6=new frm_Payment();
            r6.MdiParent=this;
            r6.Show();
        }

        private void customerWiseBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Customerwise_Booking r7= new frm_Customerwise_Booking();
            r7.MdiParent = this;
            r7.Show();
        }

        private void carWiseBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Carwise_Booking r8 = new frm_Carwise_Booking();
            r8.MdiParent = this;
            r8.Show();
        }

        private void driverWiseBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Driverwise_Booking r9 = new frm_Driverwise_Booking();
            r9.MdiParent = this;
            r9.Show();
        }

        private void destinationnWiseBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Destinationwise_Booking r10= new frm_Destinationwise_Booking();
            r10.MdiParent = this;
            r10.Show();
        }

        private void bookingWisePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Bookingwise_Payment r11 = new frm_Bookingwise_Payment();
            r11.MdiParent = this;
            r11.Show();
        }

        private void dateWiseBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Datewise_Booking r12 = new frm_Datewise_Booking();
            r12.MdiParent = this;
            r12.Show();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com");
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }
        
    }
}