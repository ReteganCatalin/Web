<?php
if(isset($_POST['submit'])) {
    include('db/connection.php');
    $id = $_POST['id'];
    $con = OpenConnection();
    $sql = "DELETE FROM multimedia.media WHERE id='" . $id."';" ;
    $con->query($sql);
    if ($con->affected_rows == 1) {
        echo "Deleted a record successfully";
    } else if($con->affected_rows == 0 )
    {
        echo "No records with that id";
    }
    else
    {
        echo "Error: " . $sql . "<br>" . $con->error;
    }
    CloseConnection($con);
}

?>
<!DOCTYPE html>
<html>
<head>
    <title>DELETE File</title>
</head>
<body>
<h1>DELETE FILE</h1>
<form method="post" action="delete.php">
    <input type="text" name = "id" placeholder="Enter id">
    <br>
    <input type="submit" name="submit" value="Delete file">
</form>


</body>
</html>
