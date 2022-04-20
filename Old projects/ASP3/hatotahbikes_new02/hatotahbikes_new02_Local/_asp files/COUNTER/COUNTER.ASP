<%@ Language=VBScript %>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
<html>
<head>
</head>
<body dir="rtl" stylesrc="../data.htm" background="../../bg01.jpg" text="#440000" link="#800000" vlink="#800000" alink="#CC0000" rightmargin="0" bottommargin="0" leftmargin="0" topMargin="0">
<%
	Application("hatotahbikes_counter")=Application("hatotahbikes_counter")+1
	Response.Write Application("hatotahbikes_counter")
%>
<font size="1"><br>מבקרים</font>
</body>
</html>
