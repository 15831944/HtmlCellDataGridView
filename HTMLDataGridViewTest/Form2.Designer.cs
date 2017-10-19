namespace HTMLDataGridViewTest
{
	partial class Form2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.dataGridView1 = new DataGridViewHTML.DataGridViewEx();
			this.buttonClose = new System.Windows.Forms.Button();
			this.dataGridViewHTMLColumn1 = new DataGridViewHTML.DataGridViewHTMLColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
			this.Column6 = new DataGridViewHTML.DataGridViewHTMLColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7});
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridView1.GridColor = System.Drawing.Color.Orange;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(873, 585);
			this.dataGridView1.TabIndex = 0;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(810, 603);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// dataGridViewHTMLColumn1
			// 
			this.dataGridViewHTMLColumn1.FillWeight = 300F;
			this.dataGridViewHTMLColumn1.HeaderText = "工艺内容";
			this.dataGridViewHTMLColumn1.Name = "dataGridViewHTMLColumn1";
			this.dataGridViewHTMLColumn1.ReadOnly = true;
			this.dataGridViewHTMLColumn1.Width = 300;
			// 
			// Column1
			// 
			this.Column1.Frozen = true;
			this.Column1.HeaderText = "名称";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 60;
			// 
			// Column2
			// 
			this.Column2.FillWeight = 20F;
			this.Column2.HeaderText = "视图";
			this.Column2.Image = ((System.Drawing.Image)(resources.GetObject("Column2.Image")));
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 20;
			// 
			// Column3
			// 
			this.Column3.FillWeight = 20F;
			this.Column3.HeaderText = "元素";
			this.Column3.Image = ((System.Drawing.Image)(resources.GetObject("Column3.Image")));
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 20;
			// 
			// Column4
			// 
			this.Column4.FillWeight = 20F;
			this.Column4.HeaderText = "零件";
			this.Column4.Image = ((System.Drawing.Image)(resources.GetObject("Column4.Image")));
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 20;
			// 
			// Column6
			// 
			this.Column6.FillWeight = 300F;
			this.Column6.HeaderText = "工艺内容";
			this.Column6.Name = "Column6";
			this.Column6.Width = 300;
			// 
			// Column7
			// 
			this.Column7.FillWeight = 150F;
			this.Column7.HeaderText = "备注";
			this.Column7.Name = "Column7";
			this.Column7.Width = 150;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(897, 638);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form2";
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DataGridViewHTML.DataGridViewEx dataGridView1;
		private System.Windows.Forms.Button buttonClose;
		private DataGridViewHTML.DataGridViewHTMLColumn dataGridViewHTMLColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewImageColumn Column2;
		private System.Windows.Forms.DataGridViewImageColumn Column3;
		private System.Windows.Forms.DataGridViewImageColumn Column4;
		private DataGridViewHTML.DataGridViewHTMLColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
	}
}