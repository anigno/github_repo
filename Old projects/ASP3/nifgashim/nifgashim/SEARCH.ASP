<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<P>
<form id=form1 name=form1 method=post action=searchResults.asp>
<TABLE border=1 cellPadding=1 cellSpacing=1 dir=rtl width="100%">
  <TR>
    <TD>שם משתמש</TD>
    <TD><INPUT id=txtUsername name=txtUsername 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered" tabIndex=0></TD>
    <TD>שם פרטי</TD>
    <TD><INPUT id=txtName name=txtName 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered; TEXT-ALIGN: right" 
      tabIndex=0></TD></TR>
  <TR>
    <TD>שם משפחה</TD>
    <TD><INPUT id=txtFamily1 name=txtFamily1 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered; TEXT-ALIGN: right" 
      tabIndex=0></TD>
    <TD>מין</TD>
    <TD><SELECT id=txtSex name=txtSex 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>אישה</OPTION> <OPTION 
        value=2>גבר</OPTION></SELECT></TD></TR>
  <TR>
    <TD>גיל</TD>
    <TD>מ<SELECT id=txtAgefrom name=txtAgefrom 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=15>15</OPTION> <OPTION value=16>16</OPTION><OPTION 
        value=16>16</OPTION><OPTION value=17>17</OPTION><OPTION 
        value=18>18</OPTION><OPTION value=19>19</OPTION><OPTION 
        value=20>20</OPTION><OPTION value=21>21</OPTION><OPTION 
        value=22>22</OPTION><OPTION value=23>23</OPTION><OPTION 
        value=24>24</OPTION><OPTION value=25>25</OPTION><OPTION 
        value=26>26</OPTION><OPTION value=27>27</OPTION><OPTION 
        value=28>28</OPTION><OPTION value=29>29</OPTION><OPTION 
        value=30>30</OPTION> <OPTION value=31>31</OPTION><OPTION 
        value=32>32</OPTION><OPTION value=33>33</OPTION><OPTION 
        value=34>34</OPTION><OPTION value=35>35</OPTION><OPTION 
        value=36>36</OPTION><OPTION value=37>37</OPTION><OPTION 
        value=38>38</OPTION><OPTION value=39>39</OPTION><OPTION 
        value=40>40</OPTION><OPTION value=41>41</OPTION><OPTION 
        value=42>42</OPTION><OPTION value=43>43</OPTION><OPTION 
        value=44>44</OPTION><OPTION value=45>45</OPTION><OPTION 
        value=46>46</OPTION> <OPTION value=47>47</OPTION><OPTION 
        value=48>48</OPTION><OPTION value=49>49</OPTION><OPTION 
        value=50>50</OPTION><OPTION value=51>51</OPTION><OPTION 
        value=52>52</OPTION><OPTION value=53>53</OPTION><OPTION 
        value=54>54</OPTION><OPTION value=55>55</OPTION><OPTION 
        value=56>56</OPTION><OPTION value=57>57</OPTION><OPTION 
        value=58>58</OPTION><OPTION value=59>59</OPTION><OPTION 
        value=60>60</OPTION></SELECT>&nbsp;עד<SELECT id=txtAgeto name=txtAgeto 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=15>15</OPTION> <OPTION value=16>16</OPTION><OPTION 
        value=16>16</OPTION><OPTION value=17>17</OPTION><OPTION 
        value=18>18</OPTION><OPTION value=19>19</OPTION><OPTION 
        value=20>20</OPTION><OPTION value=21>21</OPTION><OPTION 
        value=22>22</OPTION><OPTION value=23>23</OPTION><OPTION 
        value=24>24</OPTION><OPTION value=25>25</OPTION><OPTION 
        value=26>26</OPTION><OPTION value=27>27</OPTION><OPTION 
        value=28>28</OPTION><OPTION value=29>29</OPTION><OPTION 
        value=30>30</OPTION> <OPTION value=31>31</OPTION><OPTION 
        value=32>32</OPTION><OPTION value=33>33</OPTION><OPTION 
        value=34>34</OPTION><OPTION value=35>35</OPTION><OPTION 
        value=36>36</OPTION><OPTION value=37>37</OPTION><OPTION 
        value=38>38</OPTION><OPTION value=39>39</OPTION><OPTION 
        value=40>40</OPTION><OPTION value=41>41</OPTION><OPTION 
        value=42>42</OPTION><OPTION value=43>43</OPTION><OPTION 
        value=44>44</OPTION><OPTION value=45>45</OPTION><OPTION 
        value=46>46</OPTION> <OPTION value=47>47</OPTION><OPTION 
        value=48>48</OPTION><OPTION value=49>49</OPTION><OPTION 
        value=50>50</OPTION><OPTION value=51>51</OPTION><OPTION 
        value=52>52</OPTION><OPTION value=53>53</OPTION><OPTION 
        value=54>54</OPTION><OPTION value=55>55</OPTION><OPTION 
        value=56>56</OPTION><OPTION value=57>57</OPTION><OPTION 
        value=58>58</OPTION><OPTION value=59>59</OPTION><OPTION 
        value=60>60</OPTION></SELECT></TD>
    <TD>מצב אישי</TD>
    <TD><SELECT id=txtState name=txtState 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>רווק</OPTION> <OPTION 
        value=2>נשוי</OPTION> <OPTION value=3>נשוי עם ילדים</OPTION> <OPTION 
        value=4>פרוד</OPTION> <OPTION value=5>פרוד עם ילדים</OPTION> <OPTION 
        value=6>גרוש</OPTION> <OPTION value=7>גרוש עם ילדים</OPTION> <OPTION 
        value=8>אלמן</OPTION> <OPTION value=9>אלמן עם 
