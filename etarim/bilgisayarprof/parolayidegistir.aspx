<%@ Page Title="" Language="C#" MasterPageFile="~/bilgisayarprof/bilgisayarprof.master" AutoEventWireup="true" CodeFile="parolayidegistir.aspx.cs" Inherits="bilgisayarprof_parolayidegistir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

    .style1
    {
        width: 100%;
        height: 191px;
    }
    .style2
    {
        width: 182px;
    }
    .style3
    {
        width: 151px;
    }
    .style4
    {
        width: 243%;
    }
    .style5
    {
        width: 41px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <table class="style4">
                    <tr>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Parola Değiştirme Sayfası"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Eski Parolanızı Girin :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="oldPassword" runat="server" EnableViewState="False" 
                TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="oldPassword" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
                                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Yeni Parolanizi Girin :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="newPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="newPassword" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                            
                            <asp:RegularExpressionValidator ID="MyTextBoxValidator" runat="server" 
                            ControlToValidate="newPassword"
                             ErrorMessage="Minimum uzunluk 6 karakter olmalıdır"
                                ValidationExpression=".{6}.*" /></td>
                                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Yeni Parolanizi Tekrar Girin :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="confPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="confPassword" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="mValidator" ControlToValidate="confPassword" 
                            ErrorMessage="Şifreler Uyuşmuyor!" ControlToCompare="newPassword"/></td>
                                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="Button1" runat="server" Text="Parolanızı Değiştirin" 
                Width="131px" Height="31px" onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

