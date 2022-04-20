<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	dim mdbFile,connString,conn,rs,sql
	'open DB
	mdbFile="..\db\dataManager.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
%>
<%
	dim iUserName,iPassword
	iUserName=Request.Form("txtUserName")
	iPassword=Request.Form("txtPassword")
	sql="select * from tblUsers where userName='" &_
		iUserName & "' and passwd='" & iPassword & "'"
	rs.Open sql,conn
%>
<%
	if rs.EOF then
		'EOF, no user name and password match found
%>
		<script language=vbscript>
			MsgBox "No user name or wrong password",vbCritical
			history.back
		</script>
<%
	else
		'no EOF, user name and password OK
	Session("userName")=iUserName
	Session("passwd")=iPassword
	Session.Timeout=20
	Response.Redirect "main.asp"
	end if
%>
</BODY>
</HTML>
