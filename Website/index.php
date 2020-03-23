<?php require_once('helpers/functions.php') ?>
<?php require_once('helpers/db.php') ?>
<?php
  if (!isset($_SESSION)) {
    session_start();
  }

  if (isset($_COOKIE['employee_id'])) {
    $_SESSION['employee_id'] = $_COOKIE['employee_id'];
    Redirect_to('schedule.php');
  }

 ?>

 <?php
    if (isset($_POST['submit'])) {
      $username = $_POST['username'];
      $sql = "SELECT * FROM employee WHERE username='$username'";
      $stmt = $con->query($sql);
      $res = $stmt->fetch(PDO::FETCH_ASSOC);

      $_SESSION['employee_id'] = $res['employee_id'];

      if (isset($_POST['cbx-remember-me'])) {
        $hour = time() + 3600 * 24 * 30;
        setcookie('employee_id', $res['employee_id'], $hour);
      }

      if ($res['employee_type'] == 'employee') {
        Redirect_to('schedule.php');
      } else if ($res['employee_type'] == 'manager') {
        Redirect_to('personalinfo.php');
      }
    }
  ?>

<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Page</title>
    <link rel="stylesheet" href="css/style.css">
    <script type="text/javascript" src="js/scripts.js"></script>
  </head>

  <body>

  <section id="login">
      <div class="login-system-wrapper">
        <img src="./img/logo.png" alt="">
        <h2>Login To LogiK!</h2>
        <form class="" action="index.php" method="post" onsubmit="return checkSignIn()">
          <p>
            <label for="username">Username</label>
            <input type="text" name="username" value="" id="username">
          </p>
          <div id="username-error" class="error"></div>
          <p>
            <label for="password">Password</label>
            <input type="password" name="password" value="" id="password">
          </p>
          <div id="password-error" class="error"></div>
          <p>
            <input type="checkbox" name="cbx-remember-me" value="" id="cbx-remember-me">
            <label for="cbx-remember-me">Remember Me</label>
          </p>
          <p>
            <input type="submit" name="submit" value="Login">
          </p>
        </form>
        <a href="reset-password.php" class="link">Forgot Your Password?</a>
    </div>
  </section>
  </body>
  <?php require_once('includes/footer.php') ?>
</html>
