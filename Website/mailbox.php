<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php require_once('includes/navbar.php'); ?>
<?php
    session_start();
    if (isset($_SESSION['employee_id'])) {
      $employee_id = $_SESSION['employee_id'];
    }

    function getMailReceived() {
        global $con;
        global $employee_id;
        $res = $con->query("SELECT m.mail_id, m.subject, e.first_name, e.last_name, m.content, m.date, m.status, m.deletedFromEmployee FROM mail m INNER JOIN employee e ON m.sender = e.employee_id WHERE m.receiver = '$employee_id' ORDER BY m.mail_id DESC");

        while ($row = $res->fetch(PDO::FETCH_ASSOC)) {
            $mail_id = $row["mail_id"];
            $subject = $row["subject"];
            $first_name = $row["first_name"];
            $last_name = $row["last_name"];
            $content = $row["content"];
            $date = $row["date"];
            $status = $row["status"];
            $deletedFromEmployee = $row["deletedFromEmployee"];
            $sender = $first_name." ".$last_name;
            ?>
                <script type="text/javascript">
                    receivedMail = {
                        mail_id: <?php echo json_encode($mail_id); ?>,
                        subject: <?php echo json_encode($subject); ?>,
                        content: <?php echo json_encode($content); ?>,
                        date: <?php echo json_encode($date); ?>,
                        status: <?php echo json_encode($status); ?>,
                        sender: <?php echo json_encode($sender); ?>,
                        deletedFromEmployee: <?php echo json_encode($deletedFromEmployee); ?>,
                        
                    }

                    receivedMails.push(receivedMail);
                    
                </script>
        <?php }
    }

    function getMailSent() {
        global $con;
        global $employee_id;
        $res = $con->query("SELECT m.mail_id, m.subject, e.first_name, e.last_name, m.content, m.date, m.status, m.deletedFromEmployee FROM mail m INNER JOIN employee e ON m.receiver = e.employee_id WHERE m.sender = '$employee_id' ORDER BY m.mail_id DESC");

        $res1 = $con->query("SELECT * FROM employee WHERE employee_id = '$employee_id'");
        $row1 = $res1->fetch(PDO::FETCH_ASSOC);
        $sender = $row1["first_name"]." ".$row1["last_name"];

        while ($row = $res->fetch(PDO::FETCH_ASSOC)) {
            $mail_id = $row["mail_id"];
            $subject = $row["subject"];
            $first_name = $row["first_name"];
            $last_name = $row["last_name"];
            $content = $row["content"];
            $date = $row["date"];
            $status = $row["status"];
            $deletedFromEmployee = $row["deletedFromEmployee"];
            $receiver = $first_name." ".$last_name;

            ?>
                <script type="text/javascript">
                    sentMail = {
                        mail_id: <?php echo json_encode($mail_id); ?>,
                        subject: <?php echo json_encode($subject); ?>,
                        content: <?php echo json_encode($content); ?>,
                        date: <?php echo json_encode($date); ?>,
                        status: <?php echo json_encode($status); ?>,
                        receiver: <?php echo json_encode($receiver); ?>,
                        sender: <?php echo json_encode($sender); ?>,
                        deletedFromEmployee: <?php echo json_encode($deletedFromEmployee); ?>,
                    }

                    sentMails.push(sentMail);
                </script>
        <?php }
    }

?>
<main>
    <section id="mailbox">
        <div class="mailbox-wrapper">
            <div id="inbox">
                <!-- Sidebar -->
                <div id="sidebar">
                    <!-- Sidebar compose -->
                    <div class="sidebar-compose">
                        <a href="#" class="compose-btn">
                            <span>Compose</span>
                            <i class="fa fa-plus-circle"></i>
                        </a>
                    </div>

                    <!-- Sidebar Inboxes -->
                    <ul id="sidebar-inboxes">
                        <!-- Inbox -->
                        <li class="">
                            <a href="#" onclick="fillReceivedMails(this);">
                                <i class="fa fa-inbox"></i>
                                Inbox
                                <span class="item-count-inbox"></span>
                            </a>
                        </li>

                        <!-- Sent -->
                        <li class=""> 
                            <a href="#" onclick="fillSentMails(this);">
                                <i class="fa fa-paper-plane"></i>
                                Sent 
                            </a>
                        </li>

                        <!-- Trash -->
                        <li class="">
                            <a href="#" onclick="fillDeletedMails(this);">
                                <i class="fa fa-trash"></i>
                                Trash
                                <span class="item-count-trash"></span>
                            </a>
                        </li>
                    </ul>
                </div>

                <!-- Inbox Container -->
                <div class="inbox-container">
                    <!-- Email list -->
                    <div class="email-list">
                        
                    </div>

                    <!-- Email content -->
                    <div class="email-content">
                        
                    </div>
                </div>
            </div>
        </div>
    </section>

</main>
    <script src="js/data.js"></script>
    <?php 
        getMailReceived(); 
        getMailSent();
    ?>
    <script src="js/display_inbox_mails.js"></script>
    <script src="js/display_sent_mails.js"></script>
    <script src="js/display_deleted_mails.js"></script>
</body>
</html>