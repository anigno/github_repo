<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
<%
	'if key="-1" then new item
	key=Request.QueryString("key")
	dim header,text,subject,showAll,iDate
	iDate=now()
	if key<>"-1" then
		conn=openDB("bloger.mdb")
		set rs=getRS()
		sql="select * from tblText where iKey=" & key
		rs.open sql,conn
		header=rs("iHeader")
		text=rs("iText")
		subject=rs("iSubjectNumber")
		showAll=rs("iShowToAll")
		iDate=rs("iDate")
		picture=rs("iPicture")
	end if
%>
	</HEAD>
	<body>
		<form id=form1 name=form1 method=post enctype="multipart/form-data">
		<table border="1" align="center" ID="Table1">
			<tr>
				<td colspan=2 align=center><%=iDate%>
				</td>
			</tr>
			<tr>
				<td>נושא:</td>
				<td><SELECT id="txtSubject" name="txtSubject">
<%for a=0 to ubound(textSubject)%>
					<OPTION <%if a=subject then Response.Write " selected "%> value=<%=a%>><%=textSubject(a)%></OPTION>
<%next%>					
					</SELECT></td>
			</tr>
			<tr>
				<td>כותרת:</td>
				<td><input type=text id=txtHeader name=txtHeader size=40 value="<%=header%>"></td>
			</tr>
			<tr>
				<td colspan=2><TEXTAREA onkeypress="updateCols()" rows=5 cols=40 id=txtText name=txtText><%=text%></TEXTAREA></td>
			</tr>
<%if picture<>"" then%>
			<tr><td colspan=2><img src="../../db/_files/<%=(rs("iPicture"))%>"></td></tr>
<%end if%>			
			
			<tr>
				<td colspan=2>עדכון תמונה:<INPUT type="file" ID="file1" NAME="file1">
				</td>
			</tr>
			<tr>
				<td colspan=2>האם להציג לכלל הגולשים <INPUT type="checkbox" ID="showAll" NAME="showAll"></td>
			</tr>
			<tr>
				<td align=center colspan=2>
					<INPUT type="button" value="אישור" ID="btnOK" NAME="btnOK">&nbsp&nbsp&nbsp&nbsp
					<input type="button" value="ביטול" id="btnCancel" name="btnCancel">
				</td>
			</tr>
		</table>
		</form>
	</body>
</HTML>
<script language=vbscript>
	sub btnOK_onClick()
		'check form
		errorInForm=0
		if form1.txtHeader.value="" then
			errorInForm=1
			MsgBox "יש לרשום כותרת מזהה",vbCritical
		else
		'submit form
		form1.btnOK.value="מעדכן"
		form1.btnOK.disabled=true 
		form1.action="addText01.asp?key=<%=key%>"
		form1.submit
		end if
	end sub

	sub btnCancel_onClick()
		window.history.back
	end sub
	
	form1.txtText.rows=form1.txtText.scrollHeight /20 +5
	sub updateCols()
		form1.txtText.rows=form1.txtText.scrollHeight /20 +5
	end sub
	
</script>
