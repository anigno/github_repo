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
	'check for username avaliable
	dim iuserName,iPassword
	iuserName=Request.Form("userName")
	iPassword=Request.Form("password1")
	'run SQL on userName requested
	sql="select * from tblUsers where userName='" _
		& iuserName & "'"
	rs.Open sql,conn
	if not rs.EOF then
		'user name exist no EOF
%>		
		<script language=vbscript>
			MsgBox "user name exist, try diferent user name",vbCritical
			window.navigate "newUser01.asp"
		</script>
<%		
	else 
		'EOF no username
		'add new user to database
		rs.Close 'must be close before opening another recordSet
		sql="insert into tblUsers (userName,passwd) values ('" & iuserName & "','" & iPassword & "')"
		rs.Open sql,conn
		Response.Redirect "login01.asp"
	end if
'close rs and conn	
'	rs.Close
'	set rs=nothing
'	conn.Close
'	set conn=nothing
'Response.Redirect "login01.asp"
%>
</BODY>
</HTML>
