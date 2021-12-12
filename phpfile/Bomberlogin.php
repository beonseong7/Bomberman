
<?php
  header('Content-Type: text/html; charset=utf-8');
$servername = "localhost";
$username = "root";
$password = "bansuk0628";
$dbname = "bomberia";


$PlayerID = $_POST["PlayerID"];
$PlayerPW = $_POST["PlayerPW"];

$conn = new mysqli ($servername, $username, $password, $dbname);
mysqli_query($mysqli,"set names utf8");
if(!$conn){
  die("Connection Failed.". mysqli_connect_error());
}
//else echo ("Connection Success");

//테이블명은 unitylogin으로 했음.
$sql = "SELECT ID,nick_name,score FROM user WHERE ID = '".$PlayerID."' and pwd = '".$PlayerPW."' ";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result)>0)
{
  while($row = mysqli_fetch_assoc($result)){
echo ",".$row['ID'].",".$row['nick_name'].",".$row['score'];
} 
}
else {
    echo ",Error";
  }


?>