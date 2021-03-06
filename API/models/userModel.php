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
    /** Fonction de récupérer une liste d'utilisateurs
     */
    function fctGetUsers(){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_GET_USERS()";

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
    /** Fonction de créer un utilisateur
     * @param nomUser
     * @param prenomUser
     * @param mailUser
     * @param telUser
     * @param loginUser
     * @param pwdUser
     * @param idTypeUser
     */
    function fctAddUser($nomUser,$prenomUser,$mailUser,$telUser,$loginUser,$pwdUser,$idTypeUser){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_ADD_USER(:nomUser,:prenomUser,:mailUser,:telUser,:loginUser,:pwdUser,:idTypeUser)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query ->bindParam(":nomUser", $nomUser);
            $query ->bindParam(":prenomUser", $prenomUser);
            $query ->bindParam(":mailUser", $mailUser);
            $query ->bindParam(":telUser", $telUser);
            $query ->bindParam(":loginUser", $loginUser);
            $query ->bindParam(":pwdUser", $pwdUser);
            $query ->bindParam(":idTypeUser", $idTypeUser);
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
    /** Fonction de modifier un utilisateur
     * @param nomUser
     * @param prenomUser
     * @param mailUser
     * @param telUser
     * @param loginUser
     * @param pwdUser
     * @param idTypeUser
     * @param idUser
     */
    function fctUpdUser($nomUser,$prenomUser,$mailUser,$telUser,$loginUser,$pwdUser,$idTypeUser,$idUser){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_UPD_USER(:nomUser,:prenomUser,:mailUser,:telUser,:loginUser,:pwdUser,:idTypeUser,:idUser)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query ->bindParam(":nomUser", $nomUser);
            $query ->bindParam(":prenomUser", $prenomUser);
            $query ->bindParam(":mailUser", $mailUser);
            $query ->bindParam(":telUser", $telUser);
            $query ->bindParam(":loginUser", $loginUser);
            $query ->bindParam(":pwdUser", $pwdUser);
            $query ->bindParam(":idTypeUser", $idTypeUser);
            $query ->bindParam(":idUser", $idUser);
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
    /** Fonction de supprimer un utilisateur
     * @param idUser
     */
    function fctDelUser($idUser){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_DEL_USER(:idUser)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query ->bindParam(":idTypeUser", $idUser);
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