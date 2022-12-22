using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
       // Branch branch_m;

        SqlConnection sqlCon;
        SqlDataReader sqlData;


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
        }

        private void populateDataGridView()
        {    
            dgvBranch.AutoGenerateColumns = false;
            dgvBranch.AllowUserToAddRows = false;
            dgvBranch.DataSource = region_m.Branches;
        }

        private SqlCommand setSqlSQLQuery(string query, string parameterName, string  parameterValue)
        {
            sqlCon = new SqlConnection(_ConnectionString);
            sqlCon.Open();
            SqlCommand sqlcmd  = new SqlCommand(query,sqlCon);
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue(parameterName, parameterValue);
            return sqlcmd;
        }

        private void getBranchData(int regionID)
        {     
            SqlCommand sqlcmd = setSqlSQLQuery("select id,  [Name] from Branch where RegionId =  @RegionID", "RegionID", regionID.ToString());               
            sqlData = sqlcmd.ExecuteReader();

            while (sqlData.Read())
            {
                Branch branchItem = new Branch();
                Int32 tempRegionId = sqlData.GetInt32(0);
                branchItem.Id = System.Int32.Parse(tempRegionId.ToString());
                branchItem.Name = sqlData["Name"].ToString();
                region_m.Branches.Add(branchItem);
            }

            sqlData.Close();
            sqlCon.Close();
        }


        private int getRegionID()
        {
            Int32 regionID_2;
            int regionID = 0;
           
            SqlCommand sqlcmd = setSqlSQLQuery("Select Id from [dbo].[Region] where [Name] = @RegionName", "RegionName", region_m.Name);
            sqlData = sqlcmd.ExecuteReader();

            while (sqlData.Read())
            {
                regionID_2 = sqlData.GetInt32(0);//The data coming from db is int32
                regionID = System.Int32.Parse(regionID_2.ToString());
            }

            sqlData.Close();
            sqlCon.Close();
            return regionID;//return value
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            region_m = new Region();
            //branch_m = new Branch();

            region_m.Name = txtbxRegion.Text.ToString();//Save user input
			region_m.Id = getRegionID();
          
            getBranchData(region_m.Id);
            populateDataGridView();
        }
    }
}
