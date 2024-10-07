using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace JobPortal
{   

    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data source = DESKTOP-N41JHSE\\SQLEXPRESS ; Initial catalog =    JobPortal; Integrated security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ddlusertype.SelectedValue == "1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblAdmin where AdminEmail ='" + txtemail.Text + "' and AdminPassword='" + txtpassword.Text + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Login Failed !!";
                }
                else
                {
                    Session["AID"] = dt.Rows[0]["AdminId"];
                    Response.Redirect("/AdminM/AdminHome.aspx");
                }
            }
            else if (ddlusertype.SelectedValue == "2")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblJobSeeker where JobSeekerEmail='"+txtemail.Text+"' and JobSeekerPassword='"+txtpassword.Text+"' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Login Failed !!";
                }
                else
                {
                    Session["JSID"] = dt.Rows[0]["JobSeekerId"];
                    Response.Redirect("/JobSeekerM/JobSeekerHome.aspx");
                }
            }
            else if (ddlusertype.SelectedValue == "3")
            {
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from tblJobRecruiter where JobRecruiterEmail='" + txtemail.Text + "' and JobRecruiterPassword='" + txtpassword.Text + "' ", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();


                    if (dt.Rows.Count == 0)
                    {
                        lblmsg.Text = "Login Failed !!";
                    }
                    else
                    {
                        Session["JRID"] = dt.Rows[0]["JobRecruiterId"];
                        Response.Redirect("/JobRecruiterM/JobRecruiterHome.aspx");
                    }
                }
            }
        }
    }
}