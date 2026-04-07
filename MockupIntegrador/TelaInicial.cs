using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MockupIntegrador
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Servico produto = new Servico();
            produto.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedido produto = new Pedido();
            produto.ShowDialog();
        }
    }
}
