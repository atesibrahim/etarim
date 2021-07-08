<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="gonderilenler.aspx.cs" Inherits="yonetici_gonderilenler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 143%;
    }
    .style2
    {
        width: 346px;
    }
    .style3
    {
        width: 97px;
    }
    .style4
    {
        width: 198px;
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
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Gönderilenler Kutusu"></asp:Label>
                    </td>
                    <td class="style3">
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
        <td class="style2">
            <asp:Label ID="Label2" runat="server"></asp:Label>
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
        <td class="style2">
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button1" runat="server" Text="sil" onclick="Button1_Click" 
           style="margin-left: 574px" Width="43px" Height="26px"   />
       <asp:GridView ID="GridView1" runat="server"
    
            
             AutoGenerateColumns="false" 
             BackColor=""
             
             AllowPaging="true" PageSize="15"
             OnPageIndexChanging="GridView1_PageIndexChanging"
             
           style="margin-top: 0px" Width="622px">
            <Columns>
<asp:TemplateField HeaderText="Kime">
<ItemTemplate>
<asp:Label ID="kimden" runat="server" Text='<%#Eval("kime")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tarih">
<ItemTemplate>
<asp:Label ID="tarih" runat="server" Text='<%#Eval("tarih")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Konu">
<ItemTemplate>
<asp:Label ID="konu" runat="server" Text='<%#Eval ("konu") %>' ReadOnly="true"></asp:Label>
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
    </asp:GridView>
            <br />
        </td>
        <td valign="top">
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
&nbsp;
            <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
    <asp:Label ID="mesaj" runat="server" Columns="20" 
        MaxLength="1000" style="margin-top: 8px; margin-left: 24px;" 
        Width="245px"></asp:Label>
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

