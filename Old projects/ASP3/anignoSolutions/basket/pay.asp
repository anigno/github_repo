<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body background="../_images/<%=backgroundImage%>" bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>
<form id=formPay name=formPay method=post>
		<table background="../_images/<%=tableBackgroundImage%>" align="center" width="400" border="1" ID="Table1">
<%
	conn=openDB()
	set rs=getRS()
	'get basket for current userId
	sql="select * from tblBasket where iUserId=" & session("userId") & "  order by iTime DESC"
	rs.open sql,conn
%>		
	<tr>
		<td align=center colspan=4><font size=5>סל קניות</font></td>
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
		<td><font size=2><%=rs("iProductPrise")*rs("iProductCount")%>ש"ח</font></td>
		<td><a href=delProduct.asp?delKey=<%=rs("iKey")%>&return=2><font size=2>מחק</font></a></td>
	</tr>
<%
	rs.movenext
	wend
%>
	<tr>
		<td colspan=2><font size=2>סכ"ה:</font></td>
		<td colspan=2><font size=2><%=sum%>ש"ח</font></td>
	</tr>
			<tr><td colspan=4>&nbsp</td></tr>
			<tr>
			<td colspan=4 align=center><font size=4>פרטי המזמין</font></td>
			</tr>
			<tr>
			<td>מספר ת"ז</td><td><INPUT type="text" ID="txtId" NAME="txtId"></td>
			<td colspan=2><font size=1>9 ספרות</font></td>
			</tr>
			<tr>
			<td>סוג כרטיס</td>
			<td colspan=3>
			<SELECT ID="txtCreditType" NAME="txtCreditType">
				<OPTION selected value="ויזה כאל">ויזה כאל</OPTION>
				<OPTION value="ישרכארט">ישרכארט</OPTION>
				<OPTION value="לאומי ויזה">לאומי ויזה</OPTION>
				<OPTION value="דיינרס">דיינרס</OPTION>
				<OPTION value="אמריקן אקספרס">אמריקן אקספרס</OPTION>
			</SELECT></td>
			<tr>
			<td>מספר כרטיס האשראי</td><td><INPUT type=password ID="txtCreditcard" NAME="txtCreditcard"></td>
			<td colspan=2><font size=1>ללא רווחים או סימנים אחרים</font></td>
			</tr>
			<tr>
				<td>מספר תשלומים</td><td colspan=3>
				<select id=txtPays name=txtPays>
				<option selected value=1>1</option>
				<option value=3>3</option>
				<option value=6>6</option>
				<option value=9>9</option>
				<option value=12>12</option>
				<option value=18>18</option>
				<option value=24>24</option>
				</select>
				</td>
			</tr>
			<tr>
			<td>שם ושם משפחה</td><td colspan=3><INPUT type="text" ID="txtName" NAME="txtName"></td>
			</tr>
			<tr>
			<td>כתובת למשלוח</td><td colspan=3><INPUT type="text" ID="txtAddress" NAME="txtAddress"></td>
			</tr>
			<tr>
				<td colspan=2 align=center><INPUT type="button" value="אישור תשלום" ID="btnOk" NAME="btnOk">
				</td>
				<td colspan=2><font size=1>לחיצה על אישור התשלום מחייבת.</font></td>
			</tr>		
	</table>
</form> 
	</body>
</HTML>
<script language=vbscript>
	sub btnOk_onclick()
		'check the form
		error=0
		if checkText(formPay.txtCreditcard.value,txtOnlyNumbers)=0 then error=1
		if len(formPay.txtCreditcard.value)<10 then error=1
		if checkText(formPay.txtId.value,txtOnlyNumbers)=0 then error=1
		if len(formPay.txtId.value)<9 then error=1
		if len(formPay.txtName.value)<2 then error=1
		if len(formPay.txtAddress.value)<4 then error=1
		'must encrypt creditcard number
		if error=1 then
			MsgBox "טעות במילוי הטופס!",vbCritical
		else
			formPay.action="makePay.asp"
			if <%=sum%>>0 then formPay.submit
		end if
	end sub
</script>
