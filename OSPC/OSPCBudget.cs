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

	public partial class OSPCBudget : Form {
		
		const int nBasicYear = 2013;

		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;
		int nYear;
		bool nFirstSW, nEditSW, nChangeSW;

		public OSPCBudget () {
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

		private void btnSave_Click ( object sender, EventArgs e ) {
			string sql;
			for ( int i = 0; i < gridBG.Rows.Count; i++ ) {
				sql = "		UPDATE budget SET bg_budget=? ";
				sql += "		WHERE bg_year=? AND bg_gubun=? AND bg_hang_code=? AND bg_mok_code=?";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "bg_budget", OleDbType.Double ).Value = gridBG["budget", i].Value;
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
			} else {
				btnRun.Text = "취소";
				btnRun.Image = Properties.Resources.Alerts;
			}
			nChangeSW = false;
			btnSave.Visible = false;
		}

		private void FillGrid () {
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
	}
}
