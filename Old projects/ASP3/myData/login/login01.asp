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
	password=Request.Form("txtPassword")
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
	'check username and password
	sql="select * from " & dataTable & " where iUsername='" & username & "'"
	set rs=Server.Createobject("ADODB.RecordSet")
	rs.Open sql,conn
	if rs.EOF then
		'no username found
%>
	<script language=vbscript>
		MsgBox "שם משתמש לא קיים!",vbCritical
		window.history.back()
	</script>
<%	
	else
		'username ok, check password
		if password=rs("iPassword") then
			'login ok
			session("username")=username
			Response.Redirect returnPage
		else
			'wronge password
%>
	<script language=vbscript>
		MsgBox "סיסמה שגויה!",vbCritical
		window.history.back()
	</script>
<%			
		end if
	end if

%>
	</body>
</HTML>

