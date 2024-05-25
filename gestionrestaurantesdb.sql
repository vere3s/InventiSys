-- Schema GestionRestauranteDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `GestionRestauranteDB`;

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`categorias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`categorias` (
  `IDCategoria` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  `EsIngrendiente` TINYINT(1) UNSIGNED ZEROFILL NOT NULL,
  PRIMARY KEY (`IDCategoria`)
  );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`empleados`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`empleados` (
  `IDEmpleado` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(100) NOT NULL,
  `Cargo` VARCHAR(50) NOT NULL,
  `Telefono` VARCHAR(20) NULL DEFAULT NULL,
  `Email` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`IDEmpleado`)
  );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`proveedores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`proveedores` (
  `IDProveedor` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  `Telefono` VARCHAR(45) NULL DEFAULT NULL,
  `Email` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`IDProveedor`)
  );


-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`pedidocompras`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`pedidocompras` (
  `IDPedido` INT NOT NULL AUTO_INCREMENT,
  `FechaPedido` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `Estado` VARCHAR(45) NOT NULL,
  `Comentarios` VARCHAR(200) NULL DEFAULT NULL,
  `IDProveedor` INT NOT NULL,
  PRIMARY KEY (`IDPedido`),
  CONSTRAINT `fk_PedidoVenta_Proveedor1`
    FOREIGN KEY (`IDProveedor`)
    REFERENCES `GestionRestauranteDB`.`proveedores` (`IDProveedor`)
    );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`compras`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`compras` (
  `IDCompras` INT NOT NULL AUTO_INCREMENT,
  `FechaCompra` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `Comentario` VARCHAR(45) NULL DEFAULT NULL,
  `IDPedido` INT NOT NULL,
  `IDEmpleado` INT NOT NULL,
  PRIMARY KEY (`IDCompras`, `IDEmpleado`),
  CONSTRAINT `fk_compras_empleado1`
    FOREIGN KEY (`IDEmpleado`)
    REFERENCES `GestionRestauranteDB`.`empleados` (`IDEmpleado`),
  CONSTRAINT `fk_Compras_PedidoCompras1`
    FOREIGN KEY (`IDPedido`)
    REFERENCES `GestionRestauranteDB`.`pedidocompras` (`IDPedido`)
    );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`productos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`productos` (
  `IDProducto` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  `Precio` DECIMAL(10,2) NOT NULL,
  `CostoUnitario` DECIMAL(10,2) NOT NULL,
  `EsPlatillo` TinyInt(1) ZeroFill NOT NULL ,
  `IDCategoria` INT NOT NULL,
  `Cantidad` INT NOT NULL,
  PRIMARY KEY (`IDProducto`),
  CONSTRAINT `fk_Producto_Categoria1`
    FOREIGN KEY (`IDCategoria`)
    REFERENCES `GestionRestauranteDB`.`categorias` (`IDCategoria`)
    );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`detallepedidocompras`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`detallepedidocompras` (
  `IDDetallePedido` INT NOT NULL AUTO_INCREMENT,
  `IDPedido` INT NOT NULL,
  `IDProducto` INT NOT NULL,
  `Cantidad` DOUBLE(10,2) NOT NULL,
  `Precio` DOUBLE(10,2) NOT NULL,
  PRIMARY KEY (`IDDetallePedido`),
  CONSTRAINT `fk_Detalle_PedidoVenta_PedidoVenta1`
    FOREIGN KEY (`IDPedido`)
    REFERENCES `GestionRestauranteDB`.`pedidocompras` (`IDPedido`),
  CONSTRAINT `fk_Detalle_PedidoVenta_Producto1`
    FOREIGN KEY (`IDProducto`)
    REFERENCES `GestionRestauranteDB`.`productos` (`IDProducto`)
    );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`pedidoventas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`pedidoventas` (
  `IDPedido` INT NOT NULL AUTO_INCREMENT,
  `Cliente` VARCHAR(45) NOT NULL,
  `FechaPedido` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `Estado` VARCHAR(45) NOT NULL,
  `Comentarios` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`IDPedido`)
  );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`detallepedidoventas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`detallepedidoventas` (
  `IDDetallePedido` INT NOT NULL AUTO_INCREMENT,
  `IDPedido` INT NOT NULL,
  `IDProducto` INT NOT NULL,
  `Cantidad` INT NOT NULL,
  `Precio` DOUBLE(10,2) NOT NULL,
  PRIMARY KEY (`IDDetallePedido`),
  CONSTRAINT `fk_Detalle_Pedido_Pedido`
    FOREIGN KEY (`IDPedido`)
    REFERENCES `GestionRestauranteDB`.`pedidoventas` (`IDPedido`),
  CONSTRAINT `fk_Detalle_Pedido_Producto1`
    FOREIGN KEY (`IDProducto`)
    REFERENCES `GestionRestauranteDB`.`productos` (`IDProducto`)
    );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`opciones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`opciones` (
  `IDOpcion` INT NOT NULL AUTO_INCREMENT,
  `Opcion` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`IDOpcion`)
  );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`roles` (
  `IDRol` INT NOT NULL AUTO_INCREMENT,
  `Rol` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`IDRol`)
  );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`permisos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`permisos` (
  `IDPermiso` INT NOT NULL AUTO_INCREMENT,
  `IDROL` INT NOT NULL,
  `IDOpcion` INT NOT NULL,
  PRIMARY KEY (`IDPermiso`),
  CONSTRAINT `permisos_ibfk_1`
    FOREIGN KEY (`IDROL`)
    REFERENCES `GestionRestauranteDB`.`roles` (`IDRol`),
  CONSTRAINT `permisos_ibfk_2`
    FOREIGN KEY (`IDOpcion`)
    REFERENCES `GestionRestauranteDB`.`opciones` (`IDOpcion`)
    );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`usuarios` (
  `IDUsuario` INT NOT NULL AUTO_INCREMENT,
  `Usuario` VARCHAR(100) NOT NULL,
  `Contraseña` VARCHAR(100) NOT NULL,
  `IDEmpleado` INT NOT NULL,
  `IDRol` INT NOT NULL,
  PRIMARY KEY (`IDUsuario`),
  CONSTRAINT `fk_usuario_Rol1`
    FOREIGN KEY (`IDRol`)
    REFERENCES `GestionRestauranteDB`.`roles` (`IDRol`),
  CONSTRAINT `usuario_ibfk_1`
    FOREIGN KEY (`IDEmpleado`)
    REFERENCES `GestionRestauranteDB`.`empleados` (`IDEmpleado`)
    );

-- -----------------------------------------------------
-- Table `GestionRestauranteDB`.`ventas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GestionRestauranteDB`.`ventas` (
  `IDVentas` INT NOT NULL AUTO_INCREMENT,
  `IDPedido` INT NOT NULL,
  `Precio` DOUBLE(10,2) NOT NULL,
  `FechaVenta` DATETIME NOT NULL,
  `IDEmpleado` INT NOT NULL,
  PRIMARY KEY (`IDVentas`),
  CONSTRAINT `fk_ventas_empleado1`
    FOREIGN KEY (`IDEmpleado`)
    REFERENCES `GestionRestauranteDB`.`empleados` (`IDEmpleado`),
  CONSTRAINT `fk_Ventas_Pedido1`
    FOREIGN KEY (`IDPedido`)
    REFERENCES `GestionRestauranteDB`.`pedidoventas` (`IDPedido`)
    );
