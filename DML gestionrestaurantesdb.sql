INSERT INTO `GestionRestauranteDB`.`roles` (`IDRol`, `Rol`) VALUES ('1', 'ADMINISTRADOR');
INSERT INTO `GestionRestauranteDB`.`roles` (`IDRol`, `Rol`) VALUES ('2', 'COCINERO');

INSERT INTO `GestionRestauranteDB`.`opciones` (`Opcion`) VALUES ('GESTION USUARIOS');
INSERT INTO `GestionRestauranteDB`.`opciones` (`Opcion`) VALUES ('GESTION PRODUCTOS');

INSERT INTO `GestionRestauranteDB`.`permisos` (`IDROL`, `IDOpcion`) VALUES ('1', '1');
INSERT INTO `GestionRestauranteDB`.`permisos` (`IDROL`, `IDOpcion`) VALUES ('2', '2');

INSERT INTO `GestionRestauranteDB`.`empleados` (`Nombre`, `Cargo`, `Telefono`, `Email`) VALUES ('ANDREA', 'ADMIN', '12345678', 'ANDREA@gmail.com');
INSERT INTO `GestionRestauranteDB`.`empleados` (`Nombre`, `Cargo`, `Telefono`, `Email`) VALUES ('ESTEFANY', 'COCINERO', '12345678', 'ESTEFANY@gmail.com');

INSERT INTO `GestionRestauranteDB`.`usuarios` (`Usuario`, `Contraseña`, `IDEmpleado`, `IDRol`) VALUES ('ANDRE2', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', '1', '1');
INSERT INTO `GestionRestauranteDB`.`usuarios` (`Usuario`, `Contraseña`, `IDEmpleado`, `IDRol`) VALUES ('ESTEF2', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', '2', '2');
DELIMITER //

CREATE TRIGGER after_detallepedidoventas_insert_update 
AFTER INSERT ON detallepedidoventas
FOR EACH ROW
BEGIN
    DECLARE diff INT;

    -- La cantidad insertada es la diferencia a deducir del inventario
    SET diff = NEW.Cantidad;

    -- Actualizar el inventario solo si el producto no es un platillo
    IF (SELECT EsPlatillo FROM productos WHERE IDProducto = NEW.IDProducto) = 0 THEN
        -- Actualizar la cantidad en el inventario
        UPDATE productos 
        SET Cantidad = Cantidad - diff
        WHERE IDProducto = NEW.IDProducto;
    END IF;
END //

DELIMITER //

CREATE TRIGGER after_detallepedidoventas_update 
AFTER UPDATE ON detallepedidoventas
FOR EACH ROW
BEGIN
    DECLARE diff INT;

    -- Calcular la diferencia entre la nueva cantidad y la anterior
    SET diff = NEW.Cantidad - OLD.Cantidad;

    -- Actualizar el inventario solo si el producto no es un platillo
    IF (SELECT EsPlatillo FROM productos WHERE IDProducto = NEW.IDProducto) = 0 THEN
        -- Actualizar la cantidad en el inventario
        UPDATE productos 
        SET Cantidad = Cantidad - diff
        WHERE IDProducto = NEW.IDProducto;
    END IF;
END //

DELIMITER ;
DELIMITER //

CREATE TRIGGER after_detallepedidocompras_insert
AFTER INSERT ON detallepedidocompras
FOR EACH ROW
BEGIN
    DECLARE diff INT;

    -- La cantidad insertada es la cantidad nueva a añadir al inventario
    SET diff = NEW.Cantidad;

    -- Actualizar el inventario solo si el producto no es un platillo
    IF (SELECT EsPlatillo FROM productos WHERE IDProducto = NEW.IDProducto) = 0 THEN
        UPDATE productos 
        SET Cantidad = Cantidad + diff,
            CostoUnitario = NEW.Precio -- Actualizar el costo unitario con el nuevo precio y cantidad recibida
        WHERE IDProducto = NEW.IDProducto;
    END IF;
    
    -- Actualizar el precio de compra en la tabla compras
    UPDATE compras
    SET Comentario = NEW.Precio
    WHERE IDPedido = NEW.IDPedido;
END //

DELIMITER //

CREATE TRIGGER after_detallepedidocompras_update
AFTER UPDATE ON detallepedidocompras
FOR EACH ROW
BEGIN
    DECLARE diff INT;

    -- Calcular la diferencia entre la nueva cantidad y la anterior
    SET diff = NEW.Cantidad - OLD.Cantidad;

    -- Actualizar el inventario solo si el producto no es un platillo
    IF (SELECT EsPlatillo FROM productos WHERE IDProducto = NEW.IDProducto) = 0 THEN
        UPDATE productos 
        SET Cantidad = Cantidad + diff,
            CostoUnitario = NEW.Precio -- Actualizar el costo unitario con el nuevo precio y cantidad recibida
        WHERE IDProducto = NEW.IDProducto;
    END IF;
    
    -- Actualizar el precio de compra en la tabla compras
    UPDATE compras
    SET Comentario = NEW.Precio
    WHERE IDPedido = NEW.IDPedido;
END //

DELIMITER ;
