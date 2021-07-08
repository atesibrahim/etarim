<%@ Page Title="" Language="C#" MasterPageFile="~/bilgisayarprof/bilgisayarprof.master" AutoEventWireup="true" CodeFile="materyalekle.aspx.cs" Inherits="bilgisayarprof_videoekle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 225px;
        }
        .style2
        {
        width: 196px;
    }
        .style3
        {
            width: 98%;
            height: 38px;
        }
        .style8
        {
            width: 462px;
        }
        .style12
        {
            width: 100%;
        height: 31px;
    }
        .style22
        {
            width: 37px;
        }
    .style23
    {
        width: 196px;
        height: 48px;
    }
    .style24
    {
        width: 462px;
        height: 48px;
    }
    .style25
    {
        height: 48px;
    }
    .style26
    {
        height: 29px;
        width: 135px;
    }
    .style28
    {
        width: 84px;
        height: 25px;
    }
    .style29
    {
        width: 122px;
    }
    .style30
    {
        height: 25px;
    }
    .style31
    {
        width: 312px;
    }
    .style34
    {
        width: 24px;
    }
    .style35
    {
        width: 31px;
    }
    .style36
    {
        height: 29px;
        width: 49px;
    }
    .style37
    {
        width: 196px;
        height: 68px;
    }
    .style38
    {
        width: 462px;
        height: 68px;
    }
    .style39
    {
        height: 68px;
    }
    .style40
    {
        width: 86px;
    }
    .style41
    {
        width: 68px;
    }
    .style42
    {
        width: 196px;
        height: 76px;
    }
    .style43
    {
        width: 462px;
        height: 76px;
    }
    .style44
    {
        height: 76px;
    }
    .style45
    {
        width: 100%;
    }
    .style46
    {
        width: 72px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">    
    <form id="form1">
    <div>
        <table class="style1">
            <tr>
                <td class="style42">
                    <br />
                    <br />
                    <table class="style12">
                        <tr>
                            <td class="style35">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" 
                                    Font-Size="Medium" Text="Video Ekleme"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style43">
                    <table class="style45">
                        <tr>
                            <td class="style46">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    Text="Materyal Ekleme Sayfası"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td class="style44">
                    </td>
                <td class="style44">
                    </td>
            </tr>
            <tr>
                <td class="style23">
                    <table class="style3">
                        <tr>
                            <td class="style36">
                            </td>
                            <td class="style26">
                                <asp:Label ID="Label3" runat="server" Text="Video Açıklaması :"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style24">
                    <asp:TextBox ID="TextBox2" runat="server" Height="22px" 
                        style="margin-left: 2px" Width="442px"></asp:TextBox>
                    <br />
                </td>
                <td class="style25">
                </td>
                <td class="style25">
                </td>
            </tr>
            <tr>
                <td class="style37">
                    <table class="style12">
                        <tr>
                            <td class="style28">
                                </td>
                            <td class="style30">
                                <asp:Label ID="Label2" runat="server" Text="Video Linki :"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                </td>
                <td class="style38">
        <asp:TextBox ID="TextBox1" runat="server" Width="442px" Height="23px" 
                        style="margin-top: 0px"></asp:TextBox>
                    <br />
                    <br />
                    <table class="style12">
                        <tr>
                            <td class="style29">
                                &nbsp;</td>
                            <td class="style31">
        <asp:Button ID="btnAddLink"
            runat="server" Text="Video Ekle" onclick="btnAddLink_Click" 
            Width="108px" Font-Bold="False" Height="28px" style="margin-top: 0px" />    
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style39">
                    </td>
                <td class="style39">
                </td>
            </tr>
            <tr>
                <td class="style2">
                    </td>
                <td class="style8">
                    </td>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    <table class="style12">
                        <tr>
                            <td class="style34">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    Font-Strikeout="False" Text="Dosya Ekleme"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="style12">
                        <tr>
                            <td class="style40">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Dosya Adı :"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table class="style12">
                        <tr>
                            <td class="style41">
                                &nbsp;</td>
                            <td>
                                <br />
                                <asp:Label ID="Label6" runat="server" Text="Dosya Adresi :"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style8">
                    <br />
                    <br />
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" Height="22px" Width="209px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="213px" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style8">
                    <table class="style12">
                        <tr>
                            <td class="style22">
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnDosyaEkle" runat="server" style="margin-left: 4px" 
                                    Text="Dosya Ekle" onclick="btnDosyaEkle_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    </div>
 
    </form>
</asp:Content>

