namespace MockupIntegrador
{
    partial class Pedido
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
            lblPesquisa = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            listAberto = new ListView();
            label3 = new Label();
            listConcluido = new ListView();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // lblPesquisa
            // 
            lblPesquisa.Location = new Point(74, 12);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(218, 23);
            lblPesquisa.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.White;
            button1.Location = new Point(301, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(382, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Limpar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 3;
            label1.Text = "Pesquisa:";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(776, 23);
            label2.TabIndex = 4;
            label2.Text = "Pedidos Em Aberto";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listAberto
            // 
            listAberto.Location = new Point(12, 73);
            listAberto.Name = "listAberto";
            listAberto.Size = new Size(1110, 161);
            listAberto.TabIndex = 5;
            listAberto.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 237);
            label3.Name = "label3";
            label3.Size = new Size(776, 23);
            label3.TabIndex = 6;
            label3.Text = "Pedidos Concluidos";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listConcluido
            // 
            listConcluido.Location = new Point(12, 263);
            listConcluido.Name = "listConcluido";
            listConcluido.Size = new Size(1110, 179);
            listConcluido.TabIndex = 7;
            listConcluido.UseCompatibleStateImageBehavior = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DodgerBlue;
            button3.ForeColor = Color.White;
            button3.Location = new Point(1104, 16);
            button3.Name = "button3";
            button3.Size = new Size(99, 40);
            button3.TabIndex = 8;
            button3.Text = "Novo Pedido";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1128, 73);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 9;
            button4.Text = "Concluir";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1128, 263);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 10;
            button5.Text = "Desfazer";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.Location = new Point(1128, 102);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 11;
            button6.Text = "Remover";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Pedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 454);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(listConcluido);
            Controls.Add(label3);
            Controls.Add(listAberto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lblPesquisa);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Pedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos";
            Activated += Pedido_Activated;
            Load += Pedido_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lblPesquisa;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private ListView listAberto;
        private Label label3;
        private ListView listConcluido;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}