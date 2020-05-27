<?php
$host     = '';
$username = '';
$password = '';
$database = '';

$connection = new MySQLi($host,$username,$password,$database);

if(!$connection)
{
	die("connection failed.". mysqli_connect_error());
}

$sql = "SELECT username FROM Med4_UserData ORDER BY id asc";



$result = mysqli_query($connection,$sql) or die(mysqli_error());
while ($row = mysqli_fetch_array($result))
{
	echo $row[username].":";
}

?>