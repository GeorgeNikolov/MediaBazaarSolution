using MediaBazaarSolution.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSolution
{
    public partial class DepotEditForm : Form
    {
        private MainScreen parentForm;
        private string previousItemName;
        private string previousItemCategory;
        private string previousItemAmount;
        private string previousItemPrice;
        private int itemId;
        public DepotEditForm(MainScreen parentForm, DataGridViewRow row)
        {
            InitializeComponent();

            this.parentForm = parentForm;
            this.lblEditUser.Text = "You are " + parentForm.UserFirstName;
            LoadItemCategoriesInComboBox();
            LoadDepotItemValues(row);
        }

        private void LoadDepotItemValues(DataGridViewRow row)
        {
            itemId = Convert.ToInt32(row.Cells[0].Value.ToString());
            tbxId.Text = itemId.ToString();
            tbxName.Text = row.Cells[1].Value.ToString();
            previousItemName = tbxName.Text;

            cbxEditItemCategory.SelectedIndex = cbxEditItemCategory.FindString(row.Cells[2].Value.ToString());
            previousItemCategory = cbxEditItemCategory.GetItemText(cbxEditItemCategory.SelectedItem);

            tbxAmountInStock.Text = row.Cells[3].Value.ToString();
            previousItemAmount = tbxAmountInStock.Text;
            tbxPrice.Text = row.Cells[4].Value.ToString();
            previousItemPrice = tbxPrice.Text;
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            bool queryIsSuccess = false;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit that employee?", "Edit Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                if (String.Compare(previousItemName, tbxName.Text) != 0)
                {
                    //bool IsValidName = Regex.IsMatch(tbxFName.Text, "[A-Z][a-zA-Z]");
                    
                    if (String.IsNullOrEmpty(tbxName.Text) || String.IsNullOrWhiteSpace(tbxName.Text))
                    {
                        MessageBox.Show("First name must not be blank!", "First Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxName.Text = previousItemName;
                    }
                    else
                    {
                        queryIsSuccess = ItemDAO.Instance.UpdateItemName(itemId, tbxName.Text);
                    }
                }
                
                if (String.Compare(previousItemCategory, cbxEditItemCategory.GetItemText(cbxEditItemCategory.SelectedItem)) != 0)
                {
                    queryIsSuccess = ItemDAO.Instance.UpdateItemCategory(itemId, cbxEditItemCategory.GetItemText(cbxEditItemCategory.SelectedItem));
                }

                if(String.Compare(previousItemAmount, tbxAmountInStock.Text) != 0)
                {
                    bool isValidRate = int.TryParse(tbxAmountInStock.Text, out int newAmount);

                    if (String.IsNullOrEmpty(tbxAmountInStock.Text) || String.IsNullOrWhiteSpace(tbxAmountInStock.Text))
                    {
                        MessageBox.Show("Amount must not be blank!", "Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxAmountInStock.Text = previousItemAmount;
                    }

                    else if (!isValidRate)
                    {
                        MessageBox.Show("Amount must be valid!", "Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxAmountInStock.Text = previousItemAmount;
                    }
                    else if (newAmount < 0)
                    {
                        MessageBox.Show("Amount must not be negative!", "Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxAmountInStock.Text = previousItemAmount;
                    }
                    else
                    {
                        queryIsSuccess = ItemDAO.Instance.UpdateItemAmount(itemId, newAmount);
                    }
                }
                if (String.Compare(previousItemPrice, tbxPrice.Text) != 0)
                {
                    bool isValidRate = decimal.TryParse(tbxPrice.Text, out decimal newPrice); ;
                    if (String.IsNullOrEmpty(tbxPrice.Text) || String.IsNullOrWhiteSpace(tbxPrice.Text))
                    {
                        MessageBox.Show("Price of item must not be blank!", "Price Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxPrice.Text = previousItemPrice;
                    }

                    else if (!isValidRate)
                    {
                        MessageBox.Show("Price of item must be valid!", "Price Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxPrice.Text = previousItemPrice;
                    }
                    else if (newPrice < 0)
                    {
                        MessageBox.Show("Price of item must not be negative!", "Price Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxPrice.Text = previousItemPrice;
                    }
                    else
                    {
                        queryIsSuccess = ItemDAO.Instance.UpdateItemPrice(itemId, newPrice);

                    }
                }
            }
            if (queryIsSuccess)
            {
                MessageBox.Show("Item successfully edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 
            }
            else
            {
                MessageBox.Show("Item not edited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemCategoriesInComboBox()
        {
            //Load the available categories to the combobox in the depot tab
            //By default the selected index will be 0
            
            cbxEditItemCategory.DisplayMember = "name";
            cbxEditItemCategory.ValueMember = "name";
            cbxEditItemCategory.DataSource = ItemCategoryDAO.Instance.getAllCategory();
        }
    }
}
