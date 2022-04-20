<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<%
	'sending user data to login.asp or newUser.asp by submit-post
%>
<html dir="rtl">
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
<base target="_self">
</head>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<table border="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%">
  <tr>
    <td width="22%" colspan="2">
      <P align=left><STRONG><FONT color=maroon 
    size=7>פורום</FONT></STRONG></P></td>
    <td width="20%"><FONT size=6><STRONG><FONT 
      color=maroon>&nbsp;בלי צנזורה</FONT></STRONG></FONT></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">
    <p align="left"><span lang="en-us">
    <A href="mailto:anigno@softhome.net"  title="דואר בענייני באגים ותקלות לרוני">
    <font size="2">mail anigno</font></A></span></p></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
<form action="login.asp" name="form1" method="post">
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">משתמש רשום</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">
    <p dir="rtl" align="right">שם משתמש</p> </td>
    <td width="20%">
    <input id="text1" name="txtUsername" style="BACKGROUND-COLOR: moccasin; LEFT: 4px; TOP: 1px" 
     ></td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">סיסמא</td>
    <td width="20%">
    <input id="text4" name="txtPasswd" style="BACKGROUND-COLOR: moccasin" ></td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">
<input type="submit" value="כניסה" id="submit1" name="submit1" style="BACKGROUND-COLOR: moccasin"></td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
</form>
<form name="form2" action="newUser.asp" method="post">
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">משתמש חדש</td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">שם משתמש</td>
    <td width="20%">
    <input id="text2" name="txtUsername" style="BACKGROUND-COLOR: moccasin" ></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">סיסמא</td>
    <td width="20%">
    <input id="text3" name="txtPasswd" style="BACKGROUND-COLOR: moccasin" ></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">גיל</td>
    <td width="20%"><select id="select3" name="txtAge" style="BACKGROUND-COLOR: moccasin">
    <option value="21-24" selected>20-24</option>
    <option value="25-28">25-28</option>
    <option value="29-32">29-32</option>
    <option value="33-36">33-36</option>
    <option value="37-40">37-40</option>
    <option value="41-">41-</option>
    </select></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">מין</td>
    <td width="20%"><select id="txtSex" name="txtSex" style="BACKGROUND-COLOR: moccasin">
<option value="גבר" selected dir="rtl">גבר</option>
<option value="אישה" dir="rtl">אישה</option>
</select></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">איזור מגורים</td>
    <td width="20%"><select id="txtRegion" name="txtRegion" style="BACKGROUND-COLOR: moccasin">
<option value="צפון" selected dir="rtl">צפון</option>
<option value="חיפה" dir="rtl">חיפה</option>
<option value="תל_אביב" dir="rtl">תל_אביב</option>
<option value="באר_שבע" dir="rtl">באר_שבע</option>
<option value="ירושליים" dir="rtl">ירושלים</option>
<option value="דרום" dir="rtl">דרום</option>
</select></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">
<input type="submit" value="הרשם" id="submit2" name="submit2" style="BACKGROUND-COLOR: moccasin"></td>
    <td width="20%">&nbsp;</td>
    <td width="21%">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;</td>
    <td width="20%">&nbsp;נפתח</td>
    <td width="21%">22/9/02</td>
  </tr>
</form>
</table>


</body>
</html>
<script language="vbscript">
sub document_onkeyup()
	'send at each keyUp inputs for illigle chars ellimination
	form1.txtUsername.value=checkText(form1.txtUsername.value)
	form1.txtPasswd.value=checkText(form1.txtPasswd.value)
	form2.txtUsername.value=checkText(form2.txtUsername.value)
	form2.txtPasswd.value=checkText(form2.txtPasswd.value)
end sub
</script>