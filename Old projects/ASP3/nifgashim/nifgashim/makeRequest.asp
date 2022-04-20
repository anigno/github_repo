<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	'getting friend and username data
	iFriend=Request.QueryString("friend")
	iUsername=Request.Cookies("nifgashim")("username")
	
	Response.write iUsername & " is sending request to " & iFriend
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
	'check if such request already waiting
	sql="select * from tblRequests where" & _
		" username='" & Iusername & "'" & _
		" and friend='" & iFriend & "'" & _
		" and request='waiting'"
	rs.Open sql,conn
	if rs.EOF then
		'no such request will create one
		sql="insert into tblRequests (username,friend,request) values('" & _
			iUsername & "','" &_
			iFriend & "','waiting')"
		rs1.Open sql,conn
		sql="insert into tblRequests (username,friend,request) values('" & _
			iFriend & "','" & _
			iUsername & "','waiting')"
		rs2.Open sql,conn
	end if		
%>


</BODY>
</HTML>
<script language=vbscript>
	window.history.back
</script>