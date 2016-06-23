namespace OSPC {
	partial class OSPCReport {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCReport));
			this.panel0 = new System.Windows.Forms.Panel();
			this.inYear = new System.Windows.Forms.ComboBox();
			this.lblBasic = new System.Windows.Forms.Label();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel0.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel0
			// 
			this.panel0.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel0.Controls.Add(this.inYear);
			this.panel0.Controls.Add(this.lblBasic);
			this.panel0.Controls.Add(this.btnPrint);
			this.panel0.Controls.Add(this.btnClose);
			this.panel0.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel0.Location = new System.Drawing.Point(615, 0);
			this.panel0.Name = "panel0";
			this.panel0.Padding = new System.Windows.Forms.Padding(30, 20, 30, 30);
			this.panel0.Size = new System.Drawing.Size(170, 478);
			this.panel0.TabIndex = 0;
			// 
			// inYear
			// 
			this.inYear.DropDownHeight = 150;
			this.inYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inYear.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.inYear.FormattingEnabled = true;
			this.inYear.IntegralHeight = false;
			this.inYear.ItemHeight = 17;
			this.inYear.Location = new System.Drawing.Point(80, 15);
			this.inYear.MaxDropDownItems = 5;
			this.inYear.Name = "inYear";
			this.inYear.Size = new System.Drawing.Size(80, 25);
			this.inYear.TabIndex = 0;
			this.inYear.SelectedIndexChanged += new System.EventHandler(this.inYear_SelectedIndexChanged);
			// 
			// lblBasic
			// 
			this.lblBasic.BackColor = System.Drawing.Color.DimGray;
			this.lblBasic.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblBasic.ForeColor = System.Drawing.Color.White;
			this.lblBasic.Location = new System.Drawing.Point(15, 15);
			this.lblBasic.Name = "lblBasic";
			this.lblBasic.Size = new System.Drawing.Size(60, 25);
			this.lblBasic.TabIndex = 94;
			this.lblBasic.Text = "작업년도";
			this.lblBasic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnPrint
			// 
			this.btnPrint.Image = global::OSPC.Properties.Resources.PrintPreviewHS;
			this.btnPrint.Location = new System.Drawing.Point(30, 70);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(110, 30);
			this.btnPrint.TabIndex = 91;
			this.btnPrint.Text = "미리보기";
			this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Location = new System.Drawing.Point(30, 418);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(110, 30);
			this.btnClose.TabIndex = 92;
			this.btnClose.Text = "닫기";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(615, 478);
			this.panel1.TabIndex = 1;
			// 
			// OSPCReport
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(785, 478);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel0);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OSPCReport";
			this.ShowInTaskbar = false;
			this.Text = "OSPCReport";
			this.Activated += new System.EventHandler(this.OSPCReport_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OSPCReport_FormClosing);
			this.Load += new System.EventHandler(this.OSPCReport_Load);
			this.panel0.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel0;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.ComboBox inYear;
		private System.Windows.Forms.Label lblBasic;
		private System.Windows.Forms.Panel panel1;
	}
}