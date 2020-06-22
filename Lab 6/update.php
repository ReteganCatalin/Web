<?php
include('db/connection.php');

$id = $_POST['id'];
$title = $_POST['title'];
$genre = $_POST['genre'];
$location = $_POST['location'];
$format = $_POST['format'];


$con = OpenConnection();
$sql = "UPDATE multimedia.media SET title='" . $title ."', format='".$format ."',genre='".$genre."', location='".$location."' WHERE id=".$id.";" ;
$con->query($sql);
if ($con->affected_rows== 1) {
	echo "Record updated successfully";
} else {
	echo "Error: " . $sql . "<br>" . $con->error;
}
	


    CloseConnection($con);


?>
