<%@ Language=VBScript %>
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<!--webbot BOT="GeneratedScript" PREVIEW=" " startspan --><script Language="JavaScript"><!--
function FrontPage_Form1_Validator(theForm)
{

  if (theForm.txtInterests.value.length > 250)
  {
    alert("Please enter at most 250 characters in the \"txtInterests\" field.");
    theForm.txtInterests.focus();
    return (false);
  }
  return (true);
}
//--></script><!--webbot BOT="GeneratedScript" endspan --><form id="form1" method="post" language="JavaScript" onsubmit="return FrontPage_Form1_Validator(this)" name="FrontPage_Form1">
<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" height="448">
  <tr>
    <td width="30%" rowspan="11" background="images/leftRoze.gif" height="448">&nbsp;</td>
    <td width="75%" background="images/nifgashim.gif" height="85" colspan="4">&nbsp;</td>
  </tr>
  <tr>
    <td width="15%" height="37" align="right">&nbsp;</td>
    <td width="20%" height="37" align="right"></td>
    <td width="20%" height="37" align="right">פרטי משתמש</td>
    <td width="20%" height="37" align="right">&nbsp;</td>
  </tr>
  <tr>
    <td width="15%" height="37" align="right"><div id="divusername"></div></td>
    <td width="20%" height="37" align="right"><font size="1">ש<span lang="he">ם 
    משתמש באנגלית</span></font></td>
    <td width="20%" height="37" align="right">
    <input id="txtUsername" name="txtUsername" style="BACKGROUND-COLOR: oldlace; COLOR: orangered" tabIndex="0" size="20"></td>
    <td width="20%" height="37" align="right">שם משתמש</td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right"><div id="divpasswd1"></div></td>
    <td width="20%" height="36" align="right"><font size="1">שימו לב באיזו שפה 
    אתם רושמים את הסיסמה</font></td>
    <td width="20%" height="36" align="right">
      <input id="txtPasswd1" name="txtPasswd1" style="BACKGROUND-COLOR: oldlace; COLOR: orangered; LEFT: 0px; TOP: 2px" tabIndex="0" type="password" size="20"></td>
    <td width="20%" height="36" align="right"><span lang="he">סיסמה</span></td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right"><div id="divpasswd2"></div></td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">
      <input id="txtPasswd2" name="txtPasswd2" style="BACKGROUND-COLOR: oldlace; COLOR: orangered" tabIndex="0" type="password" size="20"></td>
    <td width="20%" height="36" align="right"><span lang="he">אימות סיסמה</span></td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">&nbsp;</td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right"><div id="divname"></div></td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">
    <input id="txtName" name="txtName" style="BACKGROUND-COLOR: oldlace; COLOR: orangered; TEXT-ALIGN: right" tabIndex="0" size="20"></td>
    <td width="20%" height="36" align="right"><span lang="he">שם פרטי</span></td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right"><div id="divfamily"></div></td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">
    <input id="txtFamily1" name="txtFamily1" style="BACKGROUND-COLOR: oldlace; COLOR: orangered; TEXT-ALIGN: right" tabIndex="0" size="20"></td>
    <td width="20%" height="36" align="right"><span lang="he">שם משפחה</span></td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">
    <select id="txtSex" name="txtSex" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">אישה</option>
    <option value="2">גבר</option>
    </select></td>
    <td width="20%" height="36" align="right"><span lang="he">מין</span></td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right"><select id="txtAge" name="txtAge" style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> 
        <option selected value="15">15</option> <option value="16">16</option><option value="16">
        16</option><option value="17">17</option><option value="18">18</option><option value="19">
        19</option><option value="20">20</option><option value="21">21</option><option value="22">
        22</option><option value="23">23</option><option value="24">24</option><option value="25">
        25</option><option value="26">26</option><option value="27">27</option><option value="28">
        28</option><option value="29">29</option><option value="30">30</option> <option value="31">
        31</option><option value="32">32</option><option value="33">33</option><option value="34">
        34</option><option value="35">35</option><option value="36">36</option><option value="37">
        37</option><option value="38">38</option><option value="39">39</option><option value="40">
        40</option><option value="41">41</option><option value="42">42</option><option value="43">
        43</option><option value="44">44</option><option value="45">45</option><option value="46">
        46</option> <option value="47">47</option><option value="48">48</option><option value="49">
        49</option><option value="50">50</option><option value="51">51</option><option value="52">
        52</option><option value="53">53</option><option value="54">54</option><option value="55">
        55</option><option value="56">56</option><option value="57">57</option><option value="58">
        58</option><option value="59">59</option><option value="60">60</option></select></td>
    <td width="20%" height="36" align="right"><span lang="he">גיל</span></td>
  </tr>
  <tr>
    <td width="15%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">&nbsp;</td>
    <td width="20%" height="36" align="right">
    <select id="txtState" name="txtState" style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> 
        <option selected value="0">----</option> 
        <option value="1">רווק</option> 
        <option value="2">נשוי</option> 
        <option value="3">נשוי עם ילדים</option>
        <option value="4">פרוד</option> 
        <option value="5">פרוד עם ילדים</option>
        <option value="6">גרוש</option> 
        <option value="7">גרוש עם ילדים</option>
        <option value="8">אלמן</option>
        <option value="9">אלמן עם ילדים</option></select></td>
    <td width="20%" height="36" align="right"><span lang="he">מצב 
    אישי</span></td>
  </tr>
