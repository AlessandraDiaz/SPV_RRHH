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
-- Table structure for table `tb_solicitudpersonal`
--

DROP TABLE IF EXISTS `tb_solicitudpersonal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_solicitudpersonal` (
  `PK_CodigoSolicitud` int(11) NOT NULL AUTO_INCREMENT,
  `CodigoInterno` varchar(10) NOT NULL,
  `TipoConvocatoria` int(11) NOT NULL,
  `TipoSolicitud` int(11) NOT NULL,
  `Motivo` int(11) NOT NULL,
  `FechaSolicitud` datetime NOT NULL,
  `FechaPresentacion` datetime DEFAULT NULL,
  `FechaEnvio` datetime DEFAULT NULL,
  `CodigoCampana` int(11) DEFAULT NULL,
  `FK_CodigoCargo` int(11) NOT NULL,
  `Moneda` int(11) NOT NULL,
  `Sueldo` decimal(18,2) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `Comentarios` varchar(250) DEFAULT NULL,
  `Estado` int(11) NOT NULL,
  `FK_CodigoUsuario` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoSolicitud`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_solicitudpersonal`
--

LOCK TABLES `tb_solicitudpersonal` WRITE;
/*!40000 ALTER TABLE `tb_solicitudpersonal` DISABLE KEYS */;
INSERT INTO `tb_solicitudpersonal` VALUES (1,'SL1CA1',1,1,1,'2016-06-26 00:00:00','2016-06-30 00:00:00','2016-07-07 00:00:00',1,1,1,1500.50,3,'ok',2,2),(3,'SL1CA3',2,2,3,'2016-07-06 00:00:00','2016-07-13 00:00:00','2016-07-07 00:00:00',1,1,1,1700.00,5,'nuu',3,2),(5,'SL1CA5',1,2,3,'2016-07-06 00:00:00','2016-06-30 00:00:00',NULL,1,1,1,1000.00,2,'',1,2);
/*!40000 ALTER TABLE `tb_solicitudpersonal` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-07-07  8:48:21
