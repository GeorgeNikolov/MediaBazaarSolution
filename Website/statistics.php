<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php require_once('includes/navbar.php'); ?>
<?php 

    session_start();
    $employee_id = $_SESSION['employee_id'];
    // Stock Items Statistic Queries
    $item_distribution = array();
    $item_names = array();

    $stmt = $con->query("SELECT category_name FROM category ORDER BY category_id");
    while($res = $stmt->fetch(PDO::FETCH_ASSOC)) {
        array_push($item_names, $res['category_name']);
    }

    $stmt = $con->query("SELECT COUNT(*) AS Count FROM depot_item GROUP BY category_id ORDER BY category_id");
    while($res = $stmt->fetch(PDO::FETCH_ASSOC)) {
        array_push($item_distribution, $res['Count']);
    }


    //Missed Shifts Statistics Queries
    $now = new DateTime('now');
    $month = $now->format('m');
    $year = $now->format('Y');
    $temp;
    
    // Get number of missed shifts by month
    $missed_shifts_by_month = array();

    for ($i = 1; $i <= 9; $i++) {
        $monthIdentifier = "'"."%0".$i."/".$year."'";
        $stmt = $con->query("SELECT COUNT(*) AS Count FROM schedule WHERE employee_id = '$employee_id' AND status = 0 AND date LIKE ".$monthIdentifier);
        $res= ($stmt->fetch(PDO::FETCH_ASSOC))['Count'];
        array_push($missed_shifts_by_month, $res);
    }

    for ($i = 10; $i <= 12; $i++) {
        $monthIdentifier = "'"."%".$i."/".$year."'";
        $stmt = $con->query("SELECT COUNT(*) AS Count FROM schedule WHERE employee_id = '$employee_id' AND status = 0 AND date LIKE ".$monthIdentifier);
        $res= ($stmt->fetch(PDO::FETCH_ASSOC))['Count'];
        array_push($missed_shifts_by_month, $res);
    }

    // Get number of completed shifts by month
    $completed_shifts_by_month = array();

    for ($i = 1; $i <= 9; $i++) {
        $monthIdentifier = "'"."%0".$i."/".$year."'";
        $stmt = $con->query("SELECT COUNT(*) AS Count FROM schedule WHERE employee_id = '$employee_id' AND status = 1 AND date LIKE ".$monthIdentifier);
        $res= ($stmt->fetch(PDO::FETCH_ASSOC))['Count'];
        array_push($completed_shifts_by_month, $res);
    }

    for ($i = 10; $i <= 12; $i++) {
        $monthIdentifier = "'"."%".$i."/".$year."'";
        $stmt = $con->query("SELECT COUNT(*) AS Count FROM schedule WHERE employee_id = '$employee_id' AND status = 1 AND date LIKE ".$monthIdentifier);
        $res= ($stmt->fetch(PDO::FETCH_ASSOC))['Count'];
        array_push($completed_shifts_by_month, $res);
    }


    
?>
<main>
    <section id="statistics-section">

        <div class="stock-chart-container">
            <canvas id="stock-chart"></canvas>
        </div>

        <div class="shifts-chart-container">
            <canvas id="shifts-chart"></canvas>
        </div>
    </section>


</main>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels"></script>
<script>
    let stockChart = document.getElementById('stock-chart').getContext('2d');
    let shiftsChart = document.getElementById('shifts-chart').getContext('2d');

    // Pie Chart for Stock Item Distribution
    let pieChart = new Chart(stockChart, {
        type: 'pie', 
        data: {
            labels: [
                <?php 
                    for ($i = 0; $i < count($item_names); $i++) {
                        if($i == count($item_names) - 1) {
                            echo "'".$item_names[$i]."'";
                        } else {
                            echo "'".$item_names[$i]."'".', ';
                        }
                    }
                ?>
            ],
            datasets: [{
                label: 'Items Distribution', 
                data: [
                    <?php 
                        for ($i = 0; $i < count($item_names); $i++) {
                            if ($i == count($item_names) - 1) {
                                echo $item_distribution[$i];
                            } else {
                                echo $item_distribution[$i].', ';
                            }
                        }
                    ?>
                ],
                //backgroundColor: 'white'
                backgroundColor: [
                    'rgba(54, 162, 235, 0.6)',
                    'rgba(255, 99, 132, 0.6)',
                    'rgba(255, 206, 86, 0.6)',
                    'rgba(75, 192, 192, 0.6)',
                    'rgba(153, 102, 255, 0.6)',
                    'rgba(255, 159, 64, 0.6)',
                    'rgba(176, 245, 66, 0.6)',
                    'rgba(66, 123, 245, 0.8)',
                    'rgba(245, 66, 66, 0.8)'
                ],
                borderWidth: 1.5,
                borderColor: '#777',
                hoverBorderWidth: 3,
                hoverBorderColor: '#000'
            }]

        },
        options: {
            title: {
                display: true,
                text: 'Stock Items Distribution',
                fontSize: 30,
                fontColor: '#000'
            },
            legend: {
                position: 'right',
                labels: {
                    fontColor: '#000'
                }
            }
        }
    });

    // Bar chart for missed shifts and completed shifts comparison
    let barChart = new Chart(shiftsChart, {
        type: 'bar',

        data: {
            labels: ["January", "February", "March", "April", "May", "June", "September", "October", "November", "December"],
            datasets: [{
                label: "Missed Shifts",
                backgroundColor: 'rgba(245, 66, 66, 0.7)',
                borderWidth: 2,
                borderColor: 'rgba(245, 66, 66, 1.2)',
                hoverBorderColor: '#000',
                hoverBorderWidth: 3,
                data: [
                    <?php 
                        for ($i = 0; $i < 12; $i++) {
                            if ($i == 11){
                                echo $missed_shifts_by_month[$i];
                            } else {
                                echo $missed_shifts_by_month[$i].', ';
                            }
                        }
                    ?>
                ]
            }, {
                label: "Completed Shifts",
                backgroundColor: 'rgba(60, 179, 113, 0.7)',
                borderWidth: 2,
                borderColor: 'rgba(176, 245, 66, 1.2)',
                hoverBorderColor: '#000',
                hoverBorderWidth: 3,
                data: [
                    <?php 
                        for ($i = 0; $i < 12; $i++) {
                            if ($i == 11){
                                echo $completed_shifts_by_month[$i];
                            } else {
                                echo $completed_shifts_by_month[$i].', ';
                            }
                        }
                    ?>
                ]
            }
            
            ]
        },

        options: {
            title: {
                display: true,
                text: 'Missed & Completed Shifts Comparison',
                fontSize: 30,
                fontColor: '#000'
            },
            legend: {
                position: 'bottom',
                labels: {
                    fontColor: '#000'
                }
            }
        }
    });

</script>
</body>
</html>