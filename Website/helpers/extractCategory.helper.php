<?php require_once('db.php'); ?>
<?php
  $category = $_GET['category'];
  if ($category !== "") {
    $sql = "SELECT * FROM depot_item WHERE category_id = $category";
    $stmt = $con->query($sql);
    echo "<table>";
    echo "<tr>";
    echo "<th>ID</th>";
    echo "<th>Name</th>";
    echo "<th>Amount</th>";
    echo "<th>Category</th>";
    echo "<th>Price</th>";
    echo "</tr>";
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
      echo "<tr>";
      echo "<td>".$row['item_id']."</td>";
      echo "<td>".$row['item_name']."</td>";
      echo "<td>".$row['amount']."</td>";
      $sql1 = "SELECT category_name FROM category WHERE category_id = '$category'";
      $stmt1 = $con->query($sql1);
      $res = $stmt1->fetch(PDO:: FETCH_ASSOC);
      echo "<td>".$res['category_name']."</td>";
      echo "<td>".$row['price']."</td>";
      echo "</tr>";
    }

    echo "</table>";
  }

 ?>
