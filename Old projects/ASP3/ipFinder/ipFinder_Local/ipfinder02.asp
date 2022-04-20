<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<%
	dim mdbFile,conn
	mdbFile="..\db\ipFinder.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	openDb=conn
	set RS=Server.Createobject("ADODB.RecordSet")
	set RS1=Server.Createobject("ADODB.RecordSet")
	sql="select * from tblData"
	rs1.Open sql,conn
%>
<table border=1>
<tr>
<td>username</td><td bgcolor=Silver>remote addr</td>
<td>local addr</td><td>remote host</td>
</tr>
<%
while not rs1.EOF
%>
<tr>
<td><%=rs1("iUsername")%></td>
<td bgcolor=Silver><%=rs1("iRemote_addr")%></td>
<td ><%=rs1("iLocal_addr")%></td><td><%=rs1("iRemote_host")%></td>

<%
rs1.MoveNext
wend
%>
</table>
<INPUT type="button" value="reload IP's" id=button1 name=button1>
<INPUT type="button" value="change username" id=button2 name=button2>
</BODY>
</HTML>
<script language=vbscript>
	sub button1_onclick()
		navigate "ipfinder.asp"
	end sub

	sub button2_onclick()
		navigate "ipfinderdelCookies.asp"
	end sub
</script>

