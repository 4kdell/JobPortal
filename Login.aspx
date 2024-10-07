<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JobPortal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        ALREADY A USER : LOGIN
    </h1>
    <table>
    <tr>
        <td>User Type</td>
        <td>
            <asp:DropDownList ID="ddlusertype" runat="server">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                <asp:ListItem Text="JobSeeker" Value="2"></asp:ListItem>
                <asp:ListItem Text="JobRecruiter" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td>Email Id :</td>
        <td>
           <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>

        </td>
    </tr>

    <tr>
        <td>Password :</td>
        <td>
            <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" />
        </td>
    </tr>

    <tr>
        <td></td>
        <td>
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </td>
    </tr>

        
</table>
</asp:Content>
