<!--  AD rotator script written entirely in JavaScript  -->
<!--  Written by WenWei, 2002/03/03. E-mail: wenwei#blueidea.com  -->
<!--  ASP 2 JS Written by 小荷, 2003/05/28. E-mail: aston314#sohu.com  -->
<!--  Member Of Blueidea Web Team. -->
<!--  Welcome to www.blueidea.com. -->
document.write('<script type="text/javascript" src="/js/flashobject.js"></scr'+'ipt>');
function runCode()  //定义一个运行代码的函数，
{
	if(1 == arguments.length)
		try{event = arguments[0];}catch(e){}
  var code=(event.target || event.srcElement).parentNode.childNodes[0].value;//即要运行的代码。
  var newwin=window.open('','','');  //打开一个窗口并赋给变量newwin。
  newwin.opener = null // 防止代码对论谈页面修改
  newwin.document.write(code);  //向这个打开的窗口中写入代码code，这样就实现了运行代码功能。
  newwin.document.close();
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_showHideLayers() { //v3.0
  var i,p,v,obj,args=MM_showHideLayers.arguments;
  for (i=0; i<(args.length-2); i+=3) if ((obj=MM_findObj(args[i]))!=null) { v=args[i+2];
    if (obj.style) { obj=obj.style; v=(v=='show')?'visible':(v='hide')?'hidden':v; }
    obj.visibility=v; }
}

// AD Banner object
function ADBanner(){
  this.htmlcode  = "";// Non image banner's html code
  this.href      = "";// Link's href attrib
  this.imgsrc    = "";// Image's src attrib
  this.imgwidth  = "";// Image's width attrib
  this.imgheight = "";// Image's height attrib
  this.imgalt    = "";// Image's alt attrib
  this.imgborder = "";// Image's border attrib
  this.weight    = 1;// Banner's show weight
  this.place     = 1// Banner's place
  this.type      = 1;// Banner's type
  this.id      = 0;// Banner's ID
}

// Make Banner objects array
function CreatBanners(aBanners, aNum){
  for( var i=0; i<aNum; i++ ){
    aBanners[i] = new ADBanner();
  }
}

// Show banner
function showbanner(aPlace, aType, aBannerID)
{
  var amount = ADBanners.length;
  var includeList = new Array(amount);

  if (!document.usedBanners){
    document.usedBanners = new Array(amount);
for (var i=0; i<amount; i++)
      document.usedBanners[i] = -1;
  }
 
  var usedList = document.usedBanners;

  if (arguments.length == 2){
    var j = 0;
    var sum = 0;
for(var i=0; i<amount; i++){
if (ADBanners[i].place == aPlace && ADBanners[i].type == aType){
if (usedList[i] != i){
  includeList[j] = i;
      j++;
          sum = sum + ADBanners[i].weight;
    }
  }
 }
    if (sum <= 0)
  return;
    var rndNum = Math.round(Math.random() * sum);

    i = 0;
    j = 0;
    while (true) {
      j = j + ADBanners[includeList[i]].weight;
      if (j >= rndNum)
        break;
      i++;
    }

    i = includeList[i];
  }
  else{
if (aBannerID >= 0 && aBannerID < amount)
      i = aBannerID;
else
  return;
  }

  usedList[i] = i;

  if (ADBanners[i].htmlcode == "")
    document.write('<A HREF="'+ ADBanners[i].href +'" target=_blank><IMG SRC="'+ ADBanners[i].imgsrc +'" WIDTH="'+ ADBanners[i].imgwidth +'" HEIGHT="'+ ADBanners[i].imgheight +'" ALT="'+ ADBanners[i].imgalt +'" BORDER="'+ ADBanners[i].imgborder +'"></A>');
  else
    document.write(ADBanners[i].htmlcode);
  document.write('<script src=/common/jsbanner/redirect.asp?action=visit&id='+ADBanners[i].id+' ></s'+'cript>')
}

var ADBanners = new Array();

CreatBanners(ADBanners, 7);

ADBanners[0].htmlcode  = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=5,0,0,0" width="533" height="104"><param name=movie value="http://gg.blueidea.com/2005/www/533-104.swf"><PARAM NAME=wmode VALUE=opaque><param name=quality value=autolow><embed src="http://gg.blueidea.com/2005/www/533-104.swf" quality=autolow pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="533" height="104"></embed> </object>';
ADBanners[0].weight    = 10;
ADBanners[0].place= 2;
ADBanners[0].type = 2;
ADBanners[0].id = 38;

ADBanners[1].imgsrc    = "http://gg.blueidea.com/2006/chinaok/208x32.gif";
ADBanners[1].href = "http://www.chinaok.net.cn";
ADBanners[1].imgwidth  = "208";
ADBanners[1].imgheight = "32";
ADBanners[1].imgalt    = "建站、改版、推广，找欧科动力";
ADBanners[1].weight    = 10;
ADBanners[1].place= 4;
ADBanners[1].type = 4;
ADBanners[1].id = 42;

ADBanners[2].htmlcode  = '<script type="text/javascript">google_ad_client = "pub-5841412030047197";google_alternate_color = "CCCCD4";google_ad_width = 728;google_ad_height = 90;google_ad_format = "728x90_as";google_ad_channel ="7977407778";google_ad_type = "text_image";google_color_border = "6699CC";google_color_bg = "003366";google_color_link = "FFFFFF";google_color_url = "AECCEB";google_color_text = "AECCEB";</script><script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>';
ADBanners[2].weight    = 20;
ADBanners[2].place= 6;
ADBanners[2].type = 6;
ADBanners[2].id = 46;

ADBanners[3].imgsrc    = "http://gg.blueidea.com/2006/chinaok/468x60.gif";
ADBanners[3].href = "http://www.chinaok.net.cn";
ADBanners[3].imgwidth  = "468";
ADBanners[3].imgheight = "60";
ADBanners[3].imgalt    = "建站、改版、推广，找欧科动力";
ADBanners[3].weight    = 30;
ADBanners[3].place= 5;
ADBanners[3].type = 5;
ADBanners[3].id = 56;

ADBanners[4].imgsrc    = "http://gg.blueidea.com/2006/now/208x32.gif";
ADBanners[4].href = "http://www.now.cn";
ADBanners[4].imgwidth  = "208";
ADBanners[4].imgheight = "32";
ADBanners[4].imgalt    = "域名免费试用";
ADBanners[4].weight    = 20;
ADBanners[4].place= 4;
ADBanners[4].type = 4;
ADBanners[4].id = 41;

ADBanners[5].htmlcode  = '<script type="text/javascript">google_ad_client = "pub-5841412030047197";google_ad_width = 728;google_ad_height = 90;google_alternate_ad_url = "http://www.blueidea.com/js/google_adsense_script.html";google_ad_format = "728x90_as";google_ad_channel ="7977407778";google_ad_type = "text_image";google_color_border = "6699CC";google_color_bg = "003366";google_color_link = "FFFFFF";google_color_url = "AECCEB";google_color_text = "AECCEB";</script><script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script><br><br>';
ADBanners[5].weight    = 10;
ADBanners[5].place= 1;
ADBanners[5].type = 1;
ADBanners[5].id = 29;

ADBanners[6].htmlcode  = '<table border="0" align="center" cellpadding="0" cellspacing="0" height="40" bgcolor="#FFFFFF"><tr><td><a href=http://www.blueidea.com/game/site/2006gongyi target=_blank><img src=http://gg.blueidea.com/2006/gongyi/banner.jpg border=0></a></td><td width="6"></td><td><a href=http://www.feloo.com/special/youhui/ target=_blank><img src=http://gg.blueidea.com/2006/feloo/380_40.jpg border=0></a></td></tr></table>';
ADBanners[6].weight    = 10;
ADBanners[6].place= 9;
ADBanners[6].type = 6;
ADBanners[6].id = 57;

