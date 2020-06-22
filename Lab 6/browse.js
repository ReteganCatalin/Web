function jsonParse(text) {
    let json;
    try {
        json = JSON.parse(text);
    } catch (e) {
        return false;
    }
    return json;
}

function get_filtered() {
    let ajax = new XMLHttpRequest();

    ajax.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            let table = document.getElementsByTagName("table")[0];
            let oldTableBody = document.getElementsByTagName("tbody")[0];
            let newTableBody = document.createElement('tbody');
            let json = jsonParse(this.responseText);
            for (let i = 0; i < json.length; i++) {
                let mediaFile = json[i];
                let row = newTableBody.insertRow();
                Object.keys(mediaFile).forEach(function (k) {
                    let text;
                    let cell = row.insertCell();
                    text = mediaFile[k];
                    cell.appendChild(document.createTextNode(text));
                })
            }
            table.replaceChild(newTableBody, oldTableBody);
        }
    }
    ajax.open('POST', 'backend/getAllFilesByGenre.php', true);
    let genre = document.getElementsByTagName("select")[0].value;
    let json = JSON.stringify({'genre': genre});
    ajax.send(json);
}