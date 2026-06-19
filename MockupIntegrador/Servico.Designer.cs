namespace MockupIntegrador
{
    partial class Servico
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
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            comboItens = new ComboBox();
            button2 = new Button();
            button4 = new Button();
            listView1 = new ListView();
            lblTotalServico = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(533, 23);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Serviço";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome do Serviço";
            // 
            // lblNome
            // 
            lblNome.Location = new Point(15, 78);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(530, 23);
            lblNome.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.Location = new Point(240, 420);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 168);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 9;
            label3.Text = "Itens";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 113);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 11;
            label4.Text = "Itens";
            // 
            // comboItens
            // 
            comboItens.FormattingEnabled = true;
            comboItens.Location = new Point(16, 131);
            comboItens.Name = "comboItens";
            comboItens.Size = new Size(444, 23);
            comboItens.TabIndex = 12;
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.Location = new Point(470, 187);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Remover";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button4
            // 
            button4.BackColor = Color.LightBlue;
            button4.Location = new Point(470, 130);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 15;
            button4.Text = "Adicionar";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // listView1
            // 
            listView1.Location = new Point(15, 186);
            listView1.Name = "listView1";
            listView1.Size = new Size(445, 175);
            listView1.TabIndex = 16;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // lblTotalServico
            // 
            lblTotalServico.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalServico.Location = new Point(12, 364);
            lblTotalServico.Name = "lblTotalServico";
            lblTotalServico.Size = new Size(533, 23);
            lblTotalServico.TabIndex = 17;
            lblTotalServico.Text = "Total Serviço: R$ 0,00";
            lblTotalServico.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            button3.BackColor = Color.IndianRed;
            button3.ForeColor = Color.White;
            button3.Location = new Point(12, 420);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "Excluir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Servico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(557, 455);
            Controls.Add(button3);
            Controls.Add(lblTotalServico);
            Controls.Add(listView1);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(comboItens);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(lblNome);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Servico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Serviço";
            Load += Servico_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox lblNome;
        private Button button1;
        private Label label3;
        private Label label4;
        private ComboBox comboItens;
        private Button button2;
        private Button button4;
        private ListView listView1;
        private Label lblTotalServico;
        private Button button3;
    }
}
