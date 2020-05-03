using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazaarSolution.DTO;
using System.Data;

namespace MediaBazaarSolution.DAO
{
    public class ItemCategoryDAO
    {
        private static ItemCategoryDAO instance;

        public static ItemCategoryDAO Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new ItemCategoryDAO();
                }

                return ItemCategoryDAO.instance;
            }

            private set
            {
                ItemCategoryDAO instance = value;
            }
        }

        private ItemCategoryDAO() { }

        public List<Category> getAllCategory()
        {
            string query = "SELECT * FROM category";
            List<Category> listCategory = new List<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                Category category = new Category(row);
                listCategory.Add(category);
            }

            return listCategory;
        }

    }
}
