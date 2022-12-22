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
            populateDataGridView();

        }

        private void populateDataGridView()
        {
            //  dgvBranch.AutoGenerateColumns = false;
            //  dgvBranch.AllowUserToAddRows = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = typeof(Branch);


            bs.Add(region_m.Branches);


            dgvBranch.DataSource = bs;
            dgvBranch.AutoGenerateColumns = true;
        }

        private void getBranchData(int regionID)
        {
            SqlConnection conn1 = new SqlConnection(_ConnectionString);
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("select id,  [Name] from Branch where RegionId =  @RegionID", conn1);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("RegionID", regionID.ToString());
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                Branch branchItem = new Branch();
                Int32 tempRegionId = reader1.GetInt32(0);
                branchItem.Id = System.Int32.Parse(tempRegionId.ToString());
                branchItem.Name = reader1["Name"].ToString();
                region_m.Branches.Add(branchItem);
            }

            //Now let us store our value in our region class		
            reader1.Close();
            conn1.Close();
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
                regionID_2 = sqlData.GetInt32(0);//The data coming from db is int32
                regionID = System.Int32.Parse(regionID_2.ToString());
            }

            sqlData.Close();
            sclCon.Close();
            return regionID;//return value
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var tempRegionName = txtbxRegion.Text.ToString();//Save user input
            var tempRegionID = getRegionID(tempRegionName);
            region_m.Id = tempRegionID;
            region_m.Name = tempRegionName;
            getBranchData(region_m.Id);
            populateDataGridView();
        }
    }
}
