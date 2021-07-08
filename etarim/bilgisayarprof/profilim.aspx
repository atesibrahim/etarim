<%@ Page Title="" Language="C#" MasterPageFile="~/bilgisayarprof/bilgisayarprof.master" AutoEventWireup="true" CodeFile="profilim.aspx.cs" Inherits="bilgisayarprof_profilim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        #TextArea1
        {
            width: 118px;
            height: 76px;
        }
        .style26
    {
        width: 100%;
        height: 46px;
    }
    .style1
        {
            width: 88%;
            height: 390px;
        }
        .style22
        {
            width: 192px;
            height: 26px;
        }
        .style18
        {
            width: 246px;
            height: 26px;
        }
        .style8
        {
            width: 162px;
            height: 26px;
        }
        .style9
        {
            width: 366px;
            height: 26px;
        }
        .style23
        {
            width: 192px;
            height: 31px;
        }
        .style19
        {
            width: 246px;
            height: 31px;
        }
        .style12
        {
            width: 162px;
            height: 31px;
        }
        .style13
        {
            width: 366px;
            height: 31px;
        }
        .style24
        {
            width: 192px;
            height: 45px;
        }
        .style20
        {
            width: 246px;
            height: 45px;
        }
        .style16
        {
            width: 162px;
            height: 45px;
        }
        .style17
        {
            width: 366px;
            height: 45px;
        }
        .style25
        {
            width: 192px;
        }
        .style21
        {
            width: 246px;
        }
        .style4
        {
            width: 162px;
        }
        .style5
        {
            width: 366px;
        }
        .style27
    {
            width: 75px;
        }
    .style28
    {
        width: 805px;
    }
    .style29
    {
        width: 251px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style26">
    <tr>
        <td class="style27">
            &nbsp;</td>
        <td class="style28">
            <table class="style26">
                <tr>
                    <td class="style29">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Profil Görüntüleme-Düzenleme Sayfası"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style27">
            &nbsp;</td>
        <td class="style28">
    <table align="center" class="style1">
        <tr>
            <td class="style22">
                <asp:Label ID="Label1" runat="server" Text="Ad :"></asp:Label>
            </td>
            <td class="style18">
                <asp:Label ID="LabelAd" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style8" id="labelAd0">
                <asp:TextBox ID="TextBoxAd" runat="server" EnableTheming="True" 
                    Visible="False" Width="120px"></asp:TextBox>
            </td>
            <td class="style9">
            <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBoxAd"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
        </tr>
        <tr>
            <td class="style23">
                <asp:Label ID="Label2" runat="server" Text="Soyad :"></asp:Label>
            </td>
            <td class="style19">
                <asp:Label ID="LabelSoyad" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style12" id="labelSoyad0">
                <asp:TextBox ID="TextBoxSoyad" runat="server" Visible="False" 
                    Width="120px"></asp:TextBox>
            </td>
            <td class="style13">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBoxSoyad"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
        </tr>
        <tr>
            <td class="style24">
                <asp:Label ID="Label3" runat="server" Text="E Mail :"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Cep Tel :"></asp:Label>
                <br />
            </td>
            <td class="style20">
                <asp:Label ID="LabelMail" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="LabelCepTel" runat="server" Text="Label"></asp:Label>
                <br />
            </td>
            <td class="style16" id="labelMail0">
                <asp:TextBox ID="TextBoxEmail" runat="server" Visible="False" 
                    Width="120px" style="margin-left: 1px"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBoxCepTel" runat="server" Visible="False"></asp:TextBox>
                <br />
            </td>
            <td class="style17">
                
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBoxEmail" ErrorMessage="**Geçersiz E-mail Formatı"> </asp:RegularExpressionValidator><br />
                <br />
                        
                    <asp:RegularExpressionValidator ID="reg_Phone" runat="server" ControlToValidate="TextBoxCepTel"
                    ErrorMessage="Lütfen geçerli bir telefon numarası giriniz. Örnek: 0212 111 1111"
                    ValidationGroup="RegisterValidation"
                    ValidationExpression="(\\d{4}\\d{3}\d{4})|(\d{11})"> </asp:RegularExpressionValidator> 
                                
            </td>
        </tr>
        <tr>
            <td class="style24">
                <asp:Label ID="Label5" runat="server" Text="Adres :"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Adres İl :"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Adres İlçe :"></asp:Label>
            </td>
            <td class="style20">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Height="83px" 
                    style="margin-left: 0px" TextMode="MultiLine" Width="121px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelAdresIl" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="LabelAdresIlce" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style16" id="labelSifre">
                <asp:TextBox ID="TextBoxAdres" runat="server" Height="78px" 
                    style="margin-top: 0px" TextMode="MultiLine" Visible="False" Width="150px"></asp:TextBox>
                <br />
                <br />
                <asp:DropDownList ID="DropDownListAdresIl" runat="server" AutoPostBack="True" 
                    Height="21px" Visible="False" Width="111px" 
                    onselectedindexchanged="DropDownListAdresIl_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:DropDownList ID="DropDownListIlce" runat="server" AutoPostBack="True" 
                    Height="17px" Visible="False" Width="113px">
                </asp:DropDownList>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style25">
                &nbsp;</td>
            <td class="style21">
                <asp:Button ID="Button1" runat="server" Height="25px" Text="Düzenle" 
                    onclick="Button1_Click" />
            </td>
            <td class="style4">
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Kaydet" 
                    Width="76px" Visible="False" />
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
    </table>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style27">
            &nbsp;</td>
        <td class="style28">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

