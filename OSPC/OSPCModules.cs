using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace OSPC {

	public class OSPCModules {

		public Label msgText = null;

		public void MessageON ( object sender, string message = "자료를 읽는 중이니 잠시 기다리세요." ) {
			Control ctl = (Control) sender;

			ctl.Cursor = Cursors.WaitCursor;
			msgText = new Label ();
			msgText.AutoSize = false;
			msgText.BackColor = Color.Orange;
			msgText.BorderStyle = BorderStyle.FixedSingle;
			msgText.Padding = new Padding ( 20, 10, 20, 10 );
			msgText.Size = new Size ( 300, 80 );
			msgText.Text = message;
			msgText.TextAlign = ContentAlignment.MiddleCenter;
			msgText.Left = ( ctl.Width - msgText.Width ) / 2;
			msgText.Top = ( ctl.Height - msgText.Height ) / 2 - 50;
			ctl.Controls.Add ( msgText );
			msgText.BringToFront ();
			msgText.Refresh ();
		}
	
		public void MessageOFF ( object sender ) {
			Control ctl = (Control) sender;
			msgText.Visible = false;
			ctl.Controls.Remove ( msgText );
			ctl.Cursor = Cursors.Default;
			msgText = null;
		}

		public string Lunar2Solar ( string sDate ) {
			DateTime dt;
			try {
				dt = new DateTime ( Convert.ToInt32 ( sDate.Substring ( 0, 4 ) ), Convert.ToInt32 ( sDate.Substring ( 4, 2 ) ), Convert.ToInt32 ( sDate.Substring ( 6, 2 ) ) );
			} catch ( Exception ) {
				return sDate;
			}
			bool bExistLeap = false;
			KoreanLunisolarCalendar kr_Lunnar = new KoreanLunisolarCalendar ();
			int _lunnarYY = kr_Lunnar.GetYear ( dt );
			int _lunnarMM = kr_Lunnar.GetMonth ( dt );
			int _lunnarDD = kr_Lunnar.GetDayOfMonth ( dt );

			if ( kr_Lunnar.GetMonthsInYear ( _lunnarYY ) > 12 ) {              //12보다 큰달은 윤달이 있다는.
				bExistLeap = kr_Lunnar.IsLeapMonth ( _lunnarYY, _lunnarMM );   // 윤달에 대한 true or false
				int intLeap_mm = kr_Lunnar.GetLeapMonth ( _lunnarYY );         //윤달 추출
				if ( _lunnarMM >= intLeap_mm ) _lunnarMM--;
			}
			return ( new DateTime ( _lunnarYY, _lunnarMM, _lunnarDD ) ).ToString ( "yyyyMMdd" );
		}

		public string Solar2Lunar ( string sDate ) {
			string[] YunDal = new string [] { "190008", "190305", "190604", "190902", "191106", "191405", "191702", "191907", "192205",
					  "192504", "192802", "193006", "193305", "193603", "193807", "194106", "194404", "194702", "194907",
					  "195205", "195503", "195708", "196006", "196304", "196603", "196807", "197105", "197404", "197608", 
					  "197906", "198204", "198410", "198706", "199005", "199303", "199508", "199805", "200104", "200402",
					  "200607", "200905", "201203", "201409", "201705", "202004", "202302", "202506", "202805", "203103", 
					  "203311", "203606", "203905", "204202", "204407", "205003" };
			KoreanLunisolarCalendar kr_Lunnar = new KoreanLunisolarCalendar ();
			int iYear = Convert.ToInt32 ( sDate.Substring ( 0, 4 ));
			int iMonth = Convert.ToInt32 ( sDate.Substring ( 4, 2 ));
			int iDay = Convert.ToInt32 ( sDate.Substring ( 6, 2 ));
			string str = sDate.Substring ( 0, 6 );
			if ( kr_Lunnar.GetMonthsInYear ( iYear ) > 12 ) {
				int leapMonth = kr_Lunnar.GetLeapMonth ( iYear );
				for ( int i = 0; i < YunDal.Count(); i++ ) {
					if ( str == YunDal[i] ) {
						iMonth++;
						break;
					}
				}
				if ( iMonth > leapMonth ) iMonth++;
			}
			try {
				return ( kr_Lunnar.ToDateTime ( iYear, iMonth, iDay, 0, 0, 0, 0 ).ToString ( "yyyyMMdd" ) );
			} catch ( Exception ) {
				return sDate;
			}
		}

		/// <summary>
		/// Gets a Inverted DataTable
		/// </summary>
		/// <param name="table">Provided DataTable</param>
		/// <param name="columnX">X Axis Column</param>
		/// <param name="columnY">Y Axis Column</param>
		/// <param name="columnZ">Z Axis Column (values)</param>
		/// <param name="columnsToIgnore">Whether to ignore some column, it must be 
		/// provided here</param>
		/// <param name="nullValue">null Values to be filled</param> 
		/// <returns>C# Pivot Table Method  - Felipe Sabino</returns>
		public static DataTable GetInversedDataTable ( DataTable table, string columnX,
			 string columnY, string columnZ, string nullValue, bool sumValues ) {
			//Create a DataTable to Return
			DataTable returnTable = new DataTable ();

			if ( columnX == "" )
				columnX = table.Columns[0].ColumnName;

			//Add a Column at the beginning of the table
			returnTable.Columns.Add ( columnY );


			//Read all DISTINCT values from columnX Column in the provided DataTale
			List<string> columnXValues = new List<string> ();

			foreach ( DataRow dr in table.Rows ) {

				string columnXTemp = dr[columnX].ToString ();
				if ( !columnXValues.Contains ( columnXTemp ) ) {
					//Read each row value, if it's different from others provided, add to 
					//the list of values and creates a new Column with its value.
					columnXValues.Add ( columnXTemp );
					returnTable.Columns.Add ( columnXTemp );
				}
			}

			//Verify if Y and Z Axis columns re provided
			if ( columnY != "" && columnZ != "" ) {
				//Read DISTINCT Values for Y Axis Column
				List<string> columnYValues = new List<string> ();

				foreach ( DataRow dr in table.Rows ) {
					if ( !columnYValues.Contains ( dr[columnY].ToString () ) )
						columnYValues.Add ( dr[columnY].ToString () );
				}

				//Loop all Column Y Distinct Value
				foreach ( string columnYValue in columnYValues ) {
					//Creates a new Row
					DataRow drReturn = returnTable.NewRow ();
					drReturn[0] = columnYValue;
					//foreach column Y value, The rows are selected distincted
					DataRow[] rows = table.Select ( columnY + "='" + columnYValue + "'" );

					//Read each row to fill the DataTable
					foreach ( DataRow dr in rows ) {
						string rowColumnTitle = dr[columnX].ToString ();

						//Read each column to fill the DataTable
						foreach ( DataColumn dc in returnTable.Columns ) {
							if ( dc.ColumnName == rowColumnTitle ) {
								//If Sum of Values is True it try to perform a Sum
								//If sum is not possible due to value types, the value 
								// displayed is the last one read
								if ( sumValues ) {
									try {
										drReturn[rowColumnTitle] =
											 Convert.ToDecimal ( drReturn[rowColumnTitle] ) +
											 Convert.ToDecimal ( dr[columnZ] );
									} catch {
										drReturn[rowColumnTitle] = dr[columnZ];
									}
								} else {
									drReturn[rowColumnTitle] = dr[columnZ];
								}
							}
						}
					}
					returnTable.Rows.Add ( drReturn );
				}
			} else {
				throw new Exception ( "The columns to perform inversion are not provided" );
			}

			//if a nullValue is provided, fill the datable with it
			if ( nullValue != "" ) {
				foreach ( DataRow dr in returnTable.Rows ) {
					foreach ( DataColumn dc in returnTable.Columns ) {
						if ( dr[dc.ColumnName].ToString () == "" )
							dr[dc.ColumnName] = nullValue;
					}
				}
			}

			return returnTable;
		}
	}
}
