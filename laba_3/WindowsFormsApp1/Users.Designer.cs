namespace WindowsFormsApp1
{
    partial class Users
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNomer = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.labelSumma = new System.Windows.Forms.Label();
            this.export = new System.Windows.Forms.Button();
            this.Postav = new System.Windows.Forms.TextBox();
            this.Pokup = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(464, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поставщик\r\n\r\n\r\nПокупатель";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Итого:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Заказ №";
            // 
            // labelNomer
            // 
            this.labelNomer.AutoSize = true;
            this.labelNomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNomer.Location = new System.Drawing.Point(480, 33);
            this.labelNomer.Name = "labelNomer";
            this.labelNomer.Size = new System.Drawing.Size(63, 13);
            this.labelNomer.TabIndex = 4;
            this.labelNomer.Text = "10123123";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelData.Location = new System.Drawing.Point(444, 72);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(71, 13);
            this.labelData.TabIndex = 5;
            this.labelData.Text = "06.02.2025";
            // 
            // labelSumma
            // 
            this.labelSumma.AutoSize = true;
            this.labelSumma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSumma.Location = new System.Drawing.Point(40, 414);
            this.labelSumma.Name = "labelSumma";
            this.labelSumma.Size = new System.Drawing.Size(127, 20);
            this.labelSumma.TabIndex = 6;
            this.labelSumma.Text = "Сумма итого";
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(151, 463);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(235, 44);
            this.export.TabIndex = 7;
            this.export.Text = "Сформировать документ";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // Postav
            // 
            this.Postav.Location = new System.Drawing.Point(126, 25);
            this.Postav.Name = "Postav";
            this.Postav.Size = new System.Drawing.Size(260, 20);
            this.Postav.TabIndex = 8;
            // 
            // Pokup
            // 
            this.Pokup.Location = new System.Drawing.Point(126, 72);
            this.Pokup.Name = "Pokup";
            this.Pokup.Size = new System.Drawing.Size(260, 20);
            this.Pokup.TabIndex = 9;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 528);
            this.Controls.Add(this.Pokup);
            this.Controls.Add(this.Postav);
            this.Controls.Add(this.export);
            this.Controls.Add(this.labelSumma);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelNomer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сформировать представление о мире и жить в кайф";
            this.Load += new System.EventHandler(this.Workers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNomer;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelSumma;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.TextBox Postav;
        private System.Windows.Forms.TextBox Pokup;
    }
}