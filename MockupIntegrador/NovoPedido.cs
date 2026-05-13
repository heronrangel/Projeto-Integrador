using System.Text.RegularExpressions;

namespace MockupIntegrador
{
    public partial class NovoPedido : Form
    {
        public NovoPedido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNome.Text))
            {
                MessageBox.Show("O campo nome é obrigatório!");
                return;
            }

            if (string.IsNullOrEmpty(lblTelefone.Text))
            {
                MessageBox.Show("O campo telefone é obrigatório!");
                return;
            }

            if (string.IsNullOrEmpty(lblEndereco.Text))
            {
                MessageBox.Show("O campo endereço é obrigatório!");
                return;
            }

            PedidoModel pedido = new PedidoModel
            {
                Nome = lblNome.Text,
                Telefone = lblTelefone.Text,
                Endereco = lblEndereco.Text
            };

            SQL.conexao.Insert(pedido);
            this.Close();
        }

        private bool _atualizando = false;

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            if (_atualizando) return;

            var txt = sender as TextBox;

            _atualizando = true;

            int posicaoCursor = txt.SelectionStart;

            // Remove tudo que não for número
            string numeros = Regex.Replace(txt.Text, @"\D", "");

            // Limita a 11 dígitos (celular)
            if (numeros.Length > 11)
                numeros = numeros.Substring(0, 11);

            string formatado = "";

            if (numeros.Length <= 10)
            {
                // Fixo
                if (numeros.Length >= 1)
                    formatado = "(" + numeros.Substring(0, Math.Min(2, numeros.Length));

                if (numeros.Length >= 3)
                    formatado += ") " + numeros.Substring(2, Math.Min(4, numeros.Length - 2));

                if (numeros.Length >= 7)
                    formatado += "-" + numeros.Substring(6, numeros.Length - 6);
            }
            else
            {
                // Celular
                formatado = "(" + numeros.Substring(0, 2) + ") " +
                            numeros.Substring(2, 5) + "-" +
                            numeros.Substring(7, 4);
            }

            txt.Text = formatado;

            // Mantém o cursor numa posição válida
            txt.SelectionStart = txt.Text.Length;

            _atualizando = false;
        }

        private void NovoPedido_Load(object sender, EventArgs e)
        {
            var produtos = SQL.conexao.Query<Produtos>("SELECT * FROM Produtos WHERE Tipo = 1;");

            comboProdutos.DataSource = produtos;
            comboProdutos.DisplayMember = "Nome"; // você pode criar um "campo calculado" se quiser mais detalhes
            comboProdutos.ValueMember = "ID";
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
