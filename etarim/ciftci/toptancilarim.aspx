<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="toptancilarim.aspx.cs" Inherits="ciftci_toptancilarim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 98%;
        }
        .style4
        {
            width: 670px;
        }
        .style7
        {
            width: 428px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table class="style3">
        <tr>
            <td>
                &nbsp;</td>
            <td class="style4">
                <table class="style3">
                    <tr>
                        <td class="style7">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Toptancılarım Sayfası"></asp:Label>
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
            <td class="style4" valign="top" align="left">
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label>
                <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                    style="margin-left: 569px" Text="Sil" Width="55px" Height="23px" />
       <asp:GridView ID="GridView1" runat="server"  
        AutoGenerateColumns="False" 
            OnSelectedIndexChanging="select"
         OnRowDeleting="GridView1_RowDeleting" DataKeyNames="t_edilen" Width="660px" 
           Height="35px" style="margin-top: 8px"
           AllowPaging="True"
        PageSize="15"
        OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal"
          
 >

           <AlternatingRowStyle BackColor="#F7F7F7" />

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
<asp:TemplateField HeaderText="E-mail">
<ItemTemplate>
<asp:Label ID="email" runat="server" Text='<%#Eval("email")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="İş Tel">
<ItemTemplate>
<asp:Label ID="is_tel" runat="server" Text='<%#Eval ("is_tel")%>' ReadOnly="true"> </asp:Label>
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
            </td>
            <td valign="top">
    &nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
                <br />
    &nbsp;
    <asp:Label ID="Label3" runat="server"></asp:Label>
                <asp:Label ID="Label8" runat="server"></asp:Label>
                <br />
    <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="False"
        style="margin-left: 7px" Width="320px" Height="90px" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">

        <AlternatingRowStyle BackColor="White" />

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

</Columns>
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
                <br />
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                    Text="Mail Gönder" style="margin-left: 9px" />
                <br />
                &nbsp;
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Konu:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox3" runat="server" MaxLength="250" Width="317px" 
                    style="margin-left: 10px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Mail:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox4" runat="server" Height="139px" MaxLength="990" 
                    TextMode="MultiLine" Width="316px" style="margin-left: 10px"></asp:TextBox>
                <br />
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Gönder" 
                    style="margin-left: 10px" />
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
    </table>

</asp:Content>

