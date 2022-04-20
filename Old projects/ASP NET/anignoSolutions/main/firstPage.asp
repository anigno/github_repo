<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body background="../_images/<%=backgroundImage%>" bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>
		<%
		conn=openDB()
		set rs=getRS()
		'get news from tblNews
		sql="select * from tblNews order by iDate DESC"
		rs.open sql,conn
%>
		<table width="600" background="../_images/<%=tableBackgroundImage%>" align="center" border=1 ID="Table2">
			<tr>
				<td align="middle" colspan="2"><FONT size="4">חדשות</FONT>
				</td>
			</tr>
			<%
		while not rs.eof
%>
			<tr>
				<td dir="ltr"><font size="2"><%=day(rs("iDate"))%>
						/<%=month(rs("iDate"))%>
						/<%=year(rs("iDate"))%></font></td>
				<td><font size="3"><%=rs("iText")%></font></td>
			</tr>
			<%
			rs.movenext
		wend
%>
		<tr>
			<td colspan=2 align=center> <img src="../_images/<%=firstPageImage%>" width=600>
			</td>
		</tr>
		</table>
	</body>
</HTML>
