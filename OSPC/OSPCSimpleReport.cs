using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace OSPC {
	
	public partial class OSPCSimpleReport : Form {

		MyDB myDB = new MyDB ();
		string nDate;
		int nCount;
		int nReportNo; // 인수로 전달받은 Report 번호

		public OSPCSimpleReport ( int iReportNo, string iDate, int iCount ) {
			nDate = iDate; nCount = iCount; nReportNo = iReportNo;
			InitializeComponent ();
		}

		private void OSPCSimpleReport_Load(object sender, EventArgs e) {

			this.Cursor = Cursors.WaitCursor;
			if ( rptView != null ) {
				this.Controls.Remove ( rptView );
				rptView = null;
			}

			rptView = new ReportViewer ();
			rptView.BorderStyle = BorderStyle.Fixed3D;
			rptView.Dock = DockStyle.Fill;
			rptView.PageCountMode = PageCountMode.Actual;
			rptView.ShowCredentialPrompts = false;
			rptView.ShowDocumentMapButton = false;
			rptView.ShowFindControls = false;
			rptView.ShowParameterPrompts = false;
			rptView.ShowPromptAreaButton = false;
			rptView.ShowRefreshButton = false;
			rptView.ShowStopButton = false;
			rptView.TabStop = false;

			this.Controls.Add ( rptView );
			myDB.OpenDB ();
			this.rptView.RefreshReport ();
			OSPCDataSet ospcDataSet = new OSPCDataSet ();
			switch ( nReportNo ) {
				case 1:
					this.Text = "금일 헌금 현황";
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDailyOffering.rdlc";

					MakeTableRpt1Daily ( nDate, nDate, -1 );
					BindingSource bindingSource1 = new BindingSource ( ospcDataSet, "RptDaily1" );
					ReportDataSource reportSource1 = new ReportDataSource ( "ospcDataSet", bindingSource1 );
					rptView.LocalReport.DataSources.Add ( reportSource1 );

					myDB.CommandSQL = "SELECT * FROM RptDaily1";
					OleDbDataAdapter dataAdapter1 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter1.Fill ( ospcDataSet.RptDaily1 );

					ReportParameter param10 = new ReportParameter ( "rptDate", nDate );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param10 } );

					if ( ospcDataSet.RptDaily1.Rows.Count == 0 ) {
						MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 2:
					this.Text = "Bank Deposit Form";
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDepositForm.rdlc";

					BindingSource bindingSource2 = new BindingSource ( ospcDataSet, "deposit" );
					ReportDataSource reportSource2 = new ReportDataSource ( "DataSet1", bindingSource2 );
					rptView.LocalReport.DataSources.Add ( reportSource2 );

					myDB.CommandSQL = "SELECT * from [deposit] WHERE df_date = '" + nDate + "' ";
					OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter2.Fill ( ospcDataSet.deposit );

					ReportParameter param20 = new ReportParameter ( "Count", nCount.ToString () );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param20 } );

					if ( ospcDataSet.deposit.Rows.Count == 0 ) {
						MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 3:
					this.Text = "금일 헌금 및 지출 현황";
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDailyReport.rdlc";

					MakeTableRpt1Daily ( nDate, nDate, -1 );
					MakeTableRpt2Daily ( nDate, nDate );
					BindingSource bindingSource31 = new BindingSource ( ospcDataSet, "RptDaily1" );
					BindingSource bindingSource32 = new BindingSource ( ospcDataSet, "RptDaily2" );
					ReportDataSource reportSource31 = new ReportDataSource ( "DataSet1", bindingSource31 );
					ReportDataSource reportSource32 = new ReportDataSource ( "DataSet2", bindingSource32 );
					rptView.LocalReport.DataSources.Add ( reportSource31 );
					rptView.LocalReport.DataSources.Add ( reportSource32 );

					myDB.CommandSQL = "SELECT * FROM RptDaily1";
					OleDbDataAdapter dataAdapter31 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter31.Fill ( ospcDataSet.RptDaily1 );

					myDB.CommandSQL = "SELECT * FROM RptDaily2";
					OleDbDataAdapter dataAdapter32 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter32.Fill ( ospcDataSet.RptDaily2 );

					ReportParameter param30 = new ReportParameter ( "rptDate", nDate );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param30 } );

					if ( ospcDataSet.RptDaily1.Rows.Count == 0 && ospcDataSet.RptDaily2.Rows.Count == 0 ) {
						MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				default: break;
			}
			rptView.RefreshReport ();
			this.Cursor = Cursors.Default;
		}

		private void OSPCSimpleReport_FormClosing(object sender, FormClosingEventArgs e) {
			myDB.CloseDB ();
		}

		private void MakeTableRpt1Daily ( string sFromDate, string sToDate, int sCode ) {
			// 헌금현황에 사용할 임시테이블을 만든다
			string sql = "DROP TABLE RptDaily1";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "SELECT tr_believer_code AS r1_id, tr_believer_name AS r2_name, tr_date AS r1_date, ";
			sql += "IIF( tr_mok_name = '십일조', tr_amount, 0 ) AS r1_amt, IIF( tr_mok_name = '주일헌금', tr_amount, 0 ) AS r2_amt, IIF( tr_mok_name = '감사헌금', tr_amount, 0 ) AS r3_amt, ";
			sql += "IIF( tr_mok_name = '선교헌금', tr_amount, 0 ) AS r4_amt, IIF( tr_mok_name = '절기헌금', tr_amount, 0 ) AS r5_amt, IIF( tr_mok_name = '건축헌금', tr_amount, 0 ) AS r6_amt, ";
			sql += "IIF( tr_mok_name = '구제헌금', tr_amount, 0 ) AS r7_amt, IIF( tr_mok_name = '기타헌금', tr_amount, 0 ) AS r8_amt ";
			sql += "INTO RptDaily1 FROM daily_list WHERE tr_hang_code = 1 AND tr_date BETWEEN ? AND ? ";
			if ( sCode >= 0 ) sql += "AND tr_believer_code IN ( SELECT ID FROM believers WHERE householder = " + sCode.ToString () + " ) ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = sFromDate;
			myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = sToDate;
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
		}

		private void MakeTableRpt2Daily ( string sFromDate, string sToDate ) {
			string sql = "DROP TABLE RptDaily2";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "SELECT * INTO RptDaily2 FROM ";
			sql += "(SELECT tr_date AS r2_date, tr_seq AS r2_seq, tr_hang_name + ' > ' + tr_mok_name AS r2_account, ";
			sql += "tr_believer_name AS r2_name, IIF( tr_gubun = 0, tr_amount * (-1), tr_amount ) AS r2_amount, tr_remark AS r2_remark, tr_cheque_no as r2_cheque_no ";
			sql += "FROM daily_list WHERE tr_hang_code <> 1 AND tr_date BETWEEN ? AND ?)";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = sFromDate;
			myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = sToDate;
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
		}
	}
}
