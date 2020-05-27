<?php
$host     = '';
$username = '';
$password = '';
$database = '';

$connection = new MySQLi($host,$username,$password,$database);

$playerName = $_POST["playerName"];
$timer = $_POST["timer"];
$distance = $_POST["distance"];
$rageQuit = $_POST["rageQuit"];

if(!$connection)
{
	die("connection failed.". mysqli_connect_error());
}

$sql = "INSERT INTO Med4_UserData ( username, time, distance,rageQuit) VALUES ('$playerName','$timer','$distance','$rageQuit')";


$result = mysqli_query($connection,$sql);
if(!$result)
{
	echo"there was a error";
}
else
{
	echo "everything is fine!";
}

?>