-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  sam. 06 juin 2020 à 15:39
-- Version du serveur :  10.4.10-MariaDB
-- Version de PHP :  7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `pommadam`
--

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `PRC_ADD_RESERVATION`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_ADD_RESERVATION` (IN `_idVehicule` INT, IN `_dtJour` VARCHAR(255), IN `_dtFin` VARCHAR(255), IN `_idUtilisateur` INT)  NO SQL
BEGIN
	INSERT INTO reserver(idVehicule,jourReservation,idUtilisateur,heureFin)
    VALUES (_idVehicule,FROM_UNIXTIME(_dtJour), _idUtilisateur, FROM_UNIXTIME(_dtFin));
    SELECT 1;
END$$

DROP PROCEDURE IF EXISTS `PRC_ADD_USER`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_ADD_USER` (IN `_nomUser` VARCHAR(50) CHARSET utf8, IN `_prenomUser` VARCHAR(50) CHARSET utf8, IN `_mailUser` VARCHAR(50) CHARSET utf8, IN `_telephoneUser` VARCHAR(10) CHARSET utf8, IN `_loginUser` VARCHAR(50) CHARSET utf8, IN `_passwordUser` VARCHAR(50) CHARSET utf8, IN `_idTypeUser` INT)  NO SQL
BEGIN
	INSERT INTO utilisateur(
        nomUtilisateur
        ,prenomUtilisateur
        ,mailUtilisateur
        ,telephoneUtilisateur
        ,loginUtilisateur
        ,passwordUtilisateur
        ,idTypeUtilisateur
        )
        VALUES(
            _nomUser
            ,_prenomUser
            ,_mailUser
            ,_telephoneUser
            ,_loginUser
            ,_passwordUser
            ,_idTypeUser
            );
	SELECT 1;
END$$

DROP PROCEDURE IF EXISTS `PRC_ADD_VEHICULE`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_ADD_VEHICULE` (IN `_nomVehicule` VARCHAR(50) CHARSET utf8, IN `_kilometrage` INT, IN `_idTypeVehicule` INT, IN `_nbPlace` INT, IN `_estdispo` INT(1))  NO SQL
BEGIN
	INSERT INTO vehicule(
		nomVehicule
        ,kilometrageVehicule
        ,idTypeVehicule
        ,nbPlaceVehicule
        ,estDisponible)
        VALUES(
            _nomVehicule
            ,_kilometrage
            ,_idTypeVehicule
            ,_nbPlace
            ,_estdispo
            );
    SELECT 0;
END$$

DROP PROCEDURE IF EXISTS `PRC_DEL_RESERVATION`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_DEL_RESERVATION` (IN `_idReservation` INT)  NO SQL
BEGIN
DELETE FROM reserver
WHERE idReservation = _idReservation;
END$$

DROP PROCEDURE IF EXISTS `PRC_DEL_USER`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_DEL_USER` (IN `_idUser` INT)  NO SQL
BEGIN
	DELETE FROM utilisateur
    WHERE idUtilisateur = _idUser;
    SELECT 1;
END$$

DROP PROCEDURE IF EXISTS `PRC_DEL_VEHICULE`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_DEL_VEHICULE` (IN `_idVehicule` INT)  NO SQL
BEGIN
DELETE FROM vehicule
WHERE idVehicule = _idVehicule;
END$$

DROP PROCEDURE IF EXISTS `PRC_GET_RESERVATIONS`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_GET_RESERVATIONS` ()  NO SQL
BEGIN
SELECT idReservation as Id
,jourReservation as JourReservation
,idUtilisateur as IdUtilisateur
,idVehicule as IdVehicule
,heureFin as HeureFin
FROM reserver
ORDER BY idReservation DESC;
END$$

DROP PROCEDURE IF EXISTS `PRC_GET_RESERVATIONS_BY_DATE`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_GET_RESERVATIONS_BY_DATE` (IN `_dtJour` VARCHAR(255), IN `_dtFin` VARCHAR(255), IN `_idVehicule` INT)  NO SQL
BEGIN
	SELECT idReservation as Id
	,jourReservation as JourReservation
	,idUtilisateur as IdUtilisateur
	,idVehicule as IdVehicule
	,heureFin as HeureFin
    FROM reserver
    WHERE
    	idVehicule = _idVehicule
        AND ((reserver.jourReservation BETWEEN FROM_UNIXTIME(_dtJour) AND FROM_UNIXTIME(_dtFin))
        OR
        (reserver.heureFin BETWEEN FROM_UNIXTIME(_dtJour) AND FROM_UNIXTIME(_dtFin)));
