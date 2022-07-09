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
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            RefreshGrivView();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            InsertForm insertForm = new InsertForm();

            insertForm.ShowDialog();

            RefreshGrivView();

        }

        private void RefreshGrivView()
        {
            SqlConnection sqlConnection = new SqlConnection();

            sqlConnection.ConnectionString = "Data Source=.;Initial Catalog=Test;Integrated Security=True;Pooling=False";

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT * FROM [Person]";

            DataTable dataTable = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlDataAdapter.SelectCommand = sqlCommand;

            sqlDataAdapter.Fill(dataTable);

            sqlCommand.Dispose();

            sqlConnection.Close();

            sqlConnection.Dispose();

            gvPerson.DataSource = dataTable;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (gvPerson.SelectedRows.Count > 0)
            {
                string id = gvPerson.SelectedRows[0].Cells["Id"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Remove Person", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection sqlConnection = new SqlConnection();

                    sqlConnection.ConnectionString = "Data Source=.;Initial Catalog=Test;Integrated Security=True;Pooling=False";

                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand();

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = $"DELETE FROM [Person] WHERE [Id] = {id}";
                    sqlCommand.ExecuteNonQuery();


                    sqlCommand.Dispose();

                    sqlConnection.Close();

                    sqlConnection.Dispose();

                    RefreshGrivView();
                }
            }
            else
            {
                MessageBox.Show("No rows has been selected", "Remove Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvPerson.SelectedRows.Count > 0)
            {
                string id = gvPerson.SelectedRows[0].Cells["Id"].Value.ToString();

                EditForm editForm = new EditForm();

                editForm.SetEditFrom(id);

                editForm.ShowDialog();

                RefreshGrivView();
            }
            else
            {
                MessageBox.Show("No rows has been selected", "Remove Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
