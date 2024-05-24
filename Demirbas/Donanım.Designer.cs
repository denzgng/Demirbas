namespace Demirbas
{
    partial class Donanım
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.genelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donanımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKasaBlgisi = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(641, 240);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genelToolStripMenuItem,
            this.donanımToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // genelToolStripMenuItem
            // 
            this.genelToolStripMenuItem.Name = "genelToolStripMenuItem";
            this.genelToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.genelToolStripMenuItem.Text = "Genel";
            this.genelToolStripMenuItem.Click += new System.EventHandler(this.genelToolStripMenuItem_Click);
            // 
            // donanımToolStripMenuItem
            // 
            this.donanımToolStripMenuItem.Name = "donanımToolStripMenuItem";
            this.donanımToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.donanımToolStripMenuItem.Text = "Donanım";
            // 
            // btnKasaBlgisi
            // 
            this.btnKasaBlgisi.Location = new System.Drawing.Point(550, 379);
            this.btnKasaBlgisi.Name = "btnKasaBlgisi";
            this.btnKasaBlgisi.Size = new System.Drawing.Size(103, 38);
            this.btnKasaBlgisi.TabIndex = 23;
            this.btnKasaBlgisi.Text = "Kasa Bilgisi";
            this.btnKasaBlgisi.UseVisualStyleBackColor = true;
            this.btnKasaBlgisi.Click += new System.EventHandler(this.btnKasaBlgisi_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Location = new System.Drawing.Point(12, 379);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(103, 38);
            this.btnUrunEkle.TabIndex = 24;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(121, 379);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(103, 38);
            this.btnSil.TabIndex = 25;
            this.btnSil.Text = "Ürünü Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // Donanım
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnUrunEkle);
            this.Controls.Add(this.btnKasaBlgisi);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Donanım";
            this.Text = "Donanım";
            this.Load += new System.EventHandler(this.Donanım_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem genelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donanımToolStripMenuItem;
        private System.Windows.Forms.Button btnKasaBlgisi;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnSil;
    }
}