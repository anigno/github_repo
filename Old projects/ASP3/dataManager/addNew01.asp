<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<form method=post id=form1 name=form1>
<table  border=1>
	<tr><td>
	address<INPUT TYPE="RADIO" NAME="radAddress" tabindex=0>
	 data<INPUT TYPE="RADIO" NAME="radData"><BR>
	subject/name<BR>
	<INPUT id=txtSubject name=txtSubject><BR>
	Address<BR>
	<INPUT id=txtAddress name=txtAddress ><BR>
	Phone1<BR>
	<INPUT id=txtPhone1 name=txtPhone1 
     ><BR>
	Phone2<BR>
	<INPUT id=txtPhone2 name=txtPhone2 
     ><BR>
	Email<BR>
	<INPUT id=txtEmail name=txtEmail 
     ><BR>
	<INPUT type="button" value="add new" id=button1 name=button1>
	<INPUT type="button" value=" Cancel " id=button2 name=button2> 
      </P>
	</td>
	<td>
	Data<br><TEXTAREA cols=30 id=txtData name=txtData rows=9>	</TEXTAREA>	
	</td>
	</tr>
</table>
</form>


<script language=vbscript>
	form1.radAddress.checked=true
	form1.radData.checked=false
</script>



<script language=vbscript>
	'cancel
	sub button2_onClick()
		history.back
	end sub
	
	'add new
	sub button1_onClick()
		if form1.txtSubject.value<>"" then
			form1.submit
			window.navigate "addNew02.asp"
		else
			MsgBox "No subject or name!",vbCritical
		end if
	end sub

	'radio buttons procedures
	sub radAddress_onClick()
		form1.radData.checked=false
	end sub
	
	sub radData_onClick()
		form1.radAddress.checked=false
	end sub
</script>

</BODY>
</HTML>
