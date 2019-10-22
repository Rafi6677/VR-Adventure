<?php

	$connection = @new mysqli('localhost', 'root', '', 'vr_adventure_db');

    if($connection->connect_errno != 0)
    {
    	echo "1: Failed to connect to database";
    	exit();
    }

    $login = $_POST["username"];
    $date = $_POST["date"];
    $answer1 = $_POST["answerOne"];
    $answer2 = $_POST["answerTwo"];
    $answer3 = $_POST["answerThree"];
    $answer4 = $_POST["answerFour"];

    $userIDquery = "SELECT id FROM users WHERE login = '" . $login . "';";
    $result = $connection->query($userIDquery) or die("1: User connection failed!");

    if ($result->num_rows > 0) 
    {
        while($row = $result->fetch_assoc()) 
        {
        	$userID = $row["id"];
        }
    } else {
         echo "error";
         exit();
    }

    $insertAnswersQuery = "INSERT INTO questionnairesbeforesimulation (date, idUser, answer1, answer2, answer3, answer4) 
    						VALUES ('".$date."', '".$userID."', '".$answer1."', '".$answer2."', '".$answer3."', '".$answer4."');";

   	$inserAnswers =$connection->query($insertAnswersQuery) or die("2: Insert answers failed!");

   	echo("0");

?>