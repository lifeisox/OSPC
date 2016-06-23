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

	public partial class OSPCBeliever : Form {
	
		enum ButtonSelect { New, Save, Cancel, Delete };

		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;
		List<int> nDutyID = new List<int> ();
		List<int> nBelieverID = new List<int> ();
		List<int> nRelationID = new List<int> ();

		bool nFirstSW = true, addSW = false, updateSW = false, changeSW = false;
		int mROW = 0, mID = 0;
		string mSaveStr;
		OSPCDataSetTableAdapters.zipcodesTableAdapter zipcodesAdapter = new OSPCDataSetTableAdapters.zipcodesTableAdapter ();

		public OSPCBeliever () {
			nFirstSW = true;
			InitializeComponent ();
			if ( !myDB.OpenDB () ) this.Close ();
			FillComboList ();
			inDutyCombo.KeyDown += new KeyEventHandler ( inDutyCombo_KeyDown );
			ChangeButtonStatusAll ( false, false, false, false );
			this.Refresh ();
			FillGrid ();
		}

		//-------------- Events -----------------------------------------------
		// Event: 폼이 활성화 될 때 처음 실행됨.
		private void OSPCBeliever_Activated ( object sender, EventArgs e ) {
			if (nFirstSW) {
				nFirstSW = false;
				if ( dataGrid.Rows.Count == 0 ) {
					ChangeButtonStatusAll ( true, false, false, false );
					ChangeControlsStatus ( false );
				} else {
					if ( dataGrid.RowCount > 5 ) dataGrid.FirstDisplayedScrollingRowIndex = dataGrid.RowCount - 5;
					mROW = dataGrid.RowCount - 1; // 마지막 행을 현재행으로 설정
					dataGrid.CurrentCell = dataGrid["kor_name", mROW];
				}
			}
		}
		// Event: 신규 버튼을 눌렀음
		private void btnNew_Click ( object sender, EventArgs e ) {
			if ( !SaveTable() ) return;
			ChangeControlsStatus();
			ChangeButtonStatusAll(false, false, true, false);
			if ( ( Control.ModifierKeys & Keys.Shift ) != 0 && updateSW ) ClearAllFields(false);
			else ClearAllFields(true);	// 모든 컨트롤을 초기화한다.
			addSW = true; updateSW = false; changeSW = false;
		}
		// Event: 저장 버튼을 눌렀음
		private void btnSave_Click ( object sender, EventArgs e ) {
			SaveTable(1);
		}
		// Event: 취소 버튼을 눌렀음
		private void btnCancel_Click ( object sender, EventArgs e ) {
			if (addSW) { // [신규]입력 상태에서 취소하면 필드 Clear 하고 다시 신규버튼 살리면 됨
				if (dataGrid.RowCount == 0) {
					ClearAllFields(true);
					ChangeControlsStatus(false);
					ChangeButtonStatusAll(true, false, false, false);
					addSW = false; updateSW = false; changeSW = false;
				} else {
					FillData();
				}
			} else if ( updateSW ) { // 수정 상태이면 취소하고 이전에 읽었던 데이터를 새로 깜
				FillData();
			}
		}
		// Event: 저장 버튼을 눌렀음
		private void btnDelete_Click ( object sender, EventArgs e ) {
			if ( SaveTable() ) DeleteTable();
		}
		// Event: 닫기 버튼을 눌렀음
		private void btnClose_Click ( object sender, EventArgs e ) {
			if ( SaveTable () ) {
				myDB.CloseDB ();
				this.Close ();
			}
		}
		// Event: dataGrid 선택이 바꼈음
		private void dataGrid_CurrentCellChanged ( object sender, EventArgs e ) {
			if ( dataGrid.CurrentRow == null ) return;
			if ( !nFirstSW && SaveTable() ) {
				mROW = dataGrid.CurrentRow.Index;
				dataGrid.Rows[mROW].Selected = true;
				FillData();
			}
		}
		// Event: 콤보박스에서 Enter 키가 눌리면 다음 컨트롤로
		private void inDutyCombo_KeyDown ( object sender, KeyEventArgs e ) {
			if (e.KeyCode == Keys.Return) { SendKeys.Send("{TAB}"); e.SuppressKeyPress = true; }
		}
		// Event: 우편번호가 입력되면 City와 State를 찾아온다.
		private void inPostalCode_Validating ( object sender, CancelEventArgs e ) {
			string sr = inPostalCode.Value.Substring(0,3) + " " + inPostalCode.Value.Substring(3, 3);
			myDB.CommandSQL = "SELECT city, state FROM zipcodes WHERE zip = '" + sr + "'";
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader ();
			if ( mReader.Read () ) {
				inCity.Value = mReader["city"].ToString();
				inState.Value = mReader["state"].ToString();
			} else {
				if (MessageBox.Show("우편번호를 찾을 수 없습니다. 다시 입력하시겠습니까?", "Postal Code Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ) {
					inPostalCode.Focus();
					e.Cancel = true;
				}
			}
			mReader.Close ();
		}
		// Event: 자료 수정여부를 확인하기 위해 Leave 이벤트와 쌍으로 사용. (MultiBox는 모두 사용)
		private void inKorName_Enter ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox sd = (MultiBoxControls.GeneralTextBox) sender;
			if ( !changeSW ) {
				mSaveStr = sd.Text;
			}
		}
		// Event: 자료 수정여부를 확인하기 위해 Enter 이벤트와 쌍으로 사용. (MultiBox는 모두 사용)
		private void inKorName_Leave ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox sd = (MultiBoxControls.GeneralTextBox) sender;
			if ( !nFirstSW && !changeSW && mSaveStr != sd.Text ) {
				changeSW = true;
				ChangeButtonStatusAll (false, true, true, false);
			}
		}
		// Event: CheckBox의 자료 수정여부를 확인함 
		private void inManCheck_CheckedChanged ( object sender, EventArgs e ) {
			if ( !nFirstSW && !changeSW ) {
				changeSW = true;
				ChangeButtonStatusAll ( false, true, true, false );
			}
		}
		// Event: ComboBox의 자료 수정여부를 확인홤
		private void inDutyCombo_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( !nFirstSW && !changeSW ) {
				changeSW = true;
				ChangeButtonStatusAll(false, true, true, false);
			}
		}

		//-------------- Methods -----------------------------------------
		// Method: 버튼 상태를 Enable 하거나 Disable 한다.
		private void ChangeButtonStatusAll (bool inew, bool isave, bool icancel, bool idelete) {
			btnNew.Enabled = inew;			btnSave.Enabled = isave;
			btnCancel.Enabled = icancel;	btnDelete.Enabled = idelete;
		}
		// Method: 버튼 상태를 Enable 하거나 Disable 한다.
		private void ChangeButtonStatus ( ButtonSelect iButton, bool idef ) {
			switch (iButton) {
				case ButtonSelect.New:		btnNew.Enabled = idef;		break;
				case ButtonSelect.Save:		btnSave.Enabled = idef;		break;
				case ButtonSelect.Cancel:	btnCancel.Enabled = idef;	break;
				case ButtonSelect.Delete:	btnDelete.Enabled = idef;	break;
			}
		}
		// Method: panel0에 있는 모든 컨트롤의 상태를 Enable 하거나 Disable 한다.
		private void ChangeControlsStatus ( bool stat = true ) {
			Control.ControlCollection conColl = panel0.Controls;
			foreach ( Control con in conColl ) {
				con.Enabled = stat;
			}
		}			
		// Method: 신규 작업을 하기 전에 모든 입력 필드를 Clear 한다.
		private void ClearAllFields (bool range) {
			nFirstSW = true;
			// believers의 ID 중 최대값을 구한다.
			myDB.CommandSQL = "SELECT MAX(ID) FROM believers";
			myDB.Command.Parameters.Clear ();
			mID = (int) myDB.Command.ExecuteScalar() + 1;
			inKorName.Value = "";
			inEngName.Value = "";
			inManCheck.Checked = true;	// 남자
			inMarryCheck.Checked = true; // 기혼
			inBirth.Value = DateTime.Today.ToString ( "MMdd" ); // 생일을 오늘 날짜로
			inLunarCheck.Checked = false; // 양력
			inDutyCombo.SelectedIndex = inDutyCombo.Items.Count - 1; 
			inRelationCombo.SelectedIndex = 0; // 본인 선택
			inEMail.Value = "";
			inDeletedCombo.SelectedIndex = 0;
			inRemark.Value = "";
			if ( range ) {
				inHouseHolderCombo.Text = "본인 세대주";
				inHouseHolderCombo.SelectedIndex = -1;
				inPayCodeCombo.Text = "본인 헌금대표";
				inPayCodeCombo.SelectedIndex = -1;
				inPhone1Num.Value = "6130000000";
				inPhone1Remark.Value = "";
				inPhone2Num.Value = "6130000000";
				inPhone2Remark.Value = "";
				inPhone3Num.Value = "6130000000";
				inPhone3Remark.Value = "";
				inPostalCode.Value = "K2E5S9";
				inAddress.Value = "";
				inCity.Value = "Nepean";
				inState.Value = "ON";
			}
			lblNewDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
			lblUpdateDate.Text = "";
			lblDeleteDate.Text = "";
			inKorName.Focus();
			nFirstSW = false;
		}
		// Method: DataGridView에서 데이터를 선택하면 panel0에 데이터를 뿌림	
		private void FillData () {
			nFirstSW = true;
			mID = (int) dataGrid["ID", mROW].Value;
			string sql = "SELECT * FROM believers WHERE ID=? ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = mID;
			mReader = myDB.ExeReader();
			if ( mReader.Read () ) {
				inKorName.Value = mReader["kor_name"].ToString ();
				inEngName.Value = ( String.IsNullOrEmpty ( mReader["eng_name"].ToString () ) ? "" : mReader["eng_name"].ToString () );
				if ( (int) mReader["man"] == 1 ) inManCheck.Checked = true; else inManCheck.Checked = false;
				if ( (int) mReader["married"] == 1 ) inMarryCheck.Checked = true; else inMarryCheck.Checked = false;
				inBirth.Value = ( String.IsNullOrEmpty ( mReader["birthdate"].ToString () ) ? "0101" : mReader["birthdate"].ToString () );
				if ( (int) mReader["lunar"] == 1 ) inLunarCheck.Checked = true; else inLunarCheck.Checked = false;
				int i;
				for ( i = 0; i < inDutyCombo.Items.Count; i++ ) {
					if ( nDutyID[i] == (int) mReader["duty"] ) break;
				}
				if ( i == inDutyCombo.Items.Count ) inDutyCombo.SelectedIndex = -1;
				else inDutyCombo.SelectedIndex = i;
				for ( i = 0; i < inHouseHolderCombo.Items.Count; i++ ) {
					if ( nBelieverID[i] == (int) mReader["householder"] ) break;
				}
				if ( i == inHouseHolderCombo.Items.Count ) inHouseHolderCombo.SelectedIndex = -1;
				else inHouseHolderCombo.SelectedIndex = i;
				for ( i = 0; i < inRelationCombo.Items.Count; i++ ) {
					if ( nRelationID[i] == (int) mReader["relation"] ) break;
				}
				if ( i == inRelationCombo.Items.Count ) inRelationCombo.SelectedIndex = -1;
				else inRelationCombo.SelectedIndex = i;
				inPhone1Num.Value = ( String.IsNullOrEmpty ( mReader["p1_number"].ToString () ) ? "      0000" : mReader["p1_number"].ToString () );
				inPhone1Remark.Value = ( String.IsNullOrEmpty ( mReader["p1_remark"].ToString () ) ? "" : mReader["p1_remark"].ToString () );
				inPhone2Num.Value = ( String.IsNullOrEmpty ( mReader["p2_number"].ToString () ) ? "      0000" : mReader["p2_number"].ToString ());
				inPhone2Remark.Value = ( String.IsNullOrEmpty ( mReader["p2_remark"].ToString () ) ? "" : mReader["p2_remark"].ToString () );
				inPhone3Num.Value = ( String.IsNullOrEmpty ( mReader["p3_number"].ToString () ) ? "      0000" : mReader["p3_number"].ToString () );
				inPhone3Remark.Value = ( String.IsNullOrEmpty ( mReader["p3_remark"].ToString () ) ? "" : mReader["p3_remark"].ToString () );
				inEMail.Value = ( String.IsNullOrEmpty ( mReader["email"].ToString () ) ? "" : mReader["email"].ToString () ); 
				for ( i = 0; i < inPayCodeCombo.Items.Count; i++ ) {
					if ( nBelieverID[i] == (int) mReader["pay_code"] )
						break;
				}
				if ( i == inPayCodeCombo.Items.Count ) inPayCodeCombo.SelectedIndex = -1;
				else inPayCodeCombo.SelectedIndex = i;
				inPostalCode.Value = ( String.IsNullOrEmpty ( mReader["postal_code"].ToString () ) ? "K2E5S9" : mReader["postal_code"].ToString () );
				inAddress.Value = ( String.IsNullOrEmpty ( mReader["address"].ToString () ) ? "" : mReader["address"].ToString () );
				inCity.Value = ( String.IsNullOrEmpty ( mReader["city"].ToString () ) ? "" : mReader["city"].ToString () );
				inState.Value = ( String.IsNullOrEmpty ( mReader["state"].ToString () ) ? "" : mReader["state"].ToString () );
				inDeletedCombo.SelectedIndex = (int) mReader["deleted"];
				inRemark.Value = ( String.IsNullOrEmpty ( mReader["remark"].ToString () ) ? "" : mReader["remark"].ToString () );
				lblNewDate.Text = DataToDate ( mReader["new_date"].ToString () );
				lblUpdateDate.Text = DataToDate ( mReader["update_date"].ToString () );
				lblDeleteDate.Text = DataToDate ( mReader["delete_date"].ToString () );
			}
			mReader.Close ();
			addSW = false;
			updateSW = true;
			changeSW = false;
			ChangeButtonStatusAll(true, false, false, true);
			inKorName.Focus ();
			nFirstSW = false;
		}
		// Method: 마지막으로 읽은 후 수정되었는지를 검사하여 저장 함.
		private bool SaveTable ( int optionalarg = 0 ) {
			if ( changeSW == true ) {
				changeSW = false;
				if ( optionalarg != 1 ) { // 저장버튼이 눌려진 것이 아니면?
					DialogResult result = MessageBox.Show("수정된 자료가 있습니다. 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
					if ( result == System.Windows.Forms.DialogResult.Yes ) {
						SaveDatabase();
						return true;
					} else if ( result == DialogResult.No ) {
						return true;
					} else {
						changeSW = true;
						return false;
					}
				} else {
					SaveDatabase();
					return true;
				}
			} else return true;
		}

		// Method: Grid를 채운다.
		private void FillGrid () {
			dataGrid.Rows.Clear ();
			string sql = "SELECT ID, kor_name, eng_name, LEFT(birthdate, 2) + '-' + RIGHT(birthdate, 2) AS birth, ";
			sql += "LEFT(p1_number, 3) + '-' + MID(p1_number, 4, 3) + '-' + RIGHT(p1_number, 4) AS p1_num, ";
			sql += "LEFT(postal_code, 3) + ' ' + RIGHT(postal_code, 3) AS postal, address + ' ' + city + ', ' + state + '.' AS full_addr  ";
			sql += "FROM believers ORDER BY kor_name";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			int cnt = 0;
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				dataGrid.Rows.Add (1);
				dataGrid["ID", cnt].Value = mReader["ID"];
				dataGrid["kor_name", cnt].Value = mReader["kor_name"];
				dataGrid["eng_name", cnt].Value = mReader["eng_name"];
				dataGrid["birthdate", cnt].Value = mReader["birth"];
				dataGrid["p1_number", cnt].Value = mReader["p1_num"];
				dataGrid["postal_code", cnt].Value = mReader["postal"];
				dataGrid["address", cnt++].Value = mReader["full_addr"];
			}
			mReader.Close ();
			dataGrid.Refresh ();
		}

		// Method: Binding되지 않은 콤보박스를 채운다. 
		private void FillComboList () {
			// inDutyCombo를 채운다.
			nDutyID.Clear (); inDutyCombo.Items.Clear ();
			myDB.CommandSQL = "SELECT ID, duty FROM duties ORDER BY ID";
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				nDutyID.Add ( (int) mReader["ID"] );
				inDutyCombo.Items.Add ( mReader["duty"] );
			}
			mReader.Close ();
			inDutyCombo.SelectedIndex = inDutyCombo.Items.Count - 1; // 맨 마지막 읽은 것 선택 Maybe 성도
			// inHousHolderCombo와 inPayCodeCombo를 채운다.
			nBelieverID.Clear (); inHouseHolderCombo.Items.Clear (); inPayCodeCombo.Items.Clear ();
			myDB.CommandSQL = "SELECT ID, kor_name FROM believers ORDER BY kor_name";
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				nBelieverID.Add ( (int) mReader["ID"] );
				inHouseHolderCombo.Items.Add ( mReader["kor_name"] );
				inPayCodeCombo.Items.Add ( mReader["kor_name"] );
			}
			mReader.Close ();
			inHouseHolderCombo.SelectedIndex = -1;
			inPayCodeCombo.SelectedIndex = -1;
			// inRelationCombo를 채운다.
			nRelationID.Clear (); inRelationCombo.Items.Clear ();
			myDB.CommandSQL = "SELECT ID, relation FROM family ORDER BY ID";
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				nRelationID.Add ( (int) mReader["ID"] );
				inRelationCombo.Items.Add ( mReader["relation"] );
			}
			mReader.Close ();
			inRelationCombo.SelectedIndex = 0;
			// inDeletedComboBox 리스트박스를 따로 만들어 사용.
			inDeletedCombo.Items.Clear ();
			inDeletedCombo.Items.Add ( "출석교인" );
			inDeletedCombo.Items.Add ( "탈퇴교인" );
			inDeletedCombo.Items.Add ( "[지출거래처]" );
		}
		// Method: 한 행을 삭제한다
		private void DeleteTable () {
			DialogResult result = MessageBox.Show("삭제한 자료는 복구할 수 없습니다. 정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			if ( result == System.Windows.Forms.DialogResult.Yes ) {
				string iSql = "DELETE FROM [believers] WHERE ID=?";
				myDB.CommandSQL = iSql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = mID;
				try {
					myDB.Command.ExecuteNonQuery ();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "삭제하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}
				dataGrid.Rows.Remove ( dataGrid.Rows[mROW] );
				dataGrid.Refresh ();
				addSW = false; changeSW = false;
				if (dataGrid.Rows.Count == 0) {
					updateSW = false;
					ChangeButtonStatusAll(true, false, false, false);
					ChangeControlsStatus(false);
				} 
			}
		}
		// Method: 그리드에 한 행을 추가하고 데이터베이스에 자료를 저장한다.
		private void SaveDatabase() {
			if (addSW) { // 신규 입력할 때
				string sql;
				sql = "	 INSERT INTO [believers] (ID, kor_name, eng_name, man, birthdate, lunar, married, duty, householder, ";
				sql += "	relation, email, p1_number, p1_remark, p2_number, p2_remark, p3_number, p3_remark, postal_code, ";
				sql += "	address, city, state, pay_code, remark, deleted, new_date, update_date, delete_date )";
				sql += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"; // 27개
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = mID;
				MoveRecord ();
				myDB.Command.Parameters.Add ( "new_date", OleDbType.VarChar ).Value = DateToData ( lblNewDate.Text );
				myDB.Command.Parameters.Add ( "update_date", OleDbType.VarChar ).Value = "        ";
				if ( Convert.ToInt32 ( inDeletedCombo.SelectedIndex ) != 0 ) sql = DateTime.Today.ToString ( "yyyyMMdd" ); else sql = "        ";
				myDB.Command.Parameters.Add ( "delete_date", OleDbType.VarChar ).Value = sql;
				try {
					myDB.Command.ExecuteNonQuery ();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "추가 저장하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}

				FillComboList();
				dataGrid.Rows.Add ( 1 );
				int cnt = dataGrid.Rows.Count - 1;
				dataGrid["ID", cnt].Value = mID;
				dataGrid["kor_name", cnt].Value = inKorName.Value;
				dataGrid["eng_name", cnt].Value = inEngName.Value;
				dataGrid["birthdate", cnt].Value = inBirth.Text;
				dataGrid["p1_number", cnt].Value = inPhone1Num.Text;
				dataGrid["postal_code", cnt].Value = inPostalCode.Text;
				dataGrid["address", cnt].Value = inAddress.Text + ' ' + inCity.Text + ", " + inState.Text + ".";
				ChangeButtonStatus ( ButtonSelect.Save, false );
				addSW = false; changeSW = false; updateSW = false;
				dataGrid.Refresh ();
				dataGrid.CurrentCell = dataGrid["kor_name", cnt];
			} else {
				string sql;
				sql = "	 UPDATE [believers] SET kor_name=?, eng_name=?, man=?, birthdate=?, lunar=?, married=?, duty=?, householder=?, ";
				sql += "	relation=?, email=?, p1_number=?, p1_remark=?, p2_number=?, p2_remark=?, p3_number=?, p3_remark=?, postal_code=?, ";
				sql += "	address=?, city=?, state=?, pay_code=?, remark=?, deleted=?, update_date=?, delete_date=? ";
				sql += " WHERE ID=? ";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				MoveRecord ();
				myDB.Command.Parameters.Add ( "update_date", OleDbType.VarChar ).Value = DateTime.Today.ToString ( "yyyyMMdd" );
				if ( Convert.ToInt32 ( inDeletedCombo.SelectedIndex ) != 0 ) sql = DateTime.Today.ToString ( "yyyyMMdd" ); else sql = "        ";
				myDB.Command.Parameters.Add ( "delete_date", OleDbType.VarChar ).Value = sql;
				myDB.Command.Parameters.Add ( "ID", OleDbType.Integer ).Value = mID;
				try {
					myDB.Command.ExecuteNonQuery ();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "추가 저장하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}

				lblUpdateDate.Text = DateTime.Today.ToString ( "yyyy-MM-dd" );
				lblDeleteDate.Text = DataToDate ( sql );
				int cnt = dataGrid.CurrentRow.Index;
				dataGrid["kor_name", cnt].Value = inKorName.Value;
				dataGrid["eng_name", cnt].Value = inEngName.Value;
				dataGrid["birthdate", cnt].Value = inBirth.Text;
				dataGrid["p1_number", cnt].Value = inPhone1Num.Text;
				dataGrid["postal_code", cnt].Value = inPostalCode.Text;
				dataGrid["address", cnt].Value = inAddress.Text + ' ' + inCity.Text + ", " + inState.Text + ".";
				dataGrid.Refresh ();
				addSW = false;
				updateSW = true;
				changeSW = false;
				ChangeButtonStatusAll ( true, false, false, true );
				inKorName.Focus ();
			}
		}

		private void MoveRecord () {
			int iID;
			myDB.Command.Parameters.Add ( "kor_name", OleDbType.VarChar ).Value = inKorName.Text;
			myDB.Command.Parameters.Add ( "eng_name", OleDbType.VarChar ).Value = inEngName.Text;
			if ( inManCheck.Checked ) iID = 1; else iID = 0;
			myDB.Command.Parameters.Add ( "man", OleDbType.Integer ).Value = iID;
			myDB.Command.Parameters.Add ( "birthdate", OleDbType.VarChar ).Value = inBirth.Value;
			if ( inLunarCheck.Checked ) iID = 1; else iID = 0;
			myDB.Command.Parameters.Add ( "lunar", OleDbType.Integer ).Value = iID;
			if ( inMarryCheck.Checked ) iID = 1; else iID = 0;
			myDB.Command.Parameters.Add ( "married", OleDbType.Integer ).Value = iID;
			if ( inDutyCombo.SelectedIndex < 0 ) iID = 0; else iID = nDutyID[inDutyCombo.SelectedIndex];
			myDB.Command.Parameters.Add ( "duty", OleDbType.Integer ).Value = iID;
			if ( inHouseHolderCombo.SelectedIndex < 0 ) iID = mID; else iID = nBelieverID[inHouseHolderCombo.SelectedIndex];
			myDB.Command.Parameters.Add ( "householder", OleDbType.Integer ).Value = iID;
			if ( inRelationCombo.SelectedIndex < 0 ) iID = 0; else iID = nRelationID[inRelationCombo.SelectedIndex];
			myDB.Command.Parameters.Add ( "relation", OleDbType.Integer ).Value = iID;
			myDB.Command.Parameters.Add ( "email", OleDbType.VarChar ).Value = inEMail.Text;
			myDB.Command.Parameters.Add ( "p1-number", OleDbType.VarChar ).Value = inPhone1Num.Value;
			myDB.Command.Parameters.Add ( "p1-remark", OleDbType.VarChar ).Value = inPhone1Remark.Value;
			myDB.Command.Parameters.Add ( "p2-number", OleDbType.VarChar ).Value = inPhone2Num.Value;
			myDB.Command.Parameters.Add ( "p2-remark", OleDbType.VarChar ).Value = inPhone2Remark.Value;
			myDB.Command.Parameters.Add ( "p3-number", OleDbType.VarChar ).Value = inPhone3Num.Value;
			myDB.Command.Parameters.Add ( "p3-remark", OleDbType.VarChar ).Value = inPhone3Remark.Value;
			myDB.Command.Parameters.Add ( "postal-code", OleDbType.VarChar ).Value = inPostalCode.Value;
			myDB.Command.Parameters.Add ( "address", OleDbType.VarChar ).Value = inAddress.Value;
			myDB.Command.Parameters.Add ( "city", OleDbType.VarChar ).Value = inCity.Value;
			myDB.Command.Parameters.Add ( "state", OleDbType.VarChar ).Value = inState.Value;
			if ( inPayCodeCombo.SelectedIndex < 0 ) iID = mID; else iID = nBelieverID[inPayCodeCombo.SelectedIndex];
			myDB.Command.Parameters.Add ( "pay_code", OleDbType.Integer ).Value = iID;
			myDB.Command.Parameters.Add ( "remark", OleDbType.VarChar ).Value = inRemark.Value;
			myDB.Command.Parameters.Add ( "deleted", OleDbType.Integer ).Value = inDeletedCombo.SelectedIndex;
		}

		private string DateToData (string str) {
			if (str.Length != 10) return str;
			string iStr = str.Substring(0, 4) + str.Substring(5, 2) + str.Substring(8, 2);
			return iStr;
		}
	
		private string DataToDate (string str) {
			if ( str.Length != 8 ) return str;
			string iStr = str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2);
			return iStr;
		}
	}
}
