using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private string Id { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetEditFrom(string id) 
        {
            Id = id;

            SqlConnection sqlConnection = new SqlConnection();

            sqlConnection.ConnectionString = "Data Source=.;Initial Catalog=Test;Integrated Security=True;Pooling=False";

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = $"SELECT * FROM [Person] WHERE [Id] = {id}";

            DataTable dataTable = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlDataAdapter.SelectCommand = sqlCommand;

            sqlDataAdapter.Fill(dataTable);

            sqlCommand.Dispose();

            sqlConnection.Close();

            sqlConnection.Dispose();

            txtName.Text = dataTable.Rows[0]["Name"].ToString();
            txtAge.Text = dataTable.Rows[0]["Age"].ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string age = txtAge.Text;

            SqlConnection sqlConnection = new SqlConnection();

            sqlConnection.ConnectionString = "Data Source=.;Initial Catalog=Test;Integrated Security=True;Pooling=False";

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = $"UPDATE [Person] SET [Name] = N'{name}', [Age] = {age} WHERE [Id] = {Id}";
            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            sqlConnection.Close();

            sqlConnection.Dispose();

            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
