<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	showDay=Request.QueryString("showDay")
	showDate=date()-showDay
	username="anigno"
%>
<table border=1  align=center dir=rtl>
<tr><td colspan=3 align=center><font color=blue><%=showDate%></font></td></tr>
<%
	'open DB
	mdbFile="calendar.mdb"
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
<td><a href=delMessage.asp?key=<%=rs("key")%>&showDay=<%=showDay%>>ξηχ</a></td></tr>
<%
		rs.MoveNext
	loop

%>
</table>	

</BODY>
</HTML>
</script>