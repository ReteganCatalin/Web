<%--
  Created by IntelliJ IDEA.
  User: Catalin
  Date: 6/22/2020
  Time: 1:45 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html>
<head>
    <title>Assets</title>
    <style>

        body {
            margin: 0 auto;
            text-align: center;
        }

        form {
            display: flex;
            flex-direction: column;
        }

        table {
            margin: 0 auto;
        }

        td {
            border: 1px solid black;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script language="javascript">
        function printAllAssets(assets)
        {
            var content = "<table><tr><th>Name</th><th>Description</th><th>Value</th></tr> ";
            for (var asset of assets) {
                console.log(asset);
                if (asset.value >= 10) {
                    content += "<tr bgcolor='red'>";
                }
                else {
                    content += "<tr>";
                }
                content +=
                    "<td>" + asset.name + "</td>" +
                    "<td>" + asset.description + "</td>" +
                    "<td>" + asset.value + "</td>" +
                    "</tr>";
            }

            content += "</table>";
            $("#assetData").html(content);
        }
        $(document).ready(function () {
            {

                Array.prototype.pushArray = function (arr) {
                    this.push.apply(this, arr);
                };


                var assets = [];
                $(function () {
                    $.getJSON(
                        "AssetsServlet", {}, function (data, status) {
                            assets.pushArray(data);
                            printAllAssets(assets);
                        }
                    )
                });


                $("#addList").click(function () {
                    addAssetToList();
                    updateHistory();
                });
                $("#sendList").click(function () {
                    submitAdd();
                });

                names = [];
                descriptions = [];
                values = [];

                function clearInputs() {
                    $("#name").val("");
                    $("#description").val("");
                    $("#value").val("");
                }

                function updateHistory() {
                    tableString = "<table border='1'><tr><th>Name to add</th><th>Description to add</th><th>Value to add</th></tr>"
                    for (var i = 0; i < names.length; ++i) {
                        var name = names[i];
                        var description = descriptions[i];
                        var value = values[i];
                        tableString += "<tr>";
                        tableString += "<td>" + name + "</td>";
                        tableString += "<td>" + description + "</td>";
                        tableString += "<td>" + value + "</td>";
                        tableString += "</tr>";
                    }
                    tableString += "</table>";
                    $("#history").html(tableString);
                }

                function clearHistory() {
                    $("#history").html("");
                }

                function addAssetToList() {
                    var name = $("#name").val();
                    var description = $("#description").val();
                    var value = $("#value").val();
                    console.log(name, description, value);
                    clearInputs();
                    names.push(name);
                    descriptions.push(description);
                    values.push(value);
                }

                function submitAdd() {
                    var namesString = "";
                    var descriptionsString = "";
                    var valuesString = "";
                    for (var i = 0; i < names.length; ++i) {
                        if (i > 0) {
                            namesString += ",";
                            descriptionsString += ",";
                            valuesString += ",";
                        }
                        namesString += names[i];
                        valuesString += values[i];
                        descriptionsString += descriptions[i];
                    }
                    $.post(
                        "AssetsServlet",
                        {
                            names: namesString,
                            descriptions: descriptionsString,
                            values: valuesString
                        },
                        function (data) {
                            console.log("success submit");
                            clearHistory();
                            location.href="assets.jsp";
                        }
                    );
                }
            }
        });</script>
</head>
<body>

<p>Add an asset</p>
<section id="assetData"></section>
<br>
<input placeholder="name" id="name" />
<br>
<input placeholder="description" id="description" />
<br>
<input placeholder="value" id="value" />
<br>
<button id="addList">Add to list</button>
<br>
<button id="sendList">Submit all added assets</button>
<br>
<br>
History <br>
<section id="history"></section>
</body>
