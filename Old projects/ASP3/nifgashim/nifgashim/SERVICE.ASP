<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

<%
	'getting username data
	iUsername=Request.Cookies("nifgashim")("username")
%>

<%
	'open DB
	mdbFile="\db\nifgashim.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
	set rs1=Server.Createobject("ADODB.RecordSet")
	set rs2=Server.Createobject("ADODB.RecordSet")
%>

<%
	'check talk requests from username
	sql="select * from tblRequests where" &_
		" username='" & iUsername & "' and" &_
		" request='waiting'"
	rs.Open sql,conn

	do while not rs.EOF
		'will open request.asp for each request
		'	with the username the sent the request
	Response.Write "<SCRIPT LANGUAGE=vbscript>"
	Response.Write "window.open" & chr(34) & _
		"talk.asp?Friend=" & rs("friend") & chr(34) & "," & chr(34) & _
		rs("friend") & chr(34) & "," & chr(34) & _
		"toolbar=0 width=500 height=550"  & chr(34) 
	Response.Write "</SCRIPT>"
	rs.MoveNext
	loop

%>

<%
	'change talk requests from waiting to talk
	sql="UPDATE tblRequests SET request='talk' where username='" &_
	iUsername & "' and request='waiting'"
	rs1.Open sql,conn
%>

</BODY>
</HTML>

<script language=vbscript>
	setTimeout "runReload()",10000
	sub runReload()
		window.location.reload
	end sub
</script>