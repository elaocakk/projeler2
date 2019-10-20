<?php

$servername = "127.0.0.1";
$username = "root";
$password = "elaocak";
$database = "haber";

$id=$_POST["id"];
$dislike=$_POST["dislike"];

$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql="UPDATE haberbilgi SET Begenme='$dislike' WHERE HaberID = $id";

if(mysqli_query($conn,$sql)) {
  echo "Veri Ekleme Basarili";
}else {
  echo "Veri Ekleme Basarisiz";
}

mysqli_close($conn);

?>
