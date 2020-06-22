<?php
include ('db/connection.php');

$con = OpenConnection();
$sql = "SELECT DISTINCT genre FROM multimedia.media";
$result_set = $con->query($sql);
$rows = array();
while ($row = mysqli_fetch_array($result_set, MYSQLI_NUM)) {
    $rows[] = $row[0];
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Multimedia Browser</title>
    <script type="text/javascript" src="browse.js"></script>
</head>
<body>

<label>
    <select name="Select Filter" onchange="get_filtered()">
        <?php
        foreach ($rows as $row) {
            echo "<option>$row</option>";
        }
        ?>
    </select>
</label>

<table>
    <thead>
    <th>Title</th>
    <th>Genre</th>
    <th>Format</th>
    <th>Location</th>
    </thead>
    <tbody>
    </tbody>
</table>