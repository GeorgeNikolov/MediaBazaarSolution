<?php

// $dsn = 'mysql:host=studmysql01.fhict.local;dbname=dbi411472';
// $username = "dbi411472";
// $password = "";

// $dsn = 'mysql:host=localhost;dbname=website_sem2';
// $username = "root";
// $password = "";

$dsn = 'mysql:host=studmysql01.fhict.local;dbname=dbi425406';
$username = "dbi425406";
$password = "1234";

try {
  $con = new PDO($dsn, $username, $password);
} catch (PDOException $e) {
  echo $e->getMessage();
}
