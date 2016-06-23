namespace OSPC {
	partial class OSPCBackup {
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
			this.btnBasic = new System.Windows.Forms.Button();
			this.inYear = new MultiBoxControls.GeneralTextBox();
			this.inDate = new MultiBoxControls.GeneralTextBox();
			this.btnYear = new System.Windows.Forms.Button();
			this.btnDate = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.proBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// btnBasic
			// 
			this.btnBasic.Location = new System.Drawing.Point(70, 30);
			this.btnBasic.Name = "btnBasic";
			this.btnBasic.Size = new System.Drawing.Size(220, 30);
			this.btnBasic.TabIndex = 0;
			this.btnBasic.Text = "기초자료 서버로 복사";
			this.btnBasic.UseVisualStyleBackColor = true;
			this.btnBasic.Click += new System.EventHandler(this.btnBasic_Click);
			// 
			// inYear
			// 
			this.inYear.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.Mask4Num;
			this.inYear.BackColor = System.Drawing.Color.White;
			this.inYear.FocusBColor = System.Drawing.Color.Orange;
			this.inYear.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inYear.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inYear.ForeColor = System.Drawing.Color.Black;
			this.inYear.FormatString = "";
			this.inYear.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inYear.Location = new System.Drawing.Point(70, 95);
			this.inYear.Mask = "0000";
			this.inYear.MaxLength = 4;
			this.inYear.Name = "inYear";
			this.inYear.Size = new System.Drawing.Size(100, 29);
			this.inYear.TabIndex = 1;
			this.inYear.Text = "0000";
			this.inYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.inYear.Value = "";
			// 
			// inDate
			// 
			this.inDate.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.MaskKoreaDate;
			this.inDate.BackColor = System.Drawing.Color.White;
			this.inDate.FocusBColor = System.Drawing.Color.Orange;
			this.inDate.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.inDate.ForeColor = System.Drawing.Color.Black;
			this.inDate.FormatString = "";
			this.inDate.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inDate.Location = new System.Drawing.Point(70, 145);
			this.inDate.Mask = "0000-00-00";
			this.inDate.MaxLength = 10;
			this.inDate.Name = "inDate";
			this.inDate.Size = new System.Drawing.Size(100, 29);
			this.inDate.TabIndex = 3;
			this.inDate.Text = "0000-00-00";
			this.inDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.inDate.Value = "";
			// 
			// btnYear
			// 
			this.btnYear.Location = new System.Drawing.Point(190, 95);
			this.btnYear.Name = "btnYear";
			this.btnYear.Size = new System.Drawing.Size(95, 29);
			this.btnYear.TabIndex = 2;
			this.btnYear.Text = "년 복사 실행";
			this.btnYear.UseVisualStyleBackColor = true;
			this.btnYear.Click += new System.EventHandler(this.btnYear_Click);
			// 
			// btnDate
			// 
			this.btnDate.Location = new System.Drawing.Point(190, 145);
			this.btnDate.Name = "btnDate";
			this.btnDate.Size = new System.Drawing.Size(95, 29);
			this.btnDate.TabIndex = 4;
			this.btnDate.Text = "일 복사 실행";
			this.btnDate.UseVisualStyleBackColor = true;
			this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
			// 
			// btnClose
			// 
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Location = new System.Drawing.Point(130, 215);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(95, 30);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "닫기";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// proBar
			// 
			this.proBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.proBar.Location = new System.Drawing.Point(0, 276);
			this.proBar.Maximum = 7;
			this.proBar.Name = "proBar";
			this.proBar.Size = new System.Drawing.Size(356, 23);
			this.proBar.Step = 7;
			this.proBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.proBar.TabIndex = 6;
			// 
			// OSPCBackup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 299);
			this.Controls.Add(this.proBar);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDate);
			this.Controls.Add(this.btnYear);
			this.Controls.Add(this.inDate);
			this.Controls.Add(this.inYear);
			this.Controls.Add(this.btnBasic);
			this.Name = "OSPCBackup";
			this.Text = "서버로 데이터 전송";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBasic;
		private MultiBoxControls.GeneralTextBox inYear;
		private MultiBoxControls.GeneralTextBox inDate;
		private System.Windows.Forms.Button btnYear;
		private System.Windows.Forms.Button btnDate;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ProgressBar proBar;
	}
}