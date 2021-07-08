<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="urunlerim.aspx.cs" Inherits="ciftci_urunlerim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 354px;
        }
        .style3
        {
            width: 95px;
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
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Ürünlerim Sayfası"></asp:Label>
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
            <td align="left" valign="top">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                    Text="Henüz Ekli Ürününüz Bulunmamaktadır!"></asp:Label>
                <br />

  
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="margin-left: 0px" Text="Sil" Width="62px" />
    <asp:GridView ID="GridView1" runat="server" PageSize="3"  
        AutoGenerateColumns="False" 
        onselectedindexchanged="GridView1_SelectedIndexChanged1" 
        DataKeyNames="urun_kod"  
        OnRowDeleting="GridView1_RowDeleting"  
        OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnPageIndexChanging="GridView1_PageIndexChanging" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" Height="50px" 
        style="margin-top: 10px; margin-left: 0px;" Width="633px" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">

        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

<Columns>
        <asp:TemplateField HeaderText="Düzenle-Sil">
        <ItemTemplate>
        <asp:ImageButton ID="edit"  AlternateText="edit" runat="server"  ImageUrl="~/image/edit.ico" CommandName="Edit" Height="20" Width="22"></asp:ImageButton>
        <asp:CheckBox ID="CheckBox" runat="server"  Height="20" Width="20" />
        </ItemTemplate>
        <EditItemTemplate>
        <asp:ImageButton ID="Update"  runat="server" ImageUrl="~/image/update.ico" CommandName="Update" Height="20" Width="22"></asp:ImageButton>
       <asp:ImageButton ID="Cancel"  runat="server" ImageUrl="~/image/cancel_edit.ico" CommandName="Cancel" Height="20" Width="22"></asp:ImageButton>
        
        </EditItemTemplate>
        </asp:TemplateField>
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
<asp:TextBox ID="miktar" runat="server" Text='<%#Eval ("miktar")%>' ReadOnly="" Height="20" Width="100"> </asp:TextBox>
<asp:CompareValidator runat="server" ID="mValidator" ControlToValidate="miktar"
     Type="Double" Operator="DataTypeCheck" EnableClientScript="true"
     ErrorMessage="Lütfen miktarı doğru giriniz!" Display="Dynamic" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fiyatı(/TL)">
<ItemTemplate>
<asp:TextBox ID="fiyat" runat="server"  Text='<%#Eval ("fiyat")%>' ReadOnly="true" Height="20" Width="100"> </asp:TextBox>
<asp:CompareValidator runat="server" ID="cValidator" ControlToValidate="fiyat"
     type="String" Operator="DataTypeCheck" EnableClientScript="true"   
     ErrorMessage="lütfen fiyatı doğru giriniz!" Display="Dynamic" />
</ItemTemplate>
</asp:TemplateField>


</Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />       
</asp:GridView>

  
                <br />

  
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
    </table>

  
    </asp:Content>

