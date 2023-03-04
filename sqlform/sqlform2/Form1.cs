using sqlform2.Database;
using System.Windows.Forms;

namespace sqlform2
{
    public partial class Form1 : Form
    {
        ShipperDAL shipDL = new ShipperDAL();
        
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btnInsert.Click += BtnInsert_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            string compName = txtCompanyName.Text, phone = txtCompanyPhone.Text;
            int id = Convert.ToInt32(txtCompanyID.Text);

            bool result = shipDL.Update(id,compName,phone);
            if (result)
            {
                MessageBox.Show(txtCompanyID.Text + " Numaralı ID Başarıyla Güncellendi.");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız");
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCompanyID.Text);
            
            bool result = shipDL.Delete(id);
            if (result)
            {
                MessageBox.Show(txtCompanyID.Text+ " Numaralı ID Başarıyla Silindi.");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız.");
            }
        }

        private void BtnInsert_Click(object? sender, EventArgs e)
        {
            string compName = txtCompanyName.Text , phone = txtCompanyPhone.Text ;
            bool result = shipDL.Add(compName, phone);
            if (result) 
            {
                MessageBox.Show("İşlem Başarılı");
            }
            else
            {
                MessageBox.Show("İşlem Başarılı");
            }


        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            
        }
    }
}