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