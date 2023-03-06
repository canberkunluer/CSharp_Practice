using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Windows.Controls.Primitives;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.Sqlite;
using SolrNet.Commands.Cores;
using System.Runtime.CompilerServices;


namespace wpfloginwithdata
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window 
    {
        ProductDAL pd = new ProductDAL();
        public Window1()
        {
            InitializeComponent();
            dg.ItemsSource = pd.GetProducts();
            cmbCategory.ItemsSource= pd.GetCategories();
            cmbCategory.DisplayMemberPath = "CategoryName";
            cmbCategory.SelectedValuePath = "CategoryID";
            cmbSuppliers.ItemsSource= pd.GetSuppliers();
            cmbSuppliers.DisplayMemberPath = "CompanyName";
            cmbSuppliers.SelectedValuePath = "ShipperID";
            pd.GetSuppliers();
            pd.GetCategories();
            btnUpdate.Click += BtnUpdate_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnaddcategory.Click += Btnaddcategory_Click;
            cmbCategory.SelectionChanged +=CmbCategory_SelectionChanged;
            cmbSuppliers.SelectionChanged += CmbSuppliers_SelectionChanged;
            btnaddsupplier.Click += Btnaddsupplier_Click;                                                                                                                                                                                                                                                 
        }
        private void Btnaddsupplier_Click(object sender, RoutedEventArgs e)
        {
            string contactname = txtcontactname.Text;
            string companyname = txtcompanyname.Text;
            bool result = pd.AddSupplier(contactname, companyname);
            if (result)
            {
                MessageBox.Show(txtcontactname.Text + " Başarıyla Eklendi.");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız.");
            }
            cmbSuppliers.ItemsSource = pd.GetSuppliers();
            pd.GetSuppliers();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);
            bool result = pd.DeleteProducts(id);
            if (result)
            {
                MessageBox.Show(txtid.Text + " Numaralı ID Başarıyla Silindi.");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız.");
            }
            pd.GetProducts();
        }
        private void Btnaddcategory_Click(object sender, RoutedEventArgs e)
        {
            string categoryname = txtaddcategoryname.Text;
            string desc = txtaddcategorydesc.Text;
            bool result = pd.AddCategory(categoryname,desc);
            if (result)
            {
                MessageBox.Show(txtaddcategoryname.Text + " Başarıyla Eklendi.");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız.");
            }
            cmbCategory.ItemsSource = pd.GetCategories();
            pd.GetCategories();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string productname = txtname.Text;
            int supplierid = Convert.ToInt32(cmbSuppliers.SelectedValue);
            int categoryid = Convert.ToInt32(cmbCategory.SelectedValue);
            string quantityperunit = txtquantity.Text;
            int unitprice = Convert.ToInt32(txtunitprice.Text);
            int unitsinstock = Convert.ToInt32(txtunitsinstock.Text);
            int unitsonorder = Convert.ToInt32(txtunitsonorder.Text);
            int reorderlevel = Convert.ToInt32(txtreorderlevel.Text);
            bool discontinued = Convert.ToBoolean(cmbdis.Text);
            bool result = pd.AddProducts(productname, supplierid, categoryid, quantityperunit, unitprice, unitsinstock, unitsonorder, reorderlevel, discontinued);
            if (result)
            {
                MessageBox.Show(txtname.Text + " Başarıyla EKlendi..");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız.");
            }
            dg.Items.Refresh();
            pd.GetProducts();
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(txtid.Text);
            string productname = txtname.Text;
            int supplierid = Convert.ToInt32(cmbSuppliers.SelectedValue);
            int categoryid = Convert.ToInt32(cmbCategory.SelectedValue);
            string quantityperunit = txtquantity.Text;
            int unitprice = Convert.ToInt32(txtunitprice.Text);
            int unitsinstock = Convert.ToInt32(txtunitsinstock.Text);
            int unitsonorder = Convert.ToInt32(txtunitsonorder.Text);
            int reorderlevel = Convert.ToInt32(txtreorderlevel.Text);
            bool discontinued = Convert.ToBoolean(cmbdis.Text);
            bool result = pd.UpdateProducts(id, productname, supplierid, categoryid, quantityperunit, unitprice, unitsinstock, unitsonorder, reorderlevel, discontinued);
            if (result)
            {
                MessageBox.Show(txtid.Text + " Numaralı ID Başarıyla Güncellendi.");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız.");
            }
            pd.GetProducts();
        }
        private void CmbSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedID = 0;
            if (cmbSuppliers.SelectedIndex > 0)
            {
                if (((ComboBox)sender).SelectedValue != null)
                {
                    selectedID = (int)((ComboBox)sender).SelectedValue;
                }
            }
        }
        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedID = 0;
            if (cmbCategory.SelectedIndex > 0)
            {
                if (((ComboBox)sender).SelectedValue != null)
                {
                    selectedID = (int)((ComboBox)sender).SelectedValue;
                }
            }
        }
        private void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

    }
    }

