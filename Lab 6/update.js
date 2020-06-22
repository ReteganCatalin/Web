function jsonParse(text) {
    let json;
    try {
        json = JSON.parse(text);
    } catch (e) {
        return false;
    }
    return json;
}

function update() {
    let ajax = new XMLHttpRequest();

    ajax.onreadystatechange = function () {
		console.log("here")
        if (this.readyState === 4 && this.status === 200) {
            let table = document.getElementsByTagName("table")[0];
            let oldTableBody = document.getElementsByTagName("tbody")[0];
            let newTableBody = document.createElement('tbody');
            let json = jsonParse(this.responseText);
            for (let i = 0; i < json.length; i++) {
                let mediaFile = json[i];
				var buttonID =document.createElement("button");
                let row = newTableBody.insertRow();
				var txt = document.createTextNode("Update")
				buttonID.appendChild(txt)
				row.insertCell().appendChild(buttonID);
                Object.keys(mediaFile).forEach(function (k) {
                    let text;
                    let cell = row.insertCell();
                    text = mediaFile[k];
                    cell.appendChild(document.createTextNode(text));
                })
				buttonID.addEventListener("click",function()
				{
					console.log(mediaFile[0]);
					let id=mediaFile['id'];
					let title=document.getElementById("titleInp").value;
					let format=document.getElementById("formatInp").value;
					let genre=document.getElementById("genreInp").value;
					let locationIn=document.getElementById("locationInp").value;
					$.ajax({
						type: "POST",
						url: "update.php",
						data: {id: id, title: title, 'location': locationIn, genre:genre,format:format},
						success: function(data, status) {
							$("#result").html(data);
					}
				});
					let json = JSON.stringify({'id': id,'title':title,'format':format,'location':locationIn,'genre':genre});
					console.log(json);
					ajax.send(json);
					window.location.href = 'update.html';
					
				})
            }
            table.replaceChild(newTableBody, oldTableBody);
        }
    }
    ajax.open('POST', 'backend/GetAll.php', true);
    ajax.send();
}