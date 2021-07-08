<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="gelen_kutusu.aspx.cs" Inherits="ciftci_gelen_kutusu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            margin-bottom: 0px;
        }
        .style2
        {
            width: 600px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1" align="center">
        <tr>
            <h6 style="font-size: x-large; position: static" align="center">Gelen Kutusu  </h6>
        </tr>
        <tr valign="top">
            <td class="style2">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Bold="True">Gelen Kutusu Boş!</asp:Label>
                <br />
    <asp:Button ID="Button1" runat="server" Text="sil" onclick="Button1_Click" 
           style="margin-left: 650px" Width="43px"   />
       <asp:GridView ID="GridView1" runat="server"
       
        SelectedRowStyle-BackColor="Blue"
        AutoGenerateColumns="False" 
        AllowPaging="True"
        PageSize="15"
        OnPageIndexChanging="GridView1_PageIndexChanging"      
           style="margin-top: 0px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    Width="696px"  >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
<asp:TemplateField HeaderText="Kimden" >
<ItemTemplate>
<asp:Label ID="kimden" runat="server" Text='<%#Eval("kimden")%>' ReadOnly="true" Height="20" Width="155"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tarih">
<ItemTemplate>
<asp:Label ID="tarih" runat="server" Text='<%#Eval("tarih")%>' ReadOnly="true" Height="20" Width="120"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Konu" >
<ItemTemplate>
<asp:Label ID="konu" runat="server"   Text='<%#Eval ("konu") %>'  ReadOnly="true" Height="20" Width="200" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                
<asp:TemplateField HeaderText="">
<ItemTemplate>
<asp:ImageButton ID="okundu" runat="server"     AlternateText='<%#Eval ("okundu")%>'  ImageUrl=""   OnClick="select" Height="18" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField  HeaderText="id" Visible="False">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%#Eval ("id")%>' ReadOnly="true" Visible="false"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField   HeaderText="sil" >
<ItemTemplate>
    <asp:CheckBox ID="CheckBox" runat="server"  Height="20" Width="20" />
</ItemTemplate>
</asp:TemplateField>
</Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />

<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td valign="top">
                &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Width="279px" 
                    style="margin-left: 0px"></asp:Label>
                <br />
    <asp:Label ID="mesaj" runat="server" Columns="20" 
        MaxLength="1000" style="margin-top: 0px; margin-left: 10px;" 
        Width="279px"></asp:Label>
                <br />
                <br />
                &nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                    Text="Cevapla" style="margin-left: 0px" />
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Konu:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="250" Width="278px" 
                    style="margin-left: 10px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Mail:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" Height="206px" MaxLength="990" 
                    TextMode="MultiLine" Width="280px" style="margin-left: 10px"></asp:TextBox>
                <br />
                &nbsp;
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Gönder" />
            </td>
        </tr>
        </table>
</asp:Content>

