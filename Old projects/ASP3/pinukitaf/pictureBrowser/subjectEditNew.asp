<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
	tDay=1			'if new, will use this values
	tMonth=1
	tYear=2004
if Request.QueryString("new")="no" then
	key=Request.QueryString("key")+0
	conn=openDb(mdbFile)
	set rs=getRs()
	sql="select * from tblSubjects where iKey=" & key
	rs.open sql,conn
	name=rs("iName")
	text=rs("iText")
	tDate=rs("iDate")
	tDay=getDay(tDate)+0
	tMonth=getMonth(tDate)+0
	tYear=getYear(tDate)+0
	rs.close
	set rs=nothing
	set con=nothing
end if
%>
<html dir="rtl">
	<head>
		<title>Page title</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
	<LINK REL="stylesheet" TYPE="text/css" HREF=../Styles.css>
	</head>
	<body>
		<table align="center" width="600" ID="Table1">
			<tr>
				<td><a href="vbscript:window.history.back">חזרה</a></td>
				</TD>
			</tr>
		</table>
		<form id="form1" method="post" action=subjectAdd.asp>
			<table border="1" width="600" align="center" ID="Table2">
				<tr>
					<td>תאריך</td>
					<td>
						<SELECT ID="Select1" NAME="Select1">
							<%=placeYears(tYear)%>
						</SELECT>
						<SELECT ID="Select2" NAME="Select2">
							<%=placeMonth(tMonth)%>
						</SELECT>
						<SELECT ID="Select3" NAME="Select3">
							<%=placeDays(tDay)%>
						</SELECT>
					</td>
				</tr>
				<tr>
					<td>שם נושא</td>
					<td><INPUT type="text" ID="Text2" NAME="Text2" size="50" value="<%=name%>"></td>
				</tr>
				<tr>
					<td>תאור</td>
					<td><INPUT type="text" ID="Text3" NAME="Text3" size="50" value="<%=text%>"></td>
				</tr>
				<tr>
					<td></td>
					<td>
<%if Request.QueryString("new")="yes" then%>
					<INPUT id="Button1" type="button" value="אישור" name="Button1" onclick=buttonOk()>&nbsp&nbsp&nbsp
<%end if%>					
<%if Request.QueryString("new")="no" then%>
					<INPUT id="Button3" type="button" value="עדכן" name="Button1" onclick=buttonUpdate()>&nbsp&nbsp&nbsp
					<INPUT id="Button4" type="button" value="מחק" name="Button1" onclick=buttonDel()>&nbsp&nbsp&nbsp
<%end if%>					
					<INPUT id="Button2" type="button" value="ביטול" name="Button2" onclick=buttonCancel>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>

<script language=vbscript>
sub buttonOk()
	'check form
	formOk=true
	if form1.Text2.value="" then formOk=false
	if checkText(form1.Text2.value,txtAll)=false then formOk=false
	if checkText(form1.Text3.value,txtAll)=false then formOk=false
	if checkDate(form1.Select1.value,form1.Select2.value,form1.Select3.value)=false then formOk=false
	if formOk=true then
		form1.action="subjectAdd.asp"
		form1.submit
	else
		MsgBox "בעיה בטופס!",vbOKOnly
	end if
end sub

sub buttonUpdate()
	'check form
	formOk=true
	if form1.Text2.value="" then formOk=false
	if checkText(form1.Text2.value,txtAll)=false then formOk=false
	if checkText(form1.Text3.value,txtAll)=false then formOk=false
	if checkDate(form1.Select1.value,form1.Select2.value,form1.Select3.value)=false then formOk=false
	if formOk=true then
		form1.action="subjectUpdate.asp?key=<%=key%>"
		form1.submit
	else
		MsgBox "בעיה בטופס!",vbOKOnly
	end if
end sub

sub buttonDel()
	if MsgBox("האם בטוח שברצונך למחוק נושא",vbOKCancel)=vbOK then
		form1.action="subjectDel.asp?key=<%=key%>"
		form1.submit
	end if
end sub

sub buttonCancel()
	window.history.back
end sub
</script>
