<%@ Language=VBScript %>
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body stylesrc="main.asp" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	forumId=Request.QueryString("forumId")
	iUsername=session("inbal_username")
	if iusername="" then
		Response.Write "תקלה, עליך להכנס שנית לאתר" & "<br>"
		Response.Write "<br>"
		Response.Write "<a href=main.asp>כניסה</a>" & "<br>"
		Response.End
	end if
	iParent=Request.QueryString("iparent")
	iSubject=Request.Form("txtSubject")
	iMessage=Request.Form("txtMessage")
	iRoot=Request.QueryString("iRoot")
	iFile=session("inbal_filename")
	
	session("inbal_file")=iFile
	session("inbal_username")=iUsername
	session("inbal_forumId")=forumId
	session("inbal_message")="_"
	session("inbal_subject")="_"

%>

<%
	'open DB
	dim mdbFile,sql,RS,RS1,RS2
	mdbFile="\db\inbalforum.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs1=Server.Createobject("ADODB.RecordSet")
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

<%
	Response.Write iFile
	iServer="www24.brinkster.com"
	'iServer="lala"
	iLink=""
	if iFile<>"" then
		'get filename and create alink
		fPos=InStrRev(iFile,"\")
		filename=mid(iFile,fPos+1)
		lFilename=filename
		iLink="<a href=http://" & iServer & "/inbalforum/db/" _
			& lFilename & "><font size=1 color=Green>" & Filename & "</font></a>"
	end if
%>

<%
	sql="insert into forumData (forumId,messageParent,txtSubject,txtMessage,adminShow,txtUsername,iDate,iTime,iRoot) values(" _	
	& forumId & "," _
	& iParent & "," _
	& "'" & iSubject & "'," _
	& "'" & iMessage & " " & iLink _
	& "'," _
	& "'" & "1" & "'," _
	& "'" & iUsername & "'," _
	& "'" & DateSerial(year(date),month(date),iDay) & "'," _
	& "'" & TimeSerial(iHour,minute(time),second(time)) & "'," _
	& iRoot & ")"
	Response.Write sql
	RS1.Open sql,conn
	Response.Redirect "forumShow.asp?forumId=" & forumId
	
%>
</body>
</html>
<%
	Set Conn = Nothing
%>