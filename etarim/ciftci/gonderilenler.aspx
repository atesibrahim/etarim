<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="gonderilenler.aspx.cs" Inherits="ciftci_gonderilenler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 118%;
        }
        .style2
        {
        }
        .style3
        {
            width: 327px;
        }
        .style4
        {
            width: 681px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2" colspan="2">
                <table class="style1">
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" 
                                Font-Size="Medium" Text="Gönderilenler Kutusu Sayfası"></asp:Label>
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
            <td>
                &nbsp;</td>
            <td class="style4" align="center" valign="top">
                <br />
     <asp:Button ID="Button1" runat="server" Text="sil" onclick="Button1_Click" 
           style="margin-left: 582px" Width="42px"   />
       <asp:GridView ID="GridView1" runat="server"
    
            
             AutoGenerateColumns="False"
             
             AllowPaging="True" PageSize="15"
             OnPageIndexChanging="GridView1_PageIndexChanging"
             
           style="margin-top: 4px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    Width="651px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
<asp:TemplateField HeaderText="Kime">
<ItemTemplate>
<asp:Label ID="kimden" runat="server" Text='<%#Eval("kime")%>' ReadOnly="true" Height="20" Width="155"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tarih">
<ItemTemplate>
<asp:Label ID="tarih" runat="server" Text='<%#Eval("tarih")%>' ReadOnly="true" Height="20" Width="120"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Konu">
<ItemTemplate>
<asp:Label ID="konu" runat="server" Text='<%#Eval ("konu") %>' ReadOnly="true" Height="20" Width="200" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="">
<ItemTemplate>
<asp:ImageButton ID="okundu" runat="server" AlternateText='<%#Eval ("id")%>'  ImageUrl="~/image/send.ico"  OnClick="select"   Height="20" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="id" Visible="false">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%#Eval ("id")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField   HeaderText="sil" >
<ItemTemplate>
    <asp:CheckBox ID="CheckBox" runat="server"  />
</ItemTemplate>
</asp:TemplateField>

</Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
                <br />
                <asp:Label ID="Label13" runat="server" Font-Bold="True" 
                    Text="Gönderilenler Kutusu Boş!"></asp:Label>
            </td>
            <td valign="top">
                <br />
                <asp:Label ID="Label14" runat="server" Font-Bold="True" 
                    style="margin-left: 10px" Width="303px"></asp:Label>
                <br />
    <asp:Label ID="mesaj" runat="server" Columns="20" Height="247px" 
        MaxLength="1000" style="margin-top: 2px; margin-left: 10px;" 
        Width="303px"></asp:Label>
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
            <td class="style4">
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
            <td class="style4">
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
            <td class="style4">
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
            <td class="style4">
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

