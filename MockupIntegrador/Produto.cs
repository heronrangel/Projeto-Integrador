using System.Globalization;

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

                    bool insumo = _produto.Tipo == 0;
                    label5.Visible = insumo;
                    lblEstoque.Visible = insumo;
                    label4.Visible = insumo;
                    lblValor.Visible = insumo;
                    label3.Visible = insumo;
                    lblMedida.Visible = insumo;
                    comboBox1.Text = insumo ? "INSUMO" : "DEMANDA";

                    label7.Visible = !insumo;
                    comboBox2.Visible = !insumo;

                    if (!insumo)
                    {
                        var servicos = SQL.conexao.Query<Servicos>("SELECT * FROM Servicos;");
                        comboBox2.DataSource = servicos;
                        comboBox2.DisplayMember = "Nome"; // você pode criar um "campo calculado" se quiser mais detalhes
                        comboBox2.ValueMember = "ID";
                        comboBox2.SelectedItem = servicos.Where(c => c.ID == _produto.IDServico).FirstOrDefault();
                    }
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
            bool insumo = comboBox1.Text == "INSUMO";
            if (string.IsNullOrEmpty(lblNome.Text))
            {
                MessageBox.Show("Informe o nome!");
                return;
            }

            if (string.IsNullOrEmpty(lblValor.Text) && insumo)
            {
                MessageBox.Show("Informe o valor!");
                return;
            }

            if (string.IsNullOrEmpty(lblMedida.Text) && insumo)
            {
                MessageBox.Show("Informe a unidade de medida!");
                return;
            }

            if (string.IsNullOrEmpty(lblEstoque.Text) && insumo)
            {
                MessageBox.Show("Informe o estoque!");
                return;
            }

            if (string.IsNullOrEmpty(comboBox2.Text) && !insumo)
            {
                MessageBox.Show("Informe o serviço!");
                return;
            }

            int IDServico = 0;
            if (!insumo)
            {
                Servicos selecionado = comboBox2.SelectedItem as Servicos;
                if (selecionado != null)
                {
                    IDServico = selecionado.ID;
                }
            }

            if (_produto == null)
            {
                Produtos produto = new Produtos()
                {
                    Nome = lblNome.Text,
                    Valor = FuncoesGerais.so_numero_double(lblValor.Text),
                    Medida = lblMedida.Text,
                    Estoque = FuncoesGerais.so_numero_double(lblEstoque.Text),
                    Tipo = comboBox1.Text == "INSUMO" ? 0 : 1,
                    IDServico = IDServico
                };

                SQL.conexao.Insert(produto);
            }
            else
            {
                _produto.Nome = lblNome.Text;
                _produto.Valor = FuncoesGerais.so_numero_double(lblValor.Text);
                _produto.Medida = lblMedida.Text;
                _produto.Estoque = FuncoesGerais.so_numero_double(lblEstoque.Text);
                _produto.Tipo = comboBox1.Text == "INSUMO" ? 0 : 1;
                _produto.IDServico = IDServico;

                SQL.conexao.Update(_produto);
            }

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
                    this.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool visible = comboBox1.Text == "INSUMO";
            label5.Visible = visible;
            lblEstoque.Visible = visible;
            label4.Visible = visible;
            lblValor.Visible = visible;
            label3.Visible = visible;
            lblMedida.Visible = visible;
        }
    }
}
