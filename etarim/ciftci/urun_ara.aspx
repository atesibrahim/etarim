<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="urun_ara.aspx.cs" Inherits="ciftci_urun_ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style12
     {
         width: 100%;
     }
     .style13
     {
            width: 698px;
        }
     .style15
     {
     }
        .style17
        {
            width: 147px;
        }
        .style18
        {
            width: 165px;
        }
        .style19
        {
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style12">
        <tr>
            <td>
                &nbsp;</td>
            <td class="style13">
                <table class="style12">
                    <tr>
                        <td class="style15" align="center">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Toptancı İhtiyaç Ürün Arama Sayfası"></asp:Label>
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
            <td>
                &nbsp;</td>
            <td class="style13">
                <table class="style12">
                    <tr>
                        <td class="style19">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label7" runat="server" Text="Ürün türüne göre"></asp:Label>
                        </td>
                        <td class="style17">
                            <asp:Label ID="Label8" runat="server" Text="Ürün adına göre"></asp:Label>
                        </td>
                        <td class="style18">
                            <asp:Label ID="Label9" runat="server" Text="Şehire göre"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top" class="style19">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
           OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="21px" 
           Width="100px" style="margin-left: 26px">
    </asp:DropDownList>
                        </td>
                        <td class="style17">
    <asp:DropDownList ID="DropDownList2" runat="server"  
           Height="22px" Width="102px">
    </asp:DropDownList>
                        </td>
                        <td class="style18">
    <asp:DropDownList ID="DropDownList3" runat="server"  
            Height="22px" Width="100px">
    </asp:DropDownList>
                        </td>
                        <td>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ara" 
            Height="22px" Width="63px" />
    
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
            <td>
                &nbsp;</td>
            <td class="style13" align="center">
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
            <td class="style13" valign="top" align="center">
      
       <asp:GridView ID="GridView1" runat="server" 
              style="margin-left: 0px; margin-top: 7px; margin-right: 0px;" AutoGenerateColumns="False" 
              Width="666px" CellPadding="4" ForeColor="#333333" GridLines="None" >

           <AlternatingRowStyle BackColor="White" />

        <Columns>

<asp:TemplateField HeaderText="Ürün Tür Adı">
<ItemTemplate>
<asp:Label ID="tur_ad" runat="server" Text='<%#Eval("tur_ad")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ürün Adı">
<ItemTemplate>
<asp:Label ID="ad" runat="server" Text='<%#Eval("isim")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Miktarı">
<ItemTemplate>
<asp:Label ID="miktar" runat="server" Text='<%#Eval ("miktar") %>' ReadOnly="true"></asp:Label>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Bölge">
<ItemTemplate>
<asp:Label ID="il_ad" runat="server" Text='<%#Eval ("il")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Toptancı" Visible="false">
<ItemTemplate>
<asp:Label ID="top" runat="server" Text='<%#Eval ("toptanci")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Seç">
<ItemTemplate>
<asp:ImageButton ID="sec" runat="server"       ImageUrl="~/image/more.ico"   OnClick="sec" Height="18" Width="22"> </asp:ImageButton>
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
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
       
            </td>
            <td valign="top">
           <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ></asp:Label> 
                <br />
           <asp:Label ID="Label1" runat="server" ></asp:Label> 
                <br />
           <asp:Label ID="Label2" runat="server" ></asp:Label>
                <br />
           <asp:Label ID="Label3" runat="server" ></asp:Label>
                <br />
           <asp:Label ID="Label4" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="Label11" runat="server"></asp:Label>
                <br />
           <asp:Label ID="Label5" runat="server"></asp:Label>
                <br />
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                    Text="Mail Gönder" Width="94px" />
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                    Text="Toptancılarıma Ekle" style="margin-left: 56px" Width="136px" />
                <br />
                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Konu:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="250" Width="290px"></asp:TextBox>
                <br />
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Mail:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" Height="163px" MaxLength="990" 
                    TextMode="MultiLine" Width="290px"></asp:TextBox>
                <br />
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Gönder" />
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
            <td class="style13">
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
            <td class="style13">
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
            <td class="style13">
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

