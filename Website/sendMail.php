<?php require_once('helpers/db.php'); ?>

<?php
    session_start();
    if (isset($_SESSION['employee_id'])) {
      $employee_id = $_SESSION['employee_id'];
    }

    date_default_timezone_set('Europe/Amsterdam');

    //Get the schedule id from the get method
    $receiver = $_GET["receiver"];
    $subject = $_GET["subject"];
    $content = $_GET["content"];
    //Get the current timestammp from the country
    $date = date('m/d/Y h:i:s a', time());
    
    $query = "INSERT INTO mail SET subject = ?, content = ?, date = '$date', sender = '$employee_id', receiver = '$receiver'";

    $stmt = $con->prepare($query);
    $res = $stmt->execute([$subject, $content]);

    if($res) {
        echo "Yes";
    } else {
        echo "No";
    }
?>