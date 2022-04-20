<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />

	</HEAD>
<%
	link4="<a href=../bloger/public/blogers.asp target=frameMain>בלוגים ציבוריים</a>"
	if Session("username")<>"" then
		'username loged in
		link1="<A href=../addressBook/show.asp target=frameMain>פנקס כתובות</A>"
		link2="<A href=../bloger/bloger.asp?publicKey=0 target=frameMain>בלוגר אישי</A>"
		link3="<a href=../forum/forum.asp target=frameMain>פורומים</a>"
		link5="<a href=../calendar/calendar.asp target=frameMain>יומן</a>"
		link6="<A href=/myData/exit/exit.asp?returnPage=/myData/default.asp target=_parent>יציאה</A>"
	else
		'public user
		link1="<a href=../forum/forum.asp target=frameMain>פורומים</a>"
		link2="."
		link3="."
		link5="."
		link6="<A href=/myData/exit/exit.asp?returnPage=/myData/default.asp target=_parent>כניסה/רישום</A>"
	end if
%>
	<body>
		<table border="1" align="center" width="600" ID="Table1">
			<tr>
				<td rowspan="2" colspan=2 align="middle" width="200"><h3>רשימות&nbsp</h3></td>
				<td width="100" rowspan="2" vAlign="bottom"><%=Session("username")%></td>
				<td width="150" align="middle"><font size="2"><%=link1%></font></td>
				<td width="90" align="middle"><font size="2"><%=link2%></font></td>
				<td width="90" align="middle"><font size="2"><%=link3%></font></td>
			</tr>
			<tr>
				<td align="middle"><font size="2"><%=link4%></font></td>
				<td align="middle"><font size="2"><%=link5%></font></td>
				<td align="middle"><font size="2"><%=link6%></font></td>
			</tr>
		</table>
	</body>
</HTML>
