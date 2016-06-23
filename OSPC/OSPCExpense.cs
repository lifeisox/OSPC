using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OSPC {
	public partial class OSPCExpense : Form {

		const int nTrExceptHangCode = 1;

		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;
		OSPCDataSet oDataSet = new OSPCDataSet ();
		
		// 콤보박스에서 사용할 배열
		List<int> nBelieverID = new List<int>();
		List<int> nGubun = new List<int>();
		List<int> nHangID = new List<int>();
		List<int> nMokID = new List<int>();

		string nTrDate;
		int nTrSeq;
		bool mFirst, mInsertMode;
		double nTotal;

		public OSPCExpense () {
			mFirst = true;
			InitializeComponent ();
			if ( !myDB.OpenDB () ) this.Close ();
			inDate.DateSelected = DateTime.Today; // 오늘 날짜를 선택 함
			nTrDate = inDate.DateSelected.ToString ( "yyyyMMdd" );
			FillGridTotal ();
			// 처음 들어오면 무조건 추가 모드
			mInsertMode = false;
			ModeChange ( true );
			mFirst = false;
		}
		//
		// Events ---------------------------------------------
		//
		// Event: 헌금테이블을 클릭하였음
		private void btnPrint_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCSimpleReport (3, nTrDate, 0 );
			newform.ShowDialog ();
		}
		//
		// Event: 헌금테이블을 클릭하였음
		private void gridTrans_CellClick ( object sender, DataGridViewCellEventArgs e ) {
			if ( mInsertMode ) return;
			gridTrans.CurrentCell = gridTrans["tr_mok_name", e.RowIndex];
			MoveData ();
		}
		//
		// Event: 날짜가 바뀌었음
		private void inDate_NewDateSelected ( object sender, EventArgs e ) {
			nTrDate = inDate.DateSelected.ToString ( "yyyyMMdd" );
			LoadTransGrid ();
			EnableControls ();
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
					// Max Seq 를 읽는다
					string iSql = "SELECT IIF(ISNULL(MAX(tr_seq)), 0, MAX(tr_seq)) FROM [transaction] WHERE tr_date = ?";
					myDB.CommandSQL = iSql;
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarWChar ).Value = nTrDate;
					int iSeq;
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
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nTrDate;
					myDB.Command.Parameters.Add ( "tr_seq", OleDbType.Integer ).Value = iSeq;
					myDB.Command.Parameters.Add ( "tr_gubun", OleDbType.Integer ).Value = nGubun[inAccount.SelectedIndex];
					myDB.Command.Parameters.Add ( "tr_hang_code", OleDbType.Integer ).Value = nHangID[inAccount.SelectedIndex];
					myDB.Command.Parameters.Add ( "tr_mok_code", OleDbType.Integer ).Value = nMokID[inAccount.SelectedIndex];
					myDB.Command.Parameters.Add ( "tr_believe_code", OleDbType.Integer ).Value = nBelieverID[inName.SelectedIndex];
					if ( inIsCheq.Checked ) iSeq = 0; else iSeq = 1;
					myDB.Command.Parameters.Add ( "tr_iscash", OleDbType.Integer ).Value = iSeq;
					myDB.Command.Parameters.Add ( "tr_amount", OleDbType.Double ).Value = Convert.ToDouble ( inAmount.Value );
					myDB.Command.Parameters.Add ( "tr_cheque_no", OleDbType.Integer ).Value = Convert.ToInt32 ( inCheqNo.Value );
					myDB.Command.Parameters.Add ( "tr_cheque_ok", OleDbType.Integer ).Value = 0; // Default
					myDB.Command.Parameters.Add ( "tr_cheque_date", OleDbType.VarChar ).Value = nTrDate;
					myDB.Command.Parameters.Add ( "tr_update_date", OleDbType.VarChar ).Value = nTrDate;
					myDB.Command.Parameters.Add ( "tr_remark", OleDbType.VarChar ).Value = inRemark.Value;
					try {
						myDB.Command.ExecuteNonQuery();
					} catch ( OleDbException ex) {
						MessageBox.Show ( "추가 저장하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
						return;
					}
				} else {
					int iRow = gridTrans.CurrentRow.Index, iSeq;
					string iSql = "UPDATE [transaction] SET tr_gubun=?, tr_hang_code=?, tr_mok_code=?, tr_believer_code=?, ";
					iSql += "tr_iscash=?, tr_amount=?, tr_cheque_no=?, tr_update_date=?, ";
					iSql += "tr_remark=? WHERE tr_date=? AND tr_seq=?";
					myDB.CommandSQL = iSql;
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_gubun", OleDbType.Integer ).Value = nGubun[inAccount.SelectedIndex];
					myDB.Command.Parameters.Add ( "tr_hang_code", OleDbType.Integer ).Value = nHangID[inAccount.SelectedIndex];
					myDB.Command.Parameters.Add ( "tr_mok_code", OleDbType.Integer ).Value = nMokID[inAccount.SelectedIndex];
					myDB.Command.Parameters.Add ( "tr_believe_code", OleDbType.Integer ).Value = nBelieverID[inName.SelectedIndex];
					if ( inIsCheq.Checked ) iSeq = 0; else iSeq = 1;
					myDB.Command.Parameters.Add ( "tr_iscash", OleDbType.Integer ).Value = iSeq;
					myDB.Command.Parameters.Add ( "tr_amount", OleDbType.Double ).Value = Convert.ToDouble ( inAmount.Value );
					myDB.Command.Parameters.Add ( "tr_cheque_no", OleDbType.Integer ).Value = Convert.ToInt32 ( inCheqNo.Value );
					myDB.Command.Parameters.Add ( "tr_update_date", OleDbType.VarChar ).Value = DateTime.Today.ToString ( "yyyyMMdd" );
					myDB.Command.Parameters.Add ( "tr_remark", OleDbType.VarChar ).Value = inRemark.Value;
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nTrDate;
					myDB.Command.Parameters.Add ( "tr_seq", OleDbType.Integer ).Value = (int) gridTrans["tr_seq", iRow].Value;
					try {
						myDB.Command.ExecuteNonQuery ();
					} catch ( OleDbException ex ) {
						MessageBox.Show ( "변경 저장하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
						return;
					}
				}
				LoadTransGrid ();
				ReloadTransaction ();
				int idx;
				for ( idx = 0; idx < gridTrans.Rows.Count; idx++ ) {
					if ( (int) gridTrans["tr_mok_code", idx].Value == nMokID[inAccount.SelectedIndex] ) {
						gridTrans.CurrentCell = gridTrans["tr_mok_name", idx];
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
			if ( !btnSave.Enabled ) btnSave.Enabled = true;
			if ( !ReadBelieverTable () ) inName.Focus ();
		}
		private void inAccount_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( mFirst ) return;
			if ( !btnSave.Enabled ) btnSave.Enabled = true;
			if ( !ReadAccount () ) inAccount.Focus ();
		}
		//
		// Event: 변경 되었는지를 검사
		private void inAmount_TextChanged ( object sender, EventArgs e ) {
			if ( !btnSave.Enabled ) {
				btnSave.Enabled = true;
			}
		}
		private void inCheqNo_Validating ( object sender, CancelEventArgs e ) {
			if ( Convert.ToInt32 ( inCheqNo.Value ) > 0 ) {
				inIsCheq.Checked = true;
			}
		}
		private void inIsCheq_Click ( object sender, EventArgs e ) {
			if ( !btnSave.Enabled ) {
				btnSave.Enabled = true;
			}
		}
		private void OSPCExpense_Activated ( object sender, EventArgs e ) {
			inName.Focus ();
		}
		//
		// Methods ---------------------------------------------
		private void MoveData () {
			if ( gridTrans.CurrentCell == null ) return;

			int iRow = gridTrans.CurrentRow.Index;

			mFirst = true;
			inName.SelectedIndex = -1;
			for ( int i = 0; i < nBelieverID.Count; i++ ) {
				if ( nBelieverID[i] == (int) gridTrans["tr_believer_code", iRow].Value ) {
					inName.SelectedIndex = i;
					break;
				}
			}
			inAccount.SelectedIndex = -1;
			for ( int i = 0; i < nMokID.Count; i++ ) {
				if ( nMokID[i] == (int) gridTrans["tr_mok_code", iRow].Value ) {
					inAccount.SelectedIndex = i;
					break;
				}
			}
			mFirst = false;
			nTrSeq = (int) gridTrans["tr_seq", iRow].Value;
			inAmount.Value = gridTrans["tr_amount", iRow].Value.ToString();
			inCheqNo.Value = gridTrans["tr_cheque_no", iRow].Value.ToString ();
			inRemark.Value = gridTrans["tr_remark", iRow].Value.ToString ();
			if ( (int) gridTrans["tr_iscash", iRow].Value == 1 ) inIsCheq.Checked = false;
			else inIsCheq.Checked = true;

			btnSave.Enabled = false;
			btnDelete.Enabled = true;
			inName.Focus ();
		}
		//
		// Method: 저장하기 전 오류를 체크한다.
		private void ModeChange ( bool ins ) {
			if ( ins ) {
				if ( mInsertMode ) return;
				mInsertMode = true;
				ClearFields ();
				btnChange.Image = Properties.Resources.EditCodeHS;
				btnChange.Text = "Change Edit Mode";
				panel1.BackColor = Color.OldLace;
				EnableControls ();
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
				} 
			}
		}
		private void ClearFields () {
			mFirst = true;
			inName.SelectedIndex = -1;
			inAccount.SelectedIndex = -1;
			inAmount.Value = "0";
			inCheqNo.Value = "0";
			inIsCheq.Checked = false;
			inRemark.Value = "";
			btnSave.Enabled = false;
			mFirst = false;
			inName.Focus ();
		}
		//
		// Method: 헌금 테이블을 다시 로드한다.
		private void ReloadTransaction () {
			double iAMT = 0, iSUM = 0;
			for ( int i = 1; i < gridTotal.Rows.Count; i++ ) {
				myDB.CommandSQL = "SELECT IIF(ISNULL(SUM(tr_amount)), 0, SUM(tr_amount)) FROM [transaction] WHERE tr_date = ? AND tr_hang_code = ? ";
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarWChar ).Value = nTrDate;
				myDB.Command.Parameters.Add ( "tr_hang_code", OleDbType.Integer ).Value = (int) gridTotal["ID", i].Value;
				iAMT = (double) myDB.Command.ExecuteScalar ();
				gridTotal["total", i].Value = iAMT;
				if ( (int) gridTotal["gubun", i].Value == 0 ) iSUM -= iAMT;
				else iSUM += iAMT;
			}
			gridTotal["total", 0].Value = iSUM;
			nTotal = iSUM;
		}
		//
		// Method: 저장하기 전 오류를 체크한다.
		private bool ErrorCheck () {
			if ( Convert.ToDouble ( inAmount.Value ) == 0 ) {
				MessageBox.Show ( "금액이 0 (Zero) 입니다. " );
				inAmount.Focus ();
				return false;
			}
			if ( !ReadBelieverTable () ) {
				inName.Focus ();
				return false;
			}
			if ( !ReadAccount () ) {
				inAccount.Focus ();
				return false;
			}
			return true;
		}
		private bool ReadBelieverTable () {
			if ( inName.SelectedIndex < 0 ) {
				if ( !mFirst ) MessageBox.Show ( "담당자가 선택되지 않았습니다. " );
				return false;
			}
			myDB.CommandSQL = "SELECT IIF(ISNULL(kor_name), '', kor_name) FROM believers WHERE ID = ?";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = nBelieverID[inName.SelectedIndex];
			try {
				string iStr = (string) myDB.Command.ExecuteScalar ();
				return true;
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "담당자는 반드시 입력되야하는 항목입니다.\n" + ex.Message );
				return false;
			}
		}
		private bool ReadAccount () {
			if ( inAccount.SelectedIndex < 0 ) {
				if ( !mFirst ) MessageBox.Show ( "계정과목이 선택되지 않았습니다. " );
				return false;
			}
			myDB.CommandSQL = "SELECT IIF(ISNULL(mok), '', mok) FROM mok_title WHERE ID = ?";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = nMokID[inAccount.SelectedIndex];
			try {
				string iStr = (string) myDB.Command.ExecuteScalar ();
				return true;
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "계정과목은 반드시 입력되야하는 항목입니다.\n" + ex.Message );
				return false;
			}
		}
		//
		// Method: gridTotal 그리드에 입력된 데이터를 기초하여 컨트롤을 만든다.
		private void EnableControls () {
			if ( mInsertMode ) {
				btnDelete.Visible = false;
			} else {
				btnDelete.Visible = true;
			}
			btnSave.Enabled = false;
		}
		//
		// Method: gridTatal 그리드를 채움, 로드할 때 한 번만 실행
		private void FillGridTotal () {

			// hang_code 1 을 제외하고 읽는다.
			myDB.CommandSQL = "SELECT ID, gubun, hang FROM hang_title WHERE ID <> ?";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = nTrExceptHangCode;
			mReader = myDB.ExeReader ();

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
				gridTotal["title", index].Value = mReader["hang"];
				gridTotal["total", index].Value = 0;
				gridTotal["selected", index].Value = false;
				gridTotal["title", index].Style.BackColor = Color.White;
				gridTotal["total", index++].Style.BackColor = Color.White;
			}
			mReader.Close ();
			ReloadTransaction ();

			myDB.CommandSQL = "SELECT ID, kor_name FROM believers WHERE deleted <> ? ORDER BY kor_name";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "deleted", OleDbType.Integer ).Value = 1; // 탈퇴교인은 빼고 읽는다.
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				nBelieverID.Add ( (int) mReader["ID"] );
				inName.Items.Add ( mReader["kor_name"] );
			}
			mReader.Close ();
			inName.SelectedIndex = 0;

			string ISQL = "SELECT mok_title.ID, mok_title.gubun, mok_title.hang_code, mok_title.mok, hang_title.hang ";
			ISQL += "FROM hang_title, mok_title WHERE hang_title.ID = mok_title.hang_code AND mok_title.hang_code <> ? ORDER BY hang_code, mok";
			myDB.CommandSQL = ISQL;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "hang_code", OleDbType.Integer ).Value = nTrExceptHangCode;
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				nGubun.Add ( (int) mReader["gubun"] );
				nHangID.Add ( (int) mReader["hang_code"] );
				nMokID.Add ( (int) mReader["ID"] );
				ISQL = (string) mReader["hang"] + ": " ;
				ISQL += (string) mReader["mok"];
				if ( (int) mReader["gubun"] == 0) ISQL += " [입금]";
				else ISQL += " [출금]";
				inAccount.Items.Add ( ISQL );
			}
			mReader.Close ();
			inAccount.SelectedIndex = 0;

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
			gridTrans.DataSource = "";
			oDataSet.transaction.Clear ();
			string sql = "SELECT tr_date, tr_seq, tr_gubun, tr_hang_code, tr_believer_code, tr_mok_code, tr_iscash, tr_amount, ";
			sql += "tr_cheque_no, tr_cheque_ok, tr_cheque_date, tr_update_date, hang_title.hang AS tr_hang_name, ";
			sql += "believers.kor_name AS tr_believer_name, mok_title.mok AS tr_mok_name, tr_remark FROM [transaction], [believers], [hang_title], [mok_title] ";
			sql += "WHERE hang_title.ID = [transaction].tr_hang_code ";
			sql += "AND mok_title.ID = [transaction].tr_mok_code AND believers.ID = [transaction].tr_believer_code ";
			sql += "AND tr_date = ? AND tr_hang_code <> ? ORDER BY tr_gubun, tr_hang_code, tr_mok_code";
			OleDbDataAdapter dAdpt = new OleDbDataAdapter ( myDB.Command );
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nTrDate;
			myDB.Command.Parameters.Add ( "tr_hang_code", OleDbType.Integer ).Value = nTrExceptHangCode;
			dAdpt.Fill ( oDataSet.transaction );
			gridTrans.DataSource = oDataSet.transaction;
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
			gridTrans.Columns["tr_remark"].Visible = false;
			gridTrans.Columns["tr_mok_name"].HeaderText = "계정과목";
			gridTrans.Columns["tr_mok_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			gridTrans.Columns["tr_mok_name"].Width = 70;
			gridTrans.Columns["tr_mok_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			gridTrans.Columns["tr_mok_name"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			gridTrans.Columns["tr_mok_name"].ValueType = typeof ( string );
			gridTrans.Columns["tr_mok_name"].DisplayIndex = 0;
			gridTrans.Columns["tr_believer_name"].HeaderText = "담당자";
			gridTrans.Columns["tr_believer_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			gridTrans.Columns["tr_believer_name"].Width = 60;
			gridTrans.Columns["tr_believer_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			gridTrans.Columns["tr_believer_name"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
			gridTrans.Columns["tr_believer_name"].ValueType = typeof ( string );
			gridTrans.Columns["tr_believer_name"].DisplayIndex = 1;
			gridTrans.Columns["tr_amount"].HeaderText = "금액";
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
