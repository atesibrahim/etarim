<%@ Page Title="" Language="C#" MasterPageFile="~/bilgisayarprof/bilgisayarprof.master" AutoEventWireup="true" CodeFile="mesaj_gonder.aspx.cs" Inherits="bilgisayarprof_mesaj_gonder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    .style2
    {
        width: 560px;
    }
    .style3
    {
        width: 22px;
    }
    .style4
    {
        width: 22px;
        height: 21px;
    }
    .style5
    {
        width: 560px;
        height: 21px;
    }
    .style6
    {
        height: 21px;
    }
    .style7
    {
        width: 365px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table class="style1">
        <tr>
            <td class="style4">
                </td>
            <td class="style5">
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style7">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Mail Gönderme Sayfası"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                 <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Kime"></asp:Label>
                 <br />
&nbsp;<br />
    <asp:RadioButton ID="yonetici" runat="server" GroupName="giden_mesaj" 
        Text="Yönetici"   OnCheckedChanged="yon_teknik" AutoPostBack="True" />
    
                 <br />
    
    <asp:RadioButton ID="diger" runat="server" GroupName="giden_mesaj" 
        Text="Diğer(E-mail adresi)" OnCheckedChanged="digerleri" AutoPostBack="True" 
                     Width="144px" />
    <asp:TextBox ID="kime" runat="server" 
        style="margin-left: 17px; margin-top: 14px;" Height="25px" Width="215px" 
                     Visible="false"></asp:TextBox>&nbsp; 
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="kime" ErrorMessage="**Geçersiz E-mail Formatı">
                                    </asp:RegularExpressionValidator><br />
    <br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:Label ID="Label2" runat="server" Text="Konu"></asp:Label>
    <asp:TextBox ID="konu" runat="server" MaxLength="150" 
        style="margin-left: 24px" Width="213px"></asp:TextBox><br />
   <br />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mesaj  <br />
    <asp:TextBox ID="mesaj" runat="server" Height="152px" MaxLength="1000" 
        Width="395px" Rows="20" style="margin-left: 160px" TextMode="MultiLine"></asp:TextBox>
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click" 
                     style="margin-left: 71px" />&nbsp;</td>
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
            <td class="style2">
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
            <td class="style2">
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
            <td class="style2">
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
            <td class="style2">
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

