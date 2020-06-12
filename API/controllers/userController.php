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
            case "addUser":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctAddUser($input["nomUser"]
                ,$input["prenomUser"]
                ,$input["mailUser"]
                ,$input["telUser"]
                ,$input["loginUser"]
                ,$input["pwdUser"]
                ,$input["idTypeUser"]);
            break;
            case "updUser":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctUpdUser($input["nomUser"]
                ,$input["prenomUser"]
                ,$input["mailUser"]
                ,$input["telUser"]
                ,$input["loginUser"]
                ,$input["pwdUser"]
                ,$input["idTypeUser"]
                ,$input["idUser"]);
            break;
            case "delUser":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctDelUser($input["idUser"]);
            break;
        }
    }
    echo $response;
?>
