
<?php

        $user        =    "root";
        $pass        =    "elaocak";
        $host        =    "127.0.0.1" ;
        $db            =    "haber";


      //  $baglan = mysql_connect($host,$user,$pass) or die(mysql_error());
        $connection = new mysqli($host, $user, $pass,$db);
        $connection1 = new mysqli($host,$user,$pass,$db);

     //   mysql_select_db($db,$connection) or die(mysql_error());

if ($connection->connect_error) {
    die("Connection failed: " . $connection->connect_error);
}
echo "Connected successfully";

?>


<form action="" method="post">
        <table cellspacing="5" cellpadding="5">
        <tr>
                <td>Resim URL</td>
                <td><input type="text" name="url"/></td>
            </tr>
            <tr>
                <td>Başlık</td>
                <td><input type="text" name="baslik"/></td>
            </tr>
            <tr>
                <td>İçerik</td>
                <td><input type="text" name="icerik"/></td>
            </tr>
            <tr>
                <td>Tür</td>
                <td><input type="text" name="tur"/></td>
            </tr>
            <tr>
                <td>Tarih</td>
                <td><input type="text" name="tarih"/></td>
            </tr>


                <td></td>
                <td><input type="submit" value="Kayıt Ekle" /></td>
            </tr>
        </table>
    </form>



    <?php

        // Form Gönderilmişmi Kontrolü Yapalım
        if($_POST){

            // Formdan Gelen Kayıtlar
            $Baslik = $_POST["baslik"];
           $Icerik=  $_POST["icerik"];
           $Tur=  $_POST["tur"];
           $Ytarih=  $_POST["tarih"];
           $RYol=  $_POST["url"];


            // Veritabanına Ekleyelim.

    $ekle = mysqli_query($connection,"insert into haberler (RYol, Baslik, Icerik, Tur, YTarih) VALUES ('$RYol','$Baslik','$Icerik','$Tur','$Ytarih')");
            // Sorun Oluştu mu diye test edelim. Eğer sorun yoksa hata vermeyecektir
             $ekle1 = mysqli_query($connection1,"insert into haberbilgi (Begenme, Dislike, Preview) VALUES (0,0,0)");
           if($ekle){
                echo "Başarılı Bir Şekilde Eklendi !";
            }else{
                echo "Bir Sorun Var,Ekleme Başarısız !";
            }
            if($ekle){
                 echo "Başarılı Bir Şekilde Eklendi !";
             }else{
                 echo "Bir Sorun Var,Ekleme Başarısız !";
             }
        }

	$connection->close();
        ?>
