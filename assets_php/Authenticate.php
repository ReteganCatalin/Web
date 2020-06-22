<?php
if(isset($_POST['submit'])) {
    include('dbConn.php');
    $userName = $_POST['username'];
    $pass = $_POST['pass'];
    $con = OpenConnection();
	$write="SELECT * From assets.users users where users.username='".$userName."' and users.password='".$pass."'";
	echo $write;
    $result =mysqli_query($con, $write);
    if ($row = mysqli_fetch_array($result)) {
        session_start();
        $_SESSION['user'] = $row['id'];
        CloseConnection($con);
        header("Location: assetsLOL.php");
    }
    CloseConnection($con);
}
?>
<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>Add File</title>
</head>
<body>
<h1>Login</h1>
<form method="post" action="Authenticate.php">
    <input type="text" name="username" placeholder="Enter username">
    <br>
    <input type="password" name = "pass" placeholder="Enter password">
    <br>
    <input type="submit" name="submit" value="Login">
</form>


</body>
</html>
