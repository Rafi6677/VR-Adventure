<?php 

    $connection = @new mysqli('localhost', 'root', '', 'vr_adventure_db');

    if($connection->connect_errno != 0)
    {
    	echo "1: Failed to connect to database";
    	exit();
    }

    $login = $_POST["login"];
    $password = $_POST["password"];

   $loginCheckQuery = "SELECT login, salt, hash FROM users WHERE login = '" . $login . "';";

   $loginCheck = $connection->query($loginCheckQuery) or die("2: Login check query failed!");

   if($loginCheck->num_rows != 1)
   {
        echo("7: Either no user with login, or more than one!");
        exit();
   }

    $userInfo = mysqli_fetch_assoc($loginCheck);
    $salt = $userInfo["salt"];
    $hash = $userInfo["hash"];

    $loginHash = crypt($password, $salt);

    if ($hash != $loginHash)
    {
        echo("8: Incorrect password!");
        exit();
    }

    echo("0");

?>