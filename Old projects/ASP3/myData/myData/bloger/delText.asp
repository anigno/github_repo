<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
	</HEAD>
<%
	key=Request.QueryString("key")
	conn=openDB("bloger.mdb")
	set rs=getRS()
	sql="delete from tblText where iKey=" & key
	rs.open sql,conn
	Response.Redirect "data.asp"
%>
	<body>
	</body>
</HTML>
