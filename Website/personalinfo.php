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
    $first_name = $res["first_name"];
    $last_name = $res["last_name"];

    $username = $res['username'];
    $phone = $res['phone'];
    $address = $res['address'];
    $image = $res['image'];
  }

  if (isset($_POST['submit'])) {
    $username = $_POST['username'];
    $phone = $_POST['phone'];
    $address = $_POST['address'];

    $image = $_FILES['image']['name'];
    $target = "img/".basename($_FILES['image']['name']);

    $sql = "UPDATE employee SET username=?, phone=?, address=?, image=? WHERE employee_id='$employee_id'";
    $stmt = $con->prepare($sql);
    $res = $stmt->execute([$username, $phone, $address, $image]);
    if ($res) {
      $_POST['success'] = 'Successfully Updated!';
      move_uploaded_file($_FILES['image']['tmp_name'], $target);
    }
  }

 ?>
<main>
    <section id="personal-info">
      <div id="profile">
        <img src="<?php if ($image != ""){echo "img/".$image;} else {echo "img/default-avatar.png";} ?>" alt="LOGO">
        <h3><?php echo $first_name." ".$last_name; ?></h6>
        <h4>Change your profile image</h4>
        <form class="" action="personalinfo.php" method="post" enctype="multipart/form-data" onsubmit="checkUpdateInfo()">
          <input type="File" name="image" value=""> <br>

          <p>
            <label for="username">Username</label>
            <input type="text" name="username" value="<?php echo $username; ?>" id="username">
          </p>
          <div id="username-error" class="error"></div>
          
          <p>
            <label for="phone">Phone</label>
            <input type="text" name="phone" value="<?php echo $phone; ?>" id="phone">
          </p>
          <div id="phone-error" class="error"></div>
          
          <p>
            <label for="address">Address</label>
            <input type="text" name="address" value="<?php echo $address ?>" id="address">
          </p>
          <div id="address-error" class="error"></div>
          <input type="submit" name="submit" value="Update Changes" class="update-changes-btn">
        </form>
        <div class="success-message">
          <?php echo isset($_POST['success'])?$_POST['success']:"" ?>
        </div>
      </div>
    </section>
    </main>
  </body>
</html>
