function jsonParse(text) {
    let json;
    try {
        json = JSON.parse(text);
    } catch (e) {
        return false;
    }
    return json;
}

function get_assets() {
    let ajax = new XMLHttpRequest();

    ajax.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            let table = document.getElementsByTagName("table")[0];
            let oldTableBody = document.getElementsByTagName("tbody")[0];
            let newTableBody = document.createElement('tbody');
            let json = jsonParse(this.responseText);
            for (let i = 0; i < json.length; i++) {
                let asset = json[i];
				console.log(asset);
                let row = newTableBody.insertRow();
                assetValue=parseInt(asset.value);
                if(assetValue>=10)
                {
                    row.bgColor="red";
                }

                Object.keys(asset).forEach(function (k) {
                    let text;
                    let cell = row.insertCell();
                    text = asset[k];
                    cell.appendChild(document.createTextNode(text));
                })
            }
            table.replaceChild(newTableBody, oldTableBody);
        }
    }
	console.log("here");
    ajax.open('GET', 'assets.php', true);
    ajax.send();
}
