<?php
function OpenConnection(): mysqli
{
    $dbhost = "127.0.0.1";
    $dbusername = "catalin";
    $dbpassword = "1234cata";
    $dbname = "assets";

    return mysqli_connect($dbhost, $dbusername, $dbpassword, $dbname);
}

function CloseConnection(mysqli $con)
{
    $con->close();
}
?>
