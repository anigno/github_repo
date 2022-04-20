<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<frameset cols="200,*">
		<frame frameborder=no bordercolor=#333300 src="content.asp?publicKey=<%=Request.QueryString("publicKey")%>" target="frameData">
		<frame frameborder=no bordercolor=#333300 src="data.asp?publicKey=<%=Request.QueryString("publicKey")%>" id="frameData" name="frameData">
	</frameset>
</HTML>
