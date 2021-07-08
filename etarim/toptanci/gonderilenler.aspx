<%@ Page Title="" Language="C#" MasterPageFile="~/toptanci/toptanci.master" AutoEventWireup="true" CodeFile="gonderilenler.aspx.cs" Inherits="toptanci_gonderilenler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 201%;
    }
    .style2
    {
            width: 398px;
        }
    .style5
    {
        }
        .style6
        {
            width: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table class="style1">
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style2">
            <table class="style1">
                <tr>
                    <td class="style5" align="center">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Gönderilenler Kutusu Sayfası" Width="228px" style="margin-left: 0px"></asp:Label>
                    </td>
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
        <td class="style6">
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
        <td class="style6">
            &nbsp;</td>
        <td class="style2" valign="top">
     <asp:Button ID="Button1" runat="server" Text="sil" onclick="Button1_Click" 
           style="margin-left: 591px" Width="41px"   />
       <asp:GridView ID="GridView1" runat="server"
    
            
             AutoGenerateColumns="false" 
             BackColor=""
             
             AllowPaging="true" PageSize="15"
             OnPageIndexChanging="GridView1_PageIndexChanging"
             
           style="margin-top: 0px" Width="635px" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
<asp:TemplateField HeaderText="Kime">
<ItemTemplate>
<asp:Label ID="kimden" runat="server" Text='<%#Eval("kime")%>' ReadOnly="true" Height="20"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tarih">
<ItemTemplate>
<asp:Label ID="tarih" runat="server" Text='<%#Eval("tarih")%>' ReadOnly="true" Height="20" Width="120"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Konu">
<ItemTemplate>
<asp:Label ID="konu" runat="server" Text='<%#Eval ("konu") %>' ReadOnly="true" Height="20"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="">
<ItemTemplate>
<asp:ImageButton ID="okundu" runat="server" AlternateText='<%#Eval ("id")%>'  ImageUrl="~/image/send.ico"  OnClick="select"   Height="20" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="id" Visible="false">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%#Eval ("id")%>' ReadOnly="true" Height="20"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField   HeaderText="sil" >
<ItemTemplate>
    <asp:CheckBox ID="CheckBox" runat="server"  />
</ItemTemplate>
</asp:TemplateField>

</Columns>
    </asp:GridView>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                Text="Gönderilenler Kutusu Boş!"></asp:Label>
        </td>
        <td valign="top">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="konu" runat="server" Font-Bold="True" Width="310px"></asp:Label>
            <br />
    <asp:Label ID="mesaj" runat="server" Columns="20" Height="230px" 
        MaxLength="1000" style="margin-top: 5px; margin-left: 24px;" 
        Width="310px"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
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
        <td class="style6">
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
        <td class="style6">
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

