<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="toptanci_ara.aspx.cs" Inherits="ciftci_toptanci_ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 99%;
        }
        .style5
        {
            width: 716px;
        }
        .style6
        {
            width: 261px;
        }
        .style7
        {
        }
        .style8
        {
            width: 14px;
        }
        .style9
        {
            width: 44px;
        }
        .style11
        {
            width: 134px;
        }
        .style12
        {
            width: 133px;
        }
        .style13
        {
            width: 126px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
    <br />
    </table>
    <table class="style4">
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style5">
                <table class="style4">
                    <tr>
                        <td class="style7" align="center">
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Toptancı Arama-Ekleme Sayfası"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style5">
                <table class="style4">
                    <tr>
                        <td class="style13">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" Text="İsme göre"></asp:Label>
                        </td>
                        <td class="style11">
                            <asp:Label ID="Label5" runat="server" Text="Soyismine göre"></asp:Label>
                        </td>
                        <td class="style12">
                            <asp:Label ID="Label6" runat="server" Text="Şehire göre"></asp:Label>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style13">
    <asp:TextBox ID="TextBox1" runat="server" Height="22px" style="margin-left: 36px" Width="130px"></asp:TextBox>
                        </td>
                        <td class="style11">
    <asp:TextBox ID="TextBox2" runat="server" Height="22px" Width="130px"></asp:TextBox>
                        </td>
                        <td class="style12">
    <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="131px">
    </asp:DropDownList>
                        </td>
                        <td class="style9">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ara" 
            Width="63px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style5" align="center" valign="top">
    <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="False" 
        OnRowDeleting="GridView1_RowDeleting" Width="673px"  
        AllowPaging="True"
        PageSize="15"
        OnPageIndexChanging="GridView1_PageIndexChanging" 
                    style="margin-right: 0px; margin-top: 34px;" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal"
 >

        <AlternatingRowStyle BackColor="#F7F7F7" />

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
<asp:Label ID="cep" runat="server" Text='<%#Eval ("cep")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Adres İl">
<ItemTemplate>
<asp:Label ID="il" runat="server" Text='<%#Eval ("adres")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ekle/Sil">
<ItemTemplate>
<asp:ImageButton ID="ekle" runat="server"      ImageUrl="~/image/plus.ico"   OnClick="eklesil" Height="20" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Seç">
<ItemTemplate>
<asp:ImageButton ID="sec" runat="server"       ImageUrl="~/image/more.ico"   OnClick="sec" Height="18" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>


</Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
</asp:GridView>
                <br />
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                    Text="Aradığınız Kriterlere Uygun Toptancı Bulunamadı!"></asp:Label>
            </td>
            <td class="style6" valign="top">
    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label> 
                <br />
    <asp:Label ID="Label3" runat="server"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" Width="244px" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
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
            <td class="style8">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br >

</asp:Content>

