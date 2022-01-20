CREATE DATABASE  IF NOT EXISTS `travel_agency_db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `travel_agency_db`;
-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: travel_agency_db
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `city` (
  `idCity` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `idCountry` int(11) NOT NULL,
  PRIMARY KEY (`idCity`),
  KEY `fk_City_Country1_idx` (`idCountry`),
  CONSTRAINT `fk_City_Country1` FOREIGN KEY (`idCountry`) REFERENCES `country` (`idcountry`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,'Banja Luka',1),(2,'Havana',2),(3,'Los Angeles',3),(4,'Paris',4),(5,'New York',3),(6,'Zagreb',5),(7,'Trebinje',1),(8,'Foča',1),(9,'Beč',6),(11,'Grac',6),(12,'Houston',3),(13,'Barselona',7),(14,'Varadero',2),(15,'Madrid',7),(16,'Doboj',1),(17,'Višegrad',1),(18,'Bangkok',8),(19,'Sarajevo',1);
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `idPerson` int(11) NOT NULL,
  `passport` char(8) NOT NULL,
  `isActive` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`idPerson`),
  UNIQUE KEY `passport_UNIQUE` (`passport`),
  KEY `fk_Client_Person_idx` (`idPerson`),
  CONSTRAINT `fk_Client_Person` FOREIGN KEY (`idPerson`) REFERENCES `person` (`idperson`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (2,'12345678',1),(3,'TT250002',1),(5,'EE126922',1),(6,'55555555',1),(7,'AA888555',1),(8,'ee888888',1),(9,'44455566',1),(13,'785412EE',1);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `country` (
  `idCountry` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idCountry`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'BiH'),(2,'Kuba'),(3,'SAD'),(4,'Francuska'),(5,'Hrvatska'),(6,'Austrija'),(7,'Španija'),(8,'Tajland');
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `person` (
  `idPerson` int(11) NOT NULL AUTO_INCREMENT,
  `pid` char(13) NOT NULL,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `address` varchar(45) NOT NULL,
  `phone` char(11) NOT NULL,
  `email` varchar(45) NOT NULL,
  `idCity` int(11) NOT NULL,
  PRIMARY KEY (`idPerson`),
  UNIQUE KEY `PID_UNIQUE` (`pid`),
  KEY `fk_Person_City1_idx` (`idCity`),
  CONSTRAINT `fk_Person_City1` FOREIGN KEY (`idCity`) REFERENCES `city` (`idcity`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'0109993106060','Tijana','Lakić','Boška Tošića','065/065-065','tijanalakic@gmail.com',1),(2,'2005996106060','Tanja','Lakić','Vidovdanska bb','066/066-066','tanjalakic@gmail.com',1),(3,'0101223656565','Marija','Marić','Ive Andrića bb','065/123-456','marija.maric@gmail.com',1),(4,'0102006989898','Eva','Marej','Pariska 17','033/897-352','eva.marej@yahoo.com',4),(5,'2202995202020','Una','West','Beogradska 13','066/565-656','test@test.com',2),(6,'0000000000001','Eda','Yildez','Bosfor','065/000-000','eda2021@fox.com',3),(7,'5505555636363','Ana','Borković','Majke Jugovića 7','065/999-999','anab@yahoo.co',1),(8,'0202229656565','Dijana','Dobrić','Vidovdanska 1','065/953-815','dijana@gmail.com',1),(9,'8889996665554','Marko','Marković','Kozarska 30','065/989-989','marko@gmail.com',2),(10,'8579586589898','Ivan','Milć','Balkanska','069/655-999','ivan@gmail.com',15),(11,'2345678655432','Milan','Bojić','Petra Pecije 15','065/655-998','milanb@gmail.com',1),(13,'2005998105050','Tara','Đoković','Francuska 21','065/666-777','tara@gmail.com',19);
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `idRole` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idRole`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'admin'),(2,'referent');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transportationtype`
--

DROP TABLE IF EXISTS `transportationtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transportationtype` (
  `idTransportationType` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idTransportationType`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transportationtype`
--

LOCK TABLES `transportationtype` WRITE;
/*!40000 ALTER TABLE `transportationtype` DISABLE KEYS */;
INSERT INTO `transportationtype` VALUES (1,'avion'),(2,'autobus');
/*!40000 ALTER TABLE `transportationtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `traveloffer`
--

DROP TABLE IF EXISTS `traveloffer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `traveloffer` (
  `idTravelOffer` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `price` decimal(8,2) NOT NULL,
  `departureDate` date NOT NULL,
  `arrivalDate` date NOT NULL,
  `maxPassangerNumber` int(11) NOT NULL,
  `passangerNumber` int(11) NOT NULL DEFAULT '0',
  `description` varchar(1000) DEFAULT NULL,
  `idTransportationType` int(11) NOT NULL,
  `idCity` int(11) NOT NULL,
  `isActive` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`idTravelOffer`),
  UNIQUE KEY `duration_UNIQUE` (`maxPassangerNumber`),
  KEY `fk_TravelOffer_TransportationType1_idx` (`idTransportationType`),
  KEY `fk_TravelOffer_City1_idx` (`idCity`),
  CONSTRAINT `fk_TravelOffer_City1` FOREIGN KEY (`idCity`) REFERENCES `city` (`idcity`),
  CONSTRAINT `fk_TravelOffer_TransportationType1` FOREIGN KEY (`idTransportationType`) REFERENCES `transportationtype` (`idtransportationtype`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traveloffer`
--

LOCK TABLES `traveloffer` WRITE;
/*!40000 ALTER TABLE `traveloffer` DISABLE KEYS */;
INSERT INTO `traveloffer` VALUES (1,'Valentinovo u Parizu',500.00,'2021-02-12','2021-02-20',30,1,'Putovanje za zaljubljene u čarobnom Parizu.',1,4,1),(2,'Kuba u Februaru 2021',999.00,'2021-03-01','2021-03-15',60,2,'***Avanturisticka Kuba ***',1,2,1),(6,'Ekskurzija ',1563.00,'2021-03-18','2021-03-25',250,4,'7dnevna eksurzija u Španiju\r\n***plan puta***\r\npolazak 18-03-2021 u 06.00h',2,13,1),(7,'Maldivi',1200.00,'2021-03-30','2021-04-03',9,2,'Čarobni Maldivi',1,2,1),(8,'Tajland 15 dana',0.00,'2021-02-08','2021-02-22',40,1,'***Plan puta***\r\nPolazak 08.02.2021 u 6h sa aerodroma u Beogradu.\r\n*\r\n*\r\n*\r\n',1,18,1);
/*!40000 ALTER TABLE `traveloffer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `traveloffer_has_client`
--

DROP TABLE IF EXISTS `traveloffer_has_client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `traveloffer_has_client` (
  `idTravelOffer` int(11) NOT NULL,
  `idPerson` int(11) NOT NULL,
  PRIMARY KEY (`idTravelOffer`,`idPerson`),
  KEY `fk_TravelOffer_has_Client_Client1_idx` (`idPerson`),
  KEY `fk_TravelOffer_has_Client_TravelOffer1_idx` (`idTravelOffer`),
  CONSTRAINT `fk_TravelOffer_has_Client_Client1` FOREIGN KEY (`idPerson`) REFERENCES `client` (`idperson`),
  CONSTRAINT `fk_TravelOffer_has_Client_TravelOffer1` FOREIGN KEY (`idTravelOffer`) REFERENCES `traveloffer` (`idtraveloffer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traveloffer_has_client`
--

LOCK TABLES `traveloffer_has_client` WRITE;
/*!40000 ALTER TABLE `traveloffer_has_client` DISABLE KEYS */;
INSERT INTO `traveloffer_has_client` VALUES (1,2),(6,2),(8,2),(1,3),(2,3),(6,3),(7,3),(6,5),(7,5),(2,6),(6,6);
/*!40000 ALTER TABLE `traveloffer_has_client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `idPerson` int(11) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(45) NOT NULL,
  `idRole` int(11) NOT NULL,
  `isActive` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`idPerson`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  KEY `fk_User_Person1_idx` (`idPerson`),
  KEY `fk_User_Role1_idx` (`idRole`),
  CONSTRAINT `fk_User_Person1` FOREIGN KEY (`idPerson`) REFERENCES `person` (`idperson`),
  CONSTRAINT `fk_User_Role1` FOREIGN KEY (`idRole`) REFERENCES `role` (`idrole`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin123','admin123',1,1),(4,'evaeva123','evaeva123',2,1),(10,'ivanivan','ivanivan',2,1),(11,'milanbojic1','milanmilan',2,0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-04 18:06:44
