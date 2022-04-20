<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<html dir=rtl>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
	<LINK REL="stylesheet" TYPE="text/css" HREF=Styles.css>
	<title>Page title</title>
</head>
<%
conn1=openDb(generalFile)
set rs1=getRs()
sql="select * from tblGeneral"
rs1.open sql,conn1
weekSubject=rs1("iData")
rs1.close
set rs1=nothing
set conn1=nothing
%>
<body background=<%=picturesPath%>people.gif>
<p align=center>
<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0" width="600" height="200" id="pinukitaf_main" align="middle" VIEWASTEXT>
<param name="allowScriptAccess" value="sameDomain" />
<param name="movie" value="pinukitaf_main.swf?weekSubject=<%=weekSubject%>" />
<param name="quality" value="high" />
<param name="wmode" value="transparent" />
<param name="bgcolor" value="#333333" />
<embed src="pinukitaf_main.swf" quality="high" wmode="transparent" bgcolor="#333333" width="600" height="200" name="pinukitaf_main" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
</object>
</p>

<table align=center width=600 ID="Table2" border=1>
<tr>
<td colspan=2 align=center><font size=5>לוח הודעות</font></td>
</tr>
<%
conn=openDb(addFile)
set rs=getRs()
sql="select * from tblMessages order by iDate DESC"
rs.open sql,conn
%>
<%while not rs.eof%>
<tr>
<%
theDate=rs("iDate")
d=getDay(theDate)
m=getMonth(theDate)
y=getYear(theDate)
%>
<td><%=d & "/" & m & "/" & y%></td><td><%=rs("iText")%></td>
</tr>
<%rs.moveNext%>
<%wend%>
<tr><td colspan=2><img src=<%=picturesPath%>pulser.gif width=600 height=1></td></tr>
</table>
<br><br><br>
<a href=admin.asp><font size=1 color=#003399>anigno</font></a><br><br><br>
<font size=1>
</font>
</body>
</html>
<%
rs.close
set conn=nothing
set rs=nothing
%>