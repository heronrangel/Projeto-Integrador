using System.Globalization;

namespace MockupIntegrador
{
    public partial class Produto : Form
    {
        Produtos _produto;
        public Produto(int ID = 0)
        {
            InitializeComponent();
            Inicializar.Inicializa();

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
                    Estoque = FuncoesGerais.so_numero_double(lblEstoque.Text)
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
                
            MessageBox.Show("Gravado com sucesso!");
            this.Close();
        }
    }
}
