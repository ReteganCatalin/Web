<?php
if(isset($_POST['submit'])) {
    include('db/connection.php');
    $id = $_POST['id'];
    $title = $_POST['title'];
    $genre = $_POST['genre'];
    $location = $_POST['location'];
    $format = $_POST['format'];


    $con = OpenConnection();
    $sql = "INSERT into multimedia.media values(" . $id . ",'" . $title .",'".$format .",'".$genre.",'".$location.")" ;
    $query = mysqli_query($con, $sql);

    CloseConnection($con);
}

?>
<!DOCTYPE html>
<html>
<head>
    <title>Add File</title>
</head>
<body>
<h1>ADD FILE</h1>
<form method="post" action="add.php">
    <input type="text" name = "id" placeholder="Enter id">
    <br>
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