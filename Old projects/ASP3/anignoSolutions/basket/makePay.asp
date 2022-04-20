<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir=rtl>
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
<%
	'get data from payDetails.asp
	userIdNumber=Request.Form("txtId")
	creditType=Request.Form("txtCreditType")
	creditcard=Request.Form("txtCreditcard")
	pays=request.Form("txtPays")
	username=Request.Form("txtName")
	userAddress=Request.Form("txtAddress")
	'get other data
	userSessionId=session("userId")
%>
	<body>
בקשה נקלטה במערכת החנות.
<table border=1>
<tr>
<td>מוצר</td><td>יחידות</td><td>מחיר ליח'</td>
</tr>
<%
	conn=openDB()
	set rs=getRS()
	'get user products from tblBasket, put data in tblOrders
	sql="select * from tblBasket where iUserId=" & userSessionId
	rs.open sql,conn
	dim sum
	dim orderNumber
	sum=0
	while not rs.eof
		set rs2=getRS()
		sql="insert into tblOrders (iUserIdNumber,iCreditType,iCreditcard,iPays,iUsername,iUserAddress,iProductKey,iProductCount,iProductPrise) values("
		sql=sql & "'" & userIdNumber & "',"
		sql=sql & "'" & creditType & "',"
		sql=sql & creditcard & ","
		sql=sql & pays & ","
		sql=sql & "'" & username & "',"
		sql=sql & "'" & userAddress & "',"
		sql=sql & rs("iProductKey") & ","
		sql=sql & rs("iProductCount") & ","
		sql=sql & rs("iProductPrise") & ")"
		rs2.open sql,conn
		sum=sum + rs("iProductPrise") * rs("iProductCount")
%>
<tr>
<td><%=rs("iProductName")%></td><td><%=rs("iProductCount")%></td><td><%=rs("iProductPrise")%></td>
</tr>

<%		
		rs.movenext
	wend
%>
	<tr>
	<td colspan=2>סכ"ה לתשלום</td><td><%=sum%></td>
	</tr>
<%
	'get order number from tblOrders.iKey
	set rs3=getRs
	sql="select * from tblOrders where iUserIdNumber='" & userIdNumber & "' order by iDate DESC"
	rs3.open sql,conn
	if not rs3.eof then orderNumber=rs3("iKey")	
%>	
		
		</table>
		<p></p>
<table border=1>
	<tr>
	<td><%=userIdNumber%></td><td><%=username%></td>
	</tr>
		<tr>
	<td colspan=2><%=userAddress%></td>
	</tr>
	<tr>
	<td><%=creditType%></td><td>מס' תשלומים:<%=pays%></td>
	</tr>
	<tr>
	<td colspan=2>מספר כרטיס האשראי לא מוצג.</td><td></td>
	</tr>
	<tr>
	<td>מספר הזמנה:</td><td><%=orderNumber%></td>
	</tr>
	<tr>
	<td colspan=2>&nbsp</td>
	</tr>
	<tr>
	<td colspan=2>מומלץ להדפיס דף זה</td>
	</tr>
</table>	
<p align=center><font size=5><a href=../main/firstPage.asp>חזרה לחנות</a></font></p>
	</body>
<%
	set rs4=getRS()
	sql="delete from tblBasket where iUserId=" & session("userId")
	rs4.open sql,conn
%></HTML>
