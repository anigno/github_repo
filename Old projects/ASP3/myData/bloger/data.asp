<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
	</HEAD>
	<body>
<%
	show=Request.QueryString("show")	'which subject to show, or (-1) for all
	if show="" then show="-1"
%>

<%
	conn=openDB("bloger.mdb")
	set rs=getRS()
	if show="-1" then
		sql="select * from tblText where iUsername='" & session("username")	& "'" & " order by iDate DESC"
	else
		sql="select * from tblText where iUsername='" & session("username")	& "'" & " AND iSubjectNumber=" & show & " order by iDate DESC"		
	end if		
	rs.open sql,conn
%>
		<table border="1" align="center" ID="Table1">
		<tr><td colspan=4>����� ���� �� <%=session("username")%></td></tr>
			<tr>
				<td align=center>����� ����</td>
				<td align=center>����</td>
				<td width=200 align=center>�����</td>
				<td>������</td>
			</tr>
<%while not rs.eof%>
			<tr>
			<td><font size=2><%=rs("iDate")%></font></td>
			<td align=center><%=textSubject(rs("iSubjectNumber"))%></td>
			<td align=right><a href=showOne.asp?key=<%=rs("iKey")%>><%=rs("iHeader")%></a></td>
			<td><%if rs("iShowToAll")=true then Response.Write "��" else Response.Write "��"%></td>
			</tr>
<%rs.movenext%>
<%wend%>
		</table>
	</body>
</HTML>
