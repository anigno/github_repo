<%@ Language=VBScript Codepage=1255 %>
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body >
<%
	username=Session("username")
%>	
<%
	key=Request.QueryString("key")
	'generate sql for edit and insert
	sqlInsert="insert into tblData (iUsername,iPrivate,iFamily,iEmail1,iEmail2,iAddress,iPhone1,iPhone2,iText,iGroup) values(" & _
	"'" & username & "'," & _
	"'" & Request.Form("txtPrivate") & "'," & _
	"'" & Request.Form("txtFamily") & "'," & _
	"'" & Request.Form("txtEmail1") & "'," & _
	"'" & Request.Form("txtEmail2") & "'," & _
	"'" & Request.Form("txtAddress") & "'," & _
	"'" & Request.Form("txtPhone1") & "'," & _
	"'" & Request.Form("txtPhone2") & "'," & _
	"'" & Request.Form("txtText") & "'," & _
	"" & Request.Form("selectGroup") & ")"
	
	sqlEdit="update tblData " & _
	"set iUsername='" & username & "'," & _
	"iPrivate='" & Request.Form("txtPrivate") & "'," & _
	"iFamily='" & Request.Form("txtFamily") & "'," & _
	"iEmail1='" & Request.Form("txtEmail1") & "'," & _
	"iEmail2='" & Request.Form("txtEmail2") & "'," & _
	"iAddress='" & Request.Form("txtAddress") & "'," & _
	"iPhone1='" & Request.Form("txtPhone1") & "'," & _
	"iPhone2='" & Request.Form("txtPhone2") & "'," & _
	"iText='" & Request.Form("txtText") & "'," & _
	"iGroup=" & Request.Form("selectGroup") & " " & _
	"where iKey=" & key
	Response.Write sqlInsert & "<br>"
	Response.Write sqlEdit
%>
<%
	'open DB
	dim mdbFile,sql,RS,RS1,RS2
	mdbFile="/DB/addressBook.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Mode=3
	conn.Open connString
%>
<%
	set rs=Server.Createobject("ADODB.RecordSet")
	if key="-1" then
		rs.Open sqlInsert,conn
		Response.Write "insert"
	else
		rs.Open sqlEdit,conn
		Response.Write "edit"
	end if
	Response.Redirect "show.asp?group=" & Request.Form("selectGroup")
%>
	</body>
</HTML>
<script language=vbscript>
</script>

