<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	dim mdbFile,connString,conn,conn2,rs,rs2,sql,sql2
	'open DB
	mdbFile="db\simpleForum.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
%>
<%
	set rs=Server.Createobject("ADODB.RecordSet")
	set rs2=Server.Createobject("ADODB.RecordSet")
%>
<form action=addNewSubject.asp id=form1 name=form1>
	<INPUT type="submit" value="New Subject" id=submit1 name=submit1><BR>
</form>

<table border=0 >
<! table headers>
<tr align=center  bgcolor=Aqua>
<td>   subject   </td>
<td>  date & time  </td>
<td>  name  </td>
<td>  email address </td>
</tr>
<%
	'place root subjects
	sql="select * from table1 where connected='root' order by aDate DESC"
	rs.Open sql,conn
	rs.MoveFirst
	while not rs.EOF
%>
<tr bgcolor=Silver>
<td><a href=viewSubject.asp?<%Response.Write "sKey=" & rs("key")%>><%=rs("subject")%></a></td>
<td><%Response.Write rs("aDate") & " " & rs("aTime")%></td>
<td><%Response.Write rs("name")%></td>
<td><%Response.Write rs("email")%></td>
</tr>
<%
		'place connected subjects
		sql2="select * from table1 where connected='" & rs("key") & "'"
		rs2.Open sql2,conn
'			rs2.MoveFirst
			while not rs2.EOF
%>
<tr bgcolor=Silver>
<td><a href=viewSubject.asp?<%Response.Write "sKey=" & rs2("key")%>>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=rs2("subject")%></a></td>
<td><%Response.Write rs2("aDate") & " " & rs("aTime")%></td>
<td><%Response.Write rs2("name")%></td>
<td><%Response.Write rs2("email")%></td>
</tr>
<%
			rs2.MoveNext
			wend
		rs2.Close
		rs.MoveNext			
%>
</tr>
<%
	wend
%>

</table>

</BODY>
<%
	rs.Close
	conn.Close
%>
</HTML>
