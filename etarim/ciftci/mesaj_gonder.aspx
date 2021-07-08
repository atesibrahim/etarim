<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="mesaj_gonder.aspx.cs" Inherits="ciftci_mesaj_gonder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 319px;
        }
        .style3
        {
            width: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Mail Gönderme Sayfası"></asp:Label>
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
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Kime"></asp:Label>
                <br />
                <br />
    <asp:RadioButton ID="yonetici" runat="server" GroupName="giden_mesaj" 
        Text="Yönetici"   OnCheckedChanged="yon_teknik" AutoPostBack="True" />
    <asp:RadioButton ID="teknik" runat="server" GroupName="giden_mesaj" 
        Text="Teknik Destek"  OnCheckedChanged="yon_teknik" AutoPostBack="True" />
                <br />
    <asp:RadioButton ID="diger" runat="server" GroupName="giden_mesaj" 
        Text="Diğer(E-mail adresi)" OnCheckedChanged="digerleri" AutoPostBack="True" />
    <asp:TextBox ID="kime" runat="server" 
        style="margin-left: 17px; margin-top: 14px;" Height="25px" Width="299px" 
                    Visible="false"></asp:TextBox>&nbsp;
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="kime" ErrorMessage="**Geçersiz E-mail Formatı">
                                    </asp:RegularExpressionValidator><br />
    <br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Konu"></asp:Label>
    <asp:TextBox ID="konu" runat="server" MaxLength="150" 
        style="margin-left: 21px" Width="294px" Height="23px"></asp:TextBox>
                <br />
                <br />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Mesaj"></asp:Label>
   <br />
   &nbsp;<asp:TextBox ID="mesaj" runat="server" Height="192px" MaxLength="1000" 
        Width="414px" Rows="20" style="margin-left: 146px" TextMode="MultiLine"></asp:TextBox>
                <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
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
            <td class="style3">
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
            <td class="style3">
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

