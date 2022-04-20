<%@ Language=VBScript Codepage=1255 %>
<HTML dir="rtl">
	<HEAD>
		<title>AddressBook</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
</HEAD>
	<body alink=Red>
		<%
	'get username from session
	username=Session("username")
%>
		<%
	'get data from recall
	group=Request.QueryString("group")	'which group to show this call
	if group="" then group=0
%>
		<%
	'open DB
	dim mdbFile,sql,RS,RS1,RS2
	mdbFile="/DB/addressBook.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
%>
		<%
	set rs=Server.Createobject("ADODB.RecordSet")
	if group=0 then
		sql="select * from tblData where iUsername='" & username & "' order by iFamily"
	else
		sql="select * from tblData where iUsername='" & username & "' and iGroup=" & group & " order by iFamily"
	end if
	rs.Open sql,conn
%>
		<table width="300">
			<tr>
				<td>פנקס כתובות</td>
				<td><%=username%></td>
				<td></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td>
					<SELECT ID="selectGroup" NAME="selectGroup">
						<OPTION selected value="0">כללי</OPTION>
						<OPTION value="1">משפחה</OPTION>
						<OPTION value="2">חברים</OPTION>
						<OPTION value="3">עבודה</OPTION>
						<OPTION value="4">לימודים</OPTION>
					</SELECT>
					<script language="vbscript">
						'change selectedGroup to show current group
						group="<%=group%>"
						selectGroup.selectedIndex=group
					</script>
				</td>
				<td><A href="editInsert.asp?key=-1">הוספה</A></td>
			</tr>
		</table>
		<table width="100%" border="1">
			<tr>
				<td width=3%>-</td>
				<td width=10%>משפחה</td>
				<td width=10%>פרטי</td>
				<td width=13%>טלפון</td>
				<td width=24%>דוא"ל</td>
				<td width=20%>כתובת</td>
				<td width=20%>הערות</td>
			</tr>
			<%
	while not rs.EOF
%>
			<tr>
				<td>
				<a href=editInsert.asp?key=<%=rs("iKey")%>><font size=2>ערוך</font></a><br>
				<a id="delRecord<%=rs("iKey")%>" href=# 
					onclick="delRecord(<%=rs("iKey")%>)"><font size=2>מחק</font></a>
				</td>
				<td><%=rs("iFamily")%>&nbsp;</td>
				<td><%=rs("iPrivate")%>&nbsp;</td>
				<td><%=rs("iPhone1")%>&nbsp;<br>
					<%=rs("iPhone2")%>
				</td>
				<td>
					<a href=mailto:<%=rs("iEmail1")%>><font size=2><%=rs("iEmail1")%>&nbsp;</font></a>
				<br>
					<a href=mailto:<%=rs("iEmail2")%>><font size=2><%=rs("iEmail2")%></font></a>
				</td>
				<td><font size="1"><%=rs("iAddress")%>&nbsp;</font></td>
				<td><font size="1"><%=rs("iText")%>&nbsp;</font></td>
			</tr>
			<%
	rs.MoveNext()
	wend
	rs.close
%>
		</table>
	</body>
</HTML>
<script language="vbscript">
	private sub selectGroup_onChange()
		window.location="show.asp?group=" & selectGroup.options(selectGroup.selectedIndex).value
	end sub
	private sub delRecord(k)
		answer=MsgBox("למחוק רשומה?",vbYesNo)
		if answer=vbYes then
			window.location="delRecord.asp?key=" & k & "&group=<%=group%>"
		end if
	end sub
</script>
