using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;




namespace JobPortal
{
    public partial class JobSeeker_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data source = DESKTOP-N41JHSE\\SQLEXPRESS ; Initial catalog =    JobPortal; Integrated security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindJobProfile();
                bindQualification();
                bindQuestions();
                bindState();
                
               
            }

        }

        public void bindJobProfile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblJobProfile", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobprofile.DataValueField = "JobProfileId";
            ddljobprofile.DataTextField = "JobProfileName";
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void bindQualification ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblQualifications", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqualificaiton.DataValueField = "QualificationId";
            ddlqualificaiton.DataTextField = "QualificationName";
            ddlqualificaiton.DataSource = dt;
            ddlqualificaiton.DataBind();
            ddlqualificaiton.Items.Insert(0, new ListItem("--Select--", "0"));
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
            ddlgender.SelectedValue = "0";
            ddljobprofile.SelectedValue = "0";
            ddlqualificaiton.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            ddlcity.SelectedValue="0";
            txtaddress.Text = "";
            ddlquestion.SelectedValue = "0";
            txtanswers.Text = "";
            txtdob.Text = "";
            txtmobile.Text = "";
            ddlexp.SelectedValue = "0";
            txtcomment.Text = "";

        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCity();
        }

        public void bindQuestions()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblquestions", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlquestion.DataValueField = "QuestionId";
            ddlquestion.DataTextField = "QuestionName";
            ddlquestion.DataSource = dt;
            ddlquestion.DataBind();
            ddlquestion.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string ResumeName = Path.GetFileName(furesume.PostedFile.FileName);
            string PhotoName = Path.GetFileName(fuphoto.PostedFile.FileName);

            furesume.SaveAs(Server.MapPath("JobSeekerResumes" + "\\" + ResumeName));
            fuphoto.SaveAs(Server.MapPath("JobSeekerPhotos" + "\\" + PhotoName));

            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@JobSeekername", txtname.Text);
            cmd.Parameters.AddWithValue("@JobSeekeremail", txtemail.Text);
            cmd.Parameters.AddWithValue("@JobSeekerpassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@JobSeekerGender", ddlgender.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerJobProfile", ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerQualification", ddlqualificaiton.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerState", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerCity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerAddress", txtaddress.Text);
            cmd.Parameters.AddWithValue("@JobSeekerQuestion", ddlquestion.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerAnswer", txtanswers.Text);
            cmd.Parameters.AddWithValue("@JobSeekerDOB", txtdob.Text);
            cmd.Parameters.AddWithValue("@JobSeekerMobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@JobSeekerExp", ddlexp.SelectedValue);

            cmd.Parameters.AddWithValue("@JobSeekerImage", PhotoName);
            cmd.Parameters.AddWithValue("@JobSeekerResume", ResumeName);

            cmd.Parameters.AddWithValue("@JobSeekerComments", txtcomment.Text);
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
    }
}