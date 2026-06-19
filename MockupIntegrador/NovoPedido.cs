using System.Text.RegularExpressions;

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
    public partial class NovoPedido : Form
    {
        private PedidoModel _pedido;
        private bool _revisualiza;
        public NovoPedido(PedidoModel pedido = null)
        {
            InitializeComponent();
            _revisualiza = pedido != null;
            _pedido = pedido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNome.Text))
            {
                MessageBox.Show("O campo nome é obrigatório!");
                return;
            }
            else if (string.IsNullOrEmpty(lblTelefone.Text))
            {
                MessageBox.Show("O campo telefone é obrigatório!");
                return;
            }
            else if (string.IsNullOrEmpty(lblEndereco.Text))
            {
                MessageBox.Show("O campo endereço é obrigatório!");
                return;
            }
            else if (listView2.Items.Count == 0)
            {
                MessageBox.Show("Informe ao menos um produto!");
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
                _pedido = pedido;
            }
            GravaPedProdutos();
            if (!_revisualiza)
            {
                FuncoesGerais.FxEstoque(_pedido.ID);
            }
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

            var servicos = SQL.conexao.Query<Produtos>("SELECT * FROM Servicos;");

            comboServicos.DataSource = servicos;
            comboServicos.DisplayMember = "Nome"; // você pode criar um "campo calculado" se quiser mais detalhes
            comboServicos.ValueMember = "ID";

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;

            listView2.Columns.Add("Nome", 200);
            listView2.Columns.Add("Quantidade", 100);
            listView2.Columns.Add("Serviço", 200);
            listView2.Columns.Add("Valor Serviço", 100);

            if (_pedido != null)
            {
                var pedProdutos = SQL.conexao.Query<PedPro>($"SELECT * FROM PedPro WHERE IDPedido = {_pedido.ID};");
                foreach (var s in pedProdutos)
                {
                    InsereLista(s);
                }
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
            if (string.IsNullOrEmpty(lblProduto.Text))
            {
                MessageBox.Show("Informe um produto!");
                return;
            }
            else if (string.IsNullOrEmpty(comboServicos.Text))
            {
                MessageBox.Show("Informe um serviço!");
                return;
            }
            else if (FuncoesGerais.so_numero(lblQuantidade.Text) == 0)
            {
                MessageBox.Show("Informe a quantidade!");
                return;
            }

            Produtos selecionado = comboServicos.SelectedItem as Produtos;
            if (selecionado != null)
            {
                foreach (ListViewItem s in listView2.Items)
                {
                    PedPro produto = s.Tag as PedPro;

                    if (produto != null)
                    {
                        if (produto.IDPro == selecionado.ID && produto.Nome == lblProduto.Text)
                        {
                            MessageBox.Show("Este produto já está na lista!");
                            return;
                        }
                    }
                }

                int quant = FuncoesGerais.so_numero(lblQuantidade.Text);

                Servicos servico = SQL.conexao.Query<Servicos>($"SELECT * FROM Servicos WHERE ID = {selecionado.ID}").FirstOrDefault();

                double valor = 0;
                foreach (var p in SQL.conexao.Query<ServicoItem>($"SELECT * FROM ServicoItem WHERE IDServico = {selecionado.ID}"))
                {
                    var pro = SQL.conexao.Query<Produtos>($"SELECT * FROM Produtos WHERE ID = {p.IDProduto}").FirstOrDefault();
                    if (pro != null)
                    {
                        double quantUsada = p.Quantidade * quant;
                        double est = pro.Estoque - quantUsada;
                        if (est <= 0)
                        {
                            MessageBox.Show($"Insumo {pro.Nome} ficará sem estoque!\n\nEm estoque: {pro.Estoque} {pro.Medida}\nSerá usado: {quantUsada} {pro.Medida}");
                        }
                    }

                    if (p != null)
                    {
                        p.Total = p.Valor * p.Quantidade;
                        valor += p.Total;
                    }
                }
                valor = valor * quant;

                PedPro prod = new PedPro
                {
                    IDPedido = _pedido != null ? _pedido.ID : 0,
                    IDServico = servico != null ? servico.ID : 0,
                    IDPro = selecionado.ID,
                    Nome = lblProduto.Text,
                    Quantidade = quant,
                    Valor = valor,
                    Servico = servico.Nome
                };

                InsereLista(prod);
            }
        }

        private void GravaPedProdutos()
        {
            if (_pedido != null)
            {
                if (listView2.Items.Count > 0)
                {
                    SQL.conexao.Execute($"DELETE FROM PedPro WHERE IDPedido = {_pedido.ID}");
                }
            }

            foreach (ListViewItem s in listView2.Items)
            {
                PedPro produto = s.Tag as PedPro;
                if (produto != null)
                {
                    produto.IDPedido = _pedido.ID;
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
