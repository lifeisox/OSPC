namespace OSPC {
	partial class OSPCDepositForm {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCDepositForm));
			this.panel0 = new System.Windows.Forms.Panel();
			this.gridTotal = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inDate = new MultiBoxControls.MultiCalendar();
			this.panel2 = new System.Windows.Forms.Panel();
			this.inTotal = new MultiBoxControls.GeneralTextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.inChequeTotal = new MultiBoxControls.GeneralTextBox();
			this.inCashTotal = new MultiBoxControls.GeneralTextBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl0 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel0.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTotal)).BeginInit();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel0
			// 
			this.panel0.Controls.Add(this.gridTotal);
			this.panel0.Controls.Add(this.inDate);
			this.panel0.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel0.Location = new System.Drawing.Point(0, 0);
			this.panel0.Name = "panel0";
			this.panel0.Size = new System.Drawing.Size(179, 416);
			this.panel0.TabIndex = 0;
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
			dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridTotal.ColumnHeadersHeight = 25;
			this.gridTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Selected,
            this.title,
            this.total});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridTotal.DefaultCellStyle = dataGridViewCellStyle4;
			this.gridTotal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridTotal.Location = new System.Drawing.Point(0, 170);
			this.gridTotal.Margin = new System.Windows.Forms.Padding(0);
			this.gridTotal.MultiSelect = false;
			this.gridTotal.Name = "gridTotal";
			this.gridTotal.ReadOnly = true;
			this.gridTotal.RowHeadersVisible = false;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.AliceBlue;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
			this.gridTotal.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.gridTotal.RowTemplate.Height = 23;
			this.gridTotal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.gridTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.gridTotal.Size = new System.Drawing.Size(179, 246);
			this.gridTotal.TabIndex = 2;
			this.gridTotal.TabStop = false;
			// 
			// ID
			// 
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			// 
			// Selected
			// 
			this.Selected.HeaderText = "선택";
			this.Selected.Name = "Selected";
			this.Selected.ReadOnly = true;
			this.Selected.Visible = false;
			// 
			// title
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.title.DefaultCellStyle = dataGridViewCellStyle2;
			this.title.HeaderText = "항목";
			this.title.Name = "title";
			this.title.ReadOnly = true;
			this.title.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.title.Width = 80;
			// 
			// total
			// 
			this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "C2";
			dataGridViewCellStyle3.NullValue = "0";
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.total.DefaultCellStyle = dataGridViewCellStyle3;
			this.total.HeaderText = "합계";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// inDate
			// 
			this.inDate.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.inDate.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.inDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.inDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
			this.inDate.Dock = System.Windows.Forms.DockStyle.Top;
			this.inDate.Font = new System.Drawing.Font("굴림", 9F);
			this.inDate.Location = new System.Drawing.Point(0, 0);
			this.inDate.Margin = new System.Windows.Forms.Padding(0);
			this.inDate.Name = "inDate";
			this.inDate.Size = new System.Drawing.Size(179, 170);
			this.inDate.TabIndex = 1;
			this.inDate.TabStop = false;
			this.inDate.NewDateSelected += new MultiBoxControls.MultiCalendar.DateSelectedEventHandler(this.inDate_NewDateSelected);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.inTotal);
			this.panel2.Controls.Add(this.tableLayoutPanel1);
			this.panel2.Controls.Add(this.inChequeTotal);
			this.panel2.Controls.Add(this.inCashTotal);
			this.panel2.Controls.Add(this.lblStatus);
			this.panel2.Controls.Add(this.label20);
			this.panel2.Controls.Add(this.label19);
			this.panel2.Controls.Add(this.label18);
			this.panel2.Controls.Add(this.label17);
			this.panel2.Controls.Add(this.label16);
			this.panel2.Controls.Add(this.label15);
			this.panel2.Controls.Add(this.label14);
			this.panel2.Controls.Add(this.label13);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.lbl0);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.panel2.Location = new System.Drawing.Point(179, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(511, 416);
			this.panel2.TabIndex = 500;
			// 
			// inTotal
			// 
			this.inTotal.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollarCurrency;
			this.inTotal.BackColor = System.Drawing.Color.DarkRed;
			this.inTotal.FocusBColor = System.Drawing.Color.Orange;
			this.inTotal.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inTotal.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inTotal.ForeColor = System.Drawing.Color.Orange;
			this.inTotal.FormatString = "C2";
			this.inTotal.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inTotal.Location = new System.Drawing.Point(390, 320);
			this.inTotal.Mask = "";
			this.inTotal.MaxLength = 15;
			this.inTotal.Name = "inTotal";
			this.inTotal.Size = new System.Drawing.Size(100, 25);
			this.inTotal.TabIndex = 102;
			this.inTotal.TabStop = false;
			this.inTotal.Text = "$0.00";
			this.inTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.inTotal.Value = "0";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.36735F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.61225F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.btnClose, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnPrint, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 360);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(511, 56);
			this.tableLayoutPanel1.TabIndex = 900;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Font = new System.Drawing.Font("굴림", 9F);
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Location = new System.Drawing.Point(408, 13);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 30);
			this.btnClose.TabIndex = 303;
			this.btnClose.Text = "닫기";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnPrint.Font = new System.Drawing.Font("굴림", 9F);
			this.btnPrint.Image = global::OSPC.Properties.Resources.PrintPreviewHS;
			this.btnPrint.Location = new System.Drawing.Point(283, 13);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(90, 30);
			this.btnPrint.TabIndex = 302;
			this.btnPrint.Text = "인쇄";
			this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnSave
			// 
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Font = new System.Drawing.Font("굴림", 9F);
			this.btnSave.Image = global::OSPC.Properties.Resources.saveHS;
			this.btnSave.Location = new System.Drawing.Point(159, 13);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 30);
			this.btnSave.TabIndex = 301;
			this.btnSave.Text = "저장";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// inChequeTotal
			// 
			this.inChequeTotal.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollarCurrency;
			this.inChequeTotal.BackColor = System.Drawing.Color.RoyalBlue;
			this.inChequeTotal.FocusBColor = System.Drawing.Color.Orange;
			this.inChequeTotal.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inChequeTotal.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inChequeTotal.ForeColor = System.Drawing.Color.Orange;
			this.inChequeTotal.FormatString = "C2";
			this.inChequeTotal.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inChequeTotal.Location = new System.Drawing.Point(390, 290);
			this.inChequeTotal.Mask = "";
			this.inChequeTotal.MaxLength = 15;
			this.inChequeTotal.Name = "inChequeTotal";
			this.inChequeTotal.Size = new System.Drawing.Size(100, 25);
			this.inChequeTotal.TabIndex = 101;
			this.inChequeTotal.TabStop = false;
			this.inChequeTotal.Text = "$0.00";
			this.inChequeTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.inChequeTotal.Value = "0";
			// 
			// inCashTotal
			// 
			this.inCashTotal.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollarCurrency;
			this.inCashTotal.BackColor = System.Drawing.Color.RoyalBlue;
			this.inCashTotal.FocusBColor = System.Drawing.Color.Orange;
			this.inCashTotal.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inCashTotal.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inCashTotal.ForeColor = System.Drawing.Color.Orange;
			this.inCashTotal.FormatString = "C2";
			this.inCashTotal.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inCashTotal.Location = new System.Drawing.Point(390, 260);
			this.inCashTotal.Mask = "";
			this.inCashTotal.MaxLength = 15;
			this.inCashTotal.Name = "inCashTotal";
			this.inCashTotal.Size = new System.Drawing.Size(100, 25);
			this.inCashTotal.TabIndex = 100;
			this.inCashTotal.TabStop = false;
			this.inCashTotal.Text = "$0.00";
			this.inCashTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.inCashTotal.Value = "0";
			// 
			// lblStatus
			// 
			this.lblStatus.BackColor = System.Drawing.Color.Goldenrod;
			this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStatus.ForeColor = System.Drawing.Color.Maroon;
			this.lblStatus.Location = new System.Drawing.Point(20, 320);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(250, 25);
			this.lblStatus.TabIndex = 121;
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label20
			// 
			this.label20.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label20.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.label20.ForeColor = System.Drawing.Color.White;
			this.label20.Location = new System.Drawing.Point(290, 320);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(90, 25);
			this.label20.TabIndex = 162;
			this.label20.Text = "TOTAL ";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label19
			// 
			this.label19.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label19.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.label19.ForeColor = System.Drawing.Color.White;
			this.label19.Location = new System.Drawing.Point(290, 290);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(90, 25);
			this.label19.TabIndex = 161;
			this.label19.Text = "CHEQUE ";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label18.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(290, 260);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(90, 25);
			this.label18.TabIndex = 160;
			this.label18.Text = "CASH ";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label17.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label17.ForeColor = System.Drawing.Color.White;
			this.label17.Location = new System.Drawing.Point(290, 225);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(90, 25);
			this.label17.TabIndex = 129;
			this.label17.Text = "Coins ";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label16.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label16.ForeColor = System.Drawing.Color.White;
			this.label16.Location = new System.Drawing.Point(290, 195);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(90, 25);
			this.label16.TabIndex = 128;
			this.label16.Text = "$1 Coin × ";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label15.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label15.ForeColor = System.Drawing.Color.White;
			this.label15.Location = new System.Drawing.Point(290, 165);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(90, 25);
			this.label15.TabIndex = 127;
			this.label15.Text = "$2 Coin × ";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label14.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label14.ForeColor = System.Drawing.Color.White;
			this.label14.Location = new System.Drawing.Point(290, 135);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(90, 25);
			this.label14.TabIndex = 126;
			this.label14.Text = "$5 × ";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label13.ForeColor = System.Drawing.Color.White;
			this.label13.Location = new System.Drawing.Point(290, 105);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(90, 25);
			this.label13.TabIndex = 125;
			this.label13.Text = "$10 × ";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(290, 75);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(90, 25);
			this.label12.TabIndex = 124;
			this.label12.Text = "$20 × ";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label11.ForeColor = System.Drawing.Color.White;
			this.label11.Location = new System.Drawing.Point(290, 45);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(90, 25);
			this.label11.TabIndex = 123;
			this.label11.Text = "$50 × ";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label10.ForeColor = System.Drawing.Color.White;
			this.label10.Location = new System.Drawing.Point(290, 15);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(90, 25);
			this.label10.TabIndex = 122;
			this.label10.Text = "$100 × ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(20, 285);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(90, 25);
			this.label9.TabIndex = 120;
			this.label9.Text = "CHEQUE 10 ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label8.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(20, 255);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 25);
			this.label8.TabIndex = 119;
			this.label8.Text = "CHEQUE 09 ";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(20, 225);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 25);
			this.label7.TabIndex = 118;
			this.label7.Text = "CHEQUE 08 ";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(20, 195);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 25);
			this.label6.TabIndex = 117;
			this.label6.Text = "CHEQUE 07 ";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(20, 165);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 25);
			this.label5.TabIndex = 116;
			this.label5.Text = "CHEQUE 06 ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(20, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 25);
			this.label4.TabIndex = 115;
			this.label4.Text = "CHEQUE 05 ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(20, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 25);
			this.label3.TabIndex = 114;
			this.label3.Text = "CHEQUE 04 ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(20, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 25);
			this.label2.TabIndex = 113;
			this.label2.Text = "CHEQUE 03 ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(20, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 25);
			this.label1.TabIndex = 112;
			this.label1.Text = "CHEQUE 02 ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl0
			// 
			this.lbl0.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbl0.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.lbl0.ForeColor = System.Drawing.Color.White;
			this.lbl0.Location = new System.Drawing.Point(20, 15);
			this.lbl0.Name = "lbl0";
			this.lbl0.Size = new System.Drawing.Size(90, 25);
			this.lbl0.TabIndex = 111;
			this.lbl0.Text = "CHEQUE 01 ";
			this.lbl0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(690, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(0, 416);
			this.panel1.TabIndex = 53;
			// 
			// OSPCDepositForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(690, 416);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel0);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OSPCDepositForm";
			this.Text = "Bank Deposit Form";
			this.panel0.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridTotal)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel0;
		private System.Windows.Forms.Panel panel2;
		private MultiBoxControls.MultiCalendar inDate;
		private System.Windows.Forms.DataGridView gridTotal;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl0;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
		private System.Windows.Forms.DataGridViewTextBoxColumn title;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.Panel panel1;
		private MultiBoxControls.GeneralTextBox inTotal;
		private MultiBoxControls.GeneralTextBox inChequeTotal;
		private MultiBoxControls.GeneralTextBox inCashTotal;
	}
}