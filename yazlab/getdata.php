<?php
$servername = "127.0.0.1";
$username = "root";
$password = "elaocak";
$database = "haber";

$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$heroes = array();

$sql = "SELECT * FROM haberler;";

$stmt = $conn->prepare($sql);
$stmt->execute();

$stmt->bind_result($RYol,$Baslik,$Icerik,$Tur,$HaberID,$YTarih);

 echo '{"haber":';
while($stmt->fetch()){

 $temp = [
 'RYol'=>$RYol,
 'Baslik'=>$Baslik,
 'Icerik'=>$Icerik,
 'Tur'=>$Tur,
 'HaberID'=>$HaberID,
 'YTarih'=>$YTarih
 ];

 array_push($heroes, $temp);
}

echo json_encode($heroes);
echo '}';

?>
