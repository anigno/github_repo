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
<%
	forumId=Request.QueryString("forumId")
	if forumId="" then 
		'return from upload
		forumid=session("inbal_forumId")
	else
		'regular , write data
		session("inbal_forumId")=forumId
	end if
	iParent=Request.QueryString("iParent")
	if iParent="" then
		iParent=session("inbal_iParent")
	else
		session("inbal_iParent")=iParent
	end if
	iUsername=session("inbal_username")
	iRoot=Request.QueryString("iRoot")
	if iRoot="" then
		iRoot=session("inbal_iRoot")
	else
		session("inbal_iRoot")=iRoot
	end if
	
	iFilename=Request.Form("iFilename")
	session("inbal_filename")=iFilename	
	
	if iParent=0 then session("inbal_showMessage")=""
	session.Timeout=30	
	
	if session("inbal_subject")="_" then session("inbal_subject")=" "
	if session("inbal_message")="_" then session("inbal_message")=" "
	'Response.Write forumid & "=fid<BR>"
	'Response.Write iParent  & "=ipar<BR>"
	'Response.Write iusername  & "=iu<BR>"
	'Response.Write iRoot  & "=ir<BR>"
	'Response.Write iFilename  & "=if<BR>"
	
	
%>

<%
	'fix the time and date
	dim iHour,iDay
	iHour=hour(time)
	iDay=day(date)
	iHour=iHour+7
	if iHour>23 then 
		iHour=iHour-24
		iDay=day(date)
		iDay=iDay+1
	end if
'real date is: DateSerial(year(date),month(date),iDay)
'real time is: TimeSerial(iHour,minute(time),second(time))
%>

<form id="form1" name="form1" method="post" action="addMessage01.asp?iparent=<%=iParent%>&amp;forumId=<%=forumId%>&amp;iRoot=<%=iRoot%>">
<div id="prevMessage"><%=session("inbal_showMessage")%></div>
<table border="1" dir="rtl" align="center" width="70%">
<tr><td><%=TimeSerial(iHour,minute(time),second(time))%>&nbsp;</td>
<td><%=DateSerial(year(date),month(date),iDay)%>&nbsp;</td></tr>
<tr><td colspan="2"><%=iUsername%>&nbsp;</td></tr>
<tr>
<td>נושא</td>
<td><input value="<%=session("inbal_subject")%>" id="txtSubject" name="txtSubject" style="BACKGROUND-COLOR: moccasin; HEIGHT: 25px; WIDTH: 428px">

</td></tr>

<tr><td>תוכן</td><td><textarea cols="30" id="txtMessage" name="txtMessage" rows="10" style="BACKGROUND-COLOR: moccasin; HEIGHT: 206px; WIDTH: 431px">
<%=session("inbal_message")%>
</textarea></td></tr>

<tr>
<td><a href="#" onclick="openIconList()">אייקונים</a></td>
<td><div id="iconList">&nbsp;</div></td>
</tr>
<tr><td>

</td><td>
<div id="iFileToUpload"><%=iFilename%>&nbsp;</div>
<td><tr>

<tr><td>
<input type="button" value="שלח הודעה" id="btnAdd" name="btnAdd" style="BACKGROUND-COLOR: moccasin"></td><td>
<a href="forumShow.asp?forumId=<%=forumId%>">חזרה לעמוד הפורום</a>
</td></tr>

<tr><td>ההודעה</td><td><div id="tText"></div>
</td></tr>
</table>
</form>
<div id="qq"><div></div></div>
</body>
</html>

<script language="vbscript">
	sub btnAdd_onclick()
		if form1.txtSubject.value="" then
			msgbox "יש להכניס נושא להודעה",vbCritical
		else
			'check text first to block illigle chars
			form1.txtSubject.value=checkText(form1.txtSubject.value)
			form1.txtMessage.value=checkText(form1.txtMessage.value)
			form1.btnAdd.disabled=true
			form1.submit
		end if
	end sub
</script>

<script language="vbscript">
'show real view of the message
	sub document_onkeyup()
		tText.innerHTML= showText(form1.txtSubject.value & " : " & form1.txtMessage.value)
		qq.innerHTML=AscB(mid(tText.innerHTML,len(tText.innerHTML),1)) & mid(tText.innerHTML,len(tText.innerHTML),1)
	end sub
</script>

<script language="vbscript">
'set the last input to add icons later
	dim lastTextBox
	sub document_onClick()
		if window.event.srcElement.tagName="INPUT" or _
		   window.event.srcElement.tagName="TEXTAREA" then 
			lastTextBox=window.event.srcElement.id
		end if
	end sub
</script>

<script language="vbscript">
sub openIconList()
	'create imgList and show the list
	dim iList,S
	iconList.innerHTML=""
	S=""
	for iList=11 to maxImage
		if iList=31 then s=s & "<br>"
		S=S & imgList(iList)
	next
	iconList.innerHtml=S
end sub
</script>

<script language="vbscript">
sub addIcon(i)
	dim s
	s="[" & i & "]"
	if lastTextBox="txtSubject" then form1.txtSubject.value=form1.txtSubject.value & S
	if lastTextBox="txtMessage" then form1.txtMessage.value=form1.txtMessage.value & S
end sub
</script>

<script language="vbscript">
	sub btnAddfile_onclick()
		form1.action="addMessageUpload.asp"
		form1.submit()
	end sub
</script>
