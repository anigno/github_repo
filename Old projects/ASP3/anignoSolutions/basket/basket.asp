<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body background="../_images/<%=backgroundImage%>" bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>
		<table background="../_images/<%=tableBackgroundImage%>" align="center" width="200" border="1" ID="Table1">
<%
	conn=openDB()
	set rs=getRS()
	'get basket for current userId
	sql="select * from tblBasket where iUserId=" & session("userId") & "  order by iTime DESC"
	rs.open sql,conn
%>		
	<tr>
	<td colspan=3 align=center><font size=1><%=Session("userId")%></font></td>
	</tr>
	<tr>
		<td align=center><font size=2>סל קניות</font></td>
		<td colspan=2><INPUT type="button" value="ביצוע" ID="btnPay" NAME="btnPay"></td>
	</tr>
<%
dim sum
sum=0
while not rs.eof
sum=sum+rs("iProductPrise")*rs("iProductCount")
%>
	<tr>
		<td><font size=2><%=rs("iProductName")%></font></td>
		<td><font size=2><%=rs("iProductCount")%></font></td>
		<td><a href=delProduct.asp?delKey=<%=rs("iKey")%>><font size=2>מחק</font></a></td>
	</tr>
<%
	rs.movenext
	wend
%>
<tr>
	<td align=center><font size=2>סכ"ה:</font></td>
	<td colspan=2><font size=2><%=sum%></font></td>
</tr>
	</table>
	</body>
</HTML>

<script language=vbscript>
	sub btnPay_onclick()
		<%if sum>0 then%>
			window.parent.parent.frames(1).location="pay.asp"
		<%end if%>
	end sub
</script>