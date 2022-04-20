<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	showDay=Request.QueryString("showDay")
	showDate=date()-showDay
	username=Request.QueryString("username")
%>
<table border=1  align=center dir=rtl>
<tr><td colspan=3 align=center><font color=blue>הודעות עבור <%=username%> לתאריך <%=showDate%></font></td></tr>
<%
	'open DB
	mdbFile="/db/calendar.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
%>
<%
	'get all messages for username and date
	sql="select * from tblCalendar where username='" & username & "'" &_
		"and iDate=" & showDate & " order by iTime"
	rs.open sql,conn
	do while not rs.EOF
%>
<tr>
<td align=center><%=rs("iTime")%>:00</td>
<td align=center><%=rs("iMessage")%></td>
<td><a href=delMessage.asp?key=<%=rs("key")%>&showDay=<%=showDay%>&username=<%=username%>>מחק</a></td></tr>
<%
		rs.MoveNext
	loop

%>
</table>	

</BODY>
</HTML>
</script>