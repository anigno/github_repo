<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

<%
	'get username from coockies
	username=Request.Cookies("nifgashim")("username")
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
%>

<%
	'getting username friends list
	sql="select * from tblFriends where username='" & username & "'"
	rs.Open sql,conn
%>
<TABLE dir=rtl border=1 cellPadding=0 cellSpacing=0 width="100%" height="54" style="border-collapse: collapse" bordercolor="#111111" dir=rtl>
  <TR>
    <TD colspan="2"> חברים של <%=username%></TD>
    </TR>
<%do while not rs.EOF%>
<TR>
<td><a href=makeRequest.asp?friend=<%=rs("friend")%>> דבר עם<%=rs("friend")%></a></td>
<td><a href=delFriend.asp?friend=<%=rs("friend")%>> מחק </a></td>
</TR>
<%rs.MoveNext%>
<%loop%>
</TABLE>

</body>
</HTML>