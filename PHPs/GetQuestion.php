<?php
require 'ConnectToDB.php';

$question = $_GET['question'];

$kwerenda_pobierz_ranking = "call GetQuestion($question);";

if ($wynik_pobierz_ranking=mysqli_query($link, $kwerenda_pobierz_ranking)) {
    $resultArray = array();
    $tempArray = array();

    $row = $wynik_pobierz_ranking->fetch_object();
    echo json_encode($row);
}

mysqli_close($con);
?>