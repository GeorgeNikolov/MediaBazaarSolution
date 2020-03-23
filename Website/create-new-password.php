<?php require_once('helpers/functions.php') ?>
<?php require_once('helpers/db.php') ?>
<?php
  if (isset($_POST['submit'])) {
    $selector = $_POST['selector'];
    $validator = $_POST['validator'];
    $password = $_POST['password'];

    $currentDate = date("U");

    $sql = "SELECT * FROM passwordreset WHERE passwordResetSelector=? AND passwordResetExpires >= '$currentDate'";
    $stmt = $con->prepare($sql);
    $stmt->execute([$selector]);
    $row = $stmt->fetch(PDO::FETCH_ASSOC);
    
    $tokenBin = hex2bin($validator);
    $tokenCheck = password_verify($tokenBin, $row['passwordResetToken']);

    if ($tokenCheck == false) {
      echo "You need to resubmit your reset request";
      exit();
    } else if ($tokenCheck == true) {
      $tokenEmail = $row['passwordResetEmail'];

      $sql = "UPDATE employee SET password=? WHERE email='$tokenEmail'";
      $stmt = $con->prepare($sql);
      $stmt->execute([md5($password)]);

      Redirect_to('index.php');
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
        <img src="img/logo.png" alt="">
        <h2>Enter new password</h2>

        <?php
          $selector = $_GET['selector'];
          $validator = $_GET['validator'];

          if (empty($selector) || empty($validator)) {
            echo "Could not validate request!";
          } else {
            if (ctype_xdigit($selector) && ctype_xdigit($validator)) {

         ?>


        <form class="" action="create-new-password.php" method="post" onsubmit="return checkPassword()">
          <p>
            <input type="hidden" name="selector" value="<?php echo $selector ?>">
          </p>
          <p>
            <input type="hidden" name="validator" value="<?php echo $validator ?>">
          </p>
          <p>
            <label for="password">New Password</label>
            <input type="password" name="password" value="" id="password">
          </p>
          <div id="password-error" class="error"></div>
          <p>
            <label for="password2">Confirm Your Password</label>
            <input type="password" name="password2" value="" id="password2">
          </p>
          <div id="password2-error" class="error"></div>
          <p>
            <input type="submit" name="submit" value="Reset Password">
          </p>
        </form>
      <?php } } ?>
    </div>
  </section>
  </body>
</html>
