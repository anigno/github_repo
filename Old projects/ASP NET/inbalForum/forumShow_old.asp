<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<%
	'recieve forumId and pageNumber(if redirect itself for page #)
	'display the selected forum
%>
<html>
<head>
<meta http-equiv="Refresh" content="60;#">
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">

</head>
<body dir="rtl" stylesrc="main.asp" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	dim iUsername,forumId
	forumId=Request.QueryString("forumId")
	pageNumber=Request.QueryString("pageNumber")
	iUsername=session("inbal_username")
	session("inbal_username")=iUsername
	session.Timeout=30
%>	

<%
	dim conn,rs,rs1,rs2,SQL
	conn=opendb()
	set rs=getrs()
	set rs1=getrs()
	set rs2=getrs()
%>

<%
	'get forum's name and description
	sql="select * from forums where key=" & forumId
	rs1.Open sql,conn
%>
<table>
<tr>
<td><%=rs1("forumName")%> - </td><td><%=rs1("forumDescription")%></td>
</tr><tr><td colspan="2"><%=iUsername%></td></tr>
</table>

<table border="1" width="90%">
<tr><td>
<a href="addMessage.asp?forumId=<%=forumId%>&amp;iParent=0&amp;iRoot=0">
<font color="PaleVioletRed" size="2">הוסף הודעה חדשה</font></td>
<td colspan="1"><a href="forums.asp?iUsername=<%=iUsername%>">
<font color="PaleVioletRed" size="2">חזרה לעמוד הפורומים</font></td>
<td>.</td><td>.</td></tr>
<tr><td width="60%">.</td><td width="20%">.</td><td width="10%">.</td><td width="10%">.</td></tr>



<%
'get all forumId messages, order by date and time
sql="select * from forumData  where forumId=" & forumId & " order by iDate DESC,itime DESC"
RS2.Open sql,conn

dim b:b=1
dim c:c=1
dim tShowKey	'if the iRoot=0 then message should be shown by it's own key
dim s1:s1=""	'used to collect shown iRoots, to prevent from showing again the same iRoot
dim maxInPage:maxInPage=20
dim messageCnt	'to use with showText(Text)
messageCnt=0



'move to page pageNumber
while c<=maxInPage*(pageNumber) and not RS2.EOF
	c=c+1
	RS2.MoveNext
wend

'show messages by iRoot
while b<=maxInPage and not RS2.EOF
	tShowKey=rs2("iRoot")	'this will take the root of the message to start and show from
	'check if message is root (iRoot=0)
	if tShowKey=0 then
		'message is root
		tShowKey=rs2("key")	'set to show by the key not the iRoot (=0)
		b=b+1	'to count only roots
	end if
	'will check for more then one of the same message
	if instr(1,s1,tShowKey)=0 then	
		showLeaf tShowKey
		'will add to already show list
		s1=s1 & " " & tShowKey
	end if	
	RS2.MoveNext
wend
%>


<%
	'show all messages tree from a givven key
	dim iDepth
	iDepth=0
	sub showLeaf(iKey)
		dim rs
		set rs=Server.Createobject("ADODB.RecordSet")
		sql="select * from forumData where forumId=" & forumId _
			& " and key=" & iKey
		rs.Open sql,conn
		if not rs.eof then 
			messageCnt=messageCnt+1
			showMessage(rs)
			iDepth=iDepth+1			
		end if
		rs.close
		sql="select * from forumData where forumId=" & forumId _
			& " and messageParent=" & iKey
		rs.Open sql,conn
		do
				if not rs.eof then 
					showLeaf rs("key")
					rs.MoveNext			
				end if
		loop until rs.EOF
		iDepth=iDepth-1
	end sub


	sub showMessage(rs)
		if rs("iRoot")=0 then
			iRoot=rs("key")
		else
			iRoot=rs("iRoot")
		end if
%>
		<tr><td><a title="<%=RS("txtMessage")%>" href="showMessage.asp?key=<%=rs("key")%>&amp;forumId=<%=forumId%>&amp;iRoot=<%=iRoot%>">
		<%
		if iDepth=0 then 
			Response.Write "<font size=3>" & "<div id=messageid" & messageCnt & ">" & placeSpace2(iDepth)& rs("txtSubject") & "</div></font>"
		else
			Response.Write "<font size=2>" & "<div id=messageid" & messageCnt & ">" & placeSpace2(iDepth)& rs("txtSubject") & "</div></font>"
		end if			
		%>
		</a></td>
		<td><div id="userId" onClick="submitForm()"><u><%=rs("txtUsername")%></u></font></div></td>
		<td><font size="1"><%=RS("iDate")%></font></td><td><font size="1"><%=RS("iTime")%></font></td></tr>
<%
	end sub
%>

</table>
עבור לעמוד<br>
<%
	dim a
	for a=0 to 10
%>
<a href="forumShow.asp?forumId=<%=forumId%>&amp;pageNumber=<%=a%>">
<font size="2"><%=a%></font>
</a>
<%
	next
%>
<div id="qq"></div>
<form id="form1" name="form1" action="showUser.asp" method="post">
<!--hidden input for requested username-->
<input border="0" id="txtUsername" name="txtUsername" style="BACKGROUND-COLOR: #fefff6; BORDER-BOTTOM-COLOR: #fefff6; BORDER-BOTTOM-STYLE: none; BORDER-LEFT: 0px; BORDER-RIGHT: 0px; BORDER-TOP: 0px; COLOR: #fefff6">
</form>
</body>
</html>

<script language="vbscript">
	sub btnAddMessage_onclick()
		window.navigate "addMessage.asp?iParent=0&"
	end sub
	sub btnBackToForums_onclick()
		window.history.back
	end sub
</script>




<script language="vbscript">
'script to add animate-icons to input as [xx]
'must place:
'	<a href="#" onclick="openIconList()">icons</a>
'	<div id=iconList></div>
'must change:
'	sub addIcon()
'must use:
'	function showText(iText)	will return text with real images

	'change input names
	sub addIcon(a)
		'will add [xx] to text
		if lastTextBox="txtSubject" then
			form1.txtSubject.value= _
				form1.txtSubject.value & "[" & a & "]"
			form1.txtSubject.focus
		end if
	end sub



	'generic
	'set the last input to add icons later
	dim lastTextBox
	sub document_onClick()
		if window.event.srcElement.tagName="INPUT" then 
			lastTextBox=window.event.srcElement.id
		end if

	end sub
</script>


<script language="vbscript">
	'invissible text bpx to transfer requested username to show details
	'	(because of spaces problem)
	sub document_onmousedown()
			form1.txtUsername.value= window.event.srcElement.innerhtml
	end sub

	sub submitForm()
		form1.submit()
	end sub


</script>

<%
	'run showText(Text) on all messages in page
	dim t
	for t=1 to messageCnt
	Response.Write "<script language=vbscript>" & chr(13)
		Response.Write "messageid" & t & ".innerhtml=showtext(messageid" & t & ".innerhtml)" & chr(13)
	Response.Write "</script>" & chr(13)
	next
%>

<%
	function placeSpace2(i)
		placeSpace2=placeSpace(i,"....")
	end function
%>



<%
	Set Conn = Nothing
%>
