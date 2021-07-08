<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="parolayidegistir.aspx.cs" Inherits="yonetici_parolayidegistir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 204%;
    }
    .style2
    {
        width: 182px;
    }
    .style3
    {
            width: 145px;
        }
    .style4
    {
        width: 35px;
    }
    .style5
    {
        width: 182px;
        height: 55px;
    }
    .style6
    {
        width: 145px;
        height: 55px;
    }
    .style7
    {
        height: 55px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style5">
        </td>
        <td class="style6">
            <table class="style1">
                <tr>
                    <td class="style4">
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
        <td class="style7">
            </td>
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
                            ControlToValidate="newPassword" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="MyTextBoxValidator" runat="server" 
                            ControlToValidate="newPassword"
                             ErrorMessage="Minimum uzunluk 6 karakter olmalıdır"
                                ValidationExpression=".{6}.*" />

                            </td>
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
                            <br />
                            <asp:CompareValidator runat="server" ID="mValidator" ControlToValidate="confPassword" 
                            ErrorMessage="Şifreler Uyuşmuyor!" ControlToCompare="newPassword"/>
                            </td>
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

