<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="videolar.aspx.cs" Inherits="videolar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">



    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 70px;
        }
    .style3
    {
        width: 275px;
    }
    </style>



</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-9" />
        <td align="left" valign="top">
            <table border="0" cellspacing="0" cellpadding="0" 
            style="width: 82%; height: 11px;">
          <tr>
            <td align="left" valign="top" class="style3">&nbsp;</td>
            <td align="left" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Sistem Hakkında Videolar" 
                    Font-Bold="True" Font-Size="Medium"></asp:Label>
              </td>
            <td align="left" valign="top">&nbsp;</td>
          </tr>
        </table></td>
 
  <tr>
    <td align="left" valign="top" style="padding-top:23px;">
        <table class="style1">
            <tr>
                <td class="style2">
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
                    




<form id="form1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" >
    <ItemTemplate>
    <object width="300" height="320"><param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "url") %>'></param>
    <param name="allowFullScreen" value="true"></param>
    <param name="allowscriptaccess" value="always"></param>
    <embed src='<%#DataBinder.Eval(Container.DataItem, "url") %>' type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="300" height="320">
    </embed>
    </object>
    &nbsp;&nbsp;&nbsp;&nbsp;
    </ItemTemplate>    
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [url], [aciklama], [id] FROM [videolar] ORDER BY id DESC">
    </asp:SqlDataSource>
    </form></td>
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
            </tr>
        </table>
        <br />
      </td>
  </tr>
    </asp:Content>

