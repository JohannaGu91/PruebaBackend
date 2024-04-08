-- Procedure consulta cargos
USE `prueba`;
DROP procedure IF EXISTS `prueba`.`ccargos`;
;

DELIMITER $$
USE `prueba`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ccargos`()
BEGIN
	select nombre from cargos
	where activo = true;
END$$

DELIMITER ;
;

-- Procedure consulta departamentos
USE `prueba`;
DROP procedure IF EXISTS `prueba`.`cdepts`;

DELIMITER $$
USE `prueba`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `cdepts`()
BEGIN
	select nombre from departamentos
	where activo = true;
END$$

DELIMITER ;
;


-- Procedure consulta usuarios
USE `prueba`;
DROP procedure IF EXISTS `prueba`.`cusuarios`;

DELIMITER $$
USE `prueba`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `cusuarios`()
BEGIN
	select * from users
	where activo = true;
END$$

DELIMITER ;
;

-- Procedure inserta usuarios
USE `prueba`;
DROP procedure IF EXISTS `prueba`.`iusuarios`;

DELIMITER $$
USE `prueba`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `iusuarios`(
IN e_usuario VARCHAR(255),
IN e_primerNombre VARCHAR(255),
IN e_segundoNombre VARCHAR(255),
IN e_primerApellido VARCHAR(255),
IN e_segundoApellido VARCHAR(255),
IN e_email VARCHAR(255),
IN e_idDepartamento INT,
IN e_idCargo INT
)
BEGIN
	INSERT INTO `prueba`.`users`
	(`usuario`, `primerNombre`, `segundoNombre`, `primerApellido`, `segundoApellido`, `email`, `idDepartamento`, `idCargo`, `activo` )
	VALUES
	(e_usuario, e_primerNombre, e_segundoNombre, e_primerApellido, e_segundoApellido, e_email, e_idDepartamento, e_idCargo, TRUE);

END$$

DELIMITER ;
;

-- Procedure actualiza/elimina usuarios
USE `prueba`;
DROP procedure IF EXISTS `prueba`.`ausuarios`;

DELIMITER $$
USE `prueba`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ausuarios`(
IN e_id INT,
IN e_usuario VARCHAR(255),
IN e_primerNombre VARCHAR(255),
IN e_segundoNombre VARCHAR(255),
IN e_primerApellido VARCHAR(255),
IN e_segundoApellido VARCHAR(255),
IN e_email VARCHAR(255),
IN e_idDepartamento INT,
IN e_idCargo INT,
IN e_activo BOOLEAN
)

BEGIN
	UPDATE `prueba`.`users`
    SET `usuario` = e_usuario, `primerNombre` = e_primerNombre, `segundoNombre` = e_segundoNombre, 
    `primerApellido` = e_primerApellido, `segundoApellido` = e_segundoApellido, `email` = e_email,
    `idDepartamento` = e_idDepartamento, `idCargo` = e_idCargo, `activo` = e_activo
    WHERE id = e_id;

END$$

DELIMITER ;
;


