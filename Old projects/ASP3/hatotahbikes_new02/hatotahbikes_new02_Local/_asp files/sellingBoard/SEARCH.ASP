<!--#INCLUDE FILE="functions.asp" -->
<html>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
<head>
<body dir="rtl" stylesrc="../data.htm" background="../../bg01.jpg" text="#440000" link="#800000" vlink="#800000" alink="#CC0000">

<%
	conn=openDB()
	set rs=getRs()
	sql="select * from tblSell order by iDate DESC,iSize ASC,iType ASC "
	'Response.Write sql
	'Response.End
	rs.open sql,conn
%>
<a href="index.asp">חזרה</a>
<table border="1" width="100%">
<tr>
<td>סוג</td>
<td>יצרן</td>
<td>נפח</td>
<td>דגם</td>
<td>שנה</td>
<td>יד</td>
<td>מחיר</td>
<td>תאור כללי</td>
<td>אזור מגורים</td>
<td>שם</td>
<td>טלפון</td>
<td>תאריך</td>
</tr>
<%
dim sManuf(100),iNumber
dim tDescription,tName
iNumber=0+1

sManuf(28)="B.S.A"
sManuf(1)="איטלג'ט"
sManuf(2)="אנפילד"
sManuf(3)="אפריליה"
sManuf(4)="ב.מ.וו"
sManuf(5)="בטה"
sManuf(6)="ג'ילרה"
sManuf(7)="דוקאטי"
sManuf(8)="דיאלים"
sManuf(26)="דרבי"
sManuf(9)="הונדה"
sManuf(27)="הוסברג"
sManuf(10)="הוסקוורנה"
sManuf(11)="הרלי דיווידסון"
sManuf(32)="טריום"
sManuf(12)="יאווה"
sManuf(13)="ימאהה"
sManuf(15)="מ.ז"
sManuf(29)="מוטו מורינו"
sManuf(14)="מוטוגוצי"
sManuf(24)="מלאגוטי"
sManuf(34)="נורטון"
sManuf(16)="סאן יאנג"
sManuf(17)="סוזוקי"
sManuf(33)="סי.פי.אי"
sManuf(25)="פי.ג'י.או"
sManuf(19)="פיאג'ו"
sManuf(18)="פיג'ו"
sManuf(22)="ק.ט.מ"
sManuf(20)="קאג'יבה"
sManuf(21)="קאוואסאקי"
sManuf(23)="קימקו"
%>
<%
dim isDoubleData
while not rs.EOF
	isDoubleData=0
	if tDescription=rs("iDescription") and tName=rs("iName") then isDoubleData=1
	if rs("iDate")<now()-120 then isDoubleData=1
	if isDoubleData=0 then
%>
<tr>
<td><font size="2"><%=rs("iType")%></td>
<%iNumber=rs("iManuf")%>
<td><font size="2"><%=sManuf(iNumber)%></td>
<td><font size="2"><%=rs("iSize")%></td>
<td><font size="2"><%=left(rs("iModel"),15)%></td>
<td><font size="2"><%=rs("iYear")%></td>
<td><font size="2"><%=rs("iHand")%></td>
<td><font size="2">&nbsp;<%=rs("iPrise")%></td>
<td><font size="2">&nbsp;<%=rs("iDescription")%></td>
<td><font size="2"><%=rs("iRegion")%></td>
<td><font size="2"><%=rs("iName")%></td>
<td><font size="2"><%=rs("iPhone")%></td>
<td><font size="2"><%=rs("iDate")%></td>
</tr>
<%
	tDescription=rs("iDescription")
	tName=rs("iName")
	end if
rs.movenext
wend
%>
</table>
<%
set rs=nothing
%>
<a href="index.asp">חזרה</a>
</body>
</html>
