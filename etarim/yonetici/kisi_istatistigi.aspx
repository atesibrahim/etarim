<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="kisi_istatistigi.aspx.cs" Inherits="yonetici_kisi_istatistigi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var x = document.getElementById('<%=TextBox1.ClientID%>').value;


            //alert(x);
            var xx = parseFloat(x);
            //parseInt("x");
            var y = document.getElementById('<%=TextBox2.ClientID%>').value;
            //arseInt(y);
            // alert(y);
            var yy = parseFloat(y);
            var data = google.visualization.arrayToDataTable([
          ['', 'Aktif', 'Pasif'],
          ['', xx, yy]


        ]);

            var options = {
                title: 'Çiftçi-Toptancı',
                vAxis: { title: 'Çifçi-Toptancı Durum Grafiği', titleTextStyle: { color: 'black'} }
            };

            var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 126px;
        }
        .style3
        {
            width: 127px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="Seciniz">Tüm Kullanıcılar</asp:ListItem>
                    <asp:ListItem Value="0">Çiftçi</asp:ListItem>
                    <asp:ListItem Value="1">Toptancı</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="height: 26px; width: 125px" Text="İstatistik Çıkar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">

                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
     <div id="chart_div" style="width: 700px; height: 300px; ">

                <asp:TextBox ID="TextBox1" runat="server" Width="0px"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" Width="0px"></asp:TextBox>
            </div>
</asp:Content>

