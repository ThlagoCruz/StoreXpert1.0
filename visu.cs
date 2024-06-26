using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace StoreXpert
{
    public partial class visu : Form
    {
        string connectionString = "Data Source=data.db;version=3";

        public visu()
        {
            InitializeComponent();
        }

        private void btn_verif_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Produtos";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Implementar a lógica se necessário
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implementar a lógica se necessário
        }
    }
}
