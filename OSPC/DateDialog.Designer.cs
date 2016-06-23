namespace OSPC {
	partial class DateDialog {
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
			this.inDate = new MultiBoxControls.GeneralTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// inDate
			// 
			this.inDate.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.MaskKoreaDate;
			this.inDate.BackColor = System.Drawing.Color.White;
			this.inDate.FocusBColor = System.Drawing.Color.Orange;
			this.inDate.FocusFColor = System.Drawing.Color.DarkBlue;
			this.inDate.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.inDate.ForeColor = System.Drawing.Color.Black;
			this.inDate.FormatString = "";
			this.inDate.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.inDate.Location = new System.Drawing.Point(180, 35);
			this.inDate.Mask = "0000-00-00";
			this.inDate.MaxLength = 10;
			this.inDate.Name = "inDate";
			this.inDate.Size = new System.Drawing.Size(85, 25);
			this.inDate.TabIndex = 0;
			this.inDate.Text = "0000-00-00";
			this.inDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.inDate.Value = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.DimGray;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(40, 35);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label1.Size = new System.Drawing.Size(130, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "날짜를 입력하세요";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Image = global::OSPC.Properties.Resources.PushpinHS;
			this.btnOK.Location = new System.Drawing.Point(70, 90);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 30);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "확인";
			this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::OSPC.Properties.Resources.Back;
			this.btnCancel.Location = new System.Drawing.Point(160, 90);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "취소";
			this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// DateDialog
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(307, 166);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.inDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DateDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Date";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MultiBoxControls.GeneralTextBox inDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}