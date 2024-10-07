<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="JobSeeker_Registration.aspx.cs" Inherits="JobPortal.JobSeeker_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1>  NEW JOB SEEKER REGISTRATION </h1>
    
    <table>


        <tr>
            <td>Name</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>

            <td>Email</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
            </td>

            <td>Gender</td>
            <td>
                <asp:DropDownList ID="ddlgender" runat="server">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td>Job Profile</td>
            <td>
                <asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList>
            </td>

            <td>Qualification</td>
            <td>
                <asp:DropDownList ID="ddlqualificaiton" runat="server"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>State</td>
            <td>
                <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>

            <td>Security Questions </td>
            <td>
                <asp:DropDownList ID="ddlquestion" runat="server">
                </asp:DropDownList>
            </td>

        </tr>

        <tr>
            <td>City</td>
            <td>
                <asp:DropDownList ID="ddlcity" runat="server">
                </asp:DropDownList>
            </td>
            <td>Answer</td>
            <td>
                <asp:TextBox ID="txtanswers" runat="server"></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td>Mobile</td>
            <td>
                <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
            </td>


            <td>Address</td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td>Date of Birth </td>
            <td>
                <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
            </td>

            <td>Job Experince</td>
            <td>
                <asp:DropDownList ID="ddlexp" runat="server">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td>Photo Upload</td>
            <td>
                <asp:FileUpload ID="fuphoto" runat="server" />
            </td>

            <td>Resume Upload</td>
            <td>
                <asp:FileUpload ID="furesume" runat="server" />
            </td>
        </tr>


        <tr>
            <td>Comment</td>
            <td>
                <asp:TextBox ID="txtcomment" runat="server"></asp:TextBox>
            </td>

            <td></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
