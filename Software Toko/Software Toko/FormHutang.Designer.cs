namespace Software_Toko
{
    partial class FormHutang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgHutang = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.buttonBayarHutang = new System.Windows.Forms.Button();
            this.txtBayarHutang = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtKembalian = new System.Windows.Forms.TextBox();
            this.txtJumlahHutang = new System.Windows.Forms.TextBox();
            this.txtNoFaktur = new System.Windows.Forms.TextBox();
            this.lblHargaBeli = new System.Windows.Forms.Label();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSisaHutang = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgHutang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHutang
            // 
            this.dgHutang.AllowUserToAddRows = false;
            this.dgHutang.AllowUserToDeleteRows = false;
            this.dgHutang.AllowUserToResizeColumns = false;
            this.dgHutang.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgHutang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgHutang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHutang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHutang.Location = new System.Drawing.Point(15, 20);
            this.dgHutang.Name = "dgHutang";
            this.dgHutang.ReadOnly = true;
            this.dgHutang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHutang.Size = new System.Drawing.Size(539, 235);
            this.dgHutang.TabIndex = 22;
            this.dgHutang.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgHutang_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.dgHutang);
            this.groupBox1.Location = new System.Drawing.Point(12, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 261);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txtSisaHutang);
            this.groupBox2.Controls.Add(this.txtBayarHutang);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.txtKembalian);
            this.groupBox2.Controls.Add(this.txtJumlahHutang);
            this.groupBox2.Controls.Add(this.txtNoFaktur);
            this.groupBox2.Controls.Add(this.lblHargaBeli);
            this.groupBox2.Controls.Add(this.lblNamaBarang);
            this.groupBox2.Controls.Add(this.lblId);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 135);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.CadetBlue;
            this.label27.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(11, 169);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(560, 42);
            this.label27.TabIndex = 167;
            // 
            // buttonBayarHutang
            // 
            this.buttonBayarHutang.Location = new System.Drawing.Point(452, 172);
            this.buttonBayarHutang.Name = "buttonBayarHutang";
            this.buttonBayarHutang.Size = new System.Drawing.Size(110, 30);
            this.buttonBayarHutang.TabIndex = 170;
            this.buttonBayarHutang.Text = "Bayar Hutang";
            this.buttonBayarHutang.UseVisualStyleBackColor = true;
            this.buttonBayarHutang.Click += new System.EventHandler(this.buttonBayarHutang_Click);
            // 
            // txtBayarHutang
            // 
            this.txtBayarHutang.BackColor = System.Drawing.Color.LightCoral;
            this.txtBayarHutang.Location = new System.Drawing.Point(359, 19);
            this.txtBayarHutang.Name = "txtBayarHutang";
            this.txtBayarHutang.Size = new System.Drawing.Size(192, 20);
            this.txtBayarHutang.TabIndex = 21;
            this.txtBayarHutang.Text = "0";
            this.txtBayarHutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBayarHutang.TextChanged += new System.EventHandler(this.txtBayarHutang_TextChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(285, 22);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(34, 13);
            this.label39.TabIndex = 20;
            this.label39.Text = "Bayar";
            // 
            // txtKembalian
            // 
            this.txtKembalian.BackColor = System.Drawing.Color.LightCoral;
            this.txtKembalian.Enabled = false;
            this.txtKembalian.Location = new System.Drawing.Point(359, 44);
            this.txtKembalian.Name = "txtKembalian";
            this.txtKembalian.Size = new System.Drawing.Size(192, 20);
            this.txtKembalian.TabIndex = 19;
            this.txtKembalian.Text = "0";
            this.txtKembalian.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtJumlahHutang
            // 
            this.txtJumlahHutang.Enabled = false;
            this.txtJumlahHutang.Location = new System.Drawing.Point(65, 45);
            this.txtJumlahHutang.Name = "txtJumlahHutang";
            this.txtJumlahHutang.Size = new System.Drawing.Size(192, 20);
            this.txtJumlahHutang.TabIndex = 18;
            this.txtJumlahHutang.Text = "0";
            this.txtJumlahHutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNoFaktur
            // 
            this.txtNoFaktur.Enabled = false;
            this.txtNoFaktur.Location = new System.Drawing.Point(65, 19);
            this.txtNoFaktur.Name = "txtNoFaktur";
            this.txtNoFaktur.Size = new System.Drawing.Size(192, 20);
            this.txtNoFaktur.TabIndex = 17;
            this.txtNoFaktur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHargaBeli
            // 
            this.lblHargaBeli.AutoSize = true;
            this.lblHargaBeli.Location = new System.Drawing.Point(285, 47);
            this.lblHargaBeli.Name = "lblHargaBeli";
            this.lblHargaBeli.Size = new System.Drawing.Size(56, 13);
            this.lblHargaBeli.TabIndex = 16;
            this.lblHargaBeli.Text = "Kembalian";
            // 
            // lblNamaBarang
            // 
            this.lblNamaBarang.AutoSize = true;
            this.lblNamaBarang.Location = new System.Drawing.Point(5, 48);
            this.lblNamaBarang.Name = "lblNamaBarang";
            this.lblNamaBarang.Size = new System.Drawing.Size(42, 13);
            this.lblNamaBarang.TabIndex = 15;
            this.lblNamaBarang.Text = "Hutang";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(5, 22);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(54, 13);
            this.lblId.TabIndex = 14;
            this.lblId.Text = "No Faktur";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(209, 43);
            this.label21.TabIndex = 113;
            this.label21.Text = "Sisa Hutang";
            // 
            // txtSisaHutang
            // 
            this.txtSisaHutang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtSisaHutang.Enabled = false;
            this.txtSisaHutang.Font = new System.Drawing.Font("Trebuchet MS", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSisaHutang.ForeColor = System.Drawing.Color.White;
            this.txtSisaHutang.Location = new System.Drawing.Point(221, 72);
            this.txtSisaHutang.Name = "txtSisaHutang";
            this.txtSisaHutang.Size = new System.Drawing.Size(329, 57);
            this.txtSisaHutang.TabIndex = 112;
            this.txtSisaHutang.Text = "0";
            this.txtSisaHutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormHutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 487);
            this.Controls.Add(this.buttonBayarHutang);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormHutang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHutang";
            this.Load += new System.EventHandler(this.FormHutang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHutang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHutang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button buttonBayarHutang;
        private System.Windows.Forms.TextBox txtBayarHutang;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtKembalian;
        private System.Windows.Forms.TextBox txtJumlahHutang;
        private System.Windows.Forms.TextBox txtNoFaktur;
        private System.Windows.Forms.Label lblHargaBeli;
        private System.Windows.Forms.Label lblNamaBarang;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSisaHutang;
    }
}