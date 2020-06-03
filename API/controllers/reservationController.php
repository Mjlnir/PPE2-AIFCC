<?php
    header('Content-type: application/json; charset=utf-8');
    require_once("../models/reservationModel.php");

    $response = "";
    if(isset($_GET['action'])) 
    {
        switch ($_GET['action'])
        {
            case "getReservations":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetReservations();
            break;
            case "getReservationsByDate":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetReservationsByDate($input["jourReservation"],$input["heureFin"],$input["idVehicule"]);
            break;
            case "getVehiculesByDate":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctGetVehiculesByDate($input["jourReservation"],$input["heureFin"]);
            break;
            case "addReservation":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctAddReservation($input["idVehicule"],$input["jourReservation"],$input["heureFin"],$input["idItuilisateur"]);
            break;
            case "updReservation":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctUpdReservation($input['idReservation'],$input["idVehicule"],$input["jourReservation"],$input["heureFin"]);
            break;
            case "delReservation":
                $inputJSON = file_get_contents('php://input');
                $input = json_decode($inputJSON, TRUE);
                $response = fctDelReservation($input['idReservation']);
            break;
        }
    }
    echo $response;
?>
