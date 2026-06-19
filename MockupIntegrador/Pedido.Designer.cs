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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedido));
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
            pictureBox1 = new PictureBox();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblPesquisa
            // 
            lblPesquisa.Location = new Point(297, 196);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(359, 23);
            lblPesquisa.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(662, 195);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.Location = new Point(743, 195);
            button2.Name = "button2";
            button2.Size = new Size(45, 23);
            button2.TabIndex = 2;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 178);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Buscar";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 200);
            label2.Name = "label2";
            label2.Size = new Size(191, 23);
            label2.TabIndex = 4;
            label2.Text = "Pedidos Em Aberto";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listAberto
            // 
            listAberto.Location = new Point(12, 226);
            listAberto.Name = "listAberto";
            listAberto.Size = new Size(1110, 161);
            listAberto.TabIndex = 5;
            listAberto.UseCompatibleStateImageBehavior = false;
            listAberto.DoubleClick += listAberto_DoubleClick;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 390);
            label3.Name = "label3";
            label3.Size = new Size(776, 23);
            label3.TabIndex = 6;
            label3.Text = "Pedidos Concluidos";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listConcluido
            // 
            listConcluido.Location = new Point(12, 416);
            listConcluido.Name = "listConcluido";
            listConcluido.Size = new Size(1110, 179);
            listConcluido.TabIndex = 7;
            listConcluido.UseCompatibleStateImageBehavior = false;
            // 
            // button3
            // 
            button3.BackColor = Color.LightBlue;
            button3.ForeColor = Color.Black;
            button3.Location = new Point(1023, 179);
            button3.Name = "button3";
            button3.Size = new Size(99, 40);
            button3.TabIndex = 8;
            button3.Text = "Novo Pedido";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.LightBlue;
            button4.Location = new Point(1128, 226);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 9;
            button4.Text = "Concluir";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.LightBlue;
            button5.Location = new Point(1128, 416);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 10;
            button5.Text = "Desfazer";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.BackColor = Color.LightBlue;
            button6.Location = new Point(1128, 255);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 11;
            button6.Text = "Remover";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 185);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // button7
            // 
            button7.BackColor = Color.LightBlue;
            button7.ForeColor = Color.Black;
            button7.Location = new Point(813, 179);
            button7.Name = "button7";
            button7.Size = new Size(99, 40);
            button7.TabIndex = 13;
            button7.Text = "Insumos";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.LightBlue;
            button8.ForeColor = Color.Black;
            button8.Location = new Point(918, 179);
            button8.Name = "button8";
            button8.Size = new Size(99, 40);
            button8.TabIndex = 14;
            button8.Text = "Serviços";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // Pedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1210, 607);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(pictureBox1);
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
            Text = "Lavanderia Campo Grande";
            Activated += Pedido_Activated;
            Load += Pedido_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
        private Button button7;
        private Button button8;
    }
}