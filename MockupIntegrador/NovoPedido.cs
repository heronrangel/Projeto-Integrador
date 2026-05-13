using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MockupIntegrador
{
    public partial class NovoPedido : Form
    {
        private PedidoModel _pedido;
        public NovoPedido(PedidoModel pedido = null)
        {
            InitializeComponent();
            _pedido = pedido;
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

            if (_pedido != null)
            {
                _pedido.Nome = lblNome.Text;
                _pedido.Endereco = lblEndereco.Text;
                _pedido.Telefone = lblTelefone.Text;
                SQL.conexao.Update(_pedido);
            }
            else
            {
                PedidoModel pedido = new PedidoModel
                {
                    Nome = lblNome.Text,
                    Telefone = lblTelefone.Text,
                    Endereco = lblEndereco.Text
                };
                SQL.conexao.Insert(pedido);
            }
            GravaPedProdutos();

            this.Close();
        }

        private bool _atualizando = false;

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            if (_atualizando) return;

            var txt = sender as System.Windows.Forms.TextBox;

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
            if (_pedido != null)
            {
                lblEndereco.Text = _pedido.Endereco;
                lblNome.Text = _pedido.Nome;
                lblTelefone.Text = _pedido.Telefone;
            }

            var produtos = SQL.conexao.Query<Produtos>("SELECT * FROM Produtos WHERE Tipo = 1;");

            comboProdutos.DataSource = produtos;
            comboProdutos.DisplayMember = "Nome"; // você pode criar um "campo calculado" se quiser mais detalhes
            comboProdutos.ValueMember = "ID";

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;

            listView2.Columns.Add("Nome", 200);
            listView2.Columns.Add("Quantidade", 100);
            listView2.Columns.Add("Serviço", 200);
            listView2.Columns.Add("Valor Serviço", 100);

            var pedProdutos = SQL.conexao.Query<PedPro>($"SELECT * FROM PedPro WHERE IDPedido = {_pedido.ID};");
            foreach (var s in pedProdutos)
            {
                InsereLista(s);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        string txtNumeroOld;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (lblQuantidade.Text != txtNumeroOld)
            {
                lblQuantidade.Text = FuncoesGerais.so_numero(lblQuantidade.Text).ToString();
                txtNumeroOld = lblQuantidade.Text;
            }
        }

        private void AtualizaValor()
        {
            double total = 0;
            foreach (ListViewItem s in listView2.Items)
            {
                PedPro produto = s.Tag as PedPro;
                if (produto != null)
                {
                    total += produto.Valor;
                }
            }
            lblTotal.Text = $"Tota: {FuncoesGerais.DoubleToStr(total)}";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboProdutos.Text))
            {
                MessageBox.Show("Informe um produto!");
                return;
            }
            else if (FuncoesGerais.so_numero(lblQuantidade.Text) == 0)
            {
                MessageBox.Show("Informe a quantidade!");
                return;
            }

            Produtos selecionado = comboProdutos.SelectedItem as Produtos;
            if (selecionado != null)
            {
                foreach (ListViewItem s in listView2.Items)
                {
                    PedPro produto = s.Tag as PedPro;

                    if (produto != null)
                    {
                        if (produto.IDPro == selecionado.ID)
                        {
                            MessageBox.Show("Este produto já está na lista!");
                            return;
                        }
                    }
                }

                int quant = FuncoesGerais.so_numero(lblQuantidade.Text);
                double valor = 0;
                Servicos servico = SQL.conexao.Query<Servicos>($"SELECT * FROM Servicos WHERE ID = {selecionado.IDServico}").FirstOrDefault();
                if (servico != null)
                {
                    valor = SQL.conexao.ExecuteScalar<double>($"SELECT SUM(Valor) FROM ServicoItem WHERE IDServico = {servico.ID};") * quant;
                }

                PedPro prod = new PedPro
                {
                    IDPedido = _pedido.ID,
                    IDPro = selecionado.ID,
                    Nome = comboProdutos.Text,
                    Quantidade = quant,
                    Valor = valor,
                    Servico = servico.Nome
                };

                InsereLista(prod);
            }
        }

        private void GravaPedProdutos()
        {
            if (listView2.Items.Count > 0)
            {
                SQL.conexao.Execute($"DELETE FROM PedPro WHERE IDPedido = {_pedido.ID}");
            }

            foreach (ListViewItem s in listView2.Items)
            {
                PedPro produto = s.Tag as PedPro;
                if (produto != null)
                {
                    SQL.conexao.Insert(produto);
                }
            }
        }

        private void InsereLista(PedPro prod)
        {
            var item = new ListViewItem(prod.Nome);
            item.SubItems.Add(prod.Quantidade.ToString());
            item.SubItems.Add(prod.Servico);
            item.SubItems.Add(FuncoesGerais.DoubleToStr(prod.Valor));
            item.Tag = prod;
            listView2.Items.Add(item);
            lblQuantidade.Text = "0";
            AtualizaValor();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListViewItem itemSelecionado = listView2.SelectedItems.Count > 0
            ? listView2.SelectedItems[0]
            : null;

            if (itemSelecionado != null)
            {
                PedPro selecionado = itemSelecionado.Tag as PedPro;

                if (selecionado != null)
                {
                    itemSelecionado.Remove();
                    AtualizaValor();
                }
            }
        }
    }
}
