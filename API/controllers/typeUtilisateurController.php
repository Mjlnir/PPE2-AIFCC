<?php
    header('Content-type: application/json; charset=utf-8');
    require_once("../models/typeUtilisateurModel.php");

    $response = "";
    if(isset($_GET['action'])) 
    {
        switch ($_GET['action'])
        {
            case "getTypesUtilisateurs":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetTypesUtilisateurs();
            break;
        }
    }
    echo $response;
?>
