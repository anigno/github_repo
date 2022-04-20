<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<%
	dim mdbFile
	dim connString
	dim conn
	dim rs
	dim sql

	mdbFile="test01.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0; data source="	& server.MapPath(mdbFile)& ";"
	conn.Open connString
	sql="select * from grades"
	set rs=server.CreateObject("ADODB.recordset")
	rs.Open sql,conn
	
%>
<TABLE align=center border=1 cellPadding=1 cellSpacing=1 >
<%

	do while not rs.EOF
%> 
		<TR> 
			<TD>
			<%Response.write rs("key")%>
			</TD>
			<TD>
			<%Response.Write rs("name")%>
			</TD>
			<TD>
			<%Response.Write rs("grade")%>
			</TD>
		</TR>
<% 
		rs.MoveNext
	loop
	

%>

</BODY>
</HTML>
