<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="profilim.aspx.cs" Inherits="ciftci_profilim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style8
        {
            width: 38px;
            height: 25px;
        }
        .style26
        {
            width: 99px;
            height: 33px;
        }
        .style27
        {
            width: 189px;
            height: 33px;
        }
        .style31
        {
            width: 198px;
            height: 33px;
        }
        .style19
        {
            width: 285px;
            height: 33px;
        }
        .style24
        {
            width: 99px;
            height: 65px;
        }
        .style25
        {
            width: 189px;
            height: 65px;
        }
        .style29
        {
            height: 65px;
            width: 198px;
        }
        .style3
        {
            height: 65px;
        }
        .style10
        {
            width: 99px;
        }
        .style6
        {
            width: 189px;
        }
        .style32
        {
            width: 198px;
            height: 90px;
        }
        .style17
        {
            width: 285px;
            height: 90px;
        }
        .style21
        {
            width: 99px;
            height: 76px;
        }
        .style22
        {
            width: 189px;
            height: 76px;
        }
        .style30
        {
            width: 198px;
            height: 76px;
        }
        .style4
        {
            width: 325px;
            height: 76px;
        }
        .style33
        {
            width: 263px;
        }
        .style34
        {
            width: 46px;
        }
        .style35
        {
            width: 99px;
            height: 25px;
        }
        .style36
        {
            width: 189px;
            height: 25px;
        }
        .style37
        {
            width: 198px;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style34">
                &nbsp;</td>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style33">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" 
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
            <td class="style34">
                &nbsp;</td>
            <td>
    <table align="center" class="style1">
        <tr>
            <td class="style35">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Ad :"></asp:Label>
            </td>
            <td class="style36">
                <asp:Label ID="LabelAd" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style37" id="labelAd0">
                <asp:TextBox ID="TextBoxAd" runat="server" EnableTheming="True" 
                    Visible="False" Width="120px"></asp:TextBox>
            </td>
            <td class="style8">
            <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBoxAd"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Soyad :"></asp:Label>
            </td>
            <td class="style27">
                <asp:Label ID="LabelSoyad" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style31" id="labelSoyad0">
                <asp:TextBox ID="TextBoxSoyad" runat="server" Visible="False" 
                    Width="120px"></asp:TextBox>
            </td>
            <td class="style19">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBoxSoyad"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
        </tr>
        <tr>
            <td class="style24">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="E Mail :"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Cep Tel :"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="Ev Tel :"></asp:Label>
                <br />
            </td>
            <td class="style25">
                <asp:Label ID="LabelMail" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="LabelCepTel" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="LabelEvTel" runat="server" Text="Label"></asp:Label>
                <br />
            </td>
            <td class="style29" id="labelMail0">
                <br />
                <asp:TextBox ID="TextBoxEmail" runat="server" Visible="False" 
                    Width="120px" style="margin-left: 1px"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBoxCepTel" runat="server" Visible="False"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBoxEvTel" runat="server" Visible="False"></asp:TextBox>
                <br />
                <br />
            </td>
            <td class="style3">
                
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBoxEmail" ErrorMessage="**Geçersiz E-mail Formatı">
                                    </asp:RegularExpressionValidator><br />
                <br />
                <asp:RegularExpressionValidator ID="reg_Phone" runat="server" ControlToValidate="TextBoxCepTel"
                    ErrorMessage="Lütfen geçerli bir telefon numarası giriniz. Örnek: 0212 111 1111"
                    ValidationGroup="RegisterValidation"
                    ValidationExpression="(\\d{4}\\d{3}\d{4})|(\d{11})">

                </asp:RegularExpressionValidator> 
                <br />
                <br />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEvTel"
                    ErrorMessage="Lütfen geçerli bir telefon numarası giriniz. Örnek: 0212 111 1111"
                    ValidationGroup="RegisterValidation"
                    ValidationExpression="(\\d{4}\\d{3}\d{4})|(\d{11})">

                </asp:RegularExpressionValidator> <br />
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Adres :"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="Adres İl :"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Adres İlçe :"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Height="83px" 
                    style="margin-left: 0px" TextMode="MultiLine" Width="121px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelAdresIl" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="LabelAdresIlce" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style32" id="labelSifre">
                <asp:TextBox ID="TextBoxAdres" runat="server" Height="78px" 
                    style="margin-top: 0px" TextMode="MultiLine" Visible="False" Width="150px"></asp:TextBox>
                <br />
                <br />
                <asp:DropDownList ID="DropDownListAdresIl" runat="server" AutoPostBack="True" 
                    Height="22px" Visible="False" Width="111px" 
                    onselectedindexchanged="DropDownListAdresIl_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:DropDownList ID="DropDownListIlce" runat="server" AutoPostBack="True" 
                    Height="22px" Visible="False" Width="113px">
                </asp:DropDownList>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style21">
                </td>
            <td class="style22">
                <asp:Button ID="Button1" runat="server" Height="25px" Text="Düzenle" 
                    onclick="Button1_Click" />
            </td>
            <td class="style30">
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Kaydet" 
                    Width="76px" Visible="False" />
            </td>
            <td class="style4">
                </td>
        </tr>
    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style34">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

