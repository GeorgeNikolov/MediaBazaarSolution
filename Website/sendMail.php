<?php require_once('helpers/db.php'); ?>

<?php
    session_start();
    if (isset($_SESSION['employee_id'])) {
      $employee_id = $_SESSION['employee_id'];
    }

    date_default_timezone_set('Europe/Amsterdam');

    //Get the schedule id from the get method
    $receiver = $_POST["receiver"];
    $subject = $_POST["subject"];
    $content = $_POST["content"];

    $date = date('d/m/Y h:i', time());
    
    $query = "INSERT INTO mail SET subject = ?, content = ?, date = '$date', sender = '$employee_id', receiver = '$receiver'";

    $stmt = $con->prepare($query);
    $res = $stmt->execute([$subject, $content]);

    if($res) {
        echo "Yes";
    } else {
        echo "No";
    }
?>