namespace MockupIntegrador
{
    partial class Produto
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            lblNome = new TextBox();
            lblValor = new TextBox();
            label4 = new Label();
            button1 = new Button();
            lblEstoque = new TextBox();
            label5 = new Label();
            button2 = new Button();
            lblMedida = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(533, 23);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Produto";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome do Produto";
            // 
            // lblNome
            // 
            lblNome.Location = new Point(15, 78);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(530, 23);
            lblNome.TabIndex = 2;
            // 
            // lblValor
            // 
            lblValor.Location = new Point(12, 187);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(100, 23);
            lblValor.TabIndex = 6;
            lblValor.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 169);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 5;
            label4.Text = "Valor do Produto";
            // 
            // button1
            // 
            button1.Location = new Point(238, 303);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblEstoque
            // 
            lblEstoque.Location = new Point(12, 242);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(100, 23);
            lblEstoque.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 224);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 9;
            label5.Text = "Estoque";
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.ForeColor = Color.White;
            button2.Location = new Point(12, 303);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "Excluir";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // lblMedida
            // 
            lblMedida.FormattingEnabled = true;
            lblMedida.Items.AddRange(new object[] { "KILO", "LITRO", "METRO", "UNIDADE" });
            lblMedida.Location = new Point(13, 134);
            lblMedida.Name = "lblMedida";
            lblMedida.Size = new Size(127, 23);
            lblMedida.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 116);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 16;
            label3.Text = "Unidade Medida";
            // 
            // Produto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 343);
            Controls.Add(lblMedida);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(lblEstoque);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(lblValor);
            Controls.Add(label4);
            Controls.Add(lblNome);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Produto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Produto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox lblNome;
        private TextBox lblValor;
        private Label label4;
        private Button button1;
        private TextBox lblEstoque;
        private Label label5;
        private Button button2;
        private ComboBox lblMedida;
        private Label label3;
    }
}
