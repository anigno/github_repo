<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">

</HEAD>
<BODY>
<%
	dim mdbFile,connString,conn,rs,sql
	'open DB
	mdbFile="..\db\dataManager.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")

	Response.Write "Wellcome " & Session("userName") & "<BR>"
%>

<%
	sql="select * from tblData where userName='" & Session("userName") & "'"
	'open recordSet with move backwards for rs full functionality
	rs.Open sql,conn,1 
%>
	<script language=vbscript>
		'set Vars for data
		dim dataType(100)
		dim subject(100),aData(100)
		dim aName(100),aAddress(100),aPhone1(100),aPhone2(100),aEmail(100)
		dim maxRecords
	</script>
<%
	'check for no data with EOF
	if rs.RecordCount>1 then
		'putting data from DB to script arrays
		rs.MoveFirst
		b=0:c=0
		for a=0 to rs.RecordCount-1
			Response.Write "<script language=vbscript>" & chr(13)
			'check if dataType is "address" or "general"
			if rs("dataType")="address" then
				Response.Write "aName(" & b & ")=" & chr(34) & rs("subject") & chr(34) & chr(13)
				Response.Write "aAddress(" & b & ")=" & chr(34) & rs("aAddress") & chr(34) & chr(13)
				Response.Write "aPhone1(" & b & ")=" & chr(34) & rs("aPhone1") & chr(34) & chr(13)
				Response.Write "aPhone2(" & b & ")=" & chr(34) & rs("aPhone2") & chr(34) & chr(13)
				Response.Write "aEmail(" & b & ")=" & chr(34) & rs("aEmail") & chr(34) & chr(13)
				b=b+1
			else
				Response.Write "subject(" & c & ")=" & chr(34) & rs("subject") & chr(34) & chr(13)
				Response.Write "aData(" & c & ")=" & chr(34) & rs("aData") & chr(34) & chr(13)
				c=c+1
			end if
			Response.Write "</script>" & chr(13)
			rs.MoveNext
		next 'next a
		rs.MoveFirst
	end if
%>




	<table  border=2><tr><td>
	ADRESSES:<BR>
	<SELECT size=10 id=selectAddress name=selectAddress
		style="WIDTH: 150px" >
<%
	if rs.RecordCount>0 then
		'fill select listbox with subjects (name)
		for a=0 to rs.RecordCount-1
		if rs("dataType")="address" then
			Response.Write "<option>" & rs("subject") & "</option>"
		end if
		rs.MoveNext
		next
%>
	</SELECT>
	</td><td>
	GENERAL:<BR>
	<SELECT size=10 id=selectData name=selectData
		style="WIDTH: 150px">
<%
		'fill select listbox with subjects
		rs.MoveFirst
		for a=0 to rs.RecordCount-1
		if rs("dataType")="general" then
			Response.Write "<option>" & rs("subject") & "</option>"
		end if
		rs.MoveNext
		next
	end if	
%>
</SELECT>
</td>
<form id=form1 name=form1 method=post>
<td>
<INPUT type="button" value="update" id=btnUpdate name=btnUpdate style=" WIDTH: 60px"><BR>
<INPUT type="button" value="delete" id=btnDelete name=btnDelete style=" WIDTH: 60px"><BR>
<INPUT type="button" value=" new " id=btnNew name=btnNew style=" WIDTH: 60px"><BR><BR>
<INPUT type="button" value="log off" id=btnLogoff name=btnLogoff style=" WIDTH: 60px"><BR>

	<tr><td>
	subject/name<BR>
	<INPUT type="text" id=txtSubject name=txtSubject readonly><BR>
	Address<BR>
	<INPUT type="text" id=txtAddress name=txtAddress><BR>
	Phone1<BR>
	<INPUT type="text" id=txtPhone1 name=txtPhone1><BR>
	Phone2<BR>
	<INPUT type="text" id=txtPhone2 name=txtPhone2><BR>
	Email<BR>
	<INPUT type="text" id=txtEmail name=txtEmail><BR>
	</td>
	<td>
	Data<br>
	<TEXTAREA rows=9 cols=30 id=txtData name=txtData>
	</TEXTAREA>	
	</td>
	</tr>
</form>
</table>



<script language=vbscript>
	'auto refresh
	
	'update data when clicked
	sub selectAddress_onClick()
		selectData.selectedIndex=101
		form1.txtSubject.value=aName(selectAddress.selectedIndex)
		form1.txtAddress.value=aAddress(selectAddress.selectedIndex)
		form1.txtPhone1.value=aPhone1(selectAddress.selectedIndex)
		form1.txtPhone2.value=aPhone2(selectAddress.selectedIndex)
		form1.txtEmail.value=aEmail(selectAddress.selectedIndex)
		form1.txtData.value=""
	end sub
	'update data when clicked
	sub selectData_onClick()
		selectAddress.selectedIndex=101
		form1.txtSubject.value=subject(selectData.selectedIndex)
		form1.txtAddress.value=""
		form1.txtPhone1.value=""
		form1.txtPhone2.value=""
		form1.txtEmail.value=""
		'convert aData from protected value to regular
		temp=aData(selectData.selectedIndex)
			temp2=""
			for a=1 to len(temp)
				temp2=temp2 & chr((asc(mid(temp,a,1))-96))
			next
		form1.txtData.value=temp2
	end sub
	'procedures to update data when changing selection 
	' with keyboard arrows
	sub selectAddress_onKeyup()
		selectAddress_onClick
	end sub
	sub selectData_onKeyup()
		selectData_onClick
		selectData_onClick
	end sub
	
	sub btnUpdate_onClick()
		'use both methods to transfer data
		form1.submit
		window.navigate "update.asp"
	end sub

	sub btnLogoff_onClick()
		window.navigate "logoff.asp"
	end sub

	sub btnDelete_onClick()
		form1.submit
		window.navigate "delete.asp"
	end sub

	sub btnNew_onClick()
		window.navigate "addNew01.asp"
	end sub
</script>

</BODY>
</HTML>
