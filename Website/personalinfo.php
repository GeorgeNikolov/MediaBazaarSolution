<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php require_once('includes/navbar.php'); ?>

<?php
  session_start();
  if (isset($_SESSION)) {
    $employee_id = $_SESSION['employee_id'];
    $sql = "SELECT * FROM employee WHERE employee_id = '$employee_id'";
    $stmt = $con->query($sql);
    $res = $stmt->fetch(PDO::FETCH_ASSOC);
    $first_name = $res['first_name'];
    $last_name = $res['last_name'];
    $username = $res['username'];
    $email = $res['email'];
    $phone = $res['phone'];
    $address = $res['address'];
    $image = $res['image'];
  }

  if (isset($_POST['submit'])) {
    $username = $_POST['username'];
    $first_name = $_POST['first-name'];
    $last_name = $_POST['last-name'];
    $phone = $_POST['phone'];
    $email = $_POST['email'];
    $address = $_POST['address'];

    $sql = "UPDATE employee SET username=?, first_name=?, last_name=?, phone=?, email=?, address=? WHERE employee_id='$employee_id'";
    $stmt = $con->prepare($sql);
    $res = $stmt->execute([$username, $first_name, $last_name, $phone, $email, $address]);
    if ($res) {
      $_POST['success'] = 'Successfully Updated!';
    }
  }

  if (isset($_POST['submit-avatar'])) {
    $image = $_FILES['image']['name'];
    $target    = "img/".basename($_FILES['image']['name']);
    $sql = "UPDATE employee SET image=?";
    $stmt = $con->prepare($sql);
    $res = $stmt->execute([$image]);

    if ($res) {
      move_uploaded_file($_FILES['image']['tmp_name'], $target);
      $_POST['success'] = "Successfully Updated";
    }
  }

 ?>
<main>
    <section id="personal-info">
      <div class="profile">
        <img src="<?php if ($image != ""){echo "img/".$image;} else {echo "img/default-avatar.png";} ?>" alt="LOGO">
        <h3>Username: <?php echo $username; ?></h6>
        <h3><?php echo $first_name." ".$last_name; ?></h6>
        <h4>Change your profile image</h4>
        <form class="" action="personalinfo.php" method="post" enctype="multipart/form-data">
          <input type="File" name="image" value=""> <br>
          <input type="submit" name="submit-avatar" value="Change Image">
        </form>
      </div>
      <div id="details">
        <form class="" action="personalinfo.php" method="post" onsubmit="return checkUpdateInfo()">
          <p>
            <label for="username">Username</label>
            <input type="text" name="username" value="<?php echo $username; ?>" id="username">
          </p>
          <div id="username-error" class="error"></div>
          <p>
            <label for="first-name">First Name</label>
            <input type="text" name="first-name" value="<?php echo $first_name; ?>" id="first-name">
          </p>
          <div id="first-name-error" class="error"></div>
          <p>
            <label for="last-name">Last Name</label>
            <input type="text" name="last-name" value="<?php echo $last_name; ?>" id="last-name">
          </p>
          <div id="last-name-error" class="error"></div>
          <p>
            <label for="phone">Phone</label>
            <input type="text" name="phone" value="<?php echo $phone; ?>" id="phone">
          </p>
          <div id="phone-error" class="error"></div>
          <p>
            <label for="email">Email</label>
            <input type="text" name="email" value="<?php echo $email; ?>" id="email">
          </p>
          <div id="email-error" class="error"></div>
          <p>
            <label for="address">Address</label>
            <input type="text" name="address" value="<?php echo $address ?>" id="address">
          </p>
          <div id="address-error" class="error"></div>
          <p>
            <input type="submit" name="submit" value="Update Changes">
          </p>
          <div id="success-message" class="success">
            <?php
              if (isset($_POST['success'])) {
                echo $_POST['success'];
              }
             ?>
          </div>
        </form>
      </div>
            </section>
            </main>
  </body>
</html>
