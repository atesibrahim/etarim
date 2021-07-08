<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="yoneticiekleme.aspx.cs" Inherits="yonetici_yoneticiekleme" %>

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
            height: 259px;
        }
        .style2
        {
            width: 187px;
        }
    .style4
    {
        width: 262px;
    }
    .style5
    {
        height: 5px;
    }
        .style6
        {
            width: 189px;
        }
        .style7
        {
            width: 187px;
            height: 29px;
        }
        .style8
        {
            width: 189px;
            height: 29px;
        }
        .style9
        {
            height: 29px;
        }
        .style10
        {
            width: 187px;
            height: 36px;
        }
        .style11
        {
            width: 189px;
            height: 36px;
        }
        .style12
        {
            height: 36px;
        }
        .style13
        {
            width: 187px;
            height: 30px;
        }
        .style14
        {
            width: 189px;
            height: 30px;
        }
        .style15
        {
            height: 30px;
        }
        .style16
        {
            width: 187px;
            height: 31px;
        }
        .style17
        {
            width: 189px;
            height: 31px;
        }
        .style18
        {
            height: 31px;
        }
        .style19
        {
            width: 187px;
            height: 32px;
        }
        .style20
        {
            width: 189px;
            height: 32px;
        }
        .style21
        {
            height: 32px;
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
                            Text="Yönetici Ekleme Sayfası"></asp:Label>
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
            <td class="style7">
                <asp:Label ID="Label1" runat="server" Text="Sicil No(Kod) :"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" 
                    MaxLength="8" Width="150px"></asp:TextBox>
            </td>
            <td class="style9">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="Sadece rakam kullanabilirsiniz." 
                                    ControlToValidate="TextBox1"     
                                    ValidationExpression="^\d*$" /></td>
            <td class="style9">
                </td>
            <td class="style9">
                </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="Label2" runat="server" Text="Adı :"></asp:Label>
            </td>
            <td class="style11">
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="30" Width="149px"></asp:TextBox>
            </td>
            <td class="style12">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBox2"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
            <td class="style12">
                </td>
            <td class="style12">
                </td>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="Label3" runat="server" Text="Soyadı :"></asp:Label>
            </td>
            <td class="style14">
                <asp:TextBox ID="TextBox3" runat="server" MaxLength="30" Width="150px"></asp:TextBox>
            </td>
            <td class="style15">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBox3"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
            <td class="style15">
                </td>
            <td class="style15">
                </td>
            <td class="style15">
                </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label7" runat="server" Text="E Mail Adresi :"></asp:Label>
            </td>
            <td class="style17">
                <asp:TextBox ID="TextBox4" runat="server" MaxLength="50" Width="148px"></asp:TextBox>
            </td>
            <td class="style18">
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBox4" ErrorMessage="**Geçersiz E-mail Formatı">
                                    </asp:RegularExpressionValidator>&nbsp;
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
            <td class="style18">
                </td>
            <td class="style18">
                </td>
            <td class="style18">
                </td>
        </tr>
        <tr>
            <td class="style19">
                <asp:Label ID="Label8" runat="server" Text="Şifre :"></asp:Label>
            </td>
            <td class="style20">
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" MaxLength="15" 
                    Width="146px"></asp:TextBox>
            </td>
             <td class="style21">
                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="TextBox6" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                            
                                <br />
                            
                            <asp:RegularExpressionValidator ID="MyTextBoxValidator" runat="server" 
                            ControlToValidate="TextBox6"
                             ErrorMessage="Minimum uzunluk 6 karakter olmalıdır"
                                ValidationExpression=".{6}.*" /></td>
            <td class="style21">
                </td>
            <td class="style21">
                </td>
            <td class="style21">
                </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label9" runat="server" Text="Şifre Tekrar :"></asp:Label>
            </td>
            <td class="style17">
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Password" MaxLength="15" Width="146px"></asp:TextBox>
            </td>
            <td class="style18">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBox7" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator runat="server" ID="mValidator" ControlToValidate="TextBox7" 
                            ErrorMessage="Şifreler Uyuşmuyor!" ControlToCompare="TextBox6"/></td>
            <td class="style18">
                </td>
            <td class="style18">
                </td>
            <td class="style18">
                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
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
            <td class="style6">
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
            <td class="style6">
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
            <td class="style6">
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
            <td class="style6">
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
            <td class="style6">
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

