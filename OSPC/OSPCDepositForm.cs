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

	public partial class OSPCDepositForm : Form {

		const int nTrGubun = 0, nTrHangCode = 1, nMaxCheq = 10, nMaxCash = 8;

		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;

		private List<MultiBoxControls.GeneralTextBox> nNo, nCheq, nCash;
		string nTrDate, mSaveText;
		double nTotal;
		bool mInsertMode;
		int nCount;

		public OSPCDepositForm () {
			InitializeComponent ();
			// 데이터베이스를 OPEN 함
			if ( !myDB.OpenDB () ) this.Close ();

			inDate.DateSelected = DateTime.Today; // 오늘 날짜를 선택 함
			nTrDate = inDate.DateSelected.ToString ( "yyyyMMdd" );
			FillGridTotal ();
			ReloadDeposit ();
			nNo[0].Focus ();
		}
		//
		// Event: 저장
		private void btnSave_Click ( object sender, EventArgs e ) {
			if ( mInsertMode ) {
				string iSql = "INSERT INTO deposit (df_date, cash100_amt, cash50_amt, cash20_amt, cash10_amt, cash5_amt, cash2_amt, ";
				iSql += "cash1_amt, coin_amt, cheque0_no, cheque1_no, cheque2_no, cheque3_no, cheque4_no, cheque5_no, cheque6_no, ";
				iSql += "cheque7_no, cheque8_no, cheque9_no, cheque0_amt, cheque1_amt, cheque2_amt, cheque3_amt, cheque4_amt, ";
				iSql += "cheque5_amt, cheque6_amt, cheque7_amt, cheque8_amt, cheque9_amt) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
				myDB.CommandSQL = iSql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "df_date", OleDbType.VarChar ).Value = nTrDate;
				myDB.Command.Parameters.Add ( "cash100_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[0].Value );
				myDB.Command.Parameters.Add ( "cash50_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[1].Value );
				myDB.Command.Parameters.Add ( "cash20_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[2].Value );
				myDB.Command.Parameters.Add ( "cash10_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[3].Value );
				myDB.Command.Parameters.Add ( "cash5_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[4].Value );
				myDB.Command.Parameters.Add ( "cash2_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[5].Value );
				myDB.Command.Parameters.Add ( "cash1_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[6].Value );
				myDB.Command.Parameters.Add ( "coin_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCash[7].Value );
				myDB.Command.Parameters.Add ( "cheque0_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[0].Value );
				myDB.Command.Parameters.Add ( "cheque1_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[1].Value );
				myDB.Command.Parameters.Add ( "cheque2_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[2].Value );
				myDB.Command.Parameters.Add ( "cheque3_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[3].Value );
				myDB.Command.Parameters.Add ( "cheque4_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[4].Value );
				myDB.Command.Parameters.Add ( "cheque5_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[5].Value );
				myDB.Command.Parameters.Add ( "cheque6_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[6].Value );
				myDB.Command.Parameters.Add ( "cheque7_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[7].Value );
				myDB.Command.Parameters.Add ( "cheque8_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[8].Value );
				myDB.Command.Parameters.Add ( "cheque9_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[9].Value );
				myDB.Command.Parameters.Add ( "cheque0_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[0].Value );
				myDB.Command.Parameters.Add ( "cheque1_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[1].Value );
				myDB.Command.Parameters.Add ( "cheque2_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[2].Value );
				myDB.Command.Parameters.Add ( "cheque3_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[3].Value );
				myDB.Command.Parameters.Add ( "cheque4_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[4].Value );
				myDB.Command.Parameters.Add ( "cheque5_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[5].Value );
				myDB.Command.Parameters.Add ( "cheque6_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[6].Value );
				myDB.Command.Parameters.Add ( "cheque7_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[7].Value );
				myDB.Command.Parameters.Add ( "cheque8_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[8].Value );
				myDB.Command.Parameters.Add ( "cheque9_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[9].Value );
				myDB.ExeBasic ();
				btnSave.Enabled = false;
				btnPrint.Enabled = true;
			} else {
				string iSql = "UPDATE deposit SET cash100_amt=?, cash50_amt=?, cash20_amt=?, cash10_amt=?, cash5_amt=?, ";
				iSql += "cash2_amt=?, cash1_amt=?, coin_amt=?, cheque0_no=?, cheque1_no=?, cheque2_no=?, cheque3_no=?, ";
				iSql += "cheque4_no=?, cheque5_no=?, cheque6_no=?, cheque7_no=?, cheque8_no=?, cheque9_no=?, cheque0_amt=?, ";
				iSql += "cheque1_amt=?, cheque2_amt=?, cheque3_amt=?, cheque4_amt=?, cheque5_amt=?, cheque6_amt=?, cheque7_amt=?, ";
				iSql += "cheque8_amt=?, cheque9_amt=? WHERE df_date=?"; 
				myDB.CommandSQL = iSql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "cash100_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[0].Value );
				myDB.Command.Parameters.Add ( "cash50_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[1].Value );
				myDB.Command.Parameters.Add ( "cash20_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[2].Value );
				myDB.Command.Parameters.Add ( "cash10_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[3].Value );
				myDB.Command.Parameters.Add ( "cash5_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[4].Value );
				myDB.Command.Parameters.Add ( "cash2_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[5].Value );
				myDB.Command.Parameters.Add ( "cash1_amt", OleDbType.Integer ).Value = Convert.ToInt32 ( nCash[6].Value );
				myDB.Command.Parameters.Add ( "coin_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCash[7].Value );
				myDB.Command.Parameters.Add ( "cheque0_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[0].Value );
				myDB.Command.Parameters.Add ( "cheque1_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[1].Value );
				myDB.Command.Parameters.Add ( "cheque2_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[2].Value );
				myDB.Command.Parameters.Add ( "cheque3_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[3].Value );
				myDB.Command.Parameters.Add ( "cheque4_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[4].Value );
				myDB.Command.Parameters.Add ( "cheque5_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[5].Value );
				myDB.Command.Parameters.Add ( "cheque6_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[6].Value );
				myDB.Command.Parameters.Add ( "cheque7_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[7].Value );
				myDB.Command.Parameters.Add ( "cheque8_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[8].Value );
				myDB.Command.Parameters.Add ( "cheque9_no", OleDbType.Integer ).Value = Convert.ToInt32 ( nNo[9].Value );
				myDB.Command.Parameters.Add ( "cheque0_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[0].Value );
				myDB.Command.Parameters.Add ( "cheque1_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[1].Value );
				myDB.Command.Parameters.Add ( "cheque2_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[2].Value );
				myDB.Command.Parameters.Add ( "cheque3_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[3].Value );
				myDB.Command.Parameters.Add ( "cheque4_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[4].Value );
				myDB.Command.Parameters.Add ( "cheque5_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[5].Value );
				myDB.Command.Parameters.Add ( "cheque6_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[6].Value );
				myDB.Command.Parameters.Add ( "cheque7_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[7].Value );
				myDB.Command.Parameters.Add ( "cheque8_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[8].Value );
				myDB.Command.Parameters.Add ( "cheque9_amt", OleDbType.Double ).Value = Convert.ToDouble ( nCheq[9].Value );
				myDB.Command.Parameters.Add ( "df_date", OleDbType.VarChar ).Value = nTrDate;
				myDB.ExeBasic ();
				btnSave.Enabled = false;
				btnPrint.Enabled = true;
			}
			nNo[0].Focus ();
		}
		//
		// Event: 금액이 변경되었는지 체크
		private void OSPCDepositForm_CheqEnter ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox cn = (MultiBoxControls.GeneralTextBox) sender;
			mSaveText = cn.Value;
		}
		private void OSPCDepositForm_CheqLeave ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox cn = (MultiBoxControls.GeneralTextBox) sender;
			if ( cn.Value != mSaveText ) {
				if ( !btnSave.Enabled ) btnSave.Enabled = true;
				ComputeTotal ();
			}
		}
		private void OSPCDepositForm_CashEnter ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox cn = (MultiBoxControls.GeneralTextBox) sender;
			mSaveText = cn.Value;
		}
		private void OSPCDepositForm_CashLeave ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox cn = (MultiBoxControls.GeneralTextBox) sender;
			if ( cn.Value != mSaveText ) {
				if ( !btnSave.Enabled ) btnSave.Enabled = true;
				ComputeTotal ();
			}
		}
		private void OSPCDepositForm_NoEnter ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox cn = (MultiBoxControls.GeneralTextBox) sender;
			mSaveText = cn.Value;
		}
		private void OSPCDepositForm_NoLeave ( object sender, EventArgs e ) {
			MultiBoxControls.GeneralTextBox cn = (MultiBoxControls.GeneralTextBox) sender;
			if ( cn.Value != mSaveText ) {
				if ( !btnSave.Enabled ) btnSave.Enabled = true;
			}
		}
		//
		// Event: 인쇄를 클릭하였음
		private void btnPrint_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCSimpleReport ( 2, nTrDate, nCount );
			newform.ShowDialog ();
		}
		//
		// Event: 닫기 버튼을 눌렀음
		private void btnClose_Click ( object sender, EventArgs e ) {
			myDB.CloseDB ();
			this.Close ();
		}
		//
		// Event: 날짜가 바뀌었음
		private void inDate_NewDateSelected ( object sender, EventArgs e ) {
			nTrDate = inDate.DateSelected.ToString ( "yyyyMMdd" );
			ReloadTransaction ();
			ReloadDeposit ();
			nNo[0].Focus ();
		}
		private void ComputeTotal () {
			double iCheque = 0; nCount = 0;
			for ( int i = 0; i < nMaxCheq; i++ ) {
				iCheque += Convert.ToDouble ( nCheq[i].Value );
				if ( Convert.ToDouble ( nCheq[i].Value ) > 0 ) nCount++;
			}
			double iCash = 0, iTemp = 0;
			int iCnt = 0;
			for ( int i = 0; i < nMaxCash; i++ ) {
				if ( i == 7 ) {
					iTemp = Convert.ToDouble ( nCash[i].Value );
				} else {
					iCnt = Convert.ToInt32 ( nCash[i].Value );
					switch ( i ) {
						case 0: iTemp = iCnt * 100; break;
						case 1: iTemp = iCnt * 50; break;
						case 2: iTemp = iCnt * 20; break;
						case 3: iTemp = iCnt * 10; break;
						case 4: iTemp = iCnt * 5; break;
						case 5: iTemp = iCnt * 2; break;
						case 6: iTemp = iCnt; break;
					}
				}
				iCash += iTemp;
			}
			inCashTotal.Value = iCash.ToString ();
			inChequeTotal.Value = iCheque.ToString ();
			inTotal.Value = ( iCash + iCheque ).ToString ();
			lblStatus.Text = String.Format ( "{0:C} - {1:C} = {2:C}", nTotal, iCash + iCheque, nTotal - iCash - iCheque );
		}
		//
		// Method: Deposit Form 테이블을 다시 로드한다.
		private void ReloadDeposit () {
			myDB.CommandSQL = "SELECT cash100_amt, cash10_amt, cash1_amt, cash20_amt, cash2_amt, cash50_amt, cash5_amt, cheque0_amt, cheque0_no, cheque1_amt, cheque1_no, cheque2_amt, cheque2_no, cheque3_amt, cheque3_no, cheque4_amt, cheque4_no, cheque5_amt, cheque5_no, cheque6_amt, cheque6_no, cheque7_amt, cheque7_no, cheque8_amt, cheque8_no, cheque9_amt, cheque9_no, coin_amt, df_date FROM deposit WHERE (df_date = ?)";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "df_date", OleDbType.VarChar ).Value = nTrDate;
			mReader = myDB.ExeReader ();
			if ( mReader.Read() ) {
				nNo[0].Value = mReader["cheque0_no"].ToString();
				nNo[1].Value = mReader["cheque1_no"].ToString ();
				nNo[2].Value = mReader["cheque2_no"].ToString ();
				nNo[3].Value = mReader["cheque3_no"].ToString ();
				nNo[4].Value = mReader["cheque4_no"].ToString ();
				nNo[5].Value = mReader["cheque5_no"].ToString ();
				nNo[6].Value = mReader["cheque6_no"].ToString ();
				nNo[7].Value = mReader["cheque7_no"].ToString ();
				nNo[8].Value = mReader["cheque8_no"].ToString ();
				nNo[9].Value = mReader["cheque9_no"].ToString ();
				nCheq[0].Value = mReader["cheque0_amt"].ToString ();
				nCheq[1].Value = mReader["cheque1_amt"].ToString ();
				nCheq[2].Value = mReader["cheque2_amt"].ToString ();
				nCheq[3].Value = mReader["cheque3_amt"].ToString ();
				nCheq[4].Value = mReader["cheque4_amt"].ToString ();
				nCheq[5].Value = mReader["cheque5_amt"].ToString ();
				nCheq[6].Value = mReader["cheque6_amt"].ToString ();
				nCheq[7].Value = mReader["cheque7_amt"].ToString ();
				nCheq[8].Value = mReader["cheque8_amt"].ToString ();
				nCheq[9].Value = mReader["cheque9_amt"].ToString ();
				nCash[0].Value = mReader["cash100_amt"].ToString ();
				nCash[1].Value = mReader["cash50_amt"].ToString ();
				nCash[2].Value = mReader["cash20_amt"].ToString ();
				nCash[3].Value = mReader["cash10_amt"].ToString ();
				nCash[4].Value = mReader["cash5_amt"].ToString ();
				nCash[5].Value = mReader["cash2_amt"].ToString ();
				nCash[6].Value = mReader["cash1_amt"].ToString ();
				nCash[7].Value = mReader["coin_amt"].ToString ();
				ComputeTotal ();
				btnSave.Enabled = false;
				btnPrint.Enabled = true;
				mInsertMode = false;
			} else {
				for ( int i = 0; i < nMaxCheq; i++ ) {
					nNo[i].Value = "0";
					nCheq[i].Value = "0";
				}
				for ( int i = 0; i < nMaxCash; i++ )
					nCash[i].Value = "0";
				ComputeTotal ();
				nCount = 0;
				btnSave.Enabled = false;
				btnPrint.Enabled = false;
				mInsertMode = true;
			}
			mReader.Close ();
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
			nTotal = iSUM;
		}
		//
		// Method: gridTatal 그리드를 채움, 로드할 때 한 번만 실행
		private void FillGridTotal () {

			nNo = new List<MultiBoxControls.GeneralTextBox> ();
			nCheq = new List<MultiBoxControls.GeneralTextBox> ();
			nCash = new List<MultiBoxControls.GeneralTextBox> ();
			int iNoX = 120, iCheqX = 170, iCashX = 390, iY = 15, iJump = 30;
			for ( int i = 0; i < nMaxCheq; i++ ) {
				MultiBoxControls.GeneralTextBox inNo = new MultiBoxControls.GeneralTextBox ();
				inNo.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmNumber;
				inNo.MaxLength = 5;
				inNo.Size = new System.Drawing.Size(45, 25);
				inNo.Location = new Point(iNoX, iY);
				inNo.Tag = i;
				inNo.TabIndex = i * 2;
				nNo.Add ( inNo );
				nNo[i].Enter += new EventHandler ( OSPCDepositForm_NoEnter );
				nNo[i].Leave += new EventHandler ( OSPCDepositForm_NoLeave );
				panel2.Controls.Add ( nNo[i] );

				MultiBoxControls.GeneralTextBox inCheq = new MultiBoxControls.GeneralTextBox ();
				inCheq.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollar;
				inCheq.MaxLength = 15;
				inCheq.Size = new System.Drawing.Size(100, 25);
				inCheq.Location = new Point(iCheqX, iY);
				inCheq.Tag = i;
				inCheq.TabIndex = i * 2 + 1;
				nCheq.Add ( inCheq );
				nCheq[i].Enter += new EventHandler ( OSPCDepositForm_CheqEnter );
				nCheq[i].Leave += new EventHandler ( OSPCDepositForm_CheqLeave );
				panel2.Controls.Add ( nCheq[i] );

				if ( i < nMaxCash ) {
					MultiBoxControls.GeneralTextBox inCash = new MultiBoxControls.GeneralTextBox ();
					inCash.MaxLength = 15;
					inCash.Size = new System.Drawing.Size(100, 25);
					inCash.Location = new Point(iCashX, iY);
					inCash.Tag = i;
					inCash.TabIndex = i + 20;
					if ( i < nMaxCash - 1 ) {
						inCash.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmWon;
					} else {
						inCash.AAStyle = MultiBoxControls.GeneralTextBox.MBStyle.FmDollar;
					}
					nCash.Add ( inCash );
					nCash[i].Enter += new EventHandler ( OSPCDepositForm_CashEnter );
					nCash[i].Leave += new EventHandler ( OSPCDepositForm_CashLeave );
					panel2.Controls.Add ( nCash[i] );
				}

				iY += iJump;
			}

			myDB.CommandSQL = "SELECT ID, gubun, hang_code, mok FROM mok_title WHERE hang_code = ?";
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add("hang_code", OleDbType.Integer).Value = nTrHangCode;
			mReader = myDB.ExeReader ();

			gridTotal.RowCount = 1;
			gridTotal["title", 0].Value = "TOTAL";
			gridTotal["total", 0].Value = 0;
			gridTotal["title", 0].Style.BackColor = Color.Goldenrod;
			gridTotal["total", 0].Style.BackColor = Color.Goldenrod;
			int index = 1;
			while ( mReader.Read () ) {
				gridTotal.RowCount = index + 1;
				gridTotal["ID", index].Value = mReader["ID"];
				gridTotal["title", index].Value = mReader["mok"];
				gridTotal["total", index].Value = 0;
				gridTotal["selected", index].Value = false;
				gridTotal["title", index].Style.BackColor = Color.White;
				gridTotal["total", index++].Style.BackColor = Color.White;
			}
			mReader.Close ();
			ReloadTransaction ();
		}
	}
}
