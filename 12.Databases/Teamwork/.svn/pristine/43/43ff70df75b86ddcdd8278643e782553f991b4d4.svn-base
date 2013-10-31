CREATE DATABASE  IF NOT EXISTS `supermarket` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `supermarket`;
-- MySQL dump 10.13  Distrib 5.5.32, for Win64 (x86)
--
-- Host: localhost    Database: supermarket
-- ------------------------------------------------------
-- Server version	5.5.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `ProductId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(45) NOT NULL,
  `ProductPrice` decimal(10,2) NOT NULL,
  `VendorId` int(11) NOT NULL,
  `MeasureId` int(11) NOT NULL,
  PRIMARY KEY (`ProductId`),
  UNIQUE KEY `ProductId_UNIQUE` (`ProductId`),
  KEY `fk_Products_Vendors_idx` (`VendorId`),
  KEY `fk_Products_Measurs1_idx` (`MeasureId`),
  CONSTRAINT `fk_Products_Measurs1` FOREIGN KEY (`MeasureId`) REFERENCES `measures` (`MeasureId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Products_Vendors` FOREIGN KEY (`VendorId`) REFERENCES `vendors` (`VendorId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Zagorka Light',1.25,2,1),(2,'Zagorka Dark',1.15,2,1),(3,'Zagorka Fusion',1.32,2,1),(4,'Zagorka Ultimate',1.52,2,1),(5,'Zagorka For Men',2.00,2,1),(6,'Kamenitsa Light',1.14,4,1),(7,'Kamenitsa Dark',1.50,4,1),(8,'Kamenitsa Special',2.11,4,1),(9,'Kamenitsa For Men',1.54,4,1),(10,'Kamenitsa Ultimate',2.12,4,1),(11,'Dark Chocolate',1.45,1,2),(12,'Milk Chocolate',1.39,1,2),(13,'Milk Chocolate with Nuts',1.87,1,2),(14,'Milk Chocolate 200',2.83,1,2),(15,'Dark Chocolate 200',3.12,1,2);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-22 12:59:12
