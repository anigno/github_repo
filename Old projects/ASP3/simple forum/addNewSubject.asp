<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
add new subject<BR>
<form id=form1 action=addNewSubject01.asp method=post name=form1>
	<TABLE border=1 cellPadding=1 cellSpacing=1 width="75%" >
	  <TR>
	    <TD>name</TD>
	    <TD><INPUT id=text1 name=text1></TD></TR>
	  <TR>
	    <TD>EMAIL</TD>
	    <TD><INPUT id=text2 name=text2></TD></TR>
	  <TR>
	    <TD>subject</TD>
	    <TD><INPUT id=text3 name=text3></TD></TR>
	  <TR>
	    <TD>message</TD>
	    <TD><TEXTAREA id=TEXTAREA1 name=TEXTAREA1 style="HEIGHT: 100px; WIDTH: 300px"></TEXTAREA></TD></TR>
	</TABLE>
<INPUT id=button2 name=button2 type=button value=Add>&nbsp;
<INPUT id=reset1 name=reset1 type=reset value=Reset> 
<INPUT id=button1 name=button1 type=button value=Cancel >
</form>
<script language="vbscript">
	public sub button1_onClick()
		navigate "main01.asp"
	end sub
	public sub button2_onClick()
		checkForm
	end sub
	
	public sub checkForm()
		if form1.text3.value="" then
			MsgBox "no subject !",vbCritical
			exit sub
		end if
		if form1.text1.value="" then
			MsgBox "no name !",vbCritical
			exit sub
		end if
		if form1.text2.value="" then
			MsgBox "no email !",vbCritical
			exit sub
		end if
		if form1.TEXTAREA1.value="" then
			MsgBox "no message !",vbCritical
			exit sub
		end if
		form1.submit
	end sub
</script>
</BODY>
</HTML>