END$$

DROP PROCEDURE IF EXISTS `PRC_GET_TYPES_UTILISATEURS`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_GET_TYPES_UTILISATEURS` ()  NO SQL
BEGIN
	SELECT idTypeUtilisateur as Id
    ,typeUtilisateur as NomTypeUtilisateur
    FROM typeutilisateur;
END$$

DROP PROCEDURE IF EXISTS `PRC_GET_TYPES_VEHICULES`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_GET_TYPES_VEHICULES` ()  NO SQL
BEGIN
	SELECT idTypeVehicule as Id
    , typeVehicule as NomTypeVehicule
    FROM typevehicule;
END$$

DROP PROCEDURE IF EXISTS `PRC_GET_USERS`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_GET_USERS` ()  NO SQL
BEGIN
	SELECT idUtilisateur as 'Id'
    ,nomUtilisateur as 'Nom'
    ,prenomUtilisateur as 'Prenom'
    ,mailUtilisateur as 'Mail'
    ,telephoneUtilisateur as 'Telephone'
    ,loginUtilisateur as 'Login'
    ,passwordUtilisateur as 'Mdp'
    ,idTypeUtilisateur as 'Type'
    FROM utilisateur;
END$$

DROP PROCEDURE IF EXISTS `PRC_GET_VEHICULES`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_GET_VEHICULES` ()  NO SQL
BEGIN
    SELECT idVehicule as Id
    , nomVehicule as Nom
    , estDisponible as estDisponible
    , kilometrageVehicule as Kilometrage
    , idTypeVehicule as IdTypeVehicule
    , nbPlaceVehicule as NbPlace
    FROM vehicule;
END$$

DROP PROCEDURE IF EXISTS `PRC_GET_VEHICULES_BY_DATE`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_GET_VEHICULES_BY_DATE` (IN `_dtJour` VARCHAR(255), IN `_dtFin` VARCHAR(255))  NO SQL
BEGIN
	SELECT vehicule.idVehicule as idVehicule,
    nomVehicule as nomVehicule,
    kilometrageVehicule,
    idTypeVehicule,
    nbPlaceVehicule,
    estDisponible
    FROM vehicule
    WHERE vehicule.idVehicule NOT IN 
	(SELECT reserver.idVehicule
    FROM reserver
    WHERE ((reserver.jourReservation BETWEEN FROM_UNIXTIME(_dtJour) AND FROM_UNIXTIME(_dtFin))
        OR
        (reserver.heureFin BETWEEN FROM_UNIXTIME(_dtJour) AND FROM_UNIXTIME(_dtFin))));
END$$

DROP PROCEDURE IF EXISTS `PRC_SIGN_IN`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_SIGN_IN` (IN `_loginUtilisateur` VARCHAR(50) CHARSET utf8, IN `_mdpUtilisateur` VARCHAR(50) CHARSET utf8)  NO SQL
BEGIN
	SELECT idUtilisateur as 'Id'
    ,nomUtilisateur as 'Nom'
    ,prenomUtilisateur as 'Prenom'
    ,mailUtilisateur as 'Mail'
    ,telephoneUtilisateur as 'Telephone'
    ,loginUtilisateur as 'Login'
    ,passwordUtilisateur as 'Mdp'
    ,idTypeUtilisateur as 'Type'
    FROM utilisateur
    WHERE loginUtilisateur = _loginUtilisateur
    AND passwordUtilisateur = _mdpUtilisateur;
END$$

