<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../../css/style01.css" />
	</HEAD>
	<body>
		<table border="1" align="center" >
			<tr><td>רשימת בלוגים</td></tr>
<%

	conn=openDB("users.mdb")
	set RS=getRS()
	sql="select * from tblUsers order by iUsername ASC"
	rs.open sql,conn
%>

<%while not rs.eof%>
	<tr><td align=center><a href=showPublic.asp?publicKey=<%=rs("iKey")%>&subjectNumber=-1 target=frameMain2><%=rs("iUsername")%></a></td></tr>
<%rs.movenext%>
<%wend%>
			
		</table>
	</body>
</HTML>
