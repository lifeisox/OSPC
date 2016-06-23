namespace OSPC {
	partial class OSPCOffering {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCOffering));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel0 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnChange = new System.Windows.Forms.Button();
			this.lblFamily = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.lblTitle1 = new System.Windows.Forms.Label();
			this.inName = new System.Windows.Forms.ComboBox();
			this.lblTitle0 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.gridTrans = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.gridTotal = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.gubun = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inDate = new MultiBoxControls.MultiCalendar();
			this.panel0.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTrans)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTotal)).BeginInit();
			this.SuspendLayout();
			// 
			// panel0
			// 
			this.panel0.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.panel0.Controls.Add(this.panel1);
			this.panel0.Controls.Add(this.panel5);
			this.panel0.Controls.Add(this.panel2);
			resources.ApplyResources(this.panel0, "panel0");
			this.panel0.Name = "panel0";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.PeachPuff;
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.lblFamily);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.lblTitle1);
			this.panel1.Controls.Add(this.inName);
			this.panel1.Controls.Add(this.lblTitle0);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			// 
			// btnDelete
			// 
			this.btnDelete.Image = global::OSPC.Properties.Resources.DeleteFolderHS;
			resources.ApplyResources(this.btnDelete, "btnDelete");
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.btnChange);
			resources.ApplyResources(this.panel4, "panel4");
			this.panel4.Name = "panel4";
			// 
			// btnChange
			// 
			resources.ApplyResources(this.btnChange, "btnChange");
			this.btnChange.Image = global::OSPC.Properties.Resources.EditCodeHS;
			this.btnChange.Name = "btnChange";
			this.btnChange.UseVisualStyleBackColor = true;
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// lblFamily
			// 
			this.lblFamily.BackColor = System.Drawing.Color.LightSteelBlue;
			resources.ApplyResources(this.lblFamily, "lblFamily");
			this.lblFamily.Name = "lblFamily";
			// 
			// btnSave
			// 
			this.btnSave.Image = global::OSPC.Properties.Resources.saveHS;
			resources.ApplyResources(this.btnSave, "btnSave");
			this.btnSave.Name = "btnSave";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lblTitle1
			// 
			this.lblTitle1.BackColor = System.Drawing.Color.Tan;
			resources.ApplyResources(this.lblTitle1, "lblTitle1");
			this.lblTitle1.Name = "lblTitle1";
			// 
			// inName
			// 
			this.inName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.inName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.inName.DropDownHeight = 300;
			resources.ApplyResources(this.inName, "inName");
			this.inName.Name = "inName";
			this.inName.SelectedIndexChanged += new System.EventHandler(this.inName_SelectedIndexChanged);
			this.inName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inName_KeyDown);
			// 
			// lblTitle0
			// 
			this.lblTitle0.BackColor = System.Drawing.Color.Tan;
			resources.ApplyResources(this.lblTitle0, "lblTitle0");
			this.lblTitle0.Name = "lblTitle0";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.gridTrans);
			this.panel5.Controls.Add(this.panel3);
			resources.ApplyResources(this.panel5, "panel5");
			this.panel5.Name = "panel5";
			// 
			// gridTrans
			// 
			this.gridTrans.AllowUserToAddRows = false;
			this.gridTrans.AllowUserToDeleteRows = false;
			this.gridTrans.AllowUserToResizeColumns = false;
			this.gridTrans.AllowUserToResizeRows = false;
			this.gridTrans.BackgroundColor = System.Drawing.SystemColors.Control;
			this.gridTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.gridTrans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			resources.ApplyResources(this.gridTrans, "gridTrans");
			this.gridTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.gridTrans.MultiSelect = false;
			this.gridTrans.Name = "gridTrans";
			this.gridTrans.ReadOnly = true;
			this.gridTrans.RowHeadersVisible = false;
			this.gridTrans.RowTemplate.Height = 23;
			this.gridTrans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTrans_CellClick);
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.btnPrint);
			this.panel3.Controls.Add(this.btnClose);
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.Name = "panel3";
			// 
			// btnPrint
			// 
			this.btnPrint.Image = global::OSPC.Properties.Resources.PrintPreviewHS;
			resources.ApplyResources(this.btnPrint, "btnPrint");
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnClose
			// 
			resources.ApplyResources(this.btnClose, "btnClose");
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Name = "btnClose";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Controls.Add(this.gridTotal);
			this.panel2.Controls.Add(this.inDate);
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			// 
			// gridTotal
			// 
			this.gridTotal.AllowUserToAddRows = false;
			this.gridTotal.AllowUserToDeleteRows = false;
			this.gridTotal.AllowUserToResizeColumns = false;
			this.gridTotal.AllowUserToResizeRows = false;
			this.gridTotal.BackgroundColor = System.Drawing.SystemColors.Control;
			this.gridTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.gridTotal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			resources.ApplyResources(this.gridTotal, "gridTotal");
			this.gridTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.gridTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Selected,
            this.gubun,
            this.title,
            this.total});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F);
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridTotal.DefaultCellStyle = dataGridViewCellStyle4;
			this.gridTotal.MultiSelect = false;
			this.gridTotal.Name = "gridTotal";
			this.gridTotal.ReadOnly = true;
			this.gridTotal.RowHeadersVisible = false;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.AliceBlue;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
			this.gridTotal.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.gridTotal.RowTemplate.Height = 23;
			this.gridTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridTotal.TabStop = false;
			this.gridTotal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTotal_CellClick);
			// 
			// ID
			// 
			resources.ApplyResources(this.ID, "ID");
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			// 
			// Selected
			// 
			resources.ApplyResources(this.Selected, "Selected");
			this.Selected.Name = "Selected";
			this.Selected.ReadOnly = true;
			// 
			// gubun
			// 
			resources.ApplyResources(this.gubun, "gubun");
			this.gubun.Name = "gubun";
			this.gubun.ReadOnly = true;
			// 
			// title
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.title.DefaultCellStyle = dataGridViewCellStyle2;
			resources.ApplyResources(this.title, "title");
			this.title.Name = "title";
			this.title.ReadOnly = true;
			this.title.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// total
			// 
			this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "C2";
			dataGridViewCellStyle3.NullValue = "0";
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.total.DefaultCellStyle = dataGridViewCellStyle3;
			resources.ApplyResources(this.total, "total");
			this.total.Name = "total";
			this.total.ReadOnly = true;
			this.total.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// inDate
			// 
			resources.ApplyResources(this.inDate, "inDate");
			this.inDate.BorderThickness = 2;
			this.inDate.ColorBack = System.Drawing.Color.WhiteSmoke;
			this.inDate.ColorBorder = System.Drawing.Color.RoyalBlue;
			this.inDate.ColorDays = System.Drawing.Color.Black;
			this.inDate.ColorSaturDay = System.Drawing.Color.SteelBlue;
			this.inDate.ColorSelectedBack = System.Drawing.Color.RoyalBlue;
			this.inDate.ColorSelectedFore = System.Drawing.Color.White;
			this.inDate.ColorSunDay = System.Drawing.Color.OrangeRed;
			this.inDate.ColorTodayBack = System.Drawing.Color.OrangeRed;
			this.inDate.ColorTodayFore = System.Drawing.Color.White;
			this.inDate.DateSelected = new System.DateTime(2013, 3, 29, 0, 0, 0, 0);
			this.inDate.DateSelectedString = "20130329";
			this.inDate.Name = "inDate";
			this.inDate.TabStop = false;
			this.inDate.NewDateSelected += new MultiBoxControls.MultiCalendar.DateSelectedEventHandler(this.inDate_NewDateSelected);
			// 
			// OSPCOffering
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.panel0);
			this.Name = "OSPCOffering";
			this.Activated += new System.EventHandler(this.OSPCOffering_Activated);
			this.panel0.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridTrans)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridTotal)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel0;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.Label lblFamily;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblTitle1;
		private System.Windows.Forms.ComboBox inName;
		private System.Windows.Forms.Label lblTitle0;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.DataGridView gridTrans;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel2;
		private MultiBoxControls.MultiCalendar inDate;
		private System.Windows.Forms.DataGridView gridTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
		private System.Windows.Forms.DataGridViewTextBoxColumn gubun;
		private System.Windows.Forms.DataGridViewTextBoxColumn title;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
	}
}