<?php
require 'ConnectToDB.php';

$question = $_GET['question'];

$kwerenda_pobierz_ranking = "call GetAnswers($question);";

if ($wynik_pobierz_ranking=mysqli_query($link, $kwerenda_pobierz_ranking)) {
    $resultArray = array();
    $tempArray = array();

    while ($row = $wynik_pobierz_ranking->fetch_object()) {
        $tempArray = $row;
        array_push($resultArray, $tempArray);
    }

    echo json_encode($resultArray);
}

mysqli_close($con);
