namespace Agile_Team_Collab
{
    partial class FrmEditDataBarang
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(81, 238);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 14;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.Location = new System.Drawing.Point(155, 167);
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.Size = new System.Drawing.Size(111, 20);
            this.txtBoxPrice.TabIndex = 13;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(155, 107);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(111, 20);
            this.txtBoxName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(80, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(76, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name";
            // 
            // txtBoxCode
            // 
            this.txtBoxCode.Location = new System.Drawing.Point(155, 53);
            this.txtBoxCode.Name = "txtBoxCode";
            this.txtBoxCode.ReadOnly = true;
            this.txtBoxCode.Size = new System.Drawing.Size(111, 20);
            this.txtBoxCode.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(80, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Code";
            // 
            // FrmEditDataBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 309);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtBoxPrice);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxCode);
            this.Controls.Add(this.label1);
            this.Name = "FrmEditDataBarang";
            this.Text = "FrmEditDataBarang";
            this.Load += new System.EventHandler(this.FrmEditDataBarang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxCode;
        private System.Windows.Forms.Label label1;
    }
}