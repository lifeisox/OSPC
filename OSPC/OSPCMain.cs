using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OSPC {

	public partial class OSPCMain : Form {

		public OSPCMain () {
			InitializeComponent ();
		}

		private void tsButtonConfigure_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCConfigure ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void tsButtonClose_Click ( object sender, EventArgs e ) {
			this.Close ();
		}

		private void tsButtonPerson_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCBeliever ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void tsButtonOffering_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCOffering ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void tsButtonBankForm_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCDepositForm ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void tsButtonExpense_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCExpense ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void tsButtonCheck_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCCheque ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void tsButtonPrint_ButtonClick ( object sender, EventArgs e ) {
			tsButtonPrint.ShowDropDown ();
		}

		private void Report01_Click ( object sender, EventArgs e ) {
			ToolStripMenuItem who = (ToolStripMenuItem) sender;
			int iReportNo;
			switch ( who.Name ) {
				case "Report01":		iReportNo = 1;	break;
				case "Report02":		iReportNo = 2;	break;
				case "Report03":		iReportNo = 3;	break;
				case "Report11":		iReportNo = 11;	break;
				case "Report12":		iReportNo = 12;	break;
				case "Report13":		iReportNo = 13;	break;
				case "Report14":		iReportNo = 14;	break;
				case "Report81":		iReportNo = 81; break; // 가족별 교인 명단
				case "Report82":		iReportNo = 82; break; // 년간 생일자 명단
				case "Report91":		iReportNo = 91; break;
				case "BookOfCash":		iReportNo = 101;break;
				case "BookOfOffering1": iReportNo = 102;break;
				case "BookOfOffering2": iReportNo = 103;break;
				case "BookOfOffering3": iReportNo = 104;break;
				case "PrintResult":		iReportNo = 121;break;
				default: return;
			}
			Form newform = new OSPCReport ( iReportNo );
			newform.MdiParent = this;
			newform.Show ();
		}

		private void tsButtonBooks_ButtonClick ( object sender, EventArgs e ) {
			tsButtonBooks.ShowDropDown ();
		}

		private void tsButtonBudgetTasks_ButtonClick ( object sender, EventArgs e ) {
			tsButtonBudgetTasks.ShowDropDown ();
		}

		private void InputBudget_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCBudget ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void GetResult_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCActual ();
			newform.MdiParent = this;
			newform.Show ();
		}

		private void BackupDB_Click ( object sender, EventArgs e ) {
			Form newform = new OSPCBackup ();
			newform.MdiParent = this;
			newform.Show ();
		}
	}
}
