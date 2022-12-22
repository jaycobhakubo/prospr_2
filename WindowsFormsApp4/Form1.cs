using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
	public partial class Form1 : Form
	{
		string _ConnectionString;
		Region region_m;
		Branch branch_m;
		public Form1()
		{
			InitializeComponent();

			_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\Database1.mdf;Integrated Security=True";

            /* What you need to do:
			 * Design and develop a small application where the user enters the name of a geographical region 
			 *  into a text box, and clicks Load. (Assume the user will only enter these valid region names: Auckland and Hamilton.)
			 *  The names of all the retail branches belonging to that region will be displayed in a grid.
			 *  
			 * Design the UI with:
			 * A label with caption "Region"
			 * A entry field for identifying the region name (one of Auckland or Hamilton).
			 * A grid for displaying the names of branches in the region.
			 * A Load button.
			 * 
			 * Behaviour of the UI:
			 * The user identifies the region in the region entry field.
			 * The user clicks the Load button.			 
			 * The names of the branches in the selected region are displayed in a DataGrid control.
			 * 
			 * There is a Region class and a Branch class in this project. Both have a Name property.
			 * The Region class contains a List<Branch> objects, being the branches belonging to that region.
			 * Load the data from the database into those classes as needed to achieve the solution.
			 * Write appropriate WinForms code to get that data on screen.
			 *
			 * Email steve@ontempo.co.nz with questions!
			*/

            region_m = new Region();
            branch_m = new Branch();

        }

		private void button1_Click(object sender, EventArgs e)
		{
			var tempRegionName = txtbxRegion.Text.ToString();//Save user input
			var tempRegionID = getRegionID(tempRegionName);


		}

		private int getRegionID(string regionName)
		{
            Int32 regionID_2;
            int regionID = 0;
            SqlConnection sclCon = new SqlConnection(_ConnectionString);
            sclCon.Open();
            SqlCommand sqlcmd = new SqlCommand("Select Id from [dbo].[Region] where [Name] = @RegionName", sclCon);
            sqlcmd.Parameters.AddWithValue("RegionName", regionName);
            SqlDataReader sqlData;
            sqlData = sqlcmd.ExecuteReader();
            List<string> branch = new List<string>();

            while (sqlData.Read())
            {
                regionID_2 = sqlData.GetInt32 (0);//The data coming from db is int32
                regionID = System.Int32.Parse(regionID_2.ToString());
            }

            sqlData.Close();
            sclCon.Close();
            return regionID;//return value
        }
	}
}
