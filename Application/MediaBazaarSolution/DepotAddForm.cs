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
    public partial class DepotAddForm : Form
    {
        private MainScreen parentForm;
        private DataGridView dgvDepot;
        public DepotAddForm(MainScreen parent, DataGridView dgvDepot)
        {
            InitializeComponent();
            parentForm = parent;
            this.dgvDepot = dgvDepot;
        }

        private void btnApplyChangesToDepot_Click(object sender, EventArgs e)
        {
            string itemName = tbxItemName.Text;
            string itemCategory = tbxCategory.Text;
            bool IsValidAmount = int.TryParse(tbxInStock.Text, out int itemInStock);
            bool IsValidPrice = decimal.TryParse(tbxPrice.Text, out decimal price);

            if (!IsValidAmount)
            {
                MessageBox.Show("The amount you entered is not an integer!", "Amount must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsValidPrice)
            {
                MessageBox.Show("The price you entered is not an integer!", "Price must be a number",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                parentForm.Depot.AddItemToDepot(dgvDepot, itemName, itemCategory, itemInStock, price);
            }
        }

        private void DepotAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            tbxItemName.Text = "";
            tbxCategory.Text = "";
            tbxInStock.Text = "";
            tbxPrice.Text = "";
        }
    }
}
