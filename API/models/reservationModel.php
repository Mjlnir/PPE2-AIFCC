<?php
    /** Fonction permettant la connexion avec la base de données
     */
    function DBLog(){
        try  
        {
            $conn = new PDO("mysql:host=localhost;dbname=POMMADAM;charset=utf8", "root", "",
            [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
             PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC]);
            if($conn)
            {
                return $conn;
            }
            else
            {
                echo "La connexion n'a pu être établie.<br />";
                die( print_r( sqlsrv_errors(), true));
            }
        }
        catch (PDOException $e)
        {
            echo 'Échec lors de la connexion : ' . $e->getMessage();
        } 
    }
    /** Fonction permettant de récupérer une liste de réservation
     */
    function fctGetReservations(){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_GET_RESERVATIONS()";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->execute();
            $row = $query->fetchAll();
            $query->closeCursor();

            $results = array();
            if(isset($row)){
                $results["success"] = true;
                $results["message"] = "Ok";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            else{
                $results["success"] = true;
                $results["message"] = "Error";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            return json_encode($results, JSON_PRETTY_PRINT);
        }
        catch (PDOException $e)
        {
            die("Error occurred:" . $e->getMessage());
        }
    }
    /** Fonction permettant de récupérer une liste de réservation pour un véhicule incluent dans une période
     * @param jourReservation
     * @param heurefin
     * @param idVehicule
     */
    function fctGetReservationsByDate($jourReservation,$heureFin,$idVehicule){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_GET_RESERVATIONS_BY_DATE(:dtJour,:dtFin,:idVehicule)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":dtJour", $jourReservation);
            $query->bindParam(":dtFin", $heureFin);
            $query->bindParam(":idVehicule", $idVehicule);
            $query->execute();
            $row = $query->fetchAll();
            $query->closeCursor();

            $results = array();
            if(isset($row)){
                $results["success"] = true;
                $results["message"] = "Ok";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            else{
                $results["success"] = true;
                $results["message"] = "Error";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            return json_encode($results, JSON_PRETTY_PRINT);
        }
        catch (PDOException $e)
        {
            die("Error occurred:" . $e->getMessage());
        }
    }
    /** Fonction permettant de créer une réservation
     * @param idVehicule
     * @param jourReservation
     * @param heurefin
     * @param idUtilisateur
     */
    function fctAddReservation($idVehicule,$jourReservation,$heureFin,$idUtilisateur){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_ADD_RESERVATION(:idVehicule,:dtJour,:dtFin,:idUtilisateur)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":idVehicule", $idVehicule);
            $query->bindParam(":dtJour", $jourReservation);
            $query->bindParam(":dtFin", $heureFin);
            $query->bindParam(":idUtilisateur",$idUtilisateur);
            $query->execute();
            $row = $query->fetch();
            $query->closeCursor();

            $results = array();
            if(isset($row)){
                $results["success"] = true;
                $results["message"] = "Ok";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            else{
                $results["success"] = true;
                $results["message"] = "Error";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            return json_encode($results, JSON_PRETTY_PRINT);
        }
        catch (PDOException $e)
        {
            die("Error occurred:" . $e->getMessage());
        }
    }
    /** Fonction permettant de modifier une réservation
     * @param idReservation
     * @param idVehicule
     * @param jourReservation
     * @param heurefin
     * @param idUtilisateur
     */
    function fctUpdReservation($idReservation,$idVehicule,$jourReservation,$heureFin){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_UPD_RESERVATION(:idReservation,:idVehicule,:dtJour,:dtFin)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":idReservation", $idReservation);
            $query->bindParam(":idVehicule", $idVehicule);
            $query->bindParam(":dtJour", $jourReservation);
            $query->bindParam(":dtFin", $heureFin);
            $query->execute();
            $row = $query->fetch();
            $query->closeCursor();

            $results = array();
            if(isset($row)){
                $results["success"] = true;
                $results["message"] = "Ok";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            else{
                $results["success"] = true;
                $results["message"] = "Error";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            return json_encode($results, JSON_PRETTY_PRINT);
        }
        catch (PDOException $e)
        {
            die("Error occurred:" . $e->getMessage());
        }
    }
    /** Fonction de supprimer une réservation
     * @param idReservation
     */
    function fctDelReservation($idReservation){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_DEL_RESERVATION(:idReservation)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":idReservation", $idReservation);
            $query->execute();
            $row = $query->fetch();
            $query->closeCursor();

            $results = array();
            if(isset($row)){
                $results["success"] = true;
                $results["message"] = "Ok";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            else{
                $results["success"] = true;
                $results["message"] = "Error";
                $results["results"] = json_encode($row, JSON_PRETTY_PRINT);
            }
            return json_encode($results, JSON_PRETTY_PRINT);
        }
        catch (PDOException $e)
        {
            die("Error occurred:" . $e->getMessage());
        }
    }
?>