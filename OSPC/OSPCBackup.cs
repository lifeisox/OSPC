using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MySql.Data;
//using MySql.Data.MySqlClient;

namespace OSPC {

	public partial class OSPCBackup : Form {
        //	string sqlConStr = @"Server=BeginAnew.db.10945885.hostedresource.com;Database=BeginAnew;Uid=BeginAnew;Pwd=withGOD@@2;";
        //	MySqlConnection sqlConn = new MySqlConnection();
        //	MySqlCommand sqlCmd = new MySqlCommand();
        //	MyDB myDB = new MyDB ();
        //	OleDbDataReader mReader;

        public OSPCBackup()
        {
            //		InitializeComponent ();
            //		myDB.OpenDB ();
            //		sqlConn.ConnectionString = sqlConStr;
            //		try {
            //			sqlConn.Open();
            //			sqlCmd.Connection = sqlConn;
            //			sqlCmd.CommandTimeout = 60;
            //			sqlCmd.UpdatedRowSource = UpdateRowSource.Both;
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show("SQL 데이터베이스 연결 도중 오류가 발생하였습니다.\n" + ex.Message );
            //		}
            //		inYear.Value = DateTime.Today.ToString ( "yyyy" );
            //		inDate.Value = DateTime.Today.ToString ( "yyyyMMdd" );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //		myDB.CloseDB ();
            //		sqlConn.Close ();
            //		sqlConn.Dispose ();
            //		this.Close ();
        }

