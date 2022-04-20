<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body background=<%=backgroundImage%> bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>
<%
	delKey=Request.QueryString("delKey")
	returnPage=Request.QueryString("return")
	conn=openDB()
	set rs=getRS()
	'delete product from basket
	sql="delete from tblBasket where iKey=" & delKey
	rs.open sql,conn
%>	
	</body>
</HTML>
<%
if returnPage=2 then
%>	
<script language=vbscript>
	window.location="pay.asp"
</script>	
<%else%>
<script language=vbscript>
	window.location="basket.asp"
</script>	
<%end if%>