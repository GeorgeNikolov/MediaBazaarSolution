<?php require_once('helpers/db.php'); ?>
<?php
    //Get the schedule id from the get method
    $sid = $_REQUEST["sid"];
    
    $query = "UPDATE schedule SET status = 1 WHERE schedule_id = '$sid'";
    $res = $con->query($query);

    if($res) {
        echo "Yes";
    } else {
        echo "No";
    }
?>