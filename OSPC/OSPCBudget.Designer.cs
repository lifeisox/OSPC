namespace OSPC {
	partial class OSPCBudget {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ();
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCBudget));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRun = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.inYear = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.gridBG = new System.Windows.Forms.DataGridView();
			this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gubun = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hang_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hang_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mok_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mok_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.budget = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridBG)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnRun);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.inYear);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(20, 9, 20, 9);
			this.panel1.Size = new System.Drawing.Size(439, 50);
			this.panel1.TabIndex = 0;
			// 
			// btnRun
			// 
			this.btnRun.Image = global::OSPC.Properties.Resources.GoToNextHS;
			this.btnRun.Location = new System.Drawing.Point(115, 9);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(65, 28);
			this.btnRun.TabIndex = 1;
			this.btnRun.Text = "취소";
			this.btnRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// btnSave
			// 
			this.btnSave.Image = global::OSPC.Properties.Resources.saveHS;
			this.btnSave.Location = new System.Drawing.Point(185, 9);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(65, 28);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "저장";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// inYear
			// 
			this.inYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inYear.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inYear.FormattingEnabled = true;
			this.inYear.Location = new System.Drawing.Point(20, 10);
			this.inYear.Name = "inYear";
			this.inYear.Size = new System.Drawing.Size(85, 25);
			this.inYear.TabIndex = 0;
			this.inYear.SelectedIndexChanged += new System.EventHandler(this.inYear_SelectedIndexChanged);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Location = new System.Drawing.Point(350, 9);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(65, 28);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "닫기";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.gridBG);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(439, 396);
			this.panel2.TabIndex = 1;
			// 
			// gridBG
			// 
			this.gridBG.AllowUserToAddRows = false;
			this.gridBG.AllowUserToResizeColumns = false;
			this.gridBG.AllowUserToResizeRows = false;
			this.gridBG.BackgroundColor = System.Drawing.SystemColors.Control;
			this.gridBG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.gridBG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridBG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridBG.ColumnHeadersHeight = 25;
			this.gridBG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.gridBG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.year,
            this.gubun,
            this.hang_code,
            this.hang_name,
            this.mok_code,
            this.mok_name,
            this.budget});
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridBG.DefaultCellStyle = dataGridViewCellStyle6;
			this.gridBG.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridBG.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gridBG.Location = new System.Drawing.Point(0, 0);
			this.gridBG.MultiSelect = false;
			this.gridBG.Name = "gridBG";
			this.gridBG.RowHeadersVisible = false;
			this.gridBG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.gridBG.RowTemplate.Height = 23;
			this.gridBG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.gridBG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridBG.Size = new System.Drawing.Size(439, 396);
			this.gridBG.TabIndex = 4;
			this.gridBG.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBG_CellValueChanged);
			// 
			// year
			// 
			this.year.HeaderText = "year";
			this.year.Name = "year";
			this.year.Visible = false;
			// 
			// gubun
			// 
			this.gubun.HeaderText = "gubun";
			this.gubun.Name = "gubun";
			this.gubun.Visible = false;
			// 
			// hang_code
			// 
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			this.hang_code.DefaultCellStyle = dataGridViewCellStyle2;
			this.hang_code.HeaderText = "hang_code";
			this.hang_code.Name = "hang_code";
			this.hang_code.Visible = false;
			// 
			// hang_name
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			this.hang_name.DefaultCellStyle = dataGridViewCellStyle3;
			this.hang_name.HeaderText = "항";
			this.hang_name.MaxInputLength = 30;
			this.hang_name.Name = "hang_name";
			this.hang_name.ReadOnly = true;
			this.hang_name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.hang_name.Width = 120;
			// 
			// mok_code
			// 
			this.mok_code.HeaderText = "mok_code";
			this.mok_code.Name = "mok_code";
			this.mok_code.Visible = false;
			// 
			// mok_name
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.mok_name.DefaultCellStyle = dataGridViewCellStyle4;
			this.mok_name.HeaderText = "목";
			this.mok_name.MaxInputLength = 50;
			this.mok_name.Name = "mok_name";
			this.mok_name.ReadOnly = true;
			this.mok_name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.mok_name.Width = 150;
			// 
			// budget
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "C2";
			dataGridViewCellStyle5.NullValue = null;
			dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
			this.budget.DefaultCellStyle = dataGridViewCellStyle5;
			this.budget.HeaderText = "예산";
			this.budget.Name = "budget";
			this.budget.Width = 150;
			// 
			// OSPCBudget
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(439, 446);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OSPCBudget";
			this.Text = "예산 입력";
			this.Activated += new System.EventHandler(this.OSPCBudget_Activated);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridBG)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.DataGridView gridBG;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ComboBox inYear;
		private System.Windows.Forms.DataGridViewTextBoxColumn year;
		private System.Windows.Forms.DataGridViewTextBoxColumn gubun;
		private System.Windows.Forms.DataGridViewTextBoxColumn hang_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn hang_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn mok_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn mok_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn budget;
	}
}