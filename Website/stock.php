<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php require_once('includes/navbar.php'); ?>
  <main>
  <div class="side-search">
    <form class="side-search-form" method="post">
      <input id="id-input" type="text" onkeyup="searchID()" placeholder="Search by ID">
      <br><br>
    </form>
    <div id="id-error" class="error">
      <form class="side-search-form" method="post">
        <input id="name-input" type="text" onkeyup="searchName()" placeholder="Search by name">
        <br><br>
      </form>
      <div id="id-error" class="error">

    </div>
    <select name="categories" onchange="showCategory(this.value)">
      <option value="">Select a category:</option>
      <?php
        $res = $con->query("SELECT * FROM category");
        while($row = $res->fetch(PDO::FETCH_ASSOC)) {
       ?>
      <option value="<?php echo $row['category_id'] ?>"><?php echo $row['category_name']; ?></option>
    <?php } ?>
    </select>
  </div>
  <div id="stock">
    <table id="table-search">
      <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Amount</th>
        <th>Category</th>
        <th>Price</th>
      </tr>
      <?php
        $sql = "SELECT * FROM depot_item";
        $stmt = $con->query($sql);
        while ($row = $stmt->fetch(PDO::FETCH_ASSOC)){
       ?>
       <tr>
         <td><?php echo $row['item_id']; ?></td>
         <td><?php echo $row['item_name']; ?></td>
         <td><?php echo $row['amount']; ?></td>
         <td>
           <?php
            $temp = $row['category_id'];
            $sql1 = "SELECT c.category_name FROM category c INNER JOIN depot_item d ON c.category_id = d.category_id WHERE d.category_id='$temp'";
            $stmt1 = $con->query($sql1);
            $row1 = $stmt1->fetch(PDO::FETCH_ASSOC);
            echo $row1['category_name'];
            ?>
         </td>
         <td><?php echo $row['price']; ?></td>
       </tr>
     <?php } ?>

    </table>

  </div>
        </main>
</body>
</hmtl>