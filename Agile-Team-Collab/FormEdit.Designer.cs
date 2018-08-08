namespace Agile_Team_Collab
{
    partial class FormEdit
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.Column_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Code,
            this.Column_Name,
            this.Column_Price});
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(776, 386);
            this.dgvData.TabIndex = 0;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(511, 415);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 1;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(615, 415);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(713, 415);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Column_Code
            // 
            this.Column_Code.HeaderText = "Code";
            this.Column_Code.Name = "Column_Code";
            this.Column_Code.ReadOnly = true;
            // 
            // Column_Name
            // 
            this.Column_Name.HeaderText = "Name";
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Column_Price
            // 
            this.Column_Price.HeaderText = "Price";
            this.Column_Price.Name = "Column_Price";
            this.Column_Price.ReadOnly = true;
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.dgvData);
            this.Name = "FormEdit";
            this.Text = "FormEdit";
            this.Load += new System.EventHandler(this.FormEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Price;
    }
}