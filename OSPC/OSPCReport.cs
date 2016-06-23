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
using System.Globalization;

namespace OSPC {
	
	public partial class OSPCReport : Form {

		const int nBasicYear = 2013;
		const int nBuilding = 8;
		const int nGospel = 6;
		const int nHelp = 9;

		MyDB myDB = new MyDB ();
		OleDbDataReader mReader;
		ReportViewer rptView = null;

		List<int> nBelieverID = new List<int> ();
		int nReportNo; // 인수로 전달받은 Report 번호
		int nYear; // 작업 기준 년
		int nCount; // Bank Deposit Form에서 사용
		int nCode; // 각종 코드 용도로 사용
		string nDueDate, nFromDate, nToDate; // 작업일자
		bool nFirstSW;

		string mSaveLastDate;

		ComboBox inDate, inFrom, inTo, inName, inBanGi, inMon;

		public OSPCReport ( int iReportNo ) {
			nReportNo = iReportNo;
			nFirstSW = true;
			InitializeComponent ();
		}

		private void OSPCReport_Load ( object sender, EventArgs e ) {

			myDB.OpenDB ();

			switch ( nReportNo ) {
				case 1:
					this.Text = "금일 헌금 현황";
					FillYearCombo ();
					DisplayDueDateCombo ();
					break;
				case 2:
					this.Text = "Bank Deposit Form";
					FillYearCombo ();
					DisplayDueDateCombo ();
					break;
				case 3:
					this.Text = "금일 헌금 및 지출 현황";
					FillYearCombo ();
					DisplayDueDateCombo ();
					break;
				case 11:
					this.Text = "기간별 가구별 헌금 현황";
					FillYearCombo ();
					DisplayDuringCombo ();
					break;
				case 12:
					this.Text = "가구별 년간 헌금 내역";
					FillYearCombo ();
					DisplayNameCombo ();
					break;
				case 13:
					this.Text = "반기 항목별 지출 현황";
					FillYearCombo ();
					DisplayBanGiCombo ();
					break;
				case 14:
					this.Text = "기간별 헌금 및 지출 현황";
					FillYearCombo ();
					DisplayDuringCombo ();
					break;
				case 81:
					this.Text = "가족별 교인 대장";
					FillYearCombo ();
					break;
				case 82:
					this.Text = "날짜별 생일자 목록";
					FillYearCombo ();
					break;
				case 91:
					this.Text = "헌금 영수증";
					FillYearCombo ();
					DisplayNameCombo ();
					break;
				case 101:
					this.Text = "현금 출납장";
					FillYearCombo ();
					DisplayMonthCombo ();
					break;
				case 102:
					this.Text = "건축헌금 대장";
					FillYearCombo ();
					break;
				case 103:
					this.Text = "선교헌금 대장";
					FillYearCombo ();
					break;
				case 104:
					this.Text = "구제헌금 대장";
					FillYearCombo ();
					break;
				case 121:
					this.Text = "예산 및 결산 보고서";
					FillYearCombo ();
					DisplayGubunCombo ();
					break;
				default: break;
			}
		}

		private void OSPCReport_Activated ( object sender, EventArgs e ) {

			if ( !nFirstSW ) return;
			nFirstSW = false;

			SetYearCombo ( DateTime.Today.Year );
		}

		private void OSPCReport_FormClosing ( object sender, FormClosingEventArgs e ) {
			myDB.CloseDB ();
		}

		private void inYear_SelectedIndexChanged ( object sender, EventArgs e ) {

			nYear = inYear.SelectedIndex + nBasicYear;
			switch ( nReportNo ) {
				case 1:
				case 2:
				case 3:
					nFirstSW = true;
					FillDateCombo ();
					nFirstSW = false;
					SetDateCombo ( mSaveLastDate );
					break;
				case 11:
				case 14:
					nFirstSW = true;
					FillDateFromCombo ();
					nFirstSW = false;
					SetDateFromCombo ( DateTime.Today.ToString("yyyyMMdd") );
					break;
				case 12:
					nFirstSW = true;
					FillNameCombo ();
					nFirstSW = false;
					inName.SelectedIndex = 0;
					break;
				case 13:
					nFirstSW = true;
					FillBanGiCombo ();
					nFirstSW = false;
					if ( DateTime.Today.Month < 7 ) inBanGi.SelectedIndex = 0;
					else inBanGi.SelectedIndex = 1;
					break;
				case 91:
					nFirstSW = true;
					inName.Items.Add ( "모두선택" );
					nBelieverID.Add ( 0 );
					FillNameCombo ();
					nFirstSW = false;
					inName.SelectedIndex = 0;
					break;
				case 101:
					nFirstSW = true;
					FillMonthCombo ();
					nFirstSW = false;
					SetMonthCombo ( DateTime.Today.ToString( "yyyyMMdd" ) );
					break;
				case 121:
					nFirstSW = true;
					FillGubunCombo ();
					nFirstSW = false;
					inBanGi.SelectedIndex = 0;
					break;
				default: break;
			}

		}

		private void inDate_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( nFirstSW ) return;
			string iDate = inDate.Items[inDate.SelectedIndex].ToString ();
			nDueDate = nYear + iDate.Substring ( 0, 2 ) + iDate.Substring ( 3, 2 ); // yyyyMMdd
		}

