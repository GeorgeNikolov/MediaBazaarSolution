using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaarSolution.DTO;
using MediaBazaarSolution.DAO;

namespace MediaBazaarSolution
{
    public partial class DepotEditForm : Form
    {
        MainScreen mainScreen;
        Item item;
        Account user;
        List<Category> categories;
        List<string> categoriesString = new List<string>();
        public DepotEditForm(MainScreen mainScreen, Item item, Account user)
        {
            InitializeComponent();

            // Initialise variables
            this.mainScreen = mainScreen;
            this.item = item;
            this.user = user;


            // Initialise Textboxes
            AmountTB.Text = item.Amount.ToString();
            NameTB.Text = item.Name;
            PriceTB.Text = item.Price.ToString();

            categories = ItemCategoryDAO.Instance.getAllCategory();
            for (int i = 0; i < categories.Count; i++ )
            {
                CategoryCB.Items.Add(categories[i].Name);
                if (item.Category.Equals(categories[i].Name))
                {
                    CategoryCB.SelectedIndex = i;
                }
                categoriesString.Add(categories[i].Name);
            }
            if(user.Type.Equals(EmployeeType.Employee))
            {
                CategoryCB.Enabled = false;
                NameTB.Enabled = false;
                PriceTB.Enabled = false;
            }

        }

        private void SaveChangesBtn_Click(object sender, EventArgs e)
        {
            string Name = NameTB.Text;
            string Price = PriceTB.Text;
            string Amount = AmountTB.Text;
            string category = CategoryCB.Text;
            char[] forbiddenCharacters = new char[] { '\\', '\'', '\"', '@', '$', '#', '&', '*', '_', '=', '?', '<', '>', '.' };
            bool forbiddenCharactersUsed = false;
            if ((Name.IndexOfAny(forbiddenCharacters) != -1))
            {
                forbiddenCharactersUsed = true;
            }

            bool isValidAmount = int.TryParse(Amount, out int intAmount);
            bool isValidPrice = decimal.TryParse(Price, out decimal decimalPrice);

            if (String.IsNullOrEmpty(Name) || String.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("The name is not valid!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(category) || String.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("The category is not valid!", "Invalid category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!categoriesString.Contains(category))
            {
                MessageBox.Show("The category is not valid!", "Invalid category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!isValidAmount)
            {
                MessageBox.Show("The amount is not valid", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!isValidPrice)
            {
                MessageBox.Show("The price is not valid", "Invalid price", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (intAmount < 0)
            {
                MessageBox.Show("The amount cannot be negative", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (decimalPrice < 0)
            {
                MessageBox.Show("The price cannot be negative", "Invalid price", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (forbiddenCharactersUsed)
            {
                MessageBox.Show($"A forbidden character is used, please refrain from using any of the following characters: {new string(forbiddenCharacters)}", "Invalid characters used", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ItemDAO.Instance.UpdateItemAmount(item.ID, intAmount) &&
                    ItemDAO.Instance.UpdateItemCategory(item.ID, category) &&
                    ItemDAO.Instance.UpdateItemName(item.ID, Name) &&
                    ItemDAO.Instance.UpdateItemPrice(item.ID, decimalPrice))
                {
                    MessageBox.Show("Item Updated!");
                    mainScreen.LoadAll();
                    this.Close();
                } else
                {
                    MessageBox.Show("Somgething went wrong! \nItem not updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
