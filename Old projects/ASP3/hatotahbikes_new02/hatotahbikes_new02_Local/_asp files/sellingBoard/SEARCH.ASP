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
<a href="index.asp">����</a>
<table border="1" width="100%">
<tr>
<td>���</td>
<td>����</td>
<td>���</td>
<td>���</td>
<td>���</td>
<td>��</td>
<td>����</td>
<td>���� ����</td>
<td>���� ������</td>
<td>��</td>
<td>�����</td>
<td>�����</td>
</tr>
<%
dim sManuf(100),iNumber
dim tDescription,tName
iNumber=0+1

sManuf(28)="B.S.A"
sManuf(1)="�����'�"
sManuf(2)="������"
sManuf(3)="�������"
sManuf(4)="�.�.��"
sManuf(5)="���"
sManuf(6)="�'����"
sManuf(7)="������"
sManuf(8)="������"
sManuf(26)="����"
sManuf(9)="�����"
sManuf(27)="������"
sManuf(10)="���������"
sManuf(11)="���� ���������"
sManuf(32)="�����"
sManuf(12)="�����"
sManuf(13)="�����"
sManuf(15)="�.�"
sManuf(29)="���� ������"
sManuf(14)="��������"
sManuf(24)="�������"
sManuf(34)="������"
sManuf(16)="��� ����"
sManuf(17)="������"
sManuf(33)="��.��.��"
sManuf(25)="��.�'�.��"
sManuf(19)="����'�"
sManuf(18)="���'�"
sManuf(22)="�.�.�"
sManuf(20)="���'���"
sManuf(21)="���������"
sManuf(23)="�����"
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
<a href="index.asp">����</a>
</body>
</html>
