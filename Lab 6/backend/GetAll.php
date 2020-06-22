<?php
include ('../db/connection.php');
include ('../db/MediaFile.php');
try{
    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $con = OpenConnection();
        $sql ="SELECT * FROM multimedia.media";
        $result_set = $con->query($sql);
        $rows = array();
        while ($row = mysqli_fetch_array($result_set)) {
            $rows[] = new MediaFile($row['ID'],$row['Title'],$row['Format'],$row['Genre'],$row['Location']);

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