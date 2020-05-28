<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php require_once('helpers/functions.php'); ?>
<?php require_once('includes/navbar.php'); ?>
<?php
  session_start();
  if (isset($_SESSION['employee_id'])) {
    $employee_id = $_SESSION['employee_id'];
  }

  function getNoteData() {
    global $con;
    global $employee_id;
    $res = $con->query("SELECT * FROM schedule WHERE employee_id = '$employee_id'");
    $date = 0;
    $time = 0;
    $task_name = "";
    while ($row = $res->fetch(PDO::FETCH_ASSOC)) {
        $id = $row['date'];
        $start_time = $row['start_time'];
        $end_time = $row['end_time'];
        $task_name = $row['task_name'];
        $status = $row['status'];
        $message = "From ".$start_time." to ".$end_time.": ".$task_name;
        $schedule_id = $row['schedule_id'];

        ?>
            <script type="text/javascript">
                schedule_post = {
                    id: <?php echo json_encode($id); ?>,
                    note_num: Math.floor(Math.random() * 5) + 1,
                    note: <?php echo json_encode($message); ?>,
                    status: <?php echo json_encode($status); ?>,
                    schedule_id: <?php echo json_encode($schedule_id); ?>,
                }

                schedule_posts.push(schedule_post);
            </script>
    <?php }
  }
  ?>

<main>
  <section id="schedule">
    <div id="calendar">
        <table class="schedule-table">
            <thead class="color">
                <tr>
                    <th colspan="7" class="border-color">
                        <h4 id="cal-year">2020</h4>
                        <div>
                            <i class="fa fa-caret-left icon" onclick="previousMonth();"></i>
                            <h3 id="cal-month">July</h3>
                            <i class="fa fa-caret-right icon" onclick="nextMonth();"></i>
                        </div>
                    </th>
                </tr>

                <tr>
                    <th class="weekday border-color">Sun</th>
                    <th class="weekday border-color">Mon</th>
                    <th class="weekday border-color">Tue</th>
                    <th class="weekday border-color">Wed</th>
                    <th class="weekday border-color">Thu</th>
                    <th class="weekday border-color">Fri</th>
                    <th class="weekday border-color">Sat</th>
                </tr>
            </thead>
             
            <tbody id="table-body" class="border-color">
                <tr>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                </tr>
                <tr>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                </tr>
                <tr>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                </tr>
                <tr>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                </tr>
                <tr>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                </tr>
                <tr>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); "></td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                    <td class="td" onclick="dayClicked(this); ">1</td>
                </tr>
            </tbody>
            
        </table>
        
        <dialog id="modal">
        <div id="schedule-post">
            <div class="popup">
                <h4>Your schedule on <span id="current-selected-date"></span></h4>
                <!-- <textarea id="schedule-post-details" class="font" name="schedule-post-details"></textarea> -->
                <ul id="todo-list">
                    <!-- List of Todo's will be generated form js code -->
                </ul>
                <div>
                    <button class="button font got-it-button" id="got-it-button" onclick="gotItButtonClicked();">Got it!</button>
                    <button class="button font completed-todos-button" id="completed-todos-button" onclick="completedTodosButtonClicked();">Completed tasks (<span id="numCompletedTasks"></span>)</button>
                    <button class="button font undone-todos-button" id="undone-todos-button" onclick="undoneTodosButtonClicked();">Undone tasks (<span id="numUndoneTasks"></span>)</button>
                </div>
            </div>
        </div>
    </dialog>
    </div>

    

    
    
  </section>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="js/data.js"></script>
    <script type="text/javascript" src="js/date.js"></script>
    <script type="text/javascript" src="js/building_calendar.js"></script>
    <script type="text/javascript" src="js/modal.js"></script>
    <script type="text/javascript" src="js/reading_notes.js"></script>
    <?php getNoteData(); ?>
    <script type="text/javascript" src="js/start.js"></script>
    <script type="text/javascript" src="js/complete_button.js"></script>
</main>
  </body>
</html>