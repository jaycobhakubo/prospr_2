
namespace WindowsFormsApp4
{
	partial class Form1
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
            this.lblRegion = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvBranches = new System.Windows.Forms.DataGridView();
            this.txtbxRegionName = new System.Windows.Forms.TextBox();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(12, 33);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(91, 16);
            this.lblRegion.TabIndex = 0;
            this.lblRegion.Text = "Region Name";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(214, 54);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvBranches
            // 
            this.dgvBranches.AutoGenerateColumns = false;
            this.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dgvBranches.DataSource = this.branchBindingSource;
            this.dgvBranches.Location = new System.Drawing.Point(12, 151);
            this.dgvBranches.Name = "dgvBranches";
            this.dgvBranches.RowHeadersWidth = 51;
            this.dgvBranches.RowTemplate.Height = 24;
            this.dgvBranches.Size = new System.Drawing.Size(277, 201);
            this.dgvBranches.TabIndex = 2;
            // 
            // txtbxRegionName
            // 
            this.txtbxRegionName.Location = new System.Drawing.Point(114, 26);
            this.txtbxRegionName.Name = "txtbxRegionName";
            this.txtbxRegionName.Size = new System.Drawing.Size(175, 22);
            this.txtbxRegionName.TabIndex = 3;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Branch Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // branchBindingSource
            // 
            this.branchBindingSource.DataSource = typeof(WindowsFormsApp4.Branch);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 448);
            this.Controls.Add(this.txtbxRegionName);
            this.Controls.Add(this.dgvBranches);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblRegion);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblRegion;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.DataGridView dgvBranches;
        private System.Windows.Forms.TextBox txtbxRegionName;
        private System.Windows.Forms.BindingSource branchBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}

