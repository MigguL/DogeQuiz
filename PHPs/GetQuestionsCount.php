<?php
require 'ConnectToDB.php';

$kwerenda_pobierz_ranking = "call GetQuestionsCount();";

if ($wynik_pobierz_ranking=mysqli_query($link, $kwerenda_pobierz_ranking)) {
    $resultArray = array();
    $tempArray = array();

    $row = $wynik_pobierz_ranking->fetch_object();
    echo json_encode($row);
}

mysqli_close($con);
?>