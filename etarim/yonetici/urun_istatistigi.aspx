<%@ Page Title="" Language="C#" MasterPageFile="~/yonetici/yonetici.master" AutoEventWireup="true" CodeFile="urun_istatistigi.aspx.cs" Inherits="yonetici_urun_istatistigi" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var x = document.getElementById('<%=TextBox1.ClientID%>').value;


            //alert(x);
           var xx= parseFloat(x);
            //parseInt("x");
            var y = document.getElementById('<%=TextBox2.ClientID%>').value;
           //arseInt(y);
           // alert(y);
            var yy = parseFloat(y);
            var data = google.visualization.arrayToDataTable([
          ['', 'Arz(kg)', 'Talep(kg)'],
          ['', xx, yy]


        ]);

            var options = {
                title: 'Çiftçi-Toptancı Arz/Talep Tablosu',
                vAxis: { title: 'Arz/Talep Miktarı', titleTextStyle: { color: 'black'} }
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
            width: 132px;
        }
        .style3
        {
            width: 137px;
        }
        .style4
        {
            width: 157px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <table class="style1">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Ürün Türü"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Ürün Adı"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
    <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="true" >
    </asp:DropDownList>
            </td>
            <td class="style3">
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" OnClientClick="return drawChart();" 
                    Text="İstatistik Çıkar" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
       
        
    </table>
     <div id="chart_div" style="width: 700px; height: 300px; ">
        <asp:TextBox ID="TextBox1" runat="server" Width="1px" ></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Width="1px"  ></asp:TextBox>
        </div>
       
</asp:Content>

