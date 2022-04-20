<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<BODY>

<%
	'open DB
	mdbFile="\db\nifgashim.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
%>

<%
	iUsername=Request.Cookies("nifgashim")("username")

	iFriend=Request.QueryString("friend")
	sql="delete from tblFriends where username='" & iUsername & "'" & _
	"and friend='" & iFriend & "'"
'	Response.Write sql
	rs.Open sql,conn	
	Response.Redirect "friends.asp"

%>

</BODY>
</HTML>

