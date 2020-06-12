<?php
    header('Content-type: application/json; charset=utf-8');
    require_once("../models/typeVehiculeModel.php");

    $response = "";
    if(isset($_GET['action'])) 
    {
        switch ($_GET['action'])
        {
            case "getTypesVehicules":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetTypesVehicules();
            break;
        }
    }
    echo $response;
?>
