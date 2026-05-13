using System.Data;

namespace MockupIntegrador
{
    public partial class Pedido : Form
    {
        public Pedido()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NovoPedido novo = new NovoPedido();
            novo.ShowDialog();
        }

        private void Pedido_Load(object sender, EventArgs e)
        {
            listAberto.View = View.Details;
            listAberto.FullRowSelect = true;
            listAberto.GridLines = true;

            listAberto.Columns.Add("Nome", 160);
            listAberto.Columns.Add("Data", 100);
            listAberto.Columns.Add("Telefone", 100);
            listAberto.Columns.Add("Endereco", 350);

            listConcluido.View = View.Details;
            listConcluido.FullRowSelect = true;
            listConcluido.GridLines = true;

            listConcluido.Columns.Add("Nome", 160);
            listConcluido.Columns.Add("Data", 100);
            listConcluido.Columns.Add("Telefone", 100);
            listConcluido.Columns.Add("Endereco", 350);
        }

        private void MontaLista(string filtro = "")
        {
            List<PedidoModel> pedidos = new List<PedidoModel>();

            if (string.IsNullOrEmpty(filtro))
            {
                pedidos = SQL.conexao.Query<PedidoModel>(
                    "SELECT * FROM PedidoModel;"
                ).ToList();
            }
            else
            {
                pedidos = SQL.conexao.Query<PedidoModel>(
                    "SELECT * FROM PedidoModel WHERE Nome LIKE ? OR Telefone LIKE ?",
                    $"%{filtro}%", $"%{filtro}%"
                );
            }

            listAberto.Items.Clear();
            listConcluido.Items.Clear();

            foreach (var pedido in pedidos.Where(c => c.Status == 0))
            {
                var item = new ListViewItem(pedido.Nome);

                item.SubItems.Add(pedido.Data.ToString("dd/MM/yyyy"));
                item.SubItems.Add(pedido.Telefone);
                item.SubItems.Add(pedido.Endereco);

                // opcional: guardar o objeto completo
                item.Tag = pedido;

                listAberto.Items.Add(item);
            }

            foreach (var pedido in pedidos.Where(c => c.Status == 1))
            {
                var item = new ListViewItem(pedido.Nome);

                item.SubItems.Add(pedido.Data.ToString("dd/MM/yyyy"));
                item.SubItems.Add(pedido.Telefone);
                item.SubItems.Add(pedido.Endereco);

                // opcional: guardar o objeto completo
                item.Tag = pedido;

                listConcluido.Items.Add(item);
            }
        }

        private void Pedido_Activated(object sender, EventArgs e)
        {
            MontaLista();
        }

        private void AlteraPedido(bool desfazer = false)
        {
            int count = !desfazer ? listAberto.SelectedItems.Count : listConcluido.SelectedItems.Count;
            if (count == 0)
            {
                MessageBox.Show("Selecione um pedido.");
                return;
            }

            // pega o primeiro item selecionado
            ListViewItem itemSelecionado = !desfazer ? listAberto.SelectedItems[0] : listConcluido.SelectedItems[0];
            PedidoModel selecionado = itemSelecionado.Tag as PedidoModel;

            if (selecionado == null)
            {
                MessageBox.Show("Erro: objeto não encontrado.");
                return;
            }

            if (!desfazer)
            {
                foreach (ListViewItem item in listAberto.Items)
                {
                    PedidoModel p = item.Tag as PedidoModel;
                    if (p != null && p.ID == selecionado.ID)
                    {
                        SQL.conexao.Execute($"UPDATE PedidoModel SET Status = 1 WHERE ID = {selecionado.ID};");
                        listAberto.Items.Remove(item);
                        break; // sai do loop depois de remover
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in listConcluido.Items)
                {
                    PedidoModel p = item.Tag as PedidoModel;
                    if (p != null && p.ID == selecionado.ID)
                    {
                        SQL.conexao.Execute($"UPDATE PedidoModel SET Status = 0 WHERE ID = {selecionado.ID};");
                        listConcluido.Items.Remove(item);
                        break; // sai do loop depois de remover
                    }
                }
            }

            MontaLista();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlteraPedido();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AlteraPedido(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MontaLista(lblPesquisa.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MontaLista();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listAberto.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um pedido.");
                return;
            }

            // pega o primeiro item selecionado
            ListViewItem itemSelecionado = listAberto.SelectedItems[0];
            PedidoModel selecionado = itemSelecionado.Tag as PedidoModel;

            if (selecionado == null)
            {
                MessageBox.Show("Erro: objeto não encontrado.");
                return;
            }

            SQL.conexao.Delete(selecionado);
            MontaLista();
        }
    }
}
