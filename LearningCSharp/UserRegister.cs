using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LearningCSharp
{
    public partial class UserRegister : Form
    {
        SQLConnection sqlConnection;
        public UserRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == txtRetypePassword.Text && txtUsername.Text != "")
            {
                string sqlCommand = "INSERT INTO Users VALUES ('" + txtUsername.Text + "', '" + txtPassword.Text +"')";
                sqlConnection = new SQLConnection(sqlCommand);
                sqlConnection.ExecuteNonQuery();
                MessageBox.Show("Tao thanh cong tai khoan");
            }
            else
            {
                MessageBox.Show("Ban da nhap sai username or password");
            }
        }
    }
}
