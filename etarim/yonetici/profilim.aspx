<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="profilim.aspx.cs" Inherits="yonetici_profilim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <head id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Admin Paneli</title>
<link href="./styles/login.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
    <style type="text/css">
        .style10
    {
        width: 100%;
    }
        .style1
        {
            width: 77%;
            height: 146px;
        }
        .style6
        {
            width: 137px;
            height: 26px;
        }
        .style7
        {
            width: 67px;
            height: 26px;
        }
        .style8
        {
            width: 162px;
            height: 26px;
        }
        .style9
        {
            width: 366px;
            height: 26px;
        }
        .style2
        {
            width: 137px;
        }
        .style3
        {
            width: 67px;
        }
        .style4
        {
            width: 162px;
        }
        .style5
        {
            width: 366px;
        }
        .style11
    {
        width: 774px;
    }
    .style12
    {
        width: 207px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style10">
    <tr>
        <td>
            &nbsp;</td>
        <td class="style11">
            <table class="style10">
                <tr>
                    <td class="style12">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Profil Görüntüleme-Düzenleme Sayfası"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style11">
    <table align="center" class="style1">
        <tr>
            <td class="style6">
                <asp:Label ID="Label1" runat="server" Text="Ad :"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="LabelAd" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style8" id="labelAd0">
                <asp:TextBox ID="TextBoxAd" runat="server" Enabled="False" EnableTheming="True" 
                    Visible="False" Width="120px"></asp:TextBox>
            </td>
            <td class="style9">
            <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBoxAd"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Soyad :"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="LabelSoyad" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style4" id="labelSoyad0">
                <asp:TextBox ID="TextBoxSoyad" runat="server" Enabled="False" Visible="False" 
                    Width="120px"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBoxSoyad"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" />&nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="E Mail :"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="LabelMail" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style4" id="labelMail0">
                <asp:TextBox ID="TextBoxEmail" runat="server" Enabled="False" Visible="False" 
                    Width="120px"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBoxEmail" ErrorMessage="**Geçersiz E-mail Formatı">
                                    </asp:RegularExpressionValidator>&nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="Button1" runat="server" Height="25px" Text="Düzenle" 
                    onclick="Button1_Click" />
            </td>
            <td class="style4" id="labelSifre">
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Kaydet" 
                    Width="76px" Visible="False" />
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
    </table>
    <body>
</body>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

