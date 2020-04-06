using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazaarSolution;
using System.Windows.Forms;

namespace MediaBazaarSolution
{
    public class Depot : BaseDAL
    {
        private List<int> indecis;
        private List<string> categories;
        public Depot()
        {
            indecis = new List<int>();
            categories = new List<string>();
        }

        public void LoadDepot(DataGridView dgvDepot)
        {
            var dbConnection = base.ConnectToDatabase();

            using (dbConnection)
            {
                MySqlCommand command = new MySqlCommand("SELECT dp.item_id, dp.item_name, dp.amount,c.category_name, dp.price " +
                "FROM `depot_item` AS dp " +
                "LEFT JOIN category AS c " +
                "ON dp.category_id = c.category_id", dbConnection);

                MySqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    dgvDepot.Rows.Clear();
                    while (reader.Read())
                    {
                        int itemId = Convert.ToInt32(reader["item_id"]);
                        string itemName = reader["item_name"].ToString();
                        int itemInStock = Convert.ToInt32(reader["amount"]);
                        string itemCategory = reader["category_name"].ToString();
                        decimal itemPrice = Convert.ToDecimal(reader["price"]);

                        dgvDepot.Rows.Add(itemId, itemName, itemCategory, itemInStock, itemPrice);

                        if (!indecis.Contains(itemId))
                        {
                            indecis.Add(itemId);
                        }
                        if (!categories.Contains(itemCategory))
                        {
                            categories.Add(itemCategory);
                        }
                    }
                }
            }
        }
        public void SearchItemById(string IdAsString, DataGridView dgvDepot)
        {
            if (String.IsNullOrEmpty(IdAsString) || String.IsNullOrWhiteSpace(IdAsString))
            {
                LoadDepot(dgvDepot);
                return;
            }

            bool IsValidWantedId = int.TryParse(IdAsString, out int wantedId);

            if (!IsValidWantedId)
            {
                MessageBox.Show("The ID you entered is not an integer!", "ID must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!indecis.Contains(int.Parse(IdAsString)))
            {
                MessageBox.Show("There is no item in the depot with the entered ID!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var dbConnection = base.ConnectToDatabase();
                using (dbConnection)
                {
                    MySqlCommand command = new MySqlCommand("SELECT dp.item_id, dp.item_name, dp.amount,c.category_name, dp.price " +
                    "FROM `depot_item` AS dp " +
                    "LEFT JOIN category AS c " +
                    "ON dp.category_id = c.category_id " +
                    "WHERE dp.item_id = @item_id", dbConnection);

                    command.Parameters.AddWithValue("@item_id", wantedId);

                    MySqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        dgvDepot.Rows.Clear();
                        while (reader.Read())
                        {
                            int itemId = Convert.ToInt32(reader["item_id"]);
                            string itemName = reader["item_name"].ToString();
                            int itemInStock = Convert.ToInt32(reader["amount"]);
                            string itemCategory = reader["category_name"].ToString();
                            decimal itemPrice = Convert.ToDecimal(reader["price"]);


                            dgvDepot.Rows.Add(itemId, itemName, itemCategory, itemInStock, itemPrice);
                        }
                    }
                }
            }
        }
        public void AddItemToDepot(DataGridView dgvDepot, string itemName, string category, int itemInStock, decimal price)
        {
            if (String.IsNullOrEmpty(itemName) || String.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show("The name is not valid!", "Invalid Item Name", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (String.IsNullOrEmpty(category) || String.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("The category is not valid!", "Invalid Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!categories.Contains(category))
            {
                MessageBox.Show("No such category!", "Invalid category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (itemInStock <= 0)
            {
                MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (price <= 0)
            {
                MessageBox.Show("The price must be positive!", "Invalid price", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var dbConnection = base.ConnectToDatabase();
                using (dbConnection)
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO depot_item(item_name,amount,category_id, price)" +
                    "VALUES(@itemName,@itemInStock,(SELECT category_id FROM category WHERE category_name=@category), @price)", dbConnection);

                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@itemInStock", itemInStock);
                    command.Parameters.AddWithValue("@price", price);

                    int resultOfQuery = command.ExecuteNonQuery();

                    if (resultOfQuery > 0)
                    {
                        MessageBox.Show("Item successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LoadDepot(dgvDepot);
                    }
                    else
                    {
                        MessageBox.Show("Item not added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void DeleteSelectedItem(DataGridView dgvDepot)
        {
            int rowIndex = dgvDepot.CurrentCell.RowIndex;
            int idOfProduct = Convert.ToInt32(dgvDepot.SelectedCells[0].Value.ToString());
            var dbConnection = base.ConnectToDatabase();
            using (dbConnection)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM depot_item WHERE item_id=@id", dbConnection);

                command.Parameters.AddWithValue("@id", idOfProduct);

                int resultOfQuery = command.ExecuteNonQuery();


                if (resultOfQuery > 0)
                {
                    MessageBox.Show("Item successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //LoadDepot(dbconnection, dgvDepot);
                    dgvDepot.Rows.RemoveAt(rowIndex);
                    indecis.Remove(idOfProduct);
                    LoadDepot(dgvDepot);
                }
                else
                {
                    MessageBox.Show("Item not deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void EditSelectedItem(DataGridView dgvDepot, int currentColumnIndex, int id, object valueToBeChanged, object oldCurrentValue)
        {
            var dbConnection = base.ConnectToDatabase();

            using (dbConnection)
            {

                MySqlCommand command = null;
                if (currentColumnIndex == 1)
                {
                    string newItemName = valueToBeChanged.ToString();

                    command = new MySqlCommand("UPDATE depot_item SET item_name = @valueToBeChanged WHERE item_id = @id", dbConnection);
                    command.Parameters.AddWithValue("@valueToBeChanged", newItemName);
                    command.Parameters.AddWithValue("@id", id);

                }
                else if (currentColumnIndex == 2)
                {
                    string category = valueToBeChanged.ToString();
                    
                    if (!categories.Contains(category))
                    {
                        MessageBox.Show("No such category!", "Invalid category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDepot.CurrentCell.Value = oldCurrentValue;
                        return;
                    }
                    else
                    {
                        command = new MySqlCommand("UPDATE depot_item SET `category_id` = (SELECT category_id FROM category WHERE category_name=@valueToBeChanged) WHERE item_id = @id", dbConnection);
                        command.Parameters.AddWithValue("@valueToBeChanged", category);
                        command.Parameters.AddWithValue("@id", id);
                    }
                }
                else if (currentColumnIndex == 3)
                {
                    bool IsValidAmount = int.TryParse(valueToBeChanged.ToString(), out int itemInStock);
                    

                    if (!IsValidAmount)
                    {
                        MessageBox.Show("The amount you entered is not an integer!", "Amount must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDepot.CurrentCell.Value = oldCurrentValue;
                        return;
                    }
                    else if (itemInStock <= 0)
                    {
                        MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDepot.CurrentCell.Value = oldCurrentValue;
                        return;
                    }
                    else
                    {
                        command = new MySqlCommand("UPDATE depot_item SET amount = @valueToBeChanged WHERE item_id = @id", dbConnection);
                        command.Parameters.AddWithValue("@valueToBeChanged", itemInStock);
                        command.Parameters.AddWithValue("@id", id);
                    }
                }
                else if (currentColumnIndex == 4)
                {
                    bool IsValidPrice = decimal.TryParse(valueToBeChanged.ToString(), out decimal price);
                    
                    if (!IsValidPrice)
                    {
                        MessageBox.Show("The price you entered is not an integer!", "Price must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDepot.CurrentCell.Value = oldCurrentValue;
                        return;
                    }
                    else if (price <= 0)
                    {
                        MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDepot.CurrentCell.Value = oldCurrentValue;
                        return;
                    }
                    else
                    {
                        command = new MySqlCommand("UPDATE depot_item SET price = @valueToBeChanged WHERE item_id = @id", dbConnection);
                        command.Parameters.AddWithValue("@valueToBeChanged", valueToBeChanged);
                        command.Parameters.AddWithValue("@id", id);
                    }
                }

                int resultOfQuery = command.ExecuteNonQuery();

                if (resultOfQuery > 0)
                {
                    MessageBox.Show("Item successfully edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Item not edited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
