<!--#INCLUDE FILE="functions.asp" -->
<html>
<head>
</head>
<body dir="rtl" stylesrc="../data.htm" background="../../bg01.jpg" text="#440000" link="#800000" vlink="#800000" alink="#CC0000">
<%iSubjectKey=Request.QueryString("iKey")
	dim conn,rs1,rs2,sql
	dim imageWidth,imageHeight
	conn=openDB()
	set rs1=getRS()
	set rs2=getRS()
%>

<%
	'get Subject from iSubjectKey
	sql="select * from tblSubjects where iKey=" & iSubjectKey 
	rs1.open sql,conn
%>
<%
	'get all product by subject
	sql="select * from tblProducts_Query where iSubject=" _
		& "'" & rs1("iKey") & "'"
	rs2.open sql,conn
%>

<p align="center"><font size="5"><%=rs1("iSubject")%></font></p>
<table border="1" align="center" dir="rtl">
<tr><td>תאור המוצר</td><td>תמונה</td><td>מחיר</td></tr>
<%while not rs2.eof%>
<tr>
<td><%=rs2("iProduct")%></td>
<td><img src="images\<%=rs2("iImagefile")%>" title="<%=rs2("iImagefile")%>"></td>
<td><%=rs2("iPrise")%> ש&quot;ח</td>
</tr>
<%rs2.movenext%>
<%wend%>
</table>
<p align="center"><a href="showSubjects.asp"><font size="4">חזרה לעמוד קודם</font></a></p>
<%
	set rs1=nothing
	set rs2=nothing
%>
</body>
</html>