DROP PROCEDURE IF EXISTS `PRC_UPD_RESERVATION`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_UPD_RESERVATION` (IN `_idReservation` INT, IN `_idVehicule` INT, IN `_dtJour` VARCHAR(255), IN `_dtFin` VARCHAR(255))  NO SQL
BEGIN
		UPDATE reserver
    	SET idVehicule = _idVehicule,
    	jourReservation = FROM_UNIXTIME(_dtJour),
    	heureFin = FROM_UNIXTIME(_dtFin)
    	WHERE idReservation = _idReservation;
        SELECT 0;
END$$

DROP PROCEDURE IF EXISTS `PRC_UPD_USER`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_UPD_USER` (IN `_nomUtilisateur` VARCHAR(50) CHARSET utf8, IN `_prenomUtilisateur` VARCHAR(50) CHARSET utf8, IN `_mailUtilisateur` VARCHAR(50) CHARSET utf8, IN `_telephoneUtilisateur` VARCHAR(50) CHARSET utf8, IN `_loginUtilisateur` VARCHAR(50) CHARSET utf8, IN `_pwdUtilisateur` VARCHAR(50) CHARSET utf8, IN `_idTypeUtilisateur` INT, IN `_idUser` INT)  NO SQL
BEGIN
	UPDATE utilisateur
    SET nomUtilisateur = _nomUtilisateur,
    prenomUtilisateur = _prenomUtilisateur,
    mailUtilisateur = _mailUtilisateur,
    telephoneUtilisateur = _telephoneUtilisateur,
    loginUtilisateur = _loginUtilisateur,
    passwordUtilisateur = _pwdUtilisateur,
    idTypeUtilisateur = _idTypeUtilisateur
    WHERE idUtilisateur = _idUser;
    SELECT 1;
END$$

DROP PROCEDURE IF EXISTS `PRC_UPD_VEHICULE`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PRC_UPD_VEHICULE` (IN `_idVehicule` INT, IN `_nomVehicule` VARCHAR(50) CHARSET utf8, IN `_Kilometrage` INT, IN `_nbPlace` INT, IN `_estDispo` INT, IN `_idTypeVehicule` INT)  NO SQL
BEGIN
	UPDATE vehicule
    SET nomVehicule = _nomVehicule
    , kilometrageVehicule = _Kilometrage
    , nbPlaceVehicule = _nbPlace
    , estDisponible = _estDispo
    , idTypeVehicule = _idTypeVehicule
    WHERE idVehicule = _idVehicule;
    SELECT 0;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `reserver`
--

DROP TABLE IF EXISTS `reserver`;
CREATE TABLE IF NOT EXISTS `reserver` (
  `idReservation` int(11) NOT NULL AUTO_INCREMENT,
  `idVehicule` int(11) NOT NULL,
  `jourReservation` datetime NOT NULL,
  `idUtilisateur` int(11) NOT NULL,
  `heureFin` datetime NOT NULL,
  PRIMARY KEY (`idReservation`,`idVehicule`,`jourReservation`,`idUtilisateur`),
  KEY `RESERVER_UTILISATEUR_FK` (`idUtilisateur`),
  KEY `RESERVER_VZHICULE_FK` (`idVehicule`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `reserver`
--

INSERT INTO `reserver` (`idReservation`, `idVehicule`, `jourReservation`, `idUtilisateur`, `heureFin`) VALUES
(3, 1, '2020-05-24 15:00:00', 2, '2020-05-24 20:00:00'),
(4, 1, '2020-05-25 15:00:00', 2, '2020-05-25 20:00:00'),
(9, 1, '2020-06-01 15:00:00', 1, '2020-06-01 20:00:00'),
(11, 9, '2020-06-30 10:00:00', 1, '2020-06-30 15:00:00'),
(12, 10, '2020-06-30 10:00:00', 1, '2020-06-30 15:00:00'),
(13, 1, '2020-06-04 17:00:00', 3, '2020-06-04 18:00:00'),
(14, 6, '2020-06-10 18:00:00', 3, '2020-06-10 20:00:00');

-- --------------------------------------------------------

--
-- Structure de la table `typeutilisateur`
--

DROP TABLE IF EXISTS `typeutilisateur`;
CREATE TABLE IF NOT EXISTS `typeutilisateur` (
  `idTypeUtilisateur` int(11) NOT NULL AUTO_INCREMENT,
  `typeUtilisateur` varchar(15) NOT NULL,
  PRIMARY KEY (`idTypeUtilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typeutilisateur`
--

INSERT INTO `typeutilisateur` (`idTypeUtilisateur`, `typeUtilisateur`) VALUES
(1, 'Admin'),
(2, 'Gestionnaire'),
(3, 'Emprunteur');

-- --------------------------------------------------------

--
-- Structure de la table `typevehicule`
--

DROP TABLE IF EXISTS `typevehicule`;
CREATE TABLE IF NOT EXISTS `typevehicule` (
  `idTypeVehicule` int(11) NOT NULL AUTO_INCREMENT,
  `typeVehicule` varchar(50) NOT NULL,
  PRIMARY KEY (`idTypeVehicule`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typevehicule`
