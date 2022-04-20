<!--#INCLUDE FILE="functions.asp" -->
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
<body dir="rtl" stylesrc="../data.htm" background="../../bg01.jpg" text="#440000" link="#800000" vlink="#800000" alink="#CC0000">

הוספת מודעה<br>
<form id="form1" name="form1" method="post" action="addNew01.asp">
<table cellSpacing="1" cellPadding="1" width="80%" border="1">
  <tr>
    <td>סוג המודעה</td>
    <td>
    <select id="type" name="type">
    <option selected value="אופנוע למכירה">אופנוע למכירה</option>
    <option value="טרקטורון למכירה">טרקטורון למכירה</option>
    <option value="ציוד למכירה">ציוד למכירה</option>
    <option value="מחפש אופנוע">מחפש אופנוע</option>
    <option value="מחפש טרקטורון">מחפש טרקטורון</option>
    <option value="מחפש ציוד">מחפש ציוד</option>
    <option value="מחפש גנוב">מחפש גנוב</option>
	</select>
    </td></tr>
  <tr>
    <td>יצרן</td>
    <td>
    <select id="manuf" name="manuf">
		<option selected value="28">B.S.A</option>
		<option value="1">איטלג'ט</option>
		<option value="2">אנפילד</option>
		<option value="3">אפריליה</option>
		<option value="4">ב.מ.וו</option>
		<option value="5">בטה</option>
		<option value="6">ג'ילרה</option>
		<option value="7">דוקאטי</option>
		<option value="8">דיאלים</option>
		<option value="26">דרבי</option>
		<option value="9">הונדה</option>
		<option value="27">הוסברג</option>
		<option value="10">הוסקוורנה</option>
		<option value="11">הרלי דיווידסון</option>
		<option value="32">טריום</option>
		<option value="12">יאווה</option>
		<option value="13">ימאהה</option>
		<option value="15">מ.ז</option>
		<option value="29">מוטו מורינו</option>
		<option value="14">מוטוגוצי</option>
		<option value="24">מלאגוטי</option>
		<option value="34">נורטון</option>
		<option value="16">סאן יאנג</option>
		<option value="17">סוזוקי</option>
		<option value="33">סי.פי.אי</option>
		<option value="25">פי.ג'י.או</option>
		<option value="19">פיאג'ו</option>
		<option value="18">פיג'ו</option>
		<option value="22">ק.ט.מ</option>
		<option value="20">קאג'יבה</option>
		<option value="21">קאוואסאקי</option>
		<option value="23">קימקו</option>
	</select>

    <td>נפח</td>
    <td>
    <select id="size" name="size">
		<option selected value="50">50</option>
		<%
			for a=60 to 1500 step 10
			Response.Write "<option value='" & a & "'>" & a & "</option>"
			next
		%>
	</select>
	</td></tr>

  <tr>
    <td>דגם&nbsp;<font size="1">(לדוגמא<br> DR,YZ,WR,F...)</font></td>
    <td><input dir="ltr" type="text" id="model" name="model">
	<!--font size=1>אנגלית</font>-->
    </td>
    <td>שנת ייצור</td>
    <td>
    <select id="year" name="year">
		<option selected value="1950">1950</option>
		<%
			for a=1951 to 2003 step 1
			Response.Write "<option value='" & a & "'>" & a & "</option>"
			next
		%>
	</select>
    </td></tr>
  <tr>
    <td>יד</td>
    <td>
<select id="hand" name="hand">
<option selected value="1">1</option>
<option value="2">2</option>
<option value="3">3</option>
<option value="4">4</option>
<option value="5">5</option>
<option value="6">6</option>
<option value="7">7</option>
<option value="8">8</option>
<option value="9">9</option>
</select>
	</td>
    <td>מחיר</td>
    <td><input type="text" id="prise" name="prise"></td></tr>
  <tr>
    <td>תאור כללי</td>
    <td>
    <textarea rows="4" cols="20" id="description" name="description">
	</textarea></td>
	<td>אזור מגורים</td>
	<td>
    <select id="region" name="region">
    <option value="צפון">צפון</option>
    <option value="נהריה והסביבה">נהריה והסביבה</option>
    <option selected value="חיפה והסביבה">חיפה והסביבה</option>
    <option value="מרכז">מרכז</option>
    <option value="דרום">דרום</option>
    </select>
	</td>	


    </tr><tr>
    <td>שם</td>
    <td>
    <input type="text" id="iname" name="iname"><br>
    </td>
    <td>טלפון
    </td>
    <td>
    <input type="text" id="phone" name="phone">
    </td></tr>

  <tr>
    <td></td>
    <td></td>
    <td></td>
    <td></td></tr>
</table>
<input type="button" value="הוסף" id="submit1" name="submit1">
&nbsp;&nbsp;&nbsp;<input type="button" value="חזרה" id="button1" name="button1">
</form>
<div id="qq"></div>
</body>
</html>

<script language="vbscript">
	sub button1_onclick()
		window.navigate "index.asp"
	end sub
	sub submit1_onclick
		if form1.description.value="" then form1.description.value="אין פרטים נוספים"
		if form1.model.value="" or form1.iname.value="" or form1.phone.value="" then
			MsgBox "חסרים פרטים בטופס!",vbCritical
		else
			form1.submit1.disabled=true
			form1.submit
		end if
	end sub
	sub model_onkeyup()
		form1.model.value=checkText(form1.model.value,2)
	end sub
	sub prise_onkeyup()
		form1.prise.value=checkText(form1.prise.value,1)
	end sub	
	sub description_onkeyup()
		form1.description.value=checkText(form1.description.value,1)
	end sub	
	sub phone_onkeyup()
		form1.phone.value=checkText(form1.phone.value,4)
	end sub	
	sub iname_onkeyup()
		form1.iname.value=checkText(form1.iname.value,1)
	end sub	

'	for q=0 to form1.manuf.length
'		qq.innerHTML=qq.innerHTML & "<br>" &_
'			"sModel(" & form1.manuf.item(q).value & ")=" & chr(34) & form1.manuf.item(q).innerhtml & chr(34)
'	next
</script>

