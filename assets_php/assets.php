<?php
include ('dbConn.php');
include ('AssetsClass.php');
try{
	session_start();
    if ($_SERVER['REQUEST_METHOD'] === 'GET') {
        $con = OpenConnection();
        $user = $_SESSION['user'];
        $sql ="SELECT * FROM assets.assets assets WHERE  assets.userID= '".$user."'";
        $result_set = $con->query($sql);
        $rows = array();
        while ($row = mysqli_fetch_array($result_set)) {
            $rows[] = new AssetsClass($row['id'],$row['userID'],$row['description'],$row['value'],$row['name']);

        }
        header('HTTP/1.1 200 OK');
        echo json_encode($rows);
        CloseConnection($con);
        exit;
    }
} catch (Exception $e) {
    echo json_encode(
        array(
            'status' => false,
            'error' => $e->getMessage(),
            'error_code' => $e->getCode()
        )
    );

    exit;
}
