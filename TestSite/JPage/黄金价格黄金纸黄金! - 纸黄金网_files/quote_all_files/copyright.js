function copyright() {
	var authorized = new Array();
	authorized[authorized.length] = "zhihuangjin.com";
	authorized[authorized.length] = "zhihuangjin.cn";
	authorized[authorized.length] = "89119.cn";
	authorized[authorized.length] = "89114.cn";
	authorized[authorized.length] = "cib.com.cn";
	
	var isauthorized = false;
	for (var i = 0; i < authorized.length; i++) {
		if (document.referrer.indexOf(authorized[i]) > -1) isauthorized = true;
	}
	
	if (!isauthorized) {
		document.body.innerHTML = '<table width="100%" height="100%"><tr><th><marquee width="100%" height="65" onmouseover="stop()" onmouseout="start()"><a href="http://www.zhihuangjin.com/" target="_blank"><img src="http://www.zhihuangjin.com/images/logo.gif" border="0"></a></marquee></td></tr></table>';
		window.open("http://www.zhihuangjin.com");
	}
}