namespace MockupIntegrador
{
    public partial class Servico : Form
    {
        Servicos _servico;
        public Servico(int ID = 0)
        {
            InitializeComponent();

            var produtos = SQL.conexao.Query<Produtos>("SELECT * FROM Produtos WHERE Tipo = 0;");
            comboItens.DataSource = produtos;
            comboItens.DisplayMember = "DisplayText"; // você pode criar um "campo calculado" se quiser mais detalhes
            comboItens.ValueMember = "ID";

            if (ID != 0)
            {
                _servico = SQL.conexao.Query<Servicos>($"SELECT * FROM Servicos WHERE ID = {ID};").FirstOrDefault();
                if (_servico != null)
                {
                    lblNome.Text = _servico.Nome;
                    var itemsServico = SQL.conexao.Query<ServicoItem>($"SELECT * FROM ServicoItem WHERE IDServico = {ID};");
                    foreach (var s in itemsServico)
                    {
                        AdicionaItem(s);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ServicoItem> itemsGravar = new List<ServicoItem>();
            foreach (ListViewItem item in listView1.Items)
            {
                ServicoItem p = item.Tag as ServicoItem;
                if (p != null)
                {
                    itemsGravar.Add(p);
                }
            }

            if (itemsGravar.Count == 0)
            {
                MessageBox.Show("Informe ao menos um item para gravar!");
                return;
            }

            int IDServico = 0;
            if (_servico == null)
            {
                Servicos servico = new Servicos
                {
                    Nome = lblNome.Text
                };
                SQL.conexao.Insert(servico);

                IDServico = servico.ID;
            }
            else
            {
                IDServico = _servico.ID;
                _servico.Nome = lblNome.Text;
                SQL.conexao.Update(_servico);
                SQL.conexao.Execute($"DELETE FROM ServicoItem WHERE IDServico = {IDServico};");
            }

            foreach (var s in itemsGravar)
            {
                s.IDServico = IDServico;
                SQL.conexao.Insert(s);
            }

            MessageBox.Show("Gravado com sucesso!");
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Produtos selecionado = comboItens.SelectedItem as Produtos;
            if (selecionado == null)
            {
                MessageBox.Show("Informe um item da lista.");
                return;
            }

            // percorre todos os ListViewItems e verifica o Tag
            foreach (ListViewItem item in listView1.Items)
            {
                Produtos p = item.Tag as Produtos;
                if (p != null && p.ID == selecionado.ID)
                {
                    MessageBox.Show("Este item já foi adicionado antes.");
                    return;
                }
            }

            AdicionaItem(selecionado);
        }

        private void AdicionaItem(Produtos produto)
        {
            var servicoItem = new ServicoItem()
            {
                ID = produto.ID,
                Nome = produto.Nome,
                Estoque = produto.Estoque,
                Medida = produto.Medida,
                Quantidade = 1,
                Valor = produto.Valor
            };

            AdicionaLista(servicoItem);
        }

        private void AdicionaItem(ServicoItem servicoItem)
        {
            AdicionaLista(servicoItem);
        }

        private void AdicionaLista(ServicoItem servicoItem)
        {
            var item = new ListViewItem(servicoItem.Nome);

            item.SubItems.Add(servicoItem.Quantidade.ToString());
            item.SubItems.Add(FuncoesGerais.DoubleToStr(servicoItem.Valor));
            item.Tag = servicoItem;

            listView1.Items.Add(item);

            AtualizaValoresLista();
        }

        private void Servico_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("Nome", 120);
            listView1.Columns.Add("Quantidade", 100);
            listView1.Columns.Add("Valor", 100);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            // pega o primeiro item selecionado
            ListViewItem itemSelecionado = listView1.SelectedItems[0];
            ServicoItem selecionado = itemSelecionado.Tag as ServicoItem;

            if (selecionado == null)
            {
                MessageBox.Show("Erro: objeto não encontrado.");
                return;
            }

            // percorre todos os itens e remove o que tiver o mesmo ID
            foreach (ListViewItem item in listView1.Items)
            {
                ServicoItem p = item.Tag as ServicoItem;
                if (p != null && p.ID == selecionado.ID)
                {
                    listView1.Items.Remove(item);
                    break; // sai do loop depois de remover
                }
            }

            AtualizaValoresLista();
        }

        private void AtualizaValoresLista()
        {
            double totalServico = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                ServicoItem p = item.Tag as ServicoItem;
                if (p != null)
                {
                    p.Total = p.Valor * p.Quantidade;
                    totalServico += p.Total;
                    item.SubItems[2].Text = FuncoesGerais.DoubleToStr(p.Total);
                }
            }
            lblTotalServico.Text = $"Total Serviço: {FuncoesGerais.DoubleToStr(totalServico)}";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            ListViewItem item = listView1.SelectedItems[0];

            Rectangle subItemRect = item.SubItems[1].Bounds;

            System.Windows.Forms.TextBox editBox = new System.Windows.Forms.TextBox();
            editBox.Bounds = subItemRect;
            editBox.Text = item.SubItems[1].Text;
            listView1.Controls.Add(editBox);
            editBox.Focus();

            editBox.LostFocus += (s, ev) =>
            {
                item.SubItems[1].Text = editBox.Text;
                ServicoItem p = item.Tag as ServicoItem;
                if (p != null)
                    p.Quantidade = FuncoesGerais.so_numero_double(editBox.Text); // atualiza objeto

                AtualizaValoresLista();
                listView1.Controls.Remove(editBox);
                editBox.Dispose();
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_servico != null)
            {
                DialogResult resultado = MessageBox.Show($"Deseja remover {_servico.Nome}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    SQL.conexao.Delete(_servico);
                    this.Close();
                }
            }
        }
    }
}
