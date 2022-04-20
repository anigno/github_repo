<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

<%
	iFriend=Request.QueryString("friend")
	iUsername=Request.Cookies("nifgashim")("username")
	Response.Write iUsername & " talk to " &  iFriend & "<br>"
%>

<%
'open DB
	dim mdbFile,connString,conn,rs,sql
	mdbFile="\db\nifgashim.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
	
	dim a
	dim b
	dim iLine()
	'select all lines into array
	sql="select * from tblTalk where (" & _
	"username='" & iUsername & "'" & _
	" and friend='" & iFriend & "') or ("  & _
	"username='" & iFriend & "'" & _
	" and friend='" & iUsername & "')"	
	rs.Open sql,conn
	'count lines
	do while not rs.EOF
		redim preserve iLine(a)
		iLine(a)=rs("theText") & "<BR>"
		a=a+1
		rs.MoveNext 
	loop
	'Response.Write "<BR>" & a & " lines until now<BR>"
	'display last 10 lines
	for b=a-10 to a-1
		if b>=0 then Response.Write iLine(b)
	next
%>
</BODY>
</HTML>
