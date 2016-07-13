CREATE DATABASE  IF NOT EXISTS `rrhh` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `rrhh`;
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
-- Table structure for table `help`
--

DROP TABLE IF EXISTS `help`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `help` (
  `TEST` varchar(10000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `help`
--

LOCK TABLES `help` WRITE;
/*!40000 ALTER TABLE `help` DISABLE KEYS */;
INSERT INTO `help` VALUES (' SELECT 	A.PK_CodigoSolicitud,A.CodigoInterno,A.TipoConvocatoria, tc.Descripcion as TipoConvocatoriaDes, A.TipoSolicitud, ts.Descripcion as TipoSolicitudDes,A.Motivo, M.Descripcion as MotivoDes, A.FechaSolicitud, A.FechaPresentacion, A.FechaEnvio, A.CodigoCampana, C.Descripcion as Campana, c.FechaInicio, c.FechaFin, A.FK_CodigoCargo, cg.Descripcion, cg.Funciones,cg.Requisitos, cg.SueldoMin, cg.SueldoMax, A.Sueldo, A.Moneda, MN.Descripcion as MonedaDes, A.Cantidad, A.Comentarios, A.Estado, E.Descripcion as EstadoDes, A.FK_CodigoUsuario FROM tb_solicitudpersonal A  INNER JOIN tb_parametros tc on a.TipoConvocatoria = tc.codigo and tc.codigoAgrupador = 3 and tc.estado = 1 INNER JOIN tb_parametros ts on a.TipoSolicitud = ts.codigo and ts.codigoAgrupador = 1 and ts.estado = 1 INNER JOIN tb_parametros M on a.Motivo = M.codigo and M.codigoAgrupador = 4 and M.estado = 1 INNER JOIN tb_parametros E on a.Estado = E.codigo and E.codigoAgrupador = 2 and E.estado = 1 INNER JOIN tb_parametros MN on a.Moneda = MN.codigo and MN.codigoAgrupador = 5 and MN.estado = 1 INNER JOIN tb_cargo CG on a.FK_CodigoCargo = cg.pk_cargo and cg.estado = 1 INNER JOIN tb_usuario U on a.FK_CodigoUsuario = U.PK_CodigoUsuario LEFT JOIN tb_campana C ON A.CodigoCampana = C.PK_CODIGOcAMPANA and c.estado = 1 WHERE 1 = 1  AND (A.PK_CodigoSolicitud NOT IN (SELECT CodigoSolicitud FROM tb_convocatoria)) AND ((2= 0) OR (A.TipoSolicitud =2)) AND ((2= 0) OR (A.Estado =2)) AND ((0= 0) OR (A.FK_CodigoUsuario =0)) AND ((2= 0) OR (U.FK_CodigoLocal =2)) AND ((0= 0) OR (U.FK_CodigoArea =0))');
/*!40000 ALTER TABLE `help` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_area`
--

DROP TABLE IF EXISTS `tb_area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_area` (
  `PK_CodigoArea` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(100) NOT NULL,
  `Estado` int(1) NOT NULL,
  PRIMARY KEY (`PK_CodigoArea`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_area`
--

LOCK TABLES `tb_area` WRITE;
/*!40000 ALTER TABLE `tb_area` DISABLE KEYS */;
INSERT INTO `tb_area` VALUES (0,'TODAS',1),(1,'CAJA',1),(2,'LACTEOS',1),(3,'PERFUMERIAS',1),(4,'PANADERIA',1);
/*!40000 ALTER TABLE `tb_area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_campana`
--

DROP TABLE IF EXISTS `tb_campana`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_campana` (
  `PK_CodigoCampana` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(50) DEFAULT NULL,
  `FechaInicio` datetime DEFAULT NULL,
  `FechaFin` datetime DEFAULT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoCampana`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_campana`
--

LOCK TABLES `tb_campana` WRITE;
/*!40000 ALTER TABLE `tb_campana` DISABLE KEYS */;
INSERT INTO `tb_campana` VALUES (1,'FIESTAS PATRIAS','2016-08-01 00:00:00','2016-09-01 00:00:00',1);
/*!40000 ALTER TABLE `tb_campana` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_cargo`
--

DROP TABLE IF EXISTS `tb_cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_cargo` (
  `PK_Cargo` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(50) NOT NULL,
  `Funciones` varchar(250) DEFAULT NULL,
  `Requisitos` varchar(250) DEFAULT NULL,
  `SueldoMin` decimal(18,2) NOT NULL,
  `SueldoMax` decimal(18,2) NOT NULL,
  `Estado` int(1) NOT NULL,
  PRIMARY KEY (`PK_Cargo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_cargo`
--

LOCK TABLES `tb_cargo` WRITE;
/*!40000 ALTER TABLE `tb_cargo` DISABLE KEYS */;
INSERT INTO `tb_cargo` VALUES (1,'Cajero','Funciones de Caja','Tecnicos',1000.00,2000.00,1),(2,'Almacenero','Funciones de almacen','Basicos',850.00,1500.00,1),(3,'Embutidos','Corte de embutidos','secundaria completa',900.00,1500.00,1),(4,'Panaderia','Funciones panaderia','Basicos',1000.00,1500.00,1),(5,'Chef','Funciones cocinero','Estudios de cocina',1500.00,2500.00,1);
/*!40000 ALTER TABLE `tb_cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_colaborador`
--

DROP TABLE IF EXISTS `tb_colaborador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_colaborador` (
  `PK_CodigoColaborador` int(11) NOT NULL AUTO_INCREMENT,
  `ApellidoPaterno` varchar(50) NOT NULL,
  `ApellidoMaterno` varchar(50) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Dni` varchar(8) NOT NULL,
  `FechaNacimiento` datetime NOT NULL,
  `Sexo` varchar(1) NOT NULL,
  `Direccion` varchar(100) NOT NULL,
  `Telefono` varchar(10) NOT NULL,
  `Correo` varchar(100) NOT NULL,
  `CurriculumVitae` varchar(100) NOT NULL,
  `EstadoCivil` varchar(1) NOT NULL,
  `CantidadHijos` int(1) NOT NULL,
  `Seguro` varchar(45) NOT NULL,
  `CodigoEssalud` varchar(45) NOT NULL,
  `Fechacese` datetime NOT NULL,
  `AntecedentePolicial` varchar(100) NOT NULL,
  `FK_CodigoUsuario` int(11) DEFAULT NULL,
  `tipoColaborador` int(1) DEFAULT NULL,
  `foto` varchar(45) DEFAULT NULL,
  `estado_postulante_convocatoria` int(1) DEFAULT NULL,
  `estado_aceptacion` int(1) DEFAULT NULL,
  `FK_CodigoConvocatoria` int(11) DEFAULT NULL,
  `FK_CodigoCV` int(11) DEFAULT NULL,
  `RindioExamen` int(1) DEFAULT NULL,
  `PuntajeFinal` int(2) DEFAULT NULL,
  PRIMARY KEY (`PK_CodigoColaborador`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_colaborador`
--

LOCK TABLES `tb_colaborador` WRITE;
/*!40000 ALTER TABLE `tb_colaborador` DISABLE KEYS */;
INSERT INTO `tb_colaborador` VALUES (1,'VARGAS','PAUCAR','ROGERD','40521561','2011-08-21 00:00:00','M','AV PASEO DE LA REPUBLICA 3717','985456855','Carlosdevelop@gmail.com','CV_40521561.docx','S',0,'SNP-40521561','ESS-40521561','2011-08-21 00:00:00','AP_40521561.docx',1,1,'40521561.jpg',0,0,0,1,0,NULL),(2,'DIAZ','PUELLES','ALESSANDRA','41524875','2011-08-21 00:00:00','F','CALLE MONTI 112','963258745','alessdiaz1xcvg@gmail.com','CV_41524875.docx','S',0,'SNP-41524875','ESS-41524875','2011-08-21 00:00:00','AP_41524875.docx',2,1,'41524875.jpg',0,0,0,2,0,NULL),(3,'TAIPE','PENAFIELD','RICHARD','43215894','2011-08-21 00:00:00','F','AV. CENTRAL 1518','945632587','1rtaipe08@gmail.com','CV_43215894.docx','C',1,'SNP-43215894','ESS-43215894','2011-08-21 00:00:00','AP_43215894.docx',3,1,'43215894.jpg',0,0,0,3,0,NULL),(4,'RAMOS','BACA','ROGER','40254156','2011-08-21 00:00:00','M','AV. PRIMAVERA 3817','3258745','1softhard01@gmailcom','CV_40254156.docx','S',1,'SNP-40254156','ESS-40254156','2011-08-21 00:00:00','AP_40254156.docx',4,1,'40254156.jpg',0,0,0,4,0,NULL),(5,'PINCO','MENDO','CRISTHIAN','42515461','2011-08-21 00:00:00','M','CALLE 48 5876','985647124','1cepm2211@gmail.com','CV_42515461.docx','C',2,'AFP-42515461','ESS-42515461','2011-08-21 00:00:00','AP_42515461.docx',5,1,'42515461.jpg',0,0,0,5,0,NULL),(6,'PACHAS','PACHAS','ALEX','44518597','2011-08-21 00:00:00','M','CALLE LAS GARZAS 258','945135483','PACHAS.PACHAS.A@gmail.com','CV_44518597.docx','C',1,'AFP-44518597','ESS-44518597','2011-08-21 00:00:00','AP_44518597.docx',6,2,'44518597.jpg',1,2,1,6,0,11),(7,'ROQUE','HUARICO','ANTONIO','32154879','2011-08-21 00:00:00','M','AV LA MARINA 2330','978741542','ROQUE.HUARICO.A@gmail.com','CV_32154879.docx','S',0,'AFP-32154879','ESS-32154879','2011-08-21 00:00:00','AP_32154879.docx',7,2,'32154879.jpg',1,2,1,7,0,12),(8,'CONTACTO','CONTACTO','CONTACTO','45792116','1986-08-21 00:00:00','M','AV LA SALA 2330','978741542','aless.diaz1@gmail.com','CV_32154879.docx','S',0,'AFP-32154879','ESS-32154879','2011-08-21 00:00:00','AP_32154879.docx',0,0,'',0,0,0,8,0,NULL),(9,'CASTILLO','CALDERON','ALFREDO','43215151','1988-08-31 00:00:00','M','JR DE LA UNION 765','986768131','abc.qw123@gmail.com','','C',2,'SNP-43215151','ESS-43215151','2011-08-21 00:00:00','AP-43215151',8,2,'43215151.jpg',1,1,1,9,0,13),(10,'AGUIRRE','DIAZ','SOLANGE','41980569','1992-05-24 00:00:00','F','AV. CONSTUCTORES 134','999185695','solange@gmail.com','','S',1,'AFP-41980569','ESS-41980569','2011-08-21 00:00:00','AP-41980569',0,2,'41980569.jpg',0,0,0,10,0,NULL),(11,'LANDEO','LOPERA','GIOVANNY','44274841','1988-05-20 00:00:00','M','AV. PARDO 765','983880249','landeo.lopea@gmail.com','','S',2,'SNP-44274841','ESS-44274841','2011-08-21 00:00:00','AP-44274841',9,2,'44274841.jpg',1,1,1,11,0,14),(12,'LLAHUANA','CCUA','KARINA','43247460','1991-03-22 00:00:00','F','AV. SAN LUIS 1034','965292635','karina.llahuana@gmail.com','','C',3,'SNP-43247460','ESS-43247460','2011-08-21 00:00:00','AP-43247460',0,2,'43247460.jpg',0,0,0,12,0,NULL),(13,'NUNEZ','TELLO','RODRIGO','45984829','1987-04-28 00:00:00','M','AV. AVIACION 2845','979625903','rnunez23@gmail.com','','S',2,'SNP-45984829','ESS-45984829','2011-08-21 00:00:00','AP-45984829',10,2,'45984829.jpg',1,0,3,13,0,15),(14,'LLERENA','VELARDE','FREDDY','43079891','1994-12-11 00:00:00','M','CA. 2 DE MAYO 756','961651014','freddy.llerena@gmail.com','','S',0,'AFP-43079891','ESS-43079891','2011-08-21 00:00:00','AP-43079891',11,2,'43079891.jpg',1,0,14,14,0,19),(15,'PALOMINO','TRIVENO','ALDO','45372560','1992-09-13 00:00:00','M','URB. LIMATAMBO, CA. AZUL 234','962148732','aldo.palomino@gmail.com','','C',1,'SNP-45372560','ESS-45372560','2011-08-21 00:00:00','AP-45372560',0,2,'45372560.jpg',0,0,0,15,0,NULL),(16,'NUNEZ','MENDOZA','ANGEL','45737562','1994-10-15 00:00:00','M','CA. CERRO AZUL 123','996270464','angel.nuNez@gmail.com','','S',0,'AFP-45737562','ESS-45737562','2011-08-21 00:00:00','AP-45737562',0,2,'45737562.jpg',0,0,0,16,0,NULL);
/*!40000 ALTER TABLE `tb_colaborador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_contrato`
--

DROP TABLE IF EXISTS `tb_contrato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_contrato` (
  `PK_CodigoContrato` int(11) NOT NULL AUTO_INCREMENT,
  `FechaInicio` date NOT NULL,
  `FechaFin` date NOT NULL,
  `TipoContrato` int(11) NOT NULL,
  `Estado` int(1) NOT NULL,
  PRIMARY KEY (`PK_CodigoContrato`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_contrato`
--

LOCK TABLES `tb_contrato` WRITE;
/*!40000 ALTER TABLE `tb_contrato` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_contrato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_convocatoria`
--

DROP TABLE IF EXISTS `tb_convocatoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_convocatoria` (
  `PK_CodigoConvocatoria` int(11) NOT NULL AUTO_INCREMENT,
  `CodigoInterno` varchar(15) DEFAULT NULL,
  `NombreConvocatoria` varchar(45) NOT NULL,
  `FechaInicio` date NOT NULL,
  `FechaFin` date NOT NULL,
  `CodigoSolicitud` int(11) NOT NULL,
  `FechaCreacion` date NOT NULL,
  `CodigoEstado` int(11) NOT NULL,
  `Fase` int(1) DEFAULT NULL,
  PRIMARY KEY (`PK_CodigoConvocatoria`),
  KEY `CodigoSolicitud` (`CodigoSolicitud`),
  KEY `CodigoEstado` (`CodigoEstado`),
  CONSTRAINT `tb_convocatoria_ibfk_2` FOREIGN KEY (`CodigoSolicitud`) REFERENCES `tb_solicitudpersonal` (`PK_CodigoSolicitud`),
  CONSTRAINT `tb_convocatoria_ibfk_3` FOREIGN KEY (`CodigoEstado`) REFERENCES `tb_parametros` (`PK_CodigoParametro`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_convocatoria`
--

LOCK TABLES `tb_convocatoria` WRITE;
/*!40000 ALTER TABLE `tb_convocatoria` DISABLE KEYS */;
INSERT INTO `tb_convocatoria` VALUES (1,'CONCA001','CAJEROS PARA CAMPAÑA','2016-07-01','2016-07-12',1,'2016-07-10',3,3),(2,'CONCA002','CONVOCATORIA DE PERSONAL','2016-07-02','2016-07-20',3,'2016-07-10',2,2),(3,'CONCA003','PERSONAL PARA ALMACÉN','2016-07-03','2016-07-19',7,'2016-07-10',2,3),(14,'CONCA014','PRUEBA CERDS','2016-07-11','2016-07-28',14,'2016-07-10',2,3);
/*!40000 ALTER TABLE `tb_convocatoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_curriculumvitae`
--

DROP TABLE IF EXISTS `tb_curriculumvitae`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_curriculumvitae` (
  `PK_CodigoCV` int(11) NOT NULL AUTO_INCREMENT,
  `Profesion` varchar(200) NOT NULL,
  `nivelAcademico` varchar(100) NOT NULL,
  `centroEstudio` varchar(200) NOT NULL,
  `anioEgreso` int(4) NOT NULL,
  `trabajo1` varchar(200) NOT NULL,
  `periodo1` varchar(500) NOT NULL,
  `funciones1` varchar(1000) NOT NULL,
  `trabajo2` varchar(200) NOT NULL,
  `periodo2` varchar(500) NOT NULL,
  `funciones2` varchar(1000) NOT NULL,
  `trabajo3` varchar(200) NOT NULL,
  `periodo3` varchar(500) NOT NULL,
  `funciones3` varchar(1000) NOT NULL,
  PRIMARY KEY (`PK_CodigoCV`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_curriculumvitae`
--

LOCK TABLES `tb_curriculumvitae` WRITE;
/*!40000 ALTER TABLE `tb_curriculumvitae` DISABLE KEYS */;
INSERT INTO `tb_curriculumvitae` VALUES (1,'INGENERIO CIVIL','BACHILLER','UPC',2017,'','','','','','','','',''),(2,'ADMINISTRACION EMPRESAS','BACHILLER','UPC',2017,'','','','','','','','',''),(3,'INGENIERO INDUSTRIAL','BACHILLER','UPC',2017,'','','','','','','','',''),(4,'MARKETING','BACHILLER','UPC',2017,'','','','','','','','',''),(5,'PUBLICIDAD','BACHILLER','UPC',2017,'','','','','','','','',''),(6,'COMPUTACION E INFORMATICA','ESTUDIANTE','XYZ',0,'EMPRESA ABC SAC','DE ENERO DEL 2014 A JUNIO DEL 2015','ATENCION AL CLIENTE','EMPRESA 123 ERIL','DE FEBRERO DEL 2014 A DICIEMBRE DEL 2014','CALL CENTER','','',''),(7,'ADMINISTRACION Y MARKETING','ESTUDIANTE','XYZ',0,'TELEVENTAS SRL','DE JUNIO DEL 2015 A NOVIEMBRE DEL 2015','CALL CENTER','GRIFO REPSOL','DE FEBRERO DEL 2014 A DICIEMBRE DEL 2014','ATENCION AL CLIENTE',' RIPLEY S.A.C','DE FEBRERO DEL 2013 A OCTUBRE DEL 2013','REPONEDOR DE PRODUCTOS'),(8,'','','',0,'','','','','','','','',''),(9,'ADMINISTRACION EMPRESAS','COMPLETO','ABC',2013,'ALMACENES LA GUARDIA','DE FEBRERO DEL 2013 A AGOSTO DEL 2015','REVISION DE PRODUCTOS','ALMACENES BONITA','DE NOVIEMBRE DEL 2012 A ENERO DEL 2013','ELABORACION KARDEX','','',''),(10,'DISENO GRAFICO','ESTUDIANTE','ABC',0,'GROUP V&G','DE MARZO DEL 2015 A DICIEMBRE DEL 2016','ATENCION AL CLIENTE','','','','','',''),(11,'-','-','',0,'CENCOSUD SA','DE MAYO DEL 2016 A JUNIO DEL 2016','REPONEDOR DE PRODUCTOS','TOPI TOP','DE ABRIL DEL 2015 A FEBRERO DEL 2016','REPONEDOR DE PRODUCTOS','','',''),(12,'-','-','',0,'TIENDAS MAKRO','DE ENERO DEL 2016 A MAYO DEL 2016','REPONEDOR DE PRODUCTOS','MAESTRO HOME CENTER','DE AGOSTO DEL 2014 A NOVIEMBE DEL 2015','REPONEDOR DE PRODUCTOS','','',''),(13,'INGENIERIA INDUSTRIAL','INCOMPLETO','DFGR',0,'HIPERMERCADOS TOTTUS','DE JULIO DEL 2015 A DICIEMBRE DEL 2015','MERCHANDISING','LICORERIA EL TAMBO','DE SEPTIEMBE DEL 2013 A MAYO DEL 2015','REPONEDOR DE PRODUCTOS','','',''),(14,'-','-','',0,'SAGA FALABELLA SA','DE SEPTIEMBRE DEL 2015 A FEBRERO DEL 2016','CAJERO','DISTRIBUIDORA ALMENDARIZ','DE AGOSTO DEL 2014 A JUNIO DEL 2015','REPONEDOR DE PRODUCTOS','','',''),(15,'CIENCIAS DE LA COMUNICACION','ESTUDIANTE','DFERD',0,'TOPI TOP PERU','DE FEBRERO DEL 2014 A MAYO DEL 2016','CAJERO','','','','','',''),(16,'-','-','',0,'EMBARCADERO 41','DE ENERO DEL 2016 A MARZO DEL 2016','ATENCION AL CLIENTE','','','','','','');
/*!40000 ALTER TABLE `tb_curriculumvitae` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_examen`
--

DROP TABLE IF EXISTS `tb_examen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_examen` (
  `PK_CodigoExamen` int(11) NOT NULL AUTO_INCREMENT,
  `NombreExamen` varchar(45) NOT NULL,
  `Descripcion` varchar(45) NOT NULL,
  `Estado` int(1) NOT NULL,
  PRIMARY KEY (`PK_CodigoExamen`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_examen`
--

LOCK TABLES `tb_examen` WRITE;
/*!40000 ALTER TABLE `tb_examen` DISABLE KEYS */;
INSERT INTO `tb_examen` VALUES (1,'EVALUACION PSICOTECNICA - NRO1','PRUEBA ESPECIAL PARA EL CARGO DE CAJERO',1),(2,'PRUEBA PSICOTECNICA - NRO56','PRUEBA ESPECIAL PARA EL CARGO DE REPONEDORES',1),(3,'TEST PSICOTECNICO ','PRUEBA ESPECIAL PARA EL CARGO DE ALMACENERO',1);
/*!40000 ALTER TABLE `tb_examen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_local`
--

DROP TABLE IF EXISTS `tb_local`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_local` (
  `PK_CodigoLocal` int(11) NOT NULL AUTO_INCREMENT,
  `NombreLocal` varchar(45) NOT NULL,
  `Direccion` varchar(100) NOT NULL,
  PRIMARY KEY (`PK_CodigoLocal`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_local`
--

LOCK TABLES `tb_local` WRITE;
/*!40000 ALTER TABLE `tb_local` DISABLE KEYS */;
INSERT INTO `tb_local` VALUES (0,'TODAS','TODAS'),(1,'PLAZA VEA-LA MOLINA','AV. RAUL FERRERO 1205 URB. REMANSO II ETAPA'),(2,'PLAZA VEA-CAMINOS DEL INCA','AV. CAMINOS DEL INCA 351 CHACARILLA');
/*!40000 ALTER TABLE `tb_local` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_parametros`
--

DROP TABLE IF EXISTS `tb_parametros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_parametros` (
  `PK_CodigoParametro` int(11) NOT NULL AUTO_INCREMENT,
  `CodigoAgrupador` int(11) NOT NULL,
  `DesAgrupador` varchar(100) DEFAULT NULL,
  `Codigo` int(11) DEFAULT NULL,
  `Descripcion` varchar(100) DEFAULT NULL,
  `Valor` varchar(100) DEFAULT NULL,
  `Estado` int(11) DEFAULT NULL,
  PRIMARY KEY (`PK_CodigoParametro`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_parametros`
--

LOCK TABLES `tb_parametros` WRITE;
/*!40000 ALTER TABLE `tb_parametros` DISABLE KEYS */;
INSERT INTO `tb_parametros` VALUES (1,1,'TBL_TIPO_SOLICITUD',1,'FIJO',NULL,1),(2,1,'TBL_TIPO_SOLICITUD',2,'TEMPORAL',NULL,1),(3,2,'TBL_ESTADO_SOLICITUD',1,'PENDIENTE',NULL,1),(4,2,'TBL_ESTADO_SOLICITUD',2,'APROBADO',NULL,1),(5,2,'TBL_ESTADO_SOLICITUD',3,'RECHAZADO',NULL,1),(6,3,'TBL_TIPO_CONVOCATORIA',1,'INTERNO',NULL,1),(7,3,'TBL_TIPO_CONVOCATORIA',2,'EXTERNO',NULL,1),(8,4,'TBL_MOTIVO_SOLICITUD',1,'REEMPLAZO','1',1),(9,4,'TBL_MOTIVO_SOLICITUD',2,'AUMENTO DE PERSONAL','1',1),(10,4,'TBL_MOTIVO_SOLICITUD',3,'CAMPAÑA','2',1),(11,4,'TBL_MOTIVO_SOLICITUD',4,'LICENCIA','2',1),(12,4,'TBL_MOTIVO_SOLICITUD',5,'DESCANSO MEDICO','2',1),(13,4,'TBL_MOTIVO_SOLICITUD',6,'VACACIONES','2',1),(14,5,'TBL_MONEDA',1,'SOLES',NULL,1),(15,5,'TBL_MONEDA',2,'DOLARES',NULL,1),(21,7,'TBL_FILTRO_SOLICITUD',1,'CÓDIGO',NULL,1),(22,7,'TBL_FILTRO_SOLICITUD',2,'TIPO DE SOLICITUD',NULL,1),(23,7,'TBL_FILTRO_SOLICITUD',3,'MOTIVO',NULL,1),(24,7,'TBL_FILTRO_SOLICITUD',4,'CARGO',NULL,1),(25,7,'TBL_FILTRO_SOLICITUD',5,'FECHA DE SOLICITUD',NULL,1),(26,7,'TBL_FILTRO_SOLICITUD',6,'FECHA DE PRESENTACIÓN',NULL,1),(27,7,'TBL_FILTRO_SOLICITUD',7,'FECHA DE ENVÍO',NULL,1),(28,2,'TBL_ESTADO_SOLICITUD',4,'ENVIADO',NULL,1),(29,8,'TBL_ESTADO_CONVOCA',1,'PENDIENTE',NULL,1),(30,8,'TBL_ESTADO_CONVOCA',2,'PUBLICADO',NULL,1),(31,8,'TBL_ESTADO_CONVOCA',3,'FINALIZADO',NULL,1),(32,8,'TBL_ESTADO_CONVOCA',4,'CANCELADO',NULL,1),(33,9,'TBL_TIPO_PREGUNTA',1,'HABILIDAD NUMERICA',NULL,1),(34,9,'TBL_TIPO_PREGUNTA',2,'ANALOGIAS',NULL,1),(35,9,'TBL_TIPO_PREGUNTA',3,'FIGURAS ANALOGAS',NULL,1),(36,9,'TBL_TIPO_PREGUNTA',4,'SERIES NUMERICAS',NULL,1),(37,9,'TBL_TIPO_PREGUNTA',5,'LIBRE',NULL,1),(38,10,'TBL_TIPO_CONTROL_EXAMEN',0,'TEXTO',NULL,1),(39,10,'TBL_TIPO_CONTROL_EXAMEN',1,'MULTIOPCION',NULL,1),(40,11,'TBL_TIPO_COLABORADOR',0,'CONTACTO',NULL,1),(41,11,'TBL_TIPO_COLABORADOR',1,'COLABORADOR',NULL,1),(42,11,'TBL_TIPO_COLABORADOR',2,'POSTULANTE',NULL,1),(43,12,'TBL_FASE_CONVOCATORIA',0,'NO INICIADA',NULL,1),(44,12,'TBL_FASE_CONVOCATORIA',1,'EVALUACIÓN PSICOLOGICA',NULL,1),(45,12,'TBL_FASE_CONVOCATORIA',2,'EXAMEN PSICOTÉCNICO',NULL,1),(46,12,'TBL_FASE_CONVOCATORIA',3,'ENTREVISTA PERSONAL',NULL,1),(47,12,'TBL_FASE_CONVOCATORIA',4,'FINALIZADO',NULL,1),(48,13,'TBL_ESTADO_ACEPTACION',0,'NO EVALUADO',NULL,1),(49,13,'TBL_ESTADO_ACEPTACION',1,'ACEPTADO',NULL,1),(50,13,'TBL_ESTADO_ACEPTACION',2,'RECHAZADO',NULL,1);
/*!40000 ALTER TABLE `tb_parametros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_perfil`
--

DROP TABLE IF EXISTS `tb_perfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_perfil` (
  `PK_CodigoPerfil` int(11) NOT NULL AUTO_INCREMENT,
  `NombrePerfil` varchar(50) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `Estado` int(1) NOT NULL,
  `FK_CodigoExamen` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoPerfil`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_perfil`
--

LOCK TABLES `tb_perfil` WRITE;
/*!40000 ALTER TABLE `tb_perfil` DISABLE KEYS */;
INSERT INTO `tb_perfil` VALUES (1,'ADMIN','ADMIN',1,0),(2,'JEFE DE AREA','JEFE DE AREA',1,0),(3,'JEFE DE TIENDA','JEFE DE TIENDA',1,0),(4,'GERENTE DE RRHH','GERENTE DE RRHH',1,0),(5,'POSTULANTE CAJERO','CAJERO',1,1),(6,'POSTULANTE ALMACÉN','ALMACÉN',1,2),(7,'ANALISTA RRHH','ANALISTA RRHH',1,0);
/*!40000 ALTER TABLE `tb_perfil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_preguntaexamen`
--

DROP TABLE IF EXISTS `tb_preguntaexamen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_preguntaexamen` (
  `PK_CodigoPregunta` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoExamen` int(11) NOT NULL,
  `Pregunta` varchar(200) NOT NULL,
  `TipoPregunta` int(2) NOT NULL,
  `ImagenExamen` varchar(50) NOT NULL,
  `Puntaje` int(2) DEFAULT NULL,
  `TipoControl` int(1) DEFAULT NULL,
  `Estado` int(1) DEFAULT NULL,
  PRIMARY KEY (`PK_CodigoPregunta`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_preguntaexamen`
--

LOCK TABLES `tb_preguntaexamen` WRITE;
/*!40000 ALTER TABLE `tb_preguntaexamen` DISABLE KEYS */;
INSERT INTO `tb_preguntaexamen` VALUES (1,1,'Si al doble de un número le resto el propio numero, se obtiene 18. Halla el número.',1,'',6,1,1),(2,1,'Luis compra 180 truzas de baño a 13 soles cada una y obsequia 35; las restantes las vende a 20 soles cada una. ¿Cuál será su ganancia?',1,'',6,1,1),(3,1,'Tres jugadores A, B Y C tienen cierta cantidad de dinero; A y B tienen juntos S/. 36; A Y C tienen juntos S/. 39; By C tienen juntos S/. 43. ¿Cuánto tiene C?',1,'',6,1,1),(4,1,'Hallar el valor de X',1,'img41.jpg',5,1,1),(5,1,'Chile : Santiago',2,'',4,1,1),(6,1,'Cobre : Alambre',2,'',4,1,1),(7,1,'Sechura : Perú',2,'',4,1,1),(8,1,'Indicar la alternativa que continua coherentemente en la siguiente secuencia gráfica:',3,'img81.jpg',6,1,1),(9,1,'Señale la figura que no tiene relación con las demás:',3,'img91.jpg',7,1,1),(10,1,'Hallar el valor de \"x\" en:',4,'img101.jpg',7,1,1),(11,1,'Hallar el número que continúa en: 2; 10; 24; 44;...',4,'',9,1,1),(12,1,'En Economía, ¿A qué se llama Bolsa?',5,'',6,1,1),(13,1,'Escriba un párrafo de como te ves en 10 años',5,'',10,0,1),(14,2,'Encuentra los operadores para conseguir que el resultado de la operación sea correcto: 1 ? 5 ? 8 = 14',1,'',8,1,1),(15,2,'Observe la siguiente imagen en la que aparecen una serie de relojes. Marque la hora correcta:',1,'img22.jpg',8,1,1),(16,2,'Realiza la siguiente operación: 4/5 de 35 = ?',1,'',8,1,1),(17,2,'Señala la palabra que está incorrectamente escrita:',2,'',8,1,1),(18,2,'Sigue la secuencia: C A Y W U ? ?',2,'',8,1,1),(19,2,'Observe la siguiente imagen. Seleccione la opción que no está relacionada con las demás:',3,'img62.jpg',8,1,1),(20,2,'Encuentre la figura que está relacionada con el modelo:',3,'img72.jpg',8,1,1),(21,2,'Indica los dos números siguen la serie 34, 36, 18, 20, 10, 12,...',4,'',8,1,1),(22,2,'Indica los dos números siguen la serie 30, 33, 36, 39, 42, 45,...',4,'',8,1,1),(23,2,'¿Cuál es la secuencia que falta en la serie? (sin contar con la Ñ): 1A 2B 4C 8A ? 32D 64A 128B 256E 512A 1024B',5,'',8,1,1);
/*!40000 ALTER TABLE `tb_preguntaexamen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_preguntaopcion`
--

DROP TABLE IF EXISTS `tb_preguntaopcion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_preguntaopcion` (
  `PK_CodigoOpcion` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoPregunta` int(11) NOT NULL,
  `NombreOpcion` varchar(200) NOT NULL,
  `Correcto` int(11) NOT NULL,
  `Estado` int(1) NOT NULL,
  PRIMARY KEY (`PK_CodigoOpcion`)
) ENGINE=InnoDB AUTO_INCREMENT=96 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_preguntaopcion`
--

LOCK TABLES `tb_preguntaopcion` WRITE;
/*!40000 ALTER TABLE `tb_preguntaopcion` DISABLE KEYS */;
INSERT INTO `tb_preguntaopcion` VALUES (1,1,'A) 18',1,1),(2,1,'B) 36',0,1),(3,1,'C) 24',0,1),(4,1,'D) 12',0,1),(5,1,'E) 20',0,1),(6,2,'A) S/. 560',1,1),(7,2,'B) S/. 580',0,1),(8,2,'C) S/. 320',0,1),(9,2,'D) S/. 400',0,1),(10,2,'E) S/. 290',0,1),(11,3,'A) S/. 45',0,1),(12,3,'B) S/. 23',1,1),(13,3,'C) S/. 32',0,1),(14,3,'D) S/. 40',0,1),(15,3,'E) S/. 18',0,1),(16,4,'A) 1',0,1),(17,4,'B) 2',1,1),(18,4,'C) 4',0,1),(19,4,'D) 3',0,1),(20,4,'E) 6',0,1),(21,5,'A) Argentina : La Paz',0,1),(22,5,'B) Bolivia : Buenos Aires',0,1),(23,5,'C) Ecuador : Quito',1,1),(24,5,'D) Perú : Arequipa',0,1),(25,6,'A) lana : chalina',0,1),(26,6,'B) caucho : neumático',0,1),(27,6,'C) tela : pantalón',0,1),(28,6,'D) acero : cuchillo',1,1),(29,7,'A) Amazonas : Brasil',0,1),(30,7,'B) Nilo : Egipto',0,1),(31,7,'C) Atacama : Chile',0,1),(32,7,'D) Popayán : Colombia',1,1),(33,8,'Figura A',1,1),(34,8,'Figura B',0,1),(35,8,'Figura C',0,1),(36,8,'Figura D',0,1),(37,8,'Figura E',0,1),(38,9,'Figura A',0,1),(39,9,'Figura B',0,1),(40,9,'Figura C',0,1),(41,9,'Figura D',1,1),(42,9,'Figura E',0,1),(43,10,'A) 118',0,1),(44,10,'B) 140',0,1),(45,10,'C) 126',1,1),(46,10,'D) 166',0,1),(47,11,'A) 60',0,1),(48,11,'B) 80',0,1),(49,11,'C) 100',0,1),(50,11,'D) 70',1,1),(51,12,'A) A los negocios de inversión.',0,1),(52,12,'B) A las compras industriales.',0,1),(53,12,'C) A la cantidad de agentes de bolsa.',0,1),(54,12,'D) Al recipiente, espacio o lugar donde se guarda dinero.',0,1),(55,12,'E) Al lugar donde se realizan las operaciones financieras de mercancías.',1,1),(56,14,'A) x, +',0,1),(57,14,'B) +, +',1,1),(58,14,'C) -, +',0,1),(59,14,'D) +, *',0,1),(60,15,'Figura B',0,1),(61,15,'Figura A',0,1),(62,15,'Figura C',0,1),(63,15,'Figura D',1,1),(64,16,'A) 26',0,1),(65,16,'B) 30',0,1),(66,16,'C) 28',1,1),(67,16,'D) 43',0,1),(68,17,'A) Anfibio',0,1),(69,17,'B) Entremes',1,1),(70,17,'C) Crédito',0,1),(71,17,'D) Jengibre',0,1),(72,18,'A) S - O',0,1),(73,18,'B) S - Q',1,1),(74,18,'C) P - S',0,1),(75,18,'D) Y - A',0,1),(76,19,'Figura A',0,1),(77,19,'Figura B',0,1),(78,19,'Figura C',1,1),(79,19,'Figura D',0,1),(80,20,'Figura B',0,1),(81,20,'Figura D',0,1),(82,20,'Figura A',0,1),(83,20,'Figura C',1,1),(84,21,'A) 6, 8',1,1),(85,21,'B) 4, 8',0,1),(86,21,'C) 8, 6',0,1),(87,21,'D) 8, 10',0,1),(88,22,'A) 46, 49',0,1),(89,22,'B) 49, 52',0,1),(90,22,'C) 48, 51',1,1),(91,22,'D) 50, 51',0,1),(92,23,'A) 12C',0,1),(93,23,'B) 16B',1,1),(94,23,'C) 14B',0,1),(95,23,'D) 16C',0,1);
/*!40000 ALTER TABLE `tb_preguntaopcion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_respuestaexamen`
--

DROP TABLE IF EXISTS `tb_respuestaexamen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_respuestaexamen` (
  `PK_codigorespuesta` int(11) NOT NULL,
  `fk_usuario` int(11) NOT NULL,
  `fk_examen` int(11) NOT NULL,
  `fk_preguntaexamen` int(11) NOT NULL,
  `fk_preguntaopcion` int(11) DEFAULT NULL,
  `Respuesta` varchar(200) DEFAULT NULL,
  `correcto` int(1) DEFAULT NULL,
  `puntajeobtenido` int(2) DEFAULT NULL,
  `tiempo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PK_codigorespuesta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_respuestaexamen`
--

LOCK TABLES `tb_respuestaexamen` WRITE;
/*!40000 ALTER TABLE `tb_respuestaexamen` DISABLE KEYS */;
INSERT INTO `tb_respuestaexamen` VALUES (1,10,1,2,7,'',0,0,'00:29:00'),(2,10,1,3,12,'',1,6,'00:29:00'),(3,10,1,4,17,'',1,5,'00:29:00'),(4,10,1,5,22,'',0,0,'00:29:00'),(5,10,1,6,28,'',1,4,'00:29:00'),(6,10,1,8,33,'',1,6,'00:29:00'),(7,10,1,10,45,'',1,7,'00:29:00'),(8,10,1,11,50,'',1,9,'00:29:00'),(9,10,1,12,55,'',1,6,'00:29:00'),(10,10,1,13,0,'asasasasasasas',1,10,'00:29:00'),(11,11,1,1,1,'',1,6,'00:17:44'),(12,11,1,2,6,'',1,6,'00:17:44'),(13,11,1,4,17,'',1,5,'00:17:44'),(14,11,1,5,23,'',1,4,'00:17:44'),(15,11,1,6,28,'',1,4,'00:17:44'),(16,11,1,7,32,'',1,4,'00:17:44'),(17,11,1,8,33,'',1,6,'00:17:44'),(18,11,1,9,41,'',1,7,'00:17:44'),(19,11,1,10,45,'',1,7,'00:17:44'),(20,11,1,11,49,'',0,0,'00:17:44'),(21,11,1,12,54,'',0,0,'00:17:44'),(22,11,1,13,0,'sdsdsfdfddfdf',1,10,'00:17:44'),(23,8,2,14,57,'',1,8,'00:21:34'),(24,8,2,15,61,'',0,0,'00:21:34'),(25,8,2,16,65,'',0,0,'00:21:34'),(26,8,2,17,69,'',1,8,'00:21:34'),(27,8,2,18,74,'',0,0,'00:21:34'),(28,8,2,19,78,'',1,8,'00:21:34'),(29,8,2,20,83,'',1,8,'00:21:34'),(30,8,2,21,84,'',1,8,'00:21:34'),(31,8,2,22,90,'',1,8,'00:21:34'),(32,8,2,23,93,'',1,8,'00:21:34'),(33,9,2,14,57,'',1,8,'00:18:10'),(34,9,2,15,63,'',1,8,'00:18:10'),(35,9,2,16,66,'',1,8,'00:18:10'),(36,9,2,17,69,'',1,8,'00:18:10'),(37,9,2,19,77,'',0,0,'00:18:10'),(38,9,2,20,83,'',1,8,'00:18:10'),(39,9,2,21,84,'',1,8,'00:18:10'),(40,9,2,22,90,'',1,8,'00:18:10'),(41,9,2,23,93,'',1,8,'00:18:10');
/*!40000 ALTER TABLE `tb_respuestaexamen` ENABLE KEYS */;
UNLOCK TABLES;

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
  `Estado` int(1) NOT NULL,
  `FK_CodigoUsuario` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoSolicitud`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_solicitudpersonal`
--

LOCK TABLES `tb_solicitudpersonal` WRITE;
/*!40000 ALTER TABLE `tb_solicitudpersonal` DISABLE KEYS */;
INSERT INTO `tb_solicitudpersonal` VALUES (1,'SL1CA1',1,1,1,'2016-06-26 00:00:00','2016-07-15 00:00:00','2016-07-07 00:00:00',1,1,1,1500.50,3,NULL,2,2),(3,'SL1CA3',2,2,3,'2016-07-06 00:00:00','2016-07-23 00:00:00','2016-07-07 00:00:00',1,1,1,1700.00,5,'',2,2),(5,'SL1CA5',1,2,3,'2016-07-06 00:00:00','2016-06-30 00:00:00',NULL,1,1,1,1000.00,2,'',1,2),(6,'SL1CA6',2,1,1,'2016-07-09 00:00:00','2016-07-28 00:00:00',NULL,0,1,1,1000.00,1,NULL,1,2),(7,'SL1CA7',1,2,3,'2016-07-09 00:00:00','2016-07-25 00:00:00','2016-07-09 00:00:00',1,1,1,1000.00,100,NULL,2,2),(8,'SL1CA8',2,2,5,'2016-07-09 00:00:00','2016-07-30 00:00:00','2016-07-09 00:00:00',0,1,1,1500.00,5,'ya culmina el descanso médico del empleado.',3,2),(9,'SL1CA9',2,2,3,'2016-07-09 00:00:00','2016-07-29 00:00:00','2016-07-09 00:00:00',1,2,1,900.00,10,NULL,2,2),(10,'SL1CA10',1,2,6,'2016-07-09 00:00:00','2016-07-29 00:00:00','2016-07-09 00:00:00',0,2,1,850.00,2,NULL,2,2),(11,'SL1CA11',1,1,2,'2016-07-09 00:00:00','2016-07-28 00:00:00','2016-07-09 00:00:00',0,2,1,1000.00,3,'Reducir el numero de personas a 2.',3,2),(12,'SL1CA12',2,1,2,'2016-07-09 00:00:00','2016-08-04 00:00:00','2016-07-09 00:00:00',0,3,1,900.00,2,'Falta de presupuesto',3,2),(13,'SL1CA13',2,2,3,'2016-07-09 00:00:00','2016-07-29 00:00:00',NULL,1,4,1,1050.00,3,NULL,1,5),(14,'SL1CA14',1,1,1,'2016-07-09 00:00:00','2016-07-28 00:00:00','2016-07-09 00:00:00',0,3,1,900.00,2,NULL,2,5),(15,'SL1CA15',2,1,1,'2016-07-09 00:00:00','2016-08-06 00:00:00',NULL,0,4,1,1000.00,3,NULL,1,5),(16,'SL1CA16',2,1,2,'2016-07-09 00:00:00','2016-08-05 00:00:00',NULL,0,5,1,2000.00,2,NULL,1,5),(17,'SL1CA17',2,2,3,'2016-07-11 00:00:00','2016-07-26 00:00:00','2016-07-11 00:00:00',1,3,1,1500.00,2,'OK',2,2);
/*!40000 ALTER TABLE `tb_solicitudpersonal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_turno`
--

DROP TABLE IF EXISTS `tb_turno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_turno` (
  `PK_CodigoTurno` int(11) NOT NULL AUTO_INCREMENT,
  `NombreTurno` varchar(45) NOT NULL,
  `HoraInicio` time NOT NULL,
  `HoraFin` time NOT NULL,
  `Estado` int(1) NOT NULL,
  PRIMARY KEY (`PK_CodigoTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_turno`
--

LOCK TABLES `tb_turno` WRITE;
/*!40000 ALTER TABLE `tb_turno` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_turno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_usuario`
--

DROP TABLE IF EXISTS `tb_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_usuario` (
  `PK_CodigoUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `FK_CodigoPerfil` int(11) NOT NULL,
  `FK_CodigoLocal` int(11) NOT NULL,
  `FK_CodigoArea` int(11) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_usuario`
--

LOCK TABLES `tb_usuario` WRITE;
/*!40000 ALTER TABLE `tb_usuario` DISABLE KEYS */;
INSERT INTO `tb_usuario` VALUES (1,'ADMIN','123',1,0,0,1),(2,'ALE','123',2,1,2,1),(3,'RICHARD','123',3,1,0,1),(4,'ROGER','123',7,0,0,1),(5,'CRISTIAN','123',2,1,3,1),(6,'ALEX','123',5,0,0,1),(7,'ANTONIO','123',6,0,0,1),(8,'ALFREDO','123',6,0,0,1),(9,'GIOVANNY','123',6,0,0,1),(10,'RODRIGO','123',5,0,0,1),(11,'FREDDY','123',5,0,0,1),(12,'CCC','123',4,0,0,1);
/*!40000 ALTER TABLE `tb_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'rrhh'
--

--
-- Dumping routines for database 'rrhh'
--
/*!50003 DROP PROCEDURE IF EXISTS `SPD_SOLICITUD` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPD_SOLICITUD`(IN CODIGO INT)
BEGIN
	
    delete from RRHH.tb_solicitudpersonal
    WHERE PK_CODIGOSOLICITUD = CODIGO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPI_CONVOCATORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPI_CONVOCATORIA`(
	IN P_NOMBRE VARCHAR(45),
    IN P_FECHA_INICIO DATETIME,
    IN P_FECHA_FIN DATETIME,
    IN P_CODIGO_SOLICITUD INT,
    OUT P_ID INT
)
BEGIN
	INSERT INTO RRHH.tb_convocatoria
    (NOMBRECONVOCATORIA, FECHAINICIO, FECHAFIN, CODIGOSOLICITUD, FECHACREACION, CODIGOESTADO)
    VALUES
    (P_NOMBRE, P_FECHA_INICIO, P_FECHA_FIN, P_CODIGO_SOLICITUD, sysdate(), 1);
    
    SET P_ID = LAST_INSERT_ID();
    
	UPDATE rrhh.tb_convocatoria a
    set CodigoInterno = concat('CONCA', LPAD(P_ID, 3, '0'))
    where a.pk_CodigoConvocatoria = P_ID;
    
    SELECT P_ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPI_RESPUESTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPI_RESPUESTAS`(
IN COD_USUARIO INT,
IN COD_EXAMEN INT,
IN COD_PREGUNTA INT,
IN COD_OPCION INT,
IN RESPUESTA VARCHAR(100),
IN CORRECTO INT,
IN PUNTAJE INT,
IN TIEMPO VARCHAR(50)
)
BEGIN
	
    INSERT INTO tb_respuestaexamen
		(fk_usuario,
		fk_examen,
		fk_preguntaexamen,
		fk_preguntaopcion,
		Respuesta,
		correcto,
		puntajeobtenido,
		tiempo)
	VALUES
		(COD_USUARIO,
		COD_EXAMEN,
		COD_PREGUNTA,
		COD_OPCION,
		RESPUESTA,
		CORRECTO,
		PUNTAJE,
		TIEMPO);
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPI_SOLICITUD` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPI_SOLICITUD`(	IN TIPO_CONV 	INT,
	IN TIPO_SOL 	INT,
	IN MOTIVO 		INT,
    IN FECHA_SOL 	DATE,
    IN FECHA_PRE 	DATE,
    IN COD_CAMPANA 	INT,
    IN COD_CARGO 	INT,
    IN COD_MONEDA	INT,
    IN SUELDO		DECIMAL(18,2),
    IN CANTIDAD 	INT,
    IN ESTADO 		INT,
    IN COD_LOCAL	INT,
    IN USUARIO		INT,
	OUT RESULT INT(11)
)
BEGIN
	
	INSERT INTO `rrhh`.`tb_solicitudpersonal`
	(`CodigoInterno`,
    `TipoConvocatoria`,
	`TipoSolicitud`,
	`Motivo`,
	`FechaSolicitud`,
	`FechaPresentacion`,
	`CodigoCampana`,
	`FK_CodigoCargo`,
	`Moneda`,
	`Sueldo`,
	`Cantidad`,
	`Estado`,
    `FK_CodigoUsuario`)
	VALUES
	(	'-',
		TIPO_CONV,
		TIPO_SOL,
		MOTIVO,
		FECHA_SOL,
		FECHA_PRE,
		COD_CAMPANA,
		COD_CARGO,
		COD_MONEDA,
		SUELDO,
		CANTIDAD,
		ESTADO,
        USUARIO);

    SET RESULT = LAST_INSERT_ID();
    
    /*GENERANDO CODIGO INTERNO*/
    
    UPDATE rrhh.tb_solicitudpersonal a
    set CodigoInterno = concat('SL', COD_LOCAL, 'CA', RESULT)
    where a.PK_CodigoSolicitud = RESULT;
    
    SELECT RESULT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_CAMPANA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_CAMPANA`(IN DESCRIPCION VARCHAR(50),
 IN CODIGO  	INT)
BEGIN
	SELECT 	A.PK_CodigoCampana,
			A.Descripcion,
            A.FechaInicio,
            A.FechaFin,
            A.Estado
    FROM RRHH.tb_campana A 
    WHERE A.Estado = 1
    AND ((DESCRIPCION = '') OR (UPPER(A.Descripcion) LIKE CONCAT('%', DESCRIPCION , '%')))
    AND ((CODIGO = 0) OR (A.PK_CodigoCampana = CODIGO));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_CARGO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_CARGO`(IN DESCRIPCION VARCHAR(50),
 IN CODIGO  	INT)
BEGIN
	SELECT 	A.PK_Cargo,
			A.Descripcion,
            A.Funciones,
            A.Requisitos,
            A.SueldoMin,
            A.SueldoMax,
            A.Estado
    FROM RRHH.tb_cargo A 
    WHERE A.Estado = 1
    AND ((DESCRIPCION = '') OR (UPPER(A.Descripcion) LIKE CONCAT('%', DESCRIPCION , '%')))
    AND ((CODIGO = 0) OR (A.PK_Cargo = CODIGO));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_COLABORADORBYID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_COLABORADORBYID`(IN CODIGO INT,
IN CODUSUARIO INT
)
BEGIN
	
	SELECT
		A.PK_CODIGOCOLABORADOR AS CODIGO,
		A.APELLIDOPATERNO,
		A.APELLIDOMATERNO,
		A.NOMBRE,
		A.DNI,
		A.FECHANACIMIENTO,
		A.SEXO,
		A.DIRECCION,
		A.TELEFONO,
		A.CORREO,
		A.ESTADOCIVIL,
		A.CANTIDADHIJOS,
		A.SEGURO,
		A.CODIGOESSALUD,
		A.FECHACESE,
		A.ANTECEDENTEPOLICIAL,
        A.FK_CODIGOCV,
        A.RindioExamen,
        A.PuntajeFinal,
        a.foto
	FROM
		RRHH.TB_COLABORADOR A 
	WHERE ((CODIGO = 0) OR (A.PK_CODIGOCOLABORADOR = CODIGO))
    AND ((CODUSUARIO = 0) OR (A.FK_CODIGOUSUARIO = CODUSUARIO));
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_COLABORADORES` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_COLABORADORES`()
BEGIN
	
    SELECT 
		PK_CODIGOCOLABORADOR AS CODIGO,
		APELLIDOPATERNO,
		APELLIDOMATERNO,
		NOMBRE,
		DNI,
		FECHANACIMIENTO,
		SEXO,
		DIRECCION,
		TELEFONO,
		CORREO,
		CURRICULUMVITAE,
		ESTADOCIVIL,
		CANTIDADHIJOS,
		SEGURO,
		CODIGOESSALUD,
		FECHACESE,
		ANTECEDENTEPOLICIAL
	FROM
		RRHH.TB_COLABORADOR A
	WHERE A.TIPOCOLABORADOR IN (0, 1);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_COLABORADOR_PERFIL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_COLABORADOR_PERFIL`(IN PERFIL      INT,
 IN TIENDA  	INT)
BEGIN
	SELECT C.PK_CodigoColaborador,
		   C.ApellidoPaterno,
		   C.ApellidoMaterno,
		   C.Nombre,
		   C.Correo,
		   U.PK_CodigoUsuario,
		   U.FK_CodigoPerfil,
		   U.FK_CodigoArea,
		   U.FK_CodigoLocal
	FROM RRHH.tb_colaborador C
			inner join RRHH.tb_usuario U on c.fK_CODIGOUSUARIO = U.PK_CODIGOUSUARIO
	WHERE U.ESTADO = 1
    AND ((PERFIL = 0) OR (U.FK_CodigoPerfil = PERFIL))
    AND ((TIENDA = 0) OR (U.FK_CodigoLocal = TIENDA));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_CV_BY_POSTULANTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_CV_BY_POSTULANTE`(IN CODIGO INT)
BEGIN
	
	SELECT  A.PK_CodigoCV, 
			A.Profesion, 
			A.nivelAcademico, 
			A.centroEstudio, 
			A.anioEgreso, 
			A.trabajo1, 
			A.periodo1, 
			A.funciones1, 
			A.trabajo2, 
			A.periodo2, 
			A.funciones2, 
			A.trabajo3, 
			A.periodo3, 
			A.funciones3
	FROM tb_curriculumvitae A 
	WHERE A.PK_CODIGOCV = CODIGO;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_EXAMENOPCIONES` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_EXAMENOPCIONES`(IN CODIGO INT)
BEGIN
	
	SELECT  O.PK_CodigoOpcion,
			O.FK_CodigoPregunta,
			O.NombreOpcion,
			O.Correcto,
			O.Estado
	FROM tb_preguntaopcion O
	WHERE O.FK_CodigoPregunta = CODIGO
	AND O.ESTADO = 1;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_GET_CONVOCATORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_GET_CONVOCATORIA`(
	IN P_ID INT
)
BEGIN
	SELECT
		A.PK_CODIGOCONVOCATORIA ID,
        A.CodigoInterno,
		A.NOMBRECONVOCATORIA NOMBRE,
		C.TipoConvocatoria CODTIPOCONVOCATORIA,
		B.DESCRIPCION TIPOCONVOCATORIA,
		A.FECHAINICIO,
		A.FECHAFIN,
		A.CODIGOSOLICITUD,
        C.FK_CodigoCargo,
        G.Descripcion AS CARGO,
        C.Cantidad,
		A.FECHACREACION,
		A.CODIGOESTADO,
		D.DESCRIPCION ESTADO,
		A.FASE,
        F.Descripcion AS FASE_DES
	FROM RRHH.TB_CONVOCATORIA A
	INNER JOIN RRHH.TB_SOLICITUDPERSONAL C ON A.CODIGOSOLICITUD = C.PK_CODIGOSOLICITUD
    INNER JOIN RRHH.TB_PARAMETROS B ON C.TipoConvocatoria = B.CODIGO  AND B.CODIGOAGRUPADOR = 3
	INNER JOIN RRHH.TB_PARAMETROS D ON A.CODIGOESTADO = D.CODIGO AND D.CODIGOAGRUPADOR = 8
    INNER JOIN RRHH.tb_parametros F ON A.FASE = F.CODIGO AND F.CODIGOAGRUPADOR = 12
    INNER JOIN TB_CARGO G ON C.FK_CodigoCargo = G.PK_CARGO
    WHERE A.PK_CODIGOCONVOCATORIA = P_ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_PARAMETRO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_PARAMETRO`(IN COD_AGRUPADOR INT)
BEGIN
	
    SELECT A.Codigo,
		   A.Descripcion,
           A.Valor,
           A.Estado
    FROM RRHH.tb_parametros A
    WHERE A.CodigoAgrupador = COD_AGRUPADOR;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_PARAMETROXCODAGRUPADOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_PARAMETROXCODAGRUPADOR`(IN COD_AGRUPADOR INT)
BEGIN
	
    SELECT A.PK_CodigoParametro Id,
		   A.Descripcion,
           A.Valor,
           A.Estado
    FROM RRHH.tb_parametros A
    WHERE A.CodigoAgrupador = COD_AGRUPADOR;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_PERFIL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_PERFIL`(IN DESCRIPCION VARCHAR(50),
 IN CODIGO  	INT)
BEGIN
	SELECT A.PK_CodigoPerfil,
			A.NombrePerfil,
            A.Descripcion,
            A.Estado
    FROM RRHH.tb_perfil A 
    WHERE A.Estado = 1
    AND ((DESCRIPCION = '') OR (UPPER(A.Descripcion) LIKE CONCAT('%', DESCRIPCION , '%')))
    AND ((CODIGO = 0) OR (A.PK_CodigoPerfil = CODIGO));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_POSTULANTES_BY_CONVOCATORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_POSTULANTES_BY_CONVOCATORIA`(IN CODIGO INT)
BEGIN
	
	SELECT
		A.PK_CODIGOCOLABORADOR AS CODIGO,
		A.APELLIDOPATERNO,
		A.APELLIDOMATERNO,
		A.NOMBRE,
		A.DNI,
		A.FECHANACIMIENTO,
		A.SEXO,
		A.DIRECCION,
		A.TELEFONO,
		A.CORREO,
		A.ESTADOCIVIL,
		A.CANTIDADHIJOS,
		A.SEGURO,
		A.CODIGOESSALUD,
		A.FECHACESE,
		A.ANTECEDENTEPOLICIAL,
        A.FK_CODIGOCV,
        A.RindioExamen,
        A.PuntajeFinal,
		A.estado_aceptacion,
        B.DESCRIPCION
	FROM
		RRHH.TB_COLABORADOR A 
                INNER JOIN RRHH.TB_PARAMETROS B ON A.estado_aceptacion = B.CODIGO AND B.CODIGOAGRUPADOR = 13
	WHERE A.TIPOCOLABORADOR = 2 -- SOLO POSTULANTES
    AND A.ESTADO_POSTULANTE_CONVOCATORIA = 1 -- SOLO APTOS
    AND A.FK_CODIGOCONVOCATORIA = CODIGO;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_PREGUNTAEXAMEN` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_PREGUNTAEXAMEN`(IN CODIGO INT)
BEGIN
	
	select  A.PK_CODIGOEXAMEN,
			A.NOMBREEXAMEN,
			A.Descripcion,
			B.PK_CODIGOPREGUNTA,
			B.PREGUNTA,
			B.TipoPregunta,
			B.IMAGENEXAMEN, 
			B.PUNTAJE,
			B.TIPOCONTROL,
			C.Descripcion
	from tb_Examen a 
	inner join tb_preguntaexamen b on a.pk_codigoExamen = b.fk_codigoexamen
	INNER JOIN tb_parametros C ON B.TIPOPREGUNTA = C.CODIGO AND C.codigoAgrupador = 9
	where A.pk_CodigoExamen = CODIGO
	AND A.ESTADO = 1
	AND B.ESTADO = 1;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_RESPUESTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_RESPUESTAS`(IN CODIGO_POSTULANTE INT)
BEGIN
	
    SELECT A.PK_codigorespuesta,
		A.fk_usuario,
        A.fk_examen,
        A.fk_preguntaexamen,
        A.fk_preguntaopcion,
        A.Respuesta,
        A.correcto,
        A.puntajeobtenido,
        A.tiempo
	FROM tb_respuestaexamen A
	WHERE A.FK_USUARIO = CODIGO_POSTULANTE;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_RESULTRESUMENBYPOSTULANTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_RESULTRESUMENBYPOSTULANTE`(IN CODIGO_POSTULANTE INT)
BEGIN
	
	select A.tiempo,
		   (select count(1) from tb_preguntaexamen WHERE FK_CodigoExamen = fk_examen) as TOTAL_PREGUNTAS,
			SUM(A.correcto) AS CORRECTO,
		   (SELECT COUNT(1) FROM tb_respuestaexamen WHERE FK_USUARIO = CODIGO_POSTULANTE AND CORRECTO = 0) AS INCORRECTO,
		   ((select COUNT(1) FROM tb_preguntaexamen WHERE FK_CodigoExamen = fk_examen) - 
				(SELECT COUNT(1) FROM tb_respuestaexamen WHERE FK_USUARIO = CODIGO_POSTULANTE)) AS NO_RESPONDIDAS,
			(select SUM(Puntaje) from tb_preguntaexamen WHERE FK_CodigoExamen = fk_examen) AS PUNTAJE_TOTAL,
			SUM(A.puntajeobtenido) AS PUNTAJE_OBTENIDO
	from RRHH.tb_respuestaexamen A
	WHERE A.FK_USUARIO = CODIGO_POSTULANTE
	group by a.tiempo;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_SEARCH_CONVOCATORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_SEARCH_CONVOCATORIA`(
	IN P_ID VARCHAR(45),
    IN P_NOMBRE VARCHAR(45),
    IN P_CODIGO_TIPO_CONVOCATORIA INT,
    IN P_FECHA_INICIO DATETIME,
    IN P_FECHA_FIN DATETIME,
    IN P_CODIGO_CARGO INT
)
BEGIN
	SET @SQLSTMSELECT = 'SELECT
							A.PK_CODIGOCONVOCATORIA ID,
							A.CodigoInterno,
							A.NOMBRECONVOCATORIA NOMBRE,
							C.TipoConvocatoria CODTIPOCONVOCATORIA,
							B.DESCRIPCION TIPOCONVOCATORIA,
							A.FECHAINICIO,
							A.FECHAFIN,
							A.CODIGOSOLICITUD,
							C.FK_CodigoCargo,
							G.Descripcion AS CARGO,
							C.Cantidad,
							A.FECHACREACION,
							A.CODIGOESTADO,
							D.DESCRIPCION ESTADO,
                            A.FASE,
							F.Descripcion AS FASE_DES
                            ';
    SET @SQLSTMFROMWHERE = ' FROM RRHH.TB_CONVOCATORIA A
								INNER JOIN RRHH.TB_SOLICITUDPERSONAL C ON A.CODIGOSOLICITUD = C.PK_CODIGOSOLICITUD
                                INNER JOIN RRHH.TB_PARAMETROS B ON C.TipoConvocatoria = B.CODIGO  AND B.CODIGOAGRUPADOR = 3
								INNER JOIN RRHH.TB_PARAMETROS D ON A.CODIGOESTADO = D.CODIGO AND D.CODIGOAGRUPADOR = 8
                                INNER JOIN RRHH.tb_parametros F ON A.FASE = F.CODIGO AND F.CODIGOAGRUPADOR = 12
								INNER JOIN TB_CARGO G ON C.FK_CodigoCargo = G.PK_CARGO
							WHERE 1 = 1';
                                
	IF P_ID IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND UPPER(A.CodigoInterno) LIKE "%',  UPPER(P_ID), '%"');
	END IF;
    
    IF P_NOMBRE IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND UPPER(A.NOMBRECONVOCATORIA) LIKE "%',  UPPER(P_NOMBRE), '%"');
	END IF;
    
    IF P_CODIGO_TIPO_CONVOCATORIA IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND C.TipoConvocatoria = ', P_CODIGO_TIPO_CONVOCATORIA);
	END IF;
    
    IF P_FECHA_INICIO IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND DATE_FORMAT(A.FECHAINICIO, "%Y-%m-%d") >= DATE_FORMAT("', P_FECHA_INICIO, '", "%Y-%m-%d")');
	END IF;
    
    IF P_FECHA_FIN IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND DATE_FORMAT(A.FECHAFIN, "%Y-%m-%d") >= DATE_FORMAT("', P_FECHA_FIN, '", "%Y-%m-%d")');
	END IF;
    
    IF P_CODIGO_CARGO IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND C.FK_CodigoCargo = ', P_CODIGO_CARGO);
	END IF;
	
	SET @SQLSTMSELECT = CONCAT(@SQLSTMSELECT, @SQLSTMFROMWHERE);
    
	PREPARE SQLSMT FROM @SQLSTMSELECT;
    EXECUTE SQLSMT;
    DEALLOCATE PREPARE SQLSMT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_SOLICITUD` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_SOLICITUD`(IN TIPOFILTRO  INT,	
 IN DESCRIPCION VARCHAR(50),
 IN CODIGO  	INT,
 IN FECHA_INI	VARCHAR(10),
 IN FECHA_FIN	VARCHAR(10),
 IN ESTADO 		INT,
 IN USUARIO		INT,
 IN CODLOCAL	INT,
 IN CODAREA		INT
)
BEGIN

	DECLARE QUERY_STM VARCHAR(10000);
    
    SET @QUERY_STM := '';
    SET @QUERY_STM = CONCAT(@QUERY_STM,' SELECT 	A.PK_CodigoSolicitud,A.CodigoInterno,A.TipoConvocatoria,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' tc.Descripcion as TipoConvocatoriaDes, A.TipoSolicitud,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' ts.Descripcion as TipoSolicitudDes,A.Motivo, M.Descripcion as MotivoDes,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' A.FechaSolicitud, A.FechaPresentacion, A.FechaEnvio, A.CodigoCampana,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' C.Descripcion as Campana, c.FechaInicio, c.FechaFin,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' A.FK_CodigoCargo, cg.Descripcion, cg.Funciones,cg.Requisitos,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' cg.SueldoMin, cg.SueldoMax, A.Sueldo, A.Moneda, MN.Descripcion as MonedaDes,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' A.Cantidad, A.Comentarios, A.Estado, E.Descripcion as EstadoDes, A.FK_CodigoUsuario');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' FROM tb_solicitudpersonal A ');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros tc on a.TipoConvocatoria = tc.codigo and tc.codigoAgrupador = 3 and tc.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros ts on a.TipoSolicitud = ts.codigo and ts.codigoAgrupador = 1 and ts.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros M on a.Motivo = M.codigo and M.codigoAgrupador = 4 and M.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros E on a.Estado = E.codigo and E.codigoAgrupador = 2 and E.estado = 1');
	SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros MN on a.Moneda = MN.codigo and MN.codigoAgrupador = 5 and MN.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_cargo CG on a.FK_CodigoCargo = cg.pk_cargo and cg.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_usuario U on a.FK_CodigoUsuario = U.PK_CodigoUsuario');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' LEFT JOIN tb_campana C ON A.CodigoCampana = C.PK_CODIGOcAMPANA and c.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' WHERE 1 = 1 ');
    
    IF TIPOFILTRO = 1 THEN 
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((''', DESCRIPCION, ''' = '''' ) OR (A.CodigoInterno LIKE concat(''%'',''', DESCRIPCION,''',''%'')))');
    ELSEIF TIPOFILTRO = 2 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODIGO, '= 0) OR (A.TipoSolicitud =', CODIGO, '))');
	ELSEIF TIPOFILTRO = 3 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODIGO, '= 0) OR (A.Motivo =', CODIGO, '))');
	ELSEIF TIPOFILTRO = 4 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODIGO, '= 0) OR (A.FK_CodigoCargo =', CODIGO, '))');
    ELSEIF TIPOFILTRO = 5 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND (CAST(A.FechaSolicitud AS DATE) BETWEEN ''', FECHA_INI, ''' AND ''', FECHA_FIN , ''')');
	ELSEIF TIPOFILTRO = 6 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND (CAST(A.FechaPresentacion AS DATE) BETWEEN ''', FECHA_INI, ''' AND ''', FECHA_FIN , ''')');
	ELSEIF TIPOFILTRO = 7 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND (CAST(A.FechaEnvio AS DATE) BETWEEN ''', FECHA_INI, ''' AND ''', FECHA_FIN , ''')');
	ELSEIF TIPOFILTRO = 8 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND (A.PK_CodigoSolicitud NOT IN (SELECT CodigoSolicitud FROM tb_convocatoria))');
		IF CODIGO <> 0 THEN
			SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODIGO, '= 0) OR (A.FK_CodigoCargo =', CODIGO, '))');
        END IF;
		IF CODLOCAL <> 0 THEN
			SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODLOCAL, '= 0) OR (A.TipoSolicitud =', CODLOCAL, '))');
        END IF;
		IF CODAREA <> 0 THEN
			SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODAREA, '= 0) OR (A.Motivo =', CODAREA, '))');
        END IF;
    END IF;
    
    SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', ESTADO, '= 0) OR (A.Estado =', ESTADO, '))');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', USUARIO, '= 0) OR (A.FK_CodigoUsuario =', USUARIO, '))');
    
	IF TIPOFILTRO <> 8 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODLOCAL, '= 0) OR (U.FK_CodigoLocal =', CODLOCAL, '))');
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODAREA, '= 0) OR (U.FK_CodigoArea =', CODAREA, '))');
	END IF;
    
    PREPARE smpt FROM @QUERY_STM;
    
	-- ejecutamos el Statement
	EXECUTE smpt;
    
	-- liberamos la memoria
	DEALLOCATE PREPARE smpt;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_SOLICITUDBYID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_SOLICITUDBYID`(IN CODIGO 	INT)
BEGIN

SELECT 	A.PK_CodigoSolicitud,
		A.CodigoInterno,
        A.TipoConvocatoria,
        tc.Descripcion as TipoConvocatoriaDes,
        A.TipoSolicitud,
        ts.Descripcion as TipoSolicitudDes,
        A.Motivo,
        M.Descripcion as MotivoDes,
        A.FechaSolicitud,
        A.FechaPresentacion,
        A.FechaEnvio,
        A.CodigoCampana,
        C.Descripcion as Campana,
        c.FechaInicio,
        c.FechaFin,
        A.FK_CodigoCargo,
        cg.Descripcion,
        cg.Funciones,
        cg.Requisitos,
        cg.SueldoMin,
        cg.SueldoMax,
        A.Sueldo,
        A.Moneda,
        MN.Descripcion as MonedaDes,
        A.Cantidad,
        A.Comentarios,
        A.Estado,
        E.Descripcion as EstadoDes,
        A.FK_CodigoUsuario
FROM tb_solicitudpersonal A 
		INNER JOIN tb_parametros tc on a.TipoConvocatoria = tc.codigo and tc.codigoAgrupador = 3 and tc.estado = 1
        INNER JOIN tb_parametros ts on a.TipoSolicitud = ts.codigo and ts.codigoAgrupador = 1 and ts.estado = 1
        INNER JOIN tb_parametros M on a.Motivo = M.codigo and M.codigoAgrupador = 4 and M.estado = 1
        INNER JOIN tb_parametros E on a.Estado = E.codigo and E.codigoAgrupador = 2 and E.estado = 1
        INNER JOIN tb_parametros MN on a.Moneda = MN.codigo and MN.codigoAgrupador = 5 and MN.estado = 1
        INNER JOIN tb_cargo CG on a.FK_CodigoCargo = cg.pk_cargo and cg.estado = 1
		LEFT JOIN tb_campana C ON A.CodigoCampana = C.PK_CODIGOcAMPANA and c.estado = 1
WHERE A.PK_CodigoSolicitud = CODIGO;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPS_SOLICITUD_CONVOCATORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPS_SOLICITUD_CONVOCATORIA`(IN TIPOFILTRO  INT,	
 IN DESCRIPCION VARCHAR(50),
 IN CODIGO  	INT,
 IN FECHA_INI	VARCHAR(10),
 IN FECHA_FIN	VARCHAR(10),
 IN ESTADO 		INT,
 IN USUARIO		INT,
 IN CODLOCAL	INT,
 IN CODAREA		INT
)
BEGIN

	DECLARE QUERY_STM VARCHAR(10000);
    
    SET @QUERY_STM := '';
    SET @QUERY_STM = CONCAT(@QUERY_STM,' SELECT 	A.PK_CodigoSolicitud,A.CodigoInterno,A.TipoConvocatoria,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' tc.Descripcion as TipoConvocatoriaDes, A.TipoSolicitud,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' ts.Descripcion as TipoSolicitudDes,A.Motivo, M.Descripcion as MotivoDes,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' A.FechaSolicitud, A.FechaPresentacion, A.FechaEnvio, A.CodigoCampana,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' C.Descripcion as Campana, c.FechaInicio, c.FechaFin,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' A.FK_CodigoCargo, cg.Descripcion, cg.Funciones,cg.Requisitos,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' cg.SueldoMin, cg.SueldoMax, A.Sueldo, A.Moneda, MN.Descripcion as MonedaDes,');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' A.Cantidad, A.Comentarios, A.Estado, E.Descripcion as EstadoDes, A.FK_CodigoUsuario,');
	SET @QUERY_STM = CONCAT(@QUERY_STM,' CT.PK_CODIGOCONVOCATORIA, CT.CODIGOESTADO, ECT.DESCRIPCION');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' FROM tb_solicitudpersonal A ');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros tc on a.TipoConvocatoria = tc.codigo and tc.codigoAgrupador = 3 and tc.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros ts on a.TipoSolicitud = ts.codigo and ts.codigoAgrupador = 1 and ts.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros M on a.Motivo = M.codigo and M.codigoAgrupador = 4 and M.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros E on a.Estado = E.codigo and E.codigoAgrupador = 2 and E.estado = 1');
	SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros MN on a.Moneda = MN.codigo and MN.codigoAgrupador = 5 and MN.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_cargo CG on a.FK_CodigoCargo = cg.pk_cargo and cg.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_usuario U on a.FK_CodigoUsuario = U.PK_CodigoUsuario');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_convocatoria CT on A.PK_CodigoSolicitud = CT.CodigoSolicitud');
	SET @QUERY_STM = CONCAT(@QUERY_STM,' INNER JOIN tb_parametros ECT on CT.CODIGOESTADO = ECT.CODIGO AND ECT.CODIGOAGRUPADOR = 8');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' LEFT JOIN tb_campana C ON A.CodigoCampana = C.PK_CODIGOcAMPANA and c.estado = 1');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' WHERE 1 = 1 AND CT.CODIGOESTADO IN (2,3) ');
    
    IF TIPOFILTRO = 1 THEN 
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((''', DESCRIPCION, ''' = '''' ) OR (A.CodigoInterno LIKE concat(''%'',''', DESCRIPCION,''',''%'')))');
    ELSEIF TIPOFILTRO = 2 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODIGO, '= 0) OR (A.TipoSolicitud =', CODIGO, '))');
	ELSEIF TIPOFILTRO = 3 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODIGO, '= 0) OR (A.Motivo =', CODIGO, '))');
	ELSEIF TIPOFILTRO = 4 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODIGO, '= 0) OR (A.FK_CodigoCargo =', CODIGO, '))');
    ELSEIF TIPOFILTRO = 5 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND (CAST(A.FechaSolicitud AS DATE) BETWEEN ''', FECHA_INI, ''' AND ''', FECHA_FIN , ''')');
	ELSEIF TIPOFILTRO = 6 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND (CAST(A.FechaPresentacion AS DATE) BETWEEN ''', FECHA_INI, ''' AND ''', FECHA_FIN , ''')');
	ELSEIF TIPOFILTRO = 7 THEN
		SET @QUERY_STM = CONCAT(@QUERY_STM,' AND (CAST(A.FechaEnvio AS DATE) BETWEEN ''', FECHA_INI, ''' AND ''', FECHA_FIN , ''')');
    END IF;
    
    SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', ESTADO, '= 0) OR (A.Estado =', ESTADO, '))');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', USUARIO, '= 0) OR (A.FK_CodigoUsuario =', USUARIO, '))');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODLOCAL, '= 0) OR (U.FK_CodigoLocal =', CODLOCAL, '))');
    SET @QUERY_STM = CONCAT(@QUERY_STM,' AND ((', CODAREA, '= 0) OR (U.FK_CodigoArea =', CODAREA, '))');
    
    PREPARE smpt FROM @QUERY_STM;
    
	-- ejecutamos el Statement
	EXECUTE smpt;
    
	-- liberamos la memoria
	DEALLOCATE PREPARE smpt;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPU_CONVOCATORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPU_CONVOCATORIA`(IN CODIGO		 		INT,
 IN ESTADO			 	INT,
 IN FASE				INT
)
BEGIN
	
	UPDATE rrhh.tb_convocatoria B
    SET B.FASE = FASE,
		B.CODIGOESTADO = ESTADO
    WHERE B.PK_CODIGOCONVOCATORIA = CODIGO;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPU_POSTULANTES_APTOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPU_POSTULANTES_APTOS`(IN CODIGO		 		INT,
 IN ESTADO_ACEPTACION 	INT
)
BEGIN
	
	UPDATE tb_colaborador A
    SET A.ESTADO_ACEPTACION = ESTADO_ACEPTACION
    WHERE A.PK_CODIGOCOLABORADOR = CODIGO;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SPU_SOLICITUD` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SPU_SOLICITUD`(	IN CODIGO 		INT,
	IN TIPO_CONV 	INT,
	IN TIPO_SOL 	INT,
	IN MOTIVO 		INT,
	IN FECHA_PRE 	DATE,
	IN COD_CAMPANA 	INT,
	IN COD_CARGO 	INT,
	IN COD_MONEDA	INT,
	IN SUELDO		DECIMAL(18,2),
	IN CANTIDAD 	INT,
	IN ESTADO 		INT,
    IN OBSERVACION 	VARCHAR(250),
	IN FECHA_ENV 	DATE
)
BEGIN
	
    update RRHH.tb_solicitudpersonal A
    SET TipoConvocatoria = TIPO_CONV, 
		TipoSolicitud = TIPO_SOL, 
        Motivo = MOTIVO, 
        FechaPresentacion = FECHA_PRE,
        CodigoCampana = COD_CAMPANA, 
		FK_CodigoCargo = COD_CARGO, 
        Moneda = COD_MONEDA, 
        Sueldo = SUELDO,
        Cantidad = CANTIDAD,
        Estado = ESTADO,
        Comentarios = OBSERVACION,
        FechaEnvio = FECHA_ENV
    WHERE A.PK_CODIGOSOLICITUD = CODIGO;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_LOGIN` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_LOGIN`(IN USUARIO VARCHAR(20),
 IN PASS  	VARCHAR(20))
BEGIN
  SELECT A.PK_CodigoUsuario, 
		 A.Usuario,
         A.FK_CodigoPerfil,
         b.NombrePerfil,
         A.FK_CodigoArea,
         d.descripcion,
         A.FK_CodigoLocal,
         C.nombreLocal,
         B.fk_CodigoExamen,
         (select RindioExamen from tb_colaborador where FK_CodigoUsuario = A.PK_CodigoUsuario) as RindioExamen,
         b.Descripcion
  FROM RRHH.tb_usuario A 
			inner join rrhh.tb_perfil b on a.FK_CodigoPerfil = b.PK_CodigoPerfil
            INNER JOIN RRHH.tb_local C ON A.FK_CodigoLocal = C.PK_CodigoLocal
            INNER join rrhh.tb_area D on a.FK_CodigoArea = d.PK_CodigoArea
  WHERE UPPER(A.USUARIO) = UPPER(USUARIO)
  AND A.PASSWORD = PASS;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-07-13  4:29:24
