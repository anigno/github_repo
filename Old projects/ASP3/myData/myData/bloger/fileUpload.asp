<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body>
<%
	key=Request.QueryString("key")
	if key="-1" then
		conn=openDB("bloger.mdb")
		set RS=getRS()
		sql="select * from tblText order by iDate DESC"
		rs.open sql,conn
		key=rs("iKey")
	end if
		
	
	
%>
	</body>
</HTML>
