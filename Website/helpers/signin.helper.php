<?php require_once('db.php') ?>
<?php

  if (isset($_POST['username'], $_POST['password'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
  }


  $sql = "SELECT * FROM employee WHERE username=?";
  $stmt = $con->prepare($sql);
  $stmt->execute([$username]);

  if ($stmt->rowCount() == 0) {
    echo "username";
    exit();
  }

  $sql = "SELECT * FROM employee WHERE username=? AND password=?";
  $stmt = $con->prepare($sql);
  $stmt->execute([$username, md5($password)]);

  if ($stmt->rowCount() == 0) {
    echo "password";
    exit();
  }
 ?>
