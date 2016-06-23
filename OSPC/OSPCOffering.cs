using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OSPC {
	public partial class OSPCOffering : Form {

		private Size nLblSize = new Size ( 85, 25 );
		private const int nLblX = 15;
		private const int nLblY = 77;
		private const int nBoxX = 110;
		private const int nGapY = 32;
		private const int nTrGubun = 0, nTrHangCode = 1;

		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;
		OSPCDataSet oDataSet = new OSPCDataSet ();

		// 콤보박스에서 사용할 배열
		List<int> nBelieverID = new List<int> ();

		private List<Label> lblView = null;
		private List<MultiBoxControls.GeneralTextBox> inBox = null;

		private string nTrDate;
		private int nTrBeliever, nTrMokCode, nTrSeq;
		private int mLastIndex;
		private bool mFirst, mInsertMode;

		public OSPCOffering () {
			mFirst = true;
			InitializeComponent ();
			if ( !myDB.OpenDB () ) this.Close ();
			inDate.DateSelected = DateTime.Today; // 오늘 날짜를 선택 함
			nTrDate = inDate.DateSelected.ToString ( "yyyyMMdd" );
			FillGridTotal ();
			ReadBelieverTable ();
			// 처음 들어오면 무조건 추가 모드
			mInsertMode = false;
			ModeChange ( true );
			mFirst = false;
		}
		//
		// Events ---------------------------------------------
		//
		// Event: 헌금 선택항목을 변경함
		private void gridTotal_CellClick ( object sender, DataGridViewCellEventArgs e ) {
			if ( e.RowIndex == 0 || !mInsertMode ) return;
			int index = e.RowIndex;
			if ( (bool) gridTotal["selected", index].Value ) {
				gridTotal["selected", index].Value = false;
				gridTotal["title", index].Style.BackColor = Color.White;
				gridTotal["total", index].Style.BackColor = Color.White;
			} else {
				gridTotal["selected", index].Value = true;
				gridTotal["title", index].Style.BackColor = Color.LightSteelBlue;
				gridTotal["total", index].Style.BackColor = Color.LightSteelBlue;
			}
			EnableControls ();
			mFirst = true;
			ReadBelieverTable ();
			mFirst = false;
			ReloadTransaction ();
			inName.Focus ();
		}
		//
		// Event: 헌금테이블을 클릭하였음
		private void OSPCOffering_Activated ( object sender, EventArgs e ) {
			inName.Focus ();
		}
		private void btnPrint_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCSimpleReport ( 1, nTrDate, 0 );
			newform.ShowDialog ();
		}
		//
		// Event: 헌금테이블을 클릭하였음
		private void gridTrans_CellClick ( object sender, DataGridViewCellEventArgs e ) {
			if ( mInsertMode ) return;
			MoveData ();
		}
		//
		// Event: 날짜가 바뀌었음
		private void inDate_NewDateSelected ( object sender, EventArgs e ) {
			nTrDate = inDate.DateSelected.ToString ( "yyyyMMdd" );
			EnableControls ();
			LoadTransGrid ();
			mFirst = true;
			ReadBelieverTable ();
			mFirst = false;
			ReloadTransaction ();
			if ( !mInsertMode ) {
				if ( gridTrans.Rows.Count <= 0 ) ModeChange ( true );
				else MoveData ();
			}
			inName.Focus ();
		}
		//
		// Event: 편집 자료 삭제
		private void btnDelete_Click ( object sender, EventArgs e ) {
			if ( ErrorCheck () ) {
				DialogResult result = MessageBox.Show ( "삭제한 자료는 복구할 수 없습니다. 정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1 );
				if ( result == System.Windows.Forms.DialogResult.Yes ) {
					string iSql = "DELETE FROM [transaction] WHERE tr_date=? AND tr_seq=?";
					myDB.CommandSQL = iSql;
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nTrDate;
					myDB.Command.Parameters.Add ( "tr_seq", OleDbType.Integer ).Value = nTrSeq;
					try {
						myDB.Command.ExecuteNonQuery ();
					} catch ( OleDbException ex ) {
						MessageBox.Show ( "삭제하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
						return;
					}
					gridTrans.Rows.Remove ( gridTrans.CurrentRow );
					ReloadTransaction ();
					if ( gridTrans.Rows.Count == 0 ) ModeChange ( true );
					else MoveData ();
				}
			}
		}
		//
		// Event: 모드 변경 버튼
		private void btnChange_Click ( object sender, EventArgs e ) {
			if ( mInsertMode ) ModeChange ( false );
			else ModeChange ( true );
		}
		//
		// Event: 닫기 버튼을 눌렀음
		private void btnClose_Click ( object sender, EventArgs e ) {
			myDB.CloseDB ();
			this.Close ();
		}
		//
		// Event: 저장
		private void btnSave_Click ( object sender, EventArgs e ) {
			if ( ErrorCheck () ) {
				if ( mInsertMode ) {
					int iSeq;
					string iSql = "SELECT IIF(ISNULL(MAX(tr_seq)), 0, MAX(tr_seq)) FROM [transaction] WHERE tr_date = ?";
					myDB.CommandSQL = iSql;
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarWChar ).Value = nTrDate;
					try {
						iSeq = (int) myDB.Command.ExecuteScalar () + 1;
					} catch ( OleDbException ex ) {
						MessageBox.Show ( "일련번호를 구하는 중 오류가 발생하여 저장하지 않습니다.\n" + ex.Message + "\n날짜나 계정과목이 지정되지 않았습니다." );
						return;
					}
					iSql = "INSERT INTO [transaction] (tr_date, tr_seq, tr_gubun, tr_hang_code, tr_mok_code, tr_believer_code, ";
					iSql += "tr_iscash, tr_amount, tr_cheque_no, tr_cheque_ok, tr_cheque_date, tr_update_date, tr_remark) ";
					iSql += "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";
					myDB.CommandSQL = iSql;
					foreach ( MultiBoxControls.GeneralTextBox inb in inBox ) {
						double d = Convert.ToDouble ( inb.Value );
						if ( d == 0 ) continue;
						myDB.Command.Parameters.Clear ();
						myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nTrDate;
						myDB.Command.Parameters.Add ( "tr_seq", OleDbType.Integer ).Value = iSeq++;
						myDB.Command.Parameters.Add ( "tr_gubun", OleDbType.Integer ).Value = nTrGubun;
						myDB.Command.Parameters.Add ( "tr_hang_code", OleDbType.Integer ).Value = nTrHangCode;
						myDB.Command.Parameters.Add ( "tr_mok_code", OleDbType.Integer ).Value = (int) lblView[(int) inb.Tag].Tag;
						myDB.Command.Parameters.Add ( "tr_believe_code", OleDbType.Integer ).Value = nTrBeliever;
						myDB.Command.Parameters.Add ( "tr_iscash", OleDbType.Integer ).Value = 1;
						myDB.Command.Parameters.Add ( "tr_amount", OleDbType.Double ).Value = d;
						myDB.Command.Parameters.Add ( "tr_cheque_no", OleDbType.Integer ).Value = 0;
						myDB.Command.Parameters.Add ( "tr_cheque_ok", OleDbType.Integer ).Value = 0;
						myDB.Command.Parameters.Add ( "tr_cheque_date", OleDbType.VarChar ).Value = nTrDate;
						myDB.Command.Parameters.Add ( "tr_update_date", OleDbType.VarChar ).Value = nTrDate;
						myDB.Command.Parameters.Add ( "tr_remark", OleDbType.VarChar ).Value = "";
						try {
							myDB.Command.ExecuteNonQuery ();
						} catch ( OleDbException ex ) {
							MessageBox.Show ( "추가 저장하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
							return;
						}
					}
				} else {
					double d = Convert.ToDouble ( inBox[0].Value );
					int iRow = gridTrans.CurrentRow.Index;
					string iSql = "UPDATE [transaction] SET tr_believer_code=?, tr_amount=?, tr_update_date=? ";
					iSql += "WHERE tr_date=? AND tr_seq=?";
					myDB.CommandSQL = iSql;
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_believe_code", OleDbType.Integer ).Value = nTrBeliever;
					myDB.Command.Parameters.Add ( "tr_amount", OleDbType.Double ).Value = d;
					myDB.Command.Parameters.Add ( "tr_update_date", OleDbType.VarChar ).Value = DateTime.Today.ToString ( "yyyyMMdd" );
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nTrDate;
					myDB.Command.Parameters.Add ( "tr_seq", OleDbType.Integer ).Value = (int) gridTrans["tr_seq", iRow].Value;
					try {
						myDB.Command.ExecuteNonQuery ();
					} catch ( OleDbException ex ) {
						MessageBox.Show ( "변경 저장하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
						return;
					}
				}
			}
			LoadTransGrid ();
			ReloadTransaction ();
			int idx;
			for ( idx = 0; idx < gridTrans.Rows.Count; idx++ ) {
				if ( (int) gridTrans["tr_believer_code", idx].Value == nTrBeliever ) {
					gridTrans.CurrentCell = gridTrans["tr_believer_name", idx];
					break;
				}
			}
			if ( !gridTrans.CurrentRow.Displayed ) {
				int row = gridTrans.CurrentRow.Index - 5;
				if ( row < 0 ) row = 0;
				gridTrans.FirstDisplayedScrollingRowIndex = row;
			}
			if ( mInsertMode ) ClearFields ();
			else MoveData ();
		}
		//
		// Event: 봉헌자 선택에서 Enter키를 누르면 다음 컨트롤로 갑니다.
		private void inName_KeyDown ( object sender, KeyEventArgs e ) {
			if ( e.KeyCode == Keys.Return ) SendKeys.Send ( "{TAB}" );
		}
		//
		// Event: 성도의 선택이 바뀌면 발생합니다.
		private void inName_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( mFirst ) return;
			if ( !mInsertMode && !btnSave.Enabled ) btnSave.Enabled = true;
			ReadBelieverTable ();
		}
		//
		// Event: 포커스 이동 순서 변경
		private void OSPCOffering_inBoxLeave ( object sender, System.EventArgs e ) {
			Control sd = (Control) sender;
			if ( (int) sd.Tag == mLastIndex ) btnSave.Focus ();
		}
		//
		// Event: 변경 되었는지를 검사
		void OSPCOffering_KeyPress ( object sender, KeyPressEventArgs e ) {
			if ( !btnSave.Enabled ) {
				btnSave.Enabled = true;
			}
		}
		//
		// Methods ---------------------------------------------
		private void MoveData () {
	
			int iRow = gridTrans.CurrentRow.Index;

			nTrMokCode = (int) gridTrans["tr_mok_code", iRow].Value;
			nTrSeq = (int) gridTrans["tr_seq", iRow].Value;
			
			mFirst = true;
			inName.SelectedIndex = -1;
			for ( int i = 0; i < nBelieverID.Count; i++ ) {
				if ( nBelieverID[i] == (int) gridTrans["tr_believer_code", iRow].Value ) {
					inName.SelectedIndex = i;
					break;
				}
			}
			mFirst = false;
			ReadBelieverTable ();

			btnSave.Enabled = false;
			btnDelete.Enabled = true;
			
			lblView[0].Text = (string) gridTrans["tr_mok_name", iRow].Value;
			inBox[0].Value = gridTrans["tr_amount", iRow].Value.ToString();
			inBox[0].Focus ();
		}
		//
		// Method: 저장하기 전 오류를 체크한다.
		private void ModeChange ( bool ins ) {
			if ( ins ) {
				if ( mInsertMode ) return;
				mInsertMode = true;
				EnableControls ();
				ClearFields ();
				btnChange.Image = Properties.Resources.EditCodeHS;
				btnChange.Text = "Change Edit Mode";
				panel1.BackColor = Color.OldLace;
				inName.Focus ();
			} else {
				if ( !mInsertMode ) return;
				if ( gridTrans.Rows.Count > 0 ) {
					mInsertMode = false;
					btnChange.Image = Properties.Resources.AddTableHS;
					btnChange.Text = "Change Insert Mode";
					panel1.BackColor = Color.PeachPuff;
					EnableControls ();
					MoveData ();
					inBox[0].Focus ();
				}
			}
		}
		private void ClearFields () {
			mFirst = true;
			inName.SelectedIndex = -1;
			lblFamily.Text = "";
			foreach ( MultiBoxControls.GeneralTextBox inb in inBox ) {
				inb.Value = "0";
			}
			btnSave.Enabled = false;
			mFirst = false;
			inName.Focus ();
		}
		//
		// Method: 헌금 테이블을 다시 로드한다.
		private void ReloadTransaction () {
			double iAMT = 0, iSUM = 0;
			for ( int i = 1; i < gridTotal.Rows.Count; i++ ) {
				myDB.CommandSQL = "SELECT IIF(ISNULL(SUM(tr_amount)), 0, SUM(tr_amount)) FROM [transaction] WHERE tr_date = ? AND tr_mok_code = ? ";
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarWChar ).Value = nTrDate;
				myDB.Command.Parameters.Add ( "tr_mok_code", OleDbType.Integer ).Value = (int) gridTotal["ID", i].Value;
				iAMT = (double) myDB.Command.ExecuteScalar ();
				gridTotal["total", i].Value = iAMT;
				iSUM += iAMT;
			}
			gridTotal["total", 0].Value = iSUM;
		}
		//
		// Method: 저장하기 전 오류를 체크한다.
		private bool ErrorCheck () {
			if ( !ReadBelieverTable () ) {
				inName.Focus ();
				return false;
			}
			foreach ( MultiBoxControls.GeneralTextBox inb in inBox ) {
				if ( Convert.ToDouble ( inb.Value ) > 0 ) return true;
			}
			MessageBox.Show ( "금액이 모두 0 (Zero) 입니다. " );
			inBox[0].Focus ();
			return false;
		}
		//
		// Method: 봉헌자 오류를 검사하고 헌금대표를 찾아 표시한다.
		private bool ReadBelieverTable () {
			if ( inName.SelectedIndex < 0 ) {
				if ( !mFirst ) MessageBox.Show ( "봉헌자가 선택되지 않았습니다. " );
				return false;
			}
			myDB.CommandSQL = "SELECT * FROM believers WHERE ID = ?";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = nBelieverID[inName.SelectedIndex];
			try {
				mReader = myDB.Command.ExecuteReader ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "봉헌자를 읽는 중 오류가 발생했습니다.\n" + ex.Message );
				return false;
			}
			mReader.Read ();
			if ( mReader["ID"] == mReader["householder"] ) {
				lblFamily.Text = mReader["kor_name"].ToString();
				nTrBeliever = (int) nBelieverID[inName.SelectedIndex];
				mReader.Close ();
				return true;
			} 
			int iSaveID = (int) mReader["householder"];
			mReader.Close ();
			myDB.CommandSQL = "SELECT * FROM believers WHERE ID = ?";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = iSaveID;
			try {
				mReader = myDB.Command.ExecuteReader ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "헌금대표를 읽는 중 오류가 발생했습니다.\n" + ex.Message );
				return false;
			}
			mReader.Read ();
			lblFamily.Text = mReader["kor_name"].ToString ();
			nTrBeliever = (int) nBelieverID[inName.SelectedIndex];
			mReader.Close ();
			return true;
		}
		//
		// Method: gridTatal 그리드에 입력된 데이터를 기초하여 컨트롤을 만든다.
		private void EnableControls () {
			// 기존에 그려진 컨트롤이 있으면 제거한다.
			int index = 0;
			if ( inBox != null || lblView != null ) {
				foreach ( Label lbl in lblView ) {
					panel1.Controls.Remove ( lblView[index++] );
				}
				index = 0;
				foreach ( MultiBoxControls.GeneralTextBox inb in inBox ) {
					panel1.Controls.Remove ( inBox[index++] );
				}
				inBox = null; lblView = null;
			}
			// 컨트롤을 새로 만들고 그린다.
			lblView = new List<Label> ();
			inBox = new List<MultiBoxControls.GeneralTextBox> ();
			index = 0; int iHeight = nLblY;
			if ( mInsertMode ) {
				for ( int i = 1; i < gridTotal.RowCount; i++ ) {
					if ( (bool) gridTotal["selected", i].Value ) {
						Label lbl = new Label ();
						MultiBoxControls.GeneralTextBox inb = new MultiBoxControls.GeneralTextBox ();
						lbl.Visible = false;
						inb.Visible = false;
						lbl.AutoSize = false;
						lbl.Size = nLblSize;
						lbl.Location = new Point ( nLblX, iHeight );
						lbl.Padding = new System.Windows.Forms.Padding ( 0, 0, 3, 0 );
						lbl.Text = gridTotal["title", i].Value.ToString ();
						lbl.TextAlign = ContentAlignment.MiddleCenter;
						lbl.BackColor = Color.Tan;
						lbl.Tag = gridTotal["ID", i].Value;	// 중요: 항목 코드를 저장
						inb.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollarCurrency;
						inb.Location = new Point ( nBoxX, iHeight );
						inb.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
						inb.Tag = index;  // 중요: index를 저장
						inb.Size = new System.Drawing.Size ( 110, 25 );
						inb.TabIndex = index + 1;
						lblView.Add ( lbl );
						inBox.Add ( inb );
						inBox[index].Leave += new EventHandler ( OSPCOffering_inBoxLeave );
						inBox[index].KeyPress += new KeyPressEventHandler ( OSPCOffering_KeyPress );
						panel1.Controls.Add ( lblView[index] );
						panel1.Controls.Add ( inBox[index] );
						lblView[index].Visible = true;
						inBox[index++].Visible = true;
						iHeight += nGapY;
					}
				}
				btnDelete.Visible = false;
			} else {
				Label lbl = new Label ();
				MultiBoxControls.GeneralTextBox inb = new MultiBoxControls.GeneralTextBox ();
				lbl.Visible = false;
				inb.Visible = false;
				lbl.AutoSize = false;
				lbl.Size = nLblSize;
				lbl.Location = new Point ( nLblX, iHeight );
				lbl.TextAlign = ContentAlignment.MiddleCenter;
				lbl.BackColor = Color.Tan;
				lbl.Padding = new System.Windows.Forms.Padding ( 0, 0, 3, 0 );
				inb.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollarCurrency;
				inb.Location = new Point ( nBoxX, iHeight );
				inb.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
				inb.Size = new System.Drawing.Size ( 110, 25 );
				inb.Tag = index;  // 중요: index를 저장
				inb.TabIndex = index + 1;
				lblView.Add ( lbl );
				inBox.Add ( inb );
				inBox[index].Leave += new EventHandler ( OSPCOffering_inBoxLeave );
				inBox[index].KeyPress += new KeyPressEventHandler ( OSPCOffering_KeyPress );
				panel1.Controls.Add ( lblView[index] );
				panel1.Controls.Add ( inBox[index] );
				lblView[index].Visible = true;
				inBox[index++].Visible = true;
				iHeight += nGapY;
				btnDelete.Visible = true;
				btnDelete.Top = iHeight + 5;
			}
			mLastIndex = index;
			btnSave.Enabled = false;
			btnSave.Top = iHeight + 5;
		}
		//
		// Method: gridTatal 그리드를 채움, 로드할 때 한 번만 실행
		private void FillGridTotal () {

			myDB.CommandSQL = "SELECT ID, hang_code, gubun, mok FROM mok_title WHERE hang_code = ?";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = nTrHangCode;
			try {
				mReader = myDB.ExeReader ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "헌금과 관련된 기초자료가 없습니다. \n헌금 기초자료를 입력한 후 다시 시도하세요,\n" + ex.Message, "자료입력 요구", MessageBoxButtons.OK, MessageBoxIcon.Error );
				this.Close ();
			}
			gridTotal.RowCount = 1;
			gridTotal["title", 0].Value = "TOTAL";
			gridTotal["total", 0].Value = 0;
			gridTotal["title", 0].Style.BackColor = Color.Goldenrod;
			gridTotal["total", 0].Style.BackColor = Color.Goldenrod;
			int index = 1;
			while ( mReader.Read () ) {
				gridTotal.RowCount = index + 1;
				gridTotal["gubun", index].Value = mReader["gubun"];
				gridTotal["ID", index].Value = mReader["ID"];
				gridTotal["title", index].Value = mReader["mok"];
				gridTotal["total", index].Value = 0;
				switch ( mReader["mok"].ToString() ) {
					case "주일헌금":
					case "십일조":
					case "감사헌금":
					case "선교헌금":
						gridTotal["selected", index].Value = true;
						gridTotal["title", index].Style.BackColor = Color.LightSteelBlue;
						gridTotal["total", index].Style.BackColor = Color.LightSteelBlue;
						break;
					default:
						gridTotal["selected", index].Value = false;
						gridTotal["title", index].Style.BackColor = Color.White;
						gridTotal["total", index].Style.BackColor = Color.White;
						break;
				}
				index++;
			}
			mReader.Close ();
			ReloadTransaction ();

			//myDB.CommandSQL = "SELECT ID, kor_name FROM believers WHERE deleted <> ? ORDER BY kor_name";
			//myDB.Command.Parameters.Clear ();
			//myDB.Command.Parameters.Add ( "deleted", OleDbType.Integer ).Value = 1; // 탈퇴교인은 빼고 읽는다.
			myDB.CommandSQL = "SELECT ID, kor_name FROM believers ORDER BY kor_name";
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				nBelieverID.Add ( (int) mReader["ID"] );
				inName.Items.Add ( mReader["kor_name"] );
			}
			mReader.Close ();
			inName.SelectedIndex = 0;

			gridTrans.AllowUserToResizeColumns = false;
			gridTrans.AllowUserToResizeRows = false;
			gridTrans.AutoGenerateColumns = true;
			gridTrans.BackgroundColor = Color.OldLace;
			gridTrans.BorderStyle = BorderStyle.Fixed3D;
			gridTrans.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			gridTrans.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			gridTrans.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font ( "맑은 고딕", 9 );
			gridTrans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			gridTrans.ColumnHeadersHeight = 25;
			gridTrans.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			gridTrans.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			gridTrans.DefaultCellStyle.Font = new System.Drawing.Font ( "맑은 고딕", 9 );
			gridTrans.DefaultCellStyle.SelectionBackColor = Color.PeachPuff;
			gridTrans.DefaultCellStyle.SelectionForeColor = Color.Black;
			gridTrans.MultiSelect = false;
			gridTrans.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			gridTrans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			LoadTransGrid ();
		}

		private void LoadTransGrid () {
			//gridTrans.DataSource = "";
			oDataSet.transaction.Clear ();
			string sql = "SELECT tr_date, tr_seq, tr_gubun, tr_hang_code, tr_believer_code, tr_mok_code, tr_iscash, tr_amount, ";
			sql += "tr_cheque_no, tr_cheque_ok, tr_cheque_date, tr_update_date, hang_title.hang AS tr_hang_name, ";
			sql += "believers.kor_name AS tr_believer_name, mok_title.mok AS tr_mok_name, tr_remark FROM [transaction], [believers], [hang_title], [mok_title] ";
			sql += "WHERE hang_title.ID = [transaction].tr_hang_code ";
			sql += "AND mok_title.ID = [transaction].tr_mok_code AND believers.ID = [transaction].tr_believer_code ";
			sql += "AND tr_date = ? AND tr_hang_code = ? ORDER BY 14, 6";
			OleDbDataAdapter dAdpt = new OleDbDataAdapter ( myDB.Command );
			gridTrans.DataSource = oDataSet.transaction;
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nTrDate;
			myDB.Command.Parameters.Add ( "tr_hang_code", OleDbType.Integer ).Value = nTrHangCode;
			try {
				dAdpt.Fill ( oDataSet.transaction );
			} catch ( OleDbException ex ) {
				MessageBox.Show ( ex.Message );
				return;
			}
			gridTrans.Columns["tr_date"].Visible = false;
			gridTrans.Columns["tr_seq"].Visible = false;
			gridTrans.Columns["tr_gubun"].Visible = false;
			gridTrans.Columns["tr_hang_code"].Visible = false;
			gridTrans.Columns["tr_hang_name"].Visible = false;
			gridTrans.Columns["tr_believer_code"].Visible = false;
			gridTrans.Columns["tr_mok_code"].Visible = false;
			gridTrans.Columns["tr_iscash"].Visible = false;
			gridTrans.Columns["tr_cheque_no"].Visible = false;
			gridTrans.Columns["tr_cheque_ok"].Visible = false;
			gridTrans.Columns["tr_cheque_date"].Visible = false;
			gridTrans.Columns["tr_update_date"].Visible = false;
			gridTrans.Columns["tr_remark"].Visible = false;
			gridTrans.Columns["tr_believer_name"].HeaderText = "봉헌자";
			gridTrans.Columns["tr_believer_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			gridTrans.Columns["tr_believer_name"].Width = 60;
			gridTrans.Columns["tr_believer_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			gridTrans.Columns["tr_believer_name"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			gridTrans.Columns["tr_believer_name"].ValueType = typeof ( string );
			gridTrans.Columns["tr_believer_name"].DisplayIndex = 0;
			gridTrans.Columns["tr_mok_name"].HeaderText = "계정과목";
			gridTrans.Columns["tr_mok_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			gridTrans.Columns["tr_mok_name"].Width = 70;
			gridTrans.Columns["tr_mok_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			gridTrans.Columns["tr_mok_name"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			gridTrans.Columns["tr_mok_name"].ValueType = typeof ( string );
			gridTrans.Columns["tr_mok_name"].DisplayIndex = 1;
			gridTrans.Columns["tr_amount"].HeaderText = "봉헌금액";
			gridTrans.Columns["tr_amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			gridTrans.Columns["tr_amount"].Width = 100;
			gridTrans.Columns["tr_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			gridTrans.Columns["tr_amount"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			gridTrans.Columns["tr_amount"].DefaultCellStyle.Format = "C2";
			gridTrans.Columns["tr_amount"].ValueType = typeof ( double );
			gridTrans.Columns["tr_amount"].DisplayIndex = 2;
		}
	}
}
