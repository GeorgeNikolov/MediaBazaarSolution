<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php require_once('includes/navbar.php'); ?>
<?php 

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
    // $missed_shifts_by_month = array();

    // for ($i = 1; $i <= 9; $i++) {
    //     $stmt = $con->query("SELECT COUNT(*) AS Count FROM schedule WHERE employee_id = '$employee_id' AND date LIKE '%\d{2}\/0'$i'\/\d{4}%' ");
        
    //     $res = $stmt->fetch(PDO::FETCH_ASSOC);
    //     array_push($missed_shifts_by_month, $res['Count']);
    // }

    // var_dump($missed_shifts_by_month);

?>
<main>
    <section id="statistics-section">

        <div class="stock-chart-container">
            <canvas id="stock-chart"></canvas>
        </div>
    </section>


</main>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels"></script>
<script>
    let stockChart = document.getElementById('stock-chart').getContext('2d');

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

</script>
</body>
</html>