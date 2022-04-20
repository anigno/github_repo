<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../../css/style01.css" />
	</HEAD>
<%
	publicKey=Request.QueryString("publicKey")
	subjectNumber=Request.QueryString("subjectNumber")
	
	conn=openDB("users.mdb")
	set RS2=getRS()
	sql="select * from tblUsers where iKey=" & publicKey
	rs2.open sql,conn
	username=rs2("iUsername")
	
	conn=openDB("bloger.mdb")
	set rs=getRS()
	if subjectNumber="-1" then
		sql="select * from tblText where iUsername='" & username & "'" & " and iShowToAll=true " & " order by iDate DESC"
	else
		sql="select * from tblText where iUsername='" & username & "'" & " AND iSubjectNumber=" & subjectNumber & " and iShowToAll=true " & " order by iDate DESC"		
	end if		
	rs.open sql,conn
%>	
	<body>
		<table border=1 align=center>
		<tr><td><a href=showPublic.asp?publicKey=<%=publicKey%>&subjectNumber=-1>הכל</a></td>
<%for a=0 to ubound(textSubject)%>
<td><font size=2><a href=showPublic.asp?publicKey=<%=publicKey%>&subjectNumber=<%=a%>><%=textSubject(a)%></a></font></td>
<%next%>		
		</tr>
		</table>
		
		<table border="1" align="center" ID="Table1">
		<tr><td colspan=3>בלוגר ציבורי של <%=username%></td></tr>
			<tr>
				<td align=center>תאריך ושעה</td>
				<td align=center>נושא</td>
				<td width=200 align=center>כותרת</td>
			</tr>
<%while not rs.eof%>
			<tr>
			<td><font size=2><%=rs("iDate")%></font></td>
			<td align=center><%=textSubject(rs("iSubjectNumber"))%></td>
			<td align=right><a href=showPublicOne.asp?key=<%=rs("iKey")%>><%=rs("iHeader")%></a></td>
			</tr>
<%rs.movenext%>
<%wend%>
	</body>
</HTML>
