﻿<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="toptancilar.aspx.cs" Inherits="yonetici_toptancilar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <head id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Admin Paneli</title>
<link href="./styles/toptancilar.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 146px;
        }
        .style2
        {
            width: 2px;
        }
        .style3
        {
            width: 11px;
        }
        .style4
        {
            width: 683px;
        }
        .style6
        {
            width: 25px;
        }
        .style7
        {
            width: 5px;
        }
    .style8
    {
        width: 100%;
    }
    .style9
    {
        width: 263px;
    }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                <table class="style8">
                    <tr>
                        <td class="style9">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Toptancılar Sayfası"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style2">
            </td>
            <td class="style4">
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
            <td class="style7">
            </td>
            <td class="style6">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style2">
            </td>
            <td class="style4">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="margin-left: 639px; margin-bottom: 0px;" Text="Sil" Width="41px" />
    <asp:GridView ID="GridView1" 
    runat="server" AutoGenerateColumns="False"
     AutoGenerateDeleteButton="False"  OnRowDeleting="GridView1_RowDeleting" Width="678px"
     Height="157px" 
    >
    <Columns>
<asp:TemplateField HeaderText="kod" Visible="false">
<ItemTemplate>
<asp:Label ID="kod" runat="server" Text='<%#Eval("kod")%>' ReadOnly="true" Height="20"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="İsim">
<ItemTemplate>
<asp:Label ID="ad" runat="server" Text='<%#Eval("ad")%>' ReadOnly="true" Height="20"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Soyisim">
<ItemTemplate>
<asp:Label ID="soyad" runat="server" Text='<%#Eval ("soyad") %>' ReadOnly="true" Height="20"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="E-mail">
<ItemTemplate>
<asp:Label ID="email" runat="server" Text='<%#Eval ("email") %>' ReadOnly="true" Height="20"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="İş Tel">
<ItemTemplate>
<asp:Label ID="is_tel" runat="server" Text='<%#Eval ("is_tel")%>' ReadOnly="true" Height="20"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Cep Tel">
<ItemTemplate>
<asp:Label ID="cep_tel" runat="server" Text='<%#Eval ("cep_tel")%>' ReadOnly="true"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Adres İl">
<ItemTemplate>
<asp:Label ID="adres" runat="server" Text='<%#Eval ("adres")%>' ReadOnly="true" Height="20"> </asp:Label>
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
            <td class="style7">
            </td>
            <td class="style6">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <body>

</body>
</asp:Content>

