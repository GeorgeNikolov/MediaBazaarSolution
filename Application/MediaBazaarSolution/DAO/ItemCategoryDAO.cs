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
        //using Singleton Design pattern 
        //this ensures that only one object of its kind exists and provides a single point of access to it for any other code
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

        //set the constructor to private so that it will not be instantiated because of its protection level
        private ItemCategoryDAO() { }

        public List<Category> getAllCategory()
        {

            string query = "SELECT * FROM category";
            List<Category> listCategory = new List<Category>();
            listCategory.Add(new Category(-1, "None"));
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Category category = new Category(row);
                listCategory.Add(category);
            }

            return listCategory;
        }

    }
}
