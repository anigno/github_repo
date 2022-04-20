//****************************************Events registration//****************************************
window.onscroll=RepeatedActions;
window.document.onmousemove=RepeatedActions;
window.onload=InitMain;



//****************************************Global variables//****************************************
//Dynamic sites array
var SitesArray=new Array();
SitesArray[0] = new Array('shire','SitePages\\Site01\\SiteImage01.jpg','210','120','SitePages\\Site01\\Site01.htm');
SitesArray[1] = new Array('shire','SitePages\\Site01\\SiteImage01.jpg','100','120','SitePages\\Site01\\Site01.htm');
SitesArray[2] = new Array('shire','SitePages\\Site01\\SiteImage01.jpg','210','200','SitePages\\Site01\\Site01.htm');
var DynamicLinks=new Array();	//DynamicLink objects array, for reposition
var DynamicLinkImageSize=40;
var DefaultImageMapWidth=400;
var DefaultImageMapHeight=600;
var CurrentMapZoom=100;
var MinLongitude=33;
var MaxLongitude=38;
var MinLatitude=33;
var MaxLatitude=29;

//****************************************Functions//****************************************
function InitMain(){
	MapImage.width=DefaultImageMapWidth;
	MapImage.height=DefaultImageMapHeight;
	RepeatedActions();
	CreateDynamicLinks();
}

function RepeatedActions(){
	MoveElementToStady(ZoomPanel,10,10);
	GetMouseXY();
	LatLong.innerHTML=GetLongitude() + " :: " + GetLatitude();
	
}

function GetLongitude(){
	GetMouseXY();
	lo=MinLongitude+(MaxLongitude-MinLongitude)*(MouseAbsolutePosX/MapImage.width);
	return parseInt(lo*100)/100;
}

function GetLatitude(){
	GetMouseXY();
	la=MinLatitude+(MaxLatitude-MinLatitude)*(MouseAbsolutePosY/MapImage.height);
	return parseInt(la*100)/100;
}

function CreateDynamicLinks(){
	for(var i=0;i<SitesArray.length;i++){
		el=document.createElement("DIV");
		document.body.appendChild(el);
		el.innerHTML="<a target='_blank' onmouseleave='HideToolTip()' onmouseover='ShowToolTop("+i+")' href='"+SitesArray[i][4]+"'><img src='Design\\Galleon.gif' width="+DynamicLinkImageSize+" height="+DynamicLinkImageSize+"/></a>";
		el.style.cursor="pointer"
		MoveElementTo(el,SitesArray[i][2],SitesArray[i][3]);
		DynamicLinks[i]=el;
	}
}

function UpdateDynamicLinks(){
	CurrentMapZoom=GetCurrentZoom();
	MapScale.innerHTML=CurrentMapZoom*100 +"%"
	for(var i=0;i<SitesArray.length;i++){
		MoveElementTo(DynamicLinks[i],SitesArray[i][2]*CurrentMapZoom,SitesArray[i][3]*CurrentMapZoom);
	}
}

function MapImageZoomIn(){
	ZoomIn(MapImage)
	UpdateDynamicLinks();
	RepeatedActions();
}
function MapImageZoomOut(){
	cz=GetCurrentZoom();
	//Prevent zoom would be less then 100%
	if(cz==1)return;
	ZoomOut(MapImage)
	UpdateDynamicLinks();
	RepeatedActions();
}


function ShowToolTop(i){
	ToolTipBox.style.visibility="visible";
	CurrentMapZoom=GetCurrentZoom();
	MoveElementTo(ToolTipBox,SitesArray[i][2]*CurrentMapZoom+DynamicLinkImageSize,SitesArray[i][3]*CurrentMapZoom);
	img = new Image()
	img.src=SitesArray[i][1]
	startStr="<table border=1  bgcolor='black'><tr><td>"
	midStr="</td></tr><tr><td align='center'><font color='white' <strong>"+SitesArray[i][0]+"</strong></font></td></tr>"
	endStr="</td></tr></table>"
	ToolTipBox.innerHTML=startStr+"<img alt='' src='"+img.src+"' width="+img.width+" height="+img.height+"/>"+midStr+endStr
}


function HideToolTip(){
	ToolTipBox.style.visibility="hidden"
}

function GetCurrentZoom(){
	return MapImage.width/DefaultImageMapWidth;
}
