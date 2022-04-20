<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../../css/style01.css" />
	</HEAD>
<%
	key=Request.QueryString("key")
	conn=openDB("bloger.mdb")
	set rs=getRS()
	sql="select * from tblText where iKey=" & key
	rs.open sql,conn
%>	
	<body>
		<table border="1" align="center"  ID="Table1">
			<tr><td>
			<a id="A2" name=goBack onclick="goBack()" href=#><font size=2>חזרה</font></a>
			</td></tr>
			<tr><td><%=rs("iDate")%></td></tr>
			<tr><td><%=textSubject(rs("iSubjectNumber"))%></td></tr>
			<tr><td align=center><h1><%=rs("iHeader")%></h1></td></tr>
			<tr><td><%=fixBR(rs("iText"))%></td></tr>
<%if rs("iPicture")<>"" then%>
			<tr><td><img src="../../../db/_files/<%=(rs("iPicture"))%>"></td></tr>
<%end if%>			
			<tr><td>
			<a id="A4" name=goBack onclick="goBack()" href=#><font size=2>חזרה</font></a>
			</td></tr>
		</table>
	</body>
</HTML>
<script language=vbscript>
	sub goBack()
		window.history.back
	end sub
</script>