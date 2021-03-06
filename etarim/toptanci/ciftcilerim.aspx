<%@ Page Title="" Language="C#" MasterPageFile="~/toptanci/toptanci.master" AutoEventWireup="true" CodeFile="ciftcilerim.aspx.cs" Inherits="toptanci_ciftcilerim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 124%;
        margin-bottom: 0px;
    }
    .style2
    {
        width: 554px;
    }
    .style3
    {
        width: 176px;
    }
    .style4
    {
        width: 298px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table class="style1">
    <tr>
        <td>
            &nbsp;</td>
        <td class="style2">
            <table class="style1">
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Çiftçilerim Sayfası"></asp:Label>
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
        <td class="style2" align="center" valign="top">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                Text="Henüz Ekli Çiftçiniz Bulunmamaktadır!"></asp:Label>

            <br />
            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                style="margin-left: 571px" Text="Sil" Width="46px" />
       <asp:GridView ID="GridView1" runat="server" PageSize="3"  
        AutoGenerateColumns="False" AutoGenerateDeleteButton="False" AutoGenerateSelectButton="False" 
         OnRowDeleting="GridView1_RowDeleting" DataKeyNames="t_edilen" Width="672px"
 >

<Columns>
       
<asp:TemplateField HeaderText="kod" Visible="false">
<ItemTemplate>
<asp:Label ID="t_edilen" runat="server" Text='<%#Eval("t_edilen")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="İsim">
<ItemTemplate>
<asp:Label ID="ad" runat="server" Text='<%#Eval("ad")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Soyisim">
<ItemTemplate>
<asp:Label ID="soyad" runat="server" Text='<%#Eval ("soyad") %>' ReadOnly="true"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Cep Tel">
<ItemTemplate>
<asp:Label ID="is_tel" runat="server" Text='<%#Eval ("cep_tel")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Adres İl">
<ItemTemplate>
<asp:Label ID="adres" runat="server" Text='<%#Eval ("il")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>

 <asp:TemplateField HeaderText="Sil">
       <ItemTemplate>
    <asp:CheckBox ID="CheckBox" runat="server"  />
</ItemTemplate>
       
  </asp:TemplateField>
<asp:TemplateField HeaderText="Seç">
<ItemTemplate>
<asp:ImageButton ID="sec" runat="server"       ImageUrl="~/image/more.ico"   OnClick="sec" Height="18" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>


</Columns>
</asp:GridView>

            <br />
            <br />

        </td>
        <td valign="top">
    &nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
            <br />
    &nbsp;
    <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            &nbsp;
            <asp:Label ID="Label6" runat="server"></asp:Label>
    <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="false"
        style="margin-left: 11px" Width="223px" Height="90px">

        <Columns>
<asp:TemplateField HeaderText="Ürün Türü">
<ItemTemplate>
<asp:Label ID="tur_ad" runat="server" Text='<%#Eval("tur_ad")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ürün Adı">
<ItemTemplate>
<asp:Label ID="ad0" runat="server" Text='<%#Eval("ad")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Miktar">
<ItemTemplate>
<asp:Label ID="soyad0" runat="server" Text='<%#Eval ("miktar") %>' ReadOnly="true"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fiyat">
<ItemTemplate>
<asp:Label ID="fiyad" runat="server" Text='<%#Eval ("fiyat") %>' ReadOnly="true"></asp:Label>
</ItemTemplate>
</asp:TemplateField>


</Columns>
       </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                style="margin-left: 13px" Text="Mail Gönder" Width="85px" />
            <br />
            &nbsp;
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Konu:"></asp:Label>
            <br />
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="250" Width="306px"></asp:TextBox>
            <br />
            &nbsp;
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Mail:"></asp:Label>
            <br />
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Height="188px" Width="303px" 
                TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                style="margin-left: 11px" Text="Gönder" Width="71px" />
        </td>
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
        <td>
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
        <td>
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
