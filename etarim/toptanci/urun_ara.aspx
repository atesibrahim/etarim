<%@ Page Title="" Language="C#" MasterPageFile="~/toptanci/toptanci.master" AutoEventWireup="true" CodeFile="urun_ara.aspx.cs" Inherits="toptanci_urun_ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 98%;
        }
        .style3
        {
            height: 60px;
        }
        .style24
        {
        }
        .style36
        {
            height: 60px;
            width: 252px;
        }
        .style37
        {
            width: 252px;
        }
        .style21
        {
            width: 124px;
            height: 30px;
        }
        .style28
        {
            width: 76px;
            height: 30px;
        }
        .style30
        {
            width: 44px;
            height: 30px;
        }
        .style18
        {
            width: 124px;
            height: 36px;
        }
        .style29
        {
            width: 76px;
            height: 36px;
        }
        .style31
        {
            width: 44px;
            height: 36px;
        }
        .style40
        {
            width: 357px;
        }
        .style41
        {
            height: 60px;
            width: 357px;
        }
        .style42
        {
            height: 60px;
            width: 5px;
        }
        .style43
        {
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style24" colspan="2" align="center">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text=" Ürün Arama Sayfası"></asp:Label>
            </td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td class="style36">
                <table style="width: 592px; height: 55px; margin-left: 34px;">
   <tr>
   <td class="style21">Ürün Türü </td>
   <td class="style21">Ürün Adı </td>
   <td class="style28">Bölgesi </td>
    <td class="style30"> </td>
   </tr>
   <tr>
   <td class="style18">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
           Height="21px" 
           Width="110px" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    </td>
   <td class="style18"> 
    <asp:DropDownList ID="DropDownList2" runat="server"  
           Height="24px" Width="107px">
    </asp:DropDownList>
    </td>
    <td class="style29">
    <asp:DropDownList ID="DropDownList3" runat="server"  
            Height="23px" Width="109px" 
           >
    </asp:DropDownList>
    </td>
    <td class="style31">
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ara" 
            Height="22px" Width="76px" />
    
    </td>
    </tr>
      </table>

                </td>
            <td class="style41">
                </td>
            <td class="style3">
                </td>
            <td class="style3">
                </td>
        </tr>
        <tr>
            <td class="style43" align="center" valign="top">

                &nbsp;</td>
            <td class="style37" valign="top" align="center" >
                <asp:GridView ID="GridView1" runat="server" 
              style="margin-left: 0px; margin-top: 5px; margin-right: 14px;" AutoGenerateColumns="false" 
              Width="648px" 
              AllowPaging="True"
        PageSize="15"
        OnPageIndexChanging="GridView1_PageIndexChanging" 
              >

        <Columns>

<asp:TemplateField HeaderText="Ürün Tür Adı">
<ItemTemplate>
<asp:Label ID="tur_ad" runat="server" Text='<%#Eval("tur_ad")%>' ReadOnly="true" Height="18"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ürün Adı">
<ItemTemplate>
<asp:Label ID="ad" runat="server" Text='<%#Eval("isim")%>' ReadOnly="true" Height="18"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Miktarı">
<ItemTemplate>
<asp:Label ID="miktar" runat="server" Text='<%#Eval ("miktar") %>' ReadOnly="true" Height="18"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fiyatı">
<ItemTemplate>
<asp:Label ID="fiyat" runat="server" Text='<%#Eval ("fiyat") %>' ReadOnly="true" Height="18"></asp:Label>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Bölge">
<ItemTemplate>
<asp:Label ID="il_ad" runat="server" Text='<%#Eval ("il")%>' ReadOnly="true" Height="18"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Toptancı" Visible="false">
<ItemTemplate>
<asp:Label ID="ciftci" runat="server" Text='<%#Eval ("ciftci")%>' ReadOnly="true" Height="18"> </asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Seç">
<ItemTemplate>
<asp:ImageButton ID="sec" runat="server"       ImageUrl="~/image/more.ico"   OnClick="sec" Height="18" Width="22"> </asp:ImageButton>
</ItemTemplate>
</asp:TemplateField>


</Columns>
       </asp:GridView>
       
                <br />
                <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                    style="margin-left: 147px" 
                    Text="Aradığınız Kriterlere Uygun Ürün Bulunmamaktadır!" Width="359px"></asp:Label>
       
            </td>
            <td class="style40" valign="top">
                <br />
&nbsp;
           <asp:Label ID="Label6" runat="server" Font-Bold="True" ></asp:Label> <br />
           &nbsp;
           <asp:Label ID="Label1" runat="server" ></asp:Label> 
           <br />
           &nbsp;
           <asp:Label ID="Label2" runat="server" ></asp:Label>
           <br />
           &nbsp;
           <asp:Label ID="Label3" runat="server" ></asp:Label>
           <br />
           &nbsp;
           <asp:Label ID="Label4" runat="server" ></asp:Label>
                <br />
&nbsp;
                <asp:Label ID="Label8" runat="server"></asp:Label>
           <br />
           &nbsp;
           <asp:Label ID="Label5" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Mail Gönder" 
                    Width="109px" />
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    Text="Çiftçilerime Ekle" Width="123px" style="margin-left: 61px" />
                <br />
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Konu:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="250" Width="310px"></asp:TextBox>
                <br />
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Mail:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" Height="202px" MaxLength="990" 
                    TextMode="MultiLine" Width="310px"></asp:TextBox>
                <br />
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Gönder" 
                    Height="26px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style43">
                &nbsp;</td>
            <td class="style37">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style43">
                &nbsp;</td>
            <td class="style37">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style43">
                &nbsp;</td>
            <td class="style37">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

