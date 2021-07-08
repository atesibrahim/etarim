<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="parolamiunuttum.aspx.cs" Inherits="parolamiunuttum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
            height: 338px;
        }
        .style9
        {
            width: 357%;
        }
        .style10
        {
            width: 189px;
        }
        .style11
        {
            width: 87px;
            height: 36px;
        }
        .style12
        {
            width: 188px;
            height: 36px;
        }
        .style13
        {
            height: 36px;
        }
        .style23
        {
            width: 87px;
            height: 61px;
        }
        .style24
        {
            width: 188px;
            height: 61px;
        }
        .style25
        {
            height: 61px;
        }
        .style26
        {
            width: 87px;
            height: 49px;
        }
        .style27
        {
            width: 188px;
            height: 49px;
        }
        .style28
        {
            height: 49px;
        }
        .style29
        {
            width: 87px;
            height: 31px;
        }
        .style30
        {
            width: 188px;
            height: 31px;
        }
        .style31
        {
            height: 31px;
        }
        .style32
        {
            width: 87px;
            height: 22px;
        }
        .style33
        {
            width: 188px;
            height: 22px;
        }
        .style34
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <tr>
        <td>
            <table class="style3">
                <form runat="server">
                <tr>
                    <td class="style23">
                    </td>
                    <td class="style24">
                        <table class="style9">
                            <tr>
                                <td class="style10">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        Text="Mail Gönderme Paneli"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td class="style25">
                    </td>
                    <td class="style25">
                    </td>
                </tr>
                <tr>
                    <td class="style26">
                    </td>
                    <td class="style27">
                        <asp:Label ID="Label1" runat="server" Text="E Mail adresinizi giriniz :"></asp:Label>
                        <br />
                    </td>
                    <td class="style28">
                        <asp:TextBox ID="TextBox1" runat="server" Width="200px" Height="22px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Parolayı gönder" Width="140px" Font-Bold="True" Font-Italic="False" 
                            Height="30px" />
                        <br />
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBox1" ErrorMessage="**Geçersiz E-mail Formatı;" ForeColor="Red">
                                    </asp:RegularExpressionValidator></td>
                    <td class="style28">
                    </td>
                </tr>
                <tr>
                    <td class="style29">
                    </td>
                    <td class="style30">
                    </td>
                    <td class="style31">
                        &nbsp;</td>
                    <td class="style31">
                    </td>
                </tr>
                <tr>
                    <td class="style32">
                    </td>
                    <td class="style33">
                    </td>
                    <td class="style34">
                    </td>
                    <td class="style34">
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                    </td>
                    <td class="style12">
                    </td>
                    <td class="style13">
                    </td>
                    <td class="style13">
                    </td>
                </tr>
                </form>
            </table>
        </td>
    </tr>

</asp:Content>

