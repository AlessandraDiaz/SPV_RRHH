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
    IN P_CODIGO_TIPO INT,
    IN P_FECHA_INICIO DATETIME,
    IN P_FECHA_FIN DATETIME,
    IN P_CODIGO_SOLICITUD INT,
    OUT P_ID INT
)
BEGIN
	INSERT INTO RRHH.tb_convocatoria
    (NOMBRECONVOCATORIA, CODIGOTIPO, FECHAINICIO, FECHAFIN, CODIGOSOLICITUD, FECHACREACION, CODIGOESTADO)
    VALUES
    (P_NOMBRE, P_CODIGO_TIPO, P_FECHA_INICIO, P_FECHA_FIN, P_CODIGO_SOLICITUD, sysdate(), 1);
    
    SET P_ID = LAST_INSERT_ID();
    
    SELECT P_ID;
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
        A.NOMBRECONVOCATORIA NOMBRE,
        A.CODIGOTIPO,
        B.DESCRIPCION TIPOCONVOCATORIA,
        A.FECHAINICIO,
        A.FECHAFIN,
        A.CODIGOSOLICITUD,
        C.CODIGOINTERNO SOLICITUD, /* OJO CAMBIAR AQUÍ POR NOMBRE O DESCRIPCIÓN DE LA SOLICITUD */
        A.FECHACREACION,
        A.CODIGOESTADO,
        D.DESCRIPCION ESTADO
    FROM RRHH.TB_CONVOCATORIA A
    INNER JOIN RRHH.TB_PARAMETROS B
    ON A.CODIGOTIPO = B.PK_CODIGOPARAMETRO
    INNER JOIN RRHH.TB_SOLICITUDPERSONAL C
    ON A.CODIGOSOLICITUD = C.PK_CODIGOSOLICITUD
    INNER JOIN RRHH.TB_PARAMETROS D
    ON A.CODIGOESTADO = D.CODIGO AND D.CODIGOAGRUPADOR = 8
    WHERE
		A.PK_CODIGOCONVOCATORIA = P_ID;
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
	IN P_ID INT,
    IN P_NOMBRE VARCHAR(45),
    IN P_CODIGO_TIPO_CONVOCATORIA INT,
    IN P_FECHA_INICIO DATETIME,
    IN P_FECHA_FIN DATETIME,
    IN P_CODIGO_TIPO_SOLICITUD INT
)
BEGIN
	SET @SQLSTMSELECT = 'SELECT
							A.PK_CODIGOCONVOCATORIA ID,
							A.NOMBRECONVOCATORIA NOMBRE,
							A.CODIGOTIPO,
							B.DESCRIPCION TIPOCONVOCATORIA,
							A.FECHAINICIO,
							A.FECHAFIN,
							A.CODIGOSOLICITUD,
							C.CODIGOINTERNO SOLICITUD, /* OJO CAMBIAR AQUÍ POR NOMBRE O DESCRIPCIÓN DE LA SOLICITUD */
							A.FECHACREACION,
							A.CODIGOESTADO,
							D.DESCRIPCION ESTADO';
	
    SET @SQLSTMFROMWHERE = ' FROM RRHH.TB_CONVOCATORIA A
							INNER JOIN RRHH.TB_PARAMETROS B ON A.CODIGOTIPO = B.PK_CODIGOPARAMETRO
							INNER JOIN RRHH.TB_SOLICITUDPERSONAL C
							ON A.CODIGOSOLICITUD = C.PK_CODIGOSOLICITUD
							INNER JOIN RRHH.TB_PARAMETROS D
							ON A.CODIGOESTADO = D.CODIGO AND D.CODIGOAGRUPADOR = 8
							WHERE
								1 = 1';
                                
	IF P_ID IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND A.PK_CODIGOCONVOCATORIA = ', P_ID);
	END IF;
    
    IF P_NOMBRE IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND A.NOMBRECONVOCATORIA = "',  P_NOMBRE, '"');
	END IF;
    
    IF P_CODIGO_TIPO_CONVOCATORIA IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND A.CODIGOTIPO = ', P_CODIGO_TIPO_CONVOCATORIA);
	END IF;
    
    IF P_FECHA_INICIO IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND DATE_FORMAT(A.FECHAINICIO, "%Y-%m-%d") >= DATE_FORMAT("', P_FECHA_INICIO, '", "%Y-%m-%d")');
	END IF;
    
    IF P_FECHA_FIN IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND DATE_FORMAT(A.FECHAFIN, "%Y-%m-%d") >= DATE_FORMAT("', P_FECHA_FIN, '", "%Y-%m-%d")');
	END IF;
    
    IF P_CODIGO_TIPO_SOLICITUD IS NOT NULL THEN
		SET @SQLSTMFROMWHERE = CONCAT(@SQLSTMFROMWHERE, ' AND A.CODIGOSOLICITUD = ', P_CODIGO_TIPO_SOLICITUD);
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
         C.nombreLocal
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

-- Dump completed on 2016-07-07  8:48:25
