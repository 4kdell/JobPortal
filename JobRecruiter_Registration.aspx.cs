using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace JobPortal
{
    public partial class JobRecruiter_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data source = DESKTOP-N41JHSE\\SQLEXPRESS ; Initial catalog =    JobPortal; Integrated security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    bindState();
                }
            }

        }

        public void bindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblState", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "StateId";
            ddlstate.DataTextField = "StateName";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        public void bindCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCity where Stateid ='" + ddlstate.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.Enabled = true;
            ddlcity.DataValueField = "CityId";
            ddlcity.DataTextField = "CityName";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
        }


        public void Clear()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            txturl.Text = "";
            txthr.Text = "";
         

            ddlstate.SelectedValue = "0";
            ddlcity.SelectedValue = "0";
            txtaddress.Text = "";

            txtmobile.Text = "";
            txtcomments.Text = "";

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            
            string ImageName = Path.GetFileName(fuimage.PostedFile.FileName);

           
            fuimage.SaveAs(Server.MapPath("JobRecruiterImages" + "\\" + ImageName));

            con.Open();
            SqlCommand cmd = new SqlCommand("proc_JobRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@JobRecruiterName", txtname.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterEmail", txtemail.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterPassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterURL", txturl.Text);
            
            
            cmd.Parameters.AddWithValue("@JobRecruiterState", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@JobRecruiterCity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@JobRecruiterAddress", txtaddress.Text);
                                             
            cmd.Parameters.AddWithValue("@JobRecruiterHR", txthr.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterMobile", txtmobile.Text);
                                             
                                            
            cmd.Parameters.AddWithValue("@JobRecruiterImage", ImageName);
            cmd.Parameters.AddWithValue("@JobRecruiterComments", txtcomments.Text);
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                lblmsg.Text = "RECORD INSERTED SUCCESSFULLY !!";
            }
            else if (i == 0)
            {
                lblmsg.Text = "RECORD NOT INSERTED SUCCESSFULLY !!";
            }
            con.Close();
            Clear();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCity();
        }
    }
}