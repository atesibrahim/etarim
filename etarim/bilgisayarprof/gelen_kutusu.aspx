<%@ Page Title="" Language="C#" MasterPageFile="~/bilgisayarprof/bilgisayarprof.master" AutoEventWireup="true" CodeFile="gelen_kutusu.aspx.cs" Inherits="bilgisayarprof_gelen_kutusu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
        height: 417px;
    }
    .style2
    {
        width: 448px;
    }
    .style3
    {
        width: 109%;
    }
    .style4
    {
        width: 287px;
    }
    .style5
    {
            height: 81px;
        }
    .style6
    {
        width: 448px;
        height: 81px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style5">
        </td>
        <td class="style6">
            <table class="style3">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Gelen Kutusu Sayfası"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td class="style5">
        </td>
        <td class="style5">
        </td>
        <td class="style5">
        </td>
        <td class="style5">
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style2" valign="top">
            <br />
    <asp:Button ID="Button1" runat="server" Text="Sil" onclick="Button1_Click" 
           style="margin-left: 537px" Width="61px"   />
       <asp:GridView ID="GridView1" runat="server"
       
        SelectedRowStyle-BackColor="Blue"
        BackColor=""
        AutoGenerateColumns="false" 
        AllowPaging="True"
        PageSize="15"
        OnPageIndexChanging="GridView1_PageIndexChanging"      
           style="margin-top: 24px" Width="595px"  >
            <Columns>
<asp:TemplateField HeaderText="Kimden" >
<ItemTemplate>
<asp:Label ID="kimden" runat="server" Text='<%#Eval("kimden")%>' ReadOnly="true" > </asp:Label>
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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </td>
        <td valign="top">
    &nbsp;
            <br />
            <br />
            <br />
            <br />
&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Konu"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <br />
    <asp:Label ID="mesaj" runat="server" Columns="20" 
        MaxLength="1000" style="margin-top: 5px; margin-left: 42px;" 
        Width="312px"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                Text="Cevapla" />
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="Label5" runat="server" Text=" Konu"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="250" Width="308px"></asp:TextBox>
            <br />
            <br />
            &nbsp;<asp:Label ID="Label6" runat="server" Text="Mail"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="218px" MaxLength="990" 
                TextMode="MultiLine" Width="318px" style="margin-left: 39px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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

