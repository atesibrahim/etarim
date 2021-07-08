﻿<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="ciftciler.aspx.cs" Inherits="yonetici_ciftciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <head id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Admin Paneli</title>
<link href="./styles/login.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 13px;
        }
        .style3
        {
            width: 759px;
        }
    .style4
    {
        width: 310px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <table class="style1">
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Çiftçiler Sayfası"></asp:Label>
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
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="Label12" runat="server"></asp:Label>
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
            <td class="style2">
                &nbsp;</td>
            <td class="style3" align="center">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" 
                    Text="Sistemde Ekli Çiftçi Bulunmamaktadır!"></asp:Label>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="margin-left: 723px" Text="Sil" Width="38px" />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    AutoGenerateDeleteButton="False"  OnRowDeleting="GridView1_RowDeleting" Width="764px"
     Height="181px" 
    >
    <Columns>
<asp:TemplateField HeaderText="kod" Visible="false">
<ItemTemplate>
<asp:Label ID="kod" runat="server" Text='<%#Eval("kod")%>' ReadOnly="true"> </asp:Label>
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
<asp:Label ID="email" runat="server" Text='<%#Eval ("email") %>' ReadOnly="true"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ev Tel">
<ItemTemplate>
<asp:Label ID="ev_tel" runat="server" Text='<%#Eval ("ev_tel")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Cep Tel">
<ItemTemplate>
<asp:Label ID="is_tel" runat="server" Text='<%#Eval ("cep_tel")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Adres İl">
<ItemTemplate>
<asp:Label ID="adres" runat="server" Text='<%#Eval ("adres")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Ak./Pas.">
<ItemTemplate>
<asp:ImageButton ID="ap" runat="server"  AlternateText='<%#Eval ("ap")%>'   ImageUrl=""  OnClick="ap"  Height="20" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sil">
<ItemTemplate>
<asp:CheckBox ID="CheckBox" runat="server"  />
</ItemTemplate>
</asp:TemplateField>
        
        
</Columns>
    </asp:GridView>
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
            <td class="style2">
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
            <td class="style2">
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
            <td class="style2">
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


