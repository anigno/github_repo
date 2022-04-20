<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
	</HEAD>
<%
	pageNumber=Request.QueryString("pageNumber")
	forumNumber=Request.QueryString("forumNumber")
	forumText=forumSubject(forumNumber)
%>

	<body>
		<table border="1" align="center" width="600" ID="Table1">
		<tr><td align=center colspan=3><%=forumText%></td></tr>
		<tr><td colspan=3>
			<a href=editInsert.asp?key=-1&forumNumber=<%=forumNumber%>&root=-1>הוספה</a>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
			<a href="forum.asp">חזרה</a></td></tr>	
			<script language=vbscript>
				sub goBack()
					window.history.back
				end sub
			</script>
<%
	conn=openDB("forum.mdb")
	set rs=getRS()	'for roots
	sql="select * from tblData where iRoot=-1 AND iForumNumber=" & forumNumber & " order by iDate DESC"
	rs.open sql,conn
	dim rootsPerPage:rootsPerPage=4
%>
<%
	while not rs.eof
		showMessage rs("iKey"),0
		rs.movenext
	wend
%>
		</table>
	</body>
</HTML>

<%
	dim a:a=1
	sub showMessage(key,n)
		dim rs:set rs=getRS()
		sql="select * from tblData where iKey=" & key
		rs.open sql,conn
%>
<tr>
	<td width=400>
		<font size=3><%=spaces(n)%>
		<span style='cursor:hand' onclick="show<%=a%>()"><u><b><%=rs("iHeader")%></b></u></span><br>
		<span id=div<%=a%>></span></font>
	</td>
	<td width=100><font size=2><%=rs("iUsername")%></font></td>
	<td width=110 align=center><font size=1><%=rs("iDate")%></font></td>
</tr>
<script language=vbscript>
	sub show<%=a%>()
<%if rs("iPicture")<>"" then%>
	picture="<img src=../../db/_files/<%=rs("iPicture")%>><br>"
<%end if%>
		if div<%=a%>.innerHtml="" then 
			div<%=a%>.innerHtml="<%=fixBR(rs("iText"))%>" & "<br>" & picture & "<a href=editInsert.asp?key=<%=rs("iKey")%>&root=<%=rs("iRoot")%>&forumNumber=<%=forumNumber%>	>הוסף תגובה</a>"
		else
			div<%=a%>.innerHtml=""
		end if
	end sub
</script>
<%		
	a=a+1
	sql="select * from tblData where iRoot=" & key
	dim rs2:set rs2=getRS()
	rs2.open sql,conn
	while not rs2.eof
		showMessage rs2("iKey"),n+1
		rs2.movenext
	wend
	end sub
%>

<%
	function spaces(n)
		dim q
		if n>8 then n=1
		for q=1 to n * 3
			spaces=spaces & "&nbsp"
		next	
	end function
%>