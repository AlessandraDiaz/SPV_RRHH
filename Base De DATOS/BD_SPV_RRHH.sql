create DATABASE `rrhh`;

/*OK-- MODIFICADO -- 02/07/16 */
CREATE TABLE `rrhh`.`TB_Cargo` (
  `PK_Cargo` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(50) NOT NULL,
  `Funciones` varchar(250) NULL,
  `Requisitos` varchar(250) NULL,
  `SueldoMin` decimal(18,2) NOT NULL,
  `SueldoMax` decimal(18,2) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_Cargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
CREATE TABLE `rrhh`.`TB_Examen` (
  `PK_CodigoExamen` int(11) NOT NULL AUTO_INCREMENT,
  `NombreExamen` varchar(45) NOT NULL,
  `Descripcion` varchar(45) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoExamen`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK -- Modificado -- 02/07/16 */
CREATE TABLE `rrhh`.`TB_Local` (
  `PK_CodigoLocal` int(11) NOT NULL AUTO_INCREMENT,
  `NombreLocal` varchar(45) NOT NULL,
  `Direccion` varchar(100) NOT NULL,
  PRIMARY KEY (`PK_CodigoLocal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
CREATE TABLE `rrhh`.`TB_Contrato` (
  `PK_CodigoContrato` int(11) NOT NULL AUTO_INCREMENT,
  `FechaInicio` date NOT NULL,
  `FechaFin` date NOT NULL,
  `TipoContrato` int(11) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoContrato`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
CREATE TABLE `rrhh`.`TB_PreguntaOpcion` (
  `PK_CodigoOpcion` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoPregunta` int(11) NOT NULL,
  `NombreOpcion` varchar(45) NOT NULL,
  `Correcto` int(11) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoOpcion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
CREATE TABLE `rrhh`.`TB_Turno` (
  `PK_CodigoTurno` int(11) NOT NULL AUTO_INCREMENT,
  `NombreTurno` varchar(45) NOT NULL,
  `HoraInicio` time NOT NULL,
  `HoraFin` time NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
CREATE TABLE `rrhh`.`TB_Preguntaexamen` (
  `PK_CodigoPregunta` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoExamen` int(11) NOT NULL,
  `Pregunta` varchar(45) NOT NULL,
  `Puntaje` int(11) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoPregunta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/* ----------------- MODIFICADO POR EAA --------------------*/
DROP TABLE `rrhh`.`TB_Convocatoria`;
CREATE TABLE `rrhh`.`TB_Convocatoria` (
  `PK_CodigoConvocatoria` int(11) NOT NULL AUTO_INCREMENT,
  `NombreConvocatoria` varchar(45) NOT NULL,
  `CodigoTipo` int(11) NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL,
  `CodigoSolicitud` int(11) NOT NULL,
  `FechaCreacion` datetime NOT NULL,
  `CodigoEstado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoConvocatoria`),
  FOREIGN KEY (CodigoTipo) REFERENCES rrhh.tb_parametros(PK_CODIGOPARAMETRO),
  FOREIGN KEY (CodigoSolicitud) REFERENCES rrhh.tb_solicitudpersonal(PK_CODIGOSOLICITUD),
  FOREIGN KEY (CodigoEstado) REFERENCES rrhh.tb_parametros(PK_CODIGOPARAMETRO)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
CREATE TABLE `rrhh`.`TB_Colaborador` (
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
  `CantidadHijos` int(45) NOT NULL,
  `Seguro` varchar(45) NOT NULL,
  `CodigoEssalud` varchar(45) NOT NULL,
  `Fechacese` datetime NOT NULL,
  `AntecedentePolicial` varchar(100) NOT NULL,
  PRIMARY KEY (`PK_CodigoColaborador`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
CREATE TABLE `rrhh`.`TB_Perfil` (
  `PK_CodigoPerfil` int(11) NOT NULL AUTO_INCREMENT,
  `NombrePerfil` varchar(50) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoPerfil`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK - MODIFICADO -- 02/07/16 */
CREATE TABLE `rrhh`.`TB_SolicitudPersonal` (
  `PK_CodigoSolicitud` INT(11) NOT NULL AUTO_INCREMENT,
  `CodigoInterno` VARCHAR(10) NOT NULL,
  `TipoConvocatoria` INT NOT NULL,
  `TipoSolicitud` INT NOT NULL,
  `Motivo` INT NOT NULL,
  `FechaSolicitud` DATETIME NOT NULL,
  `FechaPresentacion` DATETIME NULL,
  `FechaEnvio` DATETIME NULL,
  `CodigoCampana` INT NULL,
  `FK_CodigoCargo` INT NOT NULL,
  `Moneda` INT NOT NULL,
  `Sueldo` DECIMAL(18,2) NOT NULL,
  `Cantidad` INT NOT NULL,
  `Comentarios` VARCHAR(250) NULL,
  `Estado` INT NOT NULL,
  PRIMARY KEY (`PK_CodigoSolicitud`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*NUEVA TABLA -- 02/07/16 */
CREATE TABLE `rrhh`.`TB_Campana` (
  `PK_CodigoCampana` INT(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` VARCHAR(50) NULL,
  `FechaInicio` DATETIME NULL,
  `FechaFin` DATETIME NULL,
  `Estado` INT NOT NULL,
  PRIMARY KEY (`PK_CodigoCampana`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK -- SE ELIMINO LA TABLA -- 02/07/16 */
 DROP TABLE `rrhh`.`TB_SolicitudPerfil`;
 /*
CREATE TABLE `rrhh`.`TB_SolicitudPerfil` (
  `PK_CodigoSolicitudPerfil` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoSolicitud` int(11) NOT NULL,
  `FK_CodigoPerfil` int(11) NOT NULL,
  `CantidadRequerida` int(11) NOT NULL,
  `Requisitos` varchar(300) NOT NULL,
  `Funciones` varchar(300) NOT NULL,
  `Sueldo` DECIMAL(18,2) NOT NULL,
  PRIMARY KEY (`PK_CodigoSolicitudPerfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
*/

/*OK -- Modificado -- 02/07/16 */
  CREATE TABLE `rrhh`.`TB_Usuario` (
  `PK_CodigoUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `FK_CodigoPerfil` int(11) NOT NULL,
  `FK_CodigoLocal` int NOT NULL,
  `FK_CodigoArea` int NOT NULL,
  `Estado` int NOT NULL,
  PRIMARY KEY (`PK_CodigoUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
 CREATE TABLE `rrhh`.`TB_Area` (
  `PK_CodigoArea` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(100) NOT NULL,
  `Estado` int NOT NULL,
  PRIMARY KEY (`PK_CodigoArea`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*OK*/
 CREATE TABLE `rrhh`.`TB_Parametros` (
  `PK_CodigoParametro` int(11) NOT NULL AUTO_INCREMENT,
  `CodigoAgrupador` int(11) NOT NULL,
  `DesAgrupador` varchar(100) NULL,
  `Codigo` int(11)  NULL,
  `Descripcion` varchar(100)  NULL,
  `Valor` varchar(100)  NULL,
  `Estado` int  NULL,
  PRIMARY KEY (`PK_CodigoParametro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

 CREATE TABLE `rrhh`.`HELP` (
  `TEST` varchar(10000) NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'VARGAS', 'PAUCAR', 'JUAN MANUEL', '40521561', '2011-08-21 14:11:09', 'M', 'AV PASEO DE LA REPUBLICA 3717', '985456855', 'VARGAS.PAUCAR.J@gmail.com', 'CV_40521561.docx', 'S', '0', 'SNP-40521561', 'ESS-40521561', '2011-08-21 14:11:09', 'AP_40521561.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'PINEDA', 'SALAZAR', 'ROSARIO', '41524875', '2011-08-21 14:11:09', 'F', 'CALLE MONTI 112', '963258745', 'PINEDA.SALAZAR.R@gmail.com', 'CV_41524875.docx', 'S', '0', 'SNP-41524875', 'ESS-41524875', '2011-08-21 14:11:09', 'AP_41524875.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'CABELLO', 'SOTO', 'SOFIA', '43215894', '2011-08-21 14:11:09', 'F', 'AV. CENTRAL 1518', '945632587', 'CABELLO.SOTO.S@gmail.com', 'CV_43215894.docx', 'C', '1', 'SNP-43215894', 'ESS-43215894', '2011-08-21 14:11:09', 'AP_43215894.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'SANCHEZ', 'BACA', 'RAUL', '40254156', '2011-08-21 14:11:09', 'M', 'AV. PRIMAVERA 3817', '3258745', 'SANCHEZ.BACA.R@gmail.com', 'CV_40254156.docx', 'S', '1', 'SNP-40254156', 'ESS-40254156', '2011-08-21 14:11:09', 'AP_40254156.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'ALVARADO', 'LOPEZ', 'JOSE', '42515461', '2011-08-21 14:11:09', 'M', 'CALLE 48 5876', '985647124', 'ALVARADO.LOPEZ.J@gmail.com', 'CV_42515461.docx', 'C', '2', 'AFP-42515461', 'ESS-42515461', '2011-08-21 14:11:09', 'AP_42515461.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'PACHAS', 'PACHAS', 'ALEX', '44518597', '2011-08-21 14:11:09', 'M', 'CALLE LAS GARZAS 258', '945135483', 'PACHAS.PACHAS.A@gmail.com', 'CV_44518597.docx', 'C', '1', 'AFP-44518597', 'ESS-44518597', '2011-08-21 14:11:09', 'AP_44518597.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'ROQUE', 'HUARICO', 'ANTONIO', '32154879', '2011-08-21 14:11:09', 'M', 'AV LA MARINA 2330', '978741542', 'ROQUE.HUARICO.A@gmail.com', 'CV_32154879.docx', 'S', '0', 'AFP-32154879', 'ESS-32154879', '2011-08-21 14:11:09', 'AP_32154879.docx');
*/

/*OK -- MODIFICADO -- 02/07/16*/
DELIMITER //
CREATE PROCEDURE rrhh.SP_LOGIN
(IN USUARIO VARCHAR(20),
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
END //;

DELIMITER ;

CALL  SP_LOGIN('ALE', '123');

/*OK -- MODIFICADO -- 02/07/16 */
DELIMITER //
CREATE PROCEDURE rrhh.SPS_SOLICITUD
(IN TIPOFILTRO  INT,	
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
    
END //;

DELIMITER ;

CALL rrhh.SPS_SOLICITUD(0,'', 0, '2016-06-26','2016-06-30', 0, 0,1,0);
select * from tb_usuarios
/*OK -- MODIFICADO -- 02/07/16 */
DELIMITER //
CREATE PROCEDURE rrhh.SPS_SOLICITUDBYID
(IN CODIGO 	INT)
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

END //;

DELIMITER ;

CALL rrhh.SPS_SOLICITUDBYID(1);

/*OK*/
DELIMITER //
CREATE PROCEDURE rrhh.SPS_PARAMETRO
(IN COD_AGRUPADOR INT)
BEGIN
	
    SELECT A.Codigo,
		   A.Descripcion,
           A.Valor,
           A.Estado
    FROM RRHH.tb_parametros A
    WHERE A.CodigoAgrupador = COD_AGRUPADOR;
    
END //;

DELIMITER ;

CALL rrhh.SPS_PARAMETRO(1)

/*OK -- MODIFICADO -- 02/07/16 */
DELIMITER //
CREATE PROCEDURE rrhh.SPI_SOLICITUD
(	IN TIPO_CONV 	INT,
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
END //;

DELIMITER ;

CALL rrhh.SPI_SOLICITUD(1, 1, 1,'2016-06-26', '2016-06-30',1,1,1,1500.50,3,1,1,2,@VAL);
SELECT @VAL;

/*OK -- MODIFICADO -- 02/07/16 */
DELIMITER //
CREATE PROCEDURE rrhh.SPU_SOLICITUD
(	IN CODIGO 		INT,
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
    
END //;

DELIMITER ;

/*OK -- MODIFICADO -- 02/07/16 */
DELIMITER //
CREATE PROCEDURE rrhh.SPD_SOLICITUD
(IN CODIGO INT)
BEGIN
	
    delete from RRHH.tb_solicitudpersonal
    WHERE PK_CODIGOSOLICITUD = CODIGO;
END //;

DELIMITER ;

CALL rrhh.SPD_SOLICITUD (2);

/*OK -- CUS01 -- STORE ELIMINADO --02/07/16 */
DROP PROCEDURE rrhh.SPS_PERFIL_X_SOLICITUD;
/*
DELIMITER //
CREATE PROCEDURE rrhh.SPS_PERFIL_X_SOLICITUD
(IN CODIGO_SOL INT)
BEGIN
	
    SELECT A.PK_CodigoSolicitudPerfil,
		   A.FK_CodigoSolicitud,
		   A.FK_CodigoPerfil,
           p.NOMBREPERFIL,
           A.CantidadRequerida,
           A.Requisitos,
           A.Funciones,
           A.Sueldo
    from RRHH.tb_solicitudperfil A 
    INNER JOIN RRHH.tb_solicitudpersonal B ON A.FK_CODIGOSOLICITUD = B.PK_CodigoSolicitud
    INNER JOIN RRHH.tb_perfil P ON A.FK_CODIGOPERFIL = P.PK_CODIGOPERFIL
    WHERE A.FK_CodigoSolicitud = CODIGO_SOL;
    
END// ;

DELIMITER ;

CALL rrhh.SPS_PERFIL_X_SOLICITUD (1);
*/


/*OK -- CUS01 -- STORE ELIMINADO --02/07/16 */
DROP PROCEDURE rrhh.SPS_PERFIL_X_SOLICITUD_BY_ID;
/*
DELIMITER //
CREATE PROCEDURE rrhh.SPS_PERFIL_X_SOLICITUD_BY_ID
(IN CODIGO INT)
BEGIN
	
    SELECT A.PK_CodigoSolicitudPerfil,
		   A.FK_CodigoSolicitud,
		   A.FK_CodigoPerfil,
           p.NOMBREPERFIL,
           A.CantidadRequerida,
           A.Requisitos,
           A.Funciones,
           A.Sueldo
    from RRHH.tb_solicitudperfil A 
    INNER JOIN RRHH.tb_solicitudpersonal B ON A.FK_CODIGOSOLICITUD = B.PK_CodigoSolicitud
    INNER JOIN RRHH.tb_perfil P ON A.FK_CODIGOPERFIL = P.PK_CODIGOPERFIL
    WHERE A.PK_CodigoSolicitudPerfil = CODIGO;
    
END// ;

DELIMITER ;

call rrhh.SPS_PERFIL_X_SOLICITUD_BY_ID(1);
*/

/*OK -- CUS01 -- STORE ELIMINADO --02/07/16 */
DROP PROCEDURE rrhh.SPI_PERFIL_X_SOLICITUD;
/*
DELIMITER //
CREATE PROCEDURE rrhh.SPI_PERFIL_X_SOLICITUD
(IN CODIGO_SOL INT,
IN CODIGO_PERFIL INT,
IN CANTIDAD INT,
IN REQUISITOS VARCHAR(300),
IN FUNCIONES VARCHAR(300),
IN SUELDO VARCHAR(20),
OUT RESULT INT(11))
BEGIN
	
    INSERT INTO RRHH.tb_solicitudperfil(
		   FK_CodigoSolicitud,
		   FK_CodigoPerfil,
           CantidadRequerida,
           Requisitos,
           Funciones,
           Sueldo) 
   values(
	CODIGO_SOL,
    CODIGO_PERFIL,
    CANTIDAD,
    REQUISITOS,
    FUNCIONES,
    SUELDO);

    SET RESULT = LAST_INSERT_ID();
    
    SELECT RESULT;

END// ;

DELIMITER ;

CALL  rrhh.SPI_PERFIL_X_SOLICITUD (1,1,10,'NIN', 'TODAS', 2000, @VAL);
SELECT @VAL;
*/

/*OK -- CUS01 -- STORE ELIMINADO --02/07/16 */
DROP PROCEDURE rrhh.SPU_PERFIL_X_SOLICITUD;
/*
DELIMITER //
CREATE PROCEDURE rrhh.SPU_PERFIL_X_SOLICITUD
(IN COD_SOLPERFIL INT,
IN CODIGO_SOL INT,
IN CODIGO_PERFIL INT,
IN CANTIDAD INT,
IN REQUISITOS VARCHAR(300),
IN FUNCIONES VARCHAR(300),
IN SUELDO VARCHAR(20)
)
BEGIN
	
    UPDATE RRHH.tb_solicitudperfil
    SET FK_CodigoSolicitud = CODIGO_SOL,
		FK_CodigoPerfil = CODIGO_PERFIL,
        CantidadRequerida = CANTIDAD,
		Requisitos = REQUISITOS,
		Funciones = FUNCIONES,
		Sueldo = SUELDO
	WHERE PK_CodigoSolicitudPerfil = COD_SOLPERFIL;

END// ;

DELIMITER ;

CALL  rrhh.SPU_PERFIL_X_SOLICITUD (5, 1,1,10,'NIN', 'TODAS', 3000);
*/


/*OK -- CUS01 -- STORE ELIMINADO --02/07/16 */
DROP PROCEDURE rrhh.SPD_PERFIL_X_SOLICITUD;
/*
DELIMITER //
CREATE PROCEDURE rrhh.SPD_PERFIL_X_SOLICITUD
(IN CODIGO INT)
BEGIN
	
    delete from RRHH.tb_solicitudperfil
    WHERE PK_CodigoSolicitudPerfil = CODIGO;
    
END //;

DELIMITER ;

CALL rrhh.SPD_PERFIL_X_SOLICITUD (5);
*/

/*OK*/
DELIMITER //
CREATE PROCEDURE rrhh.SPS_PERFIL
(IN DESCRIPCION VARCHAR(50),
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
END //;

DELIMITER ;

CALL rrhh.SPS_PERFIL ('', 0);

/*NUEVO --03/07/16*/
DELIMITER //
CREATE PROCEDURE rrhh.SPS_CARGO
(IN DESCRIPCION VARCHAR(50),
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
END //;

DELIMITER ;

CALL rrhh.SPS_CARGO ('', 0);

/*NUEVO --03/07/16*/
DELIMITER //
CREATE PROCEDURE rrhh.SPS_CAMPANA
(IN DESCRIPCION VARCHAR(50),
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
END //;

DELIMITER ;

CALL rrhh.SPS_CAMPANA ('', 0);

/*NUEVO --06/07/16*/
DELIMITER //
CREATE PROCEDURE rrhh.SPS_COLABORADOR_PERFIL
(IN PERFIL      INT,
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
END //;

DELIMITER ;

CALL rrhh.SPS_COLABORADOR_PERFIL (0, 0);



/* ----------------- INICIO EAA --------------------*/
DELIMITER //
CREATE PROCEDURE RRHH.SPI_CONVOCATORIA
(
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
END //;
DELIMITER ;

DELIMITER //
CREATE PROCEDURE RRHH.SPS_GET_CONVOCATORIA
(
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
END //;
DELIMITER ;


DELIMITER //
CREATE PROCEDURE RRHH.SPS_SEARCH_CONVOCATORIA
(
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
END //;
DELIMITER ;

-- call SPS_SEARCH_CONVOCATORIA(NULL,NULL, null, NULL, NULL, null);

DELIMITER //
CREATE PROCEDURE rrhh.SPS_PARAMETROXCODAGRUPADOR
(IN COD_AGRUPADOR INT)
BEGIN
	
    SELECT A.PK_CodigoParametro Id,
		   A.Descripcion,
           A.Valor,
           A.Estado
    FROM RRHH.tb_parametros A
    WHERE A.CodigoAgrupador = COD_AGRUPADOR;
    
END //;

DELIMITER ;

call SPS_PARAMETROXCODAGRUPADOR(3);

select * from rrhh.tb_colaborador;
SELECT * FROM rrhh.tb_perfil;
SELECT * FROM rrhh.tb_local;
SELECT * FROM rrhh.tb_area;
select * from rrhh.TB_Parametros;
select * from rrhh.TB_CONVOCATORIA;

SELECT * FROM RRHH.tb_usuario;
SELECT * FROM RRHH.tb_colaborador;

select * from tb_solicitudpersonal;

CALL rrhh.SPS_SOLICITUDBYID(1);

select * FROM RRHH.TB_PARAMETROS;
select * FROM RRHH.TB_CAMPANA;
select * FROM RRHH.tb_cargo;
select * FROM RRHH.tb_local;