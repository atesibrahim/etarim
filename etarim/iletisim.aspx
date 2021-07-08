<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="iletisim.aspx.cs" Inherits="iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 73px;
        }
        .style3
        {
            height: 26px;
        }
        .style4
        {
            width: 73px;
            height: 26px;
        }
        .style5
        {
            height: 23px;
        }
        .style6
        {
            width: 73px;
            height: 23px;
        }
        .style7
        {
            width: 162px;
        }
        .style8
        {
            height: 26px;
            width: 162px;
        }
        .style9
        {
            height: 23px;
            width: 162px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="İLETİŞİM FORMU"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        <asp:Label ID="Label1" runat="server" Text="Ad:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="50" Width="163px"></asp:TextBox>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="Geçersiz isim" 
                                    ControlToValidate="TextBox1"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" />
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox1" 
                           ID="cv1" ErrorMessage="* Alanı boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style8">
                    </td>
                    <td class="style4">
                        <asp:Label ID="Label2" runat="server" Text="Soyad:"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="50" Width="163px"></asp:TextBox>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="Geçersiz soyisim." 
                                    ControlToValidate="TextBox2"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" />
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox2" 
                           ID="RequiredFieldValidator1" ErrorMessage="* Alanı boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
                    <td class="style3">
                    </td>
                </tr>
                <tr>
                    <td class="style9">
                    </td>
                    <td class="style6">
                        <asp:Label ID="Label3" runat="server" Text="E-mail:"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="TextBox3" runat="server" MaxLength="100" Width="306px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBox3" ErrorMessage="**Geçersiz E-mail Formatı;" ForeColor="Red">
                                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox3" 
                           ID="RequiredFieldValidator2" ErrorMessage="* Alanı boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
                    <td class="style5">
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        <asp:Label ID="Label4" runat="server" Text="Konu:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" MaxLength="250" Width="305px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2" valign="top">
                        <asp:Label ID="Label5" runat="server" Text="Mesaj:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Height="193px" MaxLength="990" 
                            Width="305px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Gönder" onclick="Button1_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    </form>
</asp:Content>

