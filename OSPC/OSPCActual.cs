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
	
	public partial class OSPCActual : Form {
		
		const int nBasicYear = 2013;
		const int nBuilding = 8;
		const int nGospel = 6;
		const int nHelp = 9;

		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;
		OSPCModules mesg = new OSPCModules ();
		int nYear;
		bool nFirstSW, nEditSW, nChangeSW;

		public OSPCActual () {
			nFirstSW = true; nEditSW = false; nChangeSW = false;
			InitializeComponent ();
			myDB.OpenDB ();
			InitialButtonStatus ( true );
			FillYearCombo ();
		}

		private void btnClose_Click ( object sender, EventArgs e ) {
			myDB.CloseDB ();
			this.Close ();
		}

		private void inYear_SelectedIndexChanged ( object sender, EventArgs e ) {
			nYear = inYear.SelectedIndex + nBasicYear;
		}

		private void OSPCBudget_Activated ( object sender, EventArgs e ) {
			if ( !nFirstSW ) return;
			nFirstSW = false;

			SetYearCombo ( DateTime.Today.Year );
		}

		private void btnRun_Click ( object sender, EventArgs e ) {
			if ( nEditSW ) {
				nEditSW = false;
				InitialButtonStatus ( true );
				gridBG.Rows.Clear ();
			} else {
				nEditSW = true;
				InitialButtonStatus ( false );
				nFirstSW = true;
				FillGrid ();
				nFirstSW = false;
			}
		}

		private void btnMake_Click ( object sender, EventArgs e ) {
			if ( MessageBox.Show ( "이전에 했던 동일년도 결산 자료는 삭제됩니다. \n계속하시겠습니까?", "질문있어요", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk ) == DialogResult.No ) return;
			this.Refresh ();
			mesg.MessageON ( this, "자료를 읽는 중이니 잠시 기다리세요." );
			nEditSW = true;
			InitialButtonStatus ( false );
			nFirstSW = true;
			FillGrid ();
			nFirstSW = false;
			MakeTableRptBookCash ();
			MakeTableRptBookOther ( nBuilding );
			MakeTableRptBookOther ( nGospel );
			MakeTableRptBookOther ( nHelp );
			string sql;
			double iAmt;
			for ( int i = 0; i < gridBG.Rows.Count; i++ ) {
				sql = "		SELECT SUM(IIF(ISNULL(tr_amount), 0, tr_amount)) ";
				sql += "		FROM [transaction] WHERE LEFT(tr_date, 4) = '" + nYear.ToString() + "' ";
				sql += "			AND tr_gubun = ? AND tr_hang_code = ? AND tr_mok_code = ? ";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "tr_gubun", OleDbType.Integer ).Value = gridBG["gubun", i].Value;
				myDB.Command.Parameters.Add ( "tr_hang_code", OleDbType.Integer ).Value = gridBG["hang_code", i].Value;
				myDB.Command.Parameters.Add ( "tr_mok_code", OleDbType.Integer ).Value = gridBG["mok_code", i].Value;
				try {
					iAmt = Convert.ToDouble ( myDB.Command.ExecuteScalar () );
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				} catch ( Exception ) {
					iAmt = 0;
				}

				sql = "		UPDATE budget SET bg_actual=? ";
				sql += "		WHERE bg_year=? AND bg_gubun=? AND bg_hang_code=? AND bg_mok_code=?";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "bg_actual", OleDbType.Double ).Value = iAmt;
				myDB.Command.Parameters.Add ( "bg_year", OleDbType.VarChar ).Value = gridBG["year", i].Value;
				myDB.Command.Parameters.Add ( "bg_gubun", OleDbType.Integer ).Value = gridBG["gubun", i].Value;
				myDB.Command.Parameters.Add ( "bg_hang_code", OleDbType.Integer ).Value = gridBG["hang_code", i].Value;
				myDB.Command.Parameters.Add ( "bg_mok_code", OleDbType.Integer ).Value = gridBG["mok_code", i].Value;
				try {
					myDB.Command.ExecuteNonQuery ();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}
			}
			nEditSW = true;
			InitialButtonStatus ( false );
			nFirstSW = true;
			FillGrid ();
			nFirstSW = false;
			btnSave.Visible = true;
			btnMake.Visible = false;
			mesg.MessageOFF ( this );
			MessageBox.Show ( "자료를 정상적으로 읽었습니다." );
		}

		private void btnSave_Click ( object sender, EventArgs e ) {
			string sql;
			for ( int i = 0; i < gridBG.Rows.Count; i++ ) {
				sql = "		UPDATE budget SET bg_actual=? ";
				sql += "		WHERE bg_year=? AND bg_gubun=? AND bg_hang_code=? AND bg_mok_code=?";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "bg_actual", OleDbType.Double ).Value = gridBG["actual", i].Value;
				myDB.Command.Parameters.Add ( "bg_year", OleDbType.VarChar ).Value = gridBG["year", i].Value;
				myDB.Command.Parameters.Add ( "bg_gubun", OleDbType.Integer ).Value = gridBG["gubun", i].Value;
				myDB.Command.Parameters.Add ( "bg_hang_code", OleDbType.Integer ).Value = gridBG["hang_code", i].Value;
				myDB.Command.Parameters.Add ( "bg_mok_code", OleDbType.Integer ).Value = gridBG["mok_code", i].Value;
				try {
					myDB.Command.ExecuteNonQuery ();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}
			}
			nEditSW = false;
			InitialButtonStatus ( true );
			gridBG.Rows.Clear ();
		}

		private void gridBG_CellValueChanged ( object sender, DataGridViewCellEventArgs e ) {
			if ( nFirstSW || nChangeSW ) return;
			nChangeSW = true;
			btnSave.Visible = true;
		}

		private void FillYearCombo () {
			inYear.Items.Clear ();
			for ( int i = 0; i < 20; i++ )
				inYear.Items.Add ( ( nBasicYear + i ).ToString () + "년" );
		}

		private void SetYearCombo ( int sYear ) {
			for ( int i = 0; i < 20; i++ )
				if ( sYear == nBasicYear + i ) inYear.SelectedIndex = i;
		}

		private void InitialButtonStatus ( bool iEdit ) {
			if ( iEdit ) {
				btnRun.Text = "편집";
				btnRun.Image = Properties.Resources.GoToNextHS;
				btnMake.Visible = true;
			} else {
				btnRun.Text = "취소";
				btnRun.Image = Properties.Resources.Alerts;
				btnMake.Visible = false;
			}
			nChangeSW = false;
			btnSave.Visible = false;
		}

		private void FillGrid () {
			gridBG.Rows.Clear ();
			int iCnt = 0;
			string sql = "";
			sql += "	SELECT bg_year, bg_gubun, bg_hang_code, hang AS bg_hang_name, bg_mok_code, ";
			sql += "		mok AS bg_mok_name, bg_budget, bg_actual";
			sql += "	FROM budget, hang_title, mok_title ";
			sql += "	WHERE hang_title.ID = bg_hang_code AND mok_title.ID = bg_mok_code AND bg_year = '" + nYear.ToString() + "'";
			sql += "	ORDER BY 1, 2, 3, 5";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				gridBG.Rows.Add ( 1 );
				gridBG["year", iCnt].Value = mReader["bg_year"];
				gridBG["gubun", iCnt].Value = mReader["bg_gubun"];
				gridBG["hang_code", iCnt].Value = mReader["bg_hang_code"];
				gridBG["hang_name", iCnt].Value = mReader["bg_hang_name"];
				gridBG["mok_code", iCnt].Value = mReader["bg_mok_code"];
				gridBG["mok_name", iCnt].Value = mReader["bg_mok_name"];
				gridBG["budget", iCnt].Value = mReader["bg_budget"];
				gridBG["actual", iCnt].Value = mReader["bg_actual"];
				iCnt++;
			}
			mReader.Close ();
			if ( iCnt == 0 ) {
				sql = "		INSERT INTO budget";
				sql += "		SELECT '" + nYear.ToString() + "' AS bg_year, gubun AS bg_gubun, hang_code AS bg_hang_code, ";
				sql += "			ID AS bg_mok_code, 0 AS bg_budget, 0 AS bg_actual";
				sql += "		FROM mok_title";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				try {
					myDB.Command.ExecuteNonQuery();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}
				FillGrid();
			}
		}

		private void MakeTableRptBookCash () {
			string nFromDate = nYear + "0101";
			string nToDate = nYear + "1231";
			double iVal;
			string sql;
			sql = "	 SELECT SUM(t1_credit) - SUM(t1_debit) AS cb_bal ";
			sql += "	FROM ";
			sql += "	( ";
			sql += "	SELECT bk_credit AS t1_credit, bk_debit AS t1_debit ";
			sql += "		FROM books WHERE bk_mok_code = 0 AND bk_year = '" + ( nYear - 1 ).ToString () + "' ";
			sql += "	UNION";
			sql += "	SELECT IIF( tr_gubun=0, tr_amount, 0) AS t1_credit, IIF( tr_gubun=1, tr_amount, 0) AS t1_debit ";
			sql += "		FROM [transaction] WHERE tr_date BETWEEN '" + nFromDate + "' AND '" + nToDate + "'";
			sql += "		AND (tr_iscash = 1 OR (tr_iscash = 0 AND tr_cheque_ok = 1))";
			sql += "	) ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				iVal = Convert.ToDouble(myDB.Command.ExecuteScalar ());
			} catch ( OleDbException ) {
				iVal = 0;
			}
 
			sql = "	 INSERT INTO books (bk_year, bk_mok_code, bk_credit, bk_debit) ";
			sql += "	VALUES (?, ?, ?, ?) ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "bk_year", OleDbType.VarChar ).Value = nYear;
			myDB.Command.Parameters.Add ( "bk_mok_code", OleDbType.Integer ).Value = 0;
			if ( iVal < 0 ) {
				myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = 0;
				myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = iVal * (-1);
			} else {
				myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = iVal;
				myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = 0;
			}
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
				sql = "	 UPDATE books SET bk_credit=?, bk_debit=? ";
				sql += "	WHERE bk_year=? AND bk_mok_code=? ";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				if ( iVal < 0 ) {
					myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = 0;
					myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = iVal * ( -1 );
				} else {
					myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = iVal;
					myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = 0;
				}
				myDB.Command.Parameters.Add ( "bk_year", OleDbType.VarChar ).Value = nYear;
				myDB.Command.Parameters.Add ( "bk_mok_code", OleDbType.Integer ).Value = 0;
				try {
					myDB.Command.ExecuteNonQuery ();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "작업을 수행하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}
			}
		}

		private void MakeTableRptBookOther ( int iMokCode ) {
			double iVal;
			string nFromDate = nYear + "0101";
			string nToDate = nYear + "1231";
			string sql;
			sql = "	 SELECT SUM(t1_credit) - SUM(t1_debit) AS cb_bal ";
			sql += "	FROM ";
			sql += "	( ";
			sql += "		SELECT bk_credit AS t1_credit, bk_debit AS t1_debit ";
			sql += "			FROM books WHERE bk_mok_code = " + iMokCode.ToString() + " AND bk_year = '" + ( nYear - 1 ).ToString () + "'";
			sql += "		UNION ";
			sql += "		SELECT tr_amount AS t1_credit, 0 AS t1_debit ";
			sql += "			FROM [transaction], hang_title, mok_title ";
			sql += "			WHERE hang_title.ID=[transaction].tr_hang_code AND mok_title.ID=[transaction].tr_mok_code ";
			sql += "				AND tr_date BETWEEN '" + nFromDate + "' AND '" + nToDate + "' AND tr_hang_code = 1 AND ";
			if ( iMokCode == nBuilding ) sql += "fund_building = true ";
			else if ( iMokCode == nGospel ) sql += "fund_gospel = true ";
			else sql += "fund_help = true ";
			sql += "		UNION";
			sql += "		SELECT IIF( tr_gubun=0, tr_amount, 0) AS t1_credit, IIF( tr_gubun=1, tr_amount, 0) AS t2_debit ";
			sql += "			FROM [transaction], hang_title, mok_title, believers WHERE hang_title.ID = tr_hang_code AND  ";
			sql += "				mok_title.ID = tr_mok_code AND believers.ID = tr_believer_code AND tr_date BETWEEN '" + nFromDate + "' AND '" + nToDate + "'";
			sql += "				AND tr_hang_code <> 1 AND ";
			if ( iMokCode == nBuilding ) sql += "fund_building = true ";
			else if ( iMokCode == nGospel ) sql += "fund_gospel = true ";
			else sql += "fund_help = true ";
			sql += "	) ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				iVal = Convert.ToDouble ( myDB.Command.ExecuteScalar () );
			} catch ( OleDbException ) {
				iVal = 0;
			}
			sql = "	 INSERT INTO books (bk_year, bk_mok_code, bk_credit, bk_debit) ";
			sql += "	VALUES (?, ?, ?, ?) ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "bk_year", OleDbType.VarChar ).Value = nYear;
			myDB.Command.Parameters.Add ( "bk_mok_code", OleDbType.Integer ).Value = iMokCode;
			if ( iVal < 0 ) {
				myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = 0;
				myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = iVal * ( -1 );
			} else {
				myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = iVal;
				myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = 0;
			}
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
				sql = "	 UPDATE books SET bk_credit=?, bk_debit=? ";
				sql += "	WHERE bk_year=? AND bk_mok_code=? ";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				if ( iVal < 0 ) {
					myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = 0;
					myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = iVal * ( -1 );
				} else {
					myDB.Command.Parameters.Add ( "bk_credit", OleDbType.Double ).Value = iVal;
					myDB.Command.Parameters.Add ( "bk_debit", OleDbType.Double ).Value = 0;
				}
				myDB.Command.Parameters.Add ( "bk_year", OleDbType.VarChar ).Value = nYear;
				myDB.Command.Parameters.Add ( "bk_mok_code", OleDbType.Integer ).Value = iMokCode;
				try {
					myDB.Command.ExecuteNonQuery ();
				} catch ( OleDbException ex ) {
					MessageBox.Show ( "작업을 수행하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
					return;
				}
			}
		}
	}
}
