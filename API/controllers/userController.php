<?php
    header('Content-type: application/json; charset=utf-8');
    require_once("../models/userModel.php");

    $response = "";
    if(isset($_GET['action'])) 
    {
        switch ($_GET['action'])
        {
            case "getUsers":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetUsers();
            break;
        }
    }
    echo $response;
?>
