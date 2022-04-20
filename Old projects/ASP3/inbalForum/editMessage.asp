<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<%
	'get data from user to add message to forumId
	'if the message is a new message then recieved iParent=0
	'	else recieved iParent=key (of parent message)
%>
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body dir="rtl" stylesrc="main.asp" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
EDIT MESSAGE<br>
לא להשתמש בסימנים גרש ' , גרשיים &quot; , ו &gt; <<br>
<%
	forumId=Request.QueryString("forumId")
	iUsername=session("inbal_username")
	iKey=Request.QueryString("key")
	iRoot=Request.QueryString("iRoot")
	if iParent=0 then session("inbal_showMessage")=""
	session.Timeout=30	

	Response.Write iUsername  & " :username<BR>"
	Response.Write iKey & " :message key<BR>"
	Response.Write forumId  & " :forumId<BR>"
%>

<%
	dim conn,SQL,RS
	conn=openDb()
	set RS=getRs()
	sql="SELECT * from forumData where key=" & iKey
	rs.open sql,conn
%>
<form id="form1" name="form1" method="post" action="EditMessage01.asp?iparent=<%=iParent%>&amp;forumId=<%=forumId%>&amp;Key=<%=iKey%>">
<input type="text" id="txtSubject" name="txtSubject" value="<%=rs("txtSubject")%>" size="40"><br>
<textarea rows="15" cols="50" id="txtMessage" name="txtMessage">
<%=rs("txtMessage")%>
</textarea><br>
<input type="button" value="שלח הודעה" id="btnAdd" name="btnAdd" style="BACKGROUND-COLOR: moccasin"></td><td>
<a href="forumShow.asp?forumId=<%=forumId%>">חזרה לעמוד הפורום</a>



</form>
</body>
</html>

<script language="vbscript">
	sub btnAdd_onclick()
		if form1.txtSubject.value="" then
			msgbox "יש להכניס נושא להודעה",vbCritical
		else
			'check text first to block illigle chars
			form1.txtSubject.value=checkText(form1.txtSubject.value)
			'form1.txtMessage.value=checkText(form1.txtMessage.value)
			form1.btnAdd.disabled=true
			form1.submit
		end if
	end sub
</script>

<%
	Set Conn = Nothing
%>