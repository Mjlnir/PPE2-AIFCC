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
    /** Fonction de se connecter. Retourne l'utisiateur
     *  @param login
     *  @param mdp
     */
    function fctSignIn($login, $mdp){
        try
        {
            $conn = DBLog();

            // execute the stored procedure
            $sql = "CALL PRC_SIGN_IN(:login,:mdp)";

            // call the stored procedure
            $query = $conn->prepare($sql);
            $query->bindParam(":login", $login);
            $query->bindParam(":mdp", $mdp);
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