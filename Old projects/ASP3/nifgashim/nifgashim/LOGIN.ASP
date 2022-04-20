<%@ Language=VBScript %>
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

<p>
<form id="form1" method="post" >
<table border="0" borderColor="#111111" cellPadding="0" cellSpacing="0" height="448" style="BORDER-COLLAPSE: collapse" width="100%">
  
  <tr>
    <td background="images/leftRoze.gif" height="448" rowSpan="9" width="30%">&nbsp;</td>
    <td background="images/nifgashim.gif" height="85" width="75%" colspan="4">&nbsp;</td></tr>
  <tr>
    <td align="right" height="46" width="19%">&nbsp;</td>
    <td align="right" height="46" width="19%">&nbsp;</td>
    <td align="right" height="46" width="19%">&nbsp;</td>
    <td align="right" height="46" width="18%">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="18%">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" height="46" width="19%">&nbsp;</td>
    <td align="right" height="46" width="19%">
    <INPUT 
      id=txtUsername name=txtusername 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered" 
   ></td>
    <td align="right" height="46" width="19%">
      <P align=right>שם משתמש&nbsp;</P></td>
    <td align="right" height="46" width="18%">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="19%">
    <INPUT 
      id=txtPasswd name=txtpasswd 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered" 
type=password 
     ></td>
    <td align="right" height="45" width="19%">
      סיסמה&nbsp;</td>
    <td align="right" height="45" width="18%">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" height="45" width="19%">
    <INPUT id=btnBack language=vbscript name=btnBack onclick=window.history.back style="BACKGROUND-COLOR: oldlace; COLOR: orangered" type=button value=חזרה>&nbsp;</td>
    <td align="right" height="45" width="19%">
    <INPUT id=btnEnter name=btnEnter style="BACKGROUND-COLOR: oldlace; COLOR: orangered" type=button value=הכנס>&nbsp;</td>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="18%">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="19%"><div id=divmessage></div></td>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="18%">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="19%">
      <P align=center>&nbsp;</P>&nbsp;</td>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="18%">&nbsp;</td>
    </tr>
  <tr>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="19%">
      &nbsp;</td>
    <td align="right" height="45" width="19%">&nbsp;</td>
    <td align="right" height="45" width="18%">&nbsp;</td>
    </tr>
  </table></p></FORM>
<P>&nbsp;</P>
</body>
</html>

<script language="vbscript">
txtAllow="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" &_
"1234567890-_אבגדהוזחטיכלמנסעפצקרשתףךץןם"
'check if txt include chars from txtAllow only
'input: txt as string,txtAllow as string
'output: 0 not OK, 1 OK
function checkText(txt,txtAllow)
	dim txtOK
	txtOK=1
	for a=1 to len(txt)
		if instr(1,txtAllow,mid(txt,a,1))=0 then txtOK=0
	next
	checkText=txtOK
end function

	sub btnEnter_onclick
		formok=1
		if form1.txtUsername.value="" or checkText(form1.txtUsername.value,txtAllow)=0 then
			formok=0
		end if
		if form1.txtPasswd.value="" or checkText(form1.txtPasswd.value,txtAllow)=0 then
			formok=0
		end if
		
		if formok=0 then
			divmessage.innerHTML="שגיאה בנתונים"
		else
			form1.action="loginProcedure.asp"
			form1.submit
		end if
	end sub
</script>