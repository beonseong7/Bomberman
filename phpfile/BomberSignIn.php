
<?php
  header('Content-Type: text/html; charset=utf-8');
$servername = "localhost";
$username = "root";
$password = "bansuk0628";
$dbname = "bomberia";

$ID=$_POST["ID"];
$PW=$_POST["PW"];
$NickName=$_POST["NickName"];
$Email=$_POST["Email"];

$conn = new mysqli ($servername, $username, $password, $dbname);
mysqli_query($mysqli,"set names utf8");
if(!$conn){
  die("Connection Failed.". mysqli_connect_error());
}
//else echo ("Connection Success");

//테이블명은 unitylogin으로 했음.
$sql = "INSERT INTO user(ID,pwd,nick_name,email,score) VALUES ('".$ID."','".$PW."','".$NickName."','".$Email."',0)";
$result = mysqli_query($conn, $sql);

if($result==1)
{
echo "Success";
}
else {
    echo "Error";
  }

?>