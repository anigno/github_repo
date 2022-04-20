<%@ Language=VBScript Codepage=1255 %>
<HTML dir=rtl>
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body >
<%
key=Request.QueryString("key")
group=Request.QueryString("group")
%>
<%
	'open DB
	dim mdbFile,sql,RS,RS1,RS2
	mdbFile="/DB/addressBook.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	'delete record with key
	set rs=Server.Createobject("ADODB.RecordSet")
	sql="delete from tblData where iKey=" & key
	Response.Write sql
	rs.Open sql,conn
	Response.Redirect "show.asp?group=" & group
%>

	</body>
</HTML>

