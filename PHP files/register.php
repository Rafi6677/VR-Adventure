<?php 

    $connection = @new mysqli('localhost', 'root', '', 'vr_adventure_db');

    if($connection->connect_errno != 0)
    {
    	echo "1: Failed to connect to database";
    	exit();
    }

    $name = $_POST["name"];
    $login = $_POST["login"];
    $email = $_POST["email"];
    $password = $_POST["password"];
    $age = $_POST["age"];
    $sex = $_POST["sex"];

    $loginCheckQuery = "SELECT login FROM users WHERE login = '" . $login . "';";
    $emailCheckQuery = "SELECT email FROM users WHERE email = '" . $email . "';";

    $loginCheck = $connection->query($loginCheckQuery) or die("2: Login check query failed!");
    $emailCheck = $connection->query($emailCheckQuery) or die("3: Email check query failed!");

    if($loginCheck->num_rows > 0)
    {
    	echo "4: Login already exists!";
    	exit();
    }

    if($emailCheck->num_rows > 0)
    {
    	echo "5: Email already exists!";
    	exit();
    }


    $salt = "\$5\$rounds=5000\$" . "streamedhams" . $name . "\$";
    $hash = crypt($password, $salt);

    $connection->query("SET NAMES 'utf8'");

    $insertUserQuery = "INSERT INTO users (name, login, email, hash, salt, age, sex) VALUES ('".$name."', '".$login."', '".$email."', 
    '".$hash."', '".$salt."', '".$age."', '".$sex."');";

    $inserUser =$connection->query($insertUserQuery) or die("6: Insert user failed!");

    echo("0");

?>