using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OSPC {

	public partial class OSPCConfigure : Form {
		private const int MAX_MENU = 8;
		private DataGridView dataGrid = new DataGridView ();
		private DataGridView subGrid = new DataGridView ();
		private Label[] lblButtons = new Label[MAX_MENU];	// 메뉴Label을 배열로 잡는다.
		private Button submitSave = null;
		private Color saveForeColor, saveBackColor;
		private int saveMenu = 999; //999는 처음 로드되었다는 스위치
		private bool showSaveButton = false;

		private OSPCModules mesg = new OSPCModules ();

		private BindingSource mainBinding = new BindingSource ();
		private BindingSource subBinding = new BindingSource ();
		private OSPCDataSet ospcDataSet = new OSPCDataSet ();
		private OSPCDataSetTableAdapters.mailserversTableAdapter mailserversAdapter = new OSPCDataSetTableAdapters.mailserversTableAdapter ();
		private OSPCDataSetTableAdapters.familyTableAdapter familyAdapter = new OSPCDataSetTableAdapters.familyTableAdapter ();
		private OSPCDataSetTableAdapters.dutiesTableAdapter dutiesAdapter = new OSPCDataSetTableAdapters.dutiesTableAdapter ();
		private OSPCDataSetTableAdapters.hang_titleTableAdapter hang_titleAdapter = new OSPCDataSetTableAdapters.hang_titleTableAdapter ();
		private OSPCDataSetTableAdapters.mok_titleTableAdapter mok_titleAdapter = new OSPCDataSetTableAdapters.mok_titleTableAdapter ();
		private OSPCDataSetTableAdapters.TableAdapterManager tableManager = new OSPCDataSetTableAdapters.TableAdapterManager ();
		private int mHangCode, mGubun;

		//----- Constructor
		public OSPCConfigure () {
			InitializeComponent ();
			// TableManager 초기화
			tableManager.familyTableAdapter = familyAdapter;
			tableManager.dutiesTableAdapter = dutiesAdapter;
			tableManager.hang_titleTableAdapter = hang_titleAdapter;
			tableManager.mok_titleTableAdapter = mok_titleAdapter;
			tableManager.mailserversTableAdapter = mailserversAdapter;

			dataGrid.Visible = false;
			dataGrid.AllowUserToResizeColumns = false;
			dataGrid.AllowUserToResizeRows = false;
			dataGrid.AutoGenerateColumns = true;
			dataGrid.BackgroundColor = Color.OldLace;
			dataGrid.BorderStyle = BorderStyle.Fixed3D;
			dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			dataGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font ( "맑은 고딕", 9 );
			dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGrid.ColumnHeadersHeight = 25;
			dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			dataGrid.DefaultCellStyle.Font = new System.Drawing.Font ( "맑은 고딕", 9 );
			dataGrid.DefaultCellStyle.SelectionBackColor = Color.PeachPuff;
			dataGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
			dataGrid.Dock = DockStyle.Fill;
			dataGrid.EditMode = DataGridViewEditMode.EditOnKeystroke;
			dataGrid.MultiSelect = false;
			dataGrid.RowHeadersVisible = true;
			dataGrid.RowHeadersWidth = 30;
			dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGrid.CellValidating += new DataGridViewCellValidatingEventHandler ( dataGrid_CellValidating );
			dataGrid.CellValueChanged += new DataGridViewCellEventHandler ( dataGrid_CellValueChanged );
			dataGrid.UserDeletedRow += new DataGridViewRowEventHandler ( dataGrid_UserDeletedRow );
			dataGrid.CellClick += new DataGridViewCellEventHandler ( dataGrid_CellClick );
			panel0.Controls.Add ( dataGrid );

			subGrid.Visible = false;
			subGrid.AllowUserToResizeColumns = false;
			subGrid.AllowUserToResizeRows = false;
			subGrid.AutoGenerateColumns = true;
			subGrid.BackgroundColor = Color.OldLace;
			subGrid.BorderStyle = BorderStyle.Fixed3D;
			subGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			subGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			subGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font ( "맑은 고딕", 9 );
			subGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			subGrid.ColumnHeadersHeight = 25;
			subGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			subGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			subGrid.DefaultCellStyle.Font = new System.Drawing.Font ( "맑은 고딕", 9 );
			subGrid.DefaultCellStyle.SelectionBackColor = Color.PeachPuff;
			subGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
			subGrid.Dock = DockStyle.Right;
			subGrid.EditMode = DataGridViewEditMode.EditOnKeystroke;
			subGrid.MultiSelect = false;
			subGrid.RowHeadersWidth = 30;
			subGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			panel0.Controls.Add ( subGrid );
			subGrid.CellValidating += new DataGridViewCellValidatingEventHandler ( subGrid_CellValidating );
			subGrid.UserDeletedRow += new DataGridViewRowEventHandler ( subGrid_UserDeletedRow );
			subGrid.CellValueChanged += new DataGridViewCellEventHandler ( subGrid_CellValueChanged );

			for ( int i = 0; i < MAX_MENU; i++ ) {
				//메뉴를 만든다.
				lblButtons[i] = new Label ();
				//lblButtons[i].Parent = tblPanel;
				lblButtons[i].MouseEnter += new EventHandler ( lblButtons_MouseEnter );
				lblButtons[i].MouseLeave += new EventHandler ( lblButtons_MouseLeave );
				lblButtons[i].Click += new EventHandler ( lblButtons_Click );
				lblButtons[i].Tag = i;
				lblButtons[i].AutoSize = false;
				lblButtons[i].BackColor = Color.WhiteSmoke;
				lblButtons[i].ForeColor = Color.Black;
				lblButtons[i].Dock = DockStyle.Fill;
				lblButtons[i].Margin = new Padding ( 0 );
				lblButtons[i].TabIndex = i;
				lblButtons[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				switch ( i ) {
					case 0: lblButtons[i].Text = "이메일 도메인 주소"; break;
					case 1: lblButtons[i].Text = "가족 관계"; break;
					case 2: lblButtons[i].Text = "직분"; break;
					case 3: lblButtons[i].Text = "계정과목 (항)"; break;
					case 4: lblButtons[i].Text = "계정과목 (목)"; break;
					case 5: lblButtons[i].Text = "장부계정 등록"; break;
					case 6: lblButtons[i].Text = ""; break;
					default: lblButtons[i].Text = ""; break;
				}
				tblPanel.Controls.Add ( lblButtons[i] );
			}
		}
		//-------------------------------------------------------------------- Events
		private void lblButtons_Click ( object sender, EventArgs e ) {
			int index = (int) ( (Label) sender ).Tag;
			if ( saveMenu == index ) return;
			if ( saveMenu != 999 ) {
				if ( SaveTable () ) {
					showSaveButton = false;
					dataGrid.Columns.Clear ();
					subGrid.Columns.Clear (); 
					subGrid.Visible = false;
					lblButtons[saveMenu].BackColor = Color.WhiteSmoke;
					lblButtons[saveMenu].ForeColor = Color.Black;
				} else return;
			}
			mesg.MessageON ( this, "자료를 읽는 중이니 잠시 기다리세요." );
			showSaveButton = false;
			lblButtons[index].BackColor = Color.Tomato;
			lblButtons[index].ForeColor = Color.White;
			saveBackColor = lblButtons[index].BackColor;
			saveForeColor = lblButtons[index].ForeColor;
			saveMenu = index;
			switch ( index ) {
				case 0: // 이메일 도메인 주소
					dataGrid.AllowUserToAddRows = true;
					dataGrid.AllowUserToDeleteRows = true;
					mainBinding.DataSource = ospcDataSet.mailservers;
					mainBinding.ResetBindings ( true );
					mailserversAdapter.ClearBeforeFill = true;
					mailserversAdapter.Fill ( ospcDataSet.mailservers );
					dataGrid.DataSource = mainBinding;
					dataGrid.Columns["ID"].Visible = false;
					dataGrid.Columns["servername"].HeaderText = "E-MAIL Server Name";
					dataGrid.Columns["servername"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					dataGrid.Columns["servername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					dataGrid.Columns["servername"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["servername"].SortMode = DataGridViewColumnSortMode.Automatic;
					dataGrid.Visible = true;
					break;
				case 1:
					dataGrid.AllowUserToAddRows = true;
					dataGrid.AllowUserToDeleteRows = true;
					mainBinding.DataSource = ospcDataSet.family;
					mainBinding.ResetBindings ( true );
					familyAdapter.ClearBeforeFill = true;
					familyAdapter.Fill ( ospcDataSet.family );
					dataGrid.DataSource = mainBinding;
					dataGrid.Columns["ID"].Visible = false;
					dataGrid.Columns["relation"].HeaderText = "관계명";
					dataGrid.Columns["relation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					dataGrid.Columns["relation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					dataGrid.Columns["relation"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["relation"].SortMode = DataGridViewColumnSortMode.Automatic;
					dataGrid.Visible = true;
					break;
				case 2:
					dataGrid.AllowUserToAddRows = true;
					dataGrid.AllowUserToDeleteRows = true;
					mainBinding.DataSource = ospcDataSet.duties;
					mainBinding.ResetBindings ( true );
					dutiesAdapter.Fill ( ospcDataSet.duties );
					dataGrid.DataSource = mainBinding;
					dataGrid.Columns["ID"].Visible = false;
					dataGrid.Columns["duty"].HeaderText = "직분명";
					dataGrid.Columns["duty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					dataGrid.Columns["duty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					dataGrid.Columns["duty"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["duty"].SortMode = DataGridViewColumnSortMode.Automatic;
					dataGrid.Visible = true;
					break;
				case 3:
					dataGrid.AllowUserToAddRows = true;
					dataGrid.AllowUserToDeleteRows = true;
					mainBinding.DataSource = ospcDataSet.hang_title;
					mainBinding.ResetBindings ( true );
					hang_titleAdapter.Fill ( ospcDataSet.hang_title );
					dataGrid.DataSource = mainBinding;
					dataGrid.Columns["ID"].Visible = false;
					dataGrid.Columns["gubun"].HeaderText = "구분";
					dataGrid.Columns["gubun"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					dataGrid.Columns["gubun"].Width = 100;
					dataGrid.Columns["gubun"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGrid.Columns["gubun"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["gubun"].ValueType = typeof ( Int32 );
					dataGrid.Columns["hang"].HeaderText = "항";
					dataGrid.Columns["hang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					dataGrid.Columns["hang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					dataGrid.Columns["hang"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["hang"].SortMode = DataGridViewColumnSortMode.Automatic;
					dataGrid.Visible = true;
					break;
				case 4:
					dataGrid.AllowUserToAddRows = false;
					dataGrid.AllowUserToDeleteRows = false;
					dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
					dataGrid.ReadOnly = true;
					dataGrid.Dock = DockStyle.Fill;
					mainBinding.DataSource = ospcDataSet.hang_title;
					mainBinding.ResetBindings ( true );
					hang_titleAdapter.ClearBeforeFill = true;
					hang_titleAdapter.Fill ( ospcDataSet.hang_title );
					dataGrid.DataSource = mainBinding;
					dataGrid.Columns["ID"].Visible = false;
					dataGrid.Columns["gubun"].HeaderText = "구분";
					dataGrid.Columns["gubun"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					dataGrid.Columns["gubun"].Width = 60;
					dataGrid.Columns["gubun"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGrid.Columns["gubun"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["gubun"].ValueType = typeof ( Int32 );
					dataGrid.Columns["hang"].HeaderText = "항";
					dataGrid.Columns["hang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					dataGrid.Columns["hang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					dataGrid.Columns["hang"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["hang"].SortMode = DataGridViewColumnSortMode.Automatic;
					dataGrid.Visible = true;
					// 서브 그리드를 그림
					subGrid.Visible = true;
					break;
				case 5:
					dataGrid.AllowUserToAddRows = false;
					dataGrid.AllowUserToDeleteRows = false;
					dataGrid.ReadOnly = false;
					mainBinding.DataSource = ospcDataSet.mok_title;
					mainBinding.ResetBindings ( true );
					mok_titleAdapter.Fill ( ospcDataSet.mok_title );
					dataGrid.DataSource = mainBinding;
					dataGrid.Columns["ID"].Visible = false;
					dataGrid.Columns["hang_code"].Visible = false;
					dataGrid.Columns["gubun"].Visible = false;
					dataGrid.Columns["mok"].HeaderText = "계정명";
					dataGrid.Columns["mok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					dataGrid.Columns["mok"].Width = 150;
					dataGrid.Columns["mok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
					dataGrid.Columns["mok"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
					dataGrid.Columns["mok"].ReadOnly = true;
					dataGrid.Columns["fund_building"].HeaderText = "건축헌금";
					dataGrid.Columns["fund_building"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					dataGrid.Columns["fund_building"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGrid.Columns["fund_gospel"].HeaderText = "선교헌금";
					dataGrid.Columns["fund_gospel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					dataGrid.Columns["fund_gospel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGrid.Columns["fund_help"].HeaderText = "구제헌금";
					dataGrid.Columns["fund_help"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					dataGrid.Columns["fund_help"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGrid.Visible = true;
					break;
				case 6:
				default: break;
			}
			dataGrid.Enabled = true;
			dataGrid.Focus ();
			if ( index != 4 ) showSaveButton = true;
			mesg.MessageOFF ( this );
		}
		private void lblButtons_MouseEnter ( object sender, EventArgs e ) {
			int index = (int) ( (Label) sender ).Tag;
			saveBackColor = lblButtons[index].BackColor;
			saveForeColor = lblButtons[index].ForeColor;
			lblButtons[index].BackColor = Color.RoyalBlue;
			lblButtons[index].ForeColor = Color.WhiteSmoke;
		}
		private void lblButtons_MouseLeave ( object sender, EventArgs e ) {
			int index = (int) ( (Label) sender ).Tag;
			lblButtons[index].BackColor = saveBackColor;
			lblButtons[index].ForeColor = saveForeColor;
		}
		private void submitSave_Click ( object sender, EventArgs e ) {
			SaveTable ( 1 );
		}
		private void btnClose_Click ( object sender, EventArgs e ) {
			if ( SaveTable () ) this.Close ();
		}
		private void dataGrid_CellValidating ( object sender, DataGridViewCellValidatingEventArgs e ) {
			if ( dataGrid.Rows[e.RowIndex].IsNewRow ) { return; }
			if ( saveMenu == 3 ) {
				if ( e.ColumnIndex == 1 ) {
					int newInteger;
					if ( !int.TryParse ( e.FormattedValue.ToString (), out newInteger ) || ( newInteger != 0 && newInteger != 1 ) )
						e.Cancel = true;
				}
			}
		}
		private void dataGrid_CellValueChanged ( object sender, DataGridViewCellEventArgs e ) {
			if ( saveMenu != 4 ) drawSaveButton ();
		}
		private void dataGrid_UserDeletedRow ( object sender, DataGridViewRowEventArgs e ) {
			drawSaveButton ();
		}
		private void dataGrid_CellClick ( object sender, DataGridViewCellEventArgs e ) {
			if ( saveMenu != 4 ) return;
			showSaveButton = false;
			mHangCode = Convert.ToInt32( dataGrid[dataGrid.Columns["ID"].Index, dataGrid.CurrentCell.RowIndex].Value.ToString ());
			mGubun = Convert.ToInt32(dataGrid[dataGrid.Columns["gubun"].Index, dataGrid.CurrentCell.RowIndex].Value.ToString ());
			subBinding.DataSource = ospcDataSet.mok_title;
			subBinding.ResetBindings ( true );
			mok_titleAdapter.FillByHangGubun ( ospcDataSet.mok_title, mHangCode, mGubun );
			subGrid.DataSource = subBinding;
			subGrid.Columns["ID"].Visible = false;
			subGrid.Columns["hang_code"].Visible = false;
			subGrid.Columns["gubun"].Visible = false;
			subGrid.Columns["mok"].HeaderText = "목";
			subGrid.Columns["mok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			subGrid.Columns["mok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			subGrid.Columns["mok"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			subGrid.Columns["mok"].SortMode = DataGridViewColumnSortMode.Automatic;
			subGrid.Columns["fund_building"].Visible = false;
			subGrid.Columns["fund_gospel"].Visible = false;
			subGrid.Columns["fund_help"].Visible = false;
			showSaveButton = true;
		}
		private void subGrid_UserDeletedRow ( object sender, DataGridViewRowEventArgs e ) {
			drawSaveButton ();
		}
		private void subGrid_CellValidating ( object sender, DataGridViewCellValidatingEventArgs e ) {
			if ( subGrid.Rows[e.RowIndex].IsNewRow ) { return; }
			if ( String.IsNullOrEmpty ( e.FormattedValue.ToString () ) ) e.Cancel = true;
			else {
				subGrid[subGrid.Columns["hang_code"].Index, e.RowIndex].Value = mHangCode;
				subGrid[subGrid.Columns["gubun"].Index, e.RowIndex].Value = mGubun;
			}
		}
		private void subGrid_CellValueChanged ( object sender, DataGridViewCellEventArgs e ) {
			drawSaveButton ();
		}
		//------------------------------------- Methods
		private void drawSaveButton () {
			if ( submitSave == null && showSaveButton == true ) {
				// 저장버튼을 만든다.
				submitSave = new Button ();
				submitSave.Click += new EventHandler ( submitSave_Click );
				submitSave.Width = 80; submitSave.Height = 30;
				submitSave.ImageAlign = ContentAlignment.MiddleCenter;
				submitSave.TextAlign = ContentAlignment.MiddleRight;
				submitSave.TextImageRelation = TextImageRelation.ImageBeforeText;
				submitSave.Image = Properties.Resources.saveHS;
				submitSave.Left = 289; submitSave.Top = 16;
				submitSave.Text = "저장";
				panel1.Controls.Add ( submitSave );
			}
		}
		private bool SaveTable ( int optionalarg = 0 ) {
			if ( submitSave != null ) {
				if ( optionalarg != 1 ) { // 저장버튼이 눌려진 것이 아니면?
					DialogResult result = MessageBox.Show ( "수정된 자료가 있습니다. 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1 );
					if ( result == System.Windows.Forms.DialogResult.Yes ) {
						panel1.Controls.Remove ( submitSave ); submitSave = null; showSaveButton = false;
						tableManager.UpdateAll ( ospcDataSet );
						MessageBox.Show ( "안전하게 저장되었습니다.", "Save OK", MessageBoxButtons.OK );
						return true;
					} else if ( result == DialogResult.No ) {
						panel1.Controls.Remove ( submitSave ); submitSave = null; showSaveButton = false;
						return true;
					} else return false;
				} else {
					panel1.Controls.Remove ( submitSave ); submitSave = null; showSaveButton = false;
					tableManager.UpdateAll ( ospcDataSet );
					MessageBox.Show ( "안전하게 저장되었습니다.", "Save OK", MessageBoxButtons.OK );
					return true;
				}
			} else return true;
		}
	}
}
