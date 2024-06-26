using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace StoreXpert
{
    public partial class Cadastro : Form
    {
        string connectionString = "Data Source=data.db;version=3";

        public Cadastro()
        {
            InitializeComponent();
            VerificarECriarTabelaProdutos();
        }

        private void VerificarECriarTabelaProdutos()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='Produtos'";
                using (var command = new SQLiteCommand(checkTableQuery, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result == null)
                    {
                        string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Produtos (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nome TEXT NOT NULL,
                            Categoria TEXT NOT NULL,
                            Setor TEXT NOT NULL,
                            Preco REAL NOT NULL,
                            Codigo TEXT NOT NULL,
                            Marca TEXT NOT NULL
                        )";
                        using (var createCommand = new SQLiteCommand(createTableQuery, connection))
                        {
                            createCommand.ExecuteNonQuery();
                            MessageBox.Show("Tabela criada com sucesso!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("A tabela 'Produtos' já existe.");
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string categoria = txt_categoria.Text;
            string setor = txt_setor.Text;
            string preco = txt_preco.Text;
            string codigo = txt_codigo.Text;
            string marca = txt_marca.Text;

            InserirProduto(nome, categoria, setor, preco, codigo, marca);
        }

        private void InserirProduto(string nome, string categoria, string setor, string preco, string codigo, string marca)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Produtos (Nome, Categoria, Setor, Preco, Codigo, Marca) VALUES (@Nome, @Categoria, @Setor, @Preco, @Codigo, @Marca)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Categoria", categoria);
                    command.Parameters.AddWithValue("@Setor", setor);
                    command.Parameters.AddWithValue("@Preco", preco);
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    command.Parameters.AddWithValue("@Marca", marca);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Produto cadastrado com sucesso!");
            }
        }

        private void btn_criar_Click(object sender, EventArgs e)
        {
            VerificarECriarTabelaProdutos();
        }

        // Outros métodos e eventos do formulário podem ser adicionados aqui
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Implementar a lógica se necessário
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Implementar a lógica se necessário
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Implementar a lógica se necessário
        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {
            // Implementar a lógica se necessário
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string categoria = txt_categoria.Text;
            string setor = txt_setor.Text;
            string preco = txt_preco.Text;
            string codigo = txt_codigo.Text;
            string marca = txt_marca.Text;
            InserirProduto(nome, categoria, setor, preco, codigo, marca);
        }
    }
}