		private void inFrom_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( nFirstSW ) return;
			nFromDate = nYear + (inFrom.SelectedIndex + 1).ToString("00") + "01"; // yyyyMMdd
			nFirstSW = true;
			FillDateToCombo ();
			nFirstSW = false;
			inTo.SelectedIndex = 0;
		}

		private void inTo_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( nFirstSW ) return;
			nToDate = nYear + ( inFrom.SelectedIndex + inTo.SelectedIndex + 1 ).ToString ( "00" ) + "31"; // yyyyMMdd
		}

		private void inName_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( nFirstSW ) return;
			nCode = (int) nBelieverID[inName.SelectedIndex];
		}

		private void inBanGi_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( nFirstSW ) return;
			nCode = (int) inBanGi.SelectedIndex;
		}

		private void inMon_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( nFirstSW ) return;
			nFromDate = nYear + ( inMon.SelectedIndex + 1 ).ToString ( "00" ) + "01";
			nToDate = nYear + ( inMon.SelectedIndex + 1 ).ToString ( "00" ) + "31";
		}

		private void btnClose_Click ( object sender, EventArgs e ) {
			this.Close ();
		}

		private void btnPrint_Click ( object sender, EventArgs e ) {

			this.Cursor = Cursors.WaitCursor;
			if ( rptView != null ) {
				panel1.Controls.Remove ( rptView );
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
			
			panel1.Controls.Add ( rptView );

			OSPCDataSet ospcDataSet = new OSPCDataSet ();
			switch ( nReportNo ) {
				case 1:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDailyOffering.rdlc";

					MakeTableRpt1Daily ( nDueDate, nDueDate, -1 );
					BindingSource bindingSource1 = new BindingSource ( ospcDataSet, "RptDaily1" );
					ReportDataSource reportSource1 = new ReportDataSource ( "ospcDataSet", bindingSource1 );
					rptView.LocalReport.DataSources.Add ( reportSource1 );

					myDB.CommandSQL = "SELECT * FROM RptDaily1";
					OleDbDataAdapter dataAdapter1 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter1.Fill ( ospcDataSet.RptDaily1 );

					ReportParameter param10 = new ReportParameter ( "rptDate", nDueDate );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param10 } );

					if ( ospcDataSet.RptDaily1.Rows.Count == 0 ) {
					    MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 2:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDepositForm.rdlc";

					myDB.CommandSQL = "SELECT * from [deposit] WHERE df_date = '" + nDueDate + "' ";
					myDB.Command.Parameters.Clear ();
					mReader = myDB.ExeReader ();
					nCount = 0;
					if ( mReader.Read () ) {
						if ( (double) mReader["cheque0_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque1_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque2_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque3_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque4_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque5_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque6_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque7_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque8_amt"] > 0 ) nCount++;
						if ( (double) mReader["cheque9_amt"] > 0 ) nCount++;
					}
					mReader.Close ();

					BindingSource bindingSource2 = new BindingSource ( ospcDataSet, "deposit" );
					ReportDataSource reportSource2 = new ReportDataSource ( "DataSet1", bindingSource2 );
					rptView.LocalReport.DataSources.Add ( reportSource2 );

					myDB.CommandSQL = "SELECT * from [deposit] WHERE df_date = '" + nDueDate + "' ";
					OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(myDB.Command);
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
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDailyReport.rdlc";

					MakeTableRpt1Daily ( nDueDate, nDueDate, -1 );
					MakeTableRpt2Daily ( nDueDate, nDueDate );
					BindingSource bindingSource31 = new BindingSource ( ospcDataSet, "RptDaily1" );
					BindingSource bindingSource32 = new BindingSource ( ospcDataSet, "RptDaily2" );
					ReportDataSource reportSource31 = new ReportDataSource ( "DataSet1", bindingSource31 );
					ReportDataSource reportSource32 = new ReportDataSource ( "DataSet2", bindingSource32 );
					rptView.LocalReport.DataSources.Add ( reportSource31 );
					rptView.LocalReport.DataSources.Add ( reportSource32 );

					myDB.CommandSQL = "SELECT * FROM RptDaily1";
					OleDbDataAdapter dataAdapter31 = new OleDbDataAdapter( myDB.Command );
					dataAdapter31.Fill ( ospcDataSet.RptDaily1 );

					myDB.CommandSQL = "SELECT * FROM RptDaily2";
					OleDbDataAdapter dataAdapter32 = new OleDbDataAdapter( myDB.Command );
					dataAdapter32.Fill ( ospcDataSet.RptDaily2 );

					ReportParameter param30 = new ReportParameter ( "rptDate", nDueDate );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param30 } );

					if ( ospcDataSet.RptDaily1.Rows.Count == 0 && ospcDataSet.RptDaily2.Rows.Count == 0 ) {
					    MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 11:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDuringOffering.rdlc";

					MakeTableRpt1Daily ( nFromDate, nToDate, -1 );
					BindingSource bindingSource11 = new BindingSource ( ospcDataSet, "RptDaily1" );
					ReportDataSource reportSource11 = new ReportDataSource ( "ospcDataSet", bindingSource11 );
					rptView.LocalReport.DataSources.Add ( reportSource11 );

					myDB.CommandSQL = "SELECT * FROM RptDaily1";
					OleDbDataAdapter dataAdapter11 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter11.Fill ( ospcDataSet.RptDaily1 );

					ReportParameter param110 = new ReportParameter ( "rptDate", nFromDate.Substring ( 0, 4 ) + "년 " + nFromDate.Substring ( 4, 2 )  + "월 ~ " + nToDate.Substring ( 0, 4 ) + "년 " + nToDate.Substring ( 4, 2 ) + "월" );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param110 } );

					if ( ospcDataSet.RptDaily1.Rows.Count == 0 ) {
					    MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 12:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptPersonOffering.rdlc";

					MakeTableRpt1Daily ( nYear + "0101", nYear + "1231", nCode );
					BindingSource bindingSource12 = new BindingSource ( ospcDataSet, "RptDaily1" );
					ReportDataSource reportSource12 = new ReportDataSource ( "ospcDataSet", bindingSource12 );
					rptView.LocalReport.DataSources.Add ( reportSource12 );

					myDB.CommandSQL = "SELECT * FROM RptDaily1";
					OleDbDataAdapter dataAdapter12 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter12.Fill ( ospcDataSet.RptDaily1 );

					ReportParameter param120 = new ReportParameter ( "rptDate", nYear.ToString() + " 년" );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param120 } );

					if ( ospcDataSet.RptDaily1.Rows.Count == 0 ) {
					    MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 13: // 반기 항목별 지출현황
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptHalfYear.rdlc";

					MakeTableExpense ();
					BindingSource bindingSource13 = new BindingSource ( ospcDataSet, "YearlyExpense" );
					ReportDataSource reportSource13 = new ReportDataSource ( "ospcDataSet", bindingSource13 );
					rptView.LocalReport.DataSources.Add ( reportSource13 );

					myDB.CommandSQL = "SELECT * FROM YearlyExpense";
					OleDbDataAdapter dataAdapter13 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter13.Fill ( ospcDataSet.YearlyExpense );

					ReportParameter param130 = new ReportParameter ( "rptDate", nYear.ToString() );
					ReportParameter param131 = new ReportParameter ( "rptCondition", (inBanGi.SelectedIndex + 1).ToString() );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param130, param131 } );

					if ( ospcDataSet.YearlyExpense.Rows.Count == 0 ) {
					    MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 14:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptDuringReport.rdlc";

					BindingSource bindingSource41 = new BindingSource ( ospcDataSet, "daily_list" );
					ReportDataSource reportSource41 = new ReportDataSource ( "ospcDataSet", bindingSource41 );
					rptView.LocalReport.DataSources.Add ( reportSource41 );

					myDB.CommandSQL = "SELECT * FROM daily_list WHERE tr_date BETWEEN ? AND ?";
					myDB.Command.Parameters.Clear ();
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nFromDate;
					myDB.Command.Parameters.Add ( "tr_date", OleDbType.VarChar ).Value = nToDate;
					OleDbDataAdapter dataAdapter41 = new OleDbDataAdapter( myDB.Command );
					dataAdapter41.Fill ( ospcDataSet.daily_list );

					ReportParameter param40 = new ReportParameter ( "rptDate", nFromDate.Substring ( 0, 4 ) + "년 " + nFromDate.Substring ( 4, 2 ) + "월 ~ " + nToDate.Substring ( 0, 4 ) + "년 " + nToDate.Substring ( 4, 2 ) + "월" );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param40 } );

					if ( ospcDataSet.daily_list.Rows.Count == 0 ) {
					    MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 81:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptBelievers.rdlc";
					MakeTableRptBeliever ();
					BindingSource bindingSource811 = new BindingSource ( ospcDataSet, "BelieverList" );
					ReportDataSource reportSource811 = new ReportDataSource ( "ospcDataSet", bindingSource811 );
					rptView.LocalReport.DataSources.Add ( reportSource811 );

					myDB.CommandSQL = "SELECT * FROM BelieverList ORDER BY 1, 2";
					OleDbDataAdapter dataAdapter811 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter811.Fill ( ospcDataSet.BelieverList );

					ReportParameter param811 = new ReportParameter ( "rptDate", nYear.ToString () + " 년" );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param811 } );

					if ( ospcDataSet.BelieverList.Rows.Count == 0 ) {
						MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 82:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptBirthDate.rdlc";
					MakeTableRptBirthDate ();
					BindingSource bindingSource821 = new BindingSource ( ospcDataSet, "BirthDate" );
					ReportDataSource reportSource821 = new ReportDataSource ( "ospcDataSet", bindingSource821 );
					rptView.LocalReport.DataSources.Add ( reportSource821 );

					myDB.CommandSQL = "SELECT * FROM BirthDate ORDER BY 1, 2";
					OleDbDataAdapter dataAdapter821 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter821.Fill ( ospcDataSet.BirthDate );

					ReportParameter param821 = new ReportParameter ( "rptDate", nYear.ToString () + " 년" );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param821 } );

					if ( ospcDataSet.BirthDate.Rows.Count == 0 ) {
						MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 91:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptReceipt.rdlc";

					MakeTableRptReceipt ();
					BindingSource bindingSource91 = new BindingSource ( ospcDataSet, "RptReceipt" );
					BindingSource bindingSource92 = new BindingSource ( ospcDataSet, "church" );
					ReportDataSource reportSource91 = new ReportDataSource ( "ospcDataSet2", bindingSource91 );
					ReportDataSource reportSource92 = new ReportDataSource ( "ospcDataSet1", bindingSource92 );
					rptView.LocalReport.DataSources.Add ( reportSource91 );
					rptView.LocalReport.DataSources.Add ( reportSource92 );

					myDB.CommandSQL = "SELECT * FROM RptReceipt";
					OleDbDataAdapter dataAdapter91 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter91.Fill ( ospcDataSet.RptReceipt );

					myDB.CommandSQL = "SELECT * FROM church";
					OleDbDataAdapter dataAdapter92 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter92.Fill ( ospcDataSet.church );

					ReportParameter param90 = new ReportParameter ( "rptDate", nYear.ToString() );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param90 } );

					if ( ospcDataSet.RptReceipt.Rows.Count == 0 || ospcDataSet.church.Rows.Count == 0 ) {
					    MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 101:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptBookCash.rdlc";

					MakeTableRptBookCash ();
					BindingSource bindingSource1011 = new BindingSource ( ospcDataSet, "RptBooks" );
					ReportDataSource reportSource1011 = new ReportDataSource ( "ospcDataSet", bindingSource1011 );
					rptView.LocalReport.DataSources.Add ( reportSource1011 );

					myDB.CommandSQL = "SELECT * FROM RptBooks ORDER BY 1, 2, 3, 4";
					OleDbDataAdapter dataAdapter1011 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter1011.Fill ( ospcDataSet.RptBooks );

					ReportParameter param1011 = new ReportParameter ( "rptDate", nYear.ToString () + " 년 " + (inMon.SelectedIndex + 1).ToString() + " 월" );
					ReportParameter param1012 = new ReportParameter ( "rptTitle", "현 금 출 납 장" );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param1011 } );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param1012 } );

					if ( ospcDataSet.RptBooks.Rows.Count == 0 ) {
						MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 102:
				case 103:
				case 104:
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptBookCash.rdlc";
					int iMokCode;
					if ( nReportNo == 102 ) iMokCode = nBuilding; else if ( nReportNo == 103 ) iMokCode = nGospel; else iMokCode = nHelp;
					MakeTableRptBookOther ( iMokCode );
					BindingSource bindingSource1041 = new BindingSource ( ospcDataSet, "RptBooks" );
					ReportDataSource reportSource1041 = new ReportDataSource ( "ospcDataSet", bindingSource1041 );
					rptView.LocalReport.DataSources.Add ( reportSource1041 );

					myDB.CommandSQL = "SELECT * FROM RptBooks ORDER BY 1, 2, 3, 4";
					OleDbDataAdapter dataAdapter1041 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter1041.Fill ( ospcDataSet.RptBooks );

					ReportParameter param1041 = new ReportParameter ( "rptDate", nYear.ToString () + " 년" );
					ReportParameter param1042;
					if ( nReportNo == 102 )
						param1042 = new ReportParameter ( "rptTitle", "건 축 헌 금 대 장" );
					else if ( nReportNo == 103 )
						param1042 = new ReportParameter ( "rptTitle", "선 교 헌 금 대 장" );
					else
						param1042 = new ReportParameter ( "rptTitle", "구 제 헌 금 대 장" );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param1041 } );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param1042 } );

					if ( ospcDataSet.RptBooks.Rows.Count == 0 ) {
						MessageBox.Show ( "인쇄할 자료가 한 건도 없습니다." );
						this.Cursor = Cursors.Default;
						return;
					}
					break;
				case 121: // 예산 및 결산 보고서
					rptView.LocalReport.ReportEmbeddedResource = "OSPC.RptActual.rdlc";

					MakeTableActual ( nCode );
					BindingSource bindingSource1211 = new BindingSource ( ospcDataSet, "BudgetActual" );
					ReportDataSource reportSource1211 = new ReportDataSource ( "ospcDataSet", bindingSource1211 );
					rptView.LocalReport.DataSources.Add ( reportSource1211 );

					myDB.CommandSQL = "SELECT * FROM BudgetActual ORDER BY 1, 2, 4";
					OleDbDataAdapter dataAdapter1211 = new OleDbDataAdapter ( myDB.Command );
					dataAdapter1211.Fill ( ospcDataSet.BudgetActual );

					ReportParameter param1211 = new ReportParameter ( "rptDate", nYear.ToString () );
					ReportParameter param1212 = new ReportParameter ( "rptCondition", nCode.ToString () );
					rptView.LocalReport.SetParameters ( new ReportParameter[] { param1211, param1212 } );

					if ( ospcDataSet.BudgetActual.Rows.Count == 0 ) {
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

		private void MakeTableExpense () {
			string sql = "DROP TABLE YearlyExpense";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "SELECT tr_gubun AS gubun_code, tr_hang_code AS hang_code, hang AS hang_name, tr_mok_code AS mok_code, ";
			sql += "mok AS mok_name, SUM (IIF ( MID(tr_date, 5, 2) = '01', tr_amount, 0) ) AS col01, ";
			sql += "SUM (IIF ( MID(tr_date, 5, 2) = '02', tr_amount, 0) ) AS col02, SUM (IIF ( MID(tr_date, 5, 2) = '03', tr_amount, 0) ) AS col03, ";
			sql += "SUM (IIF ( MID(tr_date, 5, 2) = '04', tr_amount, 0) ) AS col04, SUM (IIF ( MID(tr_date, 5, 2) = '05', tr_amount, 0) ) AS col05, ";
			sql += "SUM (IIF ( MID(tr_date, 5, 2) = '06', tr_amount, 0) ) AS col06, SUM (IIF ( MID(tr_date, 5, 2) = '07', tr_amount, 0) ) AS col07, ";
			sql += "SUM (IIF ( MID(tr_date, 5, 2) = '08', tr_amount, 0) ) AS col08, SUM (IIF ( MID(tr_date, 5, 2) = '09', tr_amount, 0) ) AS col09, ";
			sql += "SUM (IIF ( MID(tr_date, 5, 2) = '10', tr_amount, 0) ) AS col10, SUM (IIF ( MID(tr_date, 5, 2) = '11', tr_amount, 0) ) AS col11, ";
			sql += "SUM (IIF ( MID(tr_date, 5, 2) = '12', tr_amount, 0) ) AS col12 INTO YearlyExpense ";
			sql += "FROM [transaction], hang_title, mok_title WHERE [hang_title].ID = [transaction].tr_hang_code AND ";
			sql += "[mok_title].ID = [transaction].tr_mok_code AND tr_gubun <> 0 AND tr_date LIKE '%" + nYear + "%' ";
			sql += "GROUP BY tr_gubun, tr_hang_code, hang, tr_mok_code, mok ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
		}

		private void MakeTableRptBeliever () {
			string sql = "DROP TABLE BelieverList";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "	SELECT householder, believers.relation, family.relation AS relation_name, kor_name, eng_name, IIF(man=1,'남','여') AS sex, ";
			sql += "	IIF(married=1,'기혼','미혼') AS marry, LEFT(birthdate, 2) + '-' + RIGHT(birthdate, 2) + IIF(lunar=1,'(음)', '(양)') AS birth, ";
			sql += "	duties.duty AS duty_name, LEFT(p1_number,3) + '-' + MID(p1_number,4,3) + '-' + RIGHT(p1_number,4) + ";
			sql += "	IIF(ISNULL(p1_remark) OR LEN(p1_remark)=0, '', '(' + p1_remark + ')') AS p1_phone, LEFT(p2_number,3) + ";
			sql += "	'-' + MID(p2_number,4,3) + '-' + RIGHT(p2_number,4) + IIF(ISNULL(p2_remark) OR LEN(p2_remark)=0, '', ";
			sql += "	'(' + p2_remark + ')') AS p2_phone, LEFT(p3_number,3) + '-' + MID(p3_number,4,3) + '-' + RIGHT(p3_number,4) + ";
			sql += "	IIF(ISNULL(p3_remark) OR LEN(p3_remark)=0, '', '(' + p3_remark + ')') AS p3_phone, IIF(ISNULL(email), '', ";
			sql += "	email) AS e_mail, IIF( ISNULL(address) OR LEN(address)=0, '', address + ' ' + IIF( ISNULL(city), '', ";
			sql += "	RTRIM(city) + ', ' + IIF( ISNULL(state), '', RTRIM(state) + '. CANADA ' + LEFT(postal_code, 3) + ' ' + ";
			sql += "	RIGHT(postal_code, 3) ) ) ) AS juso , IIF(ISNULL(remark), '', remark) AS bigo ";
			sql += "INTO BelieverList ";
			sql += "FROM believers, duties, family ";
			sql += "WHERE duties.ID = believers.duty AND family.ID = believers.relation AND deleted = 0 ";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
		}

		private void MakeTableRptBirthDate () {
			OSPCModules lun = new OSPCModules ();
			DateTime dt;
			OleDbCommand mComSub = new OleDbCommand ();
			string[] weekname = { "일", "월", "화", "수", "목", "금", "토" };
			mComSub.Connection = myDB.Connection;
			mComSub.CommandTimeout = 60;
			mComSub.UpdatedRowSource = UpdateRowSource.Both;
			string sql = "DELETE FROM BirthDate";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "SELECT * FROM believers WHERE deleted = 0";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader();
			sql = "INSERT INTO BirthDate ( bd_date, bd_name, bd_birth, bd_phone1, bd_phone2, bd_email ) VALUES (?,?,?,?,?,?)";
			mComSub.CommandText = sql;
			while ( mReader.Read() ) {
				mComSub.Parameters.Clear ();
				if ( (int) mReader["lunar"] == 1 ) sql = lun.Solar2Lunar ( nYear.ToString () + mReader["birthdate"] );
				else sql = nYear.ToString () + mReader["birthdate"];
				try {
					dt = new DateTime ( nYear, Convert.ToInt32 ( sql.Substring ( 4, 2 ) ), Convert.ToInt32 ( sql.Substring ( 6, 2 ) ) );
					sql = dt.ToString ( "MM-dd(ddd)" );
				} catch ( Exception ) {
					sql = "날짜오류";
				}
				mComSub.Parameters.Add ( "bd_date", OleDbType.VarChar ).Value = sql;
				mComSub.Parameters.Add ( "bd_name", OleDbType.VarChar ).Value = ( string.IsNullOrEmpty ( mReader["kor_name"].ToString () ) ? "" : mReader["kor_name"] );
				sql = mReader["birthdate"].ToString ().Substring ( 0, 2 ) + "-" + mReader["birthdate"].ToString ().Substring ( 2, 2 );
				if ( (int) mReader["lunar"] == 1 ) sql += "(음)";
				else sql += "(양)";
				mComSub.Parameters.Add ( "bd_birth", OleDbType.VarChar ).Value = sql;
				sql = mReader["p1_number"].ToString ().Substring ( 0, 3 ) + "-" + mReader["p1_number"].ToString ().Substring ( 3, 3 ) + "-" + mReader["p1_number"].ToString ().Substring ( 6, 3 );
				sql += ( string.IsNullOrEmpty ( mReader["p1_remark"].ToString() ) ? "" : " (" + mReader["p1_remark"] + ")" );
				mComSub.Parameters.Add ( "bd_phone1", OleDbType.VarChar ).Value = sql;
				sql = mReader["p2_number"].ToString ().Substring ( 0, 3 ) + "-" + mReader["p2_number"].ToString ().Substring ( 3, 3 ) + "-" + mReader["p2_number"].ToString ().Substring ( 6, 3 );
				sql += ( string.IsNullOrEmpty ( mReader["p2_remark"].ToString () ) ? "" : " (" + mReader["p2_remark"] + ")" );
				mComSub.Parameters.Add ( "bd_phone2", OleDbType.VarChar ).Value = sql;
				mComSub.Parameters.Add ( "bd_email", OleDbType.VarChar ).Value = ( string.IsNullOrEmpty ( mReader["email"].ToString () ) ? "" : mReader["email"] );
				mComSub.ExecuteNonQuery ();
			}
			mReader.Close();
		}

		private void MakeTableRptReceipt () {
			string sql = "DROP TABLE RptReceipt";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "SELECT rs_id, eng_name as rs_name, postal_code as rs_zipcode, address as rs_addr1, city + ' ' + state + '. CANADA' AS rs_addr2, ";
			sql += "rs_amount INTO RptReceipt FROM (SELECT householder AS rs_id, SUM (tr_amount) AS rs_amount FROM [transaction], believers ";
			sql += "WHERE ID = tr_believer_code AND tr_hang_code = 1 AND tr_date LIKE '%" + nYear + "%' ";
			sql += "GROUP BY householder) AS tempRec, believers ";
			sql += "WHERE believers.ID = tempRec.rs_id ";
			if ( inName.SelectedIndex > 0 ) {
				sql += " AND tempRec.rs_id = ? ";
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
				myDB.Command.Parameters.Add ( "tempRec.rs_id", OleDbType.Integer ).Value = nCode;
			} else {
				myDB.CommandSQL = sql;
				myDB.Command.Parameters.Clear ();
			}
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
		}

		private void MakeTableRptBookCash () {
			string sql = "DROP TABLE RptBooks";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			if ( inMon.SelectedIndex < 0 ) inMon.SelectedIndex = 0;
			sql = "	 SELECT * ";
			sql += " INTO RptBooks ";
			sql += " FROM ";
			sql += "	( ";
			sql += "	SELECT cb_date, 0 AS cb_hang_code, 0 AS cb_mok_code, 0 AS cb_seq, SUM(t1_credit) AS cb_credit, SUM(t1_debit) AS cb_debit, ";
			sql += "		SUM(t1_credit)-SUM(t1_debit) AS cb_balance, '' AS cb_remark, '전월이월' AS cb_detail ";
			sql += "	FROM ";
			sql += "		( ";
			sql += "		SELECT CSTR(CINT(bk_year)+1) + '0000' AS cb_date, bk_credit AS t1_credit, bk_debit AS t1_debit ";
			sql += "		FROM books WHERE bk_mok_code = 0 AND bk_year = '" + (nYear - 1).ToString() + "' "; // 전기자료
			if ( inMon.SelectedIndex > 0 ) {
			sql += "		UNION ALL ";
			sql += "		SELECT LEFT(tr_date, 4) + '0000' AS cb_date, IIF( tr_gubun=0, tr_amount, 0) AS t1_credit, ";
			sql += "			IIF( tr_gubun=1, tr_amount, 0) AS t1_debit";
			sql += "		FROM [transaction] WHERE tr_date BETWEEN '" + nYear.ToString () + "0101' AND '" + nYear.ToString () + inMon.SelectedIndex.ToString ( "00" ) + "31'"; // 전월까지 자료
			sql += "			AND tr_iscash = 1"; // 전월까지 현금 자료
			sql += "		UNION ALL ";
			sql += "		SELECT LEFT(tr_cheque_date, 4) + '0000' AS cb_date, IIF( tr_gubun=0, tr_amount, 0) AS t1_credit, ";
			sql += "			IIF( tr_gubun=1, tr_amount, 0) AS t1_debit";
			sql += "		FROM [transaction] WHERE tr_cheque_date BETWEEN '" + nYear.ToString () + "0101' AND '" + nYear.ToString () + inMon.SelectedIndex.ToString ( "00" ) + "31'"; // 전월까지 자료
			sql += "			AND tr_iscash = 0 AND tr_cheque_ok = 1"; // 전월까지 체크 결재 자료
			}
			sql += "		)";
			sql += "	GROUP BY cb_date ";
			sql += "	UNION ALL ";
			sql += "	SELECT tr_date AS cb_date, 1 AS cb_hang_code, 0 AS cb_mok_code, 0 AS cb_seq, SUM(tr_amount) AS cb_credit, ";
			sql += "		0 AS cb_debit, SUM(tr_amount) AS cb_balance, '' AS cb_remark, '헌금' AS cb_detail ";
			sql += "	FROM [transaction], hang_title ";
			sql += "	WHERE hang_title.ID=[transaction].tr_hang_code AND tr_date BETWEEN '" + nFromDate + "' AND '" + nToDate + "' ";
			sql += "		AND tr_hang_code = 1 ";
			sql += "	GROUP BY tr_date, tr_hang_code ";
			sql += "	UNION ALL ";
			sql += "	SELECT tr_date AS cb_date, tr_hang_code AS cb_hang_code, tr_mok_code AS cb_mok_code, tr_seq AS cb_seq, ";
			sql += "		IIF( tr_gubun=0, tr_amount, 0) AS cb_credit, IIF( tr_gubun=1, tr_amount, 0) AS cb_debit, ";
			sql += "		IIF (tr_gubun=0, tr_amount, tr_amount * (-1)) AS cb_balance, tr_remark AS cb_remark, '[' + ";
			sql += "		hang_title.hang + '] ' + mok_title.mok + '(' + believers.kor_name + ')' AS cb_detail ";
			sql += "	FROM [transaction], hang_title, mok_title, believers WHERE hang_title.ID = tr_hang_code AND ";
			sql += "		mok_title.ID = tr_mok_code AND believers.ID = tr_believer_code AND tr_date BETWEEN '" + nFromDate + "' AND ";
			sql += "		'" + nToDate + "' AND tr_hang_code <> 1 AND tr_iscash = 1 ";
			sql += "	UNION ALL ";
			sql += "	SELECT tr_cheque_date AS cb_date, tr_hang_code AS cb_hang_code, tr_mok_code AS cb_mok_code, tr_seq AS cb_seq, ";
			sql += "		IIF( tr_gubun=0, tr_amount, 0) AS cb_credit, IIF( tr_gubun=1, tr_amount, 0) AS cb_debit, ";
			sql += "		IIF (tr_gubun=0, tr_amount, tr_amount * (-1)) AS cb_balance, MID(tr_date, 5, 2) + '월 #' + STR(tr_cheque_no) AS cb_remark, '[' + ";
			sql += "		hang_title.hang + '] ' + mok_title.mok + '(' + believers.kor_name + ')' AS cb_detail ";
			sql += "	FROM [transaction], hang_title, mok_title, believers WHERE hang_title.ID = tr_hang_code AND ";
			sql += "		mok_title.ID = tr_mok_code AND believers.ID = tr_believer_code AND tr_cheque_date BETWEEN '" + nFromDate + "' AND ";
			sql += "		'" + nToDate + "' AND tr_hang_code <> 1 AND tr_iscash = 0 AND tr_cheque_ok = 1";
			sql += "	)";

			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
		}

		private void MakeTableRptBookOther ( int iMokCode ) {
			string sql = "DROP TABLE RptBooks";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			nFromDate = nYear + "0101";
			nToDate = nYear + "1231";
			sql = "	 SELECT * ";
			sql += " INTO RptBooks ";
			sql += " FROM ";
			sql += "	( ";
			sql += "	SELECT cb_date, 0 AS cb_hang_code, 0 AS cb_mok_code, 0 AS cb_seq, SUM(t1_credit) AS cb_credit, SUM(t1_debit) AS cb_debit, ";
			sql += "		SUM(t1_credit)-SUM(t1_debit) AS cb_balance, '' AS cb_remark, '전기이월' AS cb_detail";
			sql += "	FROM ";
			sql += "		(";
			sql += "		SELECT CSTR(CINT(bk_year)+1) + '0000' AS cb_date, bk_credit AS t1_credit, bk_debit AS t1_debit";
			sql += "		FROM books WHERE bk_mok_code = " + iMokCode.ToString() + " AND bk_year = '" + ( nYear - 1 ).ToString () + "'"; // 전기자료
			sql += "		)";
			sql += "	GROUP BY cb_date ";
			sql += "	UNION ";
			sql += "	SELECT tr_date AS cb_date, 1 AS cb_hang_code, 0 AS cb_mok_code, 0 AS cb_seq, SUM(tr_amount) AS cb_credit, ";
			sql += "		0 AS cb_debit, SUM(tr_amount) AS cb_balance, '' AS cb_remark, '헌금' AS cb_detail ";
			sql += "	FROM [transaction], hang_title, mok_title ";
			sql += "	WHERE hang_title.ID=[transaction].tr_hang_code AND mok_title.ID=[transaction].tr_mok_code ";
			sql += "		AND tr_date BETWEEN '" + nFromDate + "' AND '" + nToDate + "' AND tr_hang_code = 1 AND ";
			if ( iMokCode == nBuilding ) sql += "fund_building = true ";
			else if ( iMokCode == nGospel ) sql += "fund_gospel = true ";
			else sql += "fund_help = true ";
			sql += "	GROUP BY tr_date, tr_hang_code ";
			sql += "	UNION";
			sql += "	SELECT tr_date AS cb_date, tr_hang_code AS cb_hang_code, tr_mok_code AS cb_mok_code, tr_seq AS cb_seq, ";
			sql += "		IIF( tr_gubun=0, tr_amount, 0) AS cb_credit, IIF( tr_gubun=1, tr_amount, 0) AS cb_debit, ";
			sql += "		IIF (tr_gubun=0, tr_amount, tr_amount * (-1)) AS cb_balance, tr_remark AS cb_remark, '[' + ";
			sql += "		hang_title.hang + '] ' + mok_title.mok + '(' + believers.kor_name + ')' AS cb_detail ";
			sql += "	FROM [transaction], hang_title, mok_title, believers WHERE hang_title.ID = tr_hang_code AND ";
			sql += "		mok_title.ID = tr_mok_code AND believers.ID = tr_believer_code AND tr_date BETWEEN '" + nFromDate + "' AND ";
			sql += "		'" + nToDate + "' AND tr_hang_code <> 1 AND ";
			if ( iMokCode == nBuilding ) sql += "fund_building = true ";
			else if ( iMokCode == nGospel ) sql += "fund_gospel = true ";
			else sql += "fund_help = true ";
			sql += "	)";

			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
		}

		private void MakeTableActual ( int iCode ) {
			string sql = "DROP TABLE BudgetActual";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "	 SELECT bg_hang_code, hang AS bg_hang_name, bg_mok_code, mok AS bg_mok_name, ";
			sql += "	SUM(t1_lb) AS bg_last_budget, SUM(t1_la) AS bg_last_actual, SUM(t1_nb) AS bg_new_budget, ";
			sql += "	SUM(t1_na) AS bg_new_actual, IIF ( bg_new_budget <> 0, bg_new_actual / bg_new_budget, 0 ) AS bg_actual_rate, ";
			sql += "	IIF ( bg_last_actual <> 0, bg_new_actual / bg_last_actual, 0 ) AS bg_lastyear_rate ";
			sql += " INTO BudgetActual ";
			sql += " FROM";
			sql += "	(";
			sql += "	SELECT bg_hang_code, bg_mok_code, bg_budget AS t1_lb, bg_actual AS t1_la, 0 AS t1_nb, ";
			sql += "		0 AS t1_na";
			sql += "	FROM budget ";
			sql += "	WHERE bg_year = '" + ( nYear - 1 ).ToString() + "' AND bg_gubun = " + iCode.ToString() + " ";
			sql += "	UNION";
			sql += "	SELECT bg_hang_code, bg_mok_code, 0 AS t1_lb, 0 AS t1_la, bg_budget AS t1_nb, ";
			sql += "		bg_actual AS t1_na ";
			sql += "	FROM budget ";
			sql += "	WHERE bg_year = '" + nYear.ToString() + "' AND bg_gubun = " + iCode.ToString() + " ";
			sql += "	) AS tmp, hang_title, mok_title ";
			sql += " WHERE hang_title.ID= bg_hang_code AND mok_title.ID= bg_mok_code ";
			sql += " GROUP BY bg_hang_code, hang, bg_mok_code, mok ";

			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
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

		private void DisplayDueDateCombo () {
			inDate = new ComboBox ();
			inDate.DrawMode = DrawMode.Normal;
			inDate.DropDownHeight = 200;
			inDate.DropDownStyle = ComboBoxStyle.DropDownList;
			inDate.FormattingEnabled = false;
			inDate.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
			inDate.MaxDropDownItems = 10;
			inDate.Size = new Size ( 80, 25 );
			inDate.TabIndex = 1;
			inDate.Location = new Point ( 80, inYear.Location.Y + 32 );
			inDate.SelectedIndexChanged += new EventHandler(inDate_SelectedIndexChanged);
			panel0.Controls.Add ( inDate );

			Label lblDate = new Label ();
			lblDate.AutoSize = false;
			lblDate.BackColor = Color.DimGray;
			lblDate.ForeColor = Color.White;
			lblDate.Size = new Size ( 60, 25 );
			lblDate.Font = new System.Drawing.Font ( "맑은 고딕", 9, FontStyle.Bold );
			lblDate.Text = "작업일자";
			lblDate.TextAlign = ContentAlignment.MiddleCenter;
			lblDate.Location = new Point ( 15, lblBasic.Location.Y + 32 );
			panel0.Controls.Add ( lblDate );

			btnPrint.Top = lblDate.Top + 40;
		}

		private void FillDateCombo () {
			int cnt = 0;
			string sql = "";
			inDate.Items.Clear ();
			switch ( nReportNo ) {
				case 1: // 금일 헌금 현황
					sql += "SELECT tr_date from [transaction] WHERE tr_hang_code = 1 AND tr_date LIKE '%" + nYear + "%' ";
					sql += "GROUP BY tr_date ORDER BY tr_date ";
					myDB.CommandSQL = sql;
					myDB.Command.Parameters.Clear ();
					mReader = myDB.ExeReader ();
					while ( mReader.Read () ) {
						inDate.Items.Add ( mReader["tr_date"].ToString ().Substring ( 4, 2 ) + "월" + mReader["tr_date"].ToString ().Substring ( 6, 2 ) + "일" );
						mSaveLastDate = mReader["tr_date"].ToString ();
						cnt++;
					}
					break;
				case 2: // Bank Deposit Form
					sql += "SELECT df_date from [deposit] WHERE df_date LIKE '%" + nYear + "%' ";
					sql += "GROUP BY df_date ORDER BY df_date ";
					myDB.CommandSQL = sql;
					myDB.Command.Parameters.Clear ();
					mReader = myDB.ExeReader ();
					while ( mReader.Read () ) {
						inDate.Items.Add ( mReader["df_date"].ToString ().Substring ( 4, 2 ) + "월" + mReader["df_date"].ToString ().Substring ( 6, 2 ) + "일" );
						mSaveLastDate = mReader["df_date"].ToString ();
						cnt++;
					}
					break;
				case 3: // 금일 헌금 및 지출 현황 (일계표)
					sql += "SELECT tr_date from [transaction] WHERE tr_date LIKE '%" + nYear + "%' ";
					sql += "GROUP BY tr_date ORDER BY tr_date ";
					myDB.CommandSQL = sql;
					myDB.Command.Parameters.Clear ();
					mReader = myDB.ExeReader ();
					while ( mReader.Read () ) {
						inDate.Items.Add ( mReader["tr_date"].ToString ().Substring ( 4, 2 ) + "월" + mReader["tr_date"].ToString ().Substring ( 6, 2 ) + "일" );
						mSaveLastDate = mReader["tr_date"].ToString ();
						cnt++;
					}
					break;
			}
			mReader.Close ();
			if ( cnt == 0 ) {
				nDueDate = "";
				btnPrint.Enabled = false;
			}
		}

		private void SetDateCombo ( string sDate ) { // sYear : yyyyMMdd
			string iDate;
			for ( int i = 0; i < inDate.Items.Count; i++ ) {
				string iTemp = inDate.Items[i].ToString ();
				iDate = nYear + iTemp.Substring ( 0, 2 ) + iTemp.Substring ( 3, 2 );
				if ( sDate == iDate ) {
					inDate.SelectedIndex = i;
					break;
				}
			}
			if ( inDate.Items.Count <= 0 || inDate.SelectedIndex < 0 ) {
				nDueDate = "";
				btnPrint.Enabled = false;
			}
		}

		private void DisplayDuringCombo () {
			Label lblFrom = new Label ();
			lblFrom.AutoSize = false;
			lblFrom.BackColor = Color.DimGray;
			lblFrom.ForeColor = Color.White;
			lblFrom.Size = new Size ( 60, 25 );
			lblFrom.Font = new System.Drawing.Font ( "맑은 고딕", 9, FontStyle.Bold );
			lblFrom.Text = "시작일";
			lblFrom.TextAlign = ContentAlignment.MiddleCenter;
			lblFrom.Location = new Point ( 15, lblBasic.Location.Y + 32 );
			panel0.Controls.Add ( lblFrom );
			
			inFrom = new ComboBox ();
			inFrom.DrawMode = DrawMode.Normal;
			inFrom.DropDownHeight = 200;
			inFrom.DropDownStyle = ComboBoxStyle.DropDownList;
			inFrom.FormattingEnabled = false;
			inFrom.MaxDropDownItems = 12;
			inFrom.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
			inFrom.Size = new Size ( 80, 25 );
			inFrom.TabIndex = 1;
			inFrom.Location = new Point ( 80, inYear.Location.Y + 32 );
			inFrom.SelectedIndexChanged += new EventHandler ( inFrom_SelectedIndexChanged );
			panel0.Controls.Add ( inFrom );

			Label lblTo = new Label ();
			lblTo.AutoSize = false;
			lblTo.BackColor = Color.DimGray;
			lblTo.ForeColor = Color.White;
			lblTo.Size = new Size ( 60, 25 );
			lblTo.Font = new System.Drawing.Font ( "맑은 고딕", 9, FontStyle.Bold );
			lblTo.Text = "종료일";
			lblTo.TextAlign = ContentAlignment.MiddleCenter;
			lblTo.Location = new Point ( 15, lblFrom.Location.Y + 32 );
			panel0.Controls.Add ( lblTo );

			inTo = new ComboBox ();
			inTo.DrawMode = DrawMode.Normal;
			inTo.DropDownHeight = 200;
			inTo.DropDownStyle = ComboBoxStyle.DropDownList;
			inTo.FormattingEnabled = false;
			inTo.MaxDropDownItems = 12;
			inTo.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
			inTo.Size = new Size ( 80, 25 );
			inTo.TabIndex = 1;
			inTo.Location = new Point ( 80, inFrom.Location.Y + 32 );
			inTo.SelectedIndexChanged += new EventHandler ( inTo_SelectedIndexChanged );
			panel0.Controls.Add ( inTo );

			btnPrint.Top = lblTo.Top + 40;
		}

		private void FillDateFromCombo () {
			CultureInfo ci = new CultureInfo ( "en-US" );
			inFrom.Items.Clear ();
			for ( int i = 0; i < 12; i++ ) {
				inFrom.Items.Add ( new DateTime ( 2013, i + 1, 1 ).ToString ( "MMMMM", ci ) );
			}
		}

		private void FillDateToCombo () {
			CultureInfo ci = new CultureInfo ( "en-US" );
			inTo.Items.Clear ();
			if ( inFrom.SelectedIndex < 0 ) return;
			for ( int i = inFrom.SelectedIndex; i < 12; i++ ) {
				inTo.Items.Add ( new DateTime ( 2013, i + 1, 1 ).ToString ( "MMMMM", ci ) );
			}
		}

		private void SetDateFromCombo ( string sDate ) { // sYear : yyyyMMdd
			inFrom.SelectedIndex = Convert.ToInt32 ( sDate.Substring ( 4, 2 ) ) - 1;
		}

		private void DisplayNameCombo () {
			Label lblName = new Label ();
			lblName.AutoSize = false;
			lblName.BackColor = Color.DimGray;
			lblName.ForeColor = Color.White;
			lblName.Size = new Size ( 60, 25 );
			lblName.Font = new System.Drawing.Font ( "맑은 고딕", 9, FontStyle.Bold );
			lblName.Text = "헌금대표";
			lblName.TextAlign = ContentAlignment.MiddleCenter;
			lblName.Location = new Point ( 15, lblBasic.Location.Y + 32 );
			panel0.Controls.Add ( lblName );

			inName = new ComboBox ();
			inName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			inName.AutoCompleteSource = AutoCompleteSource.ListItems;
			inName.DrawMode = DrawMode.Normal;
			inName.DropDownHeight = 200;
			inName.DropDownStyle = ComboBoxStyle.DropDown;
			inName.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
			inName.FormattingEnabled = false;
			inName.MaxDropDownItems = 10;
			inName.Size = new Size ( 80, 25 );
			inName.TabIndex = 1;
			inName.Location = new Point ( 80, inYear.Location.Y + 32 );
			inName.SelectedIndexChanged += new EventHandler ( inName_SelectedIndexChanged );
			panel0.Controls.Add ( inName );
			
			btnPrint.Top = lblName.Top + 40;
		}

		private void FillNameCombo () {
			// 헌금대표 리스트를 뽑기 위하여 사용할 임시테이블을 만든다
			string sql = "DROP TABLE OfferingPerson";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ) {
			}
			sql = "SELECT sel_table.believer_code, believers.kor_name AS believer_name INTO OfferingPerson ";
			sql += "FROM (SELECT pay_code AS believer_code FROM [transaction], believers ";
			sql += "WHERE believers.ID=tr_believer_code AND deleted <> 2 AND tr_date Like '%" + nYear + "%' GROUP BY pay_code) ";
			sql += "AS sel_table, believers WHERE believers.ID = sel_table.believer_code ORDER BY 2";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			try {
				myDB.Command.ExecuteNonQuery ();
			} catch ( OleDbException ex ) {
				MessageBox.Show ( "임시 데이터 파일을 만드는 중 오류가 발생하였습니다.\n" + ex.Message + "\n프로그램 제작자에게 연락해 보세요" );
				return;
			}
			sql = "SELECT * FROM OfferingPerson ORDER BY believer_name";
			myDB.CommandSQL = sql;
			myDB.Command.Parameters.Clear ();
			mReader = myDB.ExeReader ();
			while ( mReader.Read () ) {
				nBelieverID.Add ( (int) mReader["believer_code"] );
				inName.Items.Add ( mReader["believer_name"] );
			}
			mReader.Close ();
		}

		private void DisplayBanGiCombo () {
			Label lblName = new Label ();
			lblName.AutoSize = false;
			lblName.BackColor = Color.DimGray;
			lblName.ForeColor = Color.White;
			lblName.Size = new Size ( 60, 25 );
			lblName.Font = new System.Drawing.Font ( "맑은 고딕", 9, FontStyle.Bold );
			lblName.Text = "기간선택";
			lblName.TextAlign = ContentAlignment.MiddleCenter;
			lblName.Location = new Point ( 15, lblBasic.Location.Y + 32 );
			panel0.Controls.Add ( lblName );

			inBanGi = new ComboBox ();
			inBanGi.DrawMode = DrawMode.Normal;
			inBanGi.DropDownHeight = 200;
			inBanGi.DropDownStyle = ComboBoxStyle.DropDownList;
			inBanGi.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
			inBanGi.FormattingEnabled = false;
			inBanGi.MaxDropDownItems = 2;
			inBanGi.Size = new Size ( 80, 20 );
			inBanGi.TabIndex = 1;
			inBanGi.Location = new Point ( 80, inYear.Location.Y + 32 );
			inBanGi.SelectedIndexChanged += new EventHandler ( inBanGi_SelectedIndexChanged );
			panel0.Controls.Add ( inBanGi );

			btnPrint.Top = lblName.Top + 40;
		}

		private void FillBanGiCombo () {
			inBanGi.Items.Clear ();
			inBanGi.Items.Add ( "전반기" );
			inBanGi.Items.Add ( "후반기" );
		}

		private void DisplayMonthCombo () {
			Label lblFrom = new Label ();
			lblFrom.AutoSize = false;
			lblFrom.BackColor = Color.DimGray;
			lblFrom.ForeColor = Color.White;
			lblFrom.Size = new Size ( 60, 25 );
			lblFrom.Font = new System.Drawing.Font ( "맑은 고딕", 9, FontStyle.Bold );
			lblFrom.Text = "작업월";
			lblFrom.TextAlign = ContentAlignment.MiddleCenter;
			lblFrom.Location = new Point ( 15, lblBasic.Location.Y + 32 );
			panel0.Controls.Add ( lblFrom );

			inMon = new ComboBox ();
			inMon.DrawMode = DrawMode.Normal;
			inMon.DropDownHeight = 200;
			inMon.DropDownStyle = ComboBoxStyle.DropDownList;
			inMon.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
			inMon.FormattingEnabled = false;
			inMon.MaxDropDownItems = 10;
			inMon.Size = new Size ( 80, 20 );
			inMon.TabIndex = 1;
			inMon.Location = new Point ( 80, inYear.Location.Y + 32 );
			inMon.SelectedIndexChanged += new EventHandler ( inMon_SelectedIndexChanged );
			panel0.Controls.Add ( inMon );

			btnPrint.Top = lblFrom.Top + 40;
		}

		private void FillMonthCombo () {
			CultureInfo ci = new CultureInfo ( "en-US" );
			inMon.Items.Clear ();
			for ( int i = 0; i < 12; i++ ) {
				inMon.Items.Add ( new DateTime ( 2013, i + 1, 1 ).ToString ( "MMMMM", ci ) );
			}
		}

		private void SetMonthCombo ( string sDate ) { // sYear : yyyyMMdd
			inMon.SelectedIndex = Convert.ToInt32 ( sDate.Substring ( 4, 2 ) ) - 1;
		}

		private void DisplayGubunCombo () {
			Label lblName = new Label ();
			lblName.AutoSize = false;
			lblName.BackColor = Color.DimGray;
			lblName.ForeColor = Color.White;
			lblName.Size = new Size ( 60, 25 );
			lblName.Font = new System.Drawing.Font ( "맑은 고딕", 9, FontStyle.Bold );
			lblName.Text = "종류선택";
			lblName.TextAlign = ContentAlignment.MiddleCenter;
			lblName.Location = new Point ( 15, lblBasic.Location.Y + 30 );
			panel0.Controls.Add ( lblName );

			inBanGi = new ComboBox ();
			inBanGi.DrawMode = DrawMode.Normal;
			inBanGi.DropDownHeight = 200;
			inBanGi.DropDownStyle = ComboBoxStyle.DropDownList;
			inBanGi.Font = new System.Drawing.Font ( "맑은 고딕", 10 );
			inBanGi.FormattingEnabled = false;
			inBanGi.MaxDropDownItems = 2;
			inBanGi.Size = new Size ( 80, 20 );
			inBanGi.TabIndex = 1;
			inBanGi.Location = new Point ( 80, inYear.Location.Y + 30 );
			inBanGi.SelectedIndexChanged += new EventHandler ( inBanGi_SelectedIndexChanged );
			panel0.Controls.Add ( inBanGi );

			btnPrint.Top = lblName.Top + 40;
		}

		private void FillGubunCombo () {
			inBanGi.Items.Clear ();
			inBanGi.Items.Add ( "수입부" );
			inBanGi.Items.Add ( "지출부" );
		}
	}
}
