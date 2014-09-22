CookieKey = "comparisionDataList__"

function getCookie(name) {

    var start = document.cookie.indexOf(name + "=");

    var len = start + name.length + 1;

    if ((!start) && (name != document.cookie.substring(0, name.length))) {

        return null;

    }

    if (start == -1) return null;

    var end = document.cookie.indexOf(';', len);

    if (end == -1) end = document.cookie.length;

    return unescape(document.cookie.substring(len, end));

}



function setCookie(name, value, expires, path, domain, secure) {

    var today = new Date();

    today.setTime(today.getTime());

    if (expires) {

        expires = expires * 1000 * 60 * 60 * 24;

    }

    var expires_date = new Date(today.getTime() + (expires));

    document.cookie = name + '=' + escape(value) +

((expires) ? ';expires=' + expires_date.toGMTString() : '') + //expires.toGMTString()

((path) ? ';path=' + path : '') +

((domain) ? ';domain=' + domain : '') +

((secure) ? ';secure' : '');

}



function deleteCookie(name, path, domain) {

    if (getCookie(name)) document.cookie = name + '=' +

((path) ? ';path=' + path : '') +

((domain) ? ';domain=' + domain : '') +

';expires=Thu, 01-Jan-1970 00:00:01 GMT';

}

function GetComparisionList() {
    return getCookie(CookieKey);
}


function SetHistoryItemIdentification(id, gtin) {
    if (id == null || id == "" || gtin == null || gtin == "") {
        alert("添加失败，历史版本ID、GTIN不能为空");
        return false;
    }

    value = getCookie(CookieKey);
    newValue = id + "_" + gtin + "|";
    if (value != null) {
        valueList = value.split('|');
        //判断数据在列表中是否已经存在，如果存在则返回
        for (i = 0; i < valueList.length; i++) {
            if (newValue == valueList[i] + "|") {
                alert("添加失败，比较列表中已经存在此数据");
                return false;
            }
        }
        value += newValue;
    }
    else {
        value = newValue;
    }
    setCookie(CookieKey, value, 0.5, "/", null, null);
    alert("添加成功");
    return true;
}

//
function DeleteHistoryItemIdentification(id, gtin) {
    value = getCookie(CookieKey);
    newValue = id + "_" + gtin + "|";

    if (value != null) {
        value = value.replace(newValue, "");
        setCookie(CookieKey, value, 0.05, "website1", null, null);
    }
}

//提交的比较数据的页面
function SubmitComparision(Address) {
    value = getCookie(CookieKey);
    if (value) {
        window.open("http://" + Address + "?HistoryItem=" + value);
    }
    else {
        alert("没有可比较的数据");
    }

}

function InsertRow(table) {
    for (i = table.rows.length - 1; i > 0; i--) {
        table.deleteRow(i);
    }

    value = getCookie(CookieKey);
    if (!value) {
        return;
    }
    valueList = value.split('|');
    for (i = 0; i < valueList.length; i++) {
        if (!valueList[i]) {
            return;
        }
        row = table.insertRow();

        cell = row.insertCell();
        cell.innerHTML = table.rows.length - 1;

        KeyValue = valueList[i].split('_');

        cell = row.insertCell();
        if (KeyValue.length > 0) {
            cell.innerHTML = KeyValue[0];
        }

        cell = row.insertCell();
        if (KeyValue.length > 1) {
            cell.innerHTML = KeyValue[1];
        }
        cell = row.insertCell();
        cell.innerHTML = "<img src='../Images/dbl_18.gif' class='img_b' onclick='deleteComparision(" + table.id + ",\"" + KeyValue[0] + "\", \"" + KeyValue[1] + "\");' name=btn'+i+' />";
        //"<input type=button onclick='deleteComparision(" + table.id + ",\"" + KeyValue[0] + "\", \"" + KeyValue[1] + "\");' name=btn'+i+' class='delete' value='删除'  title='Delete Row'  />";

    }
}