</table>
<p align="right">&nbsp;</p>
<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" height="373">
  <tr>
    <td width="25%" height="28"><div id="divoccupation"></div></td>
    <td width="25%" height="28">&nbsp;</td>
    <td width="25%" height="28"></td>
    <td width="25%" align="right" height="28">&nbsp;</td>
  </tr>
  <tr>
    <td width="25%" height="28" align="right">
      <input id="txtOccupation" name="txtOccupation" style="BACKGROUND-COLOR: oldlace; COLOR: orangered; TEXT-ALIGN: right" size="20"></td>
    <td width="25%" height="28" align="right">
    <span lang="he">עיסוק</span></td>
    <td width="25%" align="right" height="28">
    <select id="txtRegion" name="txtRegion" style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> 
    <option selected value="0">----</option>
    <option value="1">צפון</option>
    <option value="2">חיפה</option> 
    <option value="3">מרכז</option>
    <option value="4">גוש דן</option>
    <option value="5">תל אביב</option>
    <option value="6">ירושליים</option>
    <option value="7">באר שבע</option>
    <option value="8">דרום</option>
    <option value="9">אילת</option>
    </select></td>
    <td width="25%" align="right" height="28"><span lang="he">איזור 
    מגורים</span></td>
  </tr>
  <tr>
    <td width="25%" height="28" align="right">
    <select id="txtMoney" name="txtMoney" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">סביר</option>
    <option value="2">בסדר</option>
    <option value="3">טוב</option>
    <option value="4">מבוסס</option>
    <option value="5">עמיד</option>
    </select></td>
    <td width="25%" height="28" align="right"><span lang="he">מצב כלכלי</span></td>
    <td width="25%" align="right" height="28">
    <select id="txtSmoke" name="txtSmoke" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">לא</option>
    <option value="2">נדיר</option>
    <option value="3">כן</option>
    <option value="4">כבד</option>
    </select></td>
    <td width="25%" align="right" height="28"><span lang="he">עישון</span></td>
  </tr>
  <tr>
    <td width="25%" height="28" align="right">
    <select id="txtBelieve" name="txtBelieve" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">לא מאמין</option>
    <option value="2">מאמין</option>
    <option value="3">שומר</option>
    <option value="4">אדוק</option>
    <option value="5">חרדי</option>
    </select></td>
    <td width="25%" height="28" align="right"><span lang="he">אמונה</span></td>
    <td width="25%" align="right" height="28">
    <select id="txtDrink" name="txtDrink" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">לא</option>
    <option value="2">נדיר</option>
    <option value="3">כן</option>
    <option value="4">תמיד</option>
    </select></td>
    <td width="25%" align="right" height="28"><span lang="he">שתיה</span></td>
  </tr>
  <tr>
    <td width="25%" height="29" align="right">
    <select id="txtLuck" name="txtLuck" style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> 
    <option selected value="0">----</option>
    <option value="1">גדי</option>
    <option value="2">דלי</option>
    <option value="3">דגים</option>
    <option value="4">טלה</option>
    <option value="5">שור</option>
    <option value="6">תאומים</option>
    <option value="7">סרטן</option>
    <option value="8">אריה</option>
    <option value="9">בתולה</option>
    <option value="10">מאזניים</option>
    <option value="11">עקרב</option>
    <option value="12">קשת</option>
    </select></td>
    <td width="25%" height="29" align="right"><span lang="he">מזל</span></td>
    <td width="25%" align="right" height="29">
    <select id="txtEducation" name="txtEducation" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">בסיסית</option>
    <option value="2">תיכונית</option>
    <option value="3">בגרות</option>
    <option value="4">על תיכונית</option>
    <option value="5">אקדמאית</option>
    <option value="6">תואר שני</option>
    <option value="7">דוקטורט</option>
    </select></td>
    <td width="25%" align="right" height="29"><span lang="he">השכלה</span></td>
  </tr>
  <tr>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" align="right" height="29">
    <select id="txtHaircolor" name="txtHaircolor" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">שחור</option>
    <option value="2">חום</option>
    <option value="3">בלונד</option>
    <option value="4">ג'ינג'י</option>
    <option value="5">מחומצן</option>
    <option value="6">אדום</option>
    <option value="7">שאטני</option>
    <option value="8">אחר</option>
    
    </select></td>
    <td width="25%" align="right" height="29"><span lang="he">צבע שיער</span></td>
  </tr>
  <tr>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" align="right" height="29">
    <select id="txtHairstyle" name="txtHairstyle" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">חלק</option>
    <option value="2">חלק ארוך</option>
    <option value="3">מתולתל</option>
    <option value="4">מתולתל ארוך</option>
    <option value="5">פאנק</option>
    <option value="6">קוצים</option>
    <option value="7">קרחת</option>
    <option value="8">אחר</option>
    </select></td>
    <td width="25%" align="right" height="29"><span lang="he">סגנון שיער</span></td>
  </tr>
  <tr>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" align="right" height="29">
    <select id="txtBody" name="txtBody" style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> 
    <option selected value="0">----</option>
    <option value="1">רזה</option>
    <option value="2">חטוב</option>
    <option value="3">פרופורציונלי</option>
    <option value="4">מלא</option>
    <option value="5">שמן</option>
    </select></td>
    <td width="25%" align="right" height="29"><span lang="he">מבנה גוף</span></td>
  </tr>
  <tr>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" align="right" height="29">
    <select id="txtHeight" name="txtHeight" style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> 
    <option selected value="0">----</option>
    <option value="150">150</option>
    <option value="151">151</option>
    <option value="152">152</option>
    <option value="153">153</option>
    <option value="154">154</option>
    <option value="155">155</option>
    <option value="156">156</option>
    <option value="157">157</option>
    <option value="158">158</option>
    <option value="159">159</option>
    <option value="160">160</option>
    <option value="161">161</option>
    <option value="162">162</option>
    <option value="163">163</option>
    <option value="164">164</option>
    <option value="165">165</option>
    <option value="166">166</option>
    <option value="167">167</option>
    <option value="168">168</option>
    <option value="169">169</option>
    <option value="170">170</option>
    <option value="171">171</option>
    <option value="172">172</option>
    <option value="173">173</option>
    <option value="174">174</option>
    <option value="175">175</option>
    <option value="176">176</option>
    <option value="177">177</option>
    <option value="178">178</option>
    <option value="179">179</option>
    <option value="180">180</option>
    <option value="181">181</option>
    <option value="182">182</option>
    <option value="183">183</option>
    <option value="184">184</option>
    <option value="185">185</option>
    <option value="186">186</option>
    <option value="187">187</option>
    <option value="188">188</option>
    <option value="189">189</option>
    <option value="190">190</option>
    <option value="191">191</option>
    <option value="192">192</option>
    <option value="193">193</option>
    <option value="194">194</option>
    <option value="195">195</option>
    <option value="196">196</option>
    <option value="197">197</option>
    <option value="198">198</option>
    <option value="199">199</option>
    <option value="200">200</option>
    <option value="201">201</option>
    <option value="202">202</option>
    <option value="203">203</option>
    <option value="204">204</option>
    <option value="205">205</option>
    <option value="206">206</option>
    <option value="207">207</option>
    <option value="208">208</option>
    <option value="209">209</option>
    <option value="210">210</option>
    </select></td>
    <td width="25%" align="right" height="29"><span lang="he">גובה</span></td>
  </tr>
  <tr>
    <td width="25%" height="29"><div id="divinterests1">&nbsp;</div></td>
    <td width="50%" height="29" colspan="2"><div align="right">
      <!--webbot bot="Validation" i-maximum-length="250" --><input id="txtInterests" name="txtInterests" style="BACKGROUND-COLOR: oldlace; COLOR: orangered; HEIGHT: 25px; TEXT-ALIGN: right; WIDTH: 370px" size="47"></div></td>
    <td width="25%" align="right" height="29"><span lang="he">תחומי עניין</span></td>
  </tr>
  <tr>
    <td width="25%" height="29" align="right">&nbsp;</td>
    <td width="25%" height="29" align="right">&nbsp;</td>
    <td width="25%" height="29" align="right">
    <select id="txtArmy" name="txtArmy" style="BACKGROUND-COLOR: oldlace; COLOR: orangered">
    <option selected value="0">----</option>
    <option value="1">לא</option>
    <option value="2">חלקי</option>
    <option value="3">מלא</option>
    <option value="4">שירות לאומי</option>
    </select></td>
    <td width="25%" align="right" height="29"><span lang="he">שירות צבאי</span></td>
  </tr>
  <tr>
    <td width="25%" height="29"><div id="divmain"></div></td>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" height="29">&nbsp;</td>
    <td width="25%" align="right" height="29">&nbsp;</td>
  </tr>
  <tr>
    <td width="25%" height="29" align="middle">
    <input id="btnJoin" name="submit1" style="BACKGROUND-COLOR: oldlace; COLOR: crimson; FONT-WEIGHT: bold" type="button" value="צרפו אותי"></td>
    <td width="25%" height="29" align="middle"><input id="reset1" name="reset1" style="BACKGROUND-COLOR: oldlace; COLOR: tomato" type="reset" value="מחק נתונים"></td>
    <td width="25%" height="29" align="middle">
    <input id="cancel" name="cancel" style="BACKGROUND-COLOR: oldlace; COLOR: orange" type="button" value="ביטול"></td>
    <td width="25%" align="right" height="29">&nbsp;</td>
  </tr>
