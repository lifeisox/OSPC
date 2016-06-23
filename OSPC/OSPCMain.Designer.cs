namespace OSPC {
	partial class OSPCMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCMain));
			this.menuStrip = new System.Windows.Forms.ToolStrip();
			this.tsButtonPerson = new System.Windows.Forms.ToolStripButton();
			this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsButtonOffering = new System.Windows.Forms.ToolStripButton();
			this.tsButtonExpense = new System.Windows.Forms.ToolStripButton();
			this.tsButtonBankForm = new System.Windows.Forms.ToolStripButton();
			this.tsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsButtonCheck = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsButtonPrint = new System.Windows.Forms.ToolStripSplitButton();
			this.Report01 = new System.Windows.Forms.ToolStripMenuItem();
			this.Report02 = new System.Windows.Forms.ToolStripMenuItem();
			this.Report03 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Report11 = new System.Windows.Forms.ToolStripMenuItem();
			this.Report12 = new System.Windows.Forms.ToolStripMenuItem();
			this.Report13 = new System.Windows.Forms.ToolStripMenuItem();
			this.Report14 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.Report91 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.Report81 = new System.Windows.Forms.ToolStripMenuItem();
			this.Report82 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsButtonBooks = new System.Windows.Forms.ToolStripSplitButton();
			this.BookOfCash = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.BookOfOffering1 = new System.Windows.Forms.ToolStripMenuItem();
			this.BookOfOffering2 = new System.Windows.Forms.ToolStripMenuItem();
			this.BookOfOffering3 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsButtonClose = new System.Windows.Forms.ToolStripButton();
			this.tsSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsButtonConfigure = new System.Windows.Forms.ToolStripButton();
			this.tsSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsButtonBudgetTasks = new System.Windows.Forms.ToolStripSplitButton();
			this.InputBudget = new System.Windows.Forms.ToolStripMenuItem();
			this.GetResult = new System.Windows.Forms.ToolStripMenuItem();
			this.PrintResult = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.BackupDB = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(48, 52);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonPerson,
            this.tsSeparator1,
            this.tsButtonOffering,
            this.tsButtonExpense,
            this.tsButtonBankForm,
            this.tsSeparator2,
            this.tsButtonCheck,
            this.toolStripSeparator1,
            this.tsButtonPrint,
            this.tsButtonBooks,
            this.tsSeparator3,
            this.tsButtonClose,
            this.tsSeparator6,
            this.tsButtonConfigure,
            this.tsSeparator4,
            this.tsButtonBudgetTasks,
            this.tsSeparator5});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(0);
			this.menuStrip.Size = new System.Drawing.Size(966, 89);
			this.menuStrip.TabIndex = 4;
			// 
			// tsButtonPerson
			// 
			this.tsButtonPerson.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tsButtonPerson.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonPerson.Image")));
			this.tsButtonPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonPerson.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonPerson.Name = "tsButtonPerson";
			this.tsButtonPerson.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
			this.tsButtonPerson.Size = new System.Drawing.Size(69, 86);
			this.tsButtonPerson.Text = "교적등록";
			this.tsButtonPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonPerson.ToolTipText = "[교적등록] 교인을 추가하거나 변경합니다.";
			this.tsButtonPerson.Click += new System.EventHandler(this.tsButtonPerson_Click);
			// 
			// tsSeparator1
			// 
			this.tsSeparator1.Name = "tsSeparator1";
			this.tsSeparator1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
			this.tsSeparator1.Size = new System.Drawing.Size(6, 89);
			// 
			// tsButtonOffering
			// 
			this.tsButtonOffering.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonOffering.Image")));
			this.tsButtonOffering.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonOffering.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonOffering.Name = "tsButtonOffering";
			this.tsButtonOffering.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
			this.tsButtonOffering.Size = new System.Drawing.Size(69, 86);
			this.tsButtonOffering.Text = "헌금입력";
			this.tsButtonOffering.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonOffering.ToolTipText = "[헌금입력] 믿음으로 바친 헌금을 입력합니다.";
			this.tsButtonOffering.Click += new System.EventHandler(this.tsButtonOffering_Click);
			// 
			// tsButtonExpense
			// 
			this.tsButtonExpense.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonExpense.Image")));
			this.tsButtonExpense.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonExpense.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonExpense.Name = "tsButtonExpense";
			this.tsButtonExpense.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
			this.tsButtonExpense.Size = new System.Drawing.Size(69, 86);
			this.tsButtonExpense.Text = "수입지출";
			this.tsButtonExpense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonExpense.Click += new System.EventHandler(this.tsButtonExpense_Click);
			// 
			// tsButtonBankForm
			// 
			this.tsButtonBankForm.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonBankForm.Image")));
			this.tsButtonBankForm.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonBankForm.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonBankForm.Name = "tsButtonBankForm";
			this.tsButtonBankForm.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.tsButtonBankForm.Size = new System.Drawing.Size(66, 86);
			this.tsButtonBankForm.Text = "TD Bank";
			this.tsButtonBankForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonBankForm.Click += new System.EventHandler(this.tsButtonBankForm_Click);
			// 
			// tsSeparator2
			// 
			this.tsSeparator2.Name = "tsSeparator2";
			this.tsSeparator2.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
			this.tsSeparator2.Size = new System.Drawing.Size(6, 89);
			// 
			// tsButtonCheck
			// 
			this.tsButtonCheck.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonCheck.Image")));
			this.tsButtonCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonCheck.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.tsButtonCheck.Name = "tsButtonCheck";
			this.tsButtonCheck.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
			this.tsButtonCheck.Size = new System.Drawing.Size(69, 83);
			this.tsButtonCheck.Text = "지불완료";
			this.tsButtonCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsButtonCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonCheck.ToolTipText = "Cheque 지불완료 여부를 입력합니다.";
			this.tsButtonCheck.Click += new System.EventHandler(this.tsButtonCheck_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 89);
			// 
			// tsButtonPrint
			// 
			this.tsButtonPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Report01,
            this.Report02,
            this.Report03,
            this.toolStripSeparator2,
            this.Report11,
            this.Report12,
            this.Report13,
            this.Report14,
            this.toolStripSeparator3,
            this.Report91,
            this.toolStripSeparator5,
            this.Report81,
            this.Report82});
			this.tsButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonPrint.Image")));
			this.tsButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonPrint.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonPrint.Name = "tsButtonPrint";
			this.tsButtonPrint.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
			this.tsButtonPrint.Size = new System.Drawing.Size(81, 86);
			this.tsButtonPrint.Text = "자료인쇄";
			this.tsButtonPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonPrint.ToolTipText = "[금일헌금현황] 날짜를 입력하면 입력한 날짜의 헌금 현황을 보여줍니다.";
			this.tsButtonPrint.ButtonClick += new System.EventHandler(this.tsButtonPrint_ButtonClick);
			// 
			// Report01
			// 
			this.Report01.Image = global::OSPC.Properties.Resources.book_reportHS;
			this.Report01.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.Report01.Name = "Report01";
			this.Report01.Size = new System.Drawing.Size(210, 22);
			this.Report01.Text = "금일 헌금 현황";
			this.Report01.Click += new System.EventHandler(this.Report01_Click);
			// 
			// Report02
			// 
			this.Report02.Name = "Report02";
			this.Report02.Size = new System.Drawing.Size(210, 22);
			this.Report02.Text = "Bank Deposit Form";
			this.Report02.Click += new System.EventHandler(this.Report01_Click);
			// 
			// Report03
			// 
			this.Report03.Name = "Report03";
			this.Report03.Size = new System.Drawing.Size(210, 22);
			this.Report03.Text = "금일 헌금 및 지출 현황";
			this.Report03.Click += new System.EventHandler(this.Report01_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
			// 
			// Report11
			// 
			this.Report11.Image = global::OSPC.Properties.Resources.Book_angleHS;
			this.Report11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.Report11.Name = "Report11";
			this.Report11.Size = new System.Drawing.Size(210, 22);
			this.Report11.Text = "기간별 가구별 헌금 현황";
			this.Report11.Click += new System.EventHandler(this.Report01_Click);
			// 
			// Report12
			// 
			this.Report12.Name = "Report12";
			this.Report12.Size = new System.Drawing.Size(210, 22);
			this.Report12.Text = "가구별 년간 헌금 내역";
			this.Report12.Click += new System.EventHandler(this.Report01_Click);
			// 
			// Report13
			// 
			this.Report13.Name = "Report13";
			this.Report13.Size = new System.Drawing.Size(210, 22);
			this.Report13.Text = "반기 항목별 지출 현황";
			this.Report13.Click += new System.EventHandler(this.Report01_Click);
			// 
			// Report14
			// 
			this.Report14.Name = "Report14";
			this.Report14.Size = new System.Drawing.Size(210, 22);
			this.Report14.Text = "기간별 헌금 및 지출 현황";
			this.Report14.Click += new System.EventHandler(this.Report01_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
			// 
			// Report91
			// 
			this.Report91.Image = global::OSPC.Properties.Resources.PrintPreviewHS1;
			this.Report91.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Report91.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.Report91.Name = "Report91";
			this.Report91.Size = new System.Drawing.Size(210, 22);
			this.Report91.Text = "헌금 영수증";
			this.Report91.Click += new System.EventHandler(this.Report01_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(207, 6);
			// 
			// Report81
			// 
			this.Report81.Name = "Report81";
			this.Report81.Size = new System.Drawing.Size(210, 22);
			this.Report81.Text = "가족별 교인 대장";
			this.Report81.Click += new System.EventHandler(this.Report01_Click);
			// 
			// Report82
			// 
			this.Report82.Name = "Report82";
			this.Report82.Size = new System.Drawing.Size(210, 22);
			this.Report82.Text = "년간 생일자 목록";
			this.Report82.Click += new System.EventHandler(this.Report01_Click);
			// 
			// tsButtonBooks
			// 
			this.tsButtonBooks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BookOfCash,
            this.toolStripSeparator4,
            this.BookOfOffering1,
            this.BookOfOffering2,
            this.BookOfOffering3});
			this.tsButtonBooks.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonBooks.Image")));
			this.tsButtonBooks.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonBooks.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonBooks.Name = "tsButtonBooks";
			this.tsButtonBooks.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.tsButtonBooks.Size = new System.Drawing.Size(81, 86);
			this.tsButtonBooks.Text = "장부조회";
			this.tsButtonBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonBooks.ButtonClick += new System.EventHandler(this.tsButtonBooks_ButtonClick);
			// 
			// BookOfCash
			// 
			this.BookOfCash.Image = global::OSPC.Properties.Resources.book_addressHS;
			this.BookOfCash.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.BookOfCash.Name = "BookOfCash";
			this.BookOfCash.Size = new System.Drawing.Size(150, 22);
			this.BookOfCash.Text = "현금 출납장";
			this.BookOfCash.Click += new System.EventHandler(this.Report01_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
			// 
			// BookOfOffering1
			// 
			this.BookOfOffering1.Name = "BookOfOffering1";
			this.BookOfOffering1.Size = new System.Drawing.Size(150, 22);
			this.BookOfOffering1.Text = "건축헌금 대장";
			this.BookOfOffering1.Click += new System.EventHandler(this.Report01_Click);
			// 
			// BookOfOffering2
			// 
			this.BookOfOffering2.Name = "BookOfOffering2";
			this.BookOfOffering2.Size = new System.Drawing.Size(150, 22);
			this.BookOfOffering2.Text = "선교헌금 대장";
			this.BookOfOffering2.Click += new System.EventHandler(this.Report01_Click);
			// 
			// BookOfOffering3
			// 
			this.BookOfOffering3.Name = "BookOfOffering3";
			this.BookOfOffering3.Size = new System.Drawing.Size(150, 22);
			this.BookOfOffering3.Text = "구제헌금 대장";
			this.BookOfOffering3.Click += new System.EventHandler(this.Report01_Click);
			// 
			// tsSeparator3
			// 
			this.tsSeparator3.Name = "tsSeparator3";
			this.tsSeparator3.Size = new System.Drawing.Size(6, 89);
			// 
			// tsButtonClose
			// 
			this.tsButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonClose.Image")));
			this.tsButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonClose.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonClose.Name = "tsButtonClose";
			this.tsButtonClose.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.tsButtonClose.Size = new System.Drawing.Size(62, 86);
			this.tsButtonClose.Text = "종료";
			this.tsButtonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonClose.Click += new System.EventHandler(this.tsButtonClose_Click);
			// 
			// tsSeparator6
			// 
			this.tsSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSeparator6.Name = "tsSeparator6";
			this.tsSeparator6.Size = new System.Drawing.Size(6, 89);
			// 
			// tsButtonConfigure
			// 
			this.tsButtonConfigure.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsButtonConfigure.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonConfigure.Image")));
			this.tsButtonConfigure.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonConfigure.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonConfigure.Name = "tsButtonConfigure";
			this.tsButtonConfigure.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.tsButtonConfigure.Size = new System.Drawing.Size(69, 86);
			this.tsButtonConfigure.Text = "환경설정";
			this.tsButtonConfigure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonConfigure.Click += new System.EventHandler(this.tsButtonConfigure_Click);
			// 
			// tsSeparator4
			// 
			this.tsSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSeparator4.Name = "tsSeparator4";
			this.tsSeparator4.Size = new System.Drawing.Size(6, 89);
			// 
			// tsButtonBudgetTasks
			// 
			this.tsButtonBudgetTasks.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsButtonBudgetTasks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputBudget,
            this.GetResult,
            this.PrintResult,
            this.toolStripSeparator6,
            this.BackupDB});
			this.tsButtonBudgetTasks.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonBudgetTasks.Image")));
			this.tsButtonBudgetTasks.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsButtonBudgetTasks.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tsButtonBudgetTasks.Name = "tsButtonBudgetTasks";
			this.tsButtonBudgetTasks.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.tsButtonBudgetTasks.Size = new System.Drawing.Size(81, 86);
			this.tsButtonBudgetTasks.Text = "예산결산";
			this.tsButtonBudgetTasks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsButtonBudgetTasks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsButtonBudgetTasks.ButtonClick += new System.EventHandler(this.tsButtonBudgetTasks_ButtonClick);
			// 
			// InputBudget
			// 
			this.InputBudget.Image = global::OSPC.Properties.Resources.book_reportHS;
			this.InputBudget.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.InputBudget.Name = "InputBudget";
			this.InputBudget.Size = new System.Drawing.Size(210, 22);
			this.InputBudget.Text = "예산 입력";
			this.InputBudget.Click += new System.EventHandler(this.InputBudget_Click);
			// 
			// GetResult
			// 
			this.GetResult.Image = global::OSPC.Properties.Resources.GoToNextHS;
			this.GetResult.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.GetResult.Name = "GetResult";
			this.GetResult.Size = new System.Drawing.Size(210, 22);
			this.GetResult.Text = "결산자료 만들기";
			this.GetResult.Click += new System.EventHandler(this.GetResult_Click);
			// 
			// PrintResult
			// 
			this.PrintResult.Image = global::OSPC.Properties.Resources.PrintPreviewHS;
			this.PrintResult.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.PrintResult.Name = "PrintResult";
			this.PrintResult.Size = new System.Drawing.Size(210, 22);
			this.PrintResult.Text = "예산 및 결산 보고서 출력";
			this.PrintResult.Click += new System.EventHandler(this.Report01_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(207, 6);
			// 
			// BackupDB
			// 
			this.BackupDB.Name = "BackupDB";
			this.BackupDB.Size = new System.Drawing.Size(210, 22);
			this.BackupDB.Text = "서버로 데이터 전송";
			this.BackupDB.Click += new System.EventHandler(this.BackupDB_Click);
			// 
			// tsSeparator5
			// 
			this.tsSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSeparator5.Name = "tsSeparator5";
			this.tsSeparator5.Size = new System.Drawing.Size(6, 89);
			// 
			// statusLabel
			// 
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 4);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.statusLabel.Size = new System.Drawing.Size(931, 13);
			this.statusLabel.Spring = true;
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusLabelDate});
			this.statusStrip.Location = new System.Drawing.Point(0, 572);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusStrip.Size = new System.Drawing.Size(966, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.Stretch = false;
			this.statusStrip.TabIndex = 5;
			this.statusStrip.Text = "statusStrip1";
			// 
			// statusLabelDate
			// 
			this.statusLabelDate.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.statusLabelDate.Margin = new System.Windows.Forms.Padding(0, 5, 0, 4);
			this.statusLabelDate.Name = "statusLabelDate";
			this.statusLabelDate.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.statusLabelDate.Size = new System.Drawing.Size(20, 13);
			this.statusLabelDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// OSPCMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(966, 594);
			this.Controls.Add(this.menuStrip);
			this.Controls.Add(this.statusStrip);
			this.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "OSPCMain";
			this.Text = "오타와 사랑 장로교회";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip menuStrip;
		private System.Windows.Forms.ToolStripButton tsButtonPerson;
		private System.Windows.Forms.ToolStripSeparator tsSeparator1;
		private System.Windows.Forms.ToolStripButton tsButtonOffering;
		private System.Windows.Forms.ToolStripButton tsButtonExpense;
		private System.Windows.Forms.ToolStripButton tsButtonBankForm;
		private System.Windows.Forms.ToolStripSeparator tsSeparator2;
		private System.Windows.Forms.ToolStripSeparator tsSeparator3;
		private System.Windows.Forms.ToolStripButton tsButtonClose;
		private System.Windows.Forms.ToolStripSeparator tsSeparator6;
		private System.Windows.Forms.ToolStripButton tsButtonConfigure;
		private System.Windows.Forms.ToolStripSplitButton tsButtonBooks;
		private System.Windows.Forms.ToolStripSeparator tsSeparator5;
		private System.Windows.Forms.ToolStripSplitButton tsButtonBudgetTasks;
		private System.Windows.Forms.ToolStripSeparator tsSeparator4;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelDate;
		private System.Windows.Forms.ToolStripButton tsButtonCheck;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSplitButton tsButtonPrint;
		private System.Windows.Forms.ToolStripMenuItem Report01;
		private System.Windows.Forms.ToolStripMenuItem Report02;
		private System.Windows.Forms.ToolStripMenuItem Report03;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem Report11;
		private System.Windows.Forms.ToolStripMenuItem Report12;
		private System.Windows.Forms.ToolStripMenuItem Report13;
		private System.Windows.Forms.ToolStripMenuItem Report14;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem Report91;
		private System.Windows.Forms.ToolStripMenuItem BookOfCash;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem BookOfOffering1;
		private System.Windows.Forms.ToolStripMenuItem BookOfOffering2;
		private System.Windows.Forms.ToolStripMenuItem BookOfOffering3;
		private System.Windows.Forms.ToolStripMenuItem InputBudget;
		private System.Windows.Forms.ToolStripMenuItem GetResult;
		private System.Windows.Forms.ToolStripMenuItem PrintResult;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem Report81;
		private System.Windows.Forms.ToolStripMenuItem Report82;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem BackupDB;
	}
}