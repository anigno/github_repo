<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<P>

<%
	'getting data from join.asp form
	username=Request.Form("txtUsername")
	passwd=Request.Form("txtpasswd1")
	name=Request.Form("txtName")
	family=Request.Form("txtfamily1")
	sex=Request.Form("txtSex")
	age=Request.Form("txtage")
	state=Request.Form("txtState")
	region=Request.Form("txtRegion")
	occupation=Request.Form("txtOccupation")
	smoke=Request.Form("txtSmoke")
	money=Request.Form("txtMoney")
	drink=Request.Form("txtDrink")
	believe=Request.Form("txtbelieve")
	education=Request.Form("txteducation")
	luck=Request.Form("txtLuck")
	hairColor=Request.Form("txtHaircolor")
	hairStyle=Request.Form("txtHairstyle")
	body=Request.Form("txtBody")
	height=Request.Form("txtheight")
	interests=Request.Form("txtInterests")
	army=Request.Form("txtArmy")
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
%>

<%
	'check if username exist
	sql="select * from tblUsers where username='" & username & "'"
	rs.Open sql,conn
	if rs.EOF then
		'add username to tblUsers
		sql="insert into tblUsers (username,passwd,name,family,sex,age,state,region,occupation,smoke,imoney,drink,believe,education,luck,haircolor,hairstyle,body,height,interests,army) values(" & _
		"'" & username & "'" &_
		",'" & passwd & "'" &_
		",'" & name & "'" &_
		",'" & family & "'" &_
		",'" & sex & "'" &_
		",'" & age & "'" &_
		",'" & state & "'" &_
		",'" & region & "'" &_
		",'" & occupation & "'" &_
		",'" & smoke & "'" &_
		",'" & money & "'" &_
		",'" & drink & "'" &_
		",'" & believe & "'" &_
		",'" & education & "'" &_
		",'" & luck & "'" &_
		",'" & haircolor & "'" &_
		",'" & hairstyle & "'" &_
		",'" & body & "'" &_
		",'" & height & "'" &_
		",'" & interests & "'" &_
		",'" & army & "'" &_
		")"
		rs1.open sql,conn
		Response.Redirect "login.asp?join=yes"
	end if
%>
</P>

<P>
<TABLE border=0 borderColor=#111111 cellPadding=0 cellSpacing=0 height=448 
style="BORDER-COLLAPSE: collapse" width="100%">
  
  <TR>
    <TD background=images/leftRoze.gif height=448 rowSpan=11 
    width="30%">&nbsp;</TD>
    <TD background=images/nifgashim.gif colSpan=4 height=85 
    width="75%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=37 width="15%">&nbsp;</TD>
    <TD align=right height=37 width="20%"></TD>
    <TD align=right height=37 width="20%"></TD>
    <TD align=right height=37 width="20%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=37 width="55%" colspan="3">
      שם משתמש קיים, בחר שם אחר</TD>
    <TD align=right height=37 width="20%"></TD></TR>
  <TR>
    <TD align=right height=36 width="15%">
      <DIV id=divpasswd1></DIV></TD>
    <TD align=right height=36 width="20%"><INPUT id=btnBack name=btnBack style="BACKGROUND-COLOR: oldlace; COLOR: crimson; FONT-WEIGHT: bold" type=button value=חזרה></TD>
    <TD align=right height=36 width="20%"></TD>
    <TD align=right height=36 width="20%"></TD></TR>
  <TR>
    <TD align=right height=36 width="15%">
      <DIV id=divpasswd2></DIV></TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%"></TD>
    <TD align=right height=36 width="20%"></TD></TR>
  <TR>
    <TD align=right height=36 width="15%">&nbsp;</TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%">&nbsp;</TD></TR>
  <TR>
    <TD align=right height=36 width="15%">
      <DIV id=divname></DIV></TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%"></TD>
    <TD align=right height=36 width="20%"></TD></TR>
  <TR>
    <TD align=right height=36 width="15%">
      <DIV id=divfamily></DIV></TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%"></TD>
    <TD align=right height=36 width="20%"></TD></TR>
  <TR>
    <TD align=right height=36 width="15%">&nbsp;</TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%"></TD>
    <TD align=right height=36 width="20%"></TD></TR>
  <TR>
    <TD align=right height=36 width="15%">&nbsp;</TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%"></TD>
    <TD align=right height=36 width="20%"></TD></TR>
  <TR>
    <TD align=right height=36 width="15%">&nbsp;</TD>
    <TD align=right height=36 width="20%">&nbsp;</TD>
    <TD align=right height=36 width="20%"></TD>
    <TD align=right height=36 width="20%"></TD></TR></TABLE></P>
<P>&nbsp;</P>
</body>
</HTML>
<script language=vbscript>
sub btnBack_onClick()
	window.history.back
end sub
</script>