</table>
</form>
<p>&nbsp;</p>
</body>
</html>
<!-- ********** script **********-->
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
</script>
<script language="vbscript">
	sub cancel_onclick()
		window.history.back
	end sub
	
	sub btnJoin_onClick()
		'checks form data
		formok=1
		if form1.txtUsername.value="" or checkText(form1.txtUsername.value,txtAllow)=0 then
			formok=0
			divusername.innerHTML="<font color=red>שגיאה</font>"
		else
			divusername.innerHTML=""
		end if
		if form1.txtPasswd1.value="" or checkText(form1.txtPasswd1.value,txtAllow)=0 then
			formok=0
			divpasswd1.innerHTML="<font color=red>שגיאה</font>"
		else
			divpasswd1.innerHTML=""
		end if		
		if form1.txtPasswd1.value<>form1.txtPasswd2.value then
			formok=0
			divpasswd2.innerHTML="<font color=red>ססמאות לא דומות</font>"
		else
			divpasswd2.innerHTML=""
		end if
		if form1.txtName.value="" or checkText(form1.txtName.value,txtAllow & " ")=0 then
			formok=0
			divname.innerHTML="<font color=red>שגיאה</font>"
		else
			divname.innerHTML=""
		end if
		if form1.txtFamily1.value="" or checkText(form1.txtFamily1.value,txtAllow & " ")=0 then
			formok=0
			divfamily.innerHTML="<font color=red>שגיאה</font>"
		else
			divfamily.innerHTML=""
		end if
		if form1.txtOccupation.value="" or checkText(form1.txtOccupation.value,txtAllow & " ")=0 then
			formok=0
			divoccupation.innerHTML="<font color=red>שגיאה</font>"
		else
			divoccupation.innerHTML=""
		end if
		if form1.txtInterests.value="" or checkText(form1.txtInterests.value,txtAllow & " " & chr(13))=0 then
			formok=0
			divinterests1.innerHTML="<font color=red>שגיאה</font>"
		else
			divinterests1.innerHTML=""
		end if
		
		if formok=0 then
			divmain.innerHTML="<font color=red size=2>שגיאה במילוי הטופס</font>"
		else
			divmain.innerHTML=""
			form1.action="joinProcedure.asp"
			form1.submit
		end if
		
	end sub
</script>