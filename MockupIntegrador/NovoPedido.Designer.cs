namespace MockupIntegrador
{
    partial class NovoPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            lblNome = new TextBox();
            label1 = new Label();
            label3 = new Label();
            lblTelefone = new TextBox();
            label4 = new Label();
            lblEndereco = new TextBox();
            button1 = new Button();
            listView2 = new ListView();
            button3 = new Button();
            button5 = new Button();
            comboProdutos = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            lblQuantidade = new TextBox();
            lblTotal = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(902, 23);
            label2.TabIndex = 5;
            label2.Text = "Novo Pedido";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNome
            // 
            lblNome.Location = new Point(12, 74);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(383, 23);
            lblNome.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(402, 56);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 9;
            label3.Text = "Telefone";
            // 
            // lblTelefone
            // 
            lblTelefone.Location = new Point(402, 74);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(162, 23);
            lblTelefone.TabIndex = 8;
            lblTelefone.TextChanged += txtTelefone_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 105);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 11;
            label4.Text = "Endereço";
            // 
            // lblEndereco
            // 
            lblEndereco.Location = new Point(12, 123);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(552, 23);
            lblEndereco.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(423, 411);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView2
            // 
            listView2.Location = new Point(12, 213);
            listView2.Name = "listView2";
            listView2.Size = new Size(821, 131);
            listView2.TabIndex = 27;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button3
            // 
            button3.Location = new Point(537, 182);
            button3.Name = "button3";
            button3.Size = new Size(75, 25);
            button3.TabIndex = 26;
            button3.Text = "Adicionar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(839, 213);
            button5.Name = "button5";
            button5.Size = new Size(75, 25);
            button5.TabIndex = 25;
            button5.Text = "Remover";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // comboProdutos
            // 
            comboProdutos.FormattingEnabled = true;
            comboProdutos.Location = new Point(13, 184);
            comboProdutos.Name = "comboProdutos";
            comboProdutos.Size = new Size(440, 23);
            comboProdutos.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 166);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 23;
            label6.Text = "Produtos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(459, 166);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 29;
            label5.Text = "Quantidade";
            // 
            // lblQuantidade
            // 
            lblQuantidade.Location = new Point(459, 184);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(71, 23);
            lblQuantidade.TabIndex = 28;
            lblQuantidade.Text = "0";
            lblQuantidade.TextChanged += textBox1_TextChanged;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(12, 347);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(902, 23);
            lblTotal.TabIndex = 30;
            lblTotal.Text = "Total: R$ 0,00";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NovoPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 446);
            Controls.Add(lblTotal);
            Controls.Add(label5);
            Controls.Add(lblQuantidade);
            Controls.Add(listView2);
            Controls.Add(button3);
            Controls.Add(button5);
            Controls.Add(comboProdutos);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(lblEndereco);
            Controls.Add(label3);
            Controls.Add(lblTelefone);
            Controls.Add(label1);
            Controls.Add(lblNome);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "NovoPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novo Pedido";
            Load += NovoPedido_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox lblNome;
        private Label label1;
        private Label label3;
        private TextBox lblTelefone;
        private Label label4;
        private TextBox lblEndereco;
        private Button button1;
        private ListView listView2;
        private Button button3;
        private Button button5;
        private ComboBox comboProdutos;
        private Label label6;
        private Label label5;
        private TextBox lblQuantidade;
        private Label lblTotal;
    }
}