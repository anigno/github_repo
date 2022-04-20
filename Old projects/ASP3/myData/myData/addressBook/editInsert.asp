<%@ Language=VBScript Codepage=1255 %>
<HTML dir="rtl">
	<HEAD>
		<title>addressBook</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
</HEAD>
	<body>
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
	'getting data from show.asp
	'if key=-1 then insert new, else edit record with key
	key=Request.QueryString("key")
	'check for key, to get data for this record to edit
	if key<>"-1" then
		'get record with key, no username needed, key is unique
		sql="select * from tblData where iKey=" & key
		set rs=Server.Createobject("ADODB.RecordSet")
		rs.Open sql,conn
		'check for record for username
		if not rs.EOF then
			familyName=rs("iFamily")
			privateName=rs("iPrivate")
			address=rs("iAddress")
			phone1=rs("iPhone1")
			phone2=rs("iPhone2")
			email1=rs("iEmail1")
			email2=rs("iEmail2")
			group=rs("iGroup")
			text=rs("iText")
		end if
	end if
%>
		<form id="formEditInsert" name="formEditInsert" method="post">
			<%=Session("username")%>
			<table width="300">
				<tr>
					<td>
						קבוצה:
					</td>
					<td>
						<SELECT ID="selectGroup" NAME="selectGroup">
							<OPTION <%if group=1 then Response.Write(" selected ")%>value="1">משפחה</OPTION>
							<OPTION <%if group=2 then Response.Write(" selected ")%>value="2">חברים</OPTION>
							<OPTION <%if group=3 then Response.Write(" selected ")%>value="3">עבודה</OPTION>
							<OPTION <%if group=4 then Response.Write(" selected ")%>value="4">לימודים</OPTION>
						</SELECT>
					</td>
				</tr>
				<tr>
					<td>שם משפחה</td>
					<td><INPUT size=30 type="text" ID="txtFamily" NAME="txtFamily" value="<%=familyName%>"></td>
				</tr>
				<tr>
					<td>שם פרטי</td>
					<td><INPUT size=30 type="text" ID="txtPrivate" NAME="txtPrivate" value="<%=privateName%>"></td>
				</tr>
				<tr>
					<td>טלפון 1</td>
					<td align="right" dir="ltr"><INPUT size=30 type="text" ID="txtPhone1" NAME="txtPhone1" value="<%=phone1%>"></td>
				</tr>
				<tr>
					<td>טלפון 2</td>
					<td align="right" dir="ltr"><INPUT size=30 type="text" ID="txtPhone2" NAME="txtPhone2" value="<%=phone2%>"></td>
				</tr>
				<tr>
					<td>דוא"ל 1</td>
					<td align="right" dir="ltr"><INPUT size=50 type="text" ID="txtEmail1" NAME="txtEmail1" value="<%=email1%>"></td>
				</tr>
				<tr>
					<td>דוא"ל 2</td>
					<td align="right" dir="ltr"><INPUT size=50 type="text" ID="txtEmail2" NAME="txtEmail2" value="<%=email2%>"></td>
				</tr>
				<tr>
					<td>כתובת</td>
					<td><INPUT size=50 type="text" ID="txtAddress" NAME="txtAddress" value="<%=address%>"></td>
				</tr>
				<tr>
					<td>הערות</td>
					<td><INPUT size=50 type="text" ID="txtText" NAME="txtText" value="<%=text%>"></td>
				</tr>
				<tr>
					<td><INPUT type="button" value="עדכן/הוסף" ID="btnOk" NAME="btnOk"></td>
					<td><INPUT type="button" value="ביטול" ID="btnCancel" NAME="btnCancel"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
<script language="vbscript">
private sub btnOk_onClick()
	formEditInsert.action="editInsert01.asp?key=<%=key%>"
	formEditInsert.submit
end sub
private sub btnCancel_onClick()
	window.history.back()
end sub
</script>
