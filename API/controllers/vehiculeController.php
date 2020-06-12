<?php
    header('Content-type: application/json; charset=utf-8');
    require_once("../models/vehiculeModel.php");

    $response = "";
    if(isset($_GET['action'])) 
    {
        switch ($_GET['action'])
        {
            case "getVehicules":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetVehicules();
            break;
            case "getVehiculesByDate":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetVehiculesByDate($input["jourReservation"],$input["heureFin"]);
            break;
            case "addVehicule":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctAddVehicule($input["nomVehicule"],$input["kilometrage"],$input["nbPlace"],$input["estDispo"],$input["idTypeVehicule"]);
            break;
            case "updVehicule":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctUpdVehicule($input["idVehicule"],$input["nomVehicule"],$input["kilometrage"],$input["nbPlace"],$input["estDispo"],$input["idTypeVehicule"]);
            break;
            case "delVehicule":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctDelVehicule($input["idVehicule"]);
            break;
        }
    }
    echo $response;
?>
