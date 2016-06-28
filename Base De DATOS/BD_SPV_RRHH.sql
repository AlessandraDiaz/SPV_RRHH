create DATABASE `rrhh`;

CREATE TABLE `rrhh`.`TB_Cargo` (
  `PK_Cargo` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) NOT NULL,
  `Edstado` int(11) NOT NULL,
  PRIMARY KEY (`PK_Cargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `rrhh`.`TB_Examen` (
  `PK_CodigoExamen` int(11) NOT NULL AUTO_INCREMENT,
  `NombreExamen` varchar(45) NOT NULL,
  `Descripcion` varchar(45) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoExamen`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `rrhh`.`TB_Local` (
  `PK_Codigo` int(11) NOT NULL AUTO_INCREMENT,
  `NombreLocal` varchar(45) NOT NULL,
  `Direcion` varchar(100) NOT NULL,
  PRIMARY KEY (`PK_Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `rrhh`.`TB_Contrato` (
  `PK_CodigoContrato` int(11) NOT NULL AUTO_INCREMENT,
  `FechaInicio` date NOT NULL,
  `FechaFin` date NOT NULL,
  `TipoContrato` int(11) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoContrato`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `rrhh`.`TB_PreguntaOpcion` (
  `PK_CodigoOpcion` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoPregunta` int(11) NOT NULL,
  `NombreOpcion` varchar(45) NOT NULL,
  `Correcto` int(11) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoOpcion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `rrhh`.`TB_Turno` (
  `PK_CodigoTurno` int(11) NOT NULL AUTO_INCREMENT,
  `NombreTurno` varchar(45) NOT NULL,
  `HoraInicio` time NOT NULL,
  `HoraFin` time NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `rrhh`.`TB_Preguntaexamen` (
  `PK_CodigoPregunta` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoExamen` int(11) NOT NULL,
  `Pregunta` varchar(45) NOT NULL,
  `Puntaje` int(11) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoPregunta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `rrhh`.`TB_Convocatoria` (
  `PK_CodigoConvocatoria` int(11) NOT NULL AUTO_INCREMENT,
  `NombreConvocatoria` varchar(45) NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL,
  `FechaCreacion` datetime NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoConvocatoria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



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


CREATE TABLE `rrhh`.`TB_Perfil` (
  `PK_CodigoPerfil` int(11) NOT NULL AUTO_INCREMENT,
  `NombrePerfil` varchar(50) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `Estado` int(11) NOT NULL,
  PRIMARY KEY (`PK_CodigoPerfil`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `rrhh`.`TB_SolicitudPersonal` (
  `PK_CodigoSolicitud` INT(11) NULL AUTO_INCREMENT,
  `Descripcion` VARCHAR(100) NOT NULL,
  `FechaSolicitud` DATETIME NOT NULL,
  `TipoSolicitud` INT NOT NULL,
  `Estado` INT NOT NULL,
  PRIMARY KEY (`PK_CodigoSolicitud`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;


  CREATE TABLE `rrhh`.`TB_SolicitudPerfil` (
  `PK_CodigoSolicitudPerfil` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CodigoSolicitud` int(11) NOT NULL,
  `FK_CodigoPerfil` int(11) NOT NULL,
  `CantidadRequerida` int(11) NOT NULL,
  `Requisitos` varchar(300) NOT NULL,
  `Funciones` varchar(300) NOT NULL,
  `Sueldo` varchar(45) NOT NULL,
  PRIMARY KEY (`PK_CodigoSolicitudPerfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

  CREATE TABLE `rrhh`.`TB_Usuario` (
  `PK_CodigoUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `FK_CodigoPerfil` int(11) NOT NULL,
  `FK_Codigo` int NOT NULL,
  `FK_CodigoArea` int NOT NULL,
  `Estado` int NOT NULL,
  PRIMARY KEY (`PK_CodigoUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


 CREATE TABLE `rrhh`.`TB_Area` (
  `PK_CodigoArea` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(100) NOT NULL,
  `Estado` int NOT NULL,
  PRIMARY KEY (`PK_CodigoArea`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'VARGAS', 'PAUCAR', 'JUAN MANUEL', '40521561', '2011-08-21 14:11:09', 'M', 'AV PASEO DE LA REPUBLICA 3717', '985456855', 'VARGAS.PAUCAR.J@gmail.com', 'CV_40521561.docx', 'S', '0', 'SNP-40521561', 'ESS-40521561', '2011-08-21 14:11:09', 'AP_40521561.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'PINEDA', 'SALAZAR', 'ROSARIO', '41524875', '2011-08-21 14:11:09', 'F', 'CALLE MONTI 112', '963258745', 'PINEDA.SALAZAR.R@gmail.com', 'CV_41524875.docx', 'S', '0', 'SNP-41524875', 'ESS-41524875', '2011-08-21 14:11:09', 'AP_41524875.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'CABELLO', 'SOTO', 'SOFIA', '43215894', '2011-08-21 14:11:09', 'F', 'AV. CENTRAL 1518', '945632587', 'CABELLO.SOTO.S@gmail.com', 'CV_43215894.docx', 'C', '1', 'SNP-43215894', 'ESS-43215894', '2011-08-21 14:11:09', 'AP_43215894.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'SANCHEZ', 'BACA', 'RAUL', '40254156', '2011-08-21 14:11:09', 'M', 'AV. PRIMAVERA 3817', '3258745', 'SANCHEZ.BACA.R@gmail.com', 'CV_40254156.docx', 'S', '1', 'SNP-40254156', 'ESS-40254156', '2011-08-21 14:11:09', 'AP_40254156.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'ALVARADO', 'LOPEZ', 'JOSE', '42515461', '2011-08-21 14:11:09', 'M', 'CALLE 48 5876', '985647124', 'ALVARADO.LOPEZ.J@gmail.com', 'CV_42515461.docx', 'C', '2', 'AFP-42515461', 'ESS-42515461', '2011-08-21 14:11:09', 'AP_42515461.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'PACHAS', 'PACHAS', 'ALEX', '44518597', '2011-08-21 14:11:09', 'M', 'CALLE LAS GARZAS 258', '945135483', 'PACHAS.PACHAS.A@gmail.com', 'CV_44518597.docx', 'C', '1', 'AFP-44518597', 'ESS-44518597', '2011-08-21 14:11:09', 'AP_44518597.docx');
INSERT INTO `rrhh`.`tb_colaborador` (`ApellidoPaterno`, `ApellidoMaterno`, `Nombre`, `Dni`, `FechaNacimiento`, `Sexo`, `Direccion`, `Telefono`, `Correo`, `CurriculumVitae`, `EstadoCivil`, `CantidadHijos`, `Seguro`, `CodigoEssalud`, `Fechacese`, `AntecedentePolicial`) VALUES ( 'ROQUE', 'HUARICO', 'ANTONIO', '32154879', '2011-08-21 14:11:09', 'M', 'AV LA MARINA 2330', '978741542', 'ROQUE.HUARICO.A@gmail.com', 'CV_32154879.docx', 'S', '0', 'AFP-32154879', 'ESS-32154879', '2011-08-21 14:11:09', 'AP_32154879.docx');

select * from rrhh.tb_colaborador;
SELECT * FROM rrhh.TB_Usuario;
SELECT * FROM rrhh.tb_perfil;
SELECT * FROM rrhh.tb_local;
SELECT * FROM rrhh.tb_area;
select * from rrhh.TB_Parametros;

DELIMITER //
CREATE PROCEDURE rrhh.SP_LOGIN
(IN USUARIO VARCHAR(20),
 IN PASS  	VARCHAR(20))
BEGIN
  SELECT A.PK_CodigoUsuario, 
		 A.Usuario,
         A.FK_CodigoPerfil,
         A.FK_CodigoArea,
         A.FK_Codigo AS CODIGOLOCAL,
         b.NombrePerfil
  FROM RRHH.tb_usuario A inner join rrhh.tb_perfil b
			on a.FK_CodigoPerfil = b.PK_CodigoPerfil
  WHERE UPPER(A.USUARIO) = UPPER(USUARIO)
  AND A.PASSWORD = PASS;
END //;

DELIMITER ;

DELIMITER //
CREATE PROCEDURE rrhh.SPS_SOLICITUD
(IN DESCRIPCION VARCHAR(50),
 IN TIPOSOLICITUD  	INT)
BEGIN
	SELECT A.PK_CodigoSolicitud,
		   A.Descripcion,
           A.FechaSolicitud,
           A.TipoSolicitud,
           B.Descripcion AS DESTIPOSOLICITUD,
           A.Estado,
           C.Descripcion AS DESC_ESTADO
    FROM RRHH.tb_solicitudpersonal A 
		INNER JOIN rrhh.tb_parametros B ON A.TipoSolicitud = B.CODIGO AND B.CODIGOAGRUPADOR = 1
        INNER JOIN rrhh.tb_parametros C ON A.ESTADO = C.CODIGO AND C.CODIGOAGRUPADOR = 2
    WHERE ((DESCRIPCION = '') OR (UPPER(A.DESCRIPCION) LIKE CONCAT('%', DESCRIPCION , '%')))
    AND ((TIPOSOLICITUD = 0) OR (A.TipoSolicitud = TIPOSOLICITUD));
END //;

DELIMITER ;

CALL rrhh.SPS_SOLICITUD('', 0)

DELIMITER //
CREATE PROCEDURE rrhh.SPS_SOLICITUDBYID
(IN CODIGO 	INT)
BEGIN
	SELECT A.PK_CodigoSolicitud,
		   A.Descripcion,
           A.FechaSolicitud,
           A.TipoSolicitud,
           B.Descripcion AS DESTIPOSOLICITUD,
           A.Estado,
           C.Descripcion AS DESC_ESTADO
    FROM RRHH.tb_solicitudpersonal A 
		INNER JOIN rrhh.tb_parametros B ON A.TipoSolicitud = B.CODIGO AND B.CODIGOAGRUPADOR = 1
        INNER JOIN rrhh.tb_parametros C ON A.ESTADO = C.CODIGO AND C.CODIGOAGRUPADOR = 2
    WHERE A.PK_CodigoSolicitud = CODIGO;
END //;

DELIMITER ;

CALL rrhh.SPS_SOLICITUDBYID(1);

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

DELIMITER //
CREATE PROCEDURE rrhh.SPI_SOLICITUD
(IN DESCRIPCION VARCHAR(50),
IN FECHA datetime,
IN TIPO_SOL INT,
IN ESTADO INT,
OUT RESULT INT(11))
BEGIN
	
    INSERT INTO RRHH.tb_solicitudpersonal (Descripcion, FechaSolicitud, TipoSolicitud, Estado)
    VALUES(DESCRIPCION,FECHA, TIPO_SOL, ESTADO);
    
    SET RESULT = LAST_INSERT_ID();
    
    SELECT RESULT;
END //;

DELIMITER ;

CALL rrhh.SPI_SOLICITUD('SOLICTUD DE PERSONAL 2', '2016-06-26', 1,1, @VAL);
SELECT @VAL;


DELIMITER //
CREATE PROCEDURE rrhh.SPU_SOLICITUD
(IN CODIGO INT,
IN DESCRIPCION VARCHAR(50),
IN FECHA datetime,
IN TIPO_SOL INT,
IN ESTADO INT)
BEGIN
	
    update RRHH.tb_solicitudpersonal A
    SET Descripcion = DESCRIPCION, 
		FechaSolicitud = FECHA, 
        TipoSolicitud = TIPO_SOL, 
        Estado = ESTADO
    WHERE A.PK_CODIGOSOLICITUD = CODIGO;
    
END //;

DELIMITER ;

DELIMITER //
create PROCEDURE rrhh.SPD_SOLICITUD
(IN CODIGO INT)
BEGIN
	
    call rrhh.SPD_PERFIL_X_SOLICITUD(Codigo);
    
    delete from RRHH.tb_solicitudpersonal
    WHERE PK_CODIGOSOLICITUD = CODIGO;
    
END //;

DELIMITER ;

CALL rrhh.SPD_SOLICITUD (2);

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


DELIMITER //
CREATE PROCEDURE rrhh.SPD_PERFIL_X_SOLICITUD
(IN CODIGO INT)
BEGIN
	
    delete from RRHH.tb_solicitudperfil
    WHERE PK_CodigoSolicitudPerfil = CODIGO;
    
END //;

DELIMITER ;

CALL rrhh.SPD_PERFIL_X_SOLICITUD (5);

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

SELECT * FROM RRHH.tb_perfil p;


SELECT * FROM RRHH.tb_parametros;
SELECT * FROM RRHH.tb_solicitudpersonal;
SELECT * FROM RRHH.tb_solicitudperfil;
SELECT * FROM RRHH.TB_PERFIL;

SELECT * FROM RRHH.tb_usuario;
