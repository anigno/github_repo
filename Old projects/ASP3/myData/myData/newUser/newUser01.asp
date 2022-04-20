<%@ Language=VBScript Codepage=1255 %>
<HTML dir=rtl>
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body >
<%
	'get data from previous form
	returnPage=Request.QueryString("returnPage")
	dataFile=Request.QueryString("dataFile")
	dataTable=Request.QueryString("dataTable")
	username=Request.Form("txtUsername")
	password=Request.Form("txtPassword1")
%>
<%
	'open data connection
	mdbFile=dataFile
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
%>	
<%
	'check if username already exist
	sql="select * from " & dataTable & " where iUsername='" & username & "'"
	set rs=Server.Createobject("ADODB.RecordSet")
	rs.Open sql,conn
	if rs.EOF then
		'not exist, will add username to dataFile
		sql="insert into " & dataTable & " (iUsername,iPassword) values("
		sql=sql & "'" & username & "'," 
		sql=sql & "'" & password & "')"
		set rs1=Server.Createobject("ADODB.RecordSet")
		rs1.Open sql,conn
		session("username")=username
%>
	<script language=vbscript>
		window.location="<%=returnPage%>"
	</script>
<%		
	else
		'username exist, run script
%>
<script language=vbscript>
	MsgBox "משתמש כבר קיים במערכת",vbCritical
	window.history.back()
</script>
<%		
	end if		
%>
	</body>
</HTML>

