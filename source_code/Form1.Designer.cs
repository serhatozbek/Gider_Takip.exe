namespace deneme
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtGiderAdi = new TextBox();
            txtMiktar = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            lblToplamGider = new Label();
            dataGridView1 = new DataGridView();
            lblToplamGelir = new Label();
            txtGelirAdi = new TextBox();
            txtMiktar1 = new TextBox();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button3 = new Button();
            button4 = new Button();
            label5 = new Label();
            btnAyiYukle = new Button();
            lstAylar = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // txtGiderAdi
            // 
            txtGiderAdi.Location = new Point(59, 125);
            txtGiderAdi.Name = "txtGiderAdi";
            txtGiderAdi.Size = new Size(100, 23);
            txtGiderAdi.TabIndex = 0;
            // 
            // txtMiktar
            // 
            txtMiktar.Location = new Point(59, 191);
            txtMiktar.MaxLength = 15;
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(100, 23);
            txtMiktar.TabIndex = 1;
            txtMiktar.KeyPress += txtMiktar_KeyPress;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dateTimePicker1.Location = new Point(73, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(63, 246);
            button1.Name = "button1";
            button1.Size = new Size(89, 35);
            button1.TabIndex = 4;
            button1.Text = "GİDER EKLE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblToplamGider
            // 
            lblToplamGider.AutoSize = true;
            lblToplamGider.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblToplamGider.Location = new Point(379, 10);
            lblToplamGider.Name = "lblToplamGider";
            lblToplamGider.Size = new Size(0, 15);
            lblToplamGider.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(379, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(531, 241);
            dataGridView1.TabIndex = 6;
            // 
            // lblToplamGelir
            // 
            lblToplamGelir.AutoSize = true;
            lblToplamGelir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblToplamGelir.Location = new Point(379, 302);
            lblToplamGelir.Name = "lblToplamGelir";
            lblToplamGelir.Size = new Size(0, 15);
            lblToplamGelir.TabIndex = 7;
            // 
            // txtGelirAdi
            // 
            txtGelirAdi.Location = new Point(197, 125);
            txtGelirAdi.Name = "txtGelirAdi";
            txtGelirAdi.Size = new Size(100, 23);
            txtGelirAdi.TabIndex = 8;
            // 
            // txtMiktar1
            // 
            txtMiktar1.Location = new Point(198, 191);
            txtMiktar1.Name = "txtMiktar1";
            txtMiktar1.Size = new Size(100, 23);
            txtMiktar1.TabIndex = 9;
            txtMiktar1.KeyPress += txtMiktar1_KeyPress;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(198, 246);
            button2.Name = "button2";
            button2.Size = new Size(89, 35);
            button2.TabIndex = 10;
            button2.Text = "GELİR EKLE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(379, 320);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(531, 241);
            dataGridView2.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(73, 95);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 12;
            label1.Text = "GİDER ADI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(59, 164);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 13;
            label2.Text = "GİDER MİKTARI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(212, 95);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 14;
            label3.Text = "GELİR ADI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(198, 164);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 15;
            label4.Text = "GELİR MİKTARI";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.Location = new Point(597, 275);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 16;
            button3.Text = "GİDER SİL";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.Location = new Point(597, 577);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 17;
            button4.Text = "GELİR SİL";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.InfoText;
            label5.Location = new Point(12, 594);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 18;
            label5.Text = "#sozbek";
            // 
            // btnAyiYukle
            // 
            btnAyiYukle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnAyiYukle.Location = new Point(89, 465);
            btnAyiYukle.Name = "btnAyiYukle";
            btnAyiYukle.Size = new Size(163, 35);
            btnAyiYukle.TabIndex = 20;
            btnAyiYukle.Text = "Seçili Ayın Tablosunu Getir";
            btnAyiYukle.UseVisualStyleBackColor = true;
            btnAyiYukle.Click += btnAyiYukle_Click;
            // 
            // lstAylar
            // 
            lstAylar.FormattingEnabled = true;
            lstAylar.ItemHeight = 15;
            lstAylar.Location = new Point(63, 320);
            lstAylar.Name = "lstAylar";
            lstAylar.Size = new Size(224, 124);
            lstAylar.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(940, 623);
            Controls.Add(lstAylar);
            Controls.Add(btnAyiYukle);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(button2);
            Controls.Add(txtMiktar1);
            Controls.Add(txtGelirAdi);
            Controls.Add(lblToplamGelir);
            Controls.Add(dataGridView1);
            Controls.Add(lblToplamGider);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtMiktar);
            Controls.Add(txtGiderAdi);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gelir Gider Hesaplama";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGiderAdi;
        private TextBox txtMiktar;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Label lblToplamGider;
        private DataGridView dataGridView1;
        private Label lblToplamGelir;
        private TextBox txtGelirAdi;
        private TextBox txtMiktar1;
        private Button button2;
        private DataGridView dataGridView2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button3;
        private Button button4;
        private Label label5;
        private Button btnAyiYukle;
        private ListBox lstAylar;
    }
}
