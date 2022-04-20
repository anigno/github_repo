

//****************************************Global variables//****************************************
//Dynamic sites array
var SitesArray=new Array();
SitesArray[0] = new Array('shire','SitePages\\Site01\\SiteImage01.jpg','210','120','SitePages\\Site01\\SitePage01.htm');
SitesArray[1] = new Array('shire','SitePages\\Site01\\SiteImage01.jpg','200','110','SitePages\\Site02\\SitePage02.htm');
SitesArray[2] = new Array('shire','SitePages\\Site01\\SiteImage01.jpg','210','200','SitePages\\Site02\\SitePage02.htm');
var DynamicLinks=new Array();	//DynamicLink objects array, for reposition
var DynamicLinkImageSize=30;
var DefaultImageMapWidth=400;
var DefaultImageMapHeight=600;
var CurrentMapZoom=100;
var MinLongitude=33;
var MaxLongitude=38;
var MinLatitude=33;
var MaxLatitude=29;
