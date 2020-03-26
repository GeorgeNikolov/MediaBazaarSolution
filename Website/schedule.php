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
      <tr>
        <td>Morning</td>
        <td>Jack</td>
        <td></td>
        <td>Jack</td>
        <td>Jack</td>
        <td></td>
      </tr>
      <tr>
        <td>Afternoon</td>
        <td>Jack</td>
        <td>Jack</td>
        <td></td>
        <td>Jack</td>
        <td>Jack</td>
      </tr>
      <tr>
        <td>Evening</td>
        <td></td>
        <td>Jack</td>
        <td>Jack</td>
        <td>Jack</td>
        <td></td>
      </tr>

    </table>
  </main>

  </body>
<?php require_once('includes/footer.php'); ?>
