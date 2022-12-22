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
		private string _ConnectionString;
		Region rijon = new Region();

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

		private void button1_Click(object sender, EventArgs e)
		{
			var regionName = txtbxRegionName.Text.ToString();
			var regionID = getRegionID(regionName);//Lets get the ID of the region name

			//if our region data is good here then let us store in our region class
			rijon.Id = regionID;
			rijon.Name = regionName;

			//Now that we have our data populated smoothly let us display it on the data drid view
			//Since they only want to see branches on that region we only need one column
			getBranchData(rijon.Id);

			//if the region rijon.Id input is ok. Then let us get all the branches with that region.
			populateDataGridView();
        }

        private void getBranchData(int regionId)//This will be multilple items Region can have many branches
		{
            SqlConnection conn1 = new SqlConnection(_ConnectionString);
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("select id,  [Name] from Branch where RegionId =  @RegionID", conn1);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("RegionID", regionId.ToString());
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();
           
            while (reader1.Read())
            {
                Branch branchItem = new Branch();
                Int32 tempRegionId = reader1.GetInt32(0);
                branchItem.Id = System.Int32.Parse(tempRegionId.ToString());
                branchItem.Name = reader1["Name"].ToString();
                rijon.Branches.Add(branchItem);
            }

            //Now let us store our value in our region class		
            reader1.Close();
            conn1.Close();
        }

		private int getRegionID(string RegionName)
		{
			Int32 regionID_2;
			int regionID = 0;

            SqlConnection conn1 = new SqlConnection(_ConnectionString);
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select Id from [dbo].[Region] where [Name] = @RegionName" , conn1);
            cmd1.Parameters.AddWithValue("RegionName", RegionName);
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();
            List<string> branch = new List<string>();

            while (reader1.Read())
            {
                regionID_2 = reader1.GetInt32(0);
				regionID = System.Int32.Parse(regionID_2.ToString());
            }

            reader1.Close();
            conn1.Close();

			return regionID;
        }
		private void populateDataGridView()
		{
            dgvBranches.AutoGenerateColumns = false;
			dgvBranches.AllowUserToAddRows = false;
			dgvBranches.DataSource = rijon.Branches;
        }


    }
}
