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

CREATE TRIGGER after_detallepedidoventas_insert_update 
AFTER INSERT ON gestionrestaurantesdb.detallepedidoventas
FOR EACH ROW
BEGIN
    DECLARE diff INT;
    
    -- Obtener la diferencia entre la cantidad actual y la anterior
    SELECT NEW.Cantidad - COALESCE(OLD.Cantidad, 0) INTO diff;
    
    -- Actualizar el inventario solo si la cantidad no es para un platillo
    IF (SELECT EsPlatillo FROM gestionrestaurantesdb.productos WHERE IDProducto = NEW.IDProducto) = 0 THEN
        -- Si la diferencia es positiva, significa que se agregaron productos
        IF diff > 0 THEN
            UPDATE gestionrestaurantesdb.productos 
            SET Cantidad = Cantidad + diff
            WHERE IDProducto = NEW.IDProducto;
        -- Si la diferencia es negativa, significa que se eliminaron productos
        ELSE
            UPDATE gestionrestaurantesdb.productos 
            SET Cantidad = Cantidad - ABS(diff)
            WHERE IDProducto = NEW.IDProducto;
        END IF;
    END IF;
END;
//

DELIMITER ;


DELIMITER ;


CREATE TRIGGER after_detallepedidocompras_insert
AFTER INSERT ON gestionrestaurantesdb.detallepedidocompras
FOR EACH ROW
BEGIN
    DECLARE diff INT;

    -- La cantidad insertada es la nueva cantidad
    SET diff = NEW.Cantidad;

    -- Actualizar el inventario solo si la cantidad no es para un platillo
    IF (SELECT EsPlatillo FROM gestionrestaurantesdb.productos WHERE IDProducto = NEW.IDProducto) = 0 THEN
        UPDATE gestionrestaurantesdb.productos 
        SET Cantidad = Cantidad + diff,
            CostoUnitario = NEW.Precio -- Actualizar el costo unitario con el nuevo precio y cantidad recibida
        WHERE IDProducto = NEW.IDProducto;
    END IF;
    
    -- Actualizar el precio de compra en la tabla compras
    UPDATE gestionrestaurantesdb.compras
    SET Comentario = NEW.Precio
    WHERE PedidoCompras_IDPedido = NEW.IDPedido;
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


