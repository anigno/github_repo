<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	'getting data from main.asp
	iTime=Request.Form("txtTime")
	iMessage=Request.Form("txtMessage")
	iDate=Request.Form("txtDate")
	username="anigno"
	
%>
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
	
	
	'add message to tblCalendar
	if iMessage<>"" then
	sql="insert into tblCalendar (username,iDate,iTime,iMessage) values(" &_
		"'" & username & "'," &_
		iDate & "," &_
		iTime & "," &_
		"'" & iMessage & "'" &_
		")"
	Response.Write sql
	rs.Open sql,conn
	end if
%>
</BODY>
</HTML>
<script language=vbscript>
	window.history.back
</script>