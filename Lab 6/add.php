<!DOCTYPE html>
<html>
<?php
if(isset($_POST['submit'])) {
    include('db/connection.php');
    $title = $_POST['title'];
    $genre = $_POST['genre'];
    $location = $_POST['location'];
    $format = $_POST['format'];


    $con = OpenConnection();
    $sql = "INSERT into multimedia.media (title,format,genre,location) values('" . $title ."','".$format ."','".$genre."','".$location."')" ;
    $con->query($sql);
    if ($con->affected_rows == 1) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $con->error;
    }


    CloseConnection($con);
}
?>
<head>
	<meta charset="UTF-8">
    <title>Add File</title>
</head>
<body>
<h1>ADD FILE</h1>
<form method="post" action="add.php">
    <input type="text" name="title" placeholder="Enter title">
    <br>
    <input type="text" name = "genre" placeholder="Enter genre">
    <br>
    <input type="text" name="location" placeholder="Enter location">
    <br>
    <input type="text" name = "format" placeholder="Enter format">
    <br>
    <input type="submit" name="submit" value="Add file">
</form>


</body>
</html>