ילדים</OPTION></SELECT></TD></TR>
  <TR>
    <TD>איזור מגורים</TD>
    <TD><SELECT id=txtRegion name=txtRegion 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>צפון</OPTION> <OPTION 
        value=2>חיפה</OPTION> <OPTION value=3>מרכז</OPTION> <OPTION value=4>גוש 
        דן</OPTION> <OPTION value=5>תל אביב</OPTION> <OPTION 
        value=6>ירושליים</OPTION> <OPTION value=7>באר שבע</OPTION> <OPTION 
        value=8>דרום</OPTION> <OPTION value=9>אילת</OPTION></SELECT></TD>
    <TD>עישון</TD>
    <TD><SELECT id=txtSmoke name=txtSmoke 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>לא</OPTION> <OPTION 
        value=2>נדיר</OPTION> <OPTION value=3>כן</OPTION> <OPTION 
        value=4>כבד</OPTION></SELECT></TD></TR>
  <TR>
    <TD>מצב כלכלי</TD>
    <TD><SELECT id=txtMoney name=txtMoney 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>סביר</OPTION> <OPTION 
        value=2>בסדר</OPTION> <OPTION value=3>טוב</OPTION> <OPTION 
        value=4>מבוסס</OPTION> <OPTION value=5>עמיד</OPTION></SELECT></TD>
    <TD>שתיה</TD>
    <TD><SELECT id=txtDrink name=txtDrink 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>לא</OPTION> <OPTION 
        value=2>נדיר</OPTION> <OPTION value=3>כן</OPTION> <OPTION 
        value=4>תמיד</OPTION></SELECT></TD></TR>
  <TR>
    <TD>אמונה</TD>
    <TD><SELECT id=txtBelieve name=txtBelieve 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>לא מאמין</OPTION> <OPTION 
        value=2>מאמין</OPTION> <OPTION value=3>שומר</OPTION> <OPTION 
        value=4>אדוק</OPTION> <OPTION value=5>חרדי</OPTION></SELECT></TD>
    <TD>השכלה</TD>
    <TD><SELECT id=txtEducation name=txtEducation 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>בסיסית</OPTION> <OPTION 
        value=2>תיכונית</OPTION> <OPTION value=3>בגרות</OPTION> <OPTION 
        value=4>על תיכונית</OPTION> <OPTION value=5>אקדמאית</OPTION> <OPTION 
        value=6>תואר שני</OPTION> <OPTION value=7>דוקטורט</OPTION></SELECT></TD></TR>
  <TR>
    <TD>צבע שיער</TD>
    <TD><SELECT id=txtHaircolor name=txtHaircolor 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>שחור</OPTION> <OPTION 
        value=2>חום</OPTION> <OPTION value=3>בלונד</OPTION> <OPTION 
        value=4>ג'ינג'י</OPTION> <OPTION value=5>מחומצן</OPTION> <OPTION 
        value=6>אדום</OPTION> <OPTION value=7>שאטני</OPTION> <OPTION 
        value=8>אחר</OPTION></SELECT></TD>
    <TD>גובה</TD>
    <TD><SELECT id=txtHeight name=txtHeight 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=150>150</OPTION> <OPTION 
        value=151>151</OPTION> <OPTION value=152>152</OPTION> <OPTION 
        value=153>153</OPTION> <OPTION value=154>154</OPTION> <OPTION 
        value=155>155</OPTION> <OPTION value=156>156</OPTION> <OPTION 
        value=157>157</OPTION> <OPTION value=158>158</OPTION> <OPTION 
        value=159>159</OPTION> <OPTION value=160>160</OPTION> <OPTION 
        value=161>161</OPTION> <OPTION value=162>162</OPTION> <OPTION 
        value=163>163</OPTION> <OPTION value=164>164</OPTION> <OPTION 
        value=165>165</OPTION> <OPTION value=166>166</OPTION> <OPTION 
        value=167>167</OPTION> <OPTION value=168>168</OPTION> <OPTION 
        value=169>169</OPTION> <OPTION value=170>170</OPTION> <OPTION 
        value=171>171</OPTION> <OPTION value=172>172</OPTION> <OPTION 
        value=173>173</OPTION> <OPTION value=174>174</OPTION> <OPTION 
        value=175>175</OPTION> <OPTION value=176>176</OPTION> <OPTION 
        value=177>177</OPTION> <OPTION value=178>178</OPTION> <OPTION 
        value=179>179</OPTION> <OPTION value=180>180</OPTION> <OPTION 
        value=181>181</OPTION> <OPTION value=182>182</OPTION> <OPTION 
        value=183>183</OPTION> <OPTION value=184>184</OPTION> <OPTION 
        value=185>185</OPTION> <OPTION value=186>186</OPTION> <OPTION 
        value=187>187</OPTION> <OPTION value=188>188</OPTION> <OPTION 
        value=189>189</OPTION> <OPTION value=190>190</OPTION> <OPTION 
        value=191>191</OPTION> <OPTION value=192>192</OPTION> <OPTION 
        value=193>193</OPTION> <OPTION value=194>194</OPTION> <OPTION 
        value=195>195</OPTION> <OPTION value=196>196</OPTION> <OPTION 
        value=197>197</OPTION> <OPTION value=198>198</OPTION> <OPTION 
        value=199>199</OPTION> <OPTION value=200>200</OPTION> <OPTION 
        value=201>201</OPTION> <OPTION value=202>202</OPTION> <OPTION 
        value=203>203</OPTION> <OPTION value=204>204</OPTION> <OPTION 
        value=205>205</OPTION> <OPTION value=206>206</OPTION> <OPTION 
        value=207>207</OPTION> <OPTION value=208>208</OPTION> <OPTION 
        value=209>209</OPTION> <OPTION value=210>210</OPTION></SELECT></TD></TR>
  <TR>
    <TD>סגנון שיער</TD>
    <TD><SELECT id=txtHairstyle name=txtHairstyle 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>חלק</OPTION> <OPTION value=2>חלק 
        ארוך</OPTION> <OPTION value=3>מתולתל</OPTION> <OPTION value=4>מתולתל 
        ארוך</OPTION> <OPTION value=5>פאנק</OPTION> <OPTION 
        value=6>קוצים</OPTION> <OPTION value=7>קרחת</OPTION> <OPTION 
        value=8>אחר</OPTION></SELECT></TD>
    <TD>שירות צבאי</TD>
    <TD><SELECT id=txtArmy name=txtArmy 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>לא</OPTION> <OPTION 
        value=2>חלקי</OPTION> <OPTION value=3>מלא</OPTION> <OPTION value=4>שירות 
        לאומי</OPTION></SELECT></TD></TR>
  <TR>
    <TD>מבנה גוף</TD>
    <TD><SELECT id=txtBody name=txtBody 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>רזה</OPTION> <OPTION 
        value=2>חטוב</OPTION> <OPTION value=3>פרופורציונלי</OPTION> <OPTION 
        value=4>מלא</OPTION> <OPTION value=5>שמן</OPTION></SELECT></TD>
    <TD>מזל</TD>
    <TD><SELECT id=txtLuck name=txtLuck 
      style="BACKGROUND-COLOR: oldlace; COLOR: orangered"> <OPTION selected 
        value=0>----</OPTION> <OPTION value=1>גדי</OPTION> <OPTION 
        value=2>דלי</OPTION> <OPTION value=3>דגים</OPTION> <OPTION 
        value=4>טלה</OPTION> <OPTION value=5>שור</OPTION> <OPTION 
        value=6>תאומים</OPTION> <OPTION value=7>סרטן</OPTION> <OPTION 
        value=8>אריה</OPTION> <OPTION value=9>בתולה</OPTION> <OPTION 
        value=10>מאזניים</OPTION> <OPTION value=11>עקרב</OPTION> <OPTION 
        value=12>קשת</OPTION></SELECT></TD></TR>
  <TR>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD><INPUT type=submit id=btnSearch name=btnSearch style="BACKGROUND-COLOR: oldlace; COLOR: crimson; FONT-WEIGHT: bold" type=button value=חפש>
    </TD></TR></TABLE></P>
</form>
</body>
</HTML>
