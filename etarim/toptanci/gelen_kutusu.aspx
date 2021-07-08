<%@ Page Title="" Language="C#" MasterPageFile="~/toptanci/toptanci.master" AutoEventWireup="true" CodeFile="gelen_kutusu.aspx.cs" Inherits="toptanci_gelen_kutusu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 206%;
    }
    .style3
    {
            width: 212px;
        }
    .style4
    {
        width: 83px;
    }
    .style5
    {
        width: 356px;
    }
    .style6
    {
        width: 79px;
    }
        .style7
        {
            width: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table class="style1">
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td class="style3">
            <table class="style1">
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style6">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Gelen Kutusu Sayfası" Width="200px"></asp:Label>
                    </td>
                    <td class="style4">
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
        <td class="style7">
            &nbsp;</td>
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
        <td class="style7">
            &nbsp;</td>
        <td class="style3" valign="top">
    <asp:Button ID="Button1" runat="server" Text="sil" onclick="Button1_Click" 
           style="margin-left: 624px" Width="48px"   />
            <br />
       <asp:GridView ID="GridView1" runat="server"
       
        SelectedRowStyle-BackColor="Blue"
        BackColor=""
        AutoGenerateColumns="false" 
        AllowPaging="True"
        PageSize="15"
        OnPageIndexChanging="GridView1_PageIndexChanging"      
           style="margin-top: 0px" Width="689px"  >
            <Columns>
<asp:TemplateField HeaderText="Kimden" >
<ItemTemplate>
<asp:Label ID="kimden" runat="server" Text='<%#Eval("kimden")%>' ReadOnly="true" > </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tarih">
<ItemTemplate>
<asp:Label ID="tarih" runat="server" Text='<%#Eval("tarih")%>' ReadOnly="true" Width="120"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Konu">
<ItemTemplate>
<asp:Label ID="konu" runat="server" Text='<%#Eval ("konu") %>' ReadOnly="true"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                
<asp:TemplateField HeaderText="">
<ItemTemplate>
<asp:ImageButton ID="okundu" runat="server"     AlternateText='<%#Eval ("okundu")%>'  ImageUrl=""   OnClick="select" Height="20" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField  HeaderText="id" Visible="False">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%#Eval ("id")%>' ReadOnly="true" Visible="false"> </asp:Label>
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
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Gelen Kutusu Boş!"></asp:Label>
        </td>
        <td valign="top">
            &nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
            <br />
    <asp:Label ID="mesaj" runat="server" Columns="20" Height="40px" 
        MaxLength="1000" style="margin-top: 9px; margin-left: 9px; margin-bottom: 0px;" 
        Width="300px"></asp:Label>
            <br />
            &nbsp;
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                Text="Cevapla" />
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />
            &nbsp;
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Konu:"></asp:Label>
            <br />
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="250" Width="299px"></asp:TextBox>
            <br />
            &nbsp;
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Mail:"></asp:Label>
            <br />
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Height="180px" MaxLength="990" 
                TextMode="MultiLine" Width="299px"></asp:TextBox>
            <br />
            &nbsp;
            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Gönder" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
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
        <td class="style7">
            &nbsp;</td>
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
        <td class="style7">
            &nbsp;</td>
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

