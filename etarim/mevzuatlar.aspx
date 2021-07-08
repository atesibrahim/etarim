<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="mevzuatlar.aspx.cs" Inherits="mevzuatlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        height: 55px;
    }
    .style4
    {
        height: 55px;
        width: 75px;
    }
    .style5
    {
        width: 75px;
    }
    .style6
    {
        width: 224px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <tr>
        <td>
<table class="style1">
<form runat ="server">
            <tr>
                <td class="style4">
                </td>
                <td class="style2">
                    <table class="style1">
                        <tr>
                            <td class="style6">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    Text="Yararlı Dosyalar"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1" onrowcommand="GridView1_RowCommand" 
                        style="margin-left: 1px" Width="593px">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Dosya No" SortExpression="id" Visible="false"/>
                            
                            <asp:BoundField DataField="aciklama" HeaderText="Dosya Adı" 
                                SortExpression="dosyaadresi" />

                            <asp:BoundField DataField="dosyaadresi" HeaderText="Dosya" 
                                SortExpression="dosyaadresi" />
                            <asp:ButtonField ButtonType="Link" CommandName="Dwn" HeaderText="İndirme" 
                                Text="Dosyayı indir" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id], [dosyaadresi], [aciklama] 

                   FROM [dosyalar]"></asp:SqlDataSource>
                    <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
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
                <td class="style5">
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
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
        </form>
            </tr>
        </table>
        </td>
    </tr>
</asp:Content>


