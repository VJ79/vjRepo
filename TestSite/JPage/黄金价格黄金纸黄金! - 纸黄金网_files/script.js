function showNavigation() {
	document.getElementById('divNav').style.visibility = 'visible';
}

function hideNavigation() {
	document.getElementById('divNav').style.visibility = 'hidden';
}

function setHomepage(url) {
	if (url == null) url = location.href;
	try {
		var obj = document.createElement("A");
		obj.style.behavior='url(#default#homepage)';
		obj.setHomePage(url);
	} catch (e) {
		window.alert("您的浏览器不支持此功能！");
	}
}

function addFavorite() {
	try {
		window.external.addFavorite(location.href, document.title);
	} catch (e) {
		window.alert("您的浏览器不支持此功能！");
	}
}

function switch_state(img, obj) {
	if (obj.style.display == "none") {
		obj.style.display = "block";
		img.innerHTML = '缩小';
	}
	else {
		obj.style.display = "none";
		img.innerHTML = '展开';
	}
}
