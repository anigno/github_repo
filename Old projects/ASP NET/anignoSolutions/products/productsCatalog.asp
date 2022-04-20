<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body background="../_images/<%=backgroundImage%>" bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>
		<table background="../_images/<%=tableBackgroundImage%>" align="center" width="140" border="1" ID="Table1">
			<tr>
				<td><FONT size="4">קטלוג מוצרים</FONT>
				</td>
			</tr>
			<%
	conn=openDB()
	set rs=getRS()
	'get all subjects from tblProductsSubjects
	sql="select * from tblProductsSubjects"
	rs.open sql,conn
%>
			<%
	while not rs.eof 
%>
			<tr>
				<td align="right"><a href=showSubject.asp?iKey=<%=rs("iKey")%> target=frameProductMain><font size=2><%=rs("iSubject")%></font></a>
				</td>
			</tr>
			<%
	rs.movenext
	wend
%>
		</table>
	</body>
</HTML>
