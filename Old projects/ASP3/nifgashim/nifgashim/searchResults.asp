<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	'getting data from search.asp
	'getting data from join.asp form
	username=Request.Form("txtUsername")
	name=Request.Form("txtName")
	family=Request.Form("txtfamily1")
	sex=Request.Form("txtSex")
	agefrom=Request.Form("txtagefrom")
	ageto=Request.Form("txtageto")
	state=Request.Form("txtState")
	region=Request.Form("txtRegion")
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
%>

<%
	'creating search sql string
	sql="select * from tblUsers where " 
	sql=sql & "age>='" & agefrom & "' and age<='" & ageto & "'"
	if username<>"" then sql=sql & " and username='" & username & "'"
	if family<>"" then sql=sql & " and family='" & family & "'"
	if name<>"" then sql=sql & " and name='" & name & "'"
	if state<>"0" then sql=sql & " and state='" & state & "'"
	if sex<>"0" then sql=sql & " and sex='" & sex & "'"
	if region<>"0" then sql=sql & " and region='" & region & "'"
	if smoke<>"0" then sql=sql & " and smoke='" & smoke & "'"
	if money<>"0" then sql=sql & " and imoney='" & money & "'"
	if drink<>"0" then sql=sql & " and drink='" & drink & "'"
	if believe<>"0" then sql=sql & " and believe='" & believe & "'"
	if education<>"0" then sql=sql & " and education='" & education & "'"
	if luck<>"0" then sql=sql & " and luck='" & luck & "'"
	if hairColor<>"0" then sql=sql & " and hairColor='" & hairColor & "'"
	if hairStyle<>"0" then sql=sql & " and hairStyle='" & hairStyle & "'"
	if body<>"0" then sql=sql & " and body='" & body & "'"
	if height<>"0" then sql=sql & " and height='" & height & "'"
	if army<>"0" then sql=sql & " and army='" & army & "'"
%>
<table border=1  width="100%" dir=rtl>
<tr><td colspan=3 align=middle>תוצאות החיפוש</td></tr>
<%
	rs.Open sql,conn
	do while not rs.EOF
%>
<TR>
<TD><a href=showUsername.asp?friend=<%=rs("username")%> title='לחץ כדי לצפות בפרטים'
	 target='_blank'><%=rs("username")%></a></TD>
<TD><a href=addFriend.asp?friend=<%=rs("username")%>> הוסף את <%=rs("family")%>
	_<%=rs("name")%></a></TD>
<TD><a href=makeRequest.asp?friend=<%=rs("username")%>>דבר עם
	<%=rs("family")%>_<%=rs("name")%></a></td></TR>
<%	
	rs.MoveNext
	loop
%>
<tr><td colspan=3 dir=ltr>
<INPUT id=btnBack language=vbscript name=btnBack onclick=window.navigate("search.asp") style="BACKGROUND-COLOR: oldlace; COLOR: orangered" type=button value=חזרה></td></tr>
</table>
</body>
</HTML>
