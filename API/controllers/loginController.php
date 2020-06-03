<?php
    header('Content-type: application/json; charset=utf-8');
    require_once("../models/loginModel.php");

    $response = "";
    if(isset($_GET['action'])) 
    {
        switch ($_GET['action'])
        {
            case "login":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctSignIn($input['username'],$input['password']);
            break;
            case "user":
                $response = fctUser();
            break;
        }
    }
    echo $response;
?>
