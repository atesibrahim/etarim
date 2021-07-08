<%@ Page Title="" Language="C#" MasterPageFile="~/toptanci/toptanci.master" AutoEventWireup="true" CodeFile="ciftci_ara.aspx.cs" Inherits="toptanci_ciftci_ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
    {
        width: 101%;
    }
    .style2
    {
            width: 5px;
        }
    .style3
    {
        width: 343px;
    }
        .style4
        {
            width: 114px;
        }
        .style6
        {
            width: 82px;
        }
        .style7
        {
            width: 232px;
        }
        .style9
        {
            width: 399px;
        }
        .style10
        {
            width: 3px;
        }
        .style11
        {
            width: 461px;
        }
        .style12
        {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style9">
            <table class="style1">
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style7">
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Çiftçi Arama-Ekleme Sayfası"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style9">
            <br />
            <table class="style1">
                <tr>
                    <td class="style4">
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Text="İsmine göre"></asp:Label>
                    </td>
                    <td class="style12">
                        <asp:Label ID="Label5" runat="server" Text="Soyismine göre"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:Label ID="Label6" runat="server" Text="Şehire göre"></asp:Label>
                    </td>
                    <td class="style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:TextBox ID="TextBox1" runat="server" Width="128px"></asp:TextBox>
                    </td>
                    <td class="style12">
    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" Width="128px"></asp:TextBox>
                    </td>
                    <td class="style6">
    <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="128px">
    </asp:DropDownList>
                    </td>
                    <td class="style2">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ara" 
            Width="68px" style="margin-left: 0px" />
                    </td>
                </tr>
            </table>
        </td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style9" align="center">
            <br />
    <asp:GridView ID="GridView1" runat="server" PageSize="3"  
        AutoGenerateColumns="False"  
         Width="651px"  
 >

<Columns>
        
<asp:TemplateField HeaderText="kod" Visible="false">
<ItemTemplate>
<asp:Label ID="kodu" runat="server" Text='<%#Eval("kodu")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="İsim">
<ItemTemplate>
<asp:Label ID="adi" runat="server" Text='<%#Eval("adi")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Soyisim">
<ItemTemplate>
<asp:Label ID="soyad" runat="server" Text='<%#Eval ("soyad") %>' ReadOnly="true"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Cep Tel">
<ItemTemplate>
<asp:Label ID="is_tel" runat="server" Text='<%#Eval ("cep")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Adres İl">
<ItemTemplate>
<asp:Label ID="adres" runat="server" Text='<%#Eval ("adres")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ekle/Sil">
        <ItemTemplate>
        <asp:ImageButton ID="Delete" ImageUrl=""   runat="server" OnClick="eklesil" Height="20" Width="22"></asp:ImageButton>
        </ItemTemplate>
        </asp:TemplateField>
<asp:TemplateField HeaderText="Seç">
<ItemTemplate>
<asp:ImageButton ID="sec" runat="server"  ImageUrl="~/image/more.ico"   OnClick="sec" Height="18" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>

</Columns>
</asp:GridView>
            <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                Text="Aradığınız Kriterlere Uygun Çiftçi Bulunmamaktadır!"></asp:Label>
<br />
        </td>
        <td class="style11" valign="top">
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label> 
    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
            <br />
    &nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" Width="108px" AutoGenerateColumns="false" 
                onselectedindexchanged="GridView2_SelectedIndexChanged" 
                style="margin-left: 12px">
    <Columns>
    <asp:TemplateField HeaderText="Ürün Kodu" Visible="false">
<ItemTemplate>
<asp:Label ID="urun_kod" runat="server" Text='<%#Eval ("urun_kod")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tür Kodu" Visible="false">
<ItemTemplate>
<asp:Label ID="tur_kod" runat="server" Text='<%#Eval ("tur_kod")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Urun Türü">
<ItemTemplate>
<asp:Label ID="tur_ad" runat="server" Text='<%#Eval("tur_ad")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ürün Adı">
<ItemTemplate>
<asp:Label ID="ad" runat="server" Text='<%#Eval ("ad") %>' ReadOnly=""></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Miktarı(/kg)">
<ItemTemplate>
<asp:Label ID="miktar" runat="server" Text='<%#Eval ("miktar")%>' ReadOnly="" Height="20" Width="100"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fiyatı(/TL)">
<ItemTemplate>
<asp:Label ID="fiyat" runat="server"  Text='<%#Eval ("fiyat")%>' ReadOnly="true" Height="20" Width="100"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>



</Columns>

    </asp:GridView>

        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style11">
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

