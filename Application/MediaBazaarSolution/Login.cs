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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

             

        private void ShowPW_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void ShowPW_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // ValidateUser

            /*switch (user.role)
            {
                case "admin":*/
                    AdminScreen adminScreen = new AdminScreen();
                    adminScreen.Show();
                    
                    this.Hide();/*
                    break;
                case "manager":
                    ManagerScreen managerScreen = new ManagerScreen();
                    managerScreen.Activate();
                    this.Close();
                    break;
                case "depotWorker":
                    DepotWorker depotWorker = new DepotWorker();
                    depotWorker.Activate();
                    this.Close();
                    break;
            }*/

            

        }
    }
}
