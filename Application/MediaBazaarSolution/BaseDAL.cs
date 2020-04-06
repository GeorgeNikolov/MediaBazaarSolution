using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediaBazaarSolution
{
    public class BaseDAL
    {
        private string connectionString = @"Server=studmysql01.fhict.local;Uid=dbi425406;Database=dbi425406;Pwd=1234;";

        protected BaseDAL()
        {

        }

        protected MySqlConnection ConnectToDatabase()
        {
            var dbConnection = new MySqlConnection(connectionString);

            try
            {
                dbConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            return dbConnection;
        }
    }
}
