<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
			<link rel="stylesheet" type="text/css" href="../css/style01.css" />
</HEAD>
<%
	key=Request.QueryString("key")
	root=Request.QueryString("root")
	forumNumber=Request.QueryString("forumNumber")
	forumText=forumSubject(forumNumber)	
%>

<%
	if key<>"-1" then
		conn=openDB("forum.mdb")
		set rs=getRS()
		sql="select * from tblData where iKey=" & key
		rs.open sql,conn
		prevHeader=rs("iHeader")
		prevText=rs("iText")
	end if
%>
	<body>
		<form id=form1 name=form1 method=post enctype="multipart/form-data">
		<table border="1" align="center" width="600" ID="Table1">
			<tr><td colspan=2 align=center><%=forumText%></td></tr>
<%if key="-1" then%>
			<tr><td colspan=2 align=center>הוספת נושא חדש</td></tr>
<%else%>
			<tr><td colspan=2 align=center>הוספת תגובה</td></tr>
			<tr><td colspan=2><font size=2><%=prevHeader%><br><%=prevText%></font></td></tr>
<%end if%>
			<tr><td>כינוי:</td><td><INPUT type="text" ID="txtUsername" NAME="txtUsername" value=<%=Session("username")%>></td></tr>
			<tr><td>כותרת:</td><td><INPUT type="text" ID="txtHeader" NAME="txtHeader" size=60></td></tr>
			<tr><td colspan=2 align=center><TEXTAREA rows=10 cols=50 ID="txtText" NAME="txtText"></TEXTAREA></td></tr>
			<tr><td>הוספת תמונה:</td><td><INPUT type="file" ID="File1" NAME="File1" size=40></td></tr>
			<tr>
				<td colspan=2><INPUT type="button" value="הוספה" ID="btnOK" NAME="btnOK">&nbsp&nbsp&nbsp
				<INPUT type="button" value="ביטול" ID="btnCancel" NAME="btnCancel"></td>
			</tr>
		</table>
		</form>
	</body>
</HTML>
<script language=vbscript>
	sub btnCancel_onClick()
		window.history.back
	end sub
	
	sub btnOK_onClick()
		'check fields
		dim error:error=false
		if form1.txtHeader.value="" or form1.txtUsername.value="" then
			MsgBox "חובה לרשום כותרת וכינוי",vbCritical
		else
			'submit form
			form1.action="editInsert01.asp?key=<%=key%>&forumNumber=<%=forumNumber%>&root=<%=root%>"
			form1.submit
		end if
		
	end sub
</script>