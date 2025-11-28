using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace SupermercadoCaixa
{
    public partial class FormProdutos : Form
    {
        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtQuantidade;
        private DataGridView dgvProdutos;
        private Button btnAdicionar;
        private Button btnAtualizar;
        private Button btnExcluir;
        private Button btnLimpar;
        private int produtoIdSelecionado = 0;

        public FormProdutos()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void InitializeComponent()
        {
            this.Text = "Cadastro de Produtos";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Labels e TextBoxes
            Label lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.Location = new Point(20, 20);
            lblNome.Size = new Size(100, 20);
            this.Controls.Add(lblNome);

            txtNome = new TextBox();
            txtNome.Location = new Point(130, 20);
            txtNome.Size = new Size(300, 20);
            this.Controls.Add(txtNome);

            Label lblPreco = new Label();
            lblPreco.Text = "Preço:";
            lblPreco.Location = new Point(20, 60);
            lblPreco.Size = new Size(100, 20);
            this.Controls.Add(lblPreco);

            txtPreco = new TextBox();
            txtPreco.Location = new Point(130, 60);
            txtPreco.Size = new Size(150, 20);
            this.Controls.Add(txtPreco);

            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.Location = new Point(20, 100);
            lblQuantidade.Size = new Size(100, 20);
            this.Controls.Add(lblQuantidade);

            txtQuantidade = new TextBox();
            txtQuantidade.Location = new Point(130, 100);
            txtQuantidade.Size = new Size(150, 20);
            this.Controls.Add(txtQuantidade);

            // Botões
            btnAdicionar = new Button();
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Location = new Point(20, 140);
            btnAdicionar.Size = new Size(100, 30);
            btnAdicionar.Click += BtnAdicionar_Click;
            this.Controls.Add(btnAdicionar);

            btnAtualizar = new Button();
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.Location = new Point(130, 140);
            btnAtualizar.Size = new Size(100, 30);
            btnAtualizar.Click += BtnAtualizar_Click;
            this.Controls.Add(btnAtualizar);

            btnExcluir = new Button();
            btnExcluir.Text = "Excluir";
            btnExcluir.Location = new Point(240, 140);
            btnExcluir.Size = new Size(100, 30);
            btnExcluir.Click += BtnExcluir_Click;
            this.Controls.Add(btnExcluir);

            btnLimpar = new Button();
            btnLimpar.Text = "Limpar";
            btnLimpar.Location = new Point(350, 140);
            btnLimpar.Size = new Size(100, 30);
            btnLimpar.Click += BtnLimpar_Click;
            this.Controls.Add(btnLimpar);

            // DataGridView
            dgvProdutos = new DataGridView();
            dgvProdutos.Location = new Point(20, 190);
            dgvProdutos.Size = new Size(840, 340);
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.MultiSelect = false;
            dgvProdutos.CellClick += DgvProdutos_CellClick;
            this.Controls.Add(dgvProdutos);
        }

        private void CarregarProdutos()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Produtos ORDER BY Nome";
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProdutos.DataSource = dt;
                }
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Produtos (Nome, Preco, Quantidade) VALUES (@nome, @preco, @quantidade)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
                        cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Produto adicionado com sucesso!");
                LimparCampos();
                CarregarProdutos();
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (produtoIdSelecionado == 0)
            {
                MessageBox.Show("Selecione um produto para atualizar!");
                return;
            }

            if (ValidarCampos())
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Produtos SET Nome = @nome, Preco = @preco, Quantidade = @quantidade WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
                        cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text));
                        cmd.Parameters.AddWithValue("@id", produtoIdSelecionado);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Produto atualizado com sucesso!");
                LimparCampos();
                CarregarProdutos();
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (produtoIdSelecionado == 0)
            {
                MessageBox.Show("Selecione um produto para excluir!");
                return;
            }

            var result = MessageBox.Show("Deseja realmente excluir este produto?", "Confirmar Exclusão", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Produtos WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", produtoIdSelecionado);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Produto excluído com sucesso!");
                LimparCampos();
                CarregarProdutos();
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void DgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProdutos.Rows[e.RowIndex];
                produtoIdSelecionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtNome.Text = row.Cells["Nome"].Value.ToString();
                txtPreco.Text = row.Cells["Preco"].Value.ToString();
                txtQuantidade.Text = row.Cells["Quantidade"].Value.ToString();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome do produto é obrigatório!");
                return false;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
            {
                MessageBox.Show("Digite um preço válido!");
                return false;
            }

            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade < 0)
            {
                MessageBox.Show("Digite uma quantidade válida!");
                return false;
            }

            return true;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
            produtoIdSelecionado = 0;
        }
    }
}
