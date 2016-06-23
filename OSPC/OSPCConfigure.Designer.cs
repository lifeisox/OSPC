namespace OSPC {
	partial class OSPCConfigure {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSPCConfigure));
			this.panel0 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel0
			// 
			this.panel0.BackColor = System.Drawing.Color.Silver;
			this.panel0.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel0.Location = new System.Drawing.Point(148, 0);
			this.panel0.Name = "panel0";
			this.panel0.Size = new System.Drawing.Size(484, 383);
			this.panel0.TabIndex = 10;
			// 
			// btnClose
			// 
			this.btnClose.Image = global::OSPC.Properties.Resources.NavForward;
			this.btnClose.Location = new System.Drawing.Point(379, 16);
			this.btnClose.Margin = new System.Windows.Forms.Padding(20);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(80, 30);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "닫기";
			this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(148, 383);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(484, 63);
			this.panel1.TabIndex = 9;
			// 
			// tblPanel
			// 
			this.tblPanel.BackColor = System.Drawing.Color.DimGray;
			this.tblPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tblPanel.ColumnCount = 1;
			this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.tblPanel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tblPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tblPanel.Location = new System.Drawing.Point(0, 0);
			this.tblPanel.Margin = new System.Windows.Forms.Padding(0);
			this.tblPanel.Name = "tblPanel";
			this.tblPanel.RowCount = 9;
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tblPanel.Size = new System.Drawing.Size(148, 446);
			this.tblPanel.TabIndex = 8;
			// 
			// OSPCConfigure
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Controls.Add(this.panel0);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tblPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OSPCConfigure";
			this.Text = "기초 코드 등록";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel0;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tblPanel;
	}
}