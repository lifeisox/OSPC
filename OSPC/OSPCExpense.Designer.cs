namespace OSPC {
	partial class OSPCExpense {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCExpense));
			this.panel1 = new System.Windows.Forms.Panel();
			this.inRemark = new MultiBoxControls.GeneralTextBox();
			this.inCheqNo = new MultiBoxControls.GeneralTextBox();
			this.inAmount = new MultiBoxControls.GeneralTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.inIsCheq = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.inAccount = new System.Windows.Forms.ComboBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnChange = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.inName = new System.Windows.Forms.ComboBox();
			this.lblTitle0 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.gridTrans = new System.Windows.Forms.DataGridView();
			this.gridTotal = new System.Windows.Forms.DataGridView();
			this.inDate = new MultiBoxControls.MultiCalendar();
			this.panel0 = new System.Windows.Forms.Panel();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gubun = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTrans)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTotal)).BeginInit();
			this.panel0.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.PeachPuff;
			this.panel1.Controls.Add(this.inRemark);
			this.panel1.Controls.Add(this.inCheqNo);
			this.panel1.Controls.Add(this.inAmount);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.inIsCheq);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.inAccount);
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.inName);
			this.panel1.Controls.Add(this.lblTitle0);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(179, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(243, 504);
			this.panel1.TabIndex = 5;
			// 
			// inRemark
			// 
			this.inRemark.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.Normal;
			this.inRemark.BackColor = System.Drawing.Color.White;
			this.inRemark.FocusBColor = System.Drawing.Color.Orange;
			this.inRemark.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inRemark.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.inRemark.ForeColor = System.Drawing.Color.Black;
			this.inRemark.FormatString = "";
			this.inRemark.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.inRemark.Location = new System.Drawing.Point(115, 175);
			this.inRemark.Mask = "";
			this.inRemark.Name = "inRemark";
			this.inRemark.Size = new System.Drawing.Size(110, 25);
			this.inRemark.TabIndex = 5;
			this.inRemark.Value = "";
			this.inRemark.TextChanged += new System.EventHandler(this.inAmount_TextChanged);
			// 
			// inCheqNo
			// 
			this.inCheqNo.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmNumber;
			this.inCheqNo.BackColor = System.Drawing.Color.White;
			this.inCheqNo.FocusBColor = System.Drawing.Color.Orange;
			this.inCheqNo.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inCheqNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.inCheqNo.ForeColor = System.Drawing.Color.Black;
			this.inCheqNo.FormatString = "F0";
			this.inCheqNo.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inCheqNo.Location = new System.Drawing.Point(115, 111);
			this.inCheqNo.Mask = "";
			this.inCheqNo.MaxLength = 15;
			this.inCheqNo.Name = "inCheqNo";
			this.inCheqNo.Size = new System.Drawing.Size(110, 25);
			this.inCheqNo.TabIndex = 3;
			this.inCheqNo.Text = "0";
			this.inCheqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.inCheqNo.Value = "0";
			this.inCheqNo.TextChanged += new System.EventHandler(this.inAmount_TextChanged);
			this.inCheqNo.Validating += new System.ComponentModel.CancelEventHandler(this.inCheqNo_Validating);
			// 
			// inAmount
			// 
			this.inAmount.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollarCurrency;
			this.inAmount.BackColor = System.Drawing.Color.White;
			this.inAmount.FocusBColor = System.Drawing.Color.Orange;
			this.inAmount.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inAmount.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.inAmount.ForeColor = System.Drawing.Color.Black;
			this.inAmount.FormatString = "C2";
			this.inAmount.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inAmount.Location = new System.Drawing.Point(115, 79);
			this.inAmount.Mask = "";
			this.inAmount.MaxLength = 15;
			this.inAmount.Name = "inAmount";
			this.inAmount.Size = new System.Drawing.Size(110, 25);
			this.inAmount.TabIndex = 2;
			this.inAmount.Text = "$0.00";
			this.inAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.inAmount.Value = "0";
			this.inAmount.TextChanged += new System.EventHandler(this.inAmount_TextChanged);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Tan;
			this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label4.Location = new System.Drawing.Point(20, 175);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 25);
			this.label4.TabIndex = 101;
			this.label4.Text = "비고";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// inIsCheq
			// 
			this.inIsCheq.AutoSize = true;
			this.inIsCheq.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.inIsCheq.Location = new System.Drawing.Point(115, 143);
			this.inIsCheq.Name = "inIsCheq";
			this.inIsCheq.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
			this.inIsCheq.Size = new System.Drawing.Size(106, 25);
			this.inIsCheq.TabIndex = 4;
			this.inIsCheq.Text = "체크인가요?";
			this.inIsCheq.UseVisualStyleBackColor = true;
			this.inIsCheq.Click += new System.EventHandler(this.inIsCheq_Click);
			this.inIsCheq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inName_KeyDown);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Tan;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label3.Location = new System.Drawing.Point(20, 111);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 25);
			this.label3.TabIndex = 98;
			this.label3.Text = "Cheque #";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Tan;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label2.Location = new System.Drawing.Point(20, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 25);
			this.label2.TabIndex = 96;
			this.label2.Text = "금액";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// inAccount
			// 
			this.inAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.inAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.inAccount.DropDownHeight = 400;
			this.inAccount.DropDownWidth = 270;
			this.inAccount.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inAccount.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.inAccount.IntegralHeight = false;
			this.inAccount.ItemHeight = 17;
			this.inAccount.Location = new System.Drawing.Point(115, 47);
			this.inAccount.MaxDropDownItems = 20;
			this.inAccount.Name = "inAccount";
			this.inAccount.Size = new System.Drawing.Size(110, 25);
			this.inAccount.TabIndex = 1;
			this.inAccount.SelectedIndexChanged += new System.EventHandler(this.inAccount_SelectedIndexChanged);
			this.inAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inName_KeyDown);
			// 
			// btnDelete
			// 
			this.btnDelete.Image = global::OSPC.Properties.Resources.DeleteFolderHS;
			this.btnDelete.Location = new System.Drawing.Point(60, 220);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 30, 30, 30);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(80, 30);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "삭제";
			this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.btnChange);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 449);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(20, 11, 15, 10);
			this.panel4.Size = new System.Drawing.Size(243, 55);
			this.panel4.TabIndex = 93;
			// 
			// btnChange
			// 
			this.btnChange.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnChange.Image = global::OSPC.Properties.Resources.EditCodeHS;
			this.btnChange.Location = new System.Drawing.Point(20, 11);
			this.btnChange.Margin = new System.Windows.Forms.Padding(0);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(167, 30);
			this.btnChange.TabIndex = 8;
			this.btnChange.Text = " Change Edit Mode";
			this.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnChange.UseVisualStyleBackColor = true;
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// btnSave
			// 
			this.btnSave.Image = global::OSPC.Properties.Resources.saveHS;
			this.btnSave.Location = new System.Drawing.Point(146, 220);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 30, 30, 30);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 30);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "저장";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Tan;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label1.Location = new System.Drawing.Point(20, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 25);
			this.label1.TabIndex = 91;
			this.label1.Text = "계정과목";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// inName
			// 
			this.inName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.inName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.inName.DropDownHeight = 300;
			this.inName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.inName.IntegralHeight = false;
			this.inName.ItemHeight = 17;
			this.inName.Location = new System.Drawing.Point(115, 15);
			this.inName.Name = "inName";
			this.inName.Size = new System.Drawing.Size(110, 25);
			this.inName.TabIndex = 0;
			this.inName.SelectedIndexChanged += new System.EventHandler(this.inName_SelectedIndexChanged);
			this.inName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inName_KeyDown);
			// 
			// lblTitle0
			// 
			this.lblTitle0.BackColor = System.Drawing.Color.Tan;
			this.lblTitle0.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.lblTitle0.Location = new System.Drawing.Point(20, 15);
			this.lblTitle0.Name = "lblTitle0";
			this.lblTitle0.Size = new System.Drawing.Size(85, 25);
			this.lblTitle0.TabIndex = 2;
			this.lblTitle0.Text = "담당자";
			this.lblTitle0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.gridTrans);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(422, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(247, 504);
			this.panel2.TabIndex = 4;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.btnPrint);
			this.panel3.Controls.Add(this.btnClose);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 449);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(0, 11, 10, 10);
			this.panel3.Size = new System.Drawing.Size(247, 55);
			this.panel3.TabIndex = 6;
			// 
			// btnPrint
			// 
			this.btnPrint.Image = global::OSPC.Properties.Resources.PrintPreviewHS;
			this.btnPrint.Location = new System.Drawing.Point(65, 11);
			this.btnPrint.Margin = new System.Windows.Forms.Padding(30);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(80, 30);
			this.btnPrint.TabIndex = 2;
			this.btnPrint.Text = "인쇄";
			this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Location = new System.Drawing.Point(153, 11);
			this.btnClose.Margin = new System.Windows.Forms.Padding(20, 30, 30, 30);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(80, 30);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "닫기";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
			this.gridTrans.ColumnHeadersHeight = 25;
			this.gridTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.gridTrans.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridTrans.Location = new System.Drawing.Point(0, 0);
			this.gridTrans.MultiSelect = false;
			this.gridTrans.Name = "gridTrans";
			this.gridTrans.ReadOnly = true;
			this.gridTrans.RowHeadersVisible = false;
			this.gridTrans.RowTemplate.Height = 23;
			this.gridTrans.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.gridTrans.Size = new System.Drawing.Size(247, 504);
			this.gridTrans.TabIndex = 1;
			this.gridTrans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTrans_CellClick);
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
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridTotal.ColumnHeadersHeight = 25;
			this.gridTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.gridTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.gubun,
            this.Selected,
            this.title,
            this.total});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F);
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
			this.gridTotal.Size = new System.Drawing.Size(179, 334);
			this.gridTotal.TabIndex = 1;
			this.gridTotal.TabStop = false;
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
			this.inDate.TabIndex = 0;
			this.inDate.TabStop = false;
			this.inDate.NewDateSelected += new MultiBoxControls.MultiCalendar.DateSelectedEventHandler(this.inDate_NewDateSelected);
			// 
			// panel0
			// 
			this.panel0.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.panel0.Controls.Add(this.gridTotal);
			this.panel0.Controls.Add(this.inDate);
			this.panel0.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel0.Location = new System.Drawing.Point(0, 0);
			this.panel0.Name = "panel0";
			this.panel0.Size = new System.Drawing.Size(179, 504);
			this.panel0.TabIndex = 3;
			// 
			// ID
			// 
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			// 
			// gubun
			// 
			this.gubun.HeaderText = "gubun";
			this.gubun.Name = "gubun";
			this.gubun.ReadOnly = true;
			this.gubun.Visible = false;
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
			this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// OSPCExpense
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(669, 504);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel0);
			this.Controls.Add(this.panel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OSPCExpense";
			this.Text = "기타입금 및 비용 입력";
			this.Activated += new System.EventHandler(this.OSPCExpense_Activated);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridTrans)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTotal)).EndInit();
			this.panel0.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox inName;
		private System.Windows.Forms.Label lblTitle0;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView gridTrans;
		private System.Windows.Forms.DataGridView gridTotal;
		private MultiBoxControls.MultiCalendar inDate;
		private System.Windows.Forms.Panel panel0;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.ComboBox inAccount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox inIsCheq;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private MultiBoxControls.GeneralTextBox inCheqNo;
		private MultiBoxControls.GeneralTextBox inAmount;
		private MultiBoxControls.GeneralTextBox inRemark;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn gubun;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
		private System.Windows.Forms.DataGridViewTextBoxColumn title;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
	}
}