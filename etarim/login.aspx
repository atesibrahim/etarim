<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        #logincontainer
    {
        height: 359px;
    }
        #loginbox
        {
            height: 302px;
        }
        .style11
        {
            width: 100%;
            height: 284px;
        }
        .style4
        {
            width: 101%;
            height: 162px;
            margin-left: 0px;
            margin-top: 25px;
            margin-bottom: 0px;
        }
        .style6
        {
            width: 134px;
            height: 43px;
        }
        .style7
        {
            height: 43px;
            width: 290px;
        }
        .style8
        {
            width: 134px;
            height: 45px;
        }
        .style9
        {
            height: 45px;
            width: 290px;
        }
        .style5
        {
            width: 134px;
        }
        .style10
        {
            width: 290px;
        }
        .style12
        {
            width: 245px;
        }
        .style13
        {
            width: 245px;
            height: 104px;
        }
        .style14
        {
            height: 104px;
        }
        .style15
        {
            width: 245px;
            height: 4px;
        }
        .style16
        {
            height: 4px;
        }
        .style17
        {
            width: 120%;
        }
        .style18
        {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <tr>
        <td>
    <div id="logincontainer">
    	<h1 style="color: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E-Tarım Giriş Paneli</h1>
        <table class="style11">
            <tr>
                <td class="style15">
                </td>
                <td class="style16">
            <table class="style4">
            <form runat="server">
                <tr>
                    <td class="style6">
                        E-mail adresi<label id="username">:</label></td>
                    <td class="style7">
                        <table class="style17">
                            <tr>
                                <td class="style18">
                        <asp:TextBox ID="txtUsername" runat="server" Width="150px" Height="22px" 
                            ForeColor="Black" MaxLength="30"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="txtUsername" ErrorMessage="**Geçersiz E-mail Formatı;" ForeColor="Red">
                                    </asp:RegularExpressionValidator>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <label id="password">Parola: </label>&nbsp&nbsp;</td>
                    <td class="style9">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" 
                            Height="22px" ForeColor="Black" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style10">
                <asp:Button ID="btnLogin" runat="server" Text="Giri&#351;" 
                    onclick="btnLogin_Click1" Width="67px" Height="30px" style="margin-top: 0px" 
                            Font-Bold="True" />
                
                    &nbsp;
                        <asp:Button ID="Button1" runat="server" Height="30px" onclick="Button1_Click" 
                            Text="Parolam&#305; Unuttum" Width="133px" Font-Bold="True" />
                
                    </td>
                </tr>
                </form>
            </table>
                </td>
                <td class="style16">
                </td>
            </tr>
            <tr>
                <td class="style13">
                </td>
                <td class="style14">
                </td>
                <td class="style14">
                </td>
            </tr>
            <tr>
                <td class="style12">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
        </td>
    </tr>
</asp:Content>

