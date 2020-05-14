<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php
  session_start();
  if (isset($_SESSION['employee_id'])) {
    $employee_id = $_SESSION['employee_id'];
  }
  $res = $con->query("SELECT * FROM schedule WHERE employee_id = '$employee_id'");
  $work_day = array();
  while ($row = $res->fetch(PDO::FETCH_ASSOC)) {
    array_push($work_day, $row['work_day_id']);
  }

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
      <tr>
        <td>Morning</td>
        <td><?php if(in_array(1, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(2, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(3, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(4, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(5, $work_day)){echo "X";} ?></td>
      </tr>
      <tr>
        <td>Afternoon</td>
        <td><?php if(in_array(6, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(7, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(8, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(9, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(10, $work_day)){echo "X";} ?></td>
      </tr>
      <tr>
        <td>Evening</td>
        <td><?php if(in_array(11, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(12, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(13, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(14, $work_day)){echo "X";} ?></td>
        <td><?php if(in_array(15, $work_day)){echo "X";} ?></td>
      </tr>

    </table>
  </main>

  </body>
<?php require_once('includes/footer.php'); ?>
