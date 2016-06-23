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

	public partial class OSPCCheque : Form {
	
		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;
		bool mFirst = true, mCheck;
		
		public OSPCCheque () {
			InitializeComponent ();
			if ( !myDB.OpenDB () ) this.Close ();
		}

		private void OSPCCheque_Activated ( object sender, EventArgs e ) {
			if ( mFirst ) {
				mFirst = false;
				FillRecordToGrid ( true );
			}
		}

		private void btnClose_Click ( object sender, EventArgs e ) {
			myDB.CloseDB ();
			this.Close ();
		}

		private void btnChange_Click ( object sender, EventArgs e ) {
			if ( mCheck ) {
				FillRecordToGrid ( false );
				btnChange.Text = "미확인체크로";
			} else {
				FillRecordToGrid ( true );
				btnChange.Text = "확인된체크로";
			}
		}

		private void btnSave_Click ( object sender, EventArgs e ) {

			int iCheck;

			if ( mCheck ) iCheck = 1; else iCheck = 0;
			string iSql = "UPDATE [transaction] SET tr_cheque_ok=?, tr_cheque_date=? ";
			iSql += "WHERE tr_date=? AND tr_seq=?";
			myDB.CommandSQL = iSql;
	
			for ( int i = 0; i < gridTrans.Rows.Count; i++ ) {
				if ( (bool) gridTrans["gr_selected", i].Value ) {
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_cheque_ok", OleDbType.Integer ).Value = iCheck;
					myDB.Command.Parameters.Add ( "tr_cheque_date", OleDbType.VarChar ).Value = gridTrans["gr_cheque_date", i].Value.ToString ().Replace ( "-", "" );
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = gridTrans["tr_date", i].Value;
					myDB.Command.Parameters.Add ( "tr_seq", OleDbType.Integer ).Value = (int) gridTrans["tr_seq", i].Value;
					try {
						myDB.Command.ExecuteNonQuery ();
					} catch ( OleDbException ex ) {
						MessageBox.Show ( "변경 저장하는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
						return;
					}
				}
			}
			FillRecordToGrid ( mCheck );
		}

		private void gridTrans_CellClick ( object sender, DataGridViewCellEventArgs e ) {
			if ( e.RowIndex < 0 ) return;
			int i = e.RowIndex;
			if ( (bool) gridTrans["gr_selected", i].Value ) {
				gridTrans["gr_selected", i].Value = false;
				gridTrans["gr_date", i].Style.BackColor = Color.White;
				gridTrans["gr_believer", i].Style.BackColor = Color.White;
				gridTrans["gr_hang", i].Style.BackColor = Color.White;
				gridTrans["gr_mok", i].Style.BackColor = Color.White;
				gridTrans["gr_amount", i].Style.BackColor = Color.White;
				gridTrans["gr_cheque_no", i].Style.BackColor = Color.White;
				gridTrans["gr_cheque_date", i].Style.BackColor = Color.White;
				gridTrans["gr_remark", i].Style.BackColor = Color.White;
			} else {
				if ( mCheck ) {
					DateDialog diag = new DateDialog ( gridTrans["gr_date", i].Value.ToString ().Replace ( "-", "" ), gridTrans["gr_cheque_date", i].Value.ToString ().Replace ( "-", "" ) );
					if ( diag.ShowDialog () == DialogResult.OK ) {
						string idate = diag.InputDate;
						gridTrans["gr_selected", i].Value = true;
						gridTrans["gr_date", i].Style.BackColor = Color.Goldenrod;
						gridTrans["gr_believer", i].Style.BackColor = Color.Goldenrod;
						gridTrans["gr_hang", i].Style.BackColor = Color.Goldenrod;
						gridTrans["gr_mok", i].Style.BackColor = Color.Goldenrod;
						gridTrans["gr_amount", i].Style.BackColor = Color.Goldenrod;
						gridTrans["gr_cheque_no", i].Style.BackColor = Color.Goldenrod;
						gridTrans["gr_cheque_date", i].Style.BackColor = Color.Goldenrod;
						gridTrans["gr_cheque_date", i].Value = idate.Substring ( 0, 4 ) + "-" + idate.Substring ( 4, 2 ) + "-" + idate.Substring ( 6, 2 );
						gridTrans["gr_remark", i].Style.BackColor = Color.Goldenrod;
					}
				} else {
					gridTrans["gr_selected", i].Value = true;
					gridTrans["gr_date", i].Style.BackColor = Color.Goldenrod;
					gridTrans["gr_believer", i].Style.BackColor = Color.Goldenrod;
					gridTrans["gr_hang", i].Style.BackColor = Color.Goldenrod;
					gridTrans["gr_mok", i].Style.BackColor = Color.Goldenrod;
					gridTrans["gr_amount", i].Style.BackColor = Color.Goldenrod;
					gridTrans["gr_cheque_no", i].Style.BackColor = Color.Goldenrod;
					gridTrans["gr_cheque_date", i].Style.BackColor = Color.Goldenrod;
					gridTrans["gr_remark", i].Style.BackColor = Color.Goldenrod;
				}
			}
		}
		//
		// Method: 데이터를 읽어 그리드 컨트롤을 채운다. (바인드 안함)
		private void FillRecordToGrid ( bool fillMethod ) {

			mCheck = fillMethod;
			string sql = "SELECT tr_date, tr_seq, [believers].kor_name AS tr_believer_name, [hang_title].hang AS tr_hang_name, ";
			sql += "[mok_title].mok AS tr_mok_name, tr_amount, tr_cheque_no, tr_cheque_date, tr_remark ";
			sql += "FROM [transaction], [believers], [hang_title], [mok_title] ";
			sql += "WHERE [believers].ID = [transaction].tr_believer_code AND [hang_title].ID = [transaction].tr_hang_code AND ";
			sql += "[mok_title].ID = [transaction].tr_mok_code AND tr_gubun = 1 AND tr_iscash = 0 AND tr_date <= FORMAT(NOW(), 'yyyyMMdd') AND ([transaction].tr_date >= ?) AND (tr_cheque_ok = ?) ORDER BY tr_date";

			int idx;
			if ( fillMethod ) idx = 0; else idx = 1;
			DateTime iFrom = new DateTime ( DateTime.Today.Year - 1, DateTime.Today.Month, DateTime.Today.Day ); // 전년

			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = iFrom.ToString ( "yyyyMMdd" );
			myDB.Command.Parameters.Add ( "tr_cheque_ok", OleDbType.Integer ).Value = idx;
			try {
				mReader = myDB.Command.ExecuteReader ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( ex.Message );
				return;
			}
			int index = 0; gridTrans.Rows.Clear ();
			while ( mReader.Read () ) {
				gridTrans.RowCount = index + 1;
				gridTrans["tr_date", index].Value = mReader["tr_date"];
				gridTrans["tr_seq", index].Value = mReader["tr_seq"];
				gridTrans["gr_selected", index].Value = false;
				gridTrans["gr_date", index].Value = mReader["tr_date"].ToString ().Substring ( 0, 4 ) + "-" + mReader["tr_date"].ToString ().Substring ( 4, 2 ) + "-" + mReader["tr_date"].ToString ().Substring ( 6, 2 );
				gridTrans["gr_believer", index].Value = mReader["tr_believer_name"];
				gridTrans["gr_hang", index].Value = mReader["tr_hang_name"];
				gridTrans["gr_mok", index].Value = mReader["tr_mok_name"];
				gridTrans["gr_amount", index].Value = mReader["tr_amount"];
				gridTrans["gr_cheque_no", index].Value = mReader["tr_cheque_no"];
				gridTrans["gr_cheque_date", index].Value = mReader["tr_cheque_date"].ToString ().Substring ( 0, 4 ) + "-" + mReader["tr_cheque_date"].ToString ().Substring ( 4, 2 ) + "-" + mReader["tr_cheque_date"].ToString ().Substring ( 6, 2 );
				gridTrans["gr_remark", index++].Value = mReader["tr_remark"];
			}
			mReader.Close ();
		}
	}
}
