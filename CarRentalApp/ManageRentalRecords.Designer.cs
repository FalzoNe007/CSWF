
namespace CarRentalApp
{
    partial class ManageRentalRecords
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
            this.btnRefreshRecords = new System.Windows.Forms.Button();
            this.btnEditRecord = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRentalRecords = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshRecords
            // 
            this.btnRefreshRecords.Location = new System.Drawing.Point(578, 300);
            this.btnRefreshRecords.Name = "btnRefreshRecords";
            this.btnRefreshRecords.Size = new System.Drawing.Size(75, 48);
            this.btnRefreshRecords.TabIndex = 11;
            this.btnRefreshRecords.Text = "Refresh";
            this.btnRefreshRecords.UseVisualStyleBackColor = true;
            this.btnRefreshRecords.Click += new System.EventHandler(this.btnRefreshRecords_Click);
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Location = new System.Drawing.Point(186, 299);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(75, 48);
            this.btnEditRecord.TabIndex = 10;
            this.btnEditRecord.Text = "Edit Record";
            this.btnEditRecord.UseVisualStyleBackColor = true;
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(267, 299);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(75, 48);
            this.btnDeleteRecord.TabIndex = 9;
            this.btnDeleteRecord.Text = "Delete record";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(105, 299);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(75, 48);
            this.btnAddRecord.TabIndex = 8;
            this.btnAddRecord.Text = "Add record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manage Rental Records";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvRentalRecords
            // 
            this.dgvRentalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalRecords.Location = new System.Drawing.Point(92, 83);
            this.dgvRentalRecords.Name = "dgvRentalRecords";
            this.dgvRentalRecords.Size = new System.Drawing.Size(561, 211);
            this.dgvRentalRecords.TabIndex = 6;
            this.dgvRentalRecords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRentalRecords_CellContentClick);
            // 
            // ManageRentalRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefreshRecords);
            this.Controls.Add(this.btnEditRecord);
            this.Controls.Add(this.btnDeleteRecord);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRentalRecords);
            this.Name = "ManageRentalRecords";
            this.Text = "ManageRentalRecords";
            this.Load += new System.EventHandler(this.ManageRentalRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshRecords;
        private System.Windows.Forms.Button btnEditRecord;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRentalRecords;
    }
}