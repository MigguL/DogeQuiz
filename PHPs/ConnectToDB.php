<?php
$link = mysqli_connect("127.0.0.1", "jw", "jw@ps0&PL", "DogeQuiz");

if (!$link) {
    echo "Error: Unable to connect to MySQL." . PHP_EOL;
    echo "Debugging errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Debugging error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}

if (php_sapi_name() != 'cli') {
    mysqli_query('SET NAMES utf8', $link);
}
