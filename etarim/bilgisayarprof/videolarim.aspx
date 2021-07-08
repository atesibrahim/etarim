<%@ Page Title="" Language="C#" MasterPageFile="~/bilgisayarprof/bilgisayarprof.master" AutoEventWireup="true" CodeFile="videolarim.aspx.cs" Inherits="bilgisayarprof_videolarim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 101%;
        }
        .style2
        {
            width: 532px;
        }
        .style3
        {
            width: 453px;
        }
        .style4
        {
            width: 185px;
        }
        .style5
        {
            width: 146%;
        }
        .style6
        {
            width: 360px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel2" runat="server" Height="1082px">
        <table class="style1">
            <tr>
                <td class="style2">
                    <table class="style5">
                        <tr>
                            <td class="style6">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    Text="Videolarım Sayfası"></asp:Label>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <table class="style1">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style3">
                                &nbsp;</td>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1" Height="158px" 
                        onrowcommand="GridView1_RowCommand" Width="780px">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Video No" SortExpression="id" 
                                Visible="True" />
                            <asp:BoundField DataField="aciklama" HeaderText="Video İsmi" 
                                SortExpression="aciklama" />
                            <asp:TemplateField HeaderText="Video Adresi">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkname" runat="server" PostBackUrl='<%#Eval("url")%>' 
                                        Text='<%#Eval("url") %>'>

</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField ButtonType="Link" CommandName="Del" HeaderText="Video Silme" 
                                Text="Videoyu sil" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [url], [aciklama], [id] FROM [videolar] ORDER BY [id] DESC">
                    </asp:SqlDataSource>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
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
                <td>
                    &nbsp;</td>
            </tr>
        </table>
<!--        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
            <h4>
             %# DataBinder.Eval(Container.DataItem, "aciklama") %>
             </h4>
                <object width="350" height="350">
    <param name="movie" value='%#DataBinder.Eval(Container.DataItem, "url") %>'></param>
    <param name="allowFullScreen" value="true"></param>
    <param name="allowscriptaccess" value="always"></param>
    <embed src='%#DataBinder.Eval(Container.DataItem, "url") %>' type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="350" height="350">
    </embed>
    </object>
            </ItemTemplate>
        </asp:Repeater>-->
    </asp:Panel>
</asp:Content>

