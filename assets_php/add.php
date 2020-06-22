<?php
include('dbConn.php');
session_start();
$names = $_POST['names'];
$descriptions = $_POST['descriptions'];
$values = $_POST['values'];
$userID=$_SESSION['user'];

$con = OpenConnection();
$n = sizeof($names);
for ($i = 0; $i < $n; ++$i) {
	$name = $names[$i];
	$description = $descriptions[$i];
	$value = $values[$i];
	$sql = "INSERT into assets.assets (name,userID,description,value) values('" . $name ."','".$userID ."','".$description."','".$value."')" ;
	echo $sql;
	$con->query($sql);
}
CloseConnection($con);        
?>
		
	