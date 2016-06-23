using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OSPC {
	
	public partial class DateDialog : Form {

		string mDate, mBillDate;

		public DateDialog ( string BillDate, string ChequeDate ) {
			InitializeComponent ();
			mBillDate = BillDate;
			mDate = ChequeDate;
			inDate.Value = mDate;
		}

		public string InputDate {
			get { return mDate; }
		}

		private void btnOK_Click ( object sender, EventArgs e ) {
			if ( Convert.ToInt32(mBillDate) > Convert.ToInt32( inDate.Value ) ) {
				MessageBox.Show ( "발행이 결제일보다 클 수 없습니다." );
				DialogResult = System.Windows.Forms.DialogResult.None;
			}
			mDate = inDate.Value;
		}
	}
}
