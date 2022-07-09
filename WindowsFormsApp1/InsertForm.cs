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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }       

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string age = txtAge.Text;
            
            SqlConnection sqlConnection = new SqlConnection();

            sqlConnection.ConnectionString = "Data Source=.;Initial Catalog=Test;Integrated Security=True;Pooling=False";

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = $"INSERT INTO [Person] ([Name], [Age]) VALUES (N'{name}', {age})";
            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            sqlConnection.Close();

            sqlConnection.Dispose();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
