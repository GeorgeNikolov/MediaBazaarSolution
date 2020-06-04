<?php require_once('includes/header.php'); ?>
<?php require_once('helpers/db.php'); ?>
<?php require_once('includes/navbar.php'); ?>

  <main>
    <div class="depot">
      <div id="search-area">
        <input type="text" id="search-input" placeholder="Enter keyword here...">
        </div>
      </div>

      <div id="filter-area">
        <div class="filter-input">-- Select Keyword To Sort By --</div>
        <i class="fa fa-angle-down filter-icon"></i>

        <ul class="filter-options">
          <li onclick="fillFilterInput(this);">ID</li>
          <li onclick="fillFilterInput(this);">Name</li>
        </ul>
      </div>

      <table class="depot-table">
        <tbody>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Amount</th>
            <th>Category</th>
            <th>Price</th>
          </tr>

          <?php
          $query = "SELECT d.item_id, d.item_name, d.amount, c.category_name, d.price FROM depot_item d INNER JOIN category c ON d.category_id = c.category_id";
          $res = $con->query($query);
          
          while($row = $res->fetch(PDO::FETCH_ASSOC)) {
          ?>

          <tr class="depot-item-row">
            <td data-th="ID">
              <?php echo $row["item_id"] ?>
            </td>
            <td data-th="Name">
              <?php echo $row["item_name"] ?>
            </td>
            <td data-th="Amount">
              <?php echo $row["amount"] ?>
            </td>
            <td data-th="Category">
              <?php echo $row["category_name"] ?>
            </td>
            <td data-th="Price">
              <?php echo $row["price"] ?>
            </td>
          </tr>
          <?php } ?>

        </tbody>
      </table>
    </div>
  </main>

  <script src="js/stock_animation.js"></script>
</body>
</hmtl>