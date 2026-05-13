namespace MockupIntegrador
{
    public partial class ListaGeral : Form
    {
        private string _identificador;
        public static bool _atualizar;
        public ListaGeral(string titulo)
        {
            InitializeComponent();
            label1.Text = $"Lista de {titulo}s";
            button1.Text = $"Novo {titulo}";
            _identificador = titulo;
            comboBox1.Visible = _identificador == "produto";
        }

        private void ListaGeral_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.Add("Nome", 320);
            listView1.Columns.Add("Valor", 100);
            FxCarregaLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_identificador)
            {
                case "produto":
                    Produto produto = new Produto();
                    produto.ShowDialog();
                    break;

                case "serviço":
                    Servico servico = new Servico();
                    servico.ShowDialog();
                    break;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            switch (_identificador)
            {
                case "produto":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        ListViewItem itemSelecionado = listView1.SelectedItems[0];
                        ListaModel selecionado = itemSelecionado.Tag as ListaModel;
                        if (selecionado != null)
                        {
                            Produto produto = new Produto(selecionado.ID);
                            produto.ShowDialog();
                        }
                    }
                    break;

                case "serviço":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        ListViewItem itemSelecionado = listView1.SelectedItems[0];
                        ListaModel selecionado = itemSelecionado.Tag as ListaModel;
                        if (selecionado != null)
                        {
                            Servico produto = new Servico(selecionado.ID);
                            produto.ShowDialog();
                        }
                    }
                    break;
            }
        }

        private void FxCarregaLista()
        {
            List<ListaModel> lista;
            int tipo = comboBox1.Text == "INSUMO" ? 0 : 1;
            listView1.Items.Clear();
            switch (_identificador)
            {
                case "produto":
                    lista = SQL.conexao.Query<ListaModel>(
                        $"SELECT ID, Nome, Valor FROM Produtos WHERE Tipo = {tipo};"
                    ).ToList();
                    break;

                case "serviço":
                    lista = SQL.conexao.Query<ListaModel>(
                        "SELECT ID, Nome FROM Servicos;"
                    ).ToList();

                    foreach (var s in lista)
                    {
                        var servicoItens = SQL.conexao.Query<ServicoItem>($"SELECT * FROM ServicoItem WHERE IDServico = {s.ID};");
                        foreach (var i in servicoItens)
                        {
                            s.valor += i.Valor * i.Quantidade; 
                        }
                    }

                    break;
                default:
                    lista = new List<ListaModel>();
                    break;
            }

            foreach (var s in lista)
            {
                var item = new ListViewItem(s.nome);
                item.SubItems.Add(FuncoesGerais.DoubleToStr(s.valor));
                item.Tag = s;
                listView1.Items.Add(item);
            }
            listView1.Update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FxCarregaLista();
        }
    }
}
