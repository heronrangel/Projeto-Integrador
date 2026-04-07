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
            label5 = new Label();
            lblItens = new RichTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(453, 23);
            label2.TabIndex = 5;
            label2.Text = "Novo Pedido";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNome
            // 
            lblNome.Location = new Point(12, 74);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(453, 23);
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
            label3.Location = new Point(12, 114);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 9;
            label3.Text = "Telefone";
            // 
            // lblTelefone
            // 
            lblTelefone.Location = new Point(12, 132);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(453, 23);
            lblTelefone.TabIndex = 8;
            lblTelefone.TextChanged += txtTelefone_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 175);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 11;
            label4.Text = "Endereço";
            // 
            // lblEndereco
            // 
            lblEndereco.Location = new Point(12, 193);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(453, 23);
            lblEndereco.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 236);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 13;
            label5.Text = "Itens";
            // 
            // lblItens
            // 
            lblItens.Location = new Point(12, 254);
            lblItens.Name = "lblItens";
            lblItens.Size = new Size(453, 84);
            lblItens.TabIndex = 14;
            lblItens.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(199, 344);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NovoPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 379);
            Controls.Add(button1);
            Controls.Add(lblItens);
            Controls.Add(label5);
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
        private Label label5;
        private RichTextBox lblItens;
        private Button button1;
    }
}