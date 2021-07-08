<%@ Page Title="" Language="C#" MasterPageFile="~/toptanci/toptanci.master" AutoEventWireup="true" CodeFile="urun_ekleme.aspx.cs" Inherits="toptanci_urun_ekleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style7
        {
            width: 329px;
        }
        .style9
    {
        width: 596px;
    }
        .style10
        {
            width: 133px;
        }
        .style11
        {
            width: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                <table class="style1">
                    <tr>
                        <td class="style7">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Ürün Ekleme Sayfası"></asp:Label>
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
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
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
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                 <body>
    <form id="form1" >
    <div>
    
        <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
    
     <body>
    <form id="form2" >
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="2" style="font-size: large; color: #000000">
                    Ürün Ekle</td>
            </tr>
            <tr>
                <td class="style10">
                    Türü</td>
                <td class="style6">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="style10">
                    Ürün Adı</td>
                <td class="style6">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="style10">
                    Miktarı(/kg)</td>
                <td class="style6">
                    
                    <asp:TextBox ID="TextBox3" runat="server" MaxLength="8" 
                        style="margin-bottom: 0px" Width="76px"></asp:TextBox>
                    
                &nbsp;<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                        ControlToValidate="TextBox3" ErrorMessage="**Gerçersiz Miktar Girdiniz" 
                        ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style5" valign="middle">
                    <asp:Button ID="Button1" runat="server"   style="margin-left: 3px; margin-top: 0px;" 
                        Text="Ekle" Width="91px" onclick="Button1_Click1" Height="32px" />
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                        Text="Boş Alan Bırakmayın!"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body></div>
    </form>
</body>&nbsp;</td>
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
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
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
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
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
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
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