        private void btnBasic_Click(object sender, EventArgs e)
        {
            //		proBar.Maximum = 8;
            //		proBar.Value = 1;
            //		// 기존 테이블을 삭제한다.
            //		string sql = "DELETE FROM believers";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "believers Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM believers";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO believers (ID, kor_name, eng_name, man, birthdate, lunar, married, duty, householder, ";
            //		sql += "	relation, email, p1_number, p1_remark, p2_number, p2_remark, p3_number, p3_remark, postal_code, ";
            //		sql += "	address, city, state, pay_code, remark, deleted, new_date, update_date, delete_date )";
            //		sql += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"; // 27개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "ID", MySqlDbType.Int32 ).Value = mReader["ID"];
            //			sqlCmd.Parameters.Add ( "kor_name", MySqlDbType.VarChar ).Value = mReader["kor_name"];
            //			sqlCmd.Parameters.Add ( "eng_name", MySqlDbType.VarChar ).Value = mReader["eng_name"];
            //			sqlCmd.Parameters.Add ( "man", MySqlDbType.Int32 ).Value = mReader["man"];
            //			sqlCmd.Parameters.Add ( "birthdate", MySqlDbType.VarChar ).Value = mReader["birthdate"];
            //			sqlCmd.Parameters.Add ( "lunar", MySqlDbType.Int32 ).Value = mReader["lunar"];
            //			sqlCmd.Parameters.Add ( "married", MySqlDbType.Int32 ).Value = mReader["married"];
            //			sqlCmd.Parameters.Add ( "duty", MySqlDbType.Int32 ).Value = mReader["duty"];
            //			sqlCmd.Parameters.Add ( "householder", MySqlDbType.Int32 ).Value = mReader["householder"];
            //			sqlCmd.Parameters.Add ( "relation", MySqlDbType.Int32 ).Value = mReader["relation"];
            //			sqlCmd.Parameters.Add ( "email", MySqlDbType.VarChar ).Value = String.IsNullOrEmpty ( (string)  mReader["email"]) ? "" : mReader["email"];
            //			sqlCmd.Parameters.Add ( "p1_number", MySqlDbType.VarChar ).Value = String.IsNullOrEmpty ( (string) mReader["p1_number"] ) ? "" : mReader["p1_number"];
            //			sqlCmd.Parameters.Add ( "p1_remark", MySqlDbType.VarChar ).Value = mReader["p1_remark"];
            //			sqlCmd.Parameters.Add ( "p2_number", MySqlDbType.VarChar ).Value = mReader["p2_number"];
            //			sqlCmd.Parameters.Add ( "p2_remark", MySqlDbType.VarChar ).Value = mReader["p2_remark"];
            //			sqlCmd.Parameters.Add ( "p3_number", MySqlDbType.VarChar ).Value = mReader["p3_number"];
            //			sqlCmd.Parameters.Add ( "p3_remark", MySqlDbType.VarChar ).Value = mReader["p3_remark"];
            //			sqlCmd.Parameters.Add ( "postal_code", MySqlDbType.VarChar ).Value = mReader["postal_code"];
            //			sqlCmd.Parameters.Add ( "address", MySqlDbType.VarChar ).Value = mReader["address"];
            //			sqlCmd.Parameters.Add ( "city", MySqlDbType.VarChar ).Value = mReader["city"];
            //			sqlCmd.Parameters.Add ( "state", MySqlDbType.VarChar ).Value = mReader["state"];
            //			sqlCmd.Parameters.Add ( "pay_code", MySqlDbType.Int32 ).Value = mReader["pay_code"];
            //			sqlCmd.Parameters.Add ( "remark", MySqlDbType.VarChar ).Value = mReader["remark"];
            //			sqlCmd.Parameters.Add ( "deleted", MySqlDbType.Int32 ).Value = mReader["deleted"];
            //			sqlCmd.Parameters.Add ( "new_date", MySqlDbType.VarChar ).Value = mReader["new_date"];
            //			sqlCmd.Parameters.Add ( "update_date", MySqlDbType.VarChar ).Value = mReader["update_date"];
            //			sqlCmd.Parameters.Add ( "delete_date", MySqlDbType.VarChar ).Value = mReader["delete_date"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		proBar.Value = 2;
            //		sql = "DELETE FROM books";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "books Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM books";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO books (bk_year, bk_mok_code, bk_credit, bk_debit)";
            //		sql += " VALUES (?,?,?,?)"; // 6개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "bk_year", MySqlDbType.VarChar ).Value = mReader["bk_year"];
            //			sqlCmd.Parameters.Add ( "bk_mok_code", MySqlDbType.Int32 ).Value = mReader["bk_mok_code"];
            //			sqlCmd.Parameters.Add ( "bk_credit", MySqlDbType.Double ).Value = mReader["bk_credit"];
            //			sqlCmd.Parameters.Add ( "bk_debit", MySqlDbType.Double ).Value = mReader["bk_debit"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		proBar.Value = 3;
            //		sql = "DELETE FROM budget";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "budget Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM budget";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO budget (bg_year, bg_gubun, bg_hang_code, bg_mok_code, bg_budget, bg_actual)";
            //		sql += " VALUES (?,?,?,?,?,?)"; // 6개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "bg_year", MySqlDbType.VarChar ).Value = mReader["bg_year"];
            //			sqlCmd.Parameters.Add ( "bg_gubun", MySqlDbType.Int32 ).Value = mReader["bg_gubun"];
            //			sqlCmd.Parameters.Add ( "bg_hang_code", MySqlDbType.Int32 ).Value = mReader["bg_hang_code"];
            //			sqlCmd.Parameters.Add ( "bg_mok_code", MySqlDbType.Int32 ).Value = mReader["bg_mok_code"];
            //			sqlCmd.Parameters.Add ( "bg_budget", MySqlDbType.Double ).Value = mReader["bg_budget"];
            //			sqlCmd.Parameters.Add ( "bg_actual", MySqlDbType.Double ).Value = mReader["bg_actual"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		proBar.Value = 4;
            //		sql = "DELETE FROM church";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "church Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM church";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO church (ch_name, ch_address1, ch_address2, ch_phone, ch_no, ch_pastor, ch_treasuper, ch_treasuper_phone, ch_remark)";
            //		sql += " VALUES (?,?,?,?,?,?,?,?,?)"; // 9개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "ch_name", MySqlDbType.VarChar ).Value = mReader["ch_name"];
            //			sqlCmd.Parameters.Add ( "ch_address1", MySqlDbType.VarChar ).Value = mReader["ch_address1"];
            //			sqlCmd.Parameters.Add ( "ch_address2", MySqlDbType.VarChar ).Value = mReader["ch_address2"];
            //			sqlCmd.Parameters.Add ( "ch_phone", MySqlDbType.VarChar ).Value = mReader["ch_phone"];
            //			sqlCmd.Parameters.Add ( "ch_no", MySqlDbType.VarChar ).Value = mReader["ch_no"];
            //			sqlCmd.Parameters.Add ( "ch_pastor", MySqlDbType.VarChar ).Value = mReader["ch_pastor"];
            //			sqlCmd.Parameters.Add ( "ch_treasuper", MySqlDbType.VarChar ).Value = mReader["ch_treasuper"];
            //			sqlCmd.Parameters.Add ( "ch_treasuper_phone", MySqlDbType.VarChar ).Value = mReader["ch_treasuper_phone"];
            //			sqlCmd.Parameters.Add ( "ch_remark", MySqlDbType.VarChar ).Value = mReader["ch_remark"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		proBar.Value = 5;
            //		sql = "DELETE FROM duties";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "duties Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM duties";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO duties (ID, duty)";
            //		sql += " VALUES (?,?)"; // 2개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "ID", MySqlDbType.Int32 ).Value = mReader["ID"];
            //			sqlCmd.Parameters.Add ( "duty", MySqlDbType.VarChar ).Value = mReader["duty"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		proBar.Value = 6;
            //		sql = "DELETE FROM family";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "family Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM family";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO family (ID, relation)";
            //		sql += " VALUES (?,?)"; // 2개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "ID", MySqlDbType.Int32 ).Value = mReader["ID"];
            //			sqlCmd.Parameters.Add ( "relation", MySqlDbType.VarChar ).Value = mReader["relation"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		sql = "DELETE FROM hang_title";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "hang_title Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM hang_title";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO hang_title (ID, gubun, hang)";
            //		sql += " VALUES (?,?,?)"; // 3개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "ID", MySqlDbType.Int32 ).Value = mReader["ID"];
            //			sqlCmd.Parameters.Add ( "gubun", MySqlDbType.Int32 ).Value = mReader["gubun"];
            //			sqlCmd.Parameters.Add ( "hang", MySqlDbType.VarChar ).Value = mReader["hang"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();
            //		proBar.Value = 7;

            //		sql = "DELETE FROM mok_title";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "mok_title Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		sql = "SELECT * FROM mok_title";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO mok_title (ID, hang_code, gubun, mok, fund_building, fund_gospel, fund_help)";
            //		sql += " VALUES (?,?,?,?,?,?,?)"; // 7개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "ID", MySqlDbType.Int32 ).Value = mReader["ID"];
            //			sqlCmd.Parameters.Add ( "hang_code", MySqlDbType.Int32 ).Value = mReader["hang_code"];
            //			sqlCmd.Parameters.Add ( "gubun", MySqlDbType.Int32 ).Value = mReader["gubun"];
            //			sqlCmd.Parameters.Add ( "mok", MySqlDbType.VarChar ).Value = mReader["mok"];
            //			sqlCmd.Parameters.Add ( "fund_building", MySqlDbType.Bit ).Value = mReader["fund_building"];
            //			sqlCmd.Parameters.Add ( "fund_gospel", MySqlDbType.Bit ).Value = mReader["fund_gospel"];
            //			sqlCmd.Parameters.Add ( "fund_help", MySqlDbType.Bit ).Value = mReader["fund_help"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();
            //		proBar.Value = 8;
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            //		if ( Convert.ToInt32(inYear.Value) < 2013 ) {
            //			MessageBox.Show ( "2013년 이전 자료는 백업할 수 없습니다." );
            //			return;
            //		}
            //		proBar.Maximum = 5;
            //		proBar.Value = 1;
            //		string sql = "DELETE FROM deposit WHERE SUBSTR(df_date, 1, 4) = ?";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		sqlCmd.Parameters.Add ( "df_date", MySqlDbType.VarChar ).Value = inYear.Value;
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "deposit Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		proBar.Value = 2;
            //		sql = "SELECT * FROM deposit WHERE df_date LIKE '" + inYear.Value + "%'";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		try {
            //			mReader = myDB.ExeReader ();
            //		} catch ( OleDbException ex ) {
            //			MessageBox.Show ( "deposit Table Read error\n" + ex.Message );
            //			return;
            //		}
            //		sql = "	 INSERT INTO deposit (df_date, cash100_amt, cash50_amt, cash20_amt, cash10_amt, cash5_amt, cash2_amt, ";
            //			sql += "	cash1_amt, coin_amt, cheque0_no, cheque0_amt, cheque1_no, cheque1_amt, cheque2_no, cheque2_amt, ";
            //		sql += "	cheque3_no, cheque3_amt, cheque4_no, cheque4_amt, cheque5_no, cheque5_amt, cheque6_no, cheque6_amt, ";
            //			sql += "	cheque7_no, cheque7_amt, cheque8_no, cheque8_amt, cheque9_no, cheque9_amt) ";
            //		sql += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"; // 29개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "df_date", MySqlDbType.VarChar ).Value = mReader["df_date"];
            //			sqlCmd.Parameters.Add ( "cash100_amt", MySqlDbType.Int32 ).Value = mReader["cash100_amt"];
            //			sqlCmd.Parameters.Add ( "cash50_amt", MySqlDbType.Int32 ).Value = mReader["cash50_amt"];
            //			sqlCmd.Parameters.Add ( "cash20_amt", MySqlDbType.Int32 ).Value = mReader["cash20_amt"];
            //			sqlCmd.Parameters.Add ( "cash10_amt", MySqlDbType.Int32 ).Value = mReader["cash10_amt"];
            //			sqlCmd.Parameters.Add ( "cash5_amt", MySqlDbType.Int32 ).Value = mReader["cash5_amt"];
            //			sqlCmd.Parameters.Add ( "cash2_amt", MySqlDbType.Int32 ).Value = mReader["cash2_amt"];
            //			sqlCmd.Parameters.Add ( "cash1_amt", MySqlDbType.Int32 ).Value = mReader["cash1_amt"];
            //			sqlCmd.Parameters.Add ( "coin_amt", MySqlDbType.Double ).Value = mReader["coin_amt"];
            //			sqlCmd.Parameters.Add ( "cheque0_no", MySqlDbType.Int32 ).Value = mReader["cheque0_no"];
            //			sqlCmd.Parameters.Add ( "cheque0_amt", MySqlDbType.Double ).Value = mReader["cheque0_amt"];
            //			sqlCmd.Parameters.Add ( "cheque1_no", MySqlDbType.Int32 ).Value = mReader["cheque1_no"];
            //			sqlCmd.Parameters.Add ( "cheque1_amt", MySqlDbType.Double ).Value = mReader["cheque1_amt"];
            //			sqlCmd.Parameters.Add ( "cheque2_no", MySqlDbType.Int32 ).Value = mReader["cheque2_no"];
            //			sqlCmd.Parameters.Add ( "cheque2_amt", MySqlDbType.Double ).Value = mReader["cheque2_amt"];
            //			sqlCmd.Parameters.Add ( "cheque3_no", MySqlDbType.Int32 ).Value = mReader["cheque3_no"];
            //			sqlCmd.Parameters.Add ( "cheque3_amt", MySqlDbType.Double ).Value = mReader["cheque3_amt"];
            //			sqlCmd.Parameters.Add ( "cheque4_no", MySqlDbType.Int32 ).Value = mReader["cheque4_no"];
            //			sqlCmd.Parameters.Add ( "cheque4_amt", MySqlDbType.Double ).Value = mReader["cheque4_amt"];
            //			sqlCmd.Parameters.Add ( "cheque5_no", MySqlDbType.Int32 ).Value = mReader["cheque5_no"];
            //			sqlCmd.Parameters.Add ( "cheque5_amt", MySqlDbType.Double ).Value = mReader["cheque5_amt"];
            //			sqlCmd.Parameters.Add ( "cheque6_no", MySqlDbType.Int32 ).Value = mReader["cheque6_no"];
            //			sqlCmd.Parameters.Add ( "cheque6_amt", MySqlDbType.Double ).Value = mReader["cheque6_amt"];
            //			sqlCmd.Parameters.Add ( "cheque7_no", MySqlDbType.Int32 ).Value = mReader["cheque7_no"];
            //			sqlCmd.Parameters.Add ( "cheque7_amt", MySqlDbType.Double ).Value = mReader["cheque7_amt"];
            //			sqlCmd.Parameters.Add ( "cheque8_no", MySqlDbType.Int32 ).Value = mReader["cheque8_no"];
            //			sqlCmd.Parameters.Add ( "cheque8_amt", MySqlDbType.Double ).Value = mReader["cheque8_amt"];
            //			sqlCmd.Parameters.Add ( "cheque9_no", MySqlDbType.Int32 ).Value = mReader["cheque9_no"];
            //			sqlCmd.Parameters.Add ( "cheque9_amt", MySqlDbType.Double ).Value = mReader["cheque9_amt"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		proBar.Value = 3;
            //		sql = "DELETE FROM trans WHERE SUBSTR(tr_date, 1, 4) = ?";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		sqlCmd.Parameters.Add ( "tr_date", MySqlDbType.VarChar ).Value = inYear.Value;
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "transaction Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		proBar.Value = 4;
            //		sql = "SELECT * FROM [transaction] WHERE tr_date LIKE '" + inYear.Value + "%'";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO trans ( tr_date, tr_seq, tr_gubun, tr_hang_code, tr_mok_code, tr_believer_code, ";
            //		sql += "	tr_iscash, tr_amount, tr_cheque_no, tr_cheque_ok, tr_cheque_date, tr_update_date, tr_remark ) ";
            //		sql += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)"; // 13개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "tr_date", MySqlDbType.VarChar ).Value = mReader["tr_date"];
            //			sqlCmd.Parameters.Add ( "tr_seq", MySqlDbType.Int32 ).Value = mReader["tr_seq"];
            //			sqlCmd.Parameters.Add ( "tr_gubun", MySqlDbType.Int32 ).Value = mReader["tr_gubun"];
            //			sqlCmd.Parameters.Add ( "tr_hang_code", MySqlDbType.Int32 ).Value = mReader["tr_hang_code"];
            //			sqlCmd.Parameters.Add ( "tr_mok_code", MySqlDbType.Int32 ).Value = mReader["tr_mok_code"];
            //			sqlCmd.Parameters.Add ( "tr_believer_code", MySqlDbType.Int32 ).Value = mReader["tr_believer_code"];
            //			sqlCmd.Parameters.Add ( "tr_iscash", MySqlDbType.Int32 ).Value = mReader["tr_iscash"];
            //			sqlCmd.Parameters.Add ( "tr_amount", MySqlDbType.Double ).Value = mReader["tr_amount"];
            //			sqlCmd.Parameters.Add ( "tr_cheque_no", MySqlDbType.Int32 ).Value = mReader["tr_cheque_no"];
            //			sqlCmd.Parameters.Add ( "tr_cheque_ok", MySqlDbType.Int32 ).Value = mReader["tr_cheque_ok"];
            //			sqlCmd.Parameters.Add ( "tr_cheque_date", MySqlDbType.VarChar ).Value = mReader["tr_cheque_date"];
            //			sqlCmd.Parameters.Add ( "tr_update_date", MySqlDbType.VarChar ).Value = mReader["tr_update_date"];
            //			sqlCmd.Parameters.Add ( "tr_remark", MySqlDbType.VarChar ).Value = mReader["tr_remark"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();
            //		proBar.Value = 5;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            //		if ( Convert.ToInt32 ( inDate.Value ) < 20130101 ) {
            //			MessageBox.Show ( "2013년 이전 자료는 백업할 수 없습니다." );
            //			return;
            //		}
            //		proBar.Maximum = 5;
            //		proBar.Value = 1;
            //		string sql = "DELETE FROM deposit WHERE df_date = ?";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		sqlCmd.Parameters.Add ( "df_date", MySqlDbType.VarChar ).Value = inDate.Value;
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "deposit Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		proBar.Value = 2;
            //		sql = "SELECT * FROM deposit WHERE df_date = '" + inDate.Value + "'";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		try {
            //			mReader = myDB.ExeReader ();
            //		} catch ( OleDbException ex ) {
            //			MessageBox.Show ( "deposit Table Read error\n" + ex.Message );
            //			return;
            //		}
            //		sql = "	 INSERT INTO deposit (df_date, cash100_amt, cash50_amt, cash20_amt, cash10_amt, cash5_amt, cash2_amt, ";
            //			sql += "	cash1_amt, coin_amt, cheque0_no, cheque0_amt, cheque1_no, cheque1_amt, cheque2_no, cheque2_amt, ";
            //		sql += "	cheque3_no, cheque3_amt, cheque4_no, cheque4_amt, cheque5_no, cheque5_amt, cheque6_no, cheque6_amt, ";
            //			sql += "	cheque7_no, cheque7_amt, cheque8_no, cheque8_amt, cheque9_no, cheque9_amt) ";
            //		sql += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"; // 29개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "df_date", MySqlDbType.VarChar ).Value = mReader["df_date"];
            //			sqlCmd.Parameters.Add ( "cash100_amt", MySqlDbType.Int32 ).Value = mReader["cash100_amt"];
            //			sqlCmd.Parameters.Add ( "cash50_amt", MySqlDbType.Int32 ).Value = mReader["cash50_amt"];
            //			sqlCmd.Parameters.Add ( "cash20_amt", MySqlDbType.Int32 ).Value = mReader["cash20_amt"];
            //			sqlCmd.Parameters.Add ( "cash10_amt", MySqlDbType.Int32 ).Value = mReader["cash10_amt"];
            //			sqlCmd.Parameters.Add ( "cash5_amt", MySqlDbType.Int32 ).Value = mReader["cash5_amt"];
            //			sqlCmd.Parameters.Add ( "cash2_amt", MySqlDbType.Int32 ).Value = mReader["cash2_amt"];
            //			sqlCmd.Parameters.Add ( "cash1_amt", MySqlDbType.Int32 ).Value = mReader["cash1_amt"];
            //			sqlCmd.Parameters.Add ( "coin_amt", MySqlDbType.Double ).Value = mReader["coin_amt"];
            //			sqlCmd.Parameters.Add ( "cheque0_no", MySqlDbType.Int32 ).Value = mReader["cheque0_no"];
            //			sqlCmd.Parameters.Add ( "cheque0_amt", MySqlDbType.Double ).Value = mReader["cheque0_amt"];
            //			sqlCmd.Parameters.Add ( "cheque1_no", MySqlDbType.Int32 ).Value = mReader["cheque1_no"];
            //			sqlCmd.Parameters.Add ( "cheque1_amt", MySqlDbType.Double ).Value = mReader["cheque1_amt"];
            //			sqlCmd.Parameters.Add ( "cheque2_no", MySqlDbType.Int32 ).Value = mReader["cheque2_no"];
            //			sqlCmd.Parameters.Add ( "cheque2_amt", MySqlDbType.Double ).Value = mReader["cheque2_amt"];
            //			sqlCmd.Parameters.Add ( "cheque3_no", MySqlDbType.Int32 ).Value = mReader["cheque3_no"];
            //			sqlCmd.Parameters.Add ( "cheque3_amt", MySqlDbType.Double ).Value = mReader["cheque3_amt"];
            //			sqlCmd.Parameters.Add ( "cheque4_no", MySqlDbType.Int32 ).Value = mReader["cheque4_no"];
            //			sqlCmd.Parameters.Add ( "cheque4_amt", MySqlDbType.Double ).Value = mReader["cheque4_amt"];
            //			sqlCmd.Parameters.Add ( "cheque5_no", MySqlDbType.Int32 ).Value = mReader["cheque5_no"];
            //			sqlCmd.Parameters.Add ( "cheque5_amt", MySqlDbType.Double ).Value = mReader["cheque5_amt"];
            //			sqlCmd.Parameters.Add ( "cheque6_no", MySqlDbType.Int32 ).Value = mReader["cheque6_no"];
            //			sqlCmd.Parameters.Add ( "cheque6_amt", MySqlDbType.Double ).Value = mReader["cheque6_amt"];
            //			sqlCmd.Parameters.Add ( "cheque7_no", MySqlDbType.Int32 ).Value = mReader["cheque7_no"];
            //			sqlCmd.Parameters.Add ( "cheque7_amt", MySqlDbType.Double ).Value = mReader["cheque7_amt"];
            //			sqlCmd.Parameters.Add ( "cheque8_no", MySqlDbType.Int32 ).Value = mReader["cheque8_no"];
            //			sqlCmd.Parameters.Add ( "cheque8_amt", MySqlDbType.Double ).Value = mReader["cheque8_amt"];
            //			sqlCmd.Parameters.Add ( "cheque9_no", MySqlDbType.Int32 ).Value = mReader["cheque9_no"];
            //			sqlCmd.Parameters.Add ( "cheque9_amt", MySqlDbType.Double ).Value = mReader["cheque9_amt"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();

            //		proBar.Value = 3;
            //		sql = "DELETE FROM trans WHERE tr_date = ?";
            //		sqlCmd.CommandText = sql;
            //		sqlCmd.Parameters.Clear ();
            //		sqlCmd.Parameters.Add ( "tr_date", MySqlDbType.VarChar ).Value = inDate.Value;
            //		try {
            //			sqlCmd.ExecuteNonQuery ();
            //		} catch ( MySqlException ex ) {
            //			MessageBox.Show ( "transaction Table 구조를 먼저 만들어야 합니다.\n" + ex.Message );
            //			return;
            //		}
            //		proBar.Value = 4;
            //		sql = "SELECT * FROM [transaction] WHERE tr_date = '" + inDate.Value + "'";
            //		myDB.CommandSQL = sql;
            //		myDB.Command.Parameters.Clear ();
            //		mReader = myDB.ExeReader ();
            //		sql = "	 INSERT INTO trans ( tr_date, tr_seq, tr_gubun, tr_hang_code, tr_mok_code, tr_believer_code, ";
            //		sql += "	tr_iscash, tr_amount, tr_cheque_no, tr_cheque_ok, tr_cheque_date, tr_update_date, tr_remark ) ";
            //		sql += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)"; // 13개
            //		sqlCmd.CommandText = sql;
            //		while ( mReader.Read () ) {
            //			sqlCmd.Parameters.Clear ();
            //			sqlCmd.Parameters.Add ( "tr_date", MySqlDbType.VarChar ).Value = mReader["tr_date"];
            //			sqlCmd.Parameters.Add ( "tr_seq", MySqlDbType.Int32 ).Value = mReader["tr_seq"];
            //			sqlCmd.Parameters.Add ( "tr_gubun", MySqlDbType.Int32 ).Value = mReader["tr_gubun"];
            //			sqlCmd.Parameters.Add ( "tr_hang_code", MySqlDbType.Int32 ).Value = mReader["tr_hang_code"];
            //			sqlCmd.Parameters.Add ( "tr_mok_code", MySqlDbType.Int32 ).Value = mReader["tr_mok_code"];
            //			sqlCmd.Parameters.Add ( "tr_believer_code", MySqlDbType.Int32 ).Value = mReader["tr_believer_code"];
            //			sqlCmd.Parameters.Add ( "tr_iscash", MySqlDbType.Int32 ).Value = mReader["tr_iscash"];
            //			sqlCmd.Parameters.Add ( "tr_amount", MySqlDbType.Double ).Value = mReader["tr_amount"];
            //			sqlCmd.Parameters.Add ( "tr_cheque_no", MySqlDbType.Int32 ).Value = mReader["tr_cheque_no"];
            //			sqlCmd.Parameters.Add ( "tr_cheque_ok", MySqlDbType.Int32 ).Value = mReader["tr_cheque_ok"];
            //			sqlCmd.Parameters.Add ( "tr_cheque_date", MySqlDbType.VarChar ).Value = mReader["tr_cheque_date"];
            //			sqlCmd.Parameters.Add ( "tr_update_date", MySqlDbType.VarChar ).Value = mReader["tr_update_date"];
            //			sqlCmd.Parameters.Add ( "tr_remark", MySqlDbType.VarChar ).Value = mReader["tr_remark"];
            //			try {
            //				sqlCmd.ExecuteNonQuery ();
            //			} catch ( MySqlException ex ) {
            //				MessageBox.Show ( "INSERT 하는 중 오류가 발생하였습니다.\n" + ex.Message );
            //				return;
            //			}
            //		}
            //		mReader.Close ();
            //		proBar.Value = 5;
        }
    }
}
