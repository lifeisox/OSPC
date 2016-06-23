namespace OSPC {
	partial class OSPCCheque {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCCheque));
			this.panel1 = new System.Windows.Forms.Panel();
			this.gridTrans = new System.Windows.Forms.DataGridView();
			this.tr_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tr_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.gr_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_believer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_mok = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_cheque_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_cheque_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gr_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnChange = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTrans)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.panel1.Controls.Add(this.btnChange);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(621, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(20);
			this.panel1.Size = new System.Drawing.Size(158, 398);
			this.panel1.TabIndex = 0;
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
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTrans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridTrans.ColumnHeadersHeight = 25;
			this.gridTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.gridTrans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tr_date,
            this.tr_seq,
            this.gr_selected,
            this.gr_date,
            this.gr_believer,
            this.gr_hang,
            this.gr_mok,
            this.gr_amount,
            this.gr_cheque_no,
            this.gr_cheque_date,
            this.gr_remark});
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridTrans.DefaultCellStyle = dataGridViewCellStyle10;
			this.gridTrans.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridTrans.Location = new System.Drawing.Point(0, 0);
			this.gridTrans.Name = "gridTrans";
			this.gridTrans.ReadOnly = true;
			this.gridTrans.RowHeadersVisible = false;
			this.gridTrans.RowTemplate.Height = 23;
			this.gridTrans.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gridTrans.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.gridTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.gridTrans.ShowCellToolTips = false;
			this.gridTrans.Size = new System.Drawing.Size(621, 398);
			this.gridTrans.TabIndex = 0;
			this.gridTrans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTrans_CellClick);
			// 
			// tr_date
			// 
			this.tr_date.HeaderText = "tr_date";
			this.tr_date.Name = "tr_date";
			this.tr_date.ReadOnly = true;
			this.tr_date.Visible = false;
			// 
			// tr_seq
			// 
			this.tr_seq.HeaderText = "tr_seq";
			this.tr_seq.Name = "tr_seq";
			this.tr_seq.ReadOnly = true;
			this.tr_seq.Visible = false;
			// 
			// gr_selected
			// 
			this.gr_selected.HeaderText = "gr_selected";
			this.gr_selected.Name = "gr_selected";
			this.gr_selected.ReadOnly = true;
			this.gr_selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.gr_selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.gr_selected.Visible = false;
			// 
			// gr_date
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.gr_date.DefaultCellStyle = dataGridViewCellStyle2;
			this.gr_date.HeaderText = "날짜";
			this.gr_date.MaxInputLength = 10;
			this.gr_date.Name = "gr_date";
			this.gr_date.ReadOnly = true;
			this.gr_date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gr_date.Width = 80;
			// 
			// gr_believer
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.gr_believer.DefaultCellStyle = dataGridViewCellStyle3;
			this.gr_believer.HeaderText = "담당자";
			this.gr_believer.MaxInputLength = 20;
			this.gr_believer.Name = "gr_believer";
			this.gr_believer.ReadOnly = true;
			this.gr_believer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gr_believer.Width = 80;
			// 
			// gr_hang
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.gr_hang.DefaultCellStyle = dataGridViewCellStyle4;
			this.gr_hang.HeaderText = "계정항";
			this.gr_hang.MaxInputLength = 20;
			this.gr_hang.Name = "gr_hang";
			this.gr_hang.ReadOnly = true;
			this.gr_hang.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gr_hang.Width = 80;
			// 
			// gr_mok
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.gr_mok.DefaultCellStyle = dataGridViewCellStyle5;
			this.gr_mok.HeaderText = "계정목";
			this.gr_mok.Name = "gr_mok";
			this.gr_mok.ReadOnly = true;
			this.gr_mok.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// gr_amount
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "C2";
			dataGridViewCellStyle6.NullValue = null;
			dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.gr_amount.DefaultCellStyle = dataGridViewCellStyle6;
			this.gr_amount.HeaderText = "금액";
			this.gr_amount.Name = "gr_amount";
			this.gr_amount.ReadOnly = true;
			this.gr_amount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gr_amount.Width = 80;
			// 
			// gr_cheque_no
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.Format = "N0";
			dataGridViewCellStyle7.NullValue = null;
			this.gr_cheque_no.DefaultCellStyle = dataGridViewCellStyle7;
			this.gr_cheque_no.HeaderText = "체크번호";
			this.gr_cheque_no.MaxInputLength = 10;
			this.gr_cheque_no.Name = "gr_cheque_no";
			this.gr_cheque_no.ReadOnly = true;
			this.gr_cheque_no.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gr_cheque_no.Width = 80;
			// 
			// gr_cheque_date
			// 
			this.gr_cheque_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.gr_cheque_date.DefaultCellStyle = dataGridViewCellStyle8;
			this.gr_cheque_date.HeaderText = "결제일";
			this.gr_cheque_date.Name = "gr_cheque_date";
			this.gr_cheque_date.ReadOnly = true;
			this.gr_cheque_date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gr_cheque_date.Width = 80;
			// 
			// gr_remark
			// 
			this.gr_remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.gr_remark.DefaultCellStyle = dataGridViewCellStyle9;
			this.gr_remark.HeaderText = "비고";
			this.gr_remark.Name = "gr_remark";
			this.gr_remark.ReadOnly = true;
			// 
			// btnChange
			// 
			this.btnChange.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnChange.Image = global::OSPC.Properties.Resources.NewWindow;
			this.btnChange.Location = new System.Drawing.Point(20, 20);
			this.btnChange.Margin = new System.Windows.Forms.Padding(0);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(118, 30);
			this.btnChange.TabIndex = 3;
			this.btnChange.TabStop = false;
			this.btnChange.Text = "확인된체크로";
			this.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnChange.UseVisualStyleBackColor = true;
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Location = new System.Drawing.Point(20, 348);
			this.btnClose.Margin = new System.Windows.Forms.Padding(0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(118, 30);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "닫기";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Image = global::OSPC.Properties.Resources.saveHS;
			this.btnSave.Location = new System.Drawing.Point(20, 305);
			this.btnSave.Margin = new System.Windows.Forms.Padding(0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(118, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "저장";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// OSPCCheque
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(779, 398);
			this.Controls.Add(this.gridTrans);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OSPCCheque";
			this.Text = "Cheque 지불을 확인";
			this.Activated += new System.EventHandler(this.OSPCCheque_Activated);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridTrans)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView gridTrans;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.DataGridViewTextBoxColumn tr_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn tr_seq;
		private System.Windows.Forms.DataGridViewCheckBoxColumn gr_selected;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_believer;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_hang;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_mok;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_amount;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_cheque_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_cheque_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn gr_remark;
	}
}