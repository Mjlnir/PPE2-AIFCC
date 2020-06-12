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
    /** Fonction de récupérer une liste de véhicules
     */
    function fctGetVehicules(){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_GET_VEHICULES()";

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
    function fctGetVehiculesByDate($jourReservation,$heureFin){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_GET_VEHICULES_BY_DATE(:dtJour,:dtFin)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":dtJour", $jourReservation);
            $query->bindParam(":dtFin", $heureFin);
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
    /** Fonction de créer un véhicule
     * @param nomVehicule
     * @param kilometrage
     * @param nbPlace
     * @param estDispo
     * @param idTypeVehicule
     */
    function fctAddVehicule($nomVehicule,$kilometrage,$nbPlace,$estDispo,$idTypeVehicule){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_ADD_VEHICULE(:nomVehicule,:kilometrage,:idTypeVehicule,:nbPlace,:estDispo)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":nomVehicule", $nomVehicule);
            $query->bindParam(":kilometrage", $kilometrage);
            $query->bindParam(":nbPlace", $nbPlace);
            $query->bindParam(":estDispo", $estDispo);
            $query->bindParam(":idTypeVehicule", $idTypeVehicule);
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
    /** Fonction de modifier un véhicule
     * @param idVehicule
     * @param nomVehicule
     * @param kilometrage
     * @param nbPlace
     * @param estDispo
     * @param idTypeVehicule
     */
    function fctUpdVehicule($idVehicule,$nomVehicule,$kilometrage,$nbPlace,$estDispo,$idTypeVehicule){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_UPD_VEHICULE(:idVehicule,:nomVehicule,:kilometrage,:nbPlace,:estDispo,:idTypeVehicule)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":idVehicule", $idVehicule);
            $query->bindParam(":nomVehicule", $nomVehicule);
            $query->bindParam(":kilometrage", $kilometrage);
            $query->bindParam(":nbPlace", $nbPlace);
            $query->bindParam(":estDispo", $estDispo);
            $query->bindParam(":idTypeVehicule", $idTypeVehicule);
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
    /** Fonction de supprimer un véhicule
     * @param idVehicule
     */
    function fctDelVehicule($idVehicule){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_DEL_VEHICULE(:idVehicule)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":idVehicule", $idVehicule);
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