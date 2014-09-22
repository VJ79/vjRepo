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
		window.alert("�����������֧�ִ˹��ܣ�");
	}
}

function addFavorite() {
	try {
		window.external.addFavorite(location.href, document.title);
	} catch (e) {
		window.alert("�����������֧�ִ˹��ܣ�");
	}
}

function switch_state(img, obj) {
	if (obj.style.display == "none") {
		obj.style.display = "block";
		img.innerHTML = '��С';
	}
	else {
		obj.style.display = "none";
		img.innerHTML = 'չ��';
	}
}
