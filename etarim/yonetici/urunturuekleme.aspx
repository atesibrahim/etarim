<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="urunturuekleme.aspx.cs" Inherits="yonetici_urunturuekleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
    {
        width: 99%;
    }
    .style2
    {
        width: 119px;
    }
        .style4
        {
            width: 209px;
        }
        .style5
        {
            width: 225%;
        }
        .style6
        {
            width: 121px;
        }
        .style7
        {
            width: 210px;
        }
        .style8
        {
            width: 119px;
            height: 59px;
        }
        .style9
        {
            width: 209px;
            height: 59px;
        }
        .style10
        {
            width: 210px;
            height: 59px;
        }
        .style11
        {
            height: 59px;
        }
        .style12
        {
            width: 119px;
            height: 29px;
        }
        .style13
        {
            width: 209px;
            height: 29px;
        }
        .style14
        {
            width: 210px;
            height: 29px;
        }
        .style15
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style4">
            <table class="style5">
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Ürün Ailesi ve İsmi Ekleme Sayfası" EnableViewState="True" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style4">
            &nbsp;</td>
        <td class="style7">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Seçiniz</asp:ListItem>
                <asp:ListItem Value="Ürün Ailesi Ekleme">Ürün Ailesi Ekleme</asp:ListItem>
                <asp:ListItem Value="Ürün İsmi Ekleme">Ürün İsmi Ekleme</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style12">
        </td>
        <td class="style13">
            <asp:Label ID="Label1" runat="server" Text="Ürün Ailesi" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Ürün Ailesi" Visible="False"></asp:Label>
        </td>
        <td class="style14">
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="30" Visible="False" 
                Width="125px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList2" runat="server" Visible="False" 
                Height="22px" Width="124px" style="margin-left: 0px">
            </asp:DropDownList>
               <br />
        </td>
                                
        <td class="style15">
            <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox1" ID="RequiredFieldValidator2" ErrorMessage="* Alanı Boş Bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator><br />
        
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="** Sadece harf kullanabilirsiniz." 
                        ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$"></asp:RegularExpressionValidator>
               <br />
        <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="DropDownList2" ID="cv18" 
                                        ErrorMessage="* Lütfen bir tür seçiniz." ForeColor="Red" 
                                        InitialValue="Seçiniz"></asp:RequiredFieldValidator></td>
        <td class="style15">
            </td>
        <td class="style15">
            </td>
    </tr>
    <tr>
        <td class="style8">
            <br />
            <br />
        </td>
        <td class="style9">
            <asp:Label ID="Label2" runat="server" Text="Ürün İsmi " Visible="False"></asp:Label>
            <br />
            <br />
        </td>
        <td class="style10">
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Rows="30" Visible="False" 
                style="margin-left: 0px" Width="124px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ekle" 
                Width="68px" Visible="False" />
        </td>
        <td class="style11">
            <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox2" ID="RequiredFieldValidator1" ErrorMessage="* Alanı Boş Bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="** Sadece harf kullanabilirsiniz." 
                        ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$"></asp:RegularExpressionValidator>
            <br />
            <br />
            </td>
        <td class="style11">
            </td>
        <td class="style11">
            </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style4">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style4">
            &nbsp;</td>
        <td class="style7">
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

