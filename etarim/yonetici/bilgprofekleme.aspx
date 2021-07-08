<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="bilgprofekleme.aspx.cs" Inherits="yonetici_bilgprofekleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style3
    {
        width: 100%;
    }
        .style1
        {
            width: 96%;
            margin-left: 35px;
            margin-top: 43px;
        }
        .style2
        {
            width: 187px;
        }
    .style4
    {
        width: 202px;
    }
    .style5
    {
        height: 5px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style3">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <table class="style3">
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text="Bilgisayar Profesyoneli Ekleme Sayfası"></asp:Label>
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
        <td class="style5">
        </td>
        <td class="style5">
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
        <td>
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Sicil No(Kod) :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" 
                    MaxLength="8"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="Sadece rakam kullanabilirsiniz." 
                                    ControlToValidate="TextBox1"     
                                    ValidationExpression="^\d*$" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Adı :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="30"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;
                            <br />
                            <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBox2"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Soyadı :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" MaxLength="30"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBox3"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="E Mail Adresi :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBox4" ErrorMessage="**Geçersiz E-mail Formatı">
                                    </asp:RegularExpressionValidator>&nbsp;
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label10" runat="server" Text="Cep Tel :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </td>
             <td>
                        
                    <asp:RegularExpressionValidator ID="reg_Phone" runat="server" ControlToValidate="TextBox8"
                    ErrorMessage="Lütfen geçerli bir telefon numarası giriniz. Örnek: 0212 111 1111"
                    ValidationGroup="RegisterValidation"
                    ValidationExpression="(\\d{4}\\d{3}\d{4})|(\d{11})">

                </asp:RegularExpressionValidator> 
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="TextBox8" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Adres  :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Height="72px" TextMode="MultiLine" 
                    MaxLength="200"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBox5" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Adres İl :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="128px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                 <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="DropDownList1" ID="cv18" 
                                        ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red" 
                                        InitialValue="Seçiniz"></asp:RequiredFieldValidator>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="Adres İlçe :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"  Height="22px" Width="124px">
                </asp:DropDownList>
            </td>
            <td>
                 <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="DropDownList2" ID="RequiredFieldValidator9" 
                                        ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red" 
                                        InitialValue="Seçiniz"></asp:RequiredFieldValidator>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label8" runat="server" Text="Şifre :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" MaxLength="15"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="TextBox6" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;
                            <br />
                            <asp:RegularExpressionValidator ID="MyTextBoxValidator" runat="server" 
                            ControlToValidate="TextBox6"
                             ErrorMessage="Minimum uzunluk 6 karakter olmalıdır"
                                ValidationExpression=".{6}.*" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label9" runat="server" Text="Şifre Tekrar :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Password" MaxLength="15"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="TextBox7" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;
                            <br />
                            <asp:CompareValidator runat="server" ID="mValidator" ControlToValidate="TextBox7" 
                            ErrorMessage="Şifreler Uyuşmuyor!" ControlToCompare="TextBox6"/></td>
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
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Kaydet" 
                    Width="76px" />
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
        <td>
            &nbsp;</td>
    </tr>
    <tr>
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
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

