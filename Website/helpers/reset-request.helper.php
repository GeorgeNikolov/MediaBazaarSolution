<?php
  require_once('db.php');

  if (isset($_POST['email'])) {
    $email = $_POST['email'];
  }

  $sql = 'SELECT * FROM employee WHERE email=?';
  $stmt = $con->prepare($sql);
  $stmt->execute([$email]);

  if ($stmt->rowCount() == 0) {
    echo "email";
    exit();
  }
 ?>
