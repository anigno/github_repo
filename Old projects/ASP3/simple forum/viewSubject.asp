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
	set rs=Server.Createobject("ADODB.RecordSet")
	sql="select * from table1 where key=" & Request.QueryString("sKey") 
	rs.Open sql,conn
%>
<table border =0>
<tr bgcolor=Silver>
	<td>subject</td><td><%=rs("subject")%></td>
</tr><tr bgcolor=Silver>
	<td>date & time</td><td><%=rs("aDate") & "   " & rs("aTime")%></td>
</tr><tr bgcolor=Silver>
	<td>name</td><td><%=rs("name")%></td>
</tr><tr bgcolor=Silver>
	<td>message</td><td><%=rs("message")%></td>
</tr><tr bgcolor=Silver>
	<td><A href="mailto:<%=rs("email")%>">EMAIL</A></td>
</tr>
</table>
<%
	Session("sKey")=Request.QueryString("sKey")
%>
	<INPUT type="button" value="Add comment" id=button1 name=button1 onClick = addComment()>
<script language=vbscript>
'	dim sKey
'	sKey=<%=request.QueryString("sKey")%>
	public sub addComment()
		navigate "addComment01.asp"
	end sub
</script>

</BODY>
</HTML>
