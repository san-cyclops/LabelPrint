﻿namespace ERP.UI.Windows
{
    partial class FrmReferenceSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch1 = new System.Windows.Forms.TextBox();
            this.cmbSearchOption = new System.Windows.Forms.ComboBox();
            this.cmbOperation = new System.Windows.Forms.ComboBox();
            this.txtSearch2 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgvSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(5, 29);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.Size = new System.Drawing.Size(912, 220);
            this.dgvSearch.TabIndex = 4;
            this.dgvSearch.DoubleClick += new System.EventHandler(this.dgvSearch_DoubleClick);
            this.dgvSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSearch_KeyDown);
            // 
            // txtSearch1
            // 
            this.txtSearch1.Location = new System.Drawing.Point(334, 4);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(247, 21);
            this.txtSearch1.TabIndex = 2;
            this.txtSearch1.TextChanged += new System.EventHandler(this.txtSearch1_TextChanged);
            this.txtSearch1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch1_KeyDown);
            // 
            // cmbSearchOption
            // 
            this.cmbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchOption.FormattingEnabled = true;
            this.cmbSearchOption.Location = new System.Drawing.Point(5, 4);
            this.cmbSearchOption.Name = "cmbSearchOption";
            this.cmbSearchOption.Size = new System.Drawing.Size(185, 21);
            this.cmbSearchOption.TabIndex = 0;
            this.cmbSearchOption.SelectedIndexChanged += new System.EventHandler(this.cmbSearchOption_SelectedIndexChanged);
            // 
            // cmbOperation
            // 
            this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperation.FormattingEnabled = true;
            this.cmbOperation.Location = new System.Drawing.Point(192, 4);
            this.cmbOperation.Name = "cmbOperation";
            this.cmbOperation.Size = new System.Drawing.Size(140, 21);
            this.cmbOperation.TabIndex = 1;
            this.cmbOperation.SelectedIndexChanged += new System.EventHandler(this.cmbOperation_SelectedIndexChanged);
            // 
            // txtSearch2
            // 
            this.txtSearch2.Location = new System.Drawing.Point(583, 4);
            this.txtSearch2.Name = "txtSearch2";
            this.txtSearch2.Size = new System.Drawing.Size(247, 21);
            this.txtSearch2.TabIndex = 3;
            this.txtSearch2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch2_KeyDown);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(830, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FrmReferenceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 253);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearch2);
            this.Controls.Add(this.cmbOperation);
            this.Controls.Add(this.cmbSearchOption);
            this.Controls.Add(this.txtSearch1);
            this.Controls.Add(this.dgvSearch);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(295, 230);
            this.MaximizeBox = false;
            this.Name = "FrmReferenceSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.FrmReferenceSearch_Activated);
            this.Deactivate += new System.EventHandler(this.FrmReferenceSearch_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReferenceSearch_FormClosing);
            this.Load += new System.EventHandler(this.FrmReferenceSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReferenceSearch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.TextBox txtSearch1;
        private System.Windows.Forms.ComboBox cmbSearchOption;
        private System.Windows.Forms.ComboBox cmbOperation;
        private System.Windows.Forms.TextBox txtSearch2;
        private System.Windows.Forms.Button btnReset;
    }
}