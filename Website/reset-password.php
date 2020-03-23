<?php require_once('helpers/functions.php') ?>
<?php require_once('helpers/db.php') ?>
<?php
  require_once('libs/Exception.php');
  require_once('libs/SMTP.php');
  require_once('libs/PHPMailer.php');

  use PHPMailer\PHPMailer\PHPMailer;
 ?>
<?php
  if (isset($_POST['submit'])) {
    $selector = bin2hex(random_bytes(8));
    $token = random_bytes(32);

    $url = "http://i411472.hera.fhict.nl/create-new-password.php?selector=".$selector."&validator=".bin2hex($token);

    $expires = date("U") + 1800;

    $email = $_POST['email'];

     $sql = "DELETE FROM passwordreset WHERE passwordResetEmail=?";
     $stmt = $con->prepare($sql);
     $stmt->execute([$email]);

     $sql = "INSERT INTO passwordreset (passwordResetEmail, passwordResetSelector, passwordResetToken, passwordResetExpires) VALUES (?, ?, ?, ?)";
     $hashed_token = password_hash($token, PASSWORD_DEFAULT);
     $stmt = $con->prepare($sql);
     $stmt->execute([$email, $selector, $hashed_token, $expires]);

     $recipient = $email;
     $subject = 'Reset Your Password For LogiK';
     $message = '<p>Hello there! It seems that you have forgotten your password. We know how to help you for that.</p>';
     $message .= '<p>Click here to reset your password: </br>';
     $message .= '<a href="' . $url . '">' . $url . '</a></p>';

     $headers = "From: LogiK <i411472@hera.fhict.nl>\r\n";
     $headers .= "Reply-To: i411472@hera.fhict.nl\r\n";
     $headers .= "Content-type: text/html\r\n";


     // if (mail('doannguyenthanhkhoa2112@gmail.com', 'Testing email subject', 'Here is message')){
     //   echo "Success";
     // }

     $mail = new PHPMailer();
     $mail->IsSMTP();

     //$mail->SMTPDebug = 2;
     $mail->Host = "smtp.gmail.com";
     $mail->Port = 587;
     $mail->SMTPSecure = "tls";
     $mail->SMTPAuth = true;
     $mail->Username = "khoadoan2k@gmail.com";
     $mail->Password = "mypasswordis12345";
     $mail->SetFrom("khoadoan2k@gmail.com", "LogiK");
     $mail->AddReplyTo("khoadoan2k@gmail.com", "Reply");
     $mail->AddAddress($recipient, "recipient");
     $mail->Subject = $subject;
     $mail->isHTML(true);
     $mail->Body = $message;

     if ($mail->Send()) {
       $_POST['reset'] = "success";
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
        <h2>Reset Your Password</h2>
        <p class="reset-desc">Forgot your password ?No worry, we will send a special code to your email so that you can reset your password!</p>
        <form class="" action="reset-password.php" method="post" onsubmit="return checkEmail()">
          <p>
            <label for="email">Email</label>
            <input type="email" name="email" value="" id="email">
          </p>
          <div id="email-error" class="error"></div>
          <p>
            <input type="submit" name="submit" value="Receive new password by email">
          </p>
          <?php
            if (isset($_POST['reset'])) {
              echo '<p class="success">
                Successfully requested. Check your email!
              </p>';
            }
           ?>

        </form>

    </div>
  </section>
  </body>
</html>
