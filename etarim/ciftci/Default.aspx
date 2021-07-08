<%@ Page Title="" Language="C#" MasterPageFile="~/ciftci/ciftci.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ciftci_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 317px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
       <table width="748" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="254" align="left" valign="top" style="padding-top:21px; padding-bottom:28px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top" style="padding-bottom:28px;" class="style2"><table width="254" border="0" cellspacing="0" cellpadding="0" style="border:#D8F781 1px solid;">
              <tr>
                <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color:#617C58;">
                    <tr>
                      <td align="left" valign="top" style="padding-top:10px; padding-left:10px;"><img src="../image/index_27.gif" width="162" height="25" alt="" /></td>
                    </tr>
                    <tr>
                      <td align="left" valign="top"><table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" style=" background-color:#617C58">
                          <tr>
                            <td align="left" valign="top" style="padding-left:4px; padding-top:3px; padding-right:7px; padding-bottom:21px;"><img src="../image/index_32.gif" width="95" height="121" alt="" /></td>
                            <td align="left" valign="top" class="text" style="padding-right:8px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td align="left" valign="top" class="text" 
                                        style="padding-top:9px; color: #FFFFFF;">Tarım hakkındaki 
                                      son haberler bölümü<br /></td>
                                </tr>
                                <tr>
                                  <td align="left" valign="top" style="padding-top:4px;"><table width="100%" 
                                          border="0" cellspacing="0" cellpadding="0" style="height: 54px">
                                      <tr>
                                        <td width="51%" align="left" valign="top" style="padding-bottom:4px; color: #FFFFFF;">
                                            <br />
                                            <a href="default.aspx" style="color: #FFFFFF">Ayrıntısı</a></td>
                                        <td width="49%" align="left" valign="middle" style="padding-right:35px; color: #FFFFFF;"><img src="../image/index_68.gif" width="8" height="5" alt="" /></td>
                                      </tr>
                                  </table></td>
                                </tr>
                            </table></td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td align="left" style="padding-top:5px;">
                <table border="0" cellspacing="0" 
                    cellpadding="0" style="height: 400px; width: 99%; margin-top: 0px">
              <tr>
                <td align="left" valign="top" style="padding-left:3px; 
                      class="style3" class="style4"><img src="../image/index_40.gif" width="170" alt="" 
                        style="height: 23px; margin-top: 0px" /></td>
              </tr>
              <tr>
                <td align="left" valign="top" style="padding-top:5px;">
                    <form id="form1">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
    <ItemTemplate>
    <object width="252" height="280"><param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "url") %>'></param>
    <param name="allowFullScreen" value="true"></param>
    <param name="allowscriptaccess" value="always"></param>
    <embed src='<%#DataBinder.Eval(Container.DataItem, "url") %>' type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="252" height="280">
    </embed>
    </object>
    <br />    
    </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT TOP(1) [url], [aciklama], [id] FROM [videolar] ORDER BY id DESC ">
    </asp:SqlDataSource>
    </form><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <!--<td align="left" valign="top" class="category"><a href="~/videolar.aspx">Sistem ile ilgili diğer videolar için tıklayınız.</a></td>-->
                    </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
        <td width="526" align="left" valign="top" style="padding-top:21px; padding-bottom:28px;"><table width="480" border="0" align="right" cellpadding="0" cellspacing="0" style=" border:#414141 1px solid;">
          <tr>
            <td align="left" valign="top" style="background-color:#222222;">
                <table 
                    border="0" cellspacing="0" cellpadding="0" 
                    style="height: 502px; width: 45%; background-color:#D8F781">
                <tr>
                  <td align="left" valign="top" 
                        style="padding-top:21px; padding-left:18px; font-size: 18px; font-style: bold; font-family: 'times New Roman', Times, serif; color: #000000;" 
                        class="style3">Sistem Hakkında</td>
                </tr>
                <tr>
                  <td align="left" valign="top" class="text" style="padding-top:10px; padding-left:18px; padding-right:15px;">
                      <p class="Ozet" 
                          style="color: #000000; font-size: 15px; font-style: normal; font-family: 'Times New Roman', Times, serif">
                          <span style="text-transform:none;font-weight:normal">Bu projede Türkiye'deki 
                          çiftçiler ürünlerini farklı şehirlerdeki toptancılara satabileceklerdir. 
                          Şehirlerdeki toptancılarda ihtiyaç </span></p>
                      <p class="Ozet" 
                          style="color: #000000; font-size: 15px; font-style: normal; font-family: 'Times New Roman', Times, serif">
                          <span style="text-transform:none;font-weight:normal">duydukları ürünleri satan çiftçilere 
                          ulaşabileceklerdir. Bu amaç doğrultusunda hazırlanan E-tarım sistemi sayesinde,</span><span style="font-size:9.0pt;line-height:150%;font-weight:
normal"> </span></p>
                      <p class="Ozet" 
                          style="color: #000000; font-size: 15px; font-style: normal; font-family: 'Times New Roman', Times, serif">
                          <span style="text-transform:none;font-weight:normal">çiftçi ve toptancı iletişimini 
                          kolaylaştırmak amaçlanmıştır.</span><span style="font-weight:normal"><o:p></o:p></span></p>
                    </td>
                </tr>
				<tr>
				   <!--<td align="left" valign="top" style="padding-left:18px; padding-bottom:20px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="14%" align="left" valign="top" class="text"><a href="content.html">read more</a></td>
                       <td width="86%" align="left" valign="middle" style="padding-top:4px;"><img src="image/index_68.gif" width="8" height="5" alt="" /></td>
                     </tr>-->
                   </table>
                    
				</tr>
            </table></td>
          </tr>
        </table>
                     
       <asp:LinkButton ID="LinkButton2" runat="server" onclick="sistemvideolari_Click" ForeColor="Black"  >Sistem ile ilgili diğer videolar için tıklayınız.</asp:LinkButton>
       <br />
       
       <br />
       <asp:LinkButton ID="LinkButton3" runat="server" Font-Size="Medium" 
                        ForeColor="Black" onclick="mevzuatlar_Click">Yararlı dosyalar için tıklayınız.</asp:LinkButton>
       <br />
                          <br />
                        </td>
                    </tr><br />
          </td>
      </tr>
      
    </table>
                </td>
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
            </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td align="left" valign="top" style="padding-top:23px;"><table width="750" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:#070707 1px solid;">
      <tr>
        <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="center" valign="middle">
            <!--<pre class="footer"><a href="index.html">Home</a>       ::       <a href="content.html">About us</a>       ::       <a href="content.html">Service</a>       ::       <a href="contact.html">Contact us</a></pre></td>-->
          </tr>
          <tr>
            <td align="center" valign="middle" class="copyright">Copyright © 2013 Tüm hakları 
                Yıldız Teknik Üniversitesi Bilgisayar Mühendisliği Bölümü'ne aittir.</td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
    </asp:Content>