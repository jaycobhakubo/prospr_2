
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtbxRegion = new System.Windows.Forms.TextBox();
            this.dgvBranch = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(328, 365);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(129, 59);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.Location = new System.Drawing.Point(23, 21);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(91, 29);
            this.lblRegion.TabIndex = 1;
            this.lblRegion.Text = "Region";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.Location = new System.Drawing.Point(26, 116);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(88, 29);
            this.lblBranch.TabIndex = 2;
            this.lblBranch.Text = "Branch";
            // 
            // txtbxRegion
            // 
            this.txtbxRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxRegion.Location = new System.Drawing.Point(28, 53);
            this.txtbxRegion.Name = "txtbxRegion";
            this.txtbxRegion.Size = new System.Drawing.Size(438, 30);
            this.txtbxRegion.TabIndex = 3;
            // 
            // dgvBranch
            // 
            this.dgvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranch.Location = new System.Drawing.Point(28, 157);
            this.dgvBranch.Name = "dgvBranch";
            this.dgvBranch.RowHeadersWidth = 51;
            this.dgvBranch.RowTemplate.Height = 24;
            this.dgvBranch.Size = new System.Drawing.Size(435, 150);
            this.dgvBranch.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 450);
            this.Controls.Add(this.dgvBranch);
            this.Controls.Add(this.txtbxRegion);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Label lblRegion;
		private System.Windows.Forms.Label lblBranch;
		private System.Windows.Forms.TextBox txtbxRegion;
		private System.Windows.Forms.DataGridView dgvBranch;
	}
}

