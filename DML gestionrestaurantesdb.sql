INSERT INTO `gestionrestaurantesdb`.`roles` (`IDRol`, `Rol`) VALUES ('1', 'ADMINISTRADOR');
INSERT INTO `gestionrestaurantesdb`.`roles` (`IDRol`, `Rol`) VALUES ('2', 'COCINERO');

INSERT INTO `gestionrestaurantesdb`.`opciones` (`Opcion`) VALUES ('GESTION USUARIOS');
INSERT INTO `gestionrestaurantesdb`.`opciones` (`Opcion`) VALUES ('GESTION PRODUCTOS');

INSERT INTO `gestionrestaurantesdb`.`permisos` (`IDROL`, `IDOpcion`) VALUES ('1', '1');
INSERT INTO `gestionrestaurantesdb`.`permisos` (`IDROL`, `IDOpcion`) VALUES ('2', '2');

INSERT INTO `gestionrestaurantesdb`.`empleados` (`Nombre`, `Cargo`, `Telefono`, `Email`) VALUES ('ANDREA', 'ADMIN', '12345678', 'ANDREA@gmail.com');
INSERT INTO `gestionrestaurantesdb`.`empleados` (`Nombre`, `Cargo`, `Telefono`, `Email`) VALUES ('ESTEFANY', 'COCINERO', '12345678', 'ESTEFANY@gmail.com');

INSERT INTO `gestionrestaurantesdb`.`usuarios` (`Usuario`, `Contraseña`, `IDEmpleado`, `IDRol`) VALUES ('ANDRE2', '12345', '1', '1');
INSERT INTO `gestionrestaurantesdb`.`usuarios` (`Usuario`, `Contraseña`, `IDEmpleado`, `IDRol`) VALUES ('ESTEF2', '12345', '2', '2');

SELECT * FROM gestionrestaurantesdb.usuarios;
update gestionrestaurantesdb.usuarios 
set Contraseña = MD5('12345') 
where IDUsuario = 1;

SELECT * FROM gestionrestaurantesdb.usuarios;
update gestionrestaurantesdb.usuarios 
set Contraseña = MD5('12345') 
where IDUsuario = 2;
DELIMITER //

CREATE TRIGGER actualizar_inventario_detallepedidocompras
AFTER INSERT ON detallepedidocompras
FOR EACH ROW
BEGIN
    -- Actualizar la cantidad disponible en el inventario
    UPDATE productos 
    SET Cantidad = Cantidad + NEW.Cantidad 
    WHERE IDProducto = NEW.IDProducto;
END;
//

DELIMITER ;

DELIMITER //

CREATE TRIGGER actualizar_inventario_detallepedidocompras
AFTER INSERT ON detallepedidocompras
FOR EACH ROW
BEGIN
    DECLARE nueva_cantidad INT;
    
    -- Calcular la nueva cantidad disponible en el inventario después de la compra
    SET nueva_cantidad = (SELECT Cantidad + NEW.Cantidad FROM productos WHERE IDProducto = NEW.IDProducto);

    -- Verificar si la nueva cantidad resultante es positiva
    IF nueva_cantidad >= 0 THEN
        -- Actualizar la cantidad disponible en el inventario
        UPDATE productos 
        SET Cantidad = nueva_cantidad
        WHERE IDProducto = NEW.IDProducto;
    ELSE
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La cantidad disponible en el inventario no puede ser negativa';
    END IF;
END;
//

DELIMITER ;
DELIMITER //

CREATE TRIGGER validar_usuario_y_empleado
BEFORE INSERT ON usuarios
FOR EACH ROW
BEGIN
    DECLARE usuario_existente INT;
    DECLARE empleado_existente INT;

    -- Verificar si el usuario ya existe en otro registro de la tabla usuarios
    SELECT COUNT(*) INTO usuario_existente FROM usuarios WHERE Usuario = NEW.Usuario;

    -- Verificar si el empleado ya está asignado a otro usuario
    SELECT COUNT(*) INTO empleado_existente FROM usuarios WHERE IDEmpleado = NEW.IDEmpleado;

    -- Si el usuario ya existe en otro registro de la tabla usuarios, o el empleado ya está asignado a otro usuario, lanzar una señal de error
    IF usuario_existente > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El usuario ya existe';
    END IF;

    IF empleado_existente > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El empleado ya está asignado a otro usuario';
    END IF;
END;
//

DELIMITER ;


