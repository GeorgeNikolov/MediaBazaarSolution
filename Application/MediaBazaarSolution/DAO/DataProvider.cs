using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace MediaBazaarSolution.DAO
{
    public class DataProvider
    {
        //using Singleton Design pattern 
        //this ensures that only one object of its kind exists and provides a single point of access to it for any other code
        private static DataProvider instance;

        public static DataProvider Instance { 
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }

                return DataProvider.instance;
            }

            private set
            {
                DataProvider.instance = value;
            }
        }

        //set the constructor to private so that it will not be instantiated because of its protection level
        private DataProvider() { }

        private string connectionString = @"Server=studmysql01.fhict.local;Uid=dbi425406;Database=dbi425406;Pwd=1234;";
        //private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=website_sem2;";

        //This method will return a DataTable based on the value returned by the query
        //This method will be used for the SELECT statement
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                try
                {
                    connection.Open();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Could not connect to Database, please try again later." + e.Message);
                }
                MySqlCommand command = new MySqlCommand(query, connection);

                    if (parameters != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameters[i]);
                                i++;
                            }
                        }
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    adapter.Fill(data);

                    connection.Close();
                }      
            return data;
        }

        //This method will return the number of line successfully executed
        //This method will be use for INSERT, UPDATE, DELETE statements
        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;
            
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                try
                {
                    connection.Open();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Could not connect to Database, please try again later." + e.Message);
                }

                MySqlCommand command = new MySqlCommand(query, connection);

                    if (parameters != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameters[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();

                    connection.Close();               
            }
            return data;
        }

        //This method will return a value of type object in which you can cast it to your desired data type
        //This method is suitable for statements returning single value (scalar value) such as COUNT statement or SELECT statement that return a scalar value
        //Example: SELECT COUNT(*) FROM .... or SELECT id FROM table
        //thid method will return nothing if there is no required value retrieved from the querys
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = 0;
            
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                try
                {
                    connection.Open();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Could not connect to Database, please try again later." + e.Message);
                }
                MySqlCommand command = new MySqlCommand(query, connection);

                    if (parameters != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameters[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteScalar();

                    connection.Close();
                }
            
            
            return data;
        }
    }
}
