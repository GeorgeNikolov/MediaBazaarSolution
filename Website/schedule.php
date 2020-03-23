<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php
  session_start();
  if (isset($_SESSION['employee_id'])) {
    $employee_id = $_SESSION['employee_id'];
  }
  $shift = array("Morning", "Afternoon", "Evening");
  $date = array("Monday", "Tuesday", "")
 ?>


  <main id="schedule">
    <table>
      <tr>
        <th>Day Time</th>
        <th>Monday</th>
        <th>Tuesday</th>
        <th>Wednesday</th>
        <th>Thursday</th>
        <th>Friday</th>
      </tr>
      <?php

        for ($i = 0; $i < count($shift); ++$i) {
          $dateToWork = array();
          $sql = "SELECT w.date FROM work_day w INNER JOIN employee_work_day_int e ON e.employee_id = w.employee_id AND e.employee_id = '$employee_id' AND w.shift = '$shift[$i]'";
          $stmt = $con->query($sql);

          while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
            array_push($dateToWork, $row['date']);
          }
      ?>
      <tr>
        <td><?php echo $shift[$i]; ?></td>

      </tr>
      <?php
    }
       ?>
    </table>
  </main>

  </body>
<?php require_once('includes/footer.php'); ?>
