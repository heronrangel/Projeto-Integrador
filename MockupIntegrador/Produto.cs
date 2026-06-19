using System.Globalization;

/*
     * Projeto: Projeto Integrador II (La Salle)
     * Software desenvolvido em conjunto por:
     * - Heron Rangel Agostinho
     * - Eduardo Henrique Copatti
     *
     * Data: Semestre 1/2026
     * Descrição: Sistema para gerir uma lavanderia com a possibilidade de cadastrar insumos (produtos), serviços,
     * pedidos e estoque. Foi desenvolvido ao logo do primeiro semestre de 2026.
     */


namespace MockupIntegrador
{
    public partial class Produto : Form
    {
        Produtos _produto;
        public Produto(int ID = 0)
        {
            InitializeComponent();

            if (ID != 0)
            {
                _produto = SQL.conexao.Query<Produtos>($"SELECT * FROM Produtos WHERE ID = {ID};").FirstOrDefault();
                if (_produto != null)
                {
                    lblNome.Text = _produto.Nome;
                    lblValor.Text = FuncoesGerais.DoubleToStr(_produto.Valor);
                    lblMedida.Text = _produto.Medida;
                    lblEstoque.Text = _produto.Estoque.ToString();
                }
            }

            button2.Visible = ID != 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrEmpty(tb.Text)) return;

            string valor = "";
            foreach (char c in tb.Text)
            {
                if (char.IsDigit(c))
                    valor += c;
            }

            if (string.IsNullOrEmpty(valor))
            {
                tb.Text = "";
                return;
            }

            decimal valorDecimal = decimal.Parse(valor) / 100;
            tb.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorDecimal);
            tb.SelectionStart = tb.Text.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNome.Text))
            {
                MessageBox.Show("Informe o nome!");
                return;
            }

            if (string.IsNullOrEmpty(lblValor.Text))
            {
                MessageBox.Show("Informe o valor!");
                return;
            }

            if (string.IsNullOrEmpty(lblMedida.Text))
            {
                MessageBox.Show("Informe a unidade de medida!");
                return;
            }

            if (string.IsNullOrEmpty(lblEstoque.Text))
            {
                MessageBox.Show("Informe o estoque!");
                return;
            }

            if (_produto == null)
            {
                Produtos produto = new Produtos()
                {
                    Nome = lblNome.Text,
                    Valor = FuncoesGerais.so_numero_double(lblValor.Text),
                    Medida = lblMedida.Text,
                    Estoque = FuncoesGerais.so_numero_double(lblEstoque.Text),
                };

                SQL.conexao.Insert(produto);
            }
            else
            {
                _produto.Nome = lblNome.Text;
                _produto.Valor = FuncoesGerais.so_numero_double(lblValor.Text);
                _produto.Medida = lblMedida.Text;
                _produto.Estoque = FuncoesGerais.so_numero_double(lblEstoque.Text);

                SQL.conexao.Update(_produto);
            }
            ListaGeral.FxCarregaLista();
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (_produto != null)
            {
                DialogResult resultado = MessageBox.Show($"Deseja remover {_produto.Nome}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    SQL.conexao.Delete(_produto);
                    ListaGeral.FxCarregaLista();
                    this.Close();
                }
            }
        }
    }
}
