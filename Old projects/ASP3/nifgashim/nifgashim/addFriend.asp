<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

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
	'check if friend exist for iUsername
	iUsername=Request.Cookies("nifgashim")("username")
	iFriend=Request.QueryString("friend")
	sql="select * from tblFriends where username='" & _
		iUsername & "' and friend='" & iFriend & "'"
	rs.Open sql,conn
	if rs.EOF then
		'no friend, will add him to iUsername friends
		sql="insert into tblFriends (username,friend) VALUES ('" & _
			iUsername & "','" & iFriend & "')"
		rs.Close
		rs.Open sql,conn	
	else
		'friend exist
	end if
%>
<script language=vbscript>
	window.history.back
	window.parent.frameFriends.window.navigate "friends.asp"
</script>
</BODY>
</HTML>
