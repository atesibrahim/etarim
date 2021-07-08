<%@ Page Title="" Language="C#" MasterPageFile="~/toptanci/toptanci.master" AutoEventWireup="true" CodeFile="urun_ekle(kullanilmiyor).aspx.cs" Inherits="toptanci_urun_ekle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 98%;
            height: 163px;
            margin-top: 22px;
        }
        .style2
        {
        }
        .style3
        {
            width: 75px;
        }
        #form1
        {
            height: 26px;
            width: 982px;
            margin-left: 22px;
            margin-top: 45px;
        }
        .style4
        {
            width: 75px;
            height: 28px;
        }
        .style5
        {
            height: 28px;
            width: 209px;
        }
        .style6
        {
            width: 209px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <body>
    <form id="form1" >
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="2">
                    Ürün Ekle</td>
            </tr>
            <tr>
                <td class="style3">
                    Türü</td>
                <td class="style6">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="style3">
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
                <td class="style3">
                    Miktarı(/kg)</td>
                <td class="style6">
                    
                    <asp:TextBox ID="TextBox3" runat="server" MaxLength="8" 
                        style="margin-bottom: 0px" Width="63px"></asp:TextBox>
                    
                &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="Button1" runat="server"   style="margin-left: 3px; margin-top: 0px;" 
                        Text="Ekle" Width="91px" onclick="Button1_Click1" Height="32px" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</asp:Content>

