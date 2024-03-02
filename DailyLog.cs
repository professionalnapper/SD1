using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhiskersAndWags
{
    public partial class DailyLog : UserControl
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        public DailyLog()
        {
            InitializeComponent();
        }

        private void DailyLog_Load(object sender, EventArgs e)
        {
            // reload
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\Downloads\\(1) WhiskersAndWags\\WandW (1).accdb";
            myConn = new OleDbConnection(connectionString);
            string query = "SELECT DailyLog.LogDate, DailyLog.LogTime, DailyLog.StaffName, DailyLog.ActionTaken;";
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "DailyLog");
            dataGridView1.DataSource = ds.Tables["DailyLog"];
            myConn.Close();
        }
    }
}
