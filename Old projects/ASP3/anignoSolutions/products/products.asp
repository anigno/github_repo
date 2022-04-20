<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
<%if showBasket=true then%>
	<frameset cols="230,*">
		<frameset rows="200,*">
			<frame src=productsCatalog.asp marginwidth="5" marginheight="5" noresize>
			<frame src=../basket/basket.asp marginwidth="5" marginheight="5" id=frameBasket noresize>
		</frameset>
		<frame src=productsMain.asp id=frameProductMain name=frameProductMain marginwidth="5" marginheight="5">
	</frameset>
<%else%>
	<frameset cols="230,*">
		<frame src=productsCatalog.asp marginwidth="5" marginheight="5" noresize>
		<frame src=productsMain.asp id=frameProductMain name=frameProductMain marginwidth="5" marginheight="5">
	</frameset>
<%end if%>
</HTML>
