<?php
include ('../db/connection.php');

$connection = OpenConnection();

$query = "SELECT * FROM multimedia.media";
$result = $connection->query($query);

if(mysqli_num_rows($result)>0){
    echo "<table>";
    echo "<thead>";
    echo "<th>ID</th>";
    echo "<th>Title</th>";
    echo "<th>Genre</th>";
    echo "<th>Format</th>";
    echo "<th>Location</th>";
    echo "</thead>";
    while ($row = mysqli_fetch_array($result)){
        echo "<tr>";
        echo "<th>".$row['id']."</th>";
        echo "<th>".$row['title']."</th>";
        echo "<th>".$row['genre']."</th>";
        echo "<th>".$row['format']."</th>";
        echo "<th>".$row['location']."</th>";
        echo "</tr>";
    }
    echo "</table>";

}

CloseConnection($connection);
?>
