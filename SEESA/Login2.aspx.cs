using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace SEESA
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=DESKTOP-2A4SUVH;" +
                                        "Database=LoginDB;" +
                                        "Trusted_Connection=True");
            var query = string.Format("Select * From tblLogin where username= '{0}' AND password='{1}'",txtUserName.Text,txtPassword.Text);

            var command = new SqlCommand(query, con);
            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet,"tblLogin");

            if (dataSet.Tables["tblLogin"].Rows.Count==0)
            {
                txtPassword.Text = "";
                txtUserName.Text = "";
                Response.Write("Invalid user");
            }
            else
            {
                Response.Redirect("Dashboard.aspx");
            }
        }
    }
}