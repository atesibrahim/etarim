<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="urun_ekleme.aspx.cs" Inherits="ciftci_urun_eklem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 74%;
        }
    .style2
    {
        width: 389px;
    }
        .style5
        {
            height: 30px;
        }
        .style7
        {
            height: 37px;
        }
        .style9
        {
            height: 36px;
        }
        .style11
        {
            height: 42px;
        }
        .style12
        {
            width: 177%;
        }
        .style13
        {
            width: 189px;
        }
        .style15
        {
            height: 23px;
        }
        .style16
        {
            height: 23px;
            width: 81px;
        }
        .style17
        {
            height: 36px;
            width: 81px;
        }
        .style18
        {
            height: 37px;
            width: 81px;
        }
        .style19
        {
            height: 42px;
            width: 81px;
        }
        .style20
        {
            width: 81px;
        }
        .style21
        {
            width: 45px;
        }
        .style22
        {
            height: 23px;
            width: 45px;
        }
        .style23
        {
            height: 36px;
            width: 45px;
        }
        .style24
        {
            height: 37px;
            width: 45px;
        }
        .style25
        {
            height: 42px;
            width: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <table class="style1">
            <tr>
                <td class="style21">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    <table class="style12">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style13">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    Text="Ürün Ekleme Sayfası"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style22">
                    &nbsp;</td>
                <td class="style16">
                </td>
                <td class="style15">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="style23">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Ürün Türü :" 
                        Height="22px" Width="94px" Font-Bold="True" style="margin-left: 0px"></asp:Label>
                </td>
                <td class="style9">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="22px" 
                        Width="101px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="DropDownList1" ErrorMessage="Lütfen seçiniz." ForeColor="Red" 
                        InitialValue="Seçiniz"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style18">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Ürün Adı :" 
                        Height="22px" Width="87px" Font-Bold="True" style="margin-left: 0px"></asp:Label>
                </td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" 
                        Height="22px" style="margin-left: 0px" Width="100px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="DropDownList2" ErrorMessage="Lütfen seçiniz." ForeColor="Red" 
                        InitialValue="Seçiniz"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp;</td>
                <td class="style19">
                    <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Miktarı( Kg) :" 
                        Width="110px" Height="22px" Font-Bold="True" style="margin-left: 0px"></asp:Label>

                </td>
                <td class="style11">
                    
                    <asp:TextBox ID="TextBox3" runat="server" MaxLength="8" 
                        style="margin-bottom: 0px" Width="100px" Height="21px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                        ControlToValidate="TextBox3" ErrorMessage="**Gerçersiz Miktar Girdiniz" 
                        ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                &nbsp;</td>
            </tr>
            <tr>
                <td class="style21">
                    &nbsp;</td>
                <td class="style20">
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" 
                        Text="Fiyatı(Kg/TL ) :" Height="22px" Width="127px" Font-Bold="True" 
                        style="margin-left: 0px"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="8" Width="100px" 
                        Height="22px"></asp:TextBox>
                       

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ValidationExpression="(^(\+|\-)(0|([1-9][0-9]*))(\.[0-9]{1,4})?$)|(^(0{0,1}|([1-9][0-9]*))(\.[0-9]{1,4})?$)" 
                                    ControlToValidate="TextBox2" ErrorMessage="**Geçersiz Fiyat. Formatı şöyle olmalıdır: 000.00">
                                    </asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="style21">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="Button1" runat="server"   style="margin-left: 3px" 
                        Text="Ekle" Width="91px" onclick="Button1_Click1" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
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

