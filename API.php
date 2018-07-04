<?php

header("Content-Type: application/json; charset=UTF-8");
$servername = "nano-obras.mysql.uhserver.com";
$username = "nanocorp";
$password = "@1967Az67";
$db= "nano_obras";

$conn = new mysqli($servername, $username, $password, $db);

$conn->query("SET NAMES 'utf8'");
$conn->query('SET character_set_connection=utf8');
$conn->query('SET character_set_client=utf8');
$conn->query('SET character_set_results=utf8');

$nome = $_GET["nome"];
$senha= $_GET["senha"];

$stmt = "
		SELECT 
		    *
		FROM
		    nano_usuarios
		WHERE
		    Nome = '" . $nome . "' AND Senha = '" . $senha . "'";

$result = $conn->query($stmt);
while($row = $result->fetch_assoc()){
	$rows[] = $row;
}


echo json_encode($rows, JSON_UNESCAPED_UNICODE)

?>