--

INSERT INTO `typevehicule` (`idTypeVehicule`, `typeVehicule`) VALUES
(1, 'Voiture'),
(2, 'Camionnette'),
(3, 'Camion');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `idUtilisateur` int(11) NOT NULL AUTO_INCREMENT,
  `nomUtilisateur` varchar(50) NOT NULL,
  `prenomUtilisateur` varchar(50) NOT NULL,
  `mailUtilisateur` varchar(50) NOT NULL,
  `telephoneUtilisateur` varchar(10) NOT NULL,
  `loginUtilisateur` varchar(50) NOT NULL,
  `passwordUtilisateur` varchar(50) NOT NULL,
  `idTypeUtilisateur` int(11) NOT NULL,
  PRIMARY KEY (`idUtilisateur`),
  KEY `UTILISATEUR_TYPEUTILISATEUR_FK` (`idTypeUtilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`idUtilisateur`, `nomUtilisateur`, `prenomUtilisateur`, `mailUtilisateur`, `telephoneUtilisateur`, `loginUtilisateur`, `passwordUtilisateur`, `idTypeUtilisateur`) VALUES
(1, 'trudelle', 'florian', 'admin.admin@pommadam.com', '1122334455', 'ftrudell', 'root', 1),
(2, 'bezos', 'jeff', 'bezos.jeff@pommadam.com', '0666666667', 'jbezos', 'root', 2),
(3, 'musk', 'elon', 'musk.elon@pommadam.com', '0666666668', 'emusk', 'root', 3);

-- --------------------------------------------------------

--
-- Structure de la table `vehicule`
--

DROP TABLE IF EXISTS `vehicule`;
CREATE TABLE IF NOT EXISTS `vehicule` (
  `idVehicule` int(11) NOT NULL AUTO_INCREMENT,
  `nomVehicule` varchar(50) NOT NULL,
  `kilometrageVehicule` int(50) NOT NULL,
  `idTypeVehicule` int(11) NOT NULL,
  `nbPlaceVehicule` int(11) DEFAULT NULL,
  `estDisponible` int(1) NOT NULL,
  PRIMARY KEY (`idVehicule`),
  KEY `VEHICULE_TYPEVEHICULE_FK` (`idTypeVehicule`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `vehicule`
--

INSERT INTO `vehicule` (`idVehicule`, `nomVehicule`, `kilometrageVehicule`, `idTypeVehicule`, `nbPlaceVehicule`, `estDisponible`) VALUES
(1, 'V1', 100000, 1, 2, 1),
(2, 'V2', 100000, 1, 2, 1),
(3, 'V3', 100000, 1, 2, 1),
(4, 'V4', 100000, 1, 5, 1),
(5, 'V5', 100000, 1, 5, 1),
(6, 'CT1', 100000, 2, NULL, 1),
(7, 'CT2', 100000, 2, NULL, 1),
(8, 'C1', 100000, 3, NULL, 1),
(9, 'C2', 100000, 3, NULL, 1),
(10, 'C3', 100000, 3, NULL, 1),
(21, 'C6669', 100000, 3, 0, 1);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD CONSTRAINT `UTILISATEUR_TYPEUTILISATEUR_FK` FOREIGN KEY (`idTypeUtilisateur`) REFERENCES `typeutilisateur` (`idTypeUtilisateur`);

--
-- Contraintes pour la table `vehicule`
--
ALTER TABLE `vehicule`
  ADD CONSTRAINT `VEHICULE_TYPEVEHICULE_FK` FOREIGN KEY (`idTypeVehicule`) REFERENCES `typevehicule` (`idTypeVehicule`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
