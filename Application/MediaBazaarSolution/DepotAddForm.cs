using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaarSolution.DAO;
using MediaBazaarSolution.DTO;

namespace MediaBazaarSolution
{
    public partial class DepotAddForm : Form
    {
        private MainScreen parentForm;
        //private DataGridView dgvDepot;
        public DepotAddForm(MainScreen parent)
        {
            InitializeComponent();

            parentForm = parent;
            //this.dgvDepot = dgvDepot;
            cbxCategory.DataSource = ItemCategoryDAO.Instance.getAllCategory();
            cbxCategory.DisplayMember = "name";

        }

        private void btnApplyChangesToDepot_Click(object sender, EventArgs e)
        {
            
            string itemName = tbxItemName.Text;
            string itemCategory = (cbxCategory.SelectedItem as Category).Name;
            bool IsValidAmount = int.TryParse(tbxInStock.Text, out int itemInStock);
            bool IsValidPrice = decimal.TryParse(tbxPrice.Text, out decimal price);


            if (String.IsNullOrEmpty(itemName) || String.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show("The name is not valid!", "Invalid Item Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(itemCategory) || String.IsNullOrWhiteSpace(itemCategory))
            {
                MessageBox.Show("The category is not valid!", "Invalid Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbxCategory.SelectedIndex == -1 || cbxCategory.SelectedIndex == 0)
            {
                MessageBox.Show("The category selected is not valid!", "Amount must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsValidAmount)
            {
                MessageBox.Show("The amount you entered is not an integer!", "Amount must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (itemInStock <= 0)
            {
                MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsValidPrice)
            {
                MessageBox.Show("The price you entered is not an integer!", "Price must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!parentForm.categories.Contains(itemCategory))
            {
                MessageBox.Show("No such category!", "Invalid category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (price <= 0)
            {
                MessageBox.Show("The price must be positive!", "Invalid price", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //parentForm.Depot.AddItemToDepot(dgvDepot, itemName, itemCategory, itemInStock, price);
                if (ItemDAO.Instance.AddItemToDepot(itemName, itemCategory, itemInStock, price))
                {
                    MessageBox.Show("Item successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    parentForm.LoadAll();
                }
                else
                {
                    MessageBox.Show("Item not added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DepotAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            tbxItemName.Text = "";
            cbxCategory.SelectedIndex = 0;
            tbxInStock.Text = "";
            tbxPrice.Text = "";
        }

        private void DepotAddForm_Load(object sender, EventArgs e)
        {
            //parentForm.Depot.LoadItemCategoriesInComboBox(cbxCategory);
        }

        
    }
}
