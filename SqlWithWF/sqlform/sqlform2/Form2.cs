using sqlform2.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlform2
{
    public partial class Form2 : Form1
        
    {
        
        public Form2()
        {
            InitializeComponent();
            btnGetAllShippers.Click += BtnGetAllShippers_Click;
            this.Load += Form2_Load;
        }

        private void Form2_Load(object? sender, EventArgs e)
        {
            ShipperDAL shipperDAL = new ShipperDAL();
         //  dataGridView1.DataSource = shipperDAL.GetShippers();
        }

        private void BtnGetAllShippers_Click(object? sender, EventArgs e)
        {

           
        }

        void FillData()
        {
            
        }

    }
}
