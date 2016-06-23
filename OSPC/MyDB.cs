using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb; // SqlClient;

namespace OSPC {

	class MyDB {

		// SQL: connect string 바뀜
		//      SqlConnection mConnection....
		//		SqlDbCommand ...
		string mConnectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\OSPC\OSPC.accdb";
		OleDbConnection mConnection = new OleDbConnection();
		OleDbCommand mCommand = new OleDbCommand ();
		CommandType mCommandType = CommandType.Text;
		string mCommandSQL;

		public OleDbConnection Connection {
			get { return mConnection; }
		}

		public OleDbCommand Command {
			get { return mCommand; }
		}

		public CommandType CommandType {
			get { return mCommandType; }
			set { mCommandType = value; mCommand.CommandType = mCommandType; }
		}

		public string CommandSQL {
			get { return mCommandSQL; }
			set { mCommandSQL = value; mCommand.CommandText = mCommandSQL; }
		}

		// DataBase를 엽니다.
		public bool OpenDB () {
			mConnection.ConnectionString = mConnectString;
			try {
				mConnection.Open();
				mCommand.Connection = mConnection;
				mCommand.CommandTimeout = 60;
				mCommand.UpdatedRowSource = UpdateRowSource.Both;
			} catch ( Exception ex ) {
				MessageBox.Show("데이터베이스 연결 도중 오류가 발생하였습니다.\n" + ex.Message );
				return false;
			}
			return true;
		}
		public void CloseDB () {
			mConnection.Close ();
		}
		public int ExeBasic () {
			try {
				int result = mCommand.ExecuteNonQuery (); // 영향받은 행의 개수 리턴
				return result;
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "ExecuteNoneQuery 명령을 실행하는 중 오류가 발생하였습니다.\n" + ex.Message );
				return -666;
			}
		}
		public OleDbDataReader ExeReader () {
			return mCommand.ExecuteReader();
		}
	}

}
