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

namespace MediaBazaarSolution
{
    public partial class LogInScreen : Form
    {
        MainScreen mainScreen;
        public LogInScreen()
        {
            InitializeComponent();
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            if (LoginValid(username, password))
            {
                MainScreen f = new MainScreen(AccountDAO.Instance.GetAccount(username, password));
                
                
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Fail to login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LoginValid(string username, string password)
        {
            return AccountDAO.Instance.LoginValid(username, password);
        }

        

        private void LogInScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the program?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
