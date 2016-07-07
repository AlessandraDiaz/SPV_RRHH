-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: rrhh
-- ------------------------------------------------------
-- Server version	5.5.50-log

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
-- Table structure for table `tb_convocatoria`
--

DROP TABLE IF EXISTS `tb_convocatoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_convocatoria` (
  `PK_CodigoConvocatoria` int(11) NOT NULL AUTO_INCREMENT,
  `NombreConvocatoria` varchar(45) NOT NULL,
  `CodigoTipo` int(11) NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL,
  `CodigoSolicitud` int(11) NOT NULL,
  `FechaCreacion` datetime NOT NULL,
  `CodigoEstado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoConvocatoria`),
  KEY `CodigoTipo` (`CodigoTipo`),
  KEY `CodigoSolicitud` (`CodigoSolicitud`),
  KEY `CodigoEstado` (`CodigoEstado`),
  CONSTRAINT `tb_convocatoria_ibfk_1` FOREIGN KEY (`CodigoTipo`) REFERENCES `tb_parametros` (`PK_CodigoParametro`),
  CONSTRAINT `tb_convocatoria_ibfk_2` FOREIGN KEY (`CodigoSolicitud`) REFERENCES `tb_solicitudpersonal` (`PK_CodigoSolicitud`),
  CONSTRAINT `tb_convocatoria_ibfk_3` FOREIGN KEY (`CodigoEstado`) REFERENCES `tb_parametros` (`PK_CodigoParametro`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_convocatoria`
--

LOCK TABLES `tb_convocatoria` WRITE;
/*!40000 ALTER TABLE `tb_convocatoria` DISABLE KEYS */;
INSERT INTO `tb_convocatoria` VALUES (1,'TEST',7,'2016-07-15 00:00:00','2016-07-20 00:00:00',5,'2016-07-07 06:50:44',1),(2,'TEST 2',6,'2016-08-15 00:00:00','2016-08-30 00:00:00',1,'2016-07-07 07:03:12',1);
/*!40000 ALTER TABLE `tb_convocatoria` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-07-07  8:48:19
