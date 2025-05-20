using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INFSISTSem3
{
    public partial class Form1 : Form
    {
        private Database DB;
        private DataTable table;
        private MySqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();

            table = new DataTable();
            adapter = new MySqlDataAdapter();
            dataGridView1.DataSource = table;

            btnLoadData.Click += btnLoadData_Click;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            DB = new Database(txtDatabase.Text, txtUserId.Text, txtPassword.Text);
            LoadDataFromDatabase(txtTableName.Text);
        }

        private void LoadDataFromDatabase(string tableName)
        {
            DB.OpenConnection();

            string query = $"SELECT * FROM `{DB.GetConnection().Database}`.`{tableName}`";
            MySqlCommand command = new MySqlCommand(query, DB.GetConnection());

            table.Clear();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;

            DB.CloseConnection();
        }

        private class Database
        {
            private readonly MySqlConnection connection;

            public Database(string database, string userId, string password)
            {
                connection = new MySqlConnection(
                    $"Server=localhost;Database={database};User ID={userId};Password={password};");
            }

            public void OpenConnection() => connection.Open();
            public void CloseConnection() => connection.Close();
            public MySqlConnection GetConnection() => connection;
        }
    }
}
