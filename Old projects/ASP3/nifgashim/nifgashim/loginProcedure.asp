<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	'getting login data
	username=Request.Form("txtUsername")
	passwd=Request.Form("txtPasswd")
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
	'check for correct username and passwd
	sql="select * from tblUsers where username='" & username & "'"
	rs.Open sql,conn
	if rs.eof then
		'no username
		tError="שם משתמש לא קיים"
	else
		'username found, check passwd
		if rs("passwd")=passwd then
			'both username and passwd OK 
			'redirect to mainpage, username send by coockies
			Response.Cookies("nifgashim")("username")=username
			Response.Redirect "mainpage.asp"
		else
			'wronge passwd
			tError="סיסמה שגויה"
		end if
	end if
%>
<%
	rs.Close
	conn.Close
%>
<P></P>
<P> 
</P>
<P>
<FORM id=form1 language=JavaScript method=post name=FrontPage_Form1 
onsubmit="return FrontPage_Form1_Validator(this)">
<TABLE border=0 borderColor=#111111 cellPadding=0 cellSpacing=0 height=448 
style="BORDER-COLLAPSE: collapse" width="100%">
  
  <TR>
    <TD background=images/leftRoze.gif height=448 rowSpan=9 
    width="30%">&nbsp;</TD>
    <TD background=images/nifgashim.gif colSpan=4 height=85 
    width="75%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=46 width="19%">&nbsp;</TD>
    <TD align=right height=46 width="19%">&nbsp;</TD>
    <TD align=right height=46 width="19%">&nbsp;</TD>
    <TD align=right height=46 width="18%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%"><%=tError%><DIV></DIV></TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="18%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=46 width="19%">&nbsp;</TD>
    <TD align=right height=46 width="19%">&nbsp;</TD>
    <TD align=right height=46 width="19%">&nbsp;</TD>
    <TD align=right height=46 width="18%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="18%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="18%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=45 width="19%">
    <INPUT id=btnBack language=vbscript name=btnBack onclick=window.history.back style="BACKGROUND-COLOR: oldlace; COLOR: orangered" type=button value=חזרה>&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="18%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="18%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="19%">&nbsp;</TD>
    <TD align=right height=45 width="18%">&nbsp;</TD></TR></TABLE> 
</FORM> 
</P>
<P>&nbsp;</P>
<P>&nbsp;</P>


</body>
</HTML>
