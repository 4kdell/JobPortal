<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_Registration.aspx.cs" Inherits="JobPortal.JobRecruiter_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>  NEW JOB RECRUITER REGISTRATION </h1>
    <table>

        
        <tr>
            <td>Name :</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>

            <td>URL :</td>
            <td>
                <asp:TextBox ID="txturl" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Email :</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>

            <td>Password :</td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>HR :</td>
            <td>
                <asp:TextBox ID="txthr" runat="server"></asp:TextBox></td>
            <td>Mobile Number :</td>
            <td>
                <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>

        </tr>

        <tr>
            <td>State :</td>
            <td>
                <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList></td>
            <td>City :</td>
            <td>
                <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>


            <td>Address :</td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox></td>
            <td>Comment :</td>
            <td>
                <asp:TextBox ID="txtcomments" runat="server"></asp:TextBox></td>
        </tr>



        <tr>
            <td>Company Image :</td>
            <td> 
                <asp:FileUpload ID="fuimage" runat="server" />

            </td>

            <td></td>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
