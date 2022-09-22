using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningCSharp
{
    public partial class LoginForm : Form
    {
        SQLConnection sqlConnection;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtUsername.Text != "")
            {
                sqlConnection = new SQLConnection("SELECT 1 FROM (SELECT * FROM Users WHERE Username ='"+ txtUsername.Text + "' AND Password ='" + txtPassword.Text +"') X");
                if(sqlConnection.ExecuteScalar())
                {
                    MessageBox.Show("Ket noi thanh cong");
                }
                else
                {
                    MessageBox.Show("Ket noi that bai");
                }
            }
            else
            {
                MessageBox.Show("Moi ban nhap user va pass");
            }
        }

        private void lRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new UserRegister()).Show();
        }

        private void lDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new Delete()).Show();
        }
    }
}
