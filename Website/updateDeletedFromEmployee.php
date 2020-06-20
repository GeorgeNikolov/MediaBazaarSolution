<?php require_once('helpers/db.php'); ?>
<?php
    $mail_id = $_REQUEST["mid"];
    $query = "UPDATE mail SET deletedFromEmployee = 1 WHERE mail_id = '$mail_id'";
    $res = $con->query($query);

    if ($res) {
        echo "Yes";
    } else {
        echo "No";
    }

?>