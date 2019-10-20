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

$sql = "SELECT * FROM haberbilgi;";

$stmt = $conn->prepare($sql);
$stmt->execute();

$stmt->bind_result($HaberID,$Begenme,$Dislike,$Preview);

echo '{"haberbilgi":';
while($stmt->fetch()){
 $temp = [
 'HaberID'=>$HaberID,
 'Begenme'=>$Begenme,
 'Dislike'=>$Dislike,
 'Preview'=>$Preview
 ];

 array_push($heroes, $temp);
}

echo json_encode($heroes);
echo '}';

?>
