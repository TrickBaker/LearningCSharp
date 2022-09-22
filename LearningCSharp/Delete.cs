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

        DataTable usersTable;

        public Delete()
        {
            InitializeComponent();
            LoadUsersList();
        }


        private void LoadUsersList()
        {
            string sqlCommand = "SELECT * FROM Users";
            sqlConnection = new SQLConnection(sqlCommand);
            usersTable = sqlConnection.ExecuteReader();

            foreach (DataRow dtRow in usersTable.Rows)
            {
                // On all tables' columns
                var username = dtRow["Username"].ToString();
                cbbUsersList.Items.Add(username);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (cbbUsersList.SelectedItem.ToString() != "")
            {
                string sqlCommand = "delete from Users where Username='" + cbbUsersList.SelectedItem.ToString() + "'";
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
