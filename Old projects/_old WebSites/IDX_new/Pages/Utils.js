//Get one query string value by var name
function getQueryVariable(variable) {
  var query = window.location.search.substring(1);
  var vars = query.split("&");
  for (var i=0;i<vars.length;i++) {
    var pair = vars[i].split("=");
    if (pair[0] == variable) {
      return pair[1];
    }
  } 
  alert('Query Variable: ' + variable + ' not found');
}

function GetMouseButton(){
	mouseButton=event.button;
}

var MouseAbsolutePosX;
var MouseAbsolutePosY;
function GetMouseXY(){
	MouseAbsolutePosX=event.offsetX
	MouseAbsolutePosY=event.offsetY
}

function GetMouseAbsoluteX(){
	return event.offsetX;
}

function GetMouseAbsoluteY(){
	return event.offsetY;
}


// Browser Window Size and Position
// copyright Stephen Chapman, 3rd Jan 2005, 8th Dec 2005
// you may copy these functions but please keep the copyright notice as well
function pageWidth() {return window.innerWidth != null? window.innerWidth : document.documentElement && document.documentElement.clientWidth ?       document.documentElement.clientWidth : document.body != null ? document.body.clientWidth : null;}
function pageHeight() {return  window.innerHeight != null? window.innerHeight : document.documentElement && document.documentElement.clientHeight ?  document.documentElement.clientHeight : document.body != null? document.body.clientHeight : null;} 
//The left corner scroll value
function posLeft() {return typeof window.pageXOffset != 'undefined' ? window.pageXOffset :document.documentElement && document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft ? document.body.scrollLeft : 0;}
//The top corner scroll value
function posTop() {return typeof window.pageYOffset != 'undefined' ?  window.pageYOffset : document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop ? document.body.scrollTop : 0;}
function posRight() {return posLeft()+pageWidth();} 
function posBottom() {return posTop()+pageHeight();}


//Creates a new DIV tag with p_id and sets it's innerHTML to p_text
function PrintDiv(p_id,p_text,p_data){
	el=document.createElement("DIV");
	el.id=p_id;
	document.body.appendChild(el);
	el.innerHTML=p_text+"="+p_data;
}


//Returns a random number between 0 and n
function GetRandom(n)
{
    var ranNum= Math.floor(Math.random()*n);
    return ranNum;
}


//Moves an element to absolute position
function MoveElementTo(o,x,y){
	o.style.position="absolute";
	o.style.pixelLeft=x;
	o.style.pixelTop=y;
}

//Move an element to stady position regardless of scroll state
//must use: window.onscroll=MoveElementToStady();
function MoveElementToStady(p_el,p_x,p_y){
	p_el.style.position="absolute"
	MoveElementTo(p_el,p_x+posLeft(),p_y+posTop());
}


//Scroll to place mouse click in center of document
function ScrollToMouseCenter(){
	GetMouseXY();
	SmothScroll(MouseAbsolutePosX-document.documentElement.offsetWidth/2,MouseAbsolutePosY-document.documentElement.offsetHeight/2,50,10);
}	


//Delay execution for given milliseconds
function Wait(millis) 
{
	var date = new Date();
	var curDate = null;
	do { curDate = new Date(); } 
	while(curDate-date < millis);
} 

//Scoll smothly
function SmothScroll(p_x,p_y,p_delay,p_steps){
	dx=(p_x-posLeft())/p_steps;
	dy=(p_y-posTop())/p_steps;
	for(i=0;i<p_steps;i++){
		scroll(posLeft()+dx,posTop()+dy);
		Wait(p_delay);
	}
}

//ZoomIn usually an image
function ZoomIn(p_image){
	p_image.width*=2;
	p_image.height*=2;
	scroll(posLeft()*2+document.documentElement.offsetWidth/2,posTop()*2+document.documentElement.offsetHeight/2);
}

//ZoomOut usually an image
function ZoomOut(p_image){
	sx=posLeft()/2-document.documentElement.offsetWidth/4
	sy=posTop()/2-document.documentElement.offsetHeight/4
	p_image.width/=2;
	p_image.height/=2;
	scroll(sx,sy);
}
