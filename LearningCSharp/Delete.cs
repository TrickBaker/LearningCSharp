using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LearningCSharp
{
    public partial class Delete : Form
    {
        SQLConnection sqlConnection;
        public Delete()
        {
            InitializeComponent();
        }


        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                string sqlCommand = "delete from Users where Username='" + txtUsername.Text + "'";
                sqlConnection = new SQLConnection(sqlCommand);
                sqlConnection.ExecuteNonQuery();
                MessageBox.Show("Xoa thanh cong tai khoan");
            }
            else
            {
                MessageBox.Show("Nhap lai");
            }
        }
    }
}
