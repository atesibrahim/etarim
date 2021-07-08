<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="kayit.aspx.cs" Inherits="kayit2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 7px;
        }
        .style4
        {
            width: 72%;
            margin-left: 161px;
            margin-top: 43px;
            height: 500px;
        }
        .style5
        {
            height: 22px;
            width: 377px;
        }
        .style6
        {
            height: 22px;
            width: 185px;
        }
        .style8
        {
            width: 377px;
        }
    #logincontainer
    {
        height: 779px;
    }
        .style9
        {
            width: 165%;
            height: 60px;
        }
        .style10
        {
            width: 151px;
        }
        .style11
        {
            width: 165%;
        }
        .style12
        {
            width: 150px;
        }
    .style13
    {
        width: 115%;
    }
    .style16
    {
        width: 157px;
    }
    .style17
    {
        width: 194px;
    }
    .style18
    {
        width: 41px;
    }
        .style19
        {
            width: 154px;
        }
        .style20
        {
            width: 155px;
        }
        .style21
        {
            width: 151px;
            height: 31px;
        }
        .style22
        {
            height: 31px;
        }
        .style23
        {
            width: 142px;
        }
        .style24
        {
            width: 148px;
        }
        .style25
        {
            width: 185px;
            height: 67px;
        }
        .style26
        {
            width: 377px;
            height: 67px;
        }
        .style27
        {
            width: 185px;
        }
    </style>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <tr>
    <td>

    <div id="logincontainer">
    	<h1 style="margin-left: 3px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E-Tarım Kayıt Paneli</h1>
        <div id="loginbox">
           <table class="style4">
            <form runat="server">
                <tr>
                    <td class="style6">
                <asp:RadioButton ID="ciftci" runat="server" Text="Çiftçi Kayıt" 
                    GroupName="meslek" />
                    </td>
                    <td class="style5">
                <asp:RadioButton ID="toptanci" runat="server" Text="Toptancı Kayıt" 
                    GroupName="meslek" />
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        <br />
                        Bakanlık tarafından verilen Çiftçi veya Toptancı numarasını giriniz</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style24">
                        <asp:TextBox ID="TextBox1" runat="server" Width="150px" MaxLength="10" 
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td>
                                    
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="Sadece rakam kullanabilirsiniz." 
                                    ControlToValidate="TextBox1"     
                                    ValidationExpression="^\d*$" />&nbsp;<br />
                                    
<asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox1" 
                           ID="cv1" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        Adınız</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style23">
                        <asp:TextBox ID="TextBox2" runat="server" Width="150px" MaxLength="30" 
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox2" ID="cv2" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                            <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBox2"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" />&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        Soyadınız</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style12">
                        <asp:TextBox ID="TextBox3" runat="server" Width="150px" MaxLength="30" 
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox3" ID="cv3" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;<br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="Sadece harf kullanabilirsiniz." 
                                    ControlToValidate="TextBox3"     
                                    ValidationExpression="^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$" /></td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        E-Mail Adresi</td>
                    <td class="style8">
                        <table class="style11">
                            <tr>
                                <td class="style12">
                        <asp:TextBox ID="TextBox4" runat="server" Width="150px" MaxLength="50" 
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ControlToValidate="TextBox4" ErrorMessage="**Geçersiz E-mail Formatı;" ForeColor="Red">
                                    </asp:RegularExpressionValidator>
                                    &nbsp;
                                    <br />
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox4" ID="cv4" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        Cep Telefon No</td>
                    <td class="style26">
                        <table class="style9">
                            <tr>
                                <td class="style21">
                        <asp:TextBox ID="TextBox5" runat="server" Width="150px" MaxLength="16" Height="22px" 
                                        AutoCompleteType="Disabled"></asp:TextBox>
                        
                                </td>
                                <td class="style22">
                        
                    <asp:RegularExpressionValidator ID="reg_Phone" runat="server" ControlToValidate="TextBox5"
                    ErrorMessage="Lütfen geçerli bir telefon numarası giriniz. Örnek: 05551111111"
                    ValidationExpression="^(05)[0-9][0-9][1-9]([0-9]){6}$" ForeColor="Red">

                </asp:RegularExpressionValidator>
                                    <br />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox5" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator></td>
                                <td class="style22">
                                    </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        Ev Telefon No</td>
                    <td class="style8">
                        <table class="style11">
                            <tr>
                                <td class="style16">
                        <asp:TextBox ID="TextBox6" runat="server" Width="150px" MaxLength="14" Height="25px" 
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td>
                        
                    <asp:RegularExpressionValidator ID="reg_Phone0" runat="server" ControlToValidate="TextBox6"
                    ErrorMessage="**Lütfen geçerli bir telefon numarası giriniz. Örnek: 02121111111"
                    ValidationExpression="(\\d{4}\\d{3}\d{4})|(\d{11})" ForeColor="Red">

                </asp:RegularExpressionValidator> 
                                    <br />
                                <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox6" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red" 
                                        ID="RequiredFieldValidator1"></asp:RequiredFieldValidator></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        Adres</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style16">
                        <asp:TextBox ID="TextBox7" runat="server" Height="91px" Width="150px" 
                            MaxLength="200" TextMode="MultiLine" AutoCompleteType="Disabled" 
                                        ClientIDMode="Inherit"></asp:TextBox>
                                </td>
                                <td class="style17">
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox7" ID="cv7" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;</td>
                                <td class="style18">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        Adres İli</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style19">
                        <asp:DropDownList ID="DropDownList1" runat="server"
                            Height="22px" onselectedindexchanged="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="True" 
                            Width="150px">
                        </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="DropDownList1" ID="cv18" 
                                        ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red" 
                                        InitialValue="Seçiniz"></asp:RequiredFieldValidator>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        Adres İlçesi</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style20">
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                            Width="150px" Height="22px" >
                        </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="DropDownList2" ID="cv9" ErrorMessage="* Alanları boş bırakmayınız." 
                                        ForeColor="Red" InitialValue="Seçiniz"></asp:RequiredFieldValidator>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        &#350;ifre</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style10">
                        <asp:TextBox ID="TextBox8" runat="server" Width="150px" TextMode="Password" 
                            MaxLength="15" Height="22px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox8" ID="cv10" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                            <asp:RegularExpressionValidator ID="MyTextBoxValidator" runat="server" 
                            ControlToValidate="TextBox8"
                             ErrorMessage="Minimum uzunluk 6 karakter olmalıdır"
                                ValidationExpression=".{6}.*" />&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        &#350;ifre Tekrar</td>
                    <td class="style8">
                        <table class="style13">
                            <tr>
                                <td class="style12">
                        <asp:TextBox ID="TextBox9" runat="server" Width="150px" TextMode="Password" 
                            MaxLength="15" Height="22px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" 
                            ControlToValidate="TextBox9" ID="cv11" ErrorMessage="* Alanları boş bırakmayınız." ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                            <asp:CompareValidator runat="server" ID="mValidator" ControlToValidate="TextBox9" 
                            ErrorMessage="Şifreler Uyuşmuyor!" ControlToCompare="TextBox8"/>&nbsp;
                            </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        &nbsp;</td>
                    <td class="style8">
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Kay&#305;t ol" 
                            Width="125px" Font-Bold="True" Height="30px" />
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style27">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                </tr>
                </form>
            </table>
            &nbsp;<br />
            <table class="style3">
            </table>
        </div>
    </div>
    </td>
</tr>
</asp:Content>

