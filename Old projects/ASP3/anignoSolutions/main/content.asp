<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta content="HE" name="ms.locale">
	</HEAD>
	<body background="../_images/<%=backgroundImage%>" bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>
	<table width=600 align=center border=1 background="../_images/<%=tableBackgroundImage%>">
		<tr>
		<td align=center colspan=4><img src="../_images/<%=mainHeaderWithText%>" height="90" id=imgMain name=imgMain></td>
		<td width=140 align=center><img src="../_images/<%=storeLogo%>" align=middle id=imgLogo name=imgLogo></td>
		</tr>
		<tr>
		<td align=center><FONT size="2"><A href="firstPage.asp" target="frameData">חדשות</A> </FONT></td>
		<td align=center><FONT size="2"><A href="../about/about.asp" target="frameData">אודות</A></FONT></td>
		<td align=center><FONT size="2"><A href="../products/products.asp" target="frameData">מוצרים</A></FONT></td>
<%if showBasket=true then%>			
<td align=center>
<FONT size="2"><A href="../basket/pay.asp" target="frameData">סל הקניות</A></FONT>
</td>
<%end if%>			
<td align=center><FONT size="2"><A href="mailto:<%=gettext("email")%>">דוא"ל </A></FONT></td>
		</tr>

	</table>
	
	</body>
</HTML>
<script language=vbscript>
	if imgLogo.height>60 then imgLogo.height=60
	if imgMain.height>100 then imgMain.height=100
</script>