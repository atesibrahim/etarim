<%@ Page Title="" Language="C#" MasterPageFile="~/bilgisayarprof/bilgisayarprof.master" AutoEventWireup="true" CodeFile="gonderilenler.aspx.cs" Inherits="bilgisayarprof_gonderilenler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
    {
        width: 108%;
    }
    .style3
    {
        width: 350px;
    }
    .style4
    {
        width: 368px;
    }
    .style5
    {
        width: 151px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style2">
    <tr>
        <td>
            &nbsp;</td>
        <td class="style3">
            <table class="style2">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Gönderilen Kutusu Sayfası"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td class="style4">
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
        <td class="style3" valign="top">
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
     <asp:Button ID="Button1" runat="server" Text="sil" onclick="Button1_Click" 
           style="margin-left: 470px" Width="46px"   />
            <br />
       <asp:GridView ID="GridView1" runat="server"
    
            
             AutoGenerateColumns="false" 
             BackColor=""
             
             AllowPaging="true" PageSize="15"
             OnPageIndexChanging="GridView1_PageIndexChanging"
             
           style="margin-top: 0px" Width="517px">
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
        </td>
        <td class="style4" valign="top">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Width="339px"></asp:Label>
            <br />
            <br />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="mesaj" runat="server" Columns="20" 
        MaxLength="1000" style="margin-top: 4px; margin-left: 33px;" 
        Width="339px"></asp:Label>
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
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
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
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
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
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
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
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